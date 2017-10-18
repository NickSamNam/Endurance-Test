using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;

namespace Server
{
    public static class LogHandler
    {
        private static readonly string AppDataDir = Path.Combine(Environment.GetFolderPath(
            Environment.SpecialFolder.LocalApplicationData,
            Environment.SpecialFolderOption.DoNotVerify), Assembly.GetExecutingAssembly().GetName().Name);

        /// <summary>
        /// Save a log to the appropriate place in the filesystem.
        /// </summary>
        /// <param name="log">The log to save.</param>
        /// <returns>Returns the log's unique id to use when requesting it from storage.</returns>
        public static string SaveLog(string log)
        {
            Directory.CreateDirectory(AppDataDir);
            var logID = "";
            var path = "";
            do
            {
                logID = Guid.NewGuid().ToString("D");
                path = Path.Combine(AppDataDir, logID);
            } while (File.Exists(path));
            File.WriteAllText(path, log);
            return logID;
        }

        // TODO test with networkstream
        public static string CopyFromStream(Stream stream, int messageLength)
        {
            var logID = "";
            var path = "";
            do
            {
                logID = Guid.NewGuid().ToString("D");
                path = Path.Combine(AppDataDir, logID);
            } while (File.Exists(path));

            var schema = JSchema.Parse(JsonSchemaLog);

            try
            {
                using (var s = new StreamReader(stream))
                using (var reader = new JSchemaValidatingReader(new JsonTextReader(s)))
                using (var fs = new FileStream(path, FileMode.Create, FileAccess.Write))
                using (var writer = new StreamWriter(fs))
                {
                    reader.Schema = schema;
                    reader.ValidationEventHandler += (sender, args) => throw new JsonException();

                    while (stream.Position < messageLength && reader.Read())
                    {
                        if (reader.TokenType == JsonToken.StartObject)
                        {
                            // TODO fix read as single chunk
                            writer.WriteLine(JToken.ReadFrom(reader).ToString());
                        }
                    }
                }
            }
            catch (JsonException)
            {
                File.Delete(path);
                throw;
            }

            return logID;
        }

        /// <summary>
        /// Get the stream of a log.
        /// </summary>
        /// <param name="logID">The log's unique identifier.</param>
        /// <returns>Returns the stream of the log, or null if it doesn't exist.</returns>
        public static FileStream GetLogStream(string logID)
        {
            try
            {
                return File.OpenRead(Path.Combine(AppDataDir, logID));
            }
            catch (ArgumentException)
            {
                return null;
            }
            catch (FileNotFoundException)
            {
                return null;
            }
            catch (PathTooLongException)
            {
                return null;
            }
        }

        #region JSON Schema Log

        private const string JsonSchemaLog = @"{
	""type"":""object"",
	""$schema"": ""http://json-schema.org/draft-03/schema"",
	""id"": ""http://jsonschema.net"",
	""required"":true,
	""properties"":{
		""EnduranceTest"": {
			""type"":""object"",
			""id"": ""http://jsonschema.net/EnduranceTest"",
			""required"":true,
			""properties"":{
				""ErgometerLog"": {
					""type"":""array"",
					""id"": ""http://jsonschema.net/EnduranceTest/ErgometerLog"",
					""required"":true,
					""items"":
						{
							""type"":""object"",
							""id"": ""http://jsonschema.net/EnduranceTest/ErgometerLog/0"",
							""required"":true,
							""properties"":{
								""ActualPower"": {
									""type"":""number"",
									""id"": ""http://jsonschema.net/EnduranceTest/ErgometerLog/0/ActualPower"",
									""required"":true
								},
								""Distance"": {
									""type"":""number"",
									""id"": ""http://jsonschema.net/EnduranceTest/ErgometerLog/0/Distance"",
									""required"":true
								},
								""HR"": {
									""type"":""number"",
									""id"": ""http://jsonschema.net/EnduranceTest/ErgometerLog/0/HR"",
									""required"":true
								},
								""RPM"": {
									""type"":""number"",
									""id"": ""http://jsonschema.net/EnduranceTest/ErgometerLog/0/RPM"",
									""required"":true
								},
								""RequestedPower"": {
									""type"":""number"",
									""id"": ""http://jsonschema.net/EnduranceTest/ErgometerLog/0/RequestedPower"",
									""required"":true
								},
								""Speed"": {
									""type"":""number"",
									""id"": ""http://jsonschema.net/EnduranceTest/ErgometerLog/0/Speed"",
									""required"":true
								},
								""Time"": {
									""type"":""number"",
									""id"": ""http://jsonschema.net/EnduranceTest/ErgometerLog/0/Time"",
									""required"":true
								}
							}
						}
					

				},
				""Patient"": {
					""type"":""object"",
					""id"": ""http://jsonschema.net/EnduranceTest/Patient"",
					""required"":true,
					""properties"":{
						""BirthDate"": {
							""type"":""string"",
							""id"": ""http://jsonschema.net/EnduranceTest/Patient/BirthDate"",
							""required"":true
						},
						""FirstName"": {
							""type"":""string"",
							""id"": ""http://jsonschema.net/EnduranceTest/Patient/FirstName"",
							""required"":true
						},
						""LastName"": {
							""type"":""string"",
							""id"": ""http://jsonschema.net/EnduranceTest/Patient/LastName"",
							""required"":true
						}
					}
				},
				""TestResults"": {
					""type"":""object"",
					""id"": ""http://jsonschema.net/EnduranceTest/TestResults"",
					""required"":true,
					""properties"":{
						""VO2Max"": {
							""type"":""number"",
							""id"": ""http://jsonschema.net/EnduranceTest/TestResults/VO2Max"",
							""required"":true
						}
					}
				}
			}
		}
	}
}
";

        #endregion
    }
}
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

//        public static string CopyFromStream(Stream stream)
//        {
//            var schema = JSchema.Parse(JsonSchemaLog);
//            using (var s = new StreamReader(stream))
//            using (var reader = new JSchemaValidatingReader(new JsonTextReader(s)))
//            {
//                // assign schema and setup event handler
//                reader.Schema = schema;
//                reader.ValidationEventHandler += (sender, args) => throw new JsonException();
//
//                // bigdata.json will be validated without loading the entire document into memory
//                while (reader.Read())
//                {
//                }
//            }
//        }

        /// <summary>
        /// Copies the file to the given stream.
        /// </summary>
        /// <param name="logId">The log's unique identifier.</param>
        /// <param name="stream">The stream to copy the file to.</param>
        /// <returns>Returns true if the file was loaded and copied correctly.</returns>
        public static bool CopyToStream(string logId, Stream stream)
        {
            try
            {
                File.OpenRead(Path.Combine(AppDataDir, logId)).CopyTo(stream);
                stream.Flush();
                return true;
            }
            catch (FileNotFoundException)
            {
                return false;
            }
            catch (ArgumentException)
            {
                return false;
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
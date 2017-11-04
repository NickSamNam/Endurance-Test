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
        /// <summary>
        /// The JASON Schema to use while checking an incoming log.
        /// </summary>
        private static readonly JSchema Schema = JSchema.Parse(JsonSchemaLog);

        /// <summary>
        /// The App data local directory for this application.
        /// </summary>
        private static readonly string AppDataDir = Path.Combine(Environment.GetFolderPath(
            Environment.SpecialFolder.LocalApplicationData,
            Environment.SpecialFolderOption.DoNotVerify), Assembly.GetExecutingAssembly().GetName().Name);

        /// <summary>
        /// Save a log from a stream to the filesystem, also validates the data.
        /// </summary>
        /// <param name="stream">The stream where the log is found.</param>
        /// <returns>Returns the log's unique id to use when requesting it from storage.</returns>
        public static string PutFromStream(Stream stream)
        {
            string logID;
            string path;
            do
            {
                logID = Guid.NewGuid().ToString("D");
                path = Path.Combine(AppDataDir, logID);
            } while (File.Exists(path));

            try
            {
                var s = new StreamReader(stream);
                var reader = new JSchemaValidatingReader(new JsonTextReader(s));
                using (var fs = new FileStream(path, FileMode.Create, FileAccess.Write))
                using (var w = new StreamWriter(fs))
                using (var writer = new JsonTextWriter(w))
                {
                    reader.Schema = Schema;
                    reader.ValidationEventHandler += (sender, args) => throw new JsonException();

                    while (reader.Read())
                    {
                        switch (reader.TokenType)
                        {
                            case JsonToken.None:
                                break;
                            case JsonToken.StartObject:
                                writer.WriteStartObject();
                                break;
                            case JsonToken.StartArray:
                                writer.WriteStartArray();
                                break;
                            case JsonToken.StartConstructor:
                                writer.WriteStartConstructor(reader.Value.ToString());
                                break;
                            case JsonToken.PropertyName:
                                writer.WritePropertyName(reader.Value.ToString());
                                break;
                            case JsonToken.Comment:
                                writer.WriteComment(reader.Value.ToString());
                                break;
                            case JsonToken.Raw:
                                writer.WriteRaw(reader.Value.ToString());
                                break;
                            case JsonToken.Integer:
                                writer.WriteValue(reader.Value);
                                break;
                            case JsonToken.Float:
                                writer.WriteValue(reader.Value);
                                break;
                            case JsonToken.String:
                                writer.WriteValue(reader.Value);
                                break;
                            case JsonToken.Boolean:
                                writer.WriteValue(reader.Value);
                                break;
                            case JsonToken.Null:
                                writer.WriteNull();
                                break;
                            case JsonToken.Undefined:
                                writer.WriteUndefined();
                                break;
                            case JsonToken.EndObject:
                                writer.WriteEndObject();
                                break;
                            case JsonToken.EndArray:
                                writer.WriteEndArray();
                                break;
                            case JsonToken.EndConstructor:
                                writer.WriteEndConstructor();
                                break;
                            case JsonToken.Date:
                                writer.WriteValue(reader.Value);
                                break;
                            case JsonToken.Bytes:
                                writer.WriteValue(reader.Value);
                                break;
                            default:
                                throw new ArgumentOutOfRangeException();
                        }
                    }
                }
            }
            catch (JsonException)
            {
                File.Delete(path);
                throw;
            }
            catch (IOException e)
            {
                if (e.HResult != -2146232800)
                {
                    throw;
                }
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
            catch (DirectoryNotFoundException)
            {
                return null;
            }
            catch (UnauthorizedAccessException)
            {
                return null;
            }
            catch (NotSupportedException)
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
						},
						""Mass"": {
							""type"":""number"",
							""id"": ""http://jsonschema.net/EnduranceTest/Patient/Mass"",
							""required"":true
						}
					}
				},
				""TestResults"": {
					""type"":""object"",
					""id"": ""http://jsonschema.net/EnduranceTest/TestResults"",
					""required"":true,
					""properties"":{
						""VO2MaxAbsolute"": {
							""type"":""number"",
							""id"": ""http://jsonschema.net/EnduranceTest/TestResults/VO2MaxAbsolute"",
							""required"":true
						},
                        ""VO2MaxRelative"": {
							""type"":""number"",
							""id"": ""http://jsonschema.net/EnduranceTest/TestResults/VO2MaxRelative"",
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
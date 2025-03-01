using System;
using System.Collections.Generic;
using System.IO;

namespace Helpers
{
    public class Settings
    {
        public static function env(string $pair):string{
            //STEP1: Get the path of .env
            string filePath = Path.combine(Directory.GetCurrentDirectory(),ENV_PATH);

            if (!File.Exists(filePath))
            {
                throw new ReadAndParseEnvException();

            }

            //STEP2:Parse the .env file into a dictionary
            var config = ParseEnvFile(filePath);

            if (config.ContainsKey(pair))
            {
                return config[pair];
            }
            else
            {
                throw new ReadAndParseEnvException();
            }


        }


        private static Dictionary<string, string> ParseEnvFile(string filePath)
        {
            //STEP1: Define dictionary shape
            var config = new Dictionary<string,string>();

            //STEP2: Parse the content of file into dictionary
            try
            {
                foreach (var line in File.ReadLines(filePath))
                {
                    // Skip empty lines and comments
                    if (string.IsNullOrWhiteSpace(line) || line.StartsWith("#"))
                        continue;

                    var parts = line.Split(new[] { '=' }, 2);
                    if (parts.Length == 2)
                    {
                        config[parts[0].Trim()] = parts[1].Trim();
                    }
                }
            }
            catch (Exception)
            {
                throw new ReadAndParseEnvException();
            }

            return config;

        }
    }
}
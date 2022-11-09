using System.Text.Json;

namespace LoggerWithExceptions.Services
{
    // class that is responsible for creating JSON config file if not exists
    // and read directory path from it
    internal static class JsonService
    {
        private static string _configFile = "AppConfig.json";

        // extract directory path from JSON config file that is near .EXE file
        public static string GetDirectoryPath()
        {
            CreateInitialConfigFile();

            string? jsonString = File.ReadAllText(_configFile);
            Config? config = JsonSerializer.Deserialize<Config>(jsonString);

            string? directoryPath = config?.LoggerWithExceptions?.DirectoryPath;

            if (directoryPath is null)
            {
                throw new Exception($"Error! Missing directory from {_configFile}");
            }

            return directoryPath;
        }

        // create initial AppConfig.json near .EXE file if not exist
        private static void CreateInitialConfigFile()
        {
            // Raw string literal (C# 11 feature)
            string jsonString =
                $$"""
            {
              "LoggerWithExceptions": {
                "DirectoryPath": "Logs/"
              }
            }
            """;

            if (File.Exists(_configFile))
            {
                return;
            }

            File.WriteAllText(_configFile, jsonString);
        }

        // main class for hierarchy in JSON
        private class Config
        {
            public LoggerConfig? LoggerWithExceptions { get; set; }
        }

        // secondary class for hierarchy in JSON
        private class LoggerConfig
        {
            public string? DirectoryPath { get; set; }
        }
    }
}

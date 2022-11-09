using LoggerWithExceptions.Services;

namespace LoggerWithExceptions
{
    // Singleton class
    internal class Logger
    {
        private static Logger? _logger;
        private static IService? _consoleService;
        private static IService? _fileService;

        private Logger()
        {
        }

        public static Logger Instance
        {
            get
            {
                if (_logger is null)
                {
                    _logger = new Logger();
                }

                _consoleService = new ConsoleService();
                _fileService = new FileService();

                return _logger;
            }
        }

        // needed in case using another implementation of a console service output
        public IService ConsoleService
        {
            set
            {
                if (value is null)
                {
                    Console.WriteLine("ConsoleService cannot be null. No changes applied");
                }

                _consoleService = value;
            }
        }

        // needed in case using another implementation of a file service output
        public IService FileService
        {
            set
            {
                if (value is null)
                {
                    Console.WriteLine("FileService cannot be null. No changes applied");
                }

                _fileService = value;
            }
        }

        public void PrintToConsole(string data)
        {
            _consoleService?.Print(data);
        }

        public void PrintToFile(string data)
        {
            _fileService?.Print(data);
        }
    }
}

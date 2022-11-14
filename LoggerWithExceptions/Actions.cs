namespace LoggerWithExceptions
{
    internal class Actions
    {
        private Logger _logger;

        public Actions()
        {
            _logger = Logger.Instance;
        }

        public bool InfoAction()
        {
            // formatted string:  "{час_лога}: {тип_лога}: {повідомлення}"
            string data = $"{{{DateTime.Now}}}: {{{LoggerType.Info}}}:    " +
                $"{{Start method: InfoAction}}\n";

            _logger.PrintToFile(data);
            _logger.PrintToConsole(data);

            return true;
        }

        public void WarningAction()
        {
            throw new BusinessException("Skipped logic in method");
        }

        public void ErrorAction()
        {
            throw new Exception("I broke a logic");
        }
    }
}

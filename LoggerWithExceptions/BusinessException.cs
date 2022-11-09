namespace LoggerWithExceptions
{
    internal class BusinessException : Exception
    {
        public BusinessException(string message)
            : base(message)
        {
        }
    }
}

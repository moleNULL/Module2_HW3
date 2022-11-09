namespace LoggerWithExceptions.Services
{
    // Write data on Console
    internal class ConsoleService : IService
    {
        public void Print(string data)
        {
            Console.WriteLine(data);
        }
    }
}

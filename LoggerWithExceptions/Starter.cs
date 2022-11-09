namespace LoggerWithExceptions
{
    internal class Starter
    {
        public static void Run()
        {
            Logger logger = Logger.Instance;
            Actions actions = new Actions();

            Random rand = new Random();

            for (int i = 0; i < 100; i++)
            {
                // Range [1..3]
                int rnd = rand.Next(1, 4);
                string errData = string.Empty;

                try
                {
                    switch (rnd)
                    {
                        case 1:
                            actions.InfoAction();
                            break;
                        case 2:
                            actions.WarningAction(); // throws BusinessException
                            break;
                        case 3:
                            actions.ErrorAction();   // throws Exception
                            break;
                        default:
                            throw new Exception("Incorrect random number. Must be within range 1..3");
                    }
                }
                catch (BusinessException ex)
                {
                    // formatted string:  "{час_лога}: {тип_лога}: {повідомлення}"
                    errData = $"{{{DateTime.Now}}}: {{{LoggerType.Warning}}}: " +
                        $"{{Action got this custom Exception: {ex.Message}}}\n";
                }
                catch (Exception ex)
                {
                    // formatted string:  "{час_лога}: {тип_лога}: {повідомлення}"
                    errData = $"{{{DateTime.Now}}}: {{{LoggerType.Error}}}:   " +
                        $"{{Action failed by reason: {ex}}}\n";
                }
                finally
                {
                    logger.PrintToFile(errData);
                    logger.PrintToConsole(errData);
                }
            }
        }
    }
}

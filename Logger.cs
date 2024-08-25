namespace PetShopQa
{
    public static class Logger
    {
        private static void Log(string level, string message)
        {
            Console.WriteLine($"{level}: {DateTime.Now}" + message);
        }

        public static void LogInfo(string message)
        {
            Log("INFO", message);
        }
        
        public static void LogError(string message)
        {
            Log("ERROR", message);
        }
    }
}
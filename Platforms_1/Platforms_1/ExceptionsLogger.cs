namespace Platforms_1
{
    using System;
    using System.IO;

    public class ExceptionsLogger
    {
        public ExceptionsLogger(string errorMessage)
        {
            using (StreamWriter sw = new StreamWriter("Errors.txt", true, System.Text.Encoding.Default))
            {
                sw.WriteLine(errorMessage);
            }

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($"Error: {errorMessage}");
            Console.ResetColor();
        }
    }
}
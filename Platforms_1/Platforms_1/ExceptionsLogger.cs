namespace Platforms_1
{
    using System;
    using System.IO;

    /// <summary>
    /// Class for recording exceptions.
    /// </summary>
    public class ExceptionsLogger
    {
        /// <summary>
        /// Records exceptions by writing theirs into file and int console.
        /// </summary>
        /// <param name="errorMessage"> Message of exception.</param>
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
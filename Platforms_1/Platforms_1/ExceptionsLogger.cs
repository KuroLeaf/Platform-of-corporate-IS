namespace Platforms_1
{
    using System;
    using System.IO;

    /// <summary>
    /// Class for recording exceptions.
    /// </summary>
    public class ExceptionsLogger: Exception
    {
        /// <summary>
        /// Records exceptions by writing theirs into file and int console.
        /// </summary>
        /// <param name="errorMessage"> Message of exception.</param>
        public ExceptionsLogger(string errorMessage)
            :base(errorMessage)
        {
        }

        /// <summary>
        /// Record exception message in file "Errors.txt".
        /// </summary>
        public void RecordInFile()
        {
            using (StreamWriter sw = new StreamWriter("Errors.txt", true, System.Text.Encoding.Default))
            {
                sw.WriteLine(base.Message);
            }
        }

        /// <summary>
        /// Print exception message on console.
        /// </summary>
        public void PrintOnConsole()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($"Error: {base.Message}");
            Console.ResetColor();
        }
    }
}
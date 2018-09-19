namespace Platforms_1
{
    using System;
    using System.IO;

    /// <summary>
    /// Class with the entry point for the application.
    /// </summary>
    internal class MainClass
    {

        /// <summary>
        /// The entry point for the application.
        /// </summary>
        /// <param name="args"> A list of command line arguments.</param>
        public static void Main(string[] args)
        {
            try
            {
                Task task = new Task();
                task.DoFirstTask();
                task.DoSecondTask();

                Console.ReadKey();
            }
            catch (FileNotFoundException exc)
            {
                Console.WriteLine(exc.Message);
            }
            catch (Exception exc)
            {
                ExceptionsLogger excLoger = new ExceptionsLogger(exc.Message);
            }
        }
    }
}
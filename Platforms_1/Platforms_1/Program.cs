namespace Platforms_1
{
    using System;
    using System.IO;

    internal class MainClass
    {
        public static void Main(string[] args)
        {
            try
            {
                Task task = new Task();
                task.DoFirstTask();

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
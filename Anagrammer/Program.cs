using System;
using System.IO;

namespace Anagrammer
{
    class Program
    {
        static void Main(string[] args)
        {
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

            if (args.Length != 1)
            {
                Console.WriteLine("Invalid arguments!");
                Console.WriteLine(@"I need an argument with the path to the file which contains the words (e.g. c:\words.txt)");
                CloseApp();
                return;
            }

            if (!File.Exists(args[0]))
            {
                Console.WriteLine($"The file '{args[0]}' does not exist");
                CloseApp();
                return;
            }

            string[] wordsInFile = null;

            using (var reader = new StreamReader(args[0]))
            {
                var fileContent = reader.ReadToEnd();
                wordsInFile = fileContent.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            }

            if (wordsInFile.Length == 0)
            {
                Console.WriteLine($"The file '{args[0]}' does not have any content");
                CloseApp();
                return;
            }

            var anagrammer = new Anagrammer(wordsInFile);



            Console.ReadLine();
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Console.WriteLine($"This is embarrassing, i had an exception:");
            Console.WriteLine(e.ExceptionObject.ToString());
            CloseApp();
            return;
        }

        private static void CloseApp()
        {
            Console.WriteLine("Press any key to exit");
            Console.ReadLine();
        }
    }
}

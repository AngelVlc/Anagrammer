using System;
using System.IO;

namespace Anagrammer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Resources.PressAnyKey);

            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

            if (args.Length != 1)
            {
                Console.WriteLine(Resources.InvalidArgs);
                Console.WriteLine(Resources.ArgumentsHelp);
                CloseApp();
                return;
            }

            if (!File.Exists(args[0]))
            {
                Console.WriteLine(string.Format(Resources.FileDoesNotExist, args[0]));
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
                Console.WriteLine(string.Format(Resources.FileIsEmpty, args[0]));
                CloseApp();
                return;
            }

            var anagrammer = new Anagrammer(wordsInFile);

            try
            {
                anagrammer.CheckWords();
            }
            catch (AnagrammerCheckException agEx)
            {
                Console.WriteLine(agEx.Message);
                CloseApp();
                return;
            }

            Console.WriteLine(Resources.FileIsValid);
                      
            Console.ReadLine();
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Console.WriteLine(Resources.UnhandledException);
            Console.WriteLine(e.ExceptionObject.ToString());
            CloseApp();
            return;
        }

        private static void CloseApp()
        {
            Console.WriteLine(Resources.PressAnyKey);
            Console.ReadLine();
        }
    }
}

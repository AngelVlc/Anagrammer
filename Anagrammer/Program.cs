using System;
using System.IO;
using System.Collections.Generic;

namespace Anagrammer
{
    class Program
    {
        static void Main(string[] args)
        {
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


            Console.Write(Resources.ListOptions);
             var key = Console.ReadKey(false);
                

            while (key.KeyChar != '1' && key.KeyChar != '2')
            {
                Console.WriteLine();
                Console.WriteLine(Resources.ListInvalidOption);
                Console.Write(Resources.ListOptions);
                key = Console.ReadKey(false);
            }

            List<string> result = null;

            if (key.KeyChar == '1')
            {
                result = anagrammer.GetAnagramsByWordLength();
            }
            else
            {
                result = anagrammer.GetAnagramsByWordsNumber();
            }

            Console.WriteLine();
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }

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

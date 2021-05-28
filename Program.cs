﻿using System;
using System.Text.RegularExpressions;
using System.Timers;

namespace Task1_probation
{
    class Program
    {
        private static Timer _inputTimer;

        static void Main(string[] args)
        {
            Localization loc = new();

            // determining scopes basic word length
            const int MinWordLenth = 8, MaxWordLenth = 30;

            Console.WriteLine("Select the language of the game, please (выберите язык игры, пожалуйста):\n" +
            "number(число) - 1(en) or(или) - 2(ru)");

            Localization.Language programLanguage;

            do
            {
                try
                {
                    programLanguage = (Localization.Language)Enum.Parse(typeof(Localization.Language), (Console.ReadLine()));

                    if (programLanguage != Localization.Language.en && programLanguage != Localization.Language.ru)
                    {
                        Console.WriteLine("Incorrect input. Try again, please. (Неверный ввод. Попробуйте ещё раз)");

                        continue;
                    }
                    else
                    {
                        break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);

                    continue;
                }
            }
            while (true);

            //_inputTimer = new Timer(5000);

            //_inputTimer.Elapsed += _inputTimer_Elapsed;

            loc.Localize(programLanguage);

            Console.WriteLine(loc.Messages["gameRules"]);

            

            GameStarter gs = new();

            

            Console.WriteLine(loc.Messages["inputMainWord"]);

            while (true)
            {
                gs.MotherWord = Console.ReadLine().ToLower();

                // checking the main word for language and invalid characters
                if (!Regex.IsMatch(gs.MotherWord, loc.Messages["symbolValid"]))
                {
                    Console.WriteLine(loc.Messages["incorrectSymbols"]);

                    continue;
                }
                // checking the main word lenth
                else if (gs.MotherWord.Length > MaxWordLenth || gs.MotherWord.Length < MinWordLenth)
                {
                    Console.WriteLine(loc.Messages["invalidLenth"]);

                    continue;
                }
                else
                {
                    break;
                }
            }



            gs.StartGame();
        }
        // TODO
        // 1. format the code
        // 2. add a timer to track remaining time to answer
        // 3. fix the issue of reading chaaracters after time is over.
        private static void _inputTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            _inputTimer.Stop();
            Console.WriteLine("Your time is over!");
            Console.ReadKey();
            Environment.Exit(0);
        }
    }
}
using System;
using System.Collections.Generic;

namespace Task1probation
{
    class GameStarter
    {
        private Localization Local;

        public GameStarter(Localization loc)
        {
            Local = loc;
        }

        // for saving all entered answers
        private List<string> _allAnswers = new();

        // basic word for compiling responses words
        private string _motherWord;

        public string MotherWord
        {
            get
            {
                return _motherWord;
            }
            set
            {
                _motherWord = value;
            }

        }

        /// <summary>
        /// alternates players' responses
        /// </summary>
        internal void Start(Player pl1, Player pl2)
        {
            string playerName;

            int moveNumber = 1;

            string answerWord;

            bool answerIsValid, answerExists;

            AnswersReceiver ar = new();

            AnswerUniqueness au = new();

            AnswerConditions ac = new();

            // changes the player's number depending on the move number
            while (true)
            {
                if (moveNumber % 2 == 0)
                {
                    playerName = pl1.Name;
                }
                else
                {
                    playerName = pl2.Name;
                }

                Console.WriteLine(Local.Messages["inputAnswer"], playerName);

                answerWord = ar.InputAnswer();

                switch (answerWord)
                {
                    case "/show-words":
                        foreach (string a in _allAnswers)
                        {
                            Console.Write(a + " ");
                        }
                        Console.WriteLine();
                        Console.WriteLine("Нажмите любую кнопку чтобы продолжить");
                        Console.ReadKey();
                        Console.WriteLine();
                        continue;




                }

                answerIsValid = ac.CheckAnswerToConditions(MotherWord, answerWord);

                if (!answerIsValid)
                {
                    Console.WriteLine(Local.Messages["incorrectAnswer"], playerName);
                    Console.ReadKey();
                    break;
                }

                answerExists = au.CheckUniquenessOfAnswer(answerWord, _allAnswers);

                if (answerExists)
                {
                    Console.WriteLine(Local.Messages["repeatingWord"], playerName);
                    Console.ReadKey();
                    break;
                }
                moveNumber++;
            }
        }

    }
}

using System;
using System.Collections.Generic;

namespace Task1_probation
{
    class GameStarter
    {
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
        internal void StartGame()
        {
            string playerName;

            int moveNumber = 1;

            string answerWord;

            bool answerIsValid;

            bool answerExists;

            PlayerNames pl = new();

            List<string> playerNames = pl.GetPlayerName();

            Localization local = new();

            AnswersReceiver ar = new();

            AnswerUniqueness au = new();

            AnswerConditions ac = new();

            // changes the player's number depending on the move number
            while (true)
            {
                if (moveNumber % 2 == 0)
                {
                    playerName = playerNames[1];
                }
                else
                {
                    playerName = playerNames[0];
                }

                Console.WriteLine("Игрок {0}, введите ваш ответ, пожалуйста", playerName);

                answerWord = ar.InputAnswer();

                answerIsValid = ac.CheckAnswerToConditions(MotherWord, answerWord);

                if (!answerIsValid)
                {


                    Console.WriteLine("Ответ не соответствует условию. Игрок {0} проиграл", playerName);

                    Console.ReadKey();

                    break;
                }

                answerExists = au.CheckUniquenessOfAnswer(answerWord, _allAnswers);

                if (answerExists)
                {
                    Console.WriteLine("Это повторяющееся слово. Игрок {0} проиграл", playerName);

                    Console.ReadKey();

                    break;
                }
                moveNumber++;
            }
        }

    }
}

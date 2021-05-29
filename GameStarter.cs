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
        internal void StartGame(string player1Name, string player2Name)
        {
            string playerName;

            int moveNumber = 1;

            string answerWord;

            bool answerIsValid;

            bool answerExists;

            AnswersReceiver ar = new();

            AnswerUniqueness au = new();

            AnswerConditions ac = new();

            // changes the player's number depending on the move number
            while (true)
            {
                if (moveNumber % 2 == 0)
                {
                    playerName = player1Name;
                }
                else
                {
                    playerName = player2Name;
                }

                Console.WriteLine(Local.Messages["inputAnswer"], playerName);

                answerWord = ar.InputAnswer();

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

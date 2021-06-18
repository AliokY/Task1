using System;
using System.Collections.Generic;

namespace Task1probation
{
    class GameStarter : IStarter
    {
        private Localization Local;

        private AnswersReceiver ar = new();

        private AnswerUniqueness au = new();

        private AnswerConditions ac = new();

        private Player pl;

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
        public void Start(List<Player> allPlayersInfo, Player pl1, Player pl2)
        {
            int moveNumber = 1;

            string answerWord;

            bool answerIsValid, answerExists;

            // changes the player's number depending on the move number
            while (true)
            {
                if (moveNumber % 2 == 0)
                {
                    pl = pl1;
                }
                else
                {
                    pl = pl2;
                }
                Console.WriteLine(Local.Messages["inputAnswer"], pl.Name);

                answerWord = ar.InputAnswer();

                switch (answerWord)
                {
                    case "/info":
                        Console.WriteLine(Local.Messages["info"]);
                        continue;

                    case "/show-words":
                        foreach (string a in _allAnswers)
                        {
                            Console.Write(a + " ");
                        }
                        Console.WriteLine();
                        Console.WriteLine(Local.Messages["continue"]);
                        Console.ReadKey();
                        Console.WriteLine();
                        continue;

                    case "/score":

                        List<Player> currentPlayersInfo = pl.GetCurrentPlayerInfo(pl1, pl2);

                        if (currentPlayersInfo.Count == 0)
                        {
                            Console.WriteLine(Local.Messages["currentPlayerNoGames"]);
                            Console.ReadKey();
                            Console.WriteLine();
                        }
                        else
                        {
                            foreach (Player p in currentPlayersInfo)
                            {
                                Console.WriteLine(Local.Messages["playerInfo"], p.Name, p.Wins, p.Defeats);
                            }
                            Console.WriteLine(Local.Messages["continue"]);
                            Console.ReadKey();
                            Console.WriteLine();
                        }
                        continue;

                    case "/total-score":
                        try
                        {
                            allPlayersInfo = pl.GetAllPlayersInfo();
                            foreach (Player p in allPlayersInfo)
                            {
                                Console.WriteLine(Local.Messages["playerInfo"], p.Name, p.Wins, p.Defeats);
                            }
                            Console.WriteLine(Local.Messages["continue"]);
                            Console.ReadKey();
                            Console.WriteLine();
                        }
                        catch
                        {
                            Console.WriteLine(Local.Messages["noCompletedGames"]);
                            Console.ReadKey();
                            Console.WriteLine();
                        }
                        continue;
                }

                answerIsValid = ac.CheckAnswerToConditions(MotherWord, answerWord);

                if (!answerIsValid)
                {
                    pl.CalculateGameResult(pl, pl1, pl2);
                    Console.WriteLine(Local.Messages["incorrectAnswer"], pl.Name);
                    pl.RecordPlayerInfo(allPlayersInfo, pl1, pl2);
                    Console.ReadKey();
                    break;
                }

                answerExists = au.CheckUniquenessOfAnswer(answerWord, _allAnswers);

                if (answerExists)
                {
                    pl.CalculateGameResult(pl, pl1, pl2);
                    pl.RecordPlayerInfo(allPlayersInfo, pl1, pl2);
                    Console.WriteLine(Local.Messages["repeatingWord"], pl.Name);
                    Console.ReadKey();
                    break;
                }
                moveNumber++;
            }
        }
    }
}

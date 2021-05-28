using System;
using System.Collections.Generic;

namespace Task1_probation
{
    class PlayerNames
    {
        private string _playerName;

        internal List<string> GetPlayerName()
        {
            List<string> playerNames = new();

            Localization loc = new();

            int numberOfPlayers = 2;

            for (int i = 1; i <= numberOfPlayers; i++)
            {
                Console.WriteLine("Введите имя {0} игрока, пожалуйста:", i);

                _playerName = Console.ReadLine();

                playerNames.Add(_playerName);
            }

            return playerNames;
        }
    }
}

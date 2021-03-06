using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace Task1probation
{
    [DataContract]
    class Player
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int Wins { get; set; }
        [DataMember]
        public int Defeats { get; set; }

        public Player()
        { }
        public Player(string name)
        {
            Name = name;
        }
        public Player(string name, int wins, int defeats) : this(name)
        {
            Wins = wins;

            Defeats = defeats;
        }

        DataContractJsonSerializer jsonP = new DataContractJsonSerializer(typeof(List<Player>));

        /// <summary>
        /// Get the data of the current players from a .json file
        /// </summary>
        /// <param name="pl1"></param>
        /// <param name="pl2"></param>
        /// <returns></returns>
        internal List<Player> GetCurrentPlayerInfo(Player pl1, Player pl2)
        {
            List<Player> currentPlayersInfo = new();

            using (FileStream fs = new FileStream("GameStatistics.json", FileMode.OpenOrCreate))
            {
                List<Player> allPlayers = (List<Player>)jsonP.ReadObject(fs);
                foreach (Player p in allPlayers)
                {
                    if (p.Name == pl1.Name || p.Name == pl2.Name)
                    {
                        currentPlayersInfo.Add(p);
                    }
                }
            }
            return currentPlayersInfo;
        }

        /// <summary>
        /// Get the data of all players from a .json file
        /// </summary>
        /// <returns></returns>
        internal List<Player> GetAllPlayersInfo()
        {
            List<Player> allPlayersInfo = new();

            using (FileStream fs = new FileStream("GameStatistics.json", FileMode.OpenOrCreate))
            {
                List<Player> allPlayers = (List<Player>)jsonP.ReadObject(fs);
                foreach (Player p in allPlayers)
                {
                    allPlayersInfo.Add(p);
                }
            }
            return allPlayersInfo;
        }

        /// <summary>
        /// Adds the data of the current players to an existing .json file
        /// </summary>
        /// <param name="allPlayers"></param>
        /// <param name="pl1"></param>
        /// <param name="pl2"></param>
        internal void RecordPlayerInfo(List<Player> allPlayers, Player pl1, Player pl2)
        {
            allPlayers.Remove(pl1); allPlayers.Remove(pl2);

            List<Player> twoPlayersInfo = new List<Player>() { pl1, pl2 };

            allPlayers.AddRange(twoPlayersInfo);

            using (FileStream fs = new FileStream("GameStatistics.json", FileMode.OpenOrCreate))
            {
                jsonP.WriteObject(fs, allPlayers);
            }
        }

        /// <summary>
        /// Correction of statistics of current players after the game
        /// </summary>
        /// <param name="pl"></param>
        /// <param name="pl1"></param>
        /// <param name="pl2"></param>
        internal void CalculateGameResult(Player pl, Player pl1, Player pl2)
        {
            if (pl == pl1)
            {
                pl1.Defeats += 1; pl2.Wins += 1;
            }
            else
            {
                pl2.Defeats += 1; pl1.Wins += 1;
            }
        }

        /// <summary>
        /// Updating statistics of current players for previous games
        /// </summary>
        /// <param name="allPlayersInfo"></param>
        /// <param name="pl1"></param>
        /// <param name="pl2"></param>
        internal void AssignPreviousGamesResults(List<Player> allPlayersInfo, Player pl1, Player pl2)
        {
            foreach (Player p in allPlayersInfo)
            {
                if (p.Name == pl1.Name)
                {
                    pl1.Wins = p.Wins; pl1.Defeats = p.Defeats;
                }
                else if (p.Name == pl2.Name)
                {
                    pl2.Wins = p.Wins; pl2.Defeats = p.Defeats;
                }
            }
        }
    }
}
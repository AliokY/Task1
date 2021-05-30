
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;

namespace Task1probation
{
    class Player
    {
        private string name;

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;

            }
        }
        private int wins { get; set; }
        private int defeats { get; set; }

        public Player(string Name)
        {
            this.Name = Name;
        }
        public Player(string Name, int wins, int defeats) : this(Name)
        {
            this.wins = wins;

            this.defeats = defeats;
        }

        DataContractJsonSerializer jsonP = new DataContractJsonSerializer(typeof(Player[]));

        internal List<Player> GetTwoPlayerInfo(Player pl1, Player pl2)
        {
            List<Player> twoPlayersInfo = new();

            using (FileStream fs = new FileStream("GameStatistics.json", FileMode.OpenOrCreate))
            {
                List<Player> allPlayers = (List<Player>)jsonP.ReadObject(fs);
                foreach (Player p in allPlayers)
                {
                    if (p.name == pl1.name || p.name == pl2.name)
                    {
                        twoPlayersInfo.Add(p);
                    }
                }
            }
            return twoPlayersInfo;
        }
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
        internal void RecordPlayerInfo(Player pl1, Player pl2)
        {
            List<Player> twoPlayersInfo = new List<Player>() {pl1, pl2};

            using (FileStream fs = new FileStream("GameStatistics.json", FileMode.OpenOrCreate))
            {
                jsonP.WriteObject(fs, twoPlayersInfo);
            }
        }

    }
}


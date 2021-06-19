using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System;

namespace Task1probation
{

    class Player
    {
        public string Name { get; set; }
        public int Wins { get; set; }
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



        /// <summary>
        /// Get the data of the current players from a .json file
        /// </summary>
        /// <param name="pl1"></param>
        /// <param name="pl2"></param>
        /// <returns></returns>
        internal List<Player> GetCurrentPlayerInfo(Player pl1, Player pl2)
        {
            List<Player> currentPlayersInfo = new();

            using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["PlayersInfo"].ConnectionString))
            {
                sqlConnection.Open();

                if (sqlConnection.State == ConnectionState.Open)
                {
                    Console.WriteLine("Connection established");
                }

                string sql = $"SELECT Name, Wins, Defeats FROM PlayersInfo WHERE Name in (@name1, @name2)";

                SqlCommand command = new SqlCommand(sql, sqlConnection);

                command.Parameters.Add(new SqlParameter("@name1", pl1.Name));
                command.Parameters.Add(new SqlParameter("@name2", pl2.Name));

                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var playerName = reader[0].ToString();

                    if (playerName == pl1.Name)
                    {
                        pl1.Wins = Convert.ToInt32(reader[1]);
                        pl1.Defeats = Convert.ToInt32(reader[2]);
                    }
                    else if (playerName == pl2.Name)
                    {
                        pl2.Wins = Convert.ToInt32(reader[1]);
                        pl2.Defeats = Convert.ToInt32(reader[2]);
                    }
                }

                currentPlayersInfo.Add(pl1);
                currentPlayersInfo.Add(pl2);

                return currentPlayersInfo;
            }
        }
        /// <summary>
        /// Get the data of all players from a .json file
        /// </summary>
        /// <returns></returns>
        internal List<Player> GetAllPlayersInfo()
        {
            List<Player> allPlayersInfo = new();

            using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["PlayersInfo"].ConnectionString))
            {
                sqlConnection.Open();

                if (sqlConnection.State == ConnectionState.Open)
                {
                    Console.WriteLine("Connection established");
                }

                string sql = "SELECT Name, Wins, Defeats FROM PlayersInfo";

                SqlCommand command = new SqlCommand(sql, sqlConnection);

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Player pl = new();

                    pl.Name = reader[0].ToString();
                    pl.Wins = Convert.ToInt32(reader[1]);
                    pl.Defeats = Convert.ToInt32(reader[2]);

                    allPlayersInfo.Add(pl);
                }
                return allPlayersInfo;
            }
        }
        private void AddOrUpdate(Player player)
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["PlayersInfo"].ConnectionString))
            {
                sqlConnection.Open();

                if (sqlConnection.State == ConnectionState.Open)
                {
                    Console.WriteLine("Connectioin established");
                }
                string sql = @"IF EXISTS (SELECT * FROM dbo.PlayersInfo WHERE Name = @name)
                                 UPDATE dbo.PlayersInfo
                                 SET Wins = @wins, Defeats = @defeats
                                 WHERE Name = @name
                               ELSE 
                                 INSERT INTO dbo.PlayersInfo(Name, Wins, Defeats) VALUES (@name, @wins, @defeats)";

                using (SqlCommand cmd = new SqlCommand(sql, sqlConnection))
                {
                    SqlParameter name = new SqlParameter("@name", player.Name);
                    name.SqlDbType = SqlDbType.Char;
                    cmd.Parameters.Add(name);

                    SqlParameter wins = new SqlParameter("@wins", player.Wins);
                    wins.SqlDbType = SqlDbType.Int;
                    cmd.Parameters.Add(wins);

                    SqlParameter defeats = new SqlParameter("@defeats", player.Defeats);
                    defeats.SqlDbType = SqlDbType.Int;
                    cmd.Parameters.Add(defeats);


                    cmd.ExecuteNonQuery();
                }
            }

            // try to get from DB 
            // if exists - update
            // else - add
        }
        /// <summary>
        /// Adds the data of the current players to an existing .json file
        /// </summary>
        /// <param name="allPlayers"></param>
        /// <param name="pl1"></param>
        /// <param name="pl2"></param>
        internal void RecordPlayerInfo(List<Player> allPlayers, Player pl1, Player pl2)
        {
            AddOrUpdate(pl1);
            AddOrUpdate(pl2);
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
                pl1.Defeats += 1;
                pl2.Wins += 1;
            }
            else
            {
                pl2.Defeats += 1;
                pl1.Wins += 1;
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
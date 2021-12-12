using System;
using System.Collections.Generic;

namespace TheProject
{
    class Program
    {
        static List<List<string>> createTeams(int numTeams, int numPlayers)
        {
            var totalTeam = new List<List<string>>();

            for (int i = 0; i < numTeams; i++)
            {

                var playerList = new List<string>();
                Console.WriteLine("Enter the player names for Team " + (i + 1) + ": ");

                for (int j = 0; j < numPlayers; j++)
                {
                    string playerName = Console.ReadLine();
                    playerList.Add(playerName);
                }

                totalTeam.Add(playerList);
            }
            return totalTeam;

        }


        static void Main(string[] args)
        {
            Console.WriteLine("Initialzing Team Generator...");

            Console.WriteLine("How many teams do you want? ");
            int teamNum = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("How many players are on each team? ");
            int playerNum = Convert.ToInt32(Console.ReadLine());

            

            var teams = createTeams(teamNum, playerNum);

            Console.WriteLine(teams);
        }
        
    }


}

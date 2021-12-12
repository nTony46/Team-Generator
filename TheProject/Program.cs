using System;
using System.Collections.Generic;

namespace TheProject
{
    class Program
    {
        /* Function createPlayerList is meant to put all the names of players into a List. 
         * Example w/ (numPlayers = 3):
         * 
         * Jack  => teamList = [Jack]
         * Henry => teamList = [Jack, Henry]
         * John  => teamList = [Jack, Henry, John]
         * 
         * returns teamList
         */
        static List<string> createPlayerList(int numPlayers)
        {
            Console.WriteLine("Enter " + numPlayers + " names: ");

            var playerList = new List<string>(); 
            for (int i = 0; i < numPlayers; i++) 
            {            
                playerList.Add(Console.ReadLine()); 
            }

            return playerList;
        }

        /* Function createTeams is meant to create a numTeams amount of random teams
         * IN PROGRESS -- use rand to generate
         */
        static List<List<string>> createTeams(int numTeams)
        {
            var teamResult = new List<List<string>>();

            for (int i = 0; i < numTeams; i++)
            {

                var playerList = new List<string>();

                for (int j = 0; j < numTeams; j++)
                {
                    string playerName = Console.ReadLine();
                    playerList.Add(playerName);
                }

                teamResult.Add(playerList);
            }
            return teamResult;

        }

        static void Main(string[] args)
        {
            Console.WriteLine("Initialzing Team Generator...");
            int playerNum;
            int teamNum;
            bool check = true;

            do
            {
                Console.WriteLine("How many total players are there? "); 
                playerNum = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("How many teams do you want? ");
                teamNum = Convert.ToInt32(Console.ReadLine());


                if (playerNum % teamNum != 0) // Checks if each time has the same amount of players
                {
                    Console.WriteLine("Teams will not be even. Continue? (y/n) ");
                    if (Console.ReadLine() == "n") check = false;

                    while (Console.KeyAvailable)
                        Console.ReadKey(false); // skips previous input chars. Meant to clear buffer
                }
                else
                {
                    check = true;
                }


            } while(check == false);
            

            //var test = createTeams(teamNum);

            //Console.WriteLine(test);
        }
        
    }


}

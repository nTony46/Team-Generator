using System;
using System.Collections.Generic;

namespace TheProject
{
    class Program
    {
        /* Function createPlayerList is meant to allow user
         * to input all the names of players into a List. 
         * 
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
            Console.WriteLine("Enter " + numPlayers + " names(each on a new line): ");

            var playerList = new List<string>();
            
            for (int i = 0; i < numPlayers; i++) 
            {            
                playerList.Add(Console.ReadLine().ToString()); 
            }

            return playerList;
        }

        /* The function 'shuffle' uses the Fisher-Yates algorithm
         * 
         * It swaps the elements in List allPlayers each iteration, 
         * starting at the end and moving towards the beginning of the List.
         */
        static List<string> shuffle(List<string> allPlayers) 
        {
            var rand = new Random();

            int n = allPlayers.Count;
            while (n > 1)
            {                
                int k = rand.Next(n); 
                n--;

                string temp = allPlayers[k];
                allPlayers[k] = allPlayers[n];
                allPlayers[n] = temp;
            }
            return allPlayers;           
        }

        /* This function is meant to take in the List 'players' and
         * return a newly formatted Nested Lists with the players
         * separated into 'numTeams' amount of teams. 
         * 
         * Example w/ 
         *   players = [Jim, Pam, Gordan, Graham] 
         *   numTeams = 2
         * 
         * returns [[Jim, Pam], [Gordan, Graham]]
         */
        static List<List<string>> createTeamsList(List<string> players, int numTeams)
        {
            var teamResultList = new List<List<string>>();
            int numPlayers = players.Count;
            int playersEachTeam = numPlayers / numTeams;

            int currIndex = 0;
            int lastIndex = numPlayers - 1;

            for (int i = 0; i < numTeams; i++)
            {
                var iterationPlayerList = new List<string>();


                /* This if-statement is for the case of uneven teams.
                 * 
                 * It iterates starting at the end of List 'players' 
                 * and distributes the "remainder players" to the teams first.
                 */
                if (numPlayers % numTeams != 0)
                {
                    iterationPlayerList.Add(players[lastIndex]);
                    lastIndex--;
                    numPlayers--;
                }


                for (int j = 0; j < playersEachTeam; j++)
                {
                    iterationPlayerList.Add(players[currIndex]);
                    currIndex++;
                }

                teamResultList.Add(iterationPlayerList);
            }
            return teamResultList;
        }

        /* Function printTeams takes in a parameter teamList and
         * is prints out the teams in an orderly arangement
         * 
         * Example Output w/ teamList = [[Jim, Pam], [Gordon, Graham]]: 
         * 
         * Team 1:
         *   Jim
         *   Pam
         *   
         * Team 2:
         *   Gordan
         *   Graham
         */
        static void printTeams(List<List<string>> teamList)
        {
            for(int i = 0; i < teamList.Count; i++)
            {
                Console.WriteLine("Team " + (i + 1) + ":");
                for (int j = 0; j < teamList[i].Count; j++)
                {
                    Console.WriteLine("  " + teamList[i][j]);
                }
                Console.WriteLine();
            }
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

                if (playerNum % teamNum != 0)    // Checks if each time has the same amount of players
                {
                    Console.WriteLine("Teams will not be even. Continue? (y/n) ");
                    if (Console.ReadLine() == "n") check = false;    // sets the condition so the do-while loop will rereun

                    while (Console.KeyAvailable) 
                    Console.ReadKey(false);    // Skips previous input chars. Meant to clear buffer.
                }
                else
                {
                    check = true;    // If User continues, sets the condition to true so the do-while loop ends
                }
                
            } while(check == false);
            
            var playerList = createPlayerList(playerNum);
            var shuffledTeam = shuffle(playerList);
            var teamsList = createTeamsList(shuffledTeam, teamNum);

            Console.WriteLine();

            printTeams(teamsList);            
        }        
    }

}

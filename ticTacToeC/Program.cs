// Dusty Shaw
// Created February 13, 2023
// Play Tic Tac Toe against artificial intelligence! 

using System;
using System.IO;

namespace TicTacToe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool endGame = false;
            int turn = 0;
            string[] places = new string[9];
            for (int i = 0; i < places.Length; i++)
            {
                places[i] = $"{i + 1}";
            }
            Console.WriteLine("Welcome to TicTacToe");
            while (endGame == false)
            {
                 Console.WriteLine(PrintBoard(places));
                string playerChar = CheckTurn(turn);

                Console.WriteLine($"Player {turn % 2}: place an {playerChar} in place (1-9)");
                int position = Convert.ToInt32(Console.ReadLine());

                places = PlayTurn(playerChar, position, places);
                Console.WriteLine(PrintBoard(places));
                endGame = CheckWin(places);

                turn++;
                Console.Clear();
                if (endGame == true) { RecordBoard(places, position); }
            }
            Console.WriteLine($"player {((turn - 1) % 2)+1} won!");
        }
        public static string PrintBoard(string[] places)
        {
            return ($@"
                {places[0]} | {places[1]} | {places[2]}
                {places[3]} | {places[4]} | {places[5]}
                {places[6]} | {places[7]} | {places[8]}");
        }
        public static string CheckTurn(int turn)
        {
            return turn % 2 == 0 ? "o" : "x";
        }
        public static string[] PlayTurn(string symbol, int position, string[] places)
        {
            places[position - 1] = symbol;
            return places;
        }
        public static bool CheckWin(string[] places)
        {
            if (places[0] == places[1] && places[1] == places[2])
            {
                return true;
            }
            if (places[3] == places[4] && places[4] == places[5])
            {
                return true;
            }
            if (places[6] == places[7] && places[7] == places[8])
            {
                return true;
            }
            if (places[0] == places[4] && places[4] == places[8])
            {
                return true;
            }
            if (places[2] == places[4] && places[4] == places[6])
            {
                return true;
            }
            if (places[0] == places[3] && places[3] == places[6])
            {
                return true;
            }
            if (places[1] == places[4] && places[4] == places[7])
            {
                return true;
            }
            if (places[2] == places[5] && places[5] == places[8])
            {
                return true;
            }
            return false;
        }

        // When someone wins, the game is recorded.  Along with the string of all places,
        // games are recorded with the position last played.  This position is the winning
        // position.  The AI will then take this information, find similar games, and then
        // play previous winning positions in order to either 1) block the oponent or 
        // 2) win the game. 
        public static void RecordBoard(string[] places, int lastPlay)
        {
            string path = "C:\\Users\\shust\\OneDrive\\Desktop\\ticTacToeC\\ticTacToeC\\records.txt";

            string str = "";
            for (int i = 0; i < places.Length; i++)
            {
                str += places[i];
            }
            str += " " + lastPlay.ToString();
            File.AppendAllText(path, str + Environment.NewLine);
            //var path = "C:\\Users\\shust\\OneDrive\\Desktop\\ticTacToeC\\ticTacToeC\\records.txt";

            //using var sw = new StreamWriter(path);
            //sw.WriteLine(str);
        }

        // AI will check any previously stored games for similiarities to the game being 
        // currently played.  It will choose the most similar one, and play the winning position.
        // The more the game is played, and the more records there are of games,
        // the more intelligently the AI will choose. 
        public static int CheckRecords(string[] places)
        {
            string str = "";
            for (int i = 0; i < places.Length; i++)
            {
                str += places[i];
            }
         
            string path = "C:\\Users\\shust\\OneDrive\\Desktop\\ticTacToeC\\ticTacToeC\\records.txt";
            string[] lines = File.ReadAllLines(path);
            int score = 0;
            int bestPlay = 0;
            for (int i =0; i < lines.Length; i++)
            {
                string line = lines[i];
                char[] plays = new char[line.Length - 2];
                for (int j = 0; j < plays.Length; j++)
                {
                    if (str[j] == line[j])
                    {
                        score++;
                        if (score > bestPlay)
                        {
                            bestPlay = plays[10];
                        }
                    } 
                }
            }
            return bestPlay;
        }

        public static void aiTurn(string[] places)
        {

        }
    }
}
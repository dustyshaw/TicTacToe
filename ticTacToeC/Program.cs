using System;

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
                places[i] = ".";
            }
            while (endGame == false)
            {
                Console.WriteLine("TicTacToe");
                // MakeBoard();
                PrintBoard(places);
                string playerChar = CheckTurn(turn);
                Console.WriteLine($"Player {turn % 2}: place an {playerChar} in place (1-9)");
                int position = Convert.ToInt32(Console.ReadLine());
                places = PlayTurn(playerChar, position, places);
                PrintBoard(places);
                endGame = CheckWin(places);
                turn++;
            }
            Console.WriteLine($"player {(turn - 1) % 2} won!");
        }
        public static string MakeBoard()
        {
            return (@"
                1 | 2 | 3
                4 | 5 | 6
                7 | 8 | 9");
        }
        public static string CheckTurn(int turn)
        {
            if (turn % 2 == 0)
            {
                return "O";
            }
            else
            {
                return "X";
            }
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
            return false;
        }
        public static void PrintBoard(string[] places)
        {
            for (int i = 0; i < places.Length; i++)
            {
                Console.Write(places[i]);
            }
        }
    }
}
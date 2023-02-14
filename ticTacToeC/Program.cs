// Dusty Shaw
// Created February 13, 2023
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
                places[i] = $"{i + 1}";
            }
            while (endGame == false)
            {
                Console.WriteLine("TicTacToe");

                Console.WriteLine(MakeBoard(places));
                string playerChar = CheckTurn(turn);

                Console.WriteLine($"Player {turn % 2}: place an {playerChar} in place (1-9)");
                int position = Convert.ToInt32(Console.ReadLine());

                places = PlayTurn(playerChar, position, places);
                Console.WriteLine(MakeBoard(places));
                endGame = CheckWin(places);

                turn++;
            }
            Console.WriteLine($"player {(turn - 1) % 2} won!");
        }
        public static string MakeBoard(string[] places)
        {
            return ($@"
                {places[0]} | {places[1]} | {places[2]}
                {places[3]} | {places[4]} | {places[5]}
                {places[6]} | {places[7]} | {places[8]}");
        }
        public void updateBoard()
        {

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
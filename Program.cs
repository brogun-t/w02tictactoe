using System;
using System.Collections.Generic;

namespace tictactoe
{
    class Program
    {
        private static void Main(string[] args)
        {
            //creates string to be used as starter board
            List<string> board = GetNewBoard();
            //set first player to be player "X"
            string currentPlayer = "X";
            //while loop to check for winner before proceeding
            while (!IsGameOver(board))
            {
                drawBoard(board);
                
                string numChoice = userResponse(currentPlayer);
                editBoard(board, currentPlayer, numChoice);
                if (!IsGameOver(board))
                {
                    //changes player if the game is not over
                    currentPlayer = changeTurn(currentPlayer);
                }
            }
            drawBoard(board);
    
            //displays message to winner when game is over
            Console.WriteLine($"Game over. The winner is {currentPlayer}!");
        }
        
        
        //function to create a new board
        static List<string> GetNewBoard()
        {
            List<string> board = new List<string>();
            for (int i = 1; i <= 9; i++)
            {
                board.Add(i.ToString());
            }
            return board;
        }
        
        //create a board from given list to be displayed in 3x3
        static void drawBoard(List<string> list)
        {
            Console.WriteLine($"{list.ElementAt(0)}|{list.ElementAt(1)}|{list.ElementAt(2)}");
            Console.WriteLine("-+-+-");
            Console.WriteLine($"{list.ElementAt(3)}|{list.ElementAt(4)}|{list.ElementAt(5)}");
            Console.WriteLine("-+-+-");
            Console.WriteLine($"{list.ElementAt(6)}|{list.ElementAt(7)}|{list.ElementAt(8)}");
        }
        //asks for user input to be used as the number choice in the grid
        static string userResponse(string letter)
            {
                Console.WriteLine($"It is {letter}'s turn. Please choose a number between 1 and 9: ");
                string choice = Console.ReadLine();
                return choice;
            }
        //edits the board to show updated selection
        static void editBoard(List<string> list, string letter, string number)
        {
            int num = int.Parse(number);
            int index = num -1;
            list[index] = letter;
        }
        //decides whose turn it is to go next
        static string changeTurn(string currentPlayer)
        {
            string nextPlayer = "X";
            if (currentPlayer == "X")
            {
                nextPlayer = "O";
            }
            return nextPlayer;
        }
        //returns a new list based on the player's selection
        //static List<string> newList(List<string> oldList, )
        
        //determines if there is a winner
        static bool IsWinner(List<string> board, string player)
        {
            bool isWinner = false;
            
                if ((board[0] == player && board[1] == player && board[2] == player)
                    || (board[3] == player && board[4] == player && board[5] == player)
                    || (board[6] == player && board[7] == player && board[8] == player)
                    || (board[0] == player && board[3] == player && board[6] == player)
                    || (board[1] == player && board[4] == player && board[7] == player)
                    || (board[2] == player && board[5] == player && board[8] == player)
                    || (board[0] == player && board[4] == player && board[8] == player)
                    || (board[2] == player && board[4] == player && board[6] == player)
                    )
                {
                    isWinner = true;
                    Console.WriteLine($"{player} is the winner!");
                }

                return isWinner;
        }
        //determines if the game is over
        static bool IsGameOver(List<string> board)
        {
            bool isGameOver = false;
            
                if (IsWinner(board, "X") || IsWinner(board, "O") || IsTie(board))
                {
                    isGameOver = true;
                }

                return isGameOver;
        }
        
        //determines if there has been a tie
        static bool IsTie(List<string> board)
        {
            bool foundDigit = false;

            foreach (string value in board)
            {
                if (char.IsDigit(value[0]))
                {
                    foundDigit = true;
                    break;
                }
            }

            return !foundDigit;
        }
    }
}
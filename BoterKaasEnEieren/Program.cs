using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoterKaasEnEieren
{
    class Program
    {
        // Playfield while playing
        static char[,] playfield =
        {
            {'1', '2', '3'}, // Row 1
            {'4', '5', '6'}, // Row 2
            {'7', '8', '9'}  // Row 3
        };

        // Variable to check for a draw
        static int turns = 0;

        static void Main(string[] args)
        {
            int player = 2; // player 1 start
            int input = 0;
            bool inputCorrect = true;

            // Keep program active until the program is stopped
            do
            {
                // Check whose turn it is
                if (player == 2)
                {
                    player = 1;
                    XorO(player, input);
                }
                else if(player == 1)
                {
                    player = 2;
                    XorO(player, input);
                }

                SetPlayfield(); // Initialise playfield

                #region
                // Decide who has won
                char[] playerChars = { 'X', 'O' };

                foreach(char playerChar in playerChars)
                {
                     if(((playfield[0,0] == playerChar) && (playfield[0,1] == playerChar) && (playfield[0,2] == playerChar))
                        || ((playfield[1, 0] == playerChar) && (playfield[1, 1] == playerChar) && (playfield[1, 2] == playerChar))
                        || ((playfield[2, 0] == playerChar) && (playfield[2, 1] == playerChar) && (playfield[2, 2] == playerChar))
                        || ((playfield[0, 0] == playerChar) && (playfield[1, 0] == playerChar) && (playfield[2, 0] == playerChar))
                        || ((playfield[0, 1] == playerChar) && (playfield[1, 1] == playerChar) && (playfield[2, 1] == playerChar))
                        || ((playfield[0, 2] == playerChar) && (playfield[1, 2] == playerChar) && (playfield[2, 2] == playerChar))
                        || ((playfield[0, 0] == playerChar) && (playfield[1, 1] == playerChar) && (playfield[2, 2] == playerChar))
                        || ((playfield[0, 2] == playerChar) && (playfield[1, 1] == playerChar) && (playfield[2, 0] == playerChar))
                        )                        
                     {
                        // Write who has won
                        if (playerChar == 'X')
                        {
                            Console.WriteLine("Player 2: Winner winner chicken dinner!");
                        }
                        else
                        {
                            Console.WriteLine("Player 1: Winner winner chicken dinner!");
                        }
                        Console.WriteLine("Press any key to reset the game!");
                        Console.ReadKey();
                        // Reset the playfield
                        ResetPlayfield();

                        break;
                     }
                     // In case there is a draw
                     else if (playerChar == 10)
                     {
                         Console.WriteLine("It's a DRAW!");
                         Console.WriteLine("Press any key to reset the game!");
                         Console.ReadKey();
                         ResetPlayfield();
                         break;
                     }

                }


                #endregion

                #region
                // Check if field is still available
                do
                {
                    Console.WriteLine("\nPlayer {0}: Kies jouw veld! ", player);
                    try
                    {
                        input = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (FormatException)
                    {

                        Console.WriteLine("Please fill in a valid number!");
                    }

                    if ((input == 1) && (playfield[0, 0] == '1'))
                    {
                        inputCorrect = true;
                    }
                    else if ((input == 2) && (playfield[0, 1] == '2'))
                    {
                        inputCorrect = true;
                    }
                    else if ((input == 3) && (playfield[0, 2] == '3'))
                    {
                        inputCorrect = true;
                    }
                    else if ((input == 4) && (playfield[1, 0] == '4'))
                    {
                        inputCorrect = true;
                    }
                    else if ((input == 5) && (playfield[1, 1] == '5'))
                    {
                        inputCorrect = true;
                    }
                    else if ((input == 6) && (playfield[1, 2] == '6'))
                    {
                        inputCorrect = true;
                    }
                    else if ((input == 7) && (playfield[2, 0] == '7'))
                    {
                        inputCorrect = true;
                    }
                    else if ((input == 8) && (playfield[2, 1] == '8'))
                    {
                        inputCorrect = true;
                    }
                    else if ((input == 9) && (playfield[2, 2] == '9'))
                    {
                        inputCorrect = true;
                    }
                    else
                    // In case the chosen field was already filled in
                    {
                        Console.WriteLine("\nWrong field, choose another field!");
                        inputCorrect = false;
                    }
                } while (!inputCorrect);
                #endregion

            } while (true);

        }

        // Show the playfield
        public static void SetPlayfield()
        {
            Console.Clear();
            Console.WriteLine("Tip Tac Toe V1.0");
            Console.WriteLine(" _____ _____ _____");
            Console.WriteLine("|     |     |     |");
            Console.WriteLine("|  {0}  |  {1}  |  {2}  |", playfield[0,0], playfield[0, 1], playfield[0, 2]); // Row 1
            Console.WriteLine("|_____|_____|_____|");
            Console.WriteLine("|     |     |     |");
            Console.WriteLine("|  {0}  |  {1}  |  {2}  |", playfield[1, 0], playfield[1, 1], playfield[1, 2]); // Row 2
            Console.WriteLine("|_____|_____|_____|");
            Console.WriteLine("|     |     |     |");
            Console.WriteLine("|  {0}  |  {1}  |  {2}  |", playfield[2, 0], playfield[2, 1], playfield[2, 2]); // Row 3
            Console.WriteLine("|_____|_____|_____|");
            turns++;
        }

        // Reset function if the game is over
        public static void ResetPlayfield()
        {
            // Initial playfield for the reset (overwrites the current playfield)
            char[,] initialPlayfield =
            {
            {'1', '2', '3'}, // Row 1
            {'4', '5', '6'}, // Row 2
            {'7', '8', '9'}  // Row 3
            };

            playfield = initialPlayfield;
            SetPlayfield();
            turns = 0;
        }

        // Store X or O depending on the player
        public static void XorO(int player, int input)
        {
            char playerIcon = ' ';

            if (player == 1)
            {
                playerIcon = 'X';
            }
            else if (player == 2)
            {
                playerIcon = 'O';
            }

            switch (input)
            {
                case 1: playfield[0, 0] = playerIcon; break;
                case 2: playfield[0, 1] = playerIcon; break;
                case 3: playfield[0, 2] = playerIcon; break;
                case 4: playfield[1, 0] = playerIcon; break;
                case 5: playfield[1, 1] = playerIcon; break;
                case 6: playfield[1, 2] = playerIcon; break;
                case 7: playfield[2, 0] = playerIcon; break;
                case 8: playfield[2, 1] = playerIcon; break;
                case 9: playfield[2, 2] = playerIcon; break;
            }
        }

        // TODO: GUI, LAN, Score tracking & web version
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoterKaasEnEieren
{
    class Program
    {
        // Speelveld tijdens spelen
        static char[,] speelveld =
        {
            {'1', '2', '3'}, // Rij 1
            {'4', '5', '6'}, // Rij 2
            {'7', '8', '9'}  // Rij 3
        };

        // Bijhouden van het aantal zetten om te kijken of er gelijkspel is
        static int aantalZetten = 0;

        static void Main(string[] args)
        {
            int speler = 2; // Speler 1 start
            int input = 0;
            bool inputCorrect = true;

            // Programma blijven draaien zolang er wordt gespeeld
            do
            {
                if (speler == 2)
                {
                    speler = 1;
                    XofO(speler, input);
                }
                else if(speler == 1)
                {
                    speler = 2;
                    XofO(speler, input);
                }

                ZetSpeelveld(); // Speelveld initialisatie

                #region
                // Bepalen of iemand gewonnen heeft
                char[] spelerLetters = { 'X', 'O' };

                foreach(char spelerLetter in spelerLetters)
                {
                     if(((speelveld[0,0] == spelerLetter) && (speelveld[0,1] == spelerLetter) && (speelveld[0,2] == spelerLetter))
                        || ((speelveld[1, 0] == spelerLetter) && (speelveld[1, 1] == spelerLetter) && (speelveld[1, 2] == spelerLetter))
                        || ((speelveld[2, 0] == spelerLetter) && (speelveld[2, 1] == spelerLetter) && (speelveld[2, 2] == spelerLetter))
                        || ((speelveld[0, 0] == spelerLetter) && (speelveld[1, 0] == spelerLetter) && (speelveld[2, 0] == spelerLetter))
                        || ((speelveld[0, 1] == spelerLetter) && (speelveld[1, 1] == spelerLetter) && (speelveld[2, 1] == spelerLetter))
                        || ((speelveld[0, 2] == spelerLetter) && (speelveld[1, 2] == spelerLetter) && (speelveld[2, 2] == spelerLetter))
                        || ((speelveld[0, 0] == spelerLetter) && (speelveld[1, 1] == spelerLetter) && (speelveld[2, 2] == spelerLetter))
                        || ((speelveld[0, 2] == spelerLetter) && (speelveld[1, 1] == spelerLetter) && (speelveld[2, 0] == spelerLetter))
                        )                        
                     {
                        if (spelerLetter == 'X')
                        {
                            Console.WriteLine("Speler 2: Winner winner chicken dinner!");
                        }
                        else
                        {
                            Console.WriteLine("Speler 1: Winner winner chicken dinner!");
                        }
                        Console.WriteLine("Druk op een willekeurige toets om het spel opnieuw te starten!");
                        Console.ReadKey();
                        // Resetten van het speelveld
                        ResetSpeelveld();

                        break;
                     }
                    else if (aantalZetten == 10)
                    {
                        Console.WriteLine("Gelijkspel!");
                        Console.WriteLine("Druk op een willekeurige toets om het spel opnieuw te starten!");
                        Console.ReadKey();
                        ResetSpeelveld();
                        break;
                    }

                }


                #endregion

                #region
                // Checken of het veld al bezet is
                do
                {
                    Console.WriteLine("\nSpeler {0}: Kies jouw veld! ", speler);
                    try
                    {
                        input = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (FormatException)
                    {

                        Console.WriteLine("Voer een getal in niet een letter!");
                    }

                    if ((input == 1) && (speelveld[0, 0] == '1'))
                    {
                        inputCorrect = true;
                    }
                    else if ((input == 2) && (speelveld[0, 1] == '2'))
                    {
                        inputCorrect = true;
                    }
                    else if ((input == 3) && (speelveld[0, 2] == '3'))
                    {
                        inputCorrect = true;
                    }
                    else if ((input == 4) && (speelveld[1, 0] == '4'))
                    {
                        inputCorrect = true;
                    }
                    else if ((input == 5) && (speelveld[1, 1] == '5'))
                    {
                        inputCorrect = true;
                    }
                    else if ((input == 6) && (speelveld[1, 2] == '6'))
                    {
                        inputCorrect = true;
                    }
                    else if ((input == 7) && (speelveld[2, 0] == '7'))
                    {
                        inputCorrect = true;
                    }
                    else if ((input == 8) && (speelveld[2, 1] == '8'))
                    {
                        inputCorrect = true;
                    }
                    else if ((input == 9) && (speelveld[2, 2] == '9'))
                    {
                        inputCorrect = true;
                    }
                    else
                    {
                        Console.WriteLine("\nVerkeerde invoer! Kies een ander veld ");
                        inputCorrect = false;
                    }
                } while (!inputCorrect);
                #endregion

            } while (true);

        }

        public static void ZetSpeelveld()
        {
            Console.Clear();
            Console.WriteLine("Boter, kaas en eieren V1.0");
            Console.WriteLine(" _____ _____ _____");
            Console.WriteLine("|     |     |     |");
            Console.WriteLine("|  {0}  |  {1}  |  {2}  |", speelveld[0,0], speelveld[0, 1], speelveld[0, 2]); // Rij 1 overlay voor daadwerkelijke speelveld
            Console.WriteLine("|_____|_____|_____|");
            Console.WriteLine("|     |     |     |");
            Console.WriteLine("|  {0}  |  {1}  |  {2}  |", speelveld[1, 0], speelveld[1, 1], speelveld[1, 2]); // Rij 2 overlay voor daadwerkelijke speelveld
            Console.WriteLine("|_____|_____|_____|");
            Console.WriteLine("|     |     |     |");
            Console.WriteLine("|  {0}  |  {1}  |  {2}  |", speelveld[2, 0], speelveld[2, 1], speelveld[2, 2]); // Rij 3 overlay voor daadwerkelijke speelveld
            Console.WriteLine("|_____|_____|_____|");
            aantalZetten++;
        }

        public static void ResetSpeelveld()
        {
            // Speelveld start van het spel
            char[,] initieelSpeelveld =
            {
            {'1', '2', '3'}, // Rij 1
            {'4', '5', '6'}, // Rij 2
            {'7', '8', '9'}  // Rij 3
            };

            speelveld = initieelSpeelveld;
            ZetSpeelveld();
            aantalZetten = 0;
        }

        public static void XofO(int speler, int input)
        {
            char spelerIcoon = ' ';

            if (speler == 1)
            {
                spelerIcoon = 'X';
            }
            else if (speler == 2)
            {
                spelerIcoon = 'O';
            }

            switch (input)
            {
                case 1: speelveld[0, 0] = spelerIcoon; break;
                case 2: speelveld[0, 1] = spelerIcoon; break;
                case 3: speelveld[0, 2] = spelerIcoon; break;
                case 4: speelveld[1, 0] = spelerIcoon; break;
                case 5: speelveld[1, 1] = spelerIcoon; break;
                case 6: speelveld[1, 2] = spelerIcoon; break;
                case 7: speelveld[2, 0] = spelerIcoon; break;
                case 8: speelveld[2, 1] = spelerIcoon; break;
                case 9: speelveld[2, 2] = spelerIcoon; break;
            }
        }
    }
}

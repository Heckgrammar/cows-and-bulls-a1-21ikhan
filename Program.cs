using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CowsAndBulls
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Cows and Bulls Starter Framework Code
            int Bulls = 0;
            int TopScore = 1000;
            int Digits = 4;
            int choice = 5;
            bool keepPlaying = true;
            bool viewMenu = true;
            string rules = " If the matching digits are in their right positions, they are bulls, if in different positions, they are cows. Obtain all bulls to win";
            Console.WriteLine(rules);
            while (keepPlaying == true)
            {
                while (viewMenu == true)
                {
                    Console.WriteLine("1- Would you like to play a standard game?");
                    Console.WriteLine("2- Would you like to change the number of digita?");
                    Console.WriteLine("3- Would you like to see your top score?");
                    Console.WriteLine("4- Would you like to quit?");
                    Console.WriteLine("Choose one of these options");
                    viewMenu = false;
                }
                choice = Convert.ToInt32(Console.ReadLine());

                while (choice > 4)
                {
                    Console.WriteLine("Enter a valid choice");
                }
                if (choice == 1)
                {
                    Digits = 4;
                    viewMenu = false;
                }
                else if (choice == 2)
                {
                    Console.WriteLine("How many digits in this game");
                    Digits = Convert.ToInt32(Console.ReadLine());
                    viewMenu = false;
                }
                else if (choice == 3)
                {
                    Console.WriteLine(TopScore);
                    Console.WriteLine("Would you like to go back to menu");
                    string menuchoice = Console.ReadLine();
                    if (menuchoice == "Yes")
                    {
                        viewMenu = true;
                    }
                    else
                    {
                        Console.WriteLine("Bye");
                        keepPlaying = false;
                        break;
                    }

                }
                else if (choice == 4)
                {
                    Console.WriteLine("Bye");
                    keepPlaying = false;
                    break;
                }
                while (viewMenu == false)
                {
                    while (Bulls != Digits)
                    {

                        var rnd = new Random(); // create a new variable called rnd that is random.
                        int Cows = 0;  // starts naming variables
                        int RandomNum = 0;
                        int NumGuesses = 0;
                        string RandomNumSTR = "blank";
                        string GuessSTR = "blank";
                        bool validRandom = true;
                        bool validGuess = true; // variable naming is finished
                        int LowerBound = Convert.ToInt32(Math.Pow(10, Digits - 1)); // finds the minimum value by doing 10 to the power of the number of digits -1 e.g. for 4 digits it will be 10^3=1000
                        int UpperBound = Convert.ToInt32(Math.Pow(10, Digits) - 1); // Does the same but for digits e.g. for 4 digits is 9999
                        validRandom = false;
                        while (!validRandom)
                        {
                            RandomNum = rnd.Next(LowerBound, UpperBound);
                            RandomNumSTR = Convert.ToString(RandomNum);
                            validRandom = true;
                            for (int i = 0; i < Digits; i++)
                            {
                                for (int j = 0; j < Digits; j++)
                                {
                                    if (i != j && RandomNumSTR[i] == RandomNumSTR[j]) // checks if any digits are the same
                                    {
                                        validRandom = false;
                                        break;
                                    }
                                }
                            }
                        }
                        while (Bulls != Digits)
                        {
                            Cows = 0;
                            Bulls = 0;
                            Console.WriteLine("Enter a guess:");
                            int Guess = Convert.ToInt32(Console.ReadLine());
                            GuessSTR = Convert.ToString(Guess);
                            validGuess = true;
                            if (GuessSTR.Length != Digits || GuessSTR[0] == '0')
                            {
                                validGuess = false;
                                Console.WriteLine("Invalid guess. Please try again.");
                                continue;
                            }
                            for (int x = 0; x < Digits; x++)
                            {
                                for (int y = 0; y < Digits; y++)
                                {
                                    if (x != y && GuessSTR[x] == GuessSTR[y])
                                    {
                                        validGuess = false;
                                        break;
                                    }
                                }
                                if (!validGuess) break;
                            }
                            if (!validGuess)
                            {
                                Console.WriteLine("Invalid guess. Please try again.");
                                continue;
                            }
                            for (int a = 0; a < Digits; a++)
                            {
                                for (int b = 0; b < Digits; b++)
                                {
                                    if (a != b && GuessSTR[a] == RandomNumSTR[b])
                                    {
                                        Cows++;
                                    }
                                    else if (GuessSTR[a] == RandomNumSTR[b])
                                    {
                                        Bulls++;
                                    }
                                }
                            }
                            if (Bulls == Digits)
                            {
                                Console.WriteLine("You win, It took " + NumGuesses + " guesses.");
                            }
                            else
                            {
                                NumGuesses++;
                                Console.WriteLine("Cows: " + Cows + ", Bulls: " + Bulls);
                            }
                        }
                        if (TopScore > NumGuesses)
                        {
                            TopScore = NumGuesses;
                        }
                        Console.WriteLine("Would you like to play again? Yes or No");
                        string PlayAgain = Console.ReadLine();
                        if (PlayAgain != "Yes")
                        {
                            Console.WriteLine("Would you like to return to menu");
                            string menuReturn = Console.ReadLine();
                            if (menuReturn == "Yes")
                            {
                                viewMenu = true;
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                        else
                        {
                            Bulls = 0;
                        }
                    }
                }
            }
        }
        }
    }

            
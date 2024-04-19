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
            int Digits = 1;
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
                Console.WriteLine("Welcome to Ibrahim Khan's Cows and Bulls project:");
                Console.WriteLine("Would you like to see your top score? Yes or No");
                string ScoreView = Console.ReadLine();
                if (ScoreView == "Yes")
                {
                    Console.WriteLine(TopScore);
                }
                Console.WriteLine("Would you like to play a standard game? (4 digits) Yes or No");
                string StandardGame = Console.ReadLine();
                if (StandardGame == "Yes")
                {
                    Digits = 4;
                }
                else if (StandardGame == "No")
                {
                    Console.WriteLine("Would you like to play a custom game? Yes or No");
                    string CustomGame = Console.ReadLine();
                    if (CustomGame == "Yes")
                    {
                        Console.WriteLine("How many digits in this game");
                        Digits = Convert.ToInt32(Console.ReadLine());
                    }
                    else if (CustomGame == "No")
                    {
                        Console.WriteLine("Goodbye, since you do not want to play.");
                        break;
                    }
                }
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
                    Console.WriteLine("Bye!");
                    break;
                }
                Bulls = 0;
            }
        }
    }
}
            
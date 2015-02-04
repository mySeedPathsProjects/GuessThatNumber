using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessThatNumber
{
    public class Program
    {
        static Random rng = new Random();

        //this is the number the user needs to guess.  Set its value in your code using a RNG.
        static int NumberToGuess = 0;
        //the number the user will input as their guess
        static int UsersNumber = 0;
        //counts number of guesses it took to win
        static int NumberOfGuesses = 0;



        static void Main(string[] args)
        {
            Console.WriteLine(@"
I'm choosing a number between 1 and 100...
Can you guess what that number is?
Enter a number between 1 and 100:");

            RunGame();

            //Console.ReadKey();
          
        }

        public static void RunGame()
        {
            NumberToGuess = rng.Next(1, 101);

           
            Console.WriteLine(NumberToGuess);


            while (UsersNumber != NumberToGuess)
            {
                string input = Console.ReadLine();

                if (ValidateInput(input))
                {
                    UsersNumber = Convert.ToInt32(input);

                    if (IsGuessTooHigh(UsersNumber))
                    {
                        if (Math.Abs(UsersNumber - NumberToGuess) >= 5)
                        {
                            TooHighFar();
                        }
                        else
                        {
                            TooHighClose();
                        }
                    }
                    else if (IsGuessTooLow(UsersNumber))
                    {
                        if (Math.Abs(UsersNumber - NumberToGuess) >= 5)
                        {
                            TooLowFar();
                        }
                        else
                        {
                            TooLowClose();
                        }
                    }
                }
            }
            if (NumberOfGuesses == 0)
            {
                Console.WriteLine("Amazing!! It only took you 1 guess!!");
            }
            else
            {
                Console.WriteLine("FINALLY!!!");
                Console.WriteLine("It took you {0} guesses", NumberOfGuesses + 1);
            }
            Console.WriteLine();
            Console.WriteLine("Do you want to play again? Press Y or N");
            if (Console.ReadLine().ToUpper() == "Y")
            {
                NumberOfGuesses = 0;
                Console.WriteLine();
                Console.WriteLine("Well...start picking a number:");
                RunGame();
            }
        }
        
        public static bool ValidateInput(string userInput)
        {
            //check to make sure that the users input is a valid number between 1 and 100.
            if (userInput.All(char.IsDigit))
            {
                int inputNumber = Convert.ToInt32(userInput);
                if (inputNumber >= 1 && inputNumber <= 100)
                {
                    return true; 
                }
            }
            Console.WriteLine("That number does not compute, please try again:");

            return false;
        }

        public static void SetNumberToGuess(int number)
        {
            //TODO: make this function override your global variable holding the number the user needs to guess.  This is used only for testing methods.
        }

        public static bool IsGuessTooHigh(int userGuess)
        {
            //TODO: return true if the number guessed by the user is too high
            if (userGuess > NumberToGuess)
            {
                NumberOfGuesses++;
                return true;
            }
            return false;
        }

        public static void TooHighFar()
        {
            string[] bigHigh = { "Come on man, LOWER!", "Seriously? Much lower", "Gotta go way down" };
            Console.WriteLine(bigHigh[rng.Next(3)]);
        }

        public static void TooHighClose()
        {
            string[] smallHigh = { "Just a wee bit lower!", "Down just a touch", "A smidge lower" };
            Console.WriteLine(smallHigh[rng.Next(3)]);
        }


        public static bool IsGuessTooLow(int userGuess)
        {
            //TODO: return true if the number guessed by the user is too low
            if (userGuess < NumberToGuess)
            {
                NumberOfGuesses++;
                return true;
            }
            return false;
        }

        public static void TooLowFar()
        {
            string[] bigLow = { "Come on man, HIGHER!", "Seriously? Much higher", "Gotta go way up" };
            Console.WriteLine(bigLow[rng.Next(3)]);
        }

        public static void TooLowClose()
        {
            string[] smallLow = { "Just a wee bit higher!", "Up just a touch", "A smidge higher" };
            Console.WriteLine(smallLow[rng.Next(3)]);
        }
    }
}

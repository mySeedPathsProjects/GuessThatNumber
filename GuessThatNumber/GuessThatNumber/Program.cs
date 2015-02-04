using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessThatNumber
{
    public class Program
    {
        //creat random number generator to be used globally in program
        static Random rng = new Random();
        //this is the number the user needs to guess.  Set its value in your code using a RNG.
        static int NumberToGuess = 0;
        //the number the user will input as their guess
        static int UsersNumber = 0;
        //counts number of guesses it took to win
        static int NumberOfGuesses = 0;
        //range between user input and rng number, used for feedback statements
        static int GuessAccuracy = 0;



        static void Main(string[] args)
        {
            //choose GuessAccuracy
            GuessAccuracy = 5;
            //begin game with brief instructions, only to run once
            Console.WriteLine(@"
I'm choosing a number between 1 and 100...
Can you guess what that number is?
Enter a number between 1 and 100:");
            //run the game
            RunGame();
          
        }

        /// <summary>
        /// Game function, holds code to run game
        /// </summary>
        public static void RunGame()
        {
            //randomly generate a number to guess
            NumberToGuess = rng.Next(1, 101);

            //*** Only used to show number computer randomly generated for testing purposes
            //Console.WriteLine(NumberToGuess);

            //while user not correctly guessing the generated number
            while (UsersNumber != NumberToGuess)
            {
                //number user inputs
                string input = Console.ReadLine();
                //check to see if it's a numerical digit(s) between 1 and 100
                if (ValidateInput(input))
                {
                    //if valid convert from string to integer
                    UsersNumber = Convert.ToInt32(input);
                    //if input number is too high
                    if (IsGuessTooHigh(UsersNumber))
                    {
                        //input is 5 or more numbers too high from generated number
                        if (Math.Abs(UsersNumber - NumberToGuess) > GuessAccuracy)
                        {
                            TooHighAndFar();
                        }
                            //if number within 4 digits away
                        else
                        {
                            TooHighButClose();
                        }
                    }
                    //if input number is too low
                    else if (IsGuessTooLow(UsersNumber))
                    {
                        //input is 5 or more numbers too low from generated number
                        if (Math.Abs(UsersNumber - NumberToGuess) > GuessAccuracy)
                        {
                            TooLowAndFar();
                        }
                            //if number within 4 digits away
                        else
                        {
                            TooLowButClose();
                        }
                    }
                }
            }
            //when user guesses the correct number
            //if user guesses correctly the first try, print to screen...
            if (NumberOfGuesses == 0)
            {
                Console.WriteLine("Amazing!! It only took you 1 guess!!");
            }
            else
            {
                //increase count by 1 for final correct guess
                NumberOfGuesses++;
                Console.WriteLine();
                Console.WriteLine("FINALLY!!!");
                Console.WriteLine("It took you {0} guesses.  Well Done!", NumberOfGuesses);
            }
            Console.WriteLine();

            //ask user if they want to play again
            //input "Y" or "y" to play again.  any other input will close game
            Console.WriteLine("Do you want to play again? Press Y or N");
            if (Console.ReadLine().ToUpper() == "Y")
            {
                //reset counter
                NumberOfGuesses = 0;
                Console.WriteLine();
                Console.WriteLine("Go ahead...start guessing the number:");
                RunGame();
            }
        }
        
        /// <summary>
        /// Verifies input is a numerical digit(s) between 1 and 100
        /// </summary>
        /// <param name="userInput">number the user input</param>
        /// <returns>true if input is a number</returns>
        public static bool ValidateInput(string userInput)
        {
            //check to make sure that the users input is a numerical digit between 1 and 100.
            if (userInput.All(char.IsDigit) && userInput != string.Empty)
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

        /// <summary>
        /// used only for testing
        /// </summary>
        /// <param name="number">input done with test program</param>
        public static void SetNumberToGuess(int number)
        {
            NumberToGuess = number;
            //TODO: make this function override your global variable holding the number the user needs to guess.  This is used only for testing methods.
        }

        /// <summary>
        /// Checks if user's guess is too high
        /// </summary>
        /// <param name="userGuess">user's input number</param>
        /// <returns>true if too high</returns>
        public static bool IsGuessTooHigh(int userGuess)
        {
            //TODO: return true if the number guessed by the user is too high
            if (userGuess > NumberToGuess)
            {
                //increase counter if number too high
                NumberOfGuesses++;
                return true;
            }
            return false;
        }
        /// <summary>
        /// If user input significantly too high
        /// </summary>
        public static void TooHighAndFar()
        {
            //randomly choose response from array
            string[] bigHigh = { "Come on man, LOWER!", "Seriously? Much lower", "Gotta go way down" };
            Console.WriteLine(bigHigh[rng.Next(3)]);
        }
        /// <summary>
        /// if user input too high, but close
        /// </summary>
        public static void TooHighButClose()
        {
            //randomly choose response from array
            string[] smallHigh = { "Just a wee bit lower!", "Down just a touch", "A smidge lower" };
            Console.WriteLine(smallHigh[rng.Next(3)]);
        }


        /// <summary>
        /// Checks if user's guess is too low
        /// </summary>
        /// <param name="userGuess">user's input number</param>
        /// <returns>true if too low</returns>
        public static bool IsGuessTooLow(int userGuess)
        {
            //TODO: return true if the number guessed by the user is too low
            if (userGuess < NumberToGuess)
            {
                //increase counter if number too low
                NumberOfGuesses++;
                return true;
            }
            return false;
        }
        /// <summary>
        /// If user input significantly too low
        /// </summary>
        public static void TooLowAndFar()
        {
            //randomly choose response from array
            string[] bigLow = { "Come on man, HIGHER!", "Seriously? Much higher", "Gotta go way up" };
            Console.WriteLine(bigLow[rng.Next(3)]);
        }
        /// <summary>
        /// If user input too low, but close
        /// </summary>
        public static void TooLowButClose()
        {
            //randomly choose response from array
            string[] smallLow = { "Just a wee bit higher!", "Up just a touch", "A smidge higher" };
            Console.WriteLine(smallLow[rng.Next(3)]);
        }
    }
}

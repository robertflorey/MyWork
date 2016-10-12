using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessingGame
{
    public class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int answer = random.Next(1, 21);
            List<string> previousGuesses = new List<string>();
            string userGuess;
            string response;
            int countGuess = 0;
            Console.WriteLine("Please enter name");
            string userName = Console.ReadLine();
            while (userName == "")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Please enter a name!!");
                userName = Console.ReadLine();
                Console.ResetColor();
            }

            do
            {
                Console.WriteLine("{0} please guess a number between 1 and 20.", userName);
                userGuess = Console.ReadLine();
                if (userGuess == "q")
                {
                    break;
                }
                else
                {
                    if (previousGuesses.Contains(userGuess))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("{0}, you already guessed that number", userName);
                        response = "";
                        Console.ResetColor();
                    }
                    else
                    {
                        GuessCheck checking = new GuessCheck();
                        response = checking.GuessChecker(userGuess, answer);
                        if(response== "invalid number please try again.")
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("{0}, {1}", userName, response);
                            Console.ResetColor();
                        }
                        else if(response== "guess was too high."||response== "guess was too low.")
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine("{0}, {1}", userName, response);
                            Console.ResetColor();
                            previousGuesses.Add(userGuess);
                            ++countGuess;
                        }
                        else
                        {
                            previousGuesses.Add(userGuess);
                            ++countGuess;
                        }
                    }
                }
            
            } while (response != "congratulations!" );
            if(userGuess=="q")
            {
                Console.WriteLine("{0}, thanks for playing.", userName);
            }
            else if (countGuess == 1)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Best Guesser {0}", userName);
                Console.ResetColor();
                previousGuesses.ForEach(Console.WriteLine);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Congratulations {1}! It took {0} guesses.", countGuess, userName);
                Console.ResetColor();
                previousGuesses.ForEach(Console.WriteLine);
            }
            
            Console.ReadKey();
        }
    }
}

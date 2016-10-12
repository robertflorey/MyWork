using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GuessingGame
{
    public class GuessCheck
    {
        private int answer;

        public GuessCheck(int answer)
        {
            this.answer = answer;
        }
        public string Guess(int guess)
        {
            string response;
            
            if(guess==answer)
            {
                response = "congratulations!";
                return response;
            }
            else if (guess < 1 || guess > 20)
            {
                response= "invalid number please try again.";
                return response;
            }
            else if (guess>answer)
            {
                response = "guess was too high.";
                return response;
            }
            else
            {
                response = "guess was too low.";
                return response;
            }
        }
    }
}

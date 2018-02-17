using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CIS115CourseProject
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            // set to random word
            Random random = new Random((int)DateTime.Now.Ticks);

            // set words to guess
            string[] wordBank = { "Roman", "Student", "DeVry", "Course", "Project"};

            string guessWord = wordBank[random.Next(0, wordBank.Length)];
            string wordIsUpperCase = guessWord.ToUpper();

            // set the builder to display how many letter are there
            StringBuilder displayUser = new StringBuilder(guessWord.Length);
            for (int i = 0; i < guessWord.Length; i++)
            {
                displayUser.Append('*');
            }

            // set if the workd correct or not
            List<char> correctGuesses = new List<char>();
            List<char> incorrectGuesses = new List<char>();

            // set the variables
            int setLives = 10;
            bool setCondition = false;
            int lettersRevealed = 0;
            string setInput;
            char setGuess;

            Console.Write("Welcome to HangMan! \n");
            Console.Write("You have " + setLives + " lives for this game \n");

            // loop until User guess the word
            while (!setCondition && setLives > 0)
            {
                Console.Write("Please enter the letter please: ");

                setInput = Console.ReadLine().ToUpper();
                setGuess = setInput[0];

                // if letter was used more then one 
                if (correctGuesses.Contains(setGuess))
                {
                    Console.WriteLine("You used this letter and it's was correct: '{0}'!", setGuess);
                    continue;
                }
                else if (incorrectGuesses.Contains(setGuess))
                {
                    Console.WriteLine("You used this letter and it's was incorrect: '{0}'!", setGuess);
                    continue;
                }

                // check if the word case is right, in case, if user set uppercase
                if (wordIsUpperCase.Contains(setGuess))
                {
                    correctGuesses.Add(setGuess);

                    for (int i = 0; i < guessWord.Length; i++)
                    {
                        if (wordIsUpperCase[i] == setGuess)
                        {
                            displayUser[i] = guessWord[i];
                            lettersRevealed++;
                        }
                    }

                    Console.WriteLine("Good job, we have this letter '{0}'", setGuess);
                    Console.WriteLine("You have " + setLives + " lives");

                    setCondition |= lettersRevealed == guessWord.Length;
                }
                else
                {
                    incorrectGuesses.Add(setGuess);

                    Console.WriteLine("Nope, there's no '{0}' in it!", setGuess);
                    setLives--;

                    Console.WriteLine("You have " + setLives + " lives left");
                }

                Console.WriteLine(displayUser.ToString());
            }
            // set condition of true or false if user win or lost
            if (setCondition)
            {
                Console.WriteLine("Congratilations! You have figure out the word! Your score is: " + setLives);
            }
            else 
            {
                Console.WriteLine("You lost! It was '{0}'", guessWord); 
            } 
        }
    }
}

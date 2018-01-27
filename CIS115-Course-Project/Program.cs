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
            string guessWord = "roman";
            string wordIsUpperCase = guessWord.ToUpper();

            // set the builder to display how many letter are there
            StringBuilder displayUser = new StringBuilder(guessWord.Length);
            for (int i = 0; i < guessWord.Length; i++)
            {
                displayUser.Append('_');
            }

            // set if the workd correct or not
            List<char> correctGuesses = new List<char>();
            List<char> incorrectGuesses = new List<char>();

            // set the variables
            int setLives = 5;
            bool setCondition = false;
            int lettersRevealed = 0;

            string setInput;
            char setGuess;

            while (!setCondition && setLives > 0)
            {
                Console.Write("Enter the letter please: ");

                setInput = Console.ReadLine().ToUpper();
                setGuess = setInput[0];

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

                    setCondition |= lettersRevealed == guessWord.Length;
                }
                else
                {
                    incorrectGuesses.Add(setGuess);

                    Console.WriteLine("Nope, there's no '{0}' in it!", setGuess);
                    setLives--;
                }

                Console.WriteLine(displayUser.ToString());
            }

            if (setCondition)
                Console.WriteLine("Congratilations! You have figure out the word! Your score is: " + setLives);
            else
                Console.WriteLine("You lost! It was '{0}'", guessWord);
        }
    }
}

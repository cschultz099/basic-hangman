using System;
using System.Collections.Generic;

namespace hangman
{
    public class Program
    {
        private List<string> words = ["apple", "Supercalifragilisticexpialidocious", "elder", "salt", "crash", "sonic", "nuclear war", "wordle"];
        private string randomWord = "";
        private List<string> usedLetters = [];
        private char[] currentGuess;

        public static void Main()
        {
            Program program = new Program();
            program.SetupGame();

            while (true)
            {
                string input = Console.ReadLine() ?? string.Empty;
                program.GuessLetter(input);
            }
        }

        public void GenerateRandomWord()
        {
            Random random = new();
            int indx = random.Next(words.Count);
            randomWord = words[indx];
            currentGuess = new string('_', randomWord.Length).ToCharArray();
        }

        public void GuessLetter(string letter)
        {
            if (letter.Length == 1 && char.IsLetter(letter[0]))
            {
                if (!usedLetters.Contains(letter))
                {
                    usedLetters.Add(letter);

                    if (randomWord.Contains(letter))
                    {
                        Console.WriteLine("Correct Letter!");
                        FindLetter(letter);
                        DisplayCurrentGuess();
                    }
                    else
                    {
                        Console.WriteLine("Incorrect Letter.");
                    }
                }
                else
                {
                    Console.WriteLine("You have already used this letter.");
                }
            }
            else
            {
                Console.Write("Invalid Input.");
            }
        }

        public void FindLetter(string letter)
        {
            for (int i = 0; i < randomWord.Length; i++)
            {
                if (randomWord[i].ToString().Equals(letter, StringComparison.OrdinalIgnoreCase))
                {
                    currentGuess[i] = randomWord[i];
                }
            }
        }

        public void SetupGame()
        {
            GenerateRandomWord();

            Console.WriteLine("Welcome to hangman. Get one wrong and you die... Just kidding. You have 6 tries before I blow up the moon :3\n");
            Console.WriteLine($"Your word has {randomWord.Length} characters\n");

            Console.WriteLine("  +----+");
            Console.WriteLine("  |    |");
            Console.WriteLine("       |");
            Console.WriteLine("       |");
            Console.WriteLine("       |");
            Console.WriteLine("       |");
            Console.WriteLine(" ========\n");

            DisplayCurrentGuess();
        }

        public void DisplayCurrentGuess()
        {
            foreach (char c in currentGuess)
            {
                Console.Write(c + " ");
            }
            Console.WriteLine();
        }
    }
}
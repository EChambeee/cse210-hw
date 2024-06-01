using System;
using System.Collections.Generic;
using System.Linq;

namespace ScriptureMemorization
{
    class Program
    {
        static void Main(string[] args)
        {
            var program = new ScriptureMemorizationProgram();
            program.Run();
        }
    }

    public class ScriptureMemorizationProgram
    {
        private List<Scripture> scriptures;
        private Scripture currentScripture;
        private Random random;

        public ScriptureMemorizationProgram()
        {
            scriptures = LoadScriptures();
            random = new Random();
            currentScripture = scriptures[random.Next(scriptures.Count)];
        }

        public void Run()
        {
            while (true)
            {
                ClearScreen();
                Console.WriteLine(currentScripture);
                Console.WriteLine("\nPress enter to continue or type 'quit' to finish:");
                var input = Console.ReadLine();
                if (input.ToLower() == "quit")
                {
                    break;
                }
                if (!currentScripture.AllWordsHidden())
                {
                    currentScripture.HideRandomWords(3); 
                }
                else
                {
                    break;
                }
            }
        }

        private void ClearScreen()
        {
            Console.Clear();
        }

        private List<Scripture> LoadScriptures()
        {
            return new List<Scripture>
            {
                new Scripture(new Reference("John", 3, 16), "For God so loved the world that he gave his only begotten Son, that whoever believeth in him should not perish, but have everlating life."),
                new Scripture(new Reference("Proverbs", 3, 5, 6), "Trust in the Lord with all thine heart; and lean not unto thine own understanding; in all thy ways acknowledge him, and he shall direct thy paths.")
            };
        }
    }

    public class Reference
    {
        public string Book { get; private set; }
        public int Chapter { get; private set; }
        public int StartVerse { get; private set; }
        public int? EndVerse { get; private set; }

        public Reference(string book, int chapter, int startVerse, int? endVerse = null)
        {
            Book = book;
            Chapter = chapter;
            StartVerse = startVerse;
            EndVerse = endVerse;
        }

        public override string ToString()
        {
            return EndVerse.HasValue
                ? $"{Book} {Chapter}:{StartVerse}-{EndVerse}"
                : $"{Book} {Chapter}:{StartVerse}";
        }
    }

    public class Word
    {
        public string Text { get; private set; }
        public bool Hidden { get; private set; }

        public Word(string text)
        {
            Text = text;
            Hidden = false;
        }

        public void Hide()
        {
            Hidden = true;
        }

        public override string ToString()
        {
            return Hidden ? "____" : Text;
        }
    }

    public class Scripture
    {
        public Reference Reference { get; private set; }
        private List<Word> Words { get; set; }

        public Scripture(Reference reference, string text)
        {
            Reference = reference;
            Words = text.Split(' ').Select(word => new Word(word)).ToList();
        }

        public void HideRandomWords(int count)
        {
            var wordsToHide = Words.Where(word => !word.Hidden)
                                   .OrderBy(word => Guid.NewGuid())
                                   .Take(count)
                                   .ToList();
            wordsToHide.ForEach(word => word.Hide());
        }

        public bool AllWordsHidden()
        {
            return Words.All(word => word.Hidden);
        }

        public override string ToString()
        {
            var scriptureText = string.Join(" ", Words);
            return $"{Reference}\n{scriptureText}";
        }
    }
}

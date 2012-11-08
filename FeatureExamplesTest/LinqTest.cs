using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FeatureExamplesTest
{
    [TestClass]
    public class LinqTest
    {
        [TestMethod]
        public void FilterItemsContainedByOtherArray()
        {
            // Output: david carry
            string[] names1 = { "nick", "david", "carry" };
            string[] names2 = { "carry", "david" };
            var selectedNames = new List<string>();

            foreach (var name in names2)
            {
                if (names1.Contains(name))
                {
                    selectedNames.Add(name);
                }
            }

            foreach (var name in selectedNames)
            {
                Console.Out.WriteLine(name);
            }
        }

        [TestMethod]
        public void SelectTheLeftOnes()
        {
            //Output: nick
            string[] names1 = { "nick", "david", "carry" };
            string[] names2 = { "carry", "david" };

            var filteredNames = names1.Where(name => !names2.Contains(name));
            foreach (var name in filteredNames)
            {
                Console.Out.WriteLine(name);
            }
        }

        [TestMethod]
        public void GetAllUpperCaseItems()
        {
            string[] names = { "nick", "david", "carry" };
            var upperWords = names.Select(name => name.ToUpper());
            foreach (var word in upperWords)
            {
                Console.Out.WriteLine(word);
            }
        }

        [TestMethod]
        public void SortArrayAscending()
        {
            string[] names1 = { "nick", "david", "carry" };
            var orderedEnumerable = names1.OrderBy(s => s);
            foreach (var name in orderedEnumerable)
            {
                Console.Out.WriteLine(name);
            }
        }

        [TestMethod]
        public void SortArrayDescending()
        {
            string[] names1 = { "nick", "david", "carry" };
            var orderedEnumerable = names1.OrderBy(s => s).Reverse();
            foreach (var name in orderedEnumerable)
            {
                Console.Out.WriteLine(name);
            }
        }

        [TestMethod]
        public void MakeWordWithRandomLetters()
        {
            const string word = "happy";
            var random = new Random();
            var randomLetterWord = new string(word.ToCharArray().OrderBy(s=>random.Next()).ToArray());
            Console.Out.WriteLine(randomLetterWord);
        }

        [TestMethod]
        public void MakeWordStarAndEndLetterUnchangedButMiddleLettersInRamdonOrder()
        {
            const string word = "happy";
            var random = new Random();
            var randomLetterInMiddle = word[0]+ new string(word.Substring(1, word.Length-2).ToCharArray().OrderBy(s => random.Next()).ToArray()) + word[word.Length -1];
            Console.Out.WriteLine(randomLetterInMiddle);
        }

        [TestMethod]
        public void SortALongString()
        {
            const string text = "It does not matter";
            var orderedText = string.Join(" ", text.Split(' ').OrderBy(s => s));
            Console.Out.WriteLine(orderedText);
        }

        [TestMethod]
        public void ScrambleTextByWord()
        {
            const string text = "According to a research at Cambridge University it does not matter in what order the letters in a word are";

//            const string text1 = "Adcorcing to a rrseaech at Cambgidre Univeristy it does not mttaer in waht oredr the letters in a wrod are";

            var random = new Random();
            var scrambledText = string.Join(" ", text.Split(' ').Select(word => word.Length < 3 ? word : word[0] + new string(word.Substring(1, word.Length - 2).OrderBy(s => random.Next()).ToArray()) + word[word.Length - 1]));

            Console.Out.WriteLine(scrambledText);
        }


        [TestMethod]
        public void CountWordOccurence()
        {
            // Count the occurence of words and output them in descending, ignore case
            const string text = @"Historically, the world of data and the world of objects" +
                           @" have not been well integrated. Programmers work in C# or Visual Basic" +
                           @" and also in SQL or XQuery. On the one side are concepts such as classes," +
                           @" objects, fields, inheritance, and .NET Framework APIs. On the other side" +
                           @" are tables, columns, rows, nodes, and separate languages for dealing with" +
                           @" them. Data types often require translation between the two worlds; there are" +
                           @" different standard functions. Because the object world has no notion of query, a" +
                           @" query can only be represented as a string without compile-time type checking or" +
                           @" IntelliSense support in the IDE. Transferring data from SQL tables or XML trees to" +
                           @" objects in memory is often tedious and error-prone.";

            var words = text.Split(new[] { '.', '?', '!', ' ', ';', ':', ',' }, StringSplitOptions.RemoveEmptyEntries);
            var occurences = words.GroupBy(w => w.ToLower()).OrderBy(g => g.Count()).Reverse();

            foreach (var i in occurences)
            {
                Console.Out.WriteLine("{0} {1}", i.Key, i.Count());
            }
        }
    }
}

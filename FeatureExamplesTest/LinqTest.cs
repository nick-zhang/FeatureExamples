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
        public void CalculatAverage()
        {
            // 1 - 10
            var average = Enumerable.Range(1, 10).Select(x => x*x).Average();
            Console.Out.WriteLine(average);
        }

        [TestMethod]
        public void FilterItemsContainedByOtherArray()
        {
            //Output: david carry
            string[] names1 = {"nick", "david", "carry"};
            string[] names2 = {"carry", "david"};
            var selectedNames = names1.Where(names2.Contains);
            var bothHave = names1.Intersect(names2);

            foreach (var name in selectedNames)
            {
                Console.Out.WriteLine(name);
            }

            foreach (var name in bothHave)
            {
                Console.Out.WriteLine(name);
            }
        }

        [TestMethod]
        public void SelectTheLeftOnes()
        {
            //Output: nick
            string[] names1 = {"nick", "david", "carry"};
            string[] names2 = {"carry", "david"};

            var filteredNames = names1.Except(names2);
            foreach (var name in filteredNames)
            {
                Console.Out.WriteLine(name);
            }
        }

        [TestMethod]
        public void GetAllUppercaseItems()
        {
            //Output: NICK DAVID CARRY
            string[] names = {"nick", "david", "carry"};
            var upperWords = names.Select(name => name.ToUpper());
            foreach (var word in upperWords)
            {
                Console.Out.WriteLine(word);
            }
        }

        [TestMethod]
        public void SortArrayAscending()
        {
            //Output:carry david nick 
            string[] names = {"nick", "david", "carry"};
            var orderedEnumerable = names.OrderBy(s => s);
            foreach (var name in orderedEnumerable)
            {
                Console.Out.WriteLine(name);
            }
        }

        [TestMethod]
        public void SortArrayDescending()
        {
            //Output: nick david carray
            string[] names1 = {"nick", "david", "carry"};
            var orderedEnumerable = names1.OrderByDescending(s => s);
            foreach (var name in orderedEnumerable)
            {
                Console.Out.WriteLine(name);
            }
        }

        [TestMethod]
        public void MakeWordWithRandomLetters()
        {
            //Possbile output: apphy
            const string word = "happy";
            var random = new Random();
            var randomLetterWord = new string(word.ToCharArray().OrderBy(s => random.Next()).ToArray());
            Console.Out.WriteLine(randomLetterWord);
        }

        [TestMethod]
        public void MakeWordStarAndEndLetterUnchangedButMiddleLettersInRamdonOrder()
        {
            //Possbile output: hppay
            const string word = "happy";
            var random = new Random();
            var randomLetterInMiddle = word[0] +
                                          new string(
                                              word.Substring(1, word.Length - 2).ToCharArray().OrderBy(
                                                  s => random.Next()).ToArray()) + word[word.Length - 1];
            Console.Out.WriteLine(randomLetterInMiddle);
        }

        [TestMethod]
        public void SortALongString()
        {
            //Output: does it matter not
            const string text = "It does not matter";
            var orderedText = string.Join(" ", text.Split(' ').OrderBy(s => s));
            Console.Out.WriteLine(orderedText);
        }

        [TestMethod]
        public void ScrambleTextByWord()
        {
            // Possisble Output:            
            // const string text1 = "Adcorcing to a rrseaech at Cambgidre Univeristy it does not mttaer in waht oredr the letters in a wrod are";
            const string text =
                "According to a research at Cambridge University it does not matter in what order the letters in a word are";

            var random = new Random();
            var scrambledText = string.Join(" ",
                                               text.Split(' ').Select(
                                                   word =>
                                                   word.Length < 3
                                                       ? word
                                                       : word[0] +
                                                         new string(
                                                             word.Substring(1, word.Length - 2).OrderBy(
                                                                 s => random.Next()).ToArray()) + word[word.Length - 1]));

            Console.Out.WriteLine(scrambledText);
        }


        [TestMethod]
        public void CountWordOccurence()
        {
            // Count the occurence of words and output them in descending, ignore case
            const string text = "Historically, the world of data and the world of objects" +
                                " have not been well integrated. Programmers work in C# or Visual Basic" +
                                " and also in SQL or XQuery. On the one side are concepts such as classes," +
                                " objects, fields, inheritance, and .NET Framework APIs. On the other side" +
                                " are tables, columns, rows, nodes, and separate languages for dealing with" +
                                " them. Data types often require translation between the two worlds; there are" +
                                " different standard functions. Because the object world has no notion of query, a" +
                                " query can only be represented as a string without compile-time type checking or" +
                                " IntelliSense support in the IDE. Transferring data from SQL tables or XML trees to" +
                                " objects in memory is often tedious and error-prone.";

            var words = text.Split(new[] {'.', '?', '!', ' ', ';', ':', ','}, StringSplitOptions.RemoveEmptyEntries);
            var occurences =
                words.GroupBy(w => w.ToLower()).OrderByDescending(g => g.Count());

            foreach (var i in occurences)
            {
                Console.Out.WriteLine("{0} {1}", i.Key, i.Count());
            }
        }

        [TestMethod]
        public void SortByObjectProperty()
        {
            //Output: dog1 dog3 dog5 dogspecial dog2 dog4
            var dog1 = new Dog {IsMale = true, Name = "dog1"};
            var dog2 = new Dog {IsMale = false, Name = "dog2"};
            var dog3 = new Dog {IsMale = true, Name = "dog3"};
            var dogSpecial = new Dog(){Name = "specialDog"};
            var dog4 = new Dog {IsMale = false, Name = "dog4"};
            var dog5 = new Dog {IsMale = true, Name = "dog5"};
            var dogs = new List<Dog> {dog1, dog2, dog3, dog4, dog5};

            var reorderedDogs =
                dogs.Where(dog => dog.IsMale).Concat(new List<Dog> {dogSpecial}).Concat(dogs.Where(dog => !dog.IsMale));

            foreach (var dog in reorderedDogs)
            {
                Console.Out.WriteLine(dog.Name);
            }
        }
    }

    public class Dog
    {
        public bool IsMale;
        public string Name;
    }
}
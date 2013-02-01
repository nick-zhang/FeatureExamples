using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using FeatureExamples;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FeatureExamplesTest
{
    [TestClass]
    public class FeaturesTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            var book = new Book("Robert C. Martin", "934-2052-902993-6");
            book.PublishedYear = 2010;

            Console.Out.WriteLine("Book published year:{0}", book.PublishedYear);
        }

        [TestMethod]
        public void TestYield1()
        {
            var yieldExample = new YieldExample();
            // What's the out put?
//            yieldExample.WithNoYield();

            // What's the out put? 
            yieldExample.WithYield();
        }

        [TestMethod]
        public void TestYield2()
        {
            var yieldExample = new YieldExample();

            // What's the output?
//            foreach (var i in yieldExample.WithNoYield())
//            {
//                Console.WriteLine(i);
//            }


            // What's the output?
            IEnumerable<int> withYield = yieldExample.WithYield();
            Console.Out.WriteLine(withYield.Count());

            Console.Out.WriteLine("******");
            foreach (int i in withYield)
            {
                Console.WriteLine(i);
            }
        }

        [TestMethod]
        public void TestLINQ1()
        {
            // Specify the data source. 
            int[] scores = new[] {97, 92, 81, 60};

            IEnumerable<int> scoresGT80 = scores.Where(score => score > 80);

            foreach (int score in scoresGT80)
            {
                Console.Write(score + " ");
            }
        }

        [TestMethod]
        public void TestLINQToString()
        {
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

            const string searchTerm = "data";

            //Convert the string into an array of words 
            string[] source = text.Split(new[] {'.', '?', '!', ' ', ';', ':', ','},
                                         StringSplitOptions.RemoveEmptyEntries);

            // Create and execute the query. It executes immediately  
            // because a singleton value is produced. 
            // Use ToLowerInvariant to match "data" and "Data"  
            IEnumerable<string> matchQuery = from word in source
                                             where word.ToLower() == searchTerm.ToLower()
                                             select word;

            // Count the matches. 
            int wordCount = matchQuery.Count();
            Console.WriteLine("{0} occurrences(s) of the search term \"{1}\" were found.", wordCount, searchTerm);
        }

        [TestMethod]
        public void TestLINQToString2()
        {
            string[] names1 = {"nick", "david", "carry"};
            string[] names2 = {"carry", "david"};

            IEnumerable<string> includedNames = names1.Where(names2.Contains);
            foreach (string item in includedNames)
            {
                Console.WriteLine(item);
            }

            IEnumerable<string> excludedNames = names1.Except(names2);
            foreach (string item in excludedNames)
            {
                Console.WriteLine(item);
            }
        }

        [TestMethod]
        public void TestLINQToObject()
        {
            var arrList = new ArrayList
                              {
                                  new Student
                                      {
                                          FirstName = "Svetlana",
                                          LastName = "Omelchenko",
                                          Scores = new[] {98, 92, 81, 60}
                                      },
                                  new Student
                                      {
                                          FirstName = "Claire",
                                          LastName = "O’Donnell",
                                          Scores = new[] {75, 84, 96, 39}
                                      },
                                  new Student
                                      {
                                          FirstName = "Sven",
                                          LastName = "Mortensen",
                                          Scores = new[] {88, 94, 65, 91}
                                      },
                                  new Student
                                      {
                                          FirstName = "Cesar",
                                          LastName = "Garcia",
                                          Scores = new[] {97, 89, 85, 82}
                                      }
                              };

            IEnumerable<Student> query = from Student student in arrList
                                         where student.Scores.Any(s => s > 95)
                                         select student;

            foreach (Student s in query)
                Console.WriteLine(s.LastName);
        }

        [TestMethod]
        public void TestExtensionMethod1()
        {
            var dateTime = new DateTime(2012, 11, 5);
            var dateFormater = new DateFormater();

            string yyyyMmDd = dateFormater.YYYY_MM_DD(dateTime);

            var formatted = dateTime.YYYY_MM_DD();

            Assert.AreEqual("2012_11_05", yyyyMmDd);
        }

        [TestMethod]
        public void TestAnonymousType()
        {
            var product = new Product();
            var products = new List<Product> {product};

            var productQuery =
                from prod in products
                select new {Color = prod.Color, prod.Price};

            foreach (var v in productQuery)
            {
                Console.WriteLine("Color={0}, Price={1}", v.Color, v.Price);
            }

            var value = product.GetColorAndPrice();
            Console.Out.WriteLine(value.ToString());
        }

        [TestMethod]
        public void TestAnonymousType1()
        {
            var foo = new {name = "apple", diam = 4};
            var bar = new {name = "grape", diam = 1};
            var anonArray = new[] {foo, bar};
            Console.Out.WriteLine(anonArray[0].name);
            Console.Out.WriteLine(anonArray[0].diam);
        }

        [TestMethod]
        public void NullableTypeTest()
        {
            int? c = null;
//            Nullable<int> a = 0;

            int d = c ?? -1;

            int k = 5;

            Console.Out.WriteLine("d:" + d);
            Product p = null;
            Product q = p ?? new Product {Price = 5, Color = "RED"};
        }


    }
}
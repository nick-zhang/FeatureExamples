// Exmaple for Auto-Implemented Properties 

using System.Collections.Generic;

namespace FeatureExamples
{
    public class Book
    {
        public int PublishedYear;
        public string Author { get; private set; }
        public string ISBN { get; private set; }
        
        public Book(string author, string isbn)
        {
            Author = author;
            ISBN = isbn;
        }
    }
}
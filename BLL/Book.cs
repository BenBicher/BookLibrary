using System;

namespace BLL
{
    [Serializable]
    public class Book : Item
    {
        public string Author { get; set; }

        public Book(){}
        public Book(string title, string author, int numInStok, DateTime releaseDate, BaseCategory baseCat, InnerCategory innerCat) 
            :base(title, numInStok, releaseDate, baseCat, innerCat)
        {
            Author = author;
        }

        public Book(string author)
        {
            Author = author;
        }

        public override string GetAuthor() { return Author; }
    }
}
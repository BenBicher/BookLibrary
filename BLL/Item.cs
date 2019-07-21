using System;

namespace BLL
{
    [Serializable]
    public class Item
    {
        public string Title { get; set; }
        public Guid ISBN { get; set; }
        public int NumInStok { get; set; }
        public DateTime ReleaseDate { get; set; }
        public BaseCategory BaseCat { get; set; }
        public InnerCategory InnerCat { get; set; }

        public Item()
        {
            ISBN = new Guid();
        }

        public Item(string name, int numInStok, DateTime releaseDate)
        {
            Title = name;
            NumInStok = numInStok;
            ReleaseDate = releaseDate;
        }

        public Item(string title, int numInStok, DateTime releaseDate, BaseCategory baseCat, InnerCategory innerCat)
        {
            Title = title;
            NumInStok = numInStok;
            ReleaseDate = releaseDate;
            BaseCat = baseCat;
            InnerCat = innerCat;
        }

        public virtual string GetEdition() { return null; }
        public virtual string GetAuthor() { return null; }
    }
}
using System;

namespace BLL
{
    [Serializable]
    public class Jouranl : Item
    {
        public string Edition { get; set; }

        public Jouranl(){}
        public Jouranl(string name, int numInStok, DateTime releaseDate, string edition):base(name, numInStok, releaseDate)
        {
            Edition = edition;
        }
        public override string GetEdition() { return Edition; }
    }
}
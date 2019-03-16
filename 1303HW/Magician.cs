using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1303HW
{
    class Magician : INameable, IComparable<Magician>
    {
        public string Name { get; private set; }
        public string BirthTown { get; private set; }
        public string FavoriteSpell { get; private set; }

        public string this[string fieldName]
        {
            get
            {
                switch (fieldName)
                {
                    case "Name":
                        return this.Name;
                    case "BirthTown":
                        return this.BirthTown;
                    case "FavoriteSpell":
                        return this.FavoriteSpell;
                }
                return null;
            }
            set
            {
                switch (fieldName)
                {
                    case "Name":
                        this.Name = value;
                        break;
                    case "BirthTown":
                        this.BirthTown = value;
                        break;
                    case "FavoriteSpell":
                        this.FavoriteSpell = value;
                        break;
                }
            }
        }

        public override string ToString()
        {
            return $"Magician Name: {Name} BirthTown: {BirthTown} Title: {FavoriteSpell}";
        }

        int IComparable<Magician>.CompareTo(Magician other)
        {
            return this.Name.CompareTo(other.Name);
        }
    }
}

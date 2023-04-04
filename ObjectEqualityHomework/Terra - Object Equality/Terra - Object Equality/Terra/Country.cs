using System;

namespace iQuest.Terra
{
    public class Country : IComparable
    {
        public string Name { get; }

        public string Capital { get; }

        public Country(string name, string capital)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Capital = capital ?? throw new ArgumentNullException(nameof(capital));
        }
        public int CompareTo(object obj)
        {
            if (obj == null)
                return 1;
            if (obj is Country country)
            {
                int name = Name.CompareTo(country.Name);
                if (name != 0)
                    return name;
                return Capital.CompareTo(country.Capital);
            }
            throw new ArgumentException("Object is not a Country.");
        }
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Country other = (Country)obj;

            return Name == other.Name && Capital == other.Capital;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Capital);
        }
    }
}
﻿using System;

namespace iQuest.Terra
{
    public class Country
    {
        public string Name { get; }

        public string Capital { get; }

        public Country(string name, string capital)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Capital = capital ?? throw new ArgumentNullException(nameof(capital));
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
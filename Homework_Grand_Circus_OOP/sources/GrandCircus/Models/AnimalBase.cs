using System;
using System.Collections.Generic;
using System.Text;
using iQuest.GrandCircus.Interfaces;

namespace iQuest.GrandCircus.Models
{
    internal abstract class AnimalBase : IAnimal
    {
        public string Name { get; }
        public string SpeciesName { get; }

        public AnimalBase(string name, string speciesName)
        {
            Name = name;
            SpeciesName = speciesName;
        }
        public abstract string MakeSound();
    }
}

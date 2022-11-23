using System;
using System.Collections.Generic;
using System.Text;
using iQuest.GrandCircus.Interfaces;

namespace iQuest.GrandCircus.Models
{
    internal class AnimalBase : IAnimal
    {
        public string SpeciesName { get; set; }
        public string Name { get; set; }
        public virtual string MakeSound()
        {
            return "Animal sound!";
        }
    }
}

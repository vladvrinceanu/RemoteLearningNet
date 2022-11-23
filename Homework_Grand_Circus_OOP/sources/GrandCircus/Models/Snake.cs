using System;
using System.Collections.Generic;
using System.Text;

namespace iQuest.GrandCircus.Models
{
    internal class Snake : AnimalBase 
    {
        public Snake(string SpeciesName, string Name)
        {
            this.SpeciesName = SpeciesName;
            this.Name = Name;
        }
        public override string MakeSound()
        {
            return "snake sound!";
        }
    }
}

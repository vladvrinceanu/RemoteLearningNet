using System;
using System.Collections.Generic;
using System.Text;

namespace iQuest.GrandCircus.Models
{
    internal class Lion : AnimalBase
    {
        public Lion(string SpeciesName, string Name)
        {
            this.SpeciesName = SpeciesName;
            this.Name = Name;
        }
        public override string MakeSound()
        {
            return "lion sound!";
        }
    }
}

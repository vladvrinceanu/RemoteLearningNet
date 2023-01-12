using System;
using System.Collections.Generic;
using System.Text;

namespace iQuest.GrandCircus.Models
{
    internal class Eagle : AnimalBase
    {
        public static new readonly string SpeciesName = "Eagle";
        public Eagle(string name) : base(name, SpeciesName)
        {
        }
        public override string MakeSound()
        {
            return "eagle sound!";
        }
    }
}

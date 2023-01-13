using System;
using System.Collections.Generic;
using System.Text;

namespace iQuest.GrandCircus.Models
{
    internal class Elephant : AnimalBase
    {
        public static new readonly string SpeciesName = "Elephant";
        public Elephant(string name) : base(name, SpeciesName)
        {
        }
        public override string MakeSound()
        {
            return "elephant sound!";
        }
    }
}

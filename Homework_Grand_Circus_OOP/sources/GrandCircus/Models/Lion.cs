using System;
using System.Collections.Generic;
using System.Text;

namespace iQuest.GrandCircus.Models
{
    internal class Lion : AnimalBase
    {
        public static new readonly string SpeciesName = "Lion";
        public Lion(string name) : base(name, SpeciesName)
        {
        }
        public override string MakeSound()
        {
            return "lion sound!";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace iQuest.GrandCircus.Models
{
    internal class Snake : AnimalBase
    {
        public static new readonly string SpeciesName = "Snake";
        public Snake(string name) : base(name, SpeciesName)
        {
        }
        public override string MakeSound()
        {
            return "snake sound!";
        }
    }
}

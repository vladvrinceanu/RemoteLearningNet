using System;
using System.Collections.Generic;
using System.Text;

namespace iQuest.GrandCircus.Interfaces
{
    internal interface IAnimal
    {
        string SpeciesName { get; set; }
        string Name { get; set; }   
        string MakeSound();
    }
}

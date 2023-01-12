using System;
using System.Collections.Generic;
using System.Text;

namespace iQuest.GrandCircus.Interfaces
{
    internal interface IAnimal
    {
        string SpeciesName { get; }
        string Name { get; }   
        string MakeSound();
    }
}

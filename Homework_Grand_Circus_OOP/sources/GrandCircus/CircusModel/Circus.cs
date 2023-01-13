using iQuest.GrandCircus.Presentation;
using iQuest.GrandCircus.Interfaces;
using System.Collections.Generic;
using iQuest.GrandCircus.Models;
using System;

namespace iQuest.GrandCircus.CircusModel
{
    internal class Circus
    {
        private readonly Arena arena;
        private List<IAnimal> _animals = new List<IAnimal>();

        public Circus(Arena arena)
        {
            this.arena = arena;
        }
        public void Perform()
        {
            _animals = new List<IAnimal>{
            new Snake("Gicu"),
            new Eagle("Relu"),
            new Lion("Simba"),
            new Elephant("Dumbo")
            };

            arena.PresentCircus("Cirque du Soleil");
            foreach (IAnimal animal in _animals)
            {
                arena.AnnounceAnimal(animal.Name, animal.SpeciesName);
                arena.DisplayAnimalPerformance(animal.MakeSound());
            }
        }
    }
}
using iQuest.GrandCircus.Presentation;
using iQuest.GrandCircus.Interfaces;
using System.Collections.Generic;
using iQuest.GrandCircus.Models;
using System;

namespace iQuest.GrandCircus.CircusModel
{
    internal class Circus
    {
        private List<IAnimal> Animals = new List<IAnimal>();
        public Circus(Arena arena)
        {
            arena.PresentCircus("Circ");
        }
        public void Perform()
        {
            Snake snake = new Snake("Gicu","cobra snake");
            Lion lion = new Lion("Azorel","african lion");
            Elephant elephant = new Elephant("Mihai","indian elephant");
            Eagle eagle = new Eagle("Relu","american eagle");
            Arena arena = new Arena();

            Animals.Add(snake);
            Animals.Add(elephant);
            Animals.Add(lion);
            Animals.Add(eagle);

            foreach (var animals in Animals)
            {
                arena.AnnounceAnimal(animals.SpeciesName,animals.Name);
                arena.DisplayAnimalPerformance(animals.MakeSound());
            }
        }
    }
}
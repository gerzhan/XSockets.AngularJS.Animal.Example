using System;
using System.Collections.Generic;
using XSockets.Core.XSocket;
using XSockets.Core.XSocket.Helpers;

namespace XSockets.AngularJS.Animal.Example.Controllers
{
    public class Animals : XSocketController
    {
        /// ivory belongs to elephants...Just saying.
     
        private static readonly List<Animal> animals;
        /// <summary>
        /// Just a simple XSockets controller that illustrates a "backend" 
        /// </summary>
        public void GetAnimals()
        {
            this.Send(animals,"getAnimals"); // Pass back the list of animals
        }
        /// <summary>
        /// Action that adds an "Animal" to our static list of animals. When added everyone is notified )
        /// </summary>
        /// <param name="animal"></param>
        public void AddAnimal(Animal animal)
        {
            animals.Add(animal);
            this.SendToAll(animal, "addAnimal"); // Notify all that we have a new animal
        }
        /// <summary>
        /// Remove an animal fro the list of Animals using it's Id ( Guid )
        /// </summary>
        /// <param name="id"></param>
        public void RemoveAnimal(Guid id)
        {
            var removedAnimal = animals.Find(a => a.Id.Equals(id));
            animals.Remove(removedAnimal);
            this.SendToAll(removedAnimal, "removeAnimal"); // Notify all that an animal is removed...
        }


        static Animals()
        {
            animals = new List<Animal>
                {
                    new Animal() {Name = "Cat", Description = "Cats are also animals"},
                    new Animal() {Name = "Dog", Description = "Dogs can bark..."},
                    new Animal() {Name = "Bird", Description = "Birds can fly"}
                }; // Just set up a animals list..
        }

    }
}
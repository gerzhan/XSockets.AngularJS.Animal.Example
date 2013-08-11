using System;

namespace XSockets.AngularJS.Animal.Example.Controllers
{
    /// <summary>
    ///  A model that describes our animals
    /// </summary>
    public class Animal
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid Id { get; set; }
        public Animal()
        {
            this.Id = Guid.NewGuid();
        }
    }
}
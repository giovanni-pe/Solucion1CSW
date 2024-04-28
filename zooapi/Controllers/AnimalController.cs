using Microsoft.AspNetCore.Mvc;
using zooapi.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace zooapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AnimalController : ControllerBase
    {
        private readonly List<Animal> _animals;

        public AnimalController()
        {
            // Crear algunos animales de ejemplo
            _animals = new List<Animal>
            {
                new Animal { AnimalID = 1, Nombre = "León", Especie = "Panthera leo", Edad = 5, Genero = "Macho", FechaLlegada = new DateTime(2022, 1, 15), Habitat = "Sabana" },
                new Animal { AnimalID = 2, Nombre = "Tigre", Especie = "Panthera tigris", Edad = 4, Genero = "Hembra", FechaLlegada = new DateTime(2021, 11, 20), Habitat = "Selva" },
                new Animal { AnimalID = 3, Nombre = "Elefante", Especie = "Loxodonta africana", Edad = 10, Genero = "Macho", FechaLlegada = new DateTime(2023, 3, 5), Habitat = "Savana" }
            };
        }

        [HttpGet]
        public IEnumerable<Animal> GetAnimals()
        {
            return _animals;
        }

        [HttpGet("{id}")]
        public ActionResult<Animal> GetAnimal(int id)
        {
            var animal = _animals.FirstOrDefault(a => a.AnimalID == id);
            if (animal == null)
            {
                return NotFound();
            }
            return animal;
        }

        [HttpPost]
        public ActionResult<Animal> CreateAnimal(Animal animal)
        {
            // Generar nuevo ID para el animal
            animal.AnimalID = _animals.Max(a => a.AnimalID) + 1;
            _animals.Add(animal);
            return CreatedAtAction(nameof(GetAnimal), new { id = animal.AnimalID }, animal);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateAnimal(int id, Animal animal)
        {
            var existingAnimal = _animals.FirstOrDefault(a => a.AnimalID == id);
            if (existingAnimal == null)
            {
                return NotFound();
            }
            existingAnimal.Nombre = animal.Nombre;
            existingAnimal.Especie = animal.Especie;
            existingAnimal.Edad = animal.Edad;
            existingAnimal.Genero = animal.Genero;
            existingAnimal.FechaLlegada = animal.FechaLlegada;
            existingAnimal.Habitat = animal.Habitat;
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAnimal(int id)
        {
            var animalToRemove = _animals.FirstOrDefault(a => a.AnimalID == id);
            if (animalToRemove == null)
            {
                return NotFound();
            }
            _animals.Remove(animalToRemove);
            return NoContent();
        }
    }
}

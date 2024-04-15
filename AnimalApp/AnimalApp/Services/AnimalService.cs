﻿using AnimalApp.model;
using AnimalApp.Repositories;

namespace AnimalApp.Services
{
    public class AnimalService : IAnimalService
    {
        private readonly IAnimalRepository _repository;

        public AnimalService(IAnimalRepository repository)
        {
            _repository = repository;
        }

        public int AddAnimal(Animal animal)
        {
            return _repository.AddAnimal(animal);
        }

        public int DeleteAnimal(int idAnimal)
        {
            return _repository.DeleteAnimal(idAnimal);
        }

        public Animal GetAnimal(int idAnimal)
        {
            return _repository.GetAnimal(idAnimal);
        }

        public IEnumerable<Animal> GetAnimals(string orderBy)
        {
            return _repository.GetAnimals(orderBy);
        }

        public int UpdateAnimal(int id, Animal animal)
        {
            return _repository.UpdateAnimal(id, animal);
        }
    }
}

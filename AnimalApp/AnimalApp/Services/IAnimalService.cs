using AnimalApp.model;

namespace AnimalApp.Services
{
    public interface IAnimalService
    {
        IEnumerable<Animal> GetAnimals();
        int AddAnimal(Animal animal);
        Animal GetAnimal(int idAnimal);
        int UpdateAnimal(int id, Animal animal);
        int DeleteAnimal(int idAnimal);
    }
}

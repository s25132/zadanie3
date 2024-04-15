using AnimalApp.model;

namespace AnimalApp.Repositories
{
    public interface IAnimalRepository
    {
        IEnumerable<Animal> GetAnimals(string orderBy);
        int AddAnimal(Animal animal);
        Animal GetAnimal(int idAnimal);
        int UpdateAnimal(int id, Animal animal);
        int DeleteAnimal(int idAnimal);
    }
}

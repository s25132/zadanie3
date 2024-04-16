using AnimalApp.Model;

namespace AnimalApp.Services
{
    public interface IAnimalService
    {
        IEnumerable<AnimalWithId> GetAnimals(string orderBy);
        int AddAnimal(Animal animal);
        int UpdateAnimal(int id, Animal animal);
        int DeleteAnimal(int idAnimal);
    }
}

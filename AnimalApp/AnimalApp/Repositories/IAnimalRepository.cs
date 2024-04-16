using AnimalApp.Model;

namespace AnimalApp.Repositories
{
    public interface IAnimalRepository
    {
        IEnumerable<AnimalWithId> GetAnimals(string orderBy);
        int AddAnimal(Animal animal);
        int UpdateAnimal(int id, Animal animal);
        int DeleteAnimal(int idAnimal);
    }
}

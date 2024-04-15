using AnimalApp.model;

namespace AnimalApp.Repositories
{
    public class AnimalRepository : IAnimalRepository
    {
        public int AddAnimal(Animal animal)
        {
            return 0;
        }

        public int DeleteAnimal(int idAnimal)
        {
            return 0;
        }

        public Animal GetAnimal(int idAnimal)
        {
            return new Animal
            {
                IdAnimal = 1,
                Name = "Test",
                Description = "Test",
                Category = "Test",
                Area = "Test"
            };
        }

        public IEnumerable<Animal> GetAnimals()
        {
            List<Animal> Animals = new List<Animal>();

            Animals.Add(new Animal
            {
                IdAnimal = 1,
                Name = "Test",
                Description = "Test",
                Category = "Test",
                Area = "Test"
            });

            return Animals;
        }

        public int UpdateAnimal(int id, Animal animal)
        {
            return 0;
        }
    }
}

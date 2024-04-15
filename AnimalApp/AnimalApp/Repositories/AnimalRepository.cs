using AnimalApp.model;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace AnimalApp.Repositories
{
    public class AnimalRepository : IAnimalRepository
    {

        private IConfiguration _configuration;

        public AnimalRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public int AddAnimal(Animal animal)
        {
            if (!checkIfAnimalExistsByid(animal.IdAnimal)) //Jeżeli nie istnieje animal o tym id to go dodaj
            {
                return 0;
            }
            return -1;
        }

        public int DeleteAnimal(int idAnimal) //Jeżeli istnieje animal o tym id to go usuń
        {
            if (checkIfAnimalExistsByid(idAnimal))
            {
                return 0;
            }
            return -1;
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

        public IEnumerable<Animal> GetAnimals(string orderBy)
        {

            using var con = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
            con.Open();

            using var cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT IdAnimal, Name, Description, Category, Area FROM Animal ORDER BY @orderByCol";
            cmd.Parameters.AddWithValue("@orderByCol", orderBy);

            var dr = cmd.ExecuteReader();
            List<Animal> animals = new List<Animal>();

            while (dr.Read())
            {
               Animal animal = new Animal
                {
                   IdAnimal = (int)dr["IdAnimal"],
                   Name = dr["Name"].ToString(),
                   Description = dr["Description"].ToString(),
                   Category = dr["Category"].ToString(),
                   Area = dr["Area"].ToString()
                };
                animals.Add(animal);
            }

            return animals;
            /*          List<Animal> Animals = new List<Animal>();

                      Animals.Add(new Animal
                      {
                          IdAnimal = 1,
                          Name = "Test",
                          Description = "Test",
                          Category = "Test",
                          Area = "Test"
                      });

                      return Animals;*/
        }

        public int UpdateAnimal(int id, Animal animal)
        {
            if (checkIfAnimalExistsByid(id))  //Jeżeli istnieje animal o tym id to go modyfikuj
            {
                return 0;
            }
            return -1;
        }

        private bool checkIfAnimalExistsByid(int id)
        {
            using var con = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
            con.Open();

            using var cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select count(1) FROM Animal WHERE IdAnimal = @IdAnimal";
            cmd.Parameters.AddWithValue("@IdAnimal", id);

            var count = cmd.ExecuteNonQuery();

            return (count > 0);
        }
    }
}

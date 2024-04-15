using AnimalApp.model;
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
            Console.WriteLine("DeleteAnimal : " + idAnimal);

            if (checkIfAnimalExistsByid(idAnimal))
            {
                using var con = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
                con.Open();

                using var cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "DELETE FROM Animal WHERE idAnimal = @idAnimal";
                cmd.Parameters.AddWithValue("@idAnimal", idAnimal);

                var affectedCount = cmd.ExecuteNonQuery();
                return affectedCount;
            }

            return -1;
        }

        public Animal GetAnimal(int idAnimal)
        {
            using var con = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
            con.Open();

            using var cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT IdAnimal, Name, Description, Category, Area FROM Animal WHERE idAnimal = @idAnimal";
            cmd.Parameters.AddWithValue("@idAnimal", idAnimal);

            var dr = cmd.ExecuteReader();

            if (!dr.Read()) return null;

            Animal animal = new Animal
            {
                IdAnimal = (int)dr["IdAnimal"],
                Name = dr["Name"].ToString(),
                Description = dr["Description"].ToString(),
                Category = dr["Category"].ToString(),
                Area = dr["Area"].ToString()
            };

            return animal;
        }

        public IEnumerable<Animal> GetAnimals(string orderBy)
        {

            using var con = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
            con.Open();

            using var cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT IdAnimal, Name, Description, Category, Area FROM Animal " +
                "ORDER BY " +
                "CASE WHEN @orderByCol = 'IdAnimal' Then IdAnimal ELSE null END ASC, " +
                "CASE WHEN @orderByCol = 'Name' Then Name ELSE null END ASC, " +
                "CASE WHEN @orderByCol = 'Description' then Description ELSE null END ASC, " +
                "CASE WHEN @orderByCol = 'Area' then Area ELSE null END ASC, " +
                "CASE WHEN @orderByCol = 'Category' then Category ELSE null END ASC";


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
            Int32 count = (Int32)cmd.ExecuteScalar();

            Console.WriteLine("checkIfAnimalExistsByid : " + count);

            return (count > 0);
        }
    }
}

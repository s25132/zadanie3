using AnimalApp.Model;
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
            using var con = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
            con.Open();

            using var cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "INSERT INTO Animal(Name, Description, Category, Area) " +
                "OUTPUT INSERTED.IdAnimal " +
                "VALUES(@Name, @Description, @Category, @Area)";

            cmd.Parameters.AddWithValue("@Name", animal.Name);
            cmd.Parameters.AddWithValue("@Description", animal.Description);
            cmd.Parameters.AddWithValue("@Category", animal.Category);
            cmd.Parameters.AddWithValue("@Area", animal.Area);

            var id = (int)cmd.ExecuteScalar();
            return id;
        }

        public int DeleteAnimal(int idAnimal)
        {
 
            using var con = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
            con.Open();

            using var cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "DELETE FROM Animal WHERE idAnimal = @idAnimal";
            cmd.Parameters.AddWithValue("@idAnimal", idAnimal);

            var affectedCount = cmd.ExecuteNonQuery();
            return affectedCount;
;
        }


        public IEnumerable<AnimalWithId> GetAnimals(string orderBy)
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
            List<AnimalWithId> animals = new List<AnimalWithId>();

            while (dr.Read())
            {
                AnimalWithId animal = new AnimalWithId
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
            using var con = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
            con.Open();

            using var cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "UPDATE Animal SET Name=@Name, Description=@Description, Category=@Category, Area=@Area WHERE IdAnimal = @id";

            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@Name", animal.Name);
            cmd.Parameters.AddWithValue("@Description", animal.Description);
            cmd.Parameters.AddWithValue("@Category", animal.Category);
            cmd.Parameters.AddWithValue("@Area", animal.Area);

            var affectedCount = cmd.ExecuteNonQuery();
            return affectedCount;
        }
    }
}

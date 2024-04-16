using AnimalApp.Model;
using System.ComponentModel.DataAnnotations;

namespace AnimalApp.Model
{
    public class AnimalWithId : Animal
    {

        [Required]
        public int IdAnimal { get; set; }
    }
}

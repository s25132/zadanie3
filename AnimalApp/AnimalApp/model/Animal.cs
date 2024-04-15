using System.ComponentModel.DataAnnotations;

namespace AnimalApp.model
{
    public class Animal
    {

        [Required]
        public int IdAnimal { get; set; }
        [MaxLength(200)]
        public string Name { get; set; }
        [Required]
        [MaxLength(200)]
        public string Description { get; set; }
        [MaxLength(200)]
        public string Category { get; set; }
        [MaxLength(200)]
        public string Area { get; set; }
    }
}

using Domain.Models.Account;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models.Animal
{
    public class AnimalModel
    {
        [Key]
        public Guid AnimalId { get; set; }
        public required string Name { get; set; }

        public List<UserModel> Users { get; set; }

    }
}

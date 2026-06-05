using Simulation6.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Simulation6.Models
{
    public class Member : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Description { get; set; }
        public string? ImageUrl { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }
        public Position Position { get; set; }
        public int PositionId { get; set; }
    }

   
}

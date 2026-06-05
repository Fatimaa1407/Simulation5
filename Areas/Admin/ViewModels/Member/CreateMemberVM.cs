using Simulation6.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Simulation6.Areas.Admin.ViewModels.Member
{
    public record CreateMemberVM
    {
        [Required(ErrorMessage ="Name is required")]
        [StringLength(20,ErrorMessage ="Name cannot exceed 20 characters")]
        [MinLength(3,ErrorMessage ="Name must contain 3 characters")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Surname is required")]
        [StringLength(20, ErrorMessage = "Surname cannot exceed 20 characters")]
        [MinLength(3, ErrorMessage = "Surname must contain 3 characters")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Description is required")]
        [StringLength(200, ErrorMessage = "Description cannot exceed 200 characters")]
        [MinLength(3, ErrorMessage = "Description must contain 3 characters")]
        public string Description { get; set; }
        [Required(ErrorMessage ="Position is required")]
        public int PositionId { get; set; }
        public string? ImageUrl { get; set; }

        public IFormFile ImageFile { get; set; }
    
    }
}

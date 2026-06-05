using System.ComponentModel.DataAnnotations;

namespace Simulation6.Areas.Admin.ViewModels.Position
{
    public record UpdatePositionVM
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(20, ErrorMessage = "Name cannot exceed 20 characters")]
        [MinLength(3, ErrorMessage = "Name must contain 3 characters")]
        public string Name { get; set; }
        public int Id { get; set; }
    }
}

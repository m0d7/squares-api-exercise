using System.ComponentModel.DataAnnotations;

namespace Squares.Entities.DTO;

public class SurfaceDto
{
    [Required(ErrorMessage = "Surface name is required.")]
    public string TemplateName { get; set; }
}
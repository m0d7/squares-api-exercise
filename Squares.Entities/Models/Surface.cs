using System.ComponentModel.DataAnnotations;

namespace Squares.Entities.Models;

public class Surface
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Surface name is required.")]
    public string TemplateName { get; set; }
}
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Squares.Entities.Models;

public class Square
{
    public int Id { get; set; }

    [MinLength(4, ErrorMessage = "Square point array requires 4 point objects.")]
    [MaxLength(4, ErrorMessage = "Square point cannot exceed 4 point objects.")]
    public List<Point> Points { get; set; }

    public int SurfaceId { get; set; }

    [JsonIgnore] public Surface Surface { get; set; }
}
namespace Squares.Entities.Models;

public class Point
{
    public int Id { get; set; }
    public int X { get; set; }
    public int Y { get; set; }
    public int SquareId { get; set; }
    public Square Square { get; set; }
}
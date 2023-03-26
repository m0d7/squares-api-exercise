using Squares.Entities.DTO;
using Squares.Entities.Models;

namespace Squares.Contracts.Interfaces;

public interface ISquareValidator
{
    int DistanceFinder(PointDto a, PointDto b);
    bool IsSquare(PointDto a, PointDto b, PointDto c, PointDto d);
}
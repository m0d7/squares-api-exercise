using Microsoft.Extensions.Logging;
using Squares.Contracts.Interfaces;
using Squares.Entities.DTO;

namespace Squares.Services.Validators;

public class SquareValidator: ISquareValidator
{
    private readonly ILogger<SquareValidator> logger;
    public SquareValidator(ILogger<SquareValidator> logger)
    {
        this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }
    
    public int DistanceFinder(PointDto a, PointDto b)
    {
        return (a.X - b.X) * (a.X - b.X) + (a.Y - b.Y) * (a.Y - b.Y);
    }

    public bool IsSquare(PointDto a, PointDto b, PointDto c, PointDto d)
    {
        var distanceToB = this.DistanceFinder(a, b); // from p1 to p2
        var distanceToC = this.DistanceFinder(a, c); // from p1 to p3
        var distanceToD = this.DistanceFinder(a, d); // from p1 to p4

        if (distanceToB == 0 || distanceToC == 0 || distanceToD == 0)
        {
            return false;
        } 
        
        if (distanceToB == distanceToC && 2 * distanceToB == distanceToD && 2 * this.DistanceFinder(b, d) == this.DistanceFinder(b, c))
        {
            return true;
        }
 
        // The below two cases are similar to above case
        if (distanceToC == distanceToD && 2 * distanceToC == distanceToB && 2 * this.DistanceFinder(c, b) == this.DistanceFinder(c, d))
        {
            return true;
        }
        
        return distanceToB == distanceToD && 2 * distanceToB == distanceToC && 2 * this.DistanceFinder(b, c) == this.DistanceFinder(b, d);
    }
}
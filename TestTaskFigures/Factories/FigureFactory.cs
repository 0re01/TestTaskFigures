using TestTaskFigures.Contracts.FactoryContracts;
using TestTaskFigures.Figures;

namespace TestTaskFigures.Factories;

public class FigureFactory : IFigureFactory
{
    #region Implementation of IFigureFactory

    public IFigure GetFigure(params decimal[] sides)
    {
        switch (sides.Length)
        {
            case 1:
                return new Circle(sides[0]);
            case 3:
                return new Triangle(new []{sides[0], sides[1], sides[2]});
            default:
                throw new NotSupportedException();
        }
    }

    #endregion
}
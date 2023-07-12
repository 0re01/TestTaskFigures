namespace TestTaskFigures.Contracts.FactoryContracts;

public interface IFigureFactory
{
    public IFigure GetFigure(params decimal[] sides);
}
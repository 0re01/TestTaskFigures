using TestTaskFigures.Contracts.FactoryContracts;
using TestTaskFigures.Factories;

var figure = GetFactory().GetFigure(4.5m, 6m, 7.5m);

Console.WriteLine(figure.Square());
    
static IFigureFactory GetFactory()
{
    return new FigureFactory();
}
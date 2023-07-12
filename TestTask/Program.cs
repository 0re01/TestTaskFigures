// See https://aka.ms/new-console-template for more information

using TestTaskFigures.Contracts.FactoryContracts;
using TestTaskFigures.Factories;

Console.WriteLine("Hello, World!");

var figure = GetFactory().GetFigure(4.5m, 6m, 7.5m);

Console.WriteLine(figure.Square());
    
static IFigureFactory GetFactory()
{
    return new FigureFactory();
}
namespace TestTaskFigures.Figures;

public class Circle : IFigure
{
    private decimal _radius;

    private decimal Radius => _radius;
    
    /// <summary>
    /// Конструктор окружности по радиусу
    /// </summary>
    /// <param name="radius">длина радиуса</param>
    internal Circle(decimal radius)
    {
        _radius = radius;
    }
    
    #region Implementation of IFigure

    public decimal Square()
    {
        return Radius * Radius * (decimal)Math.PI;
    }

    #endregion
}
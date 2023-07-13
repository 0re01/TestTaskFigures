using TestTaskFigures.Exceptions;

namespace TestTaskFigures.Figures;

public class Triangle : IFigure
{
    private decimal[] Sides { get; }

    private readonly bool IsRight;
    /// <summary>
    /// Индекс длины гипотенузы гипотенузы
    /// </summary>
    private readonly int HypoInd;

    /// <summary>
    /// Коснтруктор треугольника по длинам 3 сторон
    /// </summary>
    /// <param name="sides">Набор длин сторон.</param>
    /// <exception cref="InvalidFigureArgsException">ИСключение выбрасывается в случае если передано некорректное количество сторон.</exception>
    internal Triangle(decimal[] sides)
    {
        if (sides.Length != 3)
        {
            throw new InvalidFigureArgsException("Некорректное количество сторон.");
        }

        Sides = sides;

        var comparingOneIndex = sides[0] >= sides[1] ? 0 : 1;

        HypoInd = sides[comparingOneIndex] > sides[2] ? comparingOneIndex : 2;

        var sqSum = sides[HypoInd]*sides[HypoInd] - HypoInd switch
        {
            0 => sides[1] * sides[1] + sides[2] * sides[2],
            1 => sides[0] * sides[0] + sides[2] * sides[2],
            2 => sides[1] * sides[1] + sides[0] * sides[0],
        };

        IsRight = sqSum == 0;
    }

    /// <summary>
    /// Метод получения 3 углов треугольника по 3 сторонам
    /// </summary>
    /// <returns></returns>
    private decimal[] GetAnglesBetweenSidesByThreeSides()
    {
        return new decimal[3]
        {
            GetAngleBetweenSidesByThreeSides(Sides[0], Sides[1], Sides[2]),
            GetAngleBetweenSidesByThreeSides(Sides[1], Sides[2], Sides[0]),
            GetAngleBetweenSidesByThreeSides(Sides[0], Sides[2], Sides[1]),
        };
    }

    /// <summary>
    /// Метод проверки треугольника на наличие прямого угла.
    /// </summary>
    /// <returns></returns>
    public bool IsRightTriangle()
    {
        return IsRight;
    }

    /// <summary>
    /// Метод вычисления угла между сторонами a и b, по длинам 3х сторон треугольника
    /// </summary>
    /// <param name="a">длина первой стороны образующей угол (сторона a)</param>
    /// <param name="b">длина второй стороны образующей угол (сторона b)</param>
    /// <param name="c">длина стороны противолежащей углу (сторона c)</param>
    /// <returns>величину угла в радианах</returns>
    private decimal GetAngleBetweenSidesByThreeSides(decimal a, decimal b, decimal c)
    {
        
        return Convert.ToDecimal(Math.Acos((double)((a * a + b * b - c * c) / (2 * a * b * c))));
    }

    #region Implementation of IFigure
    
    public decimal Square()
    {
        if (IsRight)
        {
            return HypoInd switch
            {
                0 => Sides[1] * Sides[2] * 0.5m,
                1 => Sides[0] * Sides[2] * 0.5m,
                2 => Sides[1] * Sides[0] * 0.5m,
            };
        }
        var semiPer = (Sides[0] + Sides[1] + Sides[2]) * 0.5m;
        return (decimal)Math.Sqrt((double)(semiPer * (semiPer - Sides[0]) * (semiPer - Sides[1]) * (semiPer - Sides[2])));
    }

    #endregion
}
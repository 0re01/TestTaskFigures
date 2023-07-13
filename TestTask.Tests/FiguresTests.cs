using System;
using TestTaskFigures.Contracts.FactoryContracts;
using TestTaskFigures.Factories;
using TestTaskFigures.Figures;
using Xunit;

namespace TestTask.Tests;

public class FiguresTests
{
    private IFigureFactory _factory;
    IFigureFactory Factory
    {
        get
        {
            if (_factory == null)
            {
                _factory = GetFactory();
            }

            return _factory;
        }
    }
    [Fact]
    public void GetFigureCircleTest()
    {
        var supposedCircle = Factory.GetFigure(4);
        var typeOfFigure = supposedCircle.GetType();
        Assert.Equal(typeOfFigure.ToString(), typeof(Circle).ToString());
    }
    
    [Fact]
    public void GetFigureTriangle()
    {
        var supposedTriangle = Factory.GetFigure(3, 3, 4);
        var typeOfFigure = supposedTriangle.GetType();
        Assert.Equal(typeOfFigure.ToString(), typeof(Triangle).ToString());
    }
    
    [Fact]
    public void IsRightTriangleFalseTest()
    {
        var supposedTriangle = Factory.GetFigure(3, 3, 4) as Triangle;
        Assert.False(supposedTriangle.IsRightTriangle());
    }
    
    [Fact]
    public void IsRightTriangleTrueTest()
    {
        var supposedTriangle = Factory.GetFigure(3, 5, 4) as Triangle;
        Assert.True(supposedTriangle.IsRightTriangle());
    }

    [Fact]
    public void GetFigureNotSupportedExceptionThrownTest()
    {
        Assert.Throws<NotSupportedException>(() => Factory.GetFigure(GetRandomHeights(2)));
    }

    private static IFigureFactory GetFactory()
    {
        return new FigureFactory();
    }

    private decimal[] GetRandomHeights(int count)
    {
        var rand = new Random();
        var res = new decimal[count];
        for (var i = 0; i < count; i++)
        {
            res[i] = NextDecimal(rand);
        }

        return res;
    }
    

    private decimal NextDecimal(Random rng)
    {
        byte scale = (byte) rng.Next(29);
        bool sign = rng.Next(2) == 1;
        return new decimal(rng.Next(), 
            rng.Next(),
            rng.Next(),
            sign,
            scale);
    }
    
}
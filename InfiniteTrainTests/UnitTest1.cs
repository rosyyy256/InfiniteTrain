using InfiniteTrain;
using NUnit.Framework;

public class Tests
{
    [Test]
    public void TrainIsClosedWithBaseConstructor_Test()
    {
        var train = new Train();
        var currentCarriage = train.Carriage;
        currentCarriage.Number = 0;
        currentCarriage.FrontCarriage.Number = 1;
        currentCarriage.RearCarriage.Number = 2;
        var number = 0;
        for (var i = 0; i < 10; i++)
        {
            Assert.AreEqual(number, currentCarriage.Number);
            currentCarriage = currentCarriage.FrontCarriage;
            number++;
            if (number == 3) number = 0;
        }
    }

    [Test]
    public void TrainIsClosedWith5Carriages_Test()
    {
        var train = new Train(5);
        var currentCarriage = train.Carriage;
        currentCarriage.Number = 0;
        currentCarriage.FrontCarriage.Number = 1;
        currentCarriage.FrontCarriage.FrontCarriage.Number = 2;
        currentCarriage.FrontCarriage.FrontCarriage.FrontCarriage.Number = 3;
        currentCarriage.FrontCarriage.FrontCarriage.FrontCarriage.FrontCarriage.Number = 4;
        var number = 0;
        for (var i = 0; i < 20; i++)
        {
            Assert.AreEqual(number, currentCarriage.Number);
            currentCarriage = currentCarriage.FrontCarriage;
            number++;
            if (number == 5) number = 0;
        }
    }

    [TestCase(3)]
    [TestCase(4)]
    [TestCase(5)]
    [TestCase(6)]
    [TestCase(7)]
    [TestCase(8)]
    [TestCase(20)]
    [TestCase(100)]
    [TestCase(1000)]
    [TestCase(10000)]
    public void CountCarriages_Test(int carriagesCount)
    {
        var train = new Train(carriagesCount);
        Assert.AreEqual(carriagesCount, train.CountCarriages());
    }
}
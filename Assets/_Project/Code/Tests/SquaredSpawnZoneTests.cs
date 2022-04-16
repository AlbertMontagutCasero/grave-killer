using NUnit.Framework;

namespace GraveKiller
{
    public class SquaredSpawnZoneTests
    {
        [Test]
        public void GetXRangeTest()
        {
            var xRange = new Range(3, 5);
            var xSignedRange = new SignedRange(xRange);

            var sut = new SquaredSpawnZone(xSignedRange, null);
            var iterationsNum = 1000;

            for (var i = 0; i < iterationsNum; i++)
            {
                var x = sut.GetX();
                var isInRange = (x >= 3 && x <= 5 || x >= -5 && x <= -3);
                TestContext.Out.WriteLine($" x  = {x}");
                Assert.That(isInRange);
            }
        }
        
        [Test]
        public void GetYRangeTest()
        {
            var yRange = new Range(10, 20);
            var ySignedRange = new SignedRange(yRange);

            var sut = new SquaredSpawnZone(null, ySignedRange);
            var iterationsNum = 1000;

            for (var i = 0; i < iterationsNum; i++)
            {
                var y = sut.GetY();
                var isInRange = (y >= 10 && y <= 20 || y >= -20 && y <= -10);
                TestContext.Out.WriteLine($" y  = {y}");
                Assert.That(isInRange);
            }
        }
    }
}

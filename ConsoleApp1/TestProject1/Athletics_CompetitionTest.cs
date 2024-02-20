using ConsoleApp1;

namespace TestProject1
{
    public class Tests
    {
        [Test]
        public void TestStatistics()
        {
            // Arrange
            var statistics = new Statistics();

            // Act
            statistics.AddGrade(5);
            statistics.AddGrade(7);
            statistics.AddGrade(9);

            // Assert
            Assert.AreEqual(5, statistics.Min);
            Assert.AreEqual(9, statistics.Max);
            Assert.AreEqual(3, statistics.Count);
            Assert.AreEqual(21, statistics.Sum);
            Assert.AreEqual(7, statistics.Average);
            Assert.AreEqual(0, statistics.spalone);
        }
    }
}
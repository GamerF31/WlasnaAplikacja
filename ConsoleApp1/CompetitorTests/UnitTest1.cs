using ConsoleApp1;

namespace CompetitorTests
{
    public class Tests
    {
        
        [Test]
        public void Test1()
        {
            // arrange
            
            var competitor = new LongJumpCompetitorInFile("CristianoGOAT", "Ronaldo");
            competitor.AddGrade(5);
            competitor.AddGrade(6);
            competitor.AddGrade(4);
            competitor.AddGrade(3);
            competitor.AddGrade(2);

            // act
            var result = competitor.GetStatistics();

            // assert
            Assert.AreEqual(4, result.Average);
            Assert.AreEqual(6, result.Max);
            Assert.AreEqual(2, result.Min);
        }
    }
}
using static ConsoleApp1.LongJumpCompetitorBase;
namespace ConsoleApp1
{
    public interface ILongJumpCompetitor
    {
        string Name { get; }
        string Surname { get; }
        void AddGrade(float grade);
        void AddGrade(string grade);
        void AddGrade(int grade);   
        Statistics GetStatistics();
    }
}

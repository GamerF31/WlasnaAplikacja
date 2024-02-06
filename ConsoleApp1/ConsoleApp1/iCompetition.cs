using static ConsoleApp1.CompetitionBase;
namespace ConsoleApp1
{
    public interface iCompetition
    {
        string Name { get; }
        string Surname { get; }
        void AddGrade(float grade);
        void AddGrade(string grade);
        void AddGrade(int grade);   
        Statistics GetStatistics();
    }
}

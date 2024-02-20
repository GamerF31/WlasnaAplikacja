using static ConsoleApp1.Atheltics_CompetitionBase;
namespace ConsoleApp1
{
    public interface IAthletics_Competition
    {
        string Name { get; }
        string Surname { get; }
        void AddGrade(float grade);
        void AddGrade(string grade);
        void AddGrade(int grade);   
        Statistics GetStatistics();
    }
}

namespace ConsoleApp1
{
    public abstract class CompetitionBase : iCompetition
    {
        public CompetitionBase(string name, string surname) 
        {
            this.Name = name;
            this.Surname = surname;

        }

        public string Name { get; private set; }
        public string Surname { get; private set; }
        public abstract void AddGrade(string grade);
        public abstract void AddGrade(int grade);
        public abstract void AddGrade(float grade);

        public abstract Statistics GetStatistics();
        
    }
}

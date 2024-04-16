namespace ConsoleApp1
{
    public abstract class LongJumpCompetitorBase : ILongJumpCompetitor
    {
        
        public LongJumpCompetitorBase(string Name, string Surname)
        {
            this.Name = Name;
            this.Surname = Surname;
        }
        public string Name { get; private set; }
        public string Surname { get; private set; }


        public abstract void AddGrade(string grade);
        public abstract void AddGrade(int grade);
        public abstract void AddGrade(float grade);

        public abstract Statistics GetStatistics();
        
    }
}

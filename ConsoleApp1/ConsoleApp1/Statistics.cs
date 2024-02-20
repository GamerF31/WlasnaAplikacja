namespace ConsoleApp1
{
    public class Statistics
    {
        public float Min { get; private set; }
        public float Max { get; private set; }
        public float Sum { get; private set; }
        public float Count { get; private set; }
        public int spalone { get; set; }

        public float Average { get
            {
                return this.Sum / this.Count;
            }
        }

        public Statistics() 
        {
            this.Count = 0;
            this.Sum = 0;
            this.spalone = 0;
            this.Max = float.MinValue;
            this.Min = float.MaxValue;
        }
        public void AddGrade(float grade)
        {
            if(grade == 0)
            { this.spalone++; }
            this.Count++;
            this.Sum += grade;
            if (grade != 0)
            {
                this.Min = Math.Min(this.Min, grade);
            }
            this.Max = Math.Max(this.Max, grade);
        }
      
        
    }
}

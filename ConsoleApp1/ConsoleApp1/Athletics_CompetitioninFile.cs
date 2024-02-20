
namespace ConsoleApp1
{
    public class Athletics_CompetitioninFile : Atheltics_CompetitionBase
    {
        private const string fileName = "competition2.txt";

        public Athletics_CompetitioninFile(string name, string surname)
            : base(name, surname)
        {
        }

        public override void AddGrade(float grade)
        {
            if (grade >= 0)
            {
                using (var writer = File.AppendText(fileName))
                {
                    writer.WriteLine(grade);
                }
            }
            else
            {
                throw new Exception("Niestety podany skok jest niemożliwy do uzyskania. Podaj ponownie skok");
            }

        }
        public override void AddGrade(int grade)
        {
            var valueinfloat = (float)grade;
            AddGrade(valueinfloat);
        }
        public override void AddGrade(string grade)
        {
            if (float.TryParse(grade, out float result))
            {
                AddGrade(result);
            }
            else
            {
                throw new Exception($"String {grade} is not float");
            }
        }

        public override Statistics GetStatistics()
        {
            var gradesFromFile = this.ReadJumpsFromFile();
            var result = this.CountStatistics(gradesFromFile);
            return result;
        }
        private List<float> ReadJumpsFromFile() 
        {
            var jumps = new List<float>();
            if(File.Exists(fileName))
            {
                using (var reader = File.OpenText(fileName))
                {
                    var line = reader.ReadLine();
                    while(line != null) 
                    {
                        var number = float.Parse(line);
                        jumps.Add(number);
                        line = reader.ReadLine();
                    }
                }

            }
            return jumps;

        }
        private Statistics CountStatistics(List<float> jumps) 
        {
            var statistics = new Statistics();
            foreach (var jump in jumps) 
            {
                statistics.AddGrade(jump);
            }

            return statistics;
        }


    }
}



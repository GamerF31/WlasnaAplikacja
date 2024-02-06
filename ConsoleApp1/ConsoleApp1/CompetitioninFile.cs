
namespace ConsoleApp1
{
    public class CompetitioninFile : CompetitionBase
    {
        private const string fileName = "competition2.txt";

        public CompetitioninFile(string name, string surname)
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
            else if (char.TryParse(grade, out char result2))
            {
                AddGrade(result2);
            }
            else
            {
                throw new Exception($"String {grade} is not float");
            }
        }
        public override Statistics GetStatistics()
        {
            var statistics = new Statistics();
            statistics.Average = 0;
            statistics.Max = float.MinValue;
            statistics.Min = float.MaxValue;
            var counter2 = 0;
            statistics.spalone = 0;
            if (File.Exists(fileName))
            {
                using (var reader = File.OpenText(fileName))
                {

                    var line = reader.ReadLine();
                    while (line != null)
                    {
                        var number = float.Parse(line);
                        statistics.Max = Math.Max(statistics.Max, number);
                        line = reader.ReadLine();
                        if (number != 0 && number > 0)
                        {
                            statistics.Min = Math.Min(statistics.Min, number);
                            counter2++;
                            statistics.Average += number;

                        }
                        if(number == 0)
                        {
                            statistics.spalone++;
                        }
                    }
                }
                statistics.Average /= counter2;
            }
            return statistics;
        }


    }
}

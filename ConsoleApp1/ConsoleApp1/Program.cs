using ConsoleApp1;
Console.WriteLine("Welcome to the Long Jump Competition!");
Thread.Sleep(2000);
Console.WriteLine();

Console.WriteLine($"Enter the number of competitors ");

int numberOfCompetitors;

while (!int.TryParse(Console.ReadLine(), out numberOfCompetitors) || numberOfCompetitors <= 0)
{
    Console.WriteLine("Invalid input. Please enter a positive integer.");
}
Thread.Sleep(1000);
var competitors = new List<LongJumpCompetitorsInFile>();
int j = 0;
while (j < numberOfCompetitors)
{
    Console.WriteLine($"Enter the name of competitor {j + 1}: ");
    string name = Console.ReadLine();
    Console.WriteLine($"Enter the surname of competitor {j + 1}: ");
    string surname = Console.ReadLine();
    competitors.Add(new LongJumpCompetitorsInFile(name, surname));
    j++;
}
Console.WriteLine($"There are {numberOfCompetitors} competitors in the competition.");
Console.WriteLine();
Console.WriteLine("Let's start the competition!");
Thread.Sleep(2000);
Console.WriteLine();
int i = 0;
float maxJump = float.MinValue;
float minJump = float.MaxValue;
List<int> bestCompetitors = new List<int>();
List<int> worstCompetitors = new List<int>();

while (i < numberOfCompetitors)
{
    Console.WriteLine($"Jump of competitor {competitors[i].Name} {competitors[i].Surname}: ");
    var input = Console.ReadLine();
    if (input == "X" || input == "x")
    {
        competitors[i].AddGrade(0);
        Console.WriteLine($"Unfortunately, competitor {competitors[i].Name} {competitors[i].Surname} fouled the jump");
        string fileName = $"{competitors[i].Name}_{competitors[i].Surname}_jump.txt";
        using (StreamWriter writer = File.AppendText(fileName))
        {
            writer.WriteLine(0);
        }
        i++;
    }
    else
    {
        try
        {
            float jump = float.Parse(input);
            if (jump > maxJump)
            {
                maxJump = jump;
                bestCompetitors.Clear();
                bestCompetitors.Add(i + 1);
            }
            else if (jump == maxJump)
            {
                bestCompetitors.Add(i + 1);
            }
            if (jump < minJump && jump > 0 && jump != 0)
            {
                minJump = jump;
                worstCompetitors.Clear();
                worstCompetitors.Add(i + 1);
            }
            else if (jump == minJump)
            {
                worstCompetitors.Add(i + 1);
            }
            competitors[i].AddGrade(jump);
            Console.WriteLine($"Competitor {competitors[i].Name} {competitors[i].Surname} made a jump of {jump} meters");

            string fileName = $"{competitors[i].Name}_{competitors[i].Surname}_jump.txt";
            using (StreamWriter writer = File.AppendText(fileName))
            {
                writer.WriteLine(jump);
            }
            i++;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception catched :{ex.Message}");
        }
    }
}

var statistics = competitors[0].GetStatistics();
Console.WriteLine();
if (bestCompetitors.Count == 1)
{
    Console.WriteLine($"Competitor number {bestCompetitors[0]} achieved the best jump of {statistics.Max} meters. Congratulations!");
}
else
{
    Console.Write("Competitors numbers ");
    foreach (int number in bestCompetitors)
    {
        Console.Write($"{number}, ");
    }
    Console.WriteLine($"achieved the best jumps of {statistics.Max} meters. We have a tie for first place!");
}
if (worstCompetitors.Count == 1)
{
    Console.WriteLine($"Competitor number {worstCompetitors[0]} achieved the worst jump of {statistics.Min} meters.");
}
else
{
    Console.Write("Competitors numbers ");
    foreach (int number in worstCompetitors)
    {
        Console.Write($"{number}, ");
    }
    Console.WriteLine($"achieved the worst jumps of {statistics.Min} meters.");
}
Console.WriteLine($"Number of fouled jumps: {statistics.spalone}");
Console.WriteLine($"Average jump length: {statistics.Average}");


Console.ReadLine();



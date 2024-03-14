using ConsoleApp1;
Console.WriteLine("Welcome to the Long Jump Competition!");
Thread.Sleep(2000);
Console.WriteLine();

const int numberOfCompetitors = 12;
var competitors = new List<LongJumpCompetitorsInFile>();
int j = 0;
while (j<numberOfCompetitors)
{
    Console.WriteLine($"Enter the name of competitor {j+1}: ");
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

while (i<numberOfCompetitors)
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
                bestCompetitors.Add(i+1);
            }
            else if (jump == maxJump)
            {
                bestCompetitors.Add(i+1);
            }
            if (jump < minJump && jump > 0 && jump != 0)
            {
                minJump = jump;
                worstCompetitors.Clear();
                worstCompetitors.Add(i+1);
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



/*
 * while(i<numberOfCompetitors)
{
    Console.WriteLine($"Skok zawodnika {competitors[i].Name} {competitors[i].Surname} wynosi: ");
    var input = Console.ReadLine();
    if (input == "X" || input == "x")
    {
        competitors[i].AddGrade(0);
        Console.WriteLine($"Niestety zawodnik {competitors[i].Name} {competitors[i].Surname} spalił swój skok");
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
                bestCompetitors.Add(i+1);
            }
            else if (jump == maxJump)
            {
                bestCompetitors.Add(i+1);
            }
            if (jump < minJump && jump > 0 && jump != 0)
            {
                minJump = jump;
                worstCompetitors.Clear();
                worstCompetitors.Add(i+1);
            }
            else if (jump == minJump)
            {
                worstCompetitors.Add(i + 1);
            }
            competitors[i].AddGrade(jump);
            Console.WriteLine($"Zawodnik {competitors[i].Name} {competitors[i].Surname} oddał skok wynoszący {jump} metra");
            i++;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception catched :{ex.Message}");
        }
    }
}
 */




/*
Thread.Sleep(2000);
Console.WriteLine("Witamy na zawodach lekkoatletycznych w skoku w dal");
Thread.Sleep(2000);
Console.WriteLine();


var competitor = new Athletics_CompetitioninFile("Przemek", "Hubacz");

Console.WriteLine($"Zawody poprowadzi sędzia {competitor.Name + " " + competitor.Surname}");
Thread.Sleep(2000);
Console.WriteLine();
Console.WriteLine("W zawodach skoku w dal weźmie udział 12 zawodników, każdy z nich odda po 1 skoku");
Thread.Sleep(5000);
Console.WriteLine();
Console.WriteLine("Zaczynamy zawody");
Thread.Sleep(2000);
Console.WriteLine();
int i = 1;
float maxJump = float.MinValue; 
float minJump = float.MaxValue; 
List<int> numbers_of_the_bests = new List<int>();
List<int> numbers_of_the_weakests = new List<int>();


while (i <= 12)
{
    Console.WriteLine($"Skok zawodnika numer {i} wynosi: ");
    var input = Console.ReadLine();
    if (input == "X" || input == "x")
    {
        competitor.AddGrade(0);
        Console.WriteLine($"Niestety zawodnik z numerem {i} spalił swój skok");
        i++;
    }
    else
    {
        try
        {
            float jump = float.Parse(input);
            if (jump > maxJump && jump > 0)
            {
                maxJump = jump;
                numbers_of_the_bests.Clear();
                numbers_of_the_bests.Add(i);
            }
            else if(jump == maxJump)
            {
                numbers_of_the_bests.Add(i);
            }
            if (jump < minJump && jump > 0 && jump != 0)
            {
                minJump = jump;
                numbers_of_the_weakests.Clear();
                numbers_of_the_weakests.Add(i);
            }
            else if (jump == minJump) 
            {
                numbers_of_the_weakests.Add(i);
            }
            competitor.AddGrade(jump);
            Console.WriteLine($"Zawodnik z numerem {i} oddał skok wynoszący {jump} metra");
            i++;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception catched :{ex.Message}");
        }
    }

}


var statistics = competitor.GetStatistics();
if (numbers_of_the_bests.Count == 1)
{
    Console.WriteLine($"Zawodnik o numerze {numbers_of_the_bests[0]} osiągnął najlepszy skok wynoszący {statistics.Max} metra. Gratulujemy!");
}
else
{
    Console.Write("Zawodnicy o numerach ");
    foreach (int number1 in numbers_of_the_bests)
    {
        Console.Write($"{number1}, ");
    }
    Console.WriteLine($"osiągnęli najlepsze skoki wynoszące {statistics.Max} metra. Mamy remis o pierwsze miejsce!");
}
if (numbers_of_the_weakests.Count == 1)
{
    Console.WriteLine($"Zawodnik o numerze {numbers_of_the_weakests[0]} osiągnął najgorszy skok wynoszący {statistics.Min} metra.");
}
else
{
    Console.Write("Zawodnicy o numerach ");
    foreach (int number in numbers_of_the_weakests)
    {
        Console.Write($"{number}, ");
    }
    Console.WriteLine($"osiągnęli najgorsze skoki wynoszące {statistics.Min} metra.");
}
Console.WriteLine($"Ilość skoków spalonych wyniosła {statistics.spalone}");
Console.WriteLine($"Średnia długość skoków wynosi {statistics.Average}");
*/



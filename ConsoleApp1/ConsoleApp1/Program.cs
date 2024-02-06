using ConsoleApp1;
Thread.Sleep(2000);
Console.WriteLine("Witamy na zawodach lekkoatletycznych w skoku w dal");
Thread.Sleep(2000);
Console.WriteLine();


var competitor = new CompetitioninFile("Przemek", "Hubacz");

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
float maxSkok = float.MinValue; 
float minSkok = float.MaxValue; 
List<int> numeryNajlepszych = new List<int>();
List<int> numeryNajsłabszych = new List<int>();


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
            float skok = float.Parse(input);
            if (skok > maxSkok && skok > 0)
            {
                maxSkok = skok;
                numeryNajlepszych.Clear();
                numeryNajlepszych.Add(i);
            }
            else if(skok == maxSkok)
            {
                numeryNajlepszych.Add(i);
            }
            if (skok < minSkok && skok > 0)
            {
                minSkok = skok;
                numeryNajsłabszych.Clear();
                numeryNajsłabszych.Add(i);
            }
            else if (skok == minSkok) 
            {
                numeryNajsłabszych.Add(i);
            }
            competitor.AddGrade(skok);
            Console.WriteLine($"Zawodnik z numerem {i} oddał skok wynoszący {skok} metra");
            i++;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception catched :{ex.Message}");
        }
    }

}


var statistics = competitor.GetStatistics();
if (numeryNajlepszych.Count == 1)
{
    Console.WriteLine($"Zawodnik o numerze {numeryNajlepszych[0]} osiągnął najlepszy skok wynoszący {statistics.Max} metra. Gratulujemy!");
}
else
{
    Console.Write("Zawodnicy o numerach ");
    foreach (int numer1 in numeryNajlepszych)
    {
        Console.Write($"{numer1}, ");
    }
    Console.WriteLine($"osiągnęli najlepsze skoki wynoszące {statistics.Max} metra. Mamy remis o pierwsze miejsce!");
}
if (numeryNajsłabszych.Count == 1)
{
    Console.WriteLine($"Zawodnik o numerze {numeryNajsłabszych[0]} osiągnął najgorszy skok wynoszący {statistics.Min} metra.");
}
else
{
    Console.Write("Zawodnicy o numerach ");
    foreach (int numer in numeryNajsłabszych)
    {
        Console.Write($"{numer}, ");
    }
    Console.WriteLine($"osiągnęli najgorsze skoki wynoszące {statistics.Min} metra.");
}
Console.WriteLine($"Ilość skoków spalonych wyniosła {statistics.spalone}");
Console.WriteLine($"Średnia długość skoków wynosi {statistics.Average}");




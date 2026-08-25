using System;

Console.WriteLine("GPA Calculator");
int count;
while (true)
{
    Console.Write("How many classes do you have? ");
    if (int.TryParse(Console.ReadLine(), out count) && count >= 0)
    {
        break;
    }

    Console.WriteLine("Please enter a whole number of classes.");
}

double totalPoints = 0;
double totalCredits = 0;

for (int i = 1; i <= count; i++)
{
    double points;
    while (true)
    {
        Console.Write($"Enter grade for class {i} (A-F or 0-100): ");
        string grade = Console.ReadLine()?.Trim().ToUpper() ?? "";
        points = grade switch
        {
            "A" => 4.0,
            "B" => 3.0,
            "C" => 2.0,
            "D" => 1.0,
            "F" => 0.0,
            _ when double.TryParse(grade, out double numericGrade) && numericGrade is >= 0 and <= 100
                => numericGrade >= 90 ? 4.0
                    : numericGrade >= 80 ? 3.0
                    : numericGrade >= 70 ? 2.0
                    : numericGrade >= 60 ? 1.0
                    : 0.0,
            _ => -1.0
        };

        if (points >= 0)
        {
            break;
        }

        Console.WriteLine("Please enter A, B, C, D, F, or a number from 0 to 100.");
    }

    double credits;
    while (true)
    {
        Console.Write($"Enter credits for class {i}: ");
        if (double.TryParse(Console.ReadLine(), out credits) && credits > 0)
        {
            break;
        }

        Console.WriteLine("Please enter a number greater than zero.");
    }

    totalPoints += points * credits;
    totalCredits += credits;
}

if (totalCredits == 0)
{
    Console.WriteLine("No credits entered.");
    return;
}

double gpa = totalPoints / totalCredits;
Console.WriteLine($"Your GPA is: {gpa:F2}");

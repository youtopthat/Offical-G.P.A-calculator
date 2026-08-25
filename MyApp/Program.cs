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
    string grade;
    while (true)
    {
        Console.Write($"Enter grade for class {i} (A, B, C, D, F): ");
        grade = Console.ReadLine()?.Trim().ToUpper() ?? "";
        if (grade is "A" or "B" or "C" or "D" or "F")
        {
            break;
        }

        Console.WriteLine("Please enter A, B, C, D, or F.");
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

    double points = grade switch
    {
        "A" => 4.0,
        "B" => 3.0,
        "C" => 2.0,
        "D" => 1.0,
        "F" => 0.0,
        _ => 0.0
    };

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

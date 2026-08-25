using System;

Console.WriteLine("GPA Calculator");
Console.Write("How many classes do you have? ");
int count = int.Parse(Console.ReadLine() ?? "0");

double totalPoints = 0;
double totalCredits = 0;

for (int i = 1; i <= count; i++)
{
    Console.Write($"Enter grade for class {i} (A, B, C, D, F): ");
    string grade = Console.ReadLine()?.Trim().ToUpper() ?? "";

    Console.Write($"Enter credits for class {i}: ");
    double credits = double.Parse(Console.ReadLine() ?? "0");

    double points = grade switch
    {
        "A" => 4.0,
        "B" => 3.0,
        "C" => 2.0,
        "D" => 1.0,
        "F" => 0.0,
        _ => throw new Exception("Invalid grade")
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

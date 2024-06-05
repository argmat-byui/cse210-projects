using System;

class Program
{
    static void Main(string[] args)
    {
        Running running = new Running(new DateOnly(2024, 6, 10), 60, 10);
        Cycling cycling = new Cycling(new DateOnly(2024, 7, 11), 90, 20);
        Swimming swimming = new Swimming(new DateOnly(2024, 8, 12), 90, 60);
        List<Activity> activities = [running, cycling, swimming];
        foreach(Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
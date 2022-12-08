using System;

internal class Program
{
    private static void Main(string[] args)
    {
        var pawel = new Employee("Pawel");
        pawel.AddGrade("4+");
        pawel.AddGrade("4+");


        while (true)
        {
            Console.WriteLine($"Hello ! Enter grade for {pawel.Name} // OR Q to exit");
            var input = Console.ReadLine();

            if (input == "q")
            {
                break;
            }

            try
            {
                var grade = double.Parse(input);
                pawel.AddGrade(grade);
            }
            catch(ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }

           finally 
            {
                Console.WriteLine("Part of finally Block Code");
                }

        }
        var stats = pawel.GetStatistics();
        Console.WriteLine($"High : {stats.High}");
        Console.WriteLine($"Low : {stats.Low}");
        Console.WriteLine($"Average : {stats.Average}");
        Console.WriteLine($"Letter  : {stats.Letter} ");



        pawel.AddGradeString("22,2"); 
        pawel.AddGradeString("10,2");
        pawel.AddGradeString("1,00");



    }
      }

    


        
   




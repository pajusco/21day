using _21day;
using System;

internal class Program
{
    private static void Main(string[] args)
    {
        StartProgram();
    }

    private static void StartProgram()
    {
        Console.WriteLine("Please Entry Student Name File you want to Create. : \r\n Entry Name: ");

        string userInput = Console.ReadLine();

        if (userInput != null)
        {
            string studenObjName = userInput;

            Student student = CreateStudent(studenObjName);
            string newStudenGetName = student.Name;
            student.GradeAdded += OnGradeAdded;
            student.lowGradAdded += LowGradeAdded;
            EnterGrade(student, student.Name);
            student.GetStatistics();

            Console.WriteLine("test T-001");
        }
        else
        {
            Environment.Exit(0);
        }
    }

    private static void EnterGrade(IStudent student,string input)
    {
        while (true)
        {
   
            Console.WriteLine($"Hello ! Enter grade for {student.Name} // OR Q to exit");
            // Console.ReadLine();
            
            if (input == "q")
            {
                break;
            }

            try
            {
                var grade = double.Parse(input);
                student.AddGrade(grade);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }

            finally
            {
                // input = Console.ReadLine();
                Console.WriteLine("Part of finally Block Code");
            }
            
            Console.WriteLine($"Hello ! Enter grade for {student.Name} // OR Q to exit");
            input = Console.ReadLine();
        }
    }

    public static Student CreateStudent(string student)
    {
        return new Student(student);
    }

    static void OnGradeAdded(object sender, EventArgs args)
    {
        Console.WriteLine("New Grade  is Added ! Test X1");
    }

    static void LowGradeAdded(object sender, EventArgs args)
    {
        Console.WriteLine("Oh no! We should inform student’s parents about this fact");
    }

    static void GetStats()
    {
        Console.WriteLine("Jestem tu");
        Console.ReadKey();

    }
}



    


    


        
   




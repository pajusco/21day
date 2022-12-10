using _21day;
using System.Diagnostics;


public class Student : Human, IStudent
{
    public delegate void GradeAddedDelegate(object sender, EventArgs args);
    public event GradeAddedDelegate GradeAdded;
    public event GradeAddedDelegate lowGradAdded;
    private List<double> grades = new List<double>();
    public const string FIRM = "M";

    public Student(string name) : base (name)
    {
        this.Name = name;
    }
    public Student(string name, string emp) : base (name)
    {
        this.Name = name;
    }
    public void AddGrade(double grade, int a)
    {

    }

    public void AddGradeString(string stringToDouble)
    {
        if (Double.TryParse(stringToDouble, out double result))
        {
            this.AddGrade(result);
            Console.WriteLine($"successfully added a Grade : {result} for {this.Name}");
        }
        else
        {
            throw new ArgumentException($"Grade '{stringToDouble}' has not been added for {this.Name}. The value must be in the range of 0-100.");
        }
    }

    public void AddGrade(string gradeWithSymbols)
    {
        short isInt;
        bool gradeIsInt = short.TryParse(gradeWithSymbols, out isInt);
        bool foundIntInRange = (isInt > 0 & isInt < 6);
        if (!gradeIsInt)
        {
            switch (gradeWithSymbols)
            {
                case "1+":
                    this.grades.Add(1.50);
                    break;
                case "2+":
                    this.grades.Add(2.50);
                    break;
                case "3+":
                    this.grades.Add(3.50);
                    break;
                case "4+":
                    this.grades.Add(4.50);
                    break;
                case "5+":
                    this.grades.Add(5.50);
                    break;
                default:
                    short.TryParse(gradeWithSymbols, out isInt);
                    throw new ArgumentException("Please provide a grade in the range 1-6 ", nameof(gradeWithSymbols));
            }
        }
        else if (foundIntInRange)
        {
            this.grades.Add(isInt);
            Console.WriteLine("test");
        }
        else if (!foundIntInRange)
        {
            Console.WriteLine($"Please provide a grade in the range 1-6 ", nameof(gradeWithSymbols));
        }
    }

    public void AddGrade(char grade) 
    {
        switch(grade)
        {
            case 'A':
                    this.grades.Add(6);
                break;
            case 'B':
                this.grades.Add(5);
                break;
            case 'C':
                this.grades.Add(4);
                break;
            case 'D':
                this.grades.Add(3);
                break;
            case 'E':
                this.grades.Add(2);
                break;
            case 'F':
                this.grades.Add(1);
                break;
            default:
                this.grades.Add(0);
                break;
        }
    }   

    public override void AddGrade(double grade)
    {
        if (grade >= 1 && grade <= 6)
        {
            this.grades.Add(grade);
            if (lowGradAdded != null && grade < 3)
            {
                lowGradAdded(this, new EventArgs());
            }

            if (GradeAdded != null)
             
            {
                GradeAdded(this, new EventArgs());
            }
        }
        else
        {
            Console.WriteLine($"Grade '{grade}' has not been added as the value must be in the range 1-6.");
            throw new ArgumentException($"Grade '{nameof(grade)}' has not been added as the value must be in the range 1-6.");
        }
    }
    
    public Statistics GetStatistics()
    {
        var result = new Statistics();
        result.Average = 0.0;
        result.High = double.MinValue;
        result.Low = double.MaxValue;
        foreach (var grade in grades)
        {
            result.Low = Math.Min(grade, result.Low);
            result.High = Math.Max(grade, result.High);
            result.Average += grade;
            // result.Low = Math.Min(grades[i], result.Low);
            //     result.High = Math.Max(grades[i], result.High);
            //      result.Average += grades[i];
        }
        result.Average /= grades.Count;
        Console.WriteLine($"Average is : {result.Average}");
        Console.WriteLine($"Low is : {result.Low}");
        Console.WriteLine($"High is : {result.High}");
        switch (result.Average)
        {
            case var d when d >= 6:
                result.Letter = 'A';
                break;

            case var d when d >= 5:
                result.Letter = 'B';
                break;

            case var d when d >= 4:
                result.Letter = 'C';
                break;

            case var d when d >= 3:
                result.Letter = 'D';
                break;

            case var d when d >= 2:
                result.Letter = 'E';
                break;

            case var d when d >= 1:
                result.Letter = 'F';
                break;

            default:
                result.Letter = 'N';
                break;

        }
        Console.WriteLine($"Letter  : {result.Letter} ");
        return result;
    }

    public void SetNewName(Student student, string newName)
    {
        Boolean noDigInName = true;
        foreach (char i in newName)
        {
            if (char.IsDigit(i))
            {
                noDigInName = false;
                Console.WriteLine("E01 - Invalid name ( Digits in the name are not allowed )"); 
            }
        }
            if (noDigInName)
            {
                student.Name = newName;
                Console.WriteLine($"The name was successfully changed to : {newName}");
            }
        }
}

//public void AddGradeString(string stringToDouble, Employee employee)
//{
//    if (Double.TryParse(stringToDouble, out double result))
//    {
//        employee.AddGrade(result);
//    }

//}
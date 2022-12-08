using System.Diagnostics;

public class Employee
{
    private List<double> grades = new List<double>();
    public Employee(string name)
    {
        this.Name = name;
    }
    public string Name { get; set; }

    public void AddGrade(string symbolsGrade)
    {
        if (symbolsGrade.Equals("1+", || "2+"))

        { 
            switch (symbolsGrade)
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
                    this.grades.Add(0);
                    break;
            }
        }
       } 

    public void AddGrade(char grade) 
    {
        switch(grade)
        {
            case 'A':
                    this.grades.Add(100);
                break;
            case 'B':
                this.grades.Add(80);
                break;
            case 'C':
                this.grades.Add(60);
                break;
            default:
                this.grades.Add(0);
                break;
        }
    }   

    public void AddGrade(double grade)
    {
        if (grade >= 0 && grade <= 100)
        {
            this.grades.Add(grade);
        }
        else
        {
            Console.WriteLine($"Grade '{grade}' has not been added as the value must be in the range 0-100.");

            throw new ArgumentException($"Grade '{nameof(grade)}' has not been added as the value must be in the range 0-100.");
        }
    }

    public Statistics GetStatistics()
    {
        var result = new Statistics();
        result.Average = 0.0;
        result.High = double.MinValue;
        result.Low = double.MaxValue;

        for (int i = 0; i < grades.Count; i++ )
        {
            if (grades[i] == 5 )
            { 
                break;
            }
            result.Low = Math.Min(grades[i], result.Low);
            result.High = Math.Max(grades[i], result.High);
            result.Average += grades[i];
        }
        result.Average /= grades.Count;
        switch(result.Average)
        {
            case var d when d >= 90:
                result.Letter = 'A';
                break;

            case var d when d >= 80:
                result.Letter = 'B';
                break;

            case var d when d >= 60:
                result.Letter = 'C';
                break;

            default:
                result.Letter = 'Z';
                break;
        }
        Console.WriteLine($"Average is : {result.Average}");
        return result;
    }
    public void SetNewName(Employee employee, string newName)
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
            if(noDigInName)
            {
                employee.Name = newName;
                Console.WriteLine($"The name was successfully changed to : {newName}");
            }
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
}

//public void AddGradeString(string stringToDouble, Employee employee)
//{
//    if (Double.TryParse(stringToDouble, out double result))
//    {
//        employee.AddGrade(result);
//    }

//}
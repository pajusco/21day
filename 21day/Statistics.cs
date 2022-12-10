public class Statistics
{
    public double Low;
    public double High;
    public double Sum;
    public int Count;

    public Statistics()
    {
        Count = 0;
        Sum = 0.0;
        High = double.MinValue;
        Low = double.MaxValue;
    }


    public double Average
    {
        get
        {
            return Sum / Count;
        }
    }

    public char Letter
    {
        get
        {
            switch (Average)
            {
                case var d when d >= 6:
                    return 'A';
                  

                case var d when d >= 5:
                    return 'B';
                   

                case var d when d >= 4:
                    return 'C';
                  

                case var d when d >= 3:
                    return 'D';
                   

                case var d when d >= 2:
                    return 'E';
                  

                case var d when d >= 1:
                    return 'F';

                default:
                    return 'N';
            }
        }
    }

    public void Add(double number)
    {
        Sum += number;
        Count += 1;
        Low = Math.Min(number, Low);
        High = Math.Max(number, High);
    }
}
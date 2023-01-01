using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Student;

namespace _21day
{
    internal interface IStudent
    {
        void AddGrade(double grade);
        Statistics GetStatistics();
        string Name { get; }
        event GradeAddedDelegate lowGradAdded;
        event GradeAddedDelegate GradeAdded;


    }
}

namespace _21dayTest
{
    public class EmployeeTests
    {
        [Fact]
        public void Test1()
        {
            // arrange

            var emp = new Employee("adam");
            emp.AddGrade(89.1);
            emp.AddGrade(90.5);
            emp.AddGrade(77.3);


            // act

            var result = emp.GetStatistics();


            // assert

            Assert.Equal(85.6, result.Average, 1);
            Assert.Equal(90.5, result.High);
            Assert.Equal(77.3, result.Low);
        }
    }
}
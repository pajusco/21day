namespace _21dayTest
{
    public class StudentTests
    {
        [Fact]
        public void Test1()
        {

            // arrange
            var emp = new Student("adam");
            emp.AddGrade(3);
            emp.AddGrade(6);
            emp.AddGrade(2);

            // act
            var result = emp.GetStatistics();

            // assert
            Assert.Equal(3.7, result.Average, 1);
            Assert.Equal(6, result.High);
            Assert.Equal(2, result.Low);
        }
    }
}
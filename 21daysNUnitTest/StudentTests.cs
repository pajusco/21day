namespace _21daysNUnitTest
{
    public class StudentTests
    {
        [SetUp]
        public void Setup()
        {
            Test1();
        }

        [Test]
        public void Test1()
        {   
            // arrange
            var emp = new Student("Marcus");
            emp.AddGrade(3);
            emp.AddGrade(6);
            emp.AddGrade(1);

            // act 
            var result = emp.GetStatistics();

            // assert
            Assert.That(result.Average, Is.EqualTo(3.3).Within(0.075));
            Assert.That(result.High, Is.EqualTo(6));
            Assert.That(result.Low, Is.EqualTo(1));
        }
    }
}
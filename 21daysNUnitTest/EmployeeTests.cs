namespace _21daysNUnitTest
{
    public class EmployeeTests
    {
        [SetUp]
        public void Setup()
        {
   
        }

        [Test]
        public void Test1()
        {   
            // arrange
            var emp = new Employee(":D");
            emp.AddGrade(55.5);
            emp.AddGrade(66.6);
            emp.AddGrade(99.9);

            // act 
            var result = emp.GetStatistics();

            // assert
            Assert.That(result.Average, Is.EqualTo(74.0));
            Assert.AreEqual(99.9, result.High);
            Assert.AreEqual(55.5, result.Low);
        }
    }
}
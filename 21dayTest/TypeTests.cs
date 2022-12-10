namespace _21dayTest
{
    public class TypeTests
    {

        public delegate string WriteMessage(string message);

        int counter = 0;

        [Fact]
        public void WriteMessageDelegateCanPointToMethod()
        {
            WriteMessage del = ReturnMessage;
            del += ReturnMessage;
            del += ReturnMessage2;

            var result = del("HELLO");
            Assert.Equal(3, counter);

        }
        string ReturnMessage(string message)
        {
            counter++;
            return message;
        }

        string ReturnMessage2(string message)
        {
            counter++;
            return message.ToUpper();
        }

        [Fact]
        public void GetEmployeeReturnsDiffrentsObjects()
        {
            var emp1 = GetEmployee("Adam");
            var emp2 = GetEmployee("Tomek");
            Assert.NotSame(emp1, emp2);
            Assert.False(Object.ReferenceEquals(emp1, emp2));
        }
        [Fact]
        public void TwoVarsCanReferenceSameObject()
        {
            var emp1 = GetEmployee("Adam");
            var emp2 = emp1;
            Assert.Same(emp1, emp2);
            Assert.True(Object.ReferenceEquals(emp1, emp2));
        }
        [Fact]
        public void CSharpCanPassByRef()
        {
            var emp1 = GetEmployee("Employee 1");
            GetEmployeeSetName(out emp1, "New Name");
            Assert.Equal("New Name", emp1.Name);
        }
        private void GetEmployeeSetName(out Student emp, string name)
        {
            emp = new Student(name);
            
        }
        [Fact]
        public void CanSetNameFromReference()
        { 
            var emp1 = GetEmployee("Adam");
            this.SetName(emp1, "NewName");
            Assert.Equal("NewName", emp1.Name);
            
        }
        private Student GetEmployee(string name)
        {
            return new Student(name);
        }
        private void SetName(Student employee, string name)
        {
            employee.Name = name;
        }

        [Fact]
        public void Test3()
        {
            var x = GetInt();
       SetInt(ref x);
            Assert.Equal(3, x);
        }
        private void SetInt(ref int x)
        {
            x = 3;
        }
        public int GetInt()
        {
            return 3;
        }
        [Fact]
        public void StringsBehaveLikeValueType()
        {
            var x = "Adam";
            var upper = this.MakeUpperCase(x);

            Assert.Equal("Adam", x);
            Assert.Equal("ADAM", upper);
        }

        private string MakeUpperCase(string parametar)
        {
            return parametar.ToUpper();
        }

    }
}

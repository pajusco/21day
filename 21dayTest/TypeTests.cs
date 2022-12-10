namespace _21dayTest
{
    public class TypeTests
    {

        public delegate string WriteMessage(string message);

        [Fact]
        public void WriteMessageDelegateCanPointToMethod()
        {
            WriteMessage del;

            del = ReturnMessage;

        }
        string ReturnMessage(string message)
        {
            return message;
        }

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
        private void GetEmployeeSetName(out Employee emp, string name)
        {
            emp = new Employee(name);
        }
        [Fact]
        public void CanSetNameFromReference()
        { 
            var emp1 = GetEmployee("Adam");
            this.SetName(emp1, "NewName");
            Assert.Equal("NewName", emp1.Name);
            
        }
        private Employee GetEmployee(string name)
        {
            return new Employee(name);
        }
        private void SetName(Employee employee, string name)
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

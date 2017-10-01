using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WcfService1;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestMethod1()
        {
            Service1 service1 = new Service1();
            service1.GetStudent("sdahsda");
        }
        [TestMethod]
        public void TestMethod2()
        {
            Service1 service1 = new Service1();
            service1.GetStudent("Aleks");
        }

        [TestMethod]
        public void TestAddStudent()
        {
            Service1 service1 = new Service1();
            service1.AddStudent("Pitka", "4");

        }

        [TestMethod]
        public void TestDeleteStudent()
        {
            Service1 service1 = new Service1();
            service1.RemoveStudent("Pitka");

        }
        [TestMethod]
        [ExpectedException(typeof(AggregateException))]
        public void TestDeleteStudent1()
        {
            Service1 service1 = new Service1();
            service1.RemoveStudent("sdada");

        }
    }
}

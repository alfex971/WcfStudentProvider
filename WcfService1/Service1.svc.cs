using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfService1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        private static List<Student> list = new List<Student>();

        public Student GetStudent(string name)
        {
            Student a= list.Find(student => student.Name == name);
            return a;
        }

        public void AddStudent(string name, string clas)
        {
            Student student = new Student(name,clas);
            list.Add(student);
        }

        public void RemoveStudent(string name,string clas)
        {
            Student student = new Student(name, clas);
            list.Remove(student);
        }

        public void EditStudetn(string name, string clas)
        {
            var a = list.Find(student => student.Name == name);
            a.Clas = clas;
            list.Add(a);
        }

        public List<Student> GetStudents()
        {
           return list.FindAll(student => student.Name != null);
        }
    }
}

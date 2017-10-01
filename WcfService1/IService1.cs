using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfService1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        Student GetStudent(string name);
        [OperationContract]
        int AddStudent(string name, string clas);

        [OperationContract]
        int RemoveStudent(string name);

        [OperationContract]
        void EditStudent(string name, string clas);

        //[OperationContract]
       // List<Student> GetStudents();
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class Student
    {
        //public Student(string name, string clas)
        //{
        //    Name = name;
        //    Clas = clas;
        //}
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Clas { get; set; }
        public override string ToString()
        {
            return $"{Name}  {Clas}";
        }
    }
}

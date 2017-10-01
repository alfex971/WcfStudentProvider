using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Migrations;
using System.Data.SqlClient;
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
        public static Student Student = new Student();
        private const string connectionString =
                "Data Source=alfexdb.database.windows.net;Initial Catalog=StudentDB;Integrated Security=False;User ID=alfex971;Password=Varchev1!;Connect Timeout=60;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"
            ;

        private static Student ReadStudent(IDataRecord reader)
        {
            int id = reader.GetInt32(0);
            string name = reader.GetString(1);
            string clas = reader.GetString(2);
            // DateTime timeStamp = reader.GetDateTime(3);
            Student student = new Student
            {
                Id = id,
                Name = name,
                Clas = clas,
                //TimeStamp = timeStamp
            };
            return student;
        }

        public Student GetStudent(string name)
        {
            const string getStudentByName = "select * from Student where name=@name";
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                using (SqlCommand selectCommand = new SqlCommand(getStudentByName, sqlConnection))
                {
                    selectCommand.Parameters.AddWithValue("@name", name);
                    using (SqlDataReader reader = selectCommand.ExecuteReader())
                    {
                        if (!reader.HasRows)
                        {
                            throw new ArgumentNullException("name","Doesn`t exist in the database");
                            //return null;
                        }
                        reader.Read();
                        var student = ReadStudent(reader);
                        Student = student;
                        return student;
                    }
                }
            }
            //Student a= list.Find(student => student.Name == name);
        }

        public int AddStudent(string name, string clas)
        {
            const string insertQuery = "insert into Student (Name, Class) values (@name, @class)";
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                using (SqlCommand insertCommand = new SqlCommand(insertQuery, sqlConnection))
                {
                    insertCommand.Parameters.AddWithValue("@name", name);
                    insertCommand.Parameters.AddWithValue("@class", clas);
                    int rowsAffected = insertCommand.ExecuteNonQuery();
                    if (rowsAffected==0)
                    {
                        throw new InvalidExpressionException();
                    }
                    return rowsAffected;
                }
            }
            //  _studentDbEntities.Students.AddOrUpdate(new Student(){Name = name,Class = clas});
            //Student student = new Student(name,clas);
            //list.Add(student);
        }

        public int RemoveStudent(string name)
        {
            const string removeQuery = "delete from Student where name=@name";
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                using (SqlCommand deleteCommand = new SqlCommand(removeQuery, sqlConnection))
                {
                    deleteCommand.Parameters.AddWithValue("@name", name);
                    int rowsAffected = deleteCommand.ExecuteNonQuery();
                    if (rowsAffected==0)
                    {
                        throw new AggregateException("There is no such Student");
                    }
                    return rowsAffected;
                }
                //Student student = new Student(name, clas);
                //list.Remove(student);
            }
        }

        public void EditStudent(string name, string clas)
        {
            //_studentDbEntities.Students.
            //var a = list.Find(student => student.Name == name);
            //a.Clas = clas;
            //list.Add(a);
        }

        //public List<Student> GetStudents()
        //{
        ////    _studentDbEntities.Students.Find()
        ////   return list.FindAll(student => student.Name != null);
        //}
    }
}


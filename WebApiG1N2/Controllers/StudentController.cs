using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.SqlClient;
using WebApiG1N2.Models;

namespace WebApiG1N2.Controllers
{
    public class StudentController : ApiController
    {

        Student student = new Student();

        static string testvalue = "Julian Jorna";
        static int testvalue2 = 12345;
        static int testvalue3 = 12345;

        // GET: api/Student
        public IEnumerable<String> Get()
        {

            SqlConnection conn = DBConnection.GetConnection();
            SqlCommand cmd;
            SqlDataReader rdr;
            String query;
            List<String> output = new List<string>();

            try
            {
                conn.Open();


                query = "select * from Student";
                cmd = new SqlCommand(query, conn);

                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {

                    //output.Add(new Student(Int32.Parse(rdr.GetValue(0).ToString()),
                    //                                 rdr.GetValue(1).ToString(),
                    //                                 rdr.GetValue(2).ToString());

                    output.Add("{Barcode: " + rdr.GetValue(0)
                                 + ", StudentID: \"" + rdr.GetValue(1) + "\""
                                 + ", Name: \"" + rdr.GetValue(2) + "\"}");
                }

            }
            catch (Exception e)
            {
                output.Clear();
                output.Add(e.Message);

            }
            finally
            {
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
            }

            return output;


        }

        // GET: api/Student/5
        public string Get(int id)
        {
            SqlConnection conn = DBConnection.GetConnection();
            SqlCommand cmd;
            SqlDataReader rdr;
            String query;
            String output = "";


            try
            {
                conn.Open();


                query = "select * from Student where Barcode =" + id;
                cmd = new SqlCommand(query, conn);

                rdr = cmd.ExecuteReader();

                //while (rdr.Read())
                //{
                //    //output = output + Barcode:  + rdr.GetValue(0)
                //    //             + "StudentID: + rdr.GetValue(1) + "\""
                //    //             + ", Name: \"" + rdr.GetValue(2) + "\"}";
                //}


                while (rdr.Read())
                {
                    output = output + ("{Barcode: " + rdr.GetValue(0)
                                 + ", StudentID: \"" + rdr.GetValue(1) + "\""
                                 + ", Name: \"" + rdr.GetValue(2) + "\"}");
                }

            }
            catch (Exception e)
            {
                output = "";
                output = output + e.Message;

            }
            finally
            {
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
            }

            return output;
        }

        // POST: api/Student
        public string Post([FromBody]Student stu)
        {
            SqlConnection conn = DBConnection.GetConnection();
            SqlCommand cmd;
            //SqlDataAdapter rda;
            String query;
            string output = "";

            try
            {
                conn.Open();


                query = "Insert into Student (Barcode,StudentID,Name) values ("
                    + stu.Barcode +", '"
                    + stu.StudentID + "', '"
                    + stu.Name+"' )";
                cmd = new SqlCommand(query, conn);
                //rda = new SqlDataAdapter();

                cmd = new SqlCommand(query, conn);
                //cmd.ExecuteNonQuery();

                output = cmd.ExecuteNonQuery().ToString() + " Rows Inserted";


            }
            catch (Exception e)
            {
                output = e.Message;

            }
            finally
            {
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            return output;
        }

        // PUT: api/Student/5
        public void Put(int id, [FromBody]string value)
        {
            SqlConnection conn = DBConnection.GetConnection();
            SqlCommand cmd;
            SqlDataAdapter rda;
            String query;

            string output = "";

            try
            {
                conn.Open();


                query = "Update student set name='" + testvalue + "' where Barcode=" + id;
                cmd = new SqlCommand(query, conn);
                rda = new SqlDataAdapter();

                rda.UpdateCommand = new SqlCommand(query, conn);
                rda.UpdateCommand.ExecuteNonQuery();

                output = "Query Complete";


            }
            catch (Exception e)
            {
                output = "";
                output = output + e.Message;

            }
            finally
            {
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        // DELETE: api/Student/5
        public void Delete(int id)
        {
            SqlConnection conn = DBConnection.GetConnection();
            SqlCommand cmd;
            SqlDataAdapter rda;
            String query;

            string output = "";

            try
            {
                conn.Open();


                query = "delete Student where Barcode=" + id;
                cmd = new SqlCommand(query, conn);
                rda = new SqlDataAdapter();

                rda.DeleteCommand = new SqlCommand(query, conn);
                rda.DeleteCommand.ExecuteNonQuery();

                output = "Student Deletion Complete";


            }
            catch (Exception e)
            {
                output = "";
                output = output + e.Message;

            }
            finally
            {
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }
    }
}

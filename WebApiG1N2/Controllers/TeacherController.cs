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
    public class TeacherController : ApiController
    {
        // GET: api/Teacher
        public IEnumerable<string> Get()
        {
            SqlConnection conn = DBConnection.GetConnection();
            SqlCommand cmd;
            SqlDataReader rdr;
            String query;
            List<String> output = new List<string>();

            try
            {
                conn.Open();


                query = "select * from Teacher";
                cmd = new SqlCommand(query, conn);

                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {

                    //output.Add(new Student(Int32.Parse(rdr.GetValue(0).ToString()),
                    //                                 rdr.GetValue(1).ToString(),
                    //                                 rdr.GetValue(2).ToString());

                    output.Add("{TName: " + rdr.GetValue(0) + "\"}");
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

        // GET: api/Teacher/5
        public string Get(string id)
        {
            SqlConnection conn = DBConnection.GetConnection();
            SqlCommand cmd;
            SqlDataReader rdr;
            String query;
            String output = "";


            try
            {
                conn.Open();


                query = "select * from Teacher where TName =" + id;
                cmd = new SqlCommand(query, conn);

                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    output = output + ("{TName: " + rdr.GetValue(0) + "\"}");
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

        // POST: api/Teacher
        public string Post([FromBody]Teacher te)
        {
            SqlConnection conn = DBConnection.GetConnection();
            SqlCommand cmd;
            //SqlDataAdapter rda;
            String query;
            string output = "";

            try
            {
                conn.Open();


                query = "Insert into Teacher (TName) values ("
                    + te.TName + "' )";
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

        // PUT: api/Teacher/5
        public string Put(string id, [FromBody]Teacher te)
        {
            SqlConnection conn = DBConnection.GetConnection();
            SqlCommand cmd;
            //SqlDataAdapter rda;
            String query;

            string output = "";

            try
            {
                conn.Open();


                query = "Update Teacher set TName='" + te.TName + "' where TName=" + id;
                cmd = new SqlCommand(query, conn);
                //rda = new SqlDataAdapter();

                output = cmd.ExecuteNonQuery().ToString() + " Rows Updated";



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

        // DELETE: api/Teacher/5
        public string Delete(string id)
        {
            SqlConnection conn = DBConnection.GetConnection();
            SqlCommand cmd;
            //SqlDataAdapter rda;
            String query;

            string output = "";

            try
            {
                conn.Open();


                query = "delete Teacher where TName=" + id;
                cmd = new SqlCommand(query, conn);
                //rda = new SqlDataAdapter();
                output = cmd.ExecuteNonQuery().ToString() + " Teacher Successfully Deleted.";


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
    }
}

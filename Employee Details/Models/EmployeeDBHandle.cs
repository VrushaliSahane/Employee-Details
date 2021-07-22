using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Documents;

namespace Employee_Details.Models
{
    public class EmployeeDBHandle
    {
        private SqlConnection con;
        private void connection()
        {
            string constraing = ConfigurationManager.ConnectionStrings["master"].ToString();
            con = new SqlConnection(constraing);
        }

        //Add New Employee
        public int AddEmployee(EmployeeModel semployee)
        {
            connection();
            SqlCommand cmd = new SqlCommand("AddEmployee", con);
            cmd.CommandType = CommandType.StoredProcedure;
            if (semployee != null)
            {
                cmd.CommandText = "AddEmployee";
                cmd.Parameters.AddWithValue("@emp_Firstname", semployee.FirstName);
                cmd.Parameters.AddWithValue("@emp_Lastname", semployee.LastName);
                cmd.Parameters.AddWithValue("@emp_Gender", semployee.Gender);
                cmd.Parameters.AddWithValue("@emp_DOB", semployee.DOB);
                cmd.Parameters.AddWithValue("@emp_Address", semployee.Address);
                cmd.Parameters.AddWithValue("@emp_Photo", semployee.Photo);
                con.Open();
                int i = cmd.ExecuteNonQuery();
                con.Close();
                return i;
            }
            else { return 0; }
        }

        //Get Employee
        public List<EmployeeModel> GetEmployeeDetails()
        {
            connection();
            SqlCommand cmd = new SqlCommand("GetEmployee", con);
            cmd.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            con.Open();
            dt.Load(cmd.ExecuteReader());
            List<EmployeeModel> lst = new List<Models.EmployeeModel>();
            foreach (DataRow item in dt.Rows)
            {
                EmployeeModel emp = new EmployeeModel();
                emp.Address = (string)item["emp_Address"];
                emp.DOB = (DateTime)item["emp_DOB"];
                emp.FirstName = (string)item["emp_Firstname"];
                emp.Gender = (string)item["emp_Gender"];
                emp.LastName = (string)item["emp_Lastname"];
                emp.Photo = (byte[])item["emp_Photo"];
                lst.Add(emp);
            }
            return lst;
        }
    }
}

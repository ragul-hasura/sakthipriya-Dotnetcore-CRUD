using Microsoft.Data.SqlClient;
using SimpleEmpCRUDAJAX.Models;
using System.Data;

namespace SimpleEmpCRUDAJAX.Repository
{
    public class EmpRepository : IEmpRepository
    {

        private readonly EmployeeDBContext _context;
        private IConfiguration _Configuration;
        string connection = "";
        public EmpRepository(IConfiguration configuration)
        {
            _Configuration = configuration;
            connection = this._Configuration.GetConnectionString("EmpDB");
        }

        //Method for Get Employee record
        public List<EmployeeDetails> getemployeedetails()
        {
            //Return list of all Employees  
            var lst = new List<EmployeeDetails>();
            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();
                SqlCommand com = new SqlCommand("GetEmployeeDetails", con);
                com.CommandType = CommandType.StoredProcedure;
                SqlDataReader rdr = com.ExecuteReader();
                while (rdr.Read())
                {
                    lst.Add(new EmployeeDetails
                    {
                        EmpId = Convert.ToInt32(rdr["EmpId"]),
                        Name = rdr["Name"].ToString(),
                        Age = Convert.ToInt32(rdr["Age"]),
                        State = rdr["State"].ToString(),
                        Country = rdr["Country"].ToString(),
                        Salary = Convert.ToDecimal(rdr["Salary"].ToString())
                    });
                }
                return lst;
            }

        }

        //Method for Adding Employee record
        public int Add(EmployeeDetails emp)
        {
            int i;
            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();
                SqlCommand com = new SqlCommand("InsertUpdateEmployeeDetails", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@EmpId", emp.EmpId);
                com.Parameters.AddWithValue("@Name", emp.Name);
                com.Parameters.AddWithValue("@Age", emp.Age);
                com.Parameters.AddWithValue("@Salary", emp.Salary);
                com.Parameters.AddWithValue("@State", emp.State);
                com.Parameters.AddWithValue("@Country", emp.Country);
                com.Parameters.AddWithValue("@Action", "Insert");
                i = com.ExecuteNonQuery();
            }
            return i;
        }


        //Method for Updating Employee record
        public int Update(EmployeeDetails emp)
        {
            int i;
            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();
                SqlCommand com = new SqlCommand("InsertUpdateEmployeeDetails", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@EmpId", emp.EmpId);
                com.Parameters.AddWithValue("@Name", emp.Name);
                com.Parameters.AddWithValue("@Age", emp.Age);
                com.Parameters.AddWithValue("@State", emp.State);
                com.Parameters.AddWithValue("@Salary", emp.Salary);
                com.Parameters.AddWithValue("@Country", emp.Country);
                com.Parameters.AddWithValue("@Action", "Update");
                i = com.ExecuteNonQuery();
            }
            return i;
        }


        //Method for Deleting an Employee
        public int Delete(int ID)
        {
            int i;
            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();
                SqlCommand com = new SqlCommand("DeleteEmployeeDetails", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@EmpId", ID);
                //com.Parameters.AddWithValue("@Action", "Delete");
                i = com.ExecuteNonQuery();
            }
            return i;
        }

        public IEnumerable<EmployeeDetails> editEmployee(int id)
        {
            var lst = new List<EmployeeDetails>();
            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();
                SqlCommand com = new SqlCommand("EditEmployeeDetails", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@EmpId", id);
                SqlDataReader rdr = com.ExecuteReader();
                while (rdr.Read())
                {
                    lst.Add(new EmployeeDetails
                    {
                        EmpId = Convert.ToInt32(rdr["EmpId"]),
                        Name = rdr["Name"].ToString(),
                        Age = Convert.ToInt32(rdr["Age"]),
                        State = rdr["State"].ToString(),
                        Country = rdr["Country"].ToString(),
                        Salary = Convert.ToDecimal(rdr["Salary"].ToString())
                    });
                }
                return lst;
            }
        }
    }
}

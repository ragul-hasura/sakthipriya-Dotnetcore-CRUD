using Microsoft.Data.SqlClient;
using SimpleEmpCRUDAJAX.Models;
using System.Data;
using System.Configuration;

namespace SimpleEmpCRUDAJAX.Repository
{
    public class EmpRepository : IEmpRepository
    {

        private readonly EmployeeDBContext _context;
        //public EmpRepository(EmployeeDBContext context)
        //{
        //    _context = context;
        //}

        //Method for getting Employee record
        public IEnumerable<EmployeeDetails> getemployeedetails()
        {
            //Return list of all Employees  

            //string cs = System.Configuration.ConfigurationManager.ConnectionStrings["EmpDB"].ConnectionString;

            var lst = new List<EmployeeDetails>();
            using (SqlConnection con = new SqlConnection("Data Source=DESKTOP-HSSF9LO;Initial Catalog=EmployeeDB;Integrated Security=True;Trusted_Connection=True; MultipleActiveResultSets=true"))
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
                        Salary= Convert.ToDecimal(rdr["Salary"].ToString())
                    });
                }
                return lst;
            }

            // return _context._employees.ToList();
        }

        public int Add(EmployeeDetails emp)
        {
            int i;
            using (SqlConnection con = new SqlConnection("Data Source=DESKTOP-HSSF9LO;Initial Catalog=EmployeeDB;Integrated Security=True;Trusted_Connection=True; MultipleActiveResultSets=true"))
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
            using (SqlConnection con = new SqlConnection("Data Source=DESKTOP-HSSF9LO;Initial Catalog=EmployeeDB;Integrated Security=True;Trusted_Connection=True; MultipleActiveResultSets=true"))
            {
                con.Open();
                SqlCommand com = new SqlCommand("InsertUpdateEmployeeDetails", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Id", emp.EmpId);
                com.Parameters.AddWithValue("@Name", emp.Name);
                com.Parameters.AddWithValue("@Age", emp.Age);
                com.Parameters.AddWithValue("@State", emp.State);
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
            using (SqlConnection con = new SqlConnection("Data Source=DESKTOP-HSSF9LO;Initial Catalog=EmployeeDB;Integrated Security=True;Trusted_Connection=True; MultipleActiveResultSets=true"))
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

        public EmployeeDetails editEmployee(int id)
        {
            throw new NotImplementedException();
        }
    }
}

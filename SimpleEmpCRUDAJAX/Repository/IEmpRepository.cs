using SimpleEmpCRUDAJAX.Models;

namespace SimpleEmpCRUDAJAX.Repository
{
    public interface IEmpRepository
    {
        public List<EmployeeDetails> getemployeedetails();
        public IEnumerable<EmployeeDetails> editEmployee(int id);
        public int Add(EmployeeDetails emp);
        public int Update(EmployeeDetails emp);
        public int Delete(int id);

    }
}

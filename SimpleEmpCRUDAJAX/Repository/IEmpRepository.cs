using SimpleEmpCRUDAJAX.Models;

namespace SimpleEmpCRUDAJAX.Repository
{
    public interface IEmpRepository
    {
        public IEnumerable<EmployeeDetails> getemployeedetails();
        public EmployeeDetails editEmployee(int id);
        public int Add(EmployeeDetails emp);
        public int Update(EmployeeDetails emp);
        public int Delete(int id);

    }
}

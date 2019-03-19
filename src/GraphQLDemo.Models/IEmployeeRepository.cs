using System.Collections.Generic;
using System.Threading.Tasks;


namespace GraphQLDemo.Models
{
    public interface IEmployeeRepository
    {
        Task<List<Employee>> GetEmployeesAsync();
    }
}

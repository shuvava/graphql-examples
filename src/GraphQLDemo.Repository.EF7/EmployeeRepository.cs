using System.Collections.Generic;
using System.Threading.Tasks;

using GraphQLDemo.Models;

using Microsoft.EntityFrameworkCore;


namespace GraphQLDemo.Repository.EF7
{
    public class EmployeeRepositoryEf7: IEmployeeRepository
    {
        private readonly GraphQLDemoContext _context;


        public EmployeeRepositoryEf7(GraphQLDemoContext context)
        {
            _context = context; 
        }
        public Task<List<Employee>> GetEmployeesAsync()
        {
            return _context.Employee.ToListAsync();
        }
    }
}

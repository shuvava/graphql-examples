using GraphQL.Types;

using GraphQLDemo.Models;


namespace GraphQLDemo.Implementation
{
    public class EmployeeQuery : ObjectGraphType  
    {  
        public EmployeeQuery(IEmployeeRepository employeeRepository)  
        {  
            Field<ListGraphType<EmployeeType>>(  
                "employees",  
                resolve: context => employeeRepository.GetEmployeesAsync()  
            );  
        }  
    }
}

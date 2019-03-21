using GraphQL.Types;

using GraphQLDemo.Models;


namespace GraphQLDemo.Implementation
{
    public class EmployeeQuery : ObjectGraphType  
    {  
        public EmployeeQuery(IEmployeeRepository employeeRepository)  
        {  
            Field<ListGraphType<EmployeeType>>("employees", resolve: context => employeeRepository.GetEmployeesAsync());

            Field<EmployeeType>("employee",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id" }),
                resolve: context => {  
                    var id = context.GetArgument<int>("id");  
                    return employeeRepository.GetEmployeeByIdAsync(id);  
                }
            );
        }  
    }
}

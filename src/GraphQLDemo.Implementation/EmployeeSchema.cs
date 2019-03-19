using GraphQL;
using GraphQL.Types;


namespace GraphQLDemo.Implementation
{
    public class EmployeeSchema : Schema  
    {  
        public EmployeeSchema(IDependencyResolver resolver) : base(resolver)  
        {  
            Query = resolver.Resolve<EmployeeQuery>();  
        }  
    }
}

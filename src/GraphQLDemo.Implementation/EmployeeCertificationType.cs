using GraphQL.Types;

using GraphQLDemo.Models;


namespace GraphQLDemo.Implementation
{
    public class EmployeeCertificationType: ObjectGraphType<Certification>
    {  
        public EmployeeCertificationType()  
        {  
            Field(t => t.Id);  
            Field(t => t.Title);  
            Field(t => t.Month, nullable: true);
            Field(t => t.Year, nullable: true);
            Field(t => t.Provider);  
        }  
    }
}

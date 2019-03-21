using System;

using GraphQL.DataLoader;
using GraphQL.Types;

using GraphQLDemo.Models;


namespace GraphQLDemo.Implementation
{
    public class EmployeeType : ObjectGraphType<Employee>  
    {  
        public EmployeeType(ICertificationRepository repository, IDataLoaderContextAccessor dataLoaderContextAccessor)
        {  
            Field(a => a.Id);
            Field(a => a.Name);
            Field(a => a.Email);
            Field(a => a.Mobile);
            Field(a => a.Company);
            Field(a => a.Address);
            Field(a => a.ShortDescription);
            Field(a => a.LongDescription);
            Field<ListGraphType<EmployeeCertificationType>>("certifications_old", resolve: context => repository.GetCertificationByEmployeeAsync(context.Source.Id));
            Field<ListGraphType<EmployeeCertificationType>>("certifications", resolve: context =>
            {
                var loader = dataLoaderContextAccessor.Context.GetOrAddCollectionBatchLoader<long, Certification>(  
                    "GetCertificationByEmployee", repository.GetCertificationByEmployeeAsync);  
  
                return loader.LoadAsync(context.Source.Id);
            });
        }
    }
}

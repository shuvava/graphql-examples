using System.Collections.Generic;
using System.Threading.Tasks;

using GraphQL.Client;
using GraphQL.Common.Request;

using GraphQLDemo.Models;

using Microsoft.AspNetCore.Mvc;


namespace GraphQLDemo.WebApp.Controllers
{
    [Route("/employee")]
    /***
     * Example of Client connection to GraphQl
     */
    public class EmployeeController: ControllerBase
    {
        private const string BaseUrl = "http://localhost:5000/graphql";

        [HttpGet]
        public async Task<List<Employee>> Get()
        {
            using (var client = new GraphQLClient(BaseUrl))  
            {  
                var query = new GraphQLRequest
                {  
                    Query = @"
                        { employees
                            { name email }
                        }",
                };  
                var response = await client.PostAsync(query);
                return response.GetDataFieldAs<List<Employee>>("employees");
            }
        }

        [HttpGet("withCerts")]
        public async Task<List<Employee>> GetWithCert()
        {
            using (var client = new GraphQLClient(BaseUrl))  
            {  
                var query = new GraphQLRequest
                {  
                    Query = @"
                        { employees
                            {
                                name email
                                certifications
                                    { title }
                            }
                        }",
                };  
                var response = await client.PostAsync(query);
                return response.GetDataFieldAs<List<Employee>>("employees");
            }
        }

        [HttpGet("{id}")]
        public async Task<Employee> Get(int id)
        {
            using (var client = new GraphQLClient(BaseUrl))
            {  
                var query = new GraphQLRequest  
                {  
                    Query = @"   
                        query employeeQuery($employeeId: ID!)
                        { employee(id: $employeeId)
                            { id name email }
                        }",  
                    Variables = new { employeeId = id }
                };  
                var response = await client.PostAsync(query);
                return response.GetDataFieldAs<Employee>("employee");
            }
        }
    }
}

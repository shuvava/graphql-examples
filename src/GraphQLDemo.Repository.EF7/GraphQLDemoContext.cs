using GraphQLDemo.Models;

using Microsoft.EntityFrameworkCore;


namespace GraphQLDemo.Repository.EF7
{
    public class GraphQLDemoContext: DbContext
    {
        public GraphQLDemoContext()
        {
            
        }
        public GraphQLDemoContext(DbContextOptions<GraphQLDemoContext> options)
        {
            
        }
        public virtual DbSet<Employee> Employee { get; set; } 
    }
}

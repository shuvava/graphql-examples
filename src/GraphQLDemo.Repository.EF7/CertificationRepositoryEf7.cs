using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQLDemo.Models;

using Microsoft.EntityFrameworkCore;


namespace GraphQLDemo.Repository.EF7
{
    public class CertificationRepositoryEf7 : ICertificationRepository
    {
        private readonly GraphQLDemoContext _context;


        public CertificationRepositoryEf7(GraphQLDemoContext context) => _context = context;

        public Task<List<Certification>> GetCertificationByEmployeeAsync(long employeeId)
        {
            return _context.Certification.Where(a => a.Id == employeeId).ToListAsync();
        }


        public async Task<ILookup<long, Certification>> GetCertificationByEmployeeAsync(IEnumerable<long> employeeIds)
        {
            var reviews = await _context.Certification.Where(a => employeeIds.Contains(a.EmployeeId)).ToListAsync();  
            return reviews.ToLookup(r => r.EmployeeId);
        }
    }
}

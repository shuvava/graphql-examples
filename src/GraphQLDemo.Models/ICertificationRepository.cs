using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace GraphQLDemo.Models
{
    public interface ICertificationRepository
    {
        Task<List<Certification>> GetCertificationByEmployeeAsync(long employeeId);
        Task<ILookup<long, Certification>> GetCertificationByEmployeeAsync(IEnumerable<long> employeeIds);
    }
}

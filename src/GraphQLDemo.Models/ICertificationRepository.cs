using System.Collections.Generic;
using System.Threading.Tasks;


namespace GraphQLDemo.Models
{
    public interface ICertificationRepository
    {
        Task<List<Certification>> GetCertificationByEmployeeAsync(long employeeId);
    }
}


using ASOS.Domain.Entities;

namespace ASOS.Domain.Interfaces.Services
{
    public interface ICompanyService
    {
        Company GetById(int id);
    }
}
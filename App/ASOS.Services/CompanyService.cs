using System;
using ASOS.Domain.Entities;
using ASOS.Domain.Interfaces.Repository;
using ASOS.Domain.Interfaces.Services;
using ASOS.Infrastructure.Data;

namespace ASOS.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly IGenericRepository<Company> _companyRepository;
        public CompanyService(IGenericRepository<Company> companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public CompanyService(): this(new CompanyRepository())
        {

        }


        public Company GetById(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException(nameof(id));
            }

            return _companyRepository.GetById(id);
        }
    }
}

using System;
using ASOS.Domain.Entities;
using ASOS.Domain.Enums;
using ASOS.Domain.Interfaces.Repository;
using ASOS.Domain.Interfaces.Services;
using ASOS.Infrastructure.Data;
using ASOS.Services.Factory;


namespace ASOS.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IGenericRepository<Customer> _customerRepository;
        private readonly IGenericRepository<Company> _companyRepository;
        private readonly ICreditCheckFactory _creditCheckFactory;

        public CustomerService(IGenericRepository<Customer> customerRepository, IGenericRepository<Company> companyRepository, ICreditCheckFactory creditCheckFactory)
        {
            _customerRepository = customerRepository;
            _companyRepository = companyRepository;
            _creditCheckFactory = creditCheckFactory;
        }

        public CustomerService(): this(new CustomerRepository(), new CompanyRepository(), new CreditCheckFactory())
        {

        }

        public bool AddCustomer(Customer customer)
        {
            if (!Validate(customer)) return false;

            var company = _companyRepository.GetById(customer.Company.Id);

            if (company == null)
            {
                return false;
            }

            //get classification
            var hasCustomerPassedCreditCheck = _creditCheckFactory.DoCreditCheck(company.Classification, customer);

            if (hasCustomerPassedCreditCheck)
            {
                _customerRepository.Add(customer);
                return true;
            }
            return false;
        }

        private static bool Validate(Customer customer)
        {
            if (customer == null)
            {
                throw new ArgumentNullException(nameof(customer));
            }

            if (string.IsNullOrEmpty(customer.FirstName) || string.IsNullOrEmpty(customer.Surname))
            {
                return false;
            }

            if (!customer.EmailAddress.Contains("@") && !customer.EmailAddress.Contains("."))
            {
                return false;
            }

            var now = DateTime.Now;
            int age = now.Year - customer.DateOfBirth.Year;
            if (now.Month < customer.DateOfBirth.Month ||
                (now.Month == customer.DateOfBirth.Month && now.Day < customer.DateOfBirth.Day)) age--;

            if (age < 21)
            {
                return false;
            }
            return true;
        }
    }
}

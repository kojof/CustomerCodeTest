using System;
using ASOS.Domain.Entities;
using ASOS.Domain.Enums;
using ASOS.Infrastructure.Data;
using ASOS.Services;
using ASOS.Services.Factory;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ASOS.UnitTests
{
    [TestClass]
    public class CustomerServiceUnitTests
    {
        private CustomerService _customerService;
        private Customer _customer;

        public CustomerServiceUnitTests()
        {
            //Due to time constraints, but use Moq to mock these external dependencies
            _customerService = new CustomerService(new CustomerRepository(), new CompanyRepository(), new CreditCheckFactory());
            _customer = new Customer();
        }

        [TestMethod]
        public void AddCustomer_FirstNameOrSurname_IsNullOrEmpty_ThenReturnFalse()
        {
            Assert.IsFalse(_customerService.AddCustomer(_customer));
        }

        [TestMethod]
        public void AddCustomer_Email_IsInValid_ThenReturnFalse()
        {
            _customer.EmailAddress = "jonjonestestcom";
            Assert.IsFalse(_customerService.AddCustomer(_customer));
        }

        [TestMethod]
        public void AddCustomer_IfCompanyIsLessThanOrEqualToZero_ThenReturnFalse()
        {
            _customer.FirstName = "jon";
            _customer.Surname = "jones";
            _customer.EmailAddress = "jone.jones@hotmail.com";
            Assert.IsFalse(_customerService.AddCustomer(_customer));
        }

        [TestMethod]
        public void AddCustomer_IfCustomerIsAGoldCustomer_ThenReturnTrue()
        {
            _customer = GetCustomer();
            //_customer.Company = new Company();

            _customer.Company = GetCompany(Classification.Gold);
            Assert.IsTrue(_customerService.AddCustomer(_customer));
        }

        [TestMethod]
        public void AddCustomer_IfCustomerIsASilverCustomer_ThenReturnTrue()
        {
            _customer = GetCustomer();
            _customer.Company = GetCompany(Classification.Silver);
            Assert.IsTrue(_customerService.AddCustomer(_customer));
        }

        [TestMethod]
        public void AddCustomer_IfCustomerIsABronzeCustomer_ThenReturnTrue()
        {
            _customer = GetCustomer();

            _customer.Company = GetCompany(Classification.Bronze);
            Assert.IsTrue(_customerService.AddCustomer(_customer));
        }

        private Customer GetCustomer()
        {
            var customer = new Customer
            {
                FirstName = "jon",
                EmailAddress = "jon.jones@hotmail.com",
                Surname = "jones",
                DateOfBirth = DateTime.Now.Date.AddYears(-50),
            };
            return customer;
        }

        private Company GetCompany(Classification classification)
        {
            var company = new Company
            {
               Id = 1,
               Name = "Yes Technologies",
               Classification = classification
            };
            return company;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASOS.Domain.Entities;
using ASOS.Domain.Enums;
using ASOS.Domain.Interfaces.ExternalServices;
using ASOS.Domain.Interfaces.Services;
using ASOS.Infrastructure.ServiceReference;

namespace ASOS.Services.Factory
{
    public class CreditCheckFactory : ICreditCheckFactory
    {private ICustomerCreditService _customerCreditService;

        private bool _hasCreditLimit { get; set; }
        private int _creditLimit { get; set; }

        public  CreditCheckFactory(ICustomerCreditService customerCreditService)
        {
            _customerCreditService = customerCreditService;
        }

        public CreditCheckFactory(): this(new CustomerCreditServiceClient())
        {
           
        }

        public bool DoCreditCheck(Classification classification, Customer customer)
        {
            if (classification == Classification.Gold)
            {
                GoldCreditCheck();
            }
            else if (classification == Classification.Silver)
            {
                SilverCreditCheck(customer);
            }
            else if (classification == Classification.Bronze)
            {
                // Do credit check
               BronzeCreditCheck(customer);
            }
            return HasCustomerPassedCreditCheck();
        }

        private void GoldCreditCheck()
        {
            // Skip credit check
            _hasCreditLimit = false;
        }

        private void SilverCreditCheck(Customer customer)
        {
            // Do credit check and double credit limit
            _hasCreditLimit = true;

            var creditLimit = GetCreditLimit(customer);
            creditLimit = creditLimit * 2;
            _creditLimit = creditLimit;

        }

        private void BronzeCreditCheck(Customer customer)
        {
            // Do credit check
            _hasCreditLimit = true;
            
            var creditLimit = GetCreditLimit(customer);
             _creditLimit = creditLimit;
        }

        private bool HasCustomerPassedCreditCheck()
        {
            if (_hasCreditLimit && _creditLimit < 500)
            {
               return false;
            }
            return true;
        }

        private int GetCreditLimit(Customer customer)
        {
            return _customerCreditService.GetCreditLimit(customer.FirstName, customer.Surname, customer.DateOfBirth);
        }
    }
}

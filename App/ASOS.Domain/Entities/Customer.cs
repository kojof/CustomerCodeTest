using System;

namespace ASOS.Domain.Entities
{
    public class Customer : ICustomer
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string Surname { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string EmailAddress { get; set; }

        public bool HasCreditLimit { get; set; }

        public int CreditLimit { get; set; }

        public Company Company { get; set; }
        public Customer DoCreditCheck()
        {
            throw new NotImplementedException();
        }
    }

    
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASOS.Domain.Entities
{public interface ICustomer
    {
        int Id { get; set; }
        string FirstName { get; set; }
        string Surname { get; set; }
        DateTime DateOfBirth { get; set; }
        string EmailAddress { get; set; }
        bool HasCreditLimit { get; set; }
        int CreditLimit { get; set; }
        Company Company { get; set; }
        Customer DoCreditCheck();
    }
}

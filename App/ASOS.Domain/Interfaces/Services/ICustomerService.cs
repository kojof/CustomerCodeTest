using System;
using ASOS.Domain.Entities;

namespace ASOS.Domain.Interfaces.Services
{
    public interface ICustomerService
    {
        bool AddCustomer(Customer customer);
    }
}
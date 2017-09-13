using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASOS.Domain.Entities;
using ASOS.Domain.Interfaces.Repository;

namespace ASOS.Infrastructure.Data
{
    public class CustomerRepository: IGenericRepository<Customer>
    {
        public void Add(Customer customer)
        {
            DataAccess.CustomerDataAccess.AddCustomer(customer);
        }

        public Customer GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}

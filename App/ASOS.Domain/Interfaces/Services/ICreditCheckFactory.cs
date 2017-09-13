using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASOS.Domain.Entities;
using ASOS.Domain.Enums;

namespace ASOS.Domain.Interfaces.Services
{
    public interface ICreditCheckFactory
    {
        bool DoCreditCheck(Classification classification, Customer customer);
    }
}

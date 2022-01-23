using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blazor_Server_assembly.Interface
{
    interface ICustomerService
    {
        string uid { get; set; }
        Customer GetCustomerById(int id);
    }
}

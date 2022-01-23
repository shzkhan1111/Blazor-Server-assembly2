using Blazor_Server_assembly.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Blazor_Server_assembly
{

    //reguster  
    public class CustomerService : ICustomerService
    {
        private List<Customer> customers;
        public string uid { get; set; }
        public CustomerService()
        {
            uid = Guid.NewGuid().ToString(); 
            customers = new List<Customer>()
            {
                new Customer{id = 1 , name = "Tom"},
                new Customer{id = 1 , name = "Jhon"},
                new Customer{id = 1 , name = "Jane"},
                new Customer{id = 1 , name = "Alex"}
            };
        }
        public Customer GetCustomerById(int id)
        {
            return customers.FirstOrDefault(x => x.id == id);
        }   
    }
}

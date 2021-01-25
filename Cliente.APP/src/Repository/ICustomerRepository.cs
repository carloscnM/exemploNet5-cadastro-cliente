using System.Collections.Generic;
using Cliente.APP.Entities;

namespace Cliente.APP.Repositories
{
    public interface ICustomerRepository
    {
        IList<Customer> Get();
        Customer Get(string id);
        Customer GetByCpf(string cpf);
        Customer Store(Customer customer);
        void Update(string id, Customer customerIn);
        void Remove(Customer customerIn);
        void Remove(string id);  
    }
}
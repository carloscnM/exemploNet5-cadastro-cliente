using System.Collections.Generic;
using CustomerApp.Entities;

namespace CustomerApp.Repositories
{
    public interface ICustomerRepository
    {
        IList<Customer> Get();
        Customer Get(string id);
        Customer GetByCpf(string cpf);
        Customer Store(Customer customer);
        void Update(Customer customer);
        void Remove(Customer customer);
        void Remove(string id);  
    }
}
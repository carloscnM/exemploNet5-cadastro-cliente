using System.Collections.Generic;
using CustomerApp.Entities;
using CustomerApp.Repositories;

namespace CustomerApp.BLL
{
    public class BoCustomer 
    {
        public IDictionary<string, string> error; 
        private readonly ICustomerRepository _customerRepository;
        public BoCustomer()
        {
            _customerRepository = new CustomerRepository();
            error = new Dictionary<string, string>();
        }
        
        public Customer New(Customer customer)
        {
            Check(customer);

            if(ExistCustomer(customer.CPF)){
                error.Add(nameof(customer.CPF), "Já existe um cadastro para esse CPF!");
            }

            if(error.Count == 0)
                return _customerRepository.Store(customer);

            return null;
        }

        public void Update(Customer customer)
        {
            Check(customer);

            if(!ExistCustomer(customer.CPF)){
                error.Add(nameof(customer.CPF), "O cadastro não foi encontrado!");
            }

            if(error.Count == 0)
                _customerRepository.Update(customer);
        }

        public IList<Customer> All()
        {
            return _customerRepository.Get();
        }

        public Customer GetByCPF(string cpf) 
        {   
            if(string.IsNullOrEmpty(cpf)){
                return null;
            }

            return _customerRepository.GetByCpf(Utils.CPF.OnlyNumber(cpf));
        }

        public void RemoveCustomer(string cpf)
        {
            _customerRepository.Remove(Utils.CPF.OnlyNumber(cpf));
        }

        public bool ExistCustomer(string cpf) =>
            _customerRepository.GetByCpf(Utils.CPF.OnlyNumber(cpf)) == null ? false : true;
        

        private void Check(Customer customer) 
        {
            if(!Utils.CPF.IsValid(customer.CPF))
            {
                error.Add(nameof(customer.CPF), $"CPF informado para o cliente {customer.Name} não é valido!");
                return;
            }
        }
    }
}

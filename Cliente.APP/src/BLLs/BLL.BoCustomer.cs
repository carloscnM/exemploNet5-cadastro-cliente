
using System.Collections.Generic;
using Cliente.APP.Entities;
using Cliente.APP.Repositories;

namespace Cliente.APP.BLL
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
        
        public void New(Customer customer)
        {
            BoRestrictiveList boRestrictiveList = new BoRestrictiveList();

            if(boRestrictiveList.HasRestriction(customer.CPF))
            {
                error.Add("Restrict", "Cadastro não poderá ser completado, tente novamente mais tarde!");
                return;
            }

            if(ExistCustomer(customer.CPF)){
                error.Add(nameof(customer.CPF), "Já existe um cadastro para esse CPF");
            }

            if(error.Count == 0)
                _customerRepository.Store(customer);
        }

        public IList<Customer> All()
        {
            return _customerRepository.Get();
        }

        public bool ExistCustomer(string cpf) =>
            _customerRepository.GetByCpf(cpf) == null ? false : true;
        

        public static bool CpfIsValid(string cpf){
            return true;
        }
    }
}

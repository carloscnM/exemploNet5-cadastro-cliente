using System.Collections.Generic;
using CustomerApp.Entities;
using CustomerApp.Repositories.Settings;
using MongoDB.Driver;

namespace CustomerApp.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private const string COLLENTION_NAME = "Customers";
        private readonly IMongoCollection<Customer> _customer;
        public CustomerRepository()
        {
            var client = new MongoClient(MongoSettings.ConnectionString);
            var database = client.GetDatabase(MongoSettings.DatabaseName);

            _customer = database.GetCollection<Customer>(COLLENTION_NAME);
        }

        public IList<Customer> Get() =>
            _customer.Find(Customer => true).ToList();

        public Customer Get(string id) =>
            _customer.Find<Customer>(customer => customer.Id == id).FirstOrDefault();

        public Customer Store(Customer customer)
        {
            _customer.InsertOne(customer);
            return customer;
        }

        public void Update(Customer customerIn) =>
            _customer.ReplaceOne(customer => customer.Id == customerIn.Id, customerIn);

        public void Remove(Customer customer) =>
            _customer.DeleteOne(customer => customer.Id == customer.Id);

        public void Remove(string cpf) => 
            _customer.DeleteOne(customer => customer.CPF == cpf);

        public Customer GetByCpf(string cpf) =>
            _customer.Find<Customer>(customer => customer.CPF == cpf).FirstOrDefault();
    }
}
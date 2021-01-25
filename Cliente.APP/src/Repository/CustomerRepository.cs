using System.Collections.Generic;
using Cliente.APP.Entities;
using Cliente.APP.Repositories.Settings;
using MongoDB.Driver;

namespace Cliente.APP.Repositories
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

        public void Update(string id, Customer customerIn) =>
            _customer.ReplaceOne(customer => customer.Id == id, customerIn);

        public void Remove(Customer customerIn) =>
            _customer.DeleteOne(customer => customer.Id == customerIn.Id);

        public void Remove(string id) => 
            _customer.DeleteOne(customer => customer.Id == id);

        public Customer GetByCpf(string cpf) =>
            _customer.Find<Customer>(customer => customer.CPF == cpf).FirstOrDefault();
    }
}
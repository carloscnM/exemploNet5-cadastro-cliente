using CustomerApp.BLL;
using CustomerApp.Entities;
using CustomerApp.Repositories.Settings;
using CustomerApp.Test;
using CustomerApp.Test.Util;
using Xunit;

namespace CustomerApp.Test.BLLs.Test
{
    
    public class BoCustomerTest 
    {
        public BoCustomerTest()
        {
            MongoSettings.ConnectionString = Config.ConnectionString;
            MongoSettings.DatabaseName = Config.DatabaseName;
            DropDataBase.Drop();
        }

        [Fact]
        public void ShouldReturnSuccessWithValidClient()
        {
                //Gerado via 4Devs
                Customer customer = new Customer() {
                    Name = "Leonardo Diogo Martin Araújo",
                    CPF = "877.464.800-47",
                    Phone = "(82) 99133-1195",
                    Email = "leonardodiogomartinaraujo_@gdsambiental.com.br"
                };

                BoCustomer bo = new BoCustomer();

                bo.New(customer);

                Assert.Equal(0, bo.error.Count);
        }

        [Fact]
        public void ShouldReturnErroWithInvalidCpfCustomer()
        {
                Customer customer = new Customer() {
                    Name = "Emilly Isabelle Sara Pereira",
                    CPF = "312.313.112-31",
                    Phone = "(69) 98762-9131",
                    Email = "emillyisabellesarapereira__emillyisabellesarapereira@tuenkers.com.br"
                };

                BoCustomer bo = new BoCustomer();

                bo.New(customer);

                Assert.NotEqual(0, bo.error.Count);
                Assert.True(bo.error.ContainsKey(nameof(customer.CPF)));
        }

        [Fact]
        public void ShouldReturnExactlyCustomerUpdate()
        {
            Customer customer = new Customer() {
                    Name = "Laís Fernanda Jennifer Aparício",
                    CPF = "051.006.141-96",
                    Phone = "(93) 99516-1821",
                    Email = "laisfernandajenniferaparicio__laisfernandajenniferaparicio@kof.com.mx"
            };

        
            BoCustomer bo = new BoCustomer();

            string Id = bo.New(customer).Id;
            
            Customer customer2 = new Customer() {
                    Id = Id,
                    Name = "Laís Fernanda Aparício",
                    CPF = "051.006.141-96",
                    Phone = "(92) 99771-7816",
                    Email = "lfjenniferA@kof.com.mx"
            };


            bo = new BoCustomer();

            bo.Update(customer2);

            Customer CustomerUpdateFind = bo.GetByCPF(customer2.CPF);

            Assert.Equal(customer2.Name, CustomerUpdateFind.Name);
            Assert.Equal(customer2.Phone, CustomerUpdateFind.Phone);
            Assert.Equal(customer2.Email, CustomerUpdateFind.Email);
        }

    }
}

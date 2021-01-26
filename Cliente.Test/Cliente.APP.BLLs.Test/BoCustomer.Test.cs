using Cliente.APP.BLL;
using Cliente.APP.Entities;
using Cliente.APP.Repositories.Settings;
using Cliente.Test.Util;
using Xunit;

namespace Cliente.Test
{
    public class BoCustomerTest
    {
        public BoCustomerTest()
        {
            MongoSettings.ConnectionString = Config.ConnectionString;
            MongoSettings.DatabaseName = Config.DatabaseName;
        }

        [Fact]
        public void ShouldReturnErrorWhenCPFIsInvalid()
        {
            string InvalidCpf = "111.111.111-11";

            Assert.False(BoCustomer.CpfIsValid(InvalidCpf));
        }

        [Fact]
        public void ShouldReturn0ErrorsWithValidClient()
        {
                Customer customer = new Customer() {
                    Name = "Pablim Santos",
                    CPF = "192.581.080-19",
                    Phone = "23348535430",
                    Email = "annetta_fay99@hotmail.com"
                };

                BoCustomer bo = new BoCustomer();

                bo.New(customer);

                Assert.Equal(bo.error.Count, 0);

                DropDataBase.Drop();
        }
    }
}

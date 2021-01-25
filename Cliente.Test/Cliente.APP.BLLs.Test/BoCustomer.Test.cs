using Cliente.APP.BLL;
using Xunit;

namespace Cliente.Test
{
    public class BoCustomerTest
    {
        [Fact]
        public void ShouldReturnErrorWhenCPFIsInvalid()
        {
            string InvalidCpf = "111.111.111-11";

            Assert.False(BoCustomer.CpfIsValid(InvalidCpf));
        }
    }
}

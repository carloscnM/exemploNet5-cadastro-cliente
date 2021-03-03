using CustomerApp.Utils;
using Xunit;

namespace CustomerApp.Test.Utils.Test
{
    public class CPFTest
    {
        [Theory]
        [InlineData("111.111.111-11")]
        [InlineData("222.222.222-22")]
        [InlineData("12524154545")]
        public void ShouldReturnFalseWhenCPFIsInvalid(string value)
        {
            Assert.False(CPF.IsValid(value)); 
        }

        [Theory]
        [InlineData("024.757.930-07")]
        [InlineData("526.096.160-90")]
        [InlineData("15598988011")]
        [InlineData("294.076.920-60")]
        public void ShouldReturnTrueWhenCPFIsValid(string value)
        {
            Assert.True(CPF.IsValid(value)); 
        }

        [Theory]
        [InlineData("02475793007", "024.757.930-07")]
        [InlineData("52609616090", "526.096.160-90")]
        [InlineData("15598988011", "155.989.880-11")]
        [InlineData("29407692060", "294.076.920-60")]
        public void ShouldReturnCPFFormated(string value, string result)
        {
            Assert.Equal(CPF.Formated(value), result);
        }

        [Theory]
        [InlineData("024.757.930-07", "02475793007")]
        [InlineData("526.096.160-90", "52609616090")]
        [InlineData("155.989.880-11", "15598988011")]
        [InlineData("294.076.920-60", "29407692060")]
        public void ShouldReturnCPFOnlyNumber(string value, string result)
        {
            Assert.Equal(CPF.OnlyNumber(value), result);
        }
    }
}
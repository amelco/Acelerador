using Acelerador.Helpers;

namespace Acelerador.Test.Helpers
{
    public class AuxiliadoresTest
    {
        [Theory]
        [InlineData("email@teste.com")]
        [InlineData("email@teste.com.br")]
        public void EmailValido_True(string email)
        {
            var real = Auxiliadores.EmailValido(email);
            Assert.True(real);
        }

        [Theory]
        [InlineData("email")]
        [InlineData("email@")]
        [InlineData("email@teste")]
        [InlineData("email@.com")]
        [InlineData("@.com")]
        [InlineData("@teste")]
        [InlineData("@teste.com")]
        public void EmailValido_False(string email)
        {
            var real = Auxiliadores.EmailValido(email);
            Assert.False(real);
        }

    }
}

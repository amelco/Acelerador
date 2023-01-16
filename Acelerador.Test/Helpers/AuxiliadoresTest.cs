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
            var resultado = Auxiliadores.EmailValido(email);
            Assert.False(resultado);
        }

        [Theory]
        [InlineData("11144477735")]
        [InlineData("34164345012")]
        [InlineData("98580285046")]
        [InlineData("18599068008")]
        [InlineData("32761154096")]
        public void CpfValido_True(string cpf)
        {
            var resultado = Auxiliadores.CpfValido(cpf);
            Assert.True(resultado);
        }

        [Theory]
        [InlineData("11111111122")]
        [InlineData("22222222222")]
        [InlineData("33333333333")]
        public void CpfValido_False(string cpf)
        {
            var resultado = Auxiliadores.CpfValido(cpf);
            Assert.False(resultado);
        }

    }
}

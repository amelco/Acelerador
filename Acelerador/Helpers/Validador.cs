using Acelerador.Entities;

namespace Acelerador.Helpers
{
    public static class Validador
    {
        public static void ValidaEmail<T>(T entidade, string email, string mensagemErro = "Email inválido.")
            where T : EntidadeBase
        {
            if (!Auxiliadores.EmailValido(email))
            {
                entidade.Erros.Add(mensagemErro);
            }
        }
    }
}

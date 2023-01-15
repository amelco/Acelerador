using Acelerador.Entities;

namespace Acelerador.Helpers
{
    public class Validador<T> where T : EntidadeBase
    {
        private T _entidade;
        public Validador(T entidade)
        {
            _entidade = entidade;
        }

        public void ValidaEmail(string email, string mensagemErro = "Email inválido.")
        {
            if (!Auxiliadores.EmailValido(email))
            {
                _entidade.Erros.Add(mensagemErro);
            }
        }
    }
}

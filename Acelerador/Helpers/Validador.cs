using Acelerador.Entities;
using System.Text.RegularExpressions;

namespace Acelerador.Helpers
{
    public static class Validador
    {
        public static void ValidaEmail<T>(T instancia, string email, string mensagemErro = "Email inválido.")
            where T : EntidadeBase
        {
            if (!Auxiliadores.EmailValido(email))
            {
                instancia.Erros.Add(mensagemErro);
            }
        }

        public static void ValidaCpf<T>(T instancia, string cpf, string mensagemErro = "CNPJ inválido")
            where T : EntidadeBase
        {
            if (!Auxiliadores.CpfValido(cpf))
            {
                instancia.Erros.Add(mensagemErro);
            }
        }
    }

    public static class Auxiliadores
    {
        public static bool RegexValido(string atributo, string regex)
        {
            return Regex.IsMatch(atributo, @regex);
        }

        public static bool EmailValido(string email)
        {
            return RegexValido(email, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");
        }

        public static bool CpfValido(string cpf)
        {
            if (RegexValido(cpf, @"^(.)\1{10}$"))   // todos dígitos iguais
                return false;

            int pdv = CalculaDigitoVerificador(cpf, true);
            int sdv = CalculaDigitoVerificador(cpf, false, pdv);
            return (pdv == cpf[9] - '0' && sdv == cpf[10] - '0');
        }

        private static int CalculaDigitoVerificador(string cpf, bool primeiro, int? pdv = null)
        {
            var digitos = cpf.Substring(0, cpf.Length - 2);
            if (primeiro == false)
            {
                if (pdv == null)
                    throw new ArgumentNullException("Primeiro digito verificador deve ser informado.");
                digitos += pdv;
            }

            var tamanho = primeiro == true ? 9 : 10;
            int soma = 0;
            for (int index = 0; index < tamanho; index++)
            {
                int digito = digitos[index] - '0';
                int multiplicador = tamanho + 1 - index;
                soma += digito * multiplicador;
            }

            var resto = soma % 11;
            if (resto < 2)
                return 0;

            return 11 - resto;
        }

    }
}

using System.Net;

namespace Acelerador.Models
{
    public class Resultado<T>
        where T : class
    {
        public bool Sucesso { get; set; } = true;
        public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.OK;
        public HashSet<string>? Erros { get; set; } = null;
        public T? Data { get; set; } = null;

        public Resultado(T data)
        {
            Data = data;
        }

        public Resultado(T data, HttpStatusCode statusCode)
        {
            Data = data;
            StatusCode = statusCode;
        }

        public Resultado(string erro, HttpStatusCode statusCode)
        {
            Erro(statusCode);
            Erros = new HashSet<string> { erro };
        }

        public Resultado(HashSet<string> erros, HttpStatusCode statusCode)
        {
            Erro(statusCode);
            Erros = erros;
        }

        private void Erro(HttpStatusCode code)
        {
            Sucesso = false;
            StatusCode = code;
        }
    }

}

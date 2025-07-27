using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompactadorHuffman.Util
{
    public static class ValidadorParametros
    {
        public static void NuloOuVazio(string valor, string nome)
        {
            if (string.IsNullOrEmpty(valor))
            {
                throw new ArgumentException($"O parâmetro '{nome}' não pode ser nulo ou vazio.", nome);
            }
        }

        public static void Nulo<T>(T obj, string nome) where T : class
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nome);
            }
        }

        public static void Branco(string valor, string nome)
        {
            if (string.IsNullOrWhiteSpace(valor))
            {
                throw new ArgumentException($"O parâmetro '{nome}' não pode estar em branco.", nome);
            }
        }

        public static void ArquivoExiste(string caminho, string nome)
        {
            if (!File.Exists(caminho))
            {
                throw new FileNotFoundException($"O arquivo especificado não foi encontrado.", nome);
            }
        }
    }
}

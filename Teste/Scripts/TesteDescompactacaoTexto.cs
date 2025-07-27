using CompactadorHuffman.IO;
using CompactadorHuffman.Interface;
using CompactadorHuffman.Compactador;
using CompactadorHuffman.Util;
using System.Text;
using System.Text.RegularExpressions;

namespace CompactadorHuffman.Teste
{
    internal class TesteDescompactacaoTexto
    {
        public static void Executar(Dictionary<char, string> dicionarioOriginal)
        {
            string pastaTeste = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Teste"));
            string caminhoArquivoEntrada = Path.Combine(pastaTeste, "Resultados", "smooth_operator_compactado.txt");
            string caminhoArquivoSaida = Path.Combine(pastaTeste, "Resultados", "smooth_operator_descompactado.txt");

            Dicionario dicionarioHelper = new Dicionario();
            Dictionary<string, char> dicionarioInvertido = dicionarioHelper.Inverter(dicionarioOriginal);

            IArquivo<string> arquivo = new ArquivoTexto();
            string conteudo = arquivo.Ler(caminhoArquivoEntrada);
            string codigoCompactado = ExtrairSecao(conteudo, "CODIGO");

            string textoDescompactado = Descompactar(codigoCompactado, dicionarioInvertido);

            arquivo.Gravar(caminhoArquivoSaida, textoDescompactado);
        }

        private static string ExtrairSecao(string conteudo, string nomeSecao)
        {
            string padrao = $@"\<{nomeSecao}\>(.*?)\<\/{nomeSecao}\>";
            Match match = Regex.Match(conteudo, padrao, RegexOptions.Singleline);

            if (!match.Success)
            {
                throw new FormatException($"Seção <{nomeSecao}> não encontrada ou mal formatada.");
            }

            return match.Groups[1].Value.Trim();
        }

        private static string Descompactar(string codigo, Dictionary<string, char> dicionario)
        {
            StringBuilder resultado = new StringBuilder();
            StringBuilder acumulador = new StringBuilder();

            foreach (char bit in codigo)
            {
                acumulador.Append(bit);
                if (dicionario.TryGetValue(acumulador.ToString(), out char caractere))
                {
                    resultado.Append(caractere);
                    acumulador.Clear();
                }
            }

            if (acumulador.Length > 0)
            {
                throw new InvalidOperationException("Código incompleto ou dicionário inconsistente ao final da descompactação.");
            }

            return resultado.ToString();
        }
    }
}
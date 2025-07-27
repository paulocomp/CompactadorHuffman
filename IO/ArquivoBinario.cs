using CompactadorHuffman.Util;
using CompactadorHuffman.Interface;
using System.Text;

namespace CompactadorHuffman.IO
{
    internal class ArquivoBinario : IArquivo<byte[]>
    {
        public byte[] Ler(string caminhoArquivo)
        {
            throw new NotImplementedException("Método desnecessário para os testes deste programa.");
        }

        public void Gravar(string caminhoArquivo, string conteudo)
        {
            ValidadorParametros.NuloOuVazio(caminhoArquivo, nameof(caminhoArquivo));
            ValidadorParametros.NuloOuVazio(conteudo, nameof(conteudo));

            try
            {
                string? diretorio = Path.GetDirectoryName(caminhoArquivo);

                if (!string.IsNullOrEmpty(diretorio) && !Directory.Exists(diretorio))
                {
                    Directory.CreateDirectory(diretorio);
                }

                byte[] bytes = ConverterBitsParaBytes(conteudo);

                File.WriteAllBytes(caminhoArquivo, bytes);
            }
            catch (IOException ex)
            {
                throw new IOException($"Erro ao escrever no arquivo binário: {caminhoArquivo}", ex);
            }
        }

        private byte[] ConverterBitsParaBytes(string bits)
        {
            int tamanhoBytes = (int)Math.Ceiling(bits.Length / 8.0);
            byte[] resultado = new byte[tamanhoBytes];

            for (int i = 0; i < bits.Length; i++)
            {
                int byteIndex = i / 8;
                int bitIndex = 7 - (i % 8);

                if (bits[i] == '1')
                {
                    resultado[byteIndex] |= (byte)(1 << bitIndex);
                }
            }

            return resultado;
        }
    }
}
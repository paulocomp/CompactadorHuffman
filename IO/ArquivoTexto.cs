using CompactadorHuffman.Interface;
using CompactadorHuffman.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CompactadorHuffman.IO
{
    internal class ArquivoTexto : IArquivo<string>
    {
        public string Ler(string caminhoArquivo)
        {
            ValidadorParametros.NuloOuVazio(caminhoArquivo, nameof(caminhoArquivo));
            ValidadorParametros.ArquivoExiste(caminhoArquivo, nameof(caminhoArquivo));

            try
            {
                return File.ReadAllText(caminhoArquivo);
            }
            catch (IOException ex)
            {
                throw new IOException($"Erro ao ler o arquivo: {caminhoArquivo}", ex);
            }
        }

        public void Gravar(string caminhoArquivo, string conteudo)
        {
            GravarInterno(caminhoArquivo, conteudo, escritor =>
            {
                escritor.WriteLine(conteudo);
            });
        }

        public void GravarComDicionario(string caminhoArquivo, string conteudo, Dictionary<char, string> dicionarioHuffman)
        {
            GravarInterno(caminhoArquivo, conteudo, escritor =>
            {
                escritor.WriteLine("Armazenamento em texto apenas para testes e fins didáticos\n");

                if (dicionarioHuffman is { Count: > 0 })
                {
                    escritor.WriteLine("<DICIONARIO>");
                    foreach (var par in dicionarioHuffman)
                    {
                        string chaveFormatada = FormatarCaractere(par.Key);
                        escritor.WriteLine($"{chaveFormatada}: {par.Value}");
                    }
                    escritor.WriteLine("</DICIONARIO>\n");
                }

                escritor.WriteLine("<CODIGO>");
                escritor.WriteLine(conteudo);
                escritor.WriteLine("</CODIGO>");
            });
        }

        private void GravarInterno(string caminhoArquivo, string conteudo, Action<StreamWriter> acaoEscrita)
        {
            ValidadorParametros.NuloOuVazio(caminhoArquivo, nameof(caminhoArquivo));
            ValidadorParametros.Nulo(conteudo, nameof(conteudo));

            try
            {
                using StreamWriter escritor = new StreamWriter(caminhoArquivo, false, Encoding.UTF8);
                acaoEscrita(escritor);
            }
            catch (IOException ex)
            {
                throw new IOException($"Erro ao escrever no arquivo: {caminhoArquivo}", ex);
            }
        }

        private string FormatarCaractere(char caractere)
        {
            return caractere switch
            {
                ' ' => "[ESPAÇO]",
                '\n' => @"\n",
                '\r' => @"\r",
                '\t' => @"\t",
                '\0' => @"\0",
                _ when char.IsControl(caractere) => $"\\u{(int)caractere:x4}",
                _ => caractere.ToString()
            };
        }
    }
}
using CompactadorHuffman.Compactador;
using CompactadorHuffman.Interface;
using CompactadorHuffman.IO;
using CompactadorHuffman.Modelo;
using CompactadorHuffman.Teste;
using CompactadorHuffman.Teste.Scripts;
using CompactadorHuffman.Util;
using System;

namespace CompactadorHuffman
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                TesteCompactacaoBinario.Executar();
                Dictionary<char, string> dicionarioOriginal = TesteCompactacaoTexto.Executar();
                TesteDescompactacaoTexto.Executar(dicionarioOriginal);
            }
            catch
            {
                throw new Exception("Erro ao executar os testes de compactação e descompactação.");
            }
        }
    }
}
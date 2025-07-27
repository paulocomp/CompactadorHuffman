using CompactadorHuffman.Compactador;
using CompactadorHuffman.Interface;
using CompactadorHuffman.IO;
using CompactadorHuffman.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompactadorHuffman.Teste.Scripts
{
    internal class TesteCompactacaoBinario
    {
        public static void Executar()
        {
            string pastaTeste = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Teste"));
            string caminhoArquivoEntrada = Path.Combine(pastaTeste, "Entradas", "lorem_ipsum.txt");
            string caminhoArquivoSaida = Path.Combine(pastaTeste, "Resultados", "lorem_ipsum_compactado.bin");

            IArquivo<string> arquivoEntrada = new ArquivoTexto();
            string conteudo = arquivoEntrada.Ler(caminhoArquivoEntrada);

            ListaFrequencia geradorFrequencias = new ListaFrequencia();
            PriorityQueue<NodoHuffman, int> filaFrequencias = geradorFrequencias.Gerar(conteudo);

            GeradorArvore geradorArvore = new GeradorArvore();
            NodoHuffman raiz = geradorArvore.Gerar(filaFrequencias);
            IArvore arvoreHuffman = new Arvore(raiz);

            Dicionario geradorDicionario = new Dicionario();
            Dictionary<char, string> dicionarioHuffman = geradorDicionario.Gerar(arvoreHuffman);

            Codificador codificador = new Codificador();
            string conteudoCompactado = codificador.Compactar(conteudo, dicionarioHuffman);

            IArquivo<byte[]> arquivoSaida = new ArquivoBinario();
            arquivoSaida.Gravar(caminhoArquivoSaida, conteudoCompactado);
        }
    }
}
# Compactador Huffman com Princípios SOLID

O programa a seguir implementa o algoritmo de compressão de Huffman como parte da aplicação de conceitos aprendidos nas disciplinas de **Estruturas de Dados I e II** do curso de **Ciência da Computação da UERJ (Universidade Estadual do Rio de Janeiro)**.  
O objetivo é **didático**, visando praticar conceitos de desenvolvimento orientado a objetos com ênfase na aplicação dos **princípios SOLID**.

---

## Princípios SOLID

Os princípios SOLID são um conjunto de boas práticas de design orientado a objetos que facilitam a manutenção, escalabilidade e reutilização de código:

- **S – Single Responsibility Principle (Princípio da Responsabilidade Única)**  
  Cada classe deve ter **apenas um motivo para mudar**, ou seja, deve ter apenas uma responsabilidade.

- **O – Open/Closed Principle (Princípio Aberto/Fechado)**  
  O código deve estar **aberto para extensão**, mas **fechado para modificação**, permitindo novas funcionalidades sem alterar código existente.

- **L – Liskov Substitution Principle (Princípio da Substituição de Liskov)**  
  Objetos de uma classe derivada devem poder ser usados no lugar de objetos da classe base **sem quebrar o comportamento esperado**.

- **I – Interface Segregation Principle (Princípio da Segregação de Interfaces)**  
  Muitas interfaces específicas são melhores do que uma interface geral. Os clientes **não devem ser forçados a depender de métodos que não usam**.

- **D – Dependency Inversion Principle (Princípio da Inversão de Dependência)**  
  Dependa de **abstrações e não de implementações**. Os módulos de alto nível não devem depender de módulos de baixo nível diretamente.

---

## Algoritmo de Compactação de Huffman

O **algoritmo de Huffman** é um método eficiente de compactação de dados baseado na frequência dos caracteres de entrada. Os passos principais são:

1. **Contar a frequência** de cada caractere no texto original.
2. **Construir uma árvore binária** (Árvore de Huffman) onde os caracteres mais frequentes ficam mais próximos da raiz.
3. **Atribuir códigos binários** a cada caractere com base no caminho até a folha correspondente (0 para esquerda, 1 para direita).
4. **Codificar o texto** substituindo cada caractere por seu código binário.
5. **Armazenar o dicionário de codificação junto ao arquivo compactado**, permitindo a posterior descompactação.

Esse processo reduz o tamanho do arquivo original, especialmente quando há muitos caracteres repetidos.
Trata-se de um algoritmo simples, porém muito eficiente para compactação de dados textuais.

---

## Como executar o código

Para executar este programa na sua máquina, siga os passos abaixo:

1. **Pré-requisitos**:
	- Instale o [.NET SDK](https://dotnet.microsoft.com/en-us/download) (versão 6.0 ou superior)
	- Um editor de código como [Visual Studio](https://visualstudio.microsoft.com/pt-br/) ou [Visual Studio Code](https://code.visualstudio.com/)

2. **Clone o repositório**:
	```bash
	git clone https://github.com/paulocomp/CompactadorHuffman.git
	cd CompactadorHuffman
	```
3. **Compile e execute o programa**:
	Se estiver usando o terminal, execute:
	```bash
	dotnet build
	dotnet run
	```
	Se estiver usando o Visual Studio:
	- Abra a solução `CompactadorHuffman.sln`
	- Pressione `Ctrl + F5` para compilar e executar.

4. **Verifique os arquivos de saída**
	Os arquivos de entrada e saída estão localizados na pasta `Teste/Entradas` e `Teste/Resultados` respectivamente:
	- `smooth_operator.txt`: arquivo de texto para compactaçao e descompactação.
	- `smooth_operator_compactado.txt`: conteúdo compactado em formato texto.
	- `smooth_operator_descompactado.txt`: reconstrução do texto original a partir do arquivo binário.
 	- `lorem_ipsum.txt`: conteúdo para ser compactado em binário. 
	- `lorem_ipsum_compactado.bin`: conteúdo compactado em binário.

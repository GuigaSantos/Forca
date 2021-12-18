using System;

namespace forca
{
    public struct Config
    {
        public int erros;
        public int tentativas;
        public String tentativas2;
        public String palavra;
        public String dica;
        public char[] acertos;
        public String[,] palavras;

        public Config(int erros, int tentativas, string palavra, string dica, string tentativas2, char[] acertos, string[,] palavras)
        {
            this.erros = erros;
            this.tentativas = tentativas;
            this.tentativas2 = tentativas2;
            this.palavra = palavra;
            this.dica = dica;
            this.palavras = palavras;
            this.acertos = acertos;
        }
    }
    public class forcaCs
    {
        public static void Main()
        {
        inicio:
            Console.Clear();
            Console.Title = "Forca C#";

            Config config;
            config.erros = 0;
            config.tentativas = 0;
            config.palavra = "";
            config.dica = "";
            config.tentativas2 = "";

            config.palavras = new String[,]{
                {"brasil", "País"},
                {"banana", "Fruta"},
                {"macaco", "Animal"},
                {"alemanha", "País"},
                {"abacate", "Fruta"},
                {"aranha", "Animal"},
                {"perna", "Parte do corpo"},
                {"braco", "Parte do corpo"},
                {"lilas", "Cor"},
                {"urubu", "Animal"}};

            Random numRandom = new Random();
            int NumRandom = numRandom.Next(0, config.palavras.Length / 2);
            config.palavra = config.palavras[NumRandom, 0].ToLower();
            config.dica = config.palavras[NumRandom, 1];
            config.acertos = new char[config.palavra.Length];
            int indice = 0;
            foreach (char i in config.palavra)
            {
                config.acertos[indice] = '-';
                indice++;
            }

            String[] forca = new String[7] {
  @"
  +---+
  |   |
      |
      |
      |
      |
=========",

    @"
  +---+
  |   |
  O   |
      |
      |
      |
=========",
    @"
  +---+
  |   |
  O   |
  |   |
      |
      |
=========",
    @"
  +---+
  |   |
  O   |
 /|   |
      |
      |
=========",
    @"
  +---+
  |   |
  O   |
 /|\  |
      |
      |
=========",
    @"
  +---+
  |   |
  O   |
 /|\  |
 /    |
      |
=========",
    @"
  +---+
  |   |
  O   |
 /|\  |
 / \  |
      |
========="}; // nada, cabeça, tronco, braços esq, braço dir, perna esq, perna dir

            Console.WriteLine("Olá {0}, bem vindo ao jogo da forca", Environment.UserName);
            Console.WriteLine("\nPressione Qualquer tecla para prosseguir. . .");
            Console.ReadKey();
            while (config.erros != forca.Length && String.Join("", config.acertos) != config.palavra)
            {
                Console.Clear();
                Console.WriteLine(forca[config.erros]);
                Console.WriteLine("\nDigite apenas 1 letra ou a palavra inteira e sem acentos\nA palavra tem {0} letras", config.palavra.Length);
                Console.WriteLine("Letras/Palavras tentadas: {0}", config.tentativas2);
                Console.WriteLine("Tentativas: {1}\nPalavra: {0}", String.Join("", config.acertos), config.tentativas);
                if (config.erros > 3) Console.WriteLine("Dica: {0}", config.dica);
                Console.Write("Digite: ");
                String Tentativa = Console.ReadLine().ToLower();
                config.tentativas++;


                if (config.tentativas2 == "")
                {
                    config.tentativas2 += Tentativa;
                }
                else
                {
                    config.tentativas2 += ", " + Tentativa;
                }


                if (Tentativa.Length != 1 && Tentativa != config.palavra || Tentativa != config.palavra && !config.palavra.Contains(Tentativa))
                {
                    config.erros++;
                }
                else if (Tentativa.Length == 1 && config.palavra.Contains(Tentativa))
                {
                    indice = 0;
                    foreach (char i in config.palavra.ToCharArray(0, config.palavra.Length))
                    {
                        if (i == Convert.ToChar(Tentativa))
                        {
                            config.acertos[indice] = i;
                        }
                        indice++;
                    }
                }
                else if (Tentativa == config.palavra)
                {
                    config.acertos = config.palavra.ToCharArray(0, config.palavra.Length);
                }
            }
            Console.Clear();
            Console.WriteLine(config.erros == forca.Length ? forca[6] : forca[config.erros]);
            Console.WriteLine("Tentativas: {1}\nPalavra: {0}", config.palavra, config.tentativas);
            Console.WriteLine(config.erros == forca.Length ? "Você foi enforcado x_x, boa sorte da proxima vez" : "Parabéns, você conseguiu se livrar do enforcamento :)");
            Console.Write("Deseja jogar dnv? [S] sim | [N] não\nDigite: ");
            String opt = Console.ReadLine();
            if (opt.ToLower() == "s") goto inicio;
        }
    }
}
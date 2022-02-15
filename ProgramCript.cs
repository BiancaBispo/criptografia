using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] criptografia;
            string TextoClaro, aux;
            int p = 7, q = 11, n, m, Z, e, cont;
            double Cri, Des, d;
            int Sem0, Sem01; // Entradas para saber se os blocos começarem com 0. 

            Console.WriteLine("Informe a mensagem");
            TextoClaro = Console.ReadLine();

            aux = TextoClaro;
            criptografia = new char[aux.Length];

            for (cont = 0; cont < aux.Length; cont++)
            {
                criptografia[cont] = aux[cont];
            }


            //Para descobrir a chave pública é preciso multiplicar o ‘p’ e ‘q’, escolhendo números primos. 
            n = p * q;

            //Inteiro positivo, função Totiente, Phi de 'n'. 
            m = (p - 1) * (q - 1);

            // Encontrar um número que seja relativamente primo(inteiro), e menor que 'm'. (Chave pública). 
            e = 3;

            /* Para achar a chave privada (d). Na qual O 'd' vai ser a chave privada, 
             * e o 'Z' vai ser um auxiliar para o cálculo. */
            Z = (m - 1) / e;
            d = m - Z;


            for (cont = 0; cont < aux.Length; cont++)
            {
                //Criptografia do texto, início usando o teorema de Euler.
                Cri = Math.Pow(criptografia[cont], e) % n;

                // Os blocos não devem começar com o número zero.                    
                if (Cri == 0)
                {
                    Sem0 = 0 + 100;
                    Sem01 = Sem0 + 255;  // O 255 é um valor dado no exemplo. Usando o ASCII.
                }

                // Pre-codificação, saber se deu certo. Ao tira-lo ficara a mensagem criptografada.
                // Cri = criptografia[cont];


                Console.Write(" Mensagem cifrada:  " + Cri);


                // Para descriptografar.
                Des = Math.Pow(Cri, d) % n;

                Console.Write("  \n Mensagem decodificada:  " + Des);
            }


            Console.WriteLine("\n\n Texto claro: {0}", TextoClaro);


            Console.ReadKey();
        }
    }
}

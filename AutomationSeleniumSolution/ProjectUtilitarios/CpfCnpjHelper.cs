using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationSeleniumSolution.ProjectUtilitarios
{
    public class CpfCnpjHelper
    {
        public String GerarCpf()
        {
            int soma = 0, resto = 0;
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            Random rnd = new Random();
            string semente = rnd.Next(100000000, 999999999).ToString();

            for (int i = 0; i < 9; i++)
                soma += int.Parse(semente[i].ToString()) * multiplicador1[i];

            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            semente = semente + resto;
            soma = 0;

            for (int i = 0; i < 10; i++)
                soma += int.Parse(semente[i].ToString()) * multiplicador2[i];

            resto = soma % 11;

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            semente = semente + resto;
            return semente;
        }

        public String GerarCpfComMascara()
        {
            String cpfComMascara =  GerarCpf();
            return Convert.ToUInt64(cpfComMascara).ToString(@"000\.000\.000\-00");
        }


        public String GerarCNPJComMascara()
        {
            int digito1 = 0, digito2 = 0, resto = 0;
            String nDigResult;
            String numerosContatenados;
            String numeroGerado;
            Random numeroAleatorio = new Random();
            //numeros gerados
            int n1 = numeroAleatorio.Next(10);
            int n2 = numeroAleatorio.Next(10);
            int n3 = numeroAleatorio.Next(10);
            int n4 = numeroAleatorio.Next(10);
            int n5 = numeroAleatorio.Next(10);
            int n6 = numeroAleatorio.Next(10);
            int n7 = numeroAleatorio.Next(10);
            int n8 = numeroAleatorio.Next(10);
            int n9 = numeroAleatorio.Next(10);
            int n10 = numeroAleatorio.Next(10);
            int n11 = numeroAleatorio.Next(10);
            int n12 = numeroAleatorio.Next(10);
            int soma = n12 * 2 + n11 * 3 + n10 * 4 + n9 * 5 + n8 * 6 + n7 * 7 + n6 * 8 + n5 * 9 + n4 * 2 + n3 * 3 + n2 * 4 + n1 * 5;
            int valor = (soma / 11) * 11;
            digito1 = soma - valor;
            //Primeiro resto da divisão por 11.
            resto = (digito1 % 11);
            if (digito1 < 2)
            {
                digito1 = 0;
            }
            else
            {
                digito1 = 11 - resto;
            }
            int soma2 = digito1 * 2 + n12 * 3 + n11 * 4 + n10 * 5 + n9 * 6 + n8 * 7 + n7 * 8 + n6 * 9 + n5 * 2 + n4 * 3 + n3 * 4 + n2 * 5 + n1 * 6;
            int valor2 = (soma2 / 11) * 11;
            digito2 = soma2 - valor2;
            //Primeiro resto da divisão por 11.
            resto = (digito2 % 11);
            if (digito2 < 2)
            {
                digito2 = 0;
            }
            else
            {
                digito2 = 11 - resto;
            }
            //Conctenando os numeros
            numerosContatenados = String.Concat(n1) + String.Concat(n2) + "." + String.Concat(n3) + String.Concat(n4) +
                                  String.Concat(n5) + "." + String.Concat(n6) + String.Concat(n7) + String.Concat(n8) + "/" +
                                  String.Concat(n9) + String.Concat(n10) + String.Concat(n11) +
                                  String.Concat(n12) + "-";
            //Concatenando o primeiro resto com o segundo.
            nDigResult = String.Concat(digito1) + String.Concat(digito2);
            numeroGerado = numerosContatenados + nDigResult;
            //System.out.println("Digito 2 ->" + digito2);
            //System.out.println("CNPJ Gerado " + numeroGerado);
            return numeroGerado;
        }

        public String GerarCNPJ()
        {
            String CNPJ = GerarCNPJComMascara();
            String CNPJSemMascara = CNPJ.Replace(".", "").Replace("/", "").Replace("-", "");
            return CNPJSemMascara;
        }
       
        
    }
}

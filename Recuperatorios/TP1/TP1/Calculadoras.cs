using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Calculadora
    {
        /// <summary>
        /// Valida los operadores
        /// </summary>
        /// <param name="operador">Operador a ser validado</param>
        /// <returns>El operador validado, sino devuelve la suma</returns>
        private static string ValidarOperador(char operador)
        {
            if (operador == '+' || operador == '-' || operador == '*' || operador == '/')
            {
                return operador.ToString();
            }
            else
            {
                return '+'.ToString();
            }
        }
        /// <summary>
        /// Realiza las operaciones necesarias
        /// </summary>
        /// <param name="num1">Primer operando</param>
        /// <param name="num2">Segundo operando</param>
        /// <param name="operador">Operador</param>
        /// <returns>El resultado de la operacion</returns>
        public static double Operar(Numero num1, Numero num2, string operador)
        {
            operador = ValidarOperador(operador[0]);
            double rta = 0;

            switch (operador)
            {
                case "+":
                    rta = num1 + num2;
                    break;
                case "-":
                    rta = num1 - num2;
                    break;
                case "*":
                    rta = num1 * num2;
                    break;
                case "/":
                    rta = num1 / num2;
                    break;
                default:
                    Console.WriteLine("No se puede realizar la opracion");
                    break;
            }
            return rta;
        }
    }
}

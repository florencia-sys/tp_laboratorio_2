using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        private double numero;

        #region Constructores

        /// <summary>
        /// Constructor por defecto, inicializa numero en 0
        /// </summary>
        public Numero()
        {
            this.numero = 0;
        }

        /// <summary>
        /// Constructor sobrecargado, asigna un double al atributo numero
        /// </summary>
        /// <param name="numero">Double que se le asignara al atributo</param>
        public Numero(double numero)
        {
            this.numero = numero;
        }

        /// <summary>
        /// Constructor sobrecargado, asigna un string al atributo numero
        /// </summary>
        /// <param name="strNumero">String que se le asignara al atributo</param>
        public Numero(string strNumero)
        {
            this.SetNumero = strNumero;
        }
        #endregion

        #region Propiedades

        /// <summary>
        /// Asigna un valor al atributo numero, previa validacion
        /// </summary>
        public string SetNumero
        {
            set
            {
                this.numero = ValidarNumero(value);
            }
        }
        #endregion

        #region Validaciones

        /// <summary>
        /// Valida que solo se ingresen numeros
        /// </summary>
        /// <param name="strNumero">Numero a ser validado</param>
        /// <returns>Valor validado, en el caso de no poder hacerlo retorna 0</returns>
        /// 
        private double ValidarNumero(string strNumero)
        {
            bool esNumero;
            int salida;
            esNumero = int.TryParse(strNumero, out salida);

            if (esNumero == true)
            {
                return (double)salida;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// Valida que solo se ingresen 1 y 0
        /// </summary>
        /// <param name="binario">Numero a ser validado</param>
        /// <returns>True si el numero se compone solo de 0 y 1, sino false</returns>
        private bool EsBinario(string binario)
        {
            bool rta = true;

            for (int i = 0; i < binario.Length; i++)
            {
                if (binario[i] != '0' && binario[i] != '1')
                {
                    rta = false;
                    break;
                }
            }

            return rta;
        }
        #endregion

        #region Metodos

        /// <summary>
        /// Convierte un binario a decimal
        /// </summary>
        /// <param name="binario">String a ser convertido a decimal</param>
        /// <returns>El string en decimal</returns>
        public string BinarioDecimal(string binario)
        {
            string rta = "Valor inválido";
            double suma = 0;
            double contador = binario.Length - 1;
            if (EsBinario(binario) == true)
            {
                for (int i = 0; i < binario.Length; i++)
                {
                    if (binario[i] == '1')
                    {
                        double potencia = Math.Pow(2, contador);
                        suma += potencia;
                        rta = suma.ToString();
                    }
                    contador--;
                }
            }
            return rta;
        }

        /// <summary>
        /// Convierte un numero decimal a binario
        /// </summary>
        /// <param name="numero">Double a ser convertido</param>
        /// <returns>El double en binario</returns>
        public string DecimalBinario(double numero)
        {
            string binario = "";

            if (numero > 0)
            {
                while (numero >= 1)
                {
                    if (numero % 2 == 0)
                        binario = "0" + binario;

                    else
                        binario = "1" + binario;

                    numero = (int)numero / 2;
                }
            }
            else
            {
                Console.WriteLine("Valor inválido");
            }

            return binario;
        }

        /// <summary>
        /// Convierte un numero decimal a binario
        /// </summary>
        /// <param name="numero">String a ser convertido</param>
        /// <returns>El string en binario</returns>
        public string DecimalBinario(string numero)
        {
            string rta = "Valor inválido";
            double n = Convert.ToDouble(numero);
            if (n > 0)
            {
                rta = DecimalBinario(n);
            }
            return rta;
        }

        #endregion

        #region Sobrecarga de operadores

        /// <summary>
        /// Sobrecarga del operador +
        /// </summary>
        /// <param name="n1">Primer operando</param>
        /// <param name="n2">Segundo operando</param>
        /// <returns>Resultado de la suma</returns>
        public static double operator +(Numero n1, Numero n2)
        {
            return n1.numero + n2.numero;
        }

        /// <summary>
        /// Sobrecarga del operador -
        /// </summary>
        /// <param name="n1">Primer operando</param>
        /// <param name="n2">Segundo operando</param>
        /// <returns>Resultado de la resta</returns>
        public static double operator -(Numero n1, Numero n2)
        {
            return n1.numero - n2.numero;
        }

        /// <summary>
        /// Sobrecarga del operador *
        /// </summary>
        /// <param name="n1">Primer operando</param>
        /// <param name="n2">Segundo operando</param>
        /// <returns>Resultado de la multiplicacion</returns>
        public static double operator *(Numero n1, Numero n2)
        {
            return n1.numero * n2.numero;
        }

        /// <summary>
        /// Sobrecarga del operador /
        /// </summary>
        /// <param name="n1">Primer operando</param>
        /// <param name="n2">Segundo operando</param>
        /// <returns>Resultado de la division</returns>
        public static double operator /(Numero n1, Numero n2)
        {
            double div = n1.numero / n2.numero;

            if (n2.numero == 0)
            {
                div = double.MinValue;
            }
            return div;
        }
        #endregion
    }
}

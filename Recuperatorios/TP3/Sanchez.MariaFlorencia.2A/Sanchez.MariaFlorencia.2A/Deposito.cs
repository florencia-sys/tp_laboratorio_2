using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Entidades
{
    [Serializable]
    public class Deposito<T> where T : Golosina
    {
        private List<T> lista;
        private int capacidad;

        /// <summary>
        /// Propiedad de lectura y escritura, devuelve la lista
        /// </summary>
        public List<T> Lista
        {
            get { return this.lista; }
            set { this.lista = value; }
        }

        /// <summary>
        /// Propiedad de lectura y escritura, devuelve la capacidad del deposito
        /// </summary>
        public int Capacidad
        {
            get { return this.capacidad; }
            set { this.capacidad = value; }
        }

        /// <summary>
        /// Constructor por defecto, inicializa la lista
        /// </summary>
        public Deposito()
        {
            this.lista = new List<T>();
        }

        /// <summary>
        /// Sobrecarga del constructor, que agrega la capacidad del deposito
        /// </summary>
        /// <param name="capacidad"></param>
        public Deposito(int capacidad) : this()
        { 
            this.capacidad = capacidad;
        }

        /// <summary>
        /// Sobrecarga del ==
        /// </summary>
        /// <param name="t"></param>
        /// <param name="l"></param>
        /// <returns></returns>
        public static bool operator ==(Deposito<T> t, T g)
        {
            bool rta = false;
            try
            {
                foreach (T item in t.lista)
                {
                    if (item.Equals(g))
                    {
                        rta = true;
                    }
                }
            }
            catch (StackOverflowException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return rta;
        }
        /// <summary>
        /// Sobrecarga del !=, niega al ==
        /// </summary>
        /// <param name="t"></param>
        /// <param name="l"></param>
        /// <returns></returns>
        public static bool operator !=(Deposito<T> t, T g)
        {
            return !(t == g);
        }

        /// <summary>
        /// Agraga un producto al deposito siempre y cuando este no se encuentre lleno
        /// </summary>
        /// <param name="d"></param>
        /// <param name="g"></param>
        /// <returns></returns>
        public static Deposito<T> operator +(Deposito<T> d, T g)
        {
            if(d.capacidad > d.lista.Count)
            {
                d.lista.Add(g);
            }
            else
            {
                throw new DepositoLlenoException();
            }
            return d;
        }

        /// <summary>
        /// Elimina un producto del deposito siempre y cuando el producto se encuentre en el
        /// </summary>
        /// <param name="d"></param>
        /// <param name="g"></param>
        /// <returns></returns>
        public static Deposito<T> operator -(Deposito<T> d, T g)
        {
            if (d == g)
            {
                d.lista.Remove(g);
            }
            else
            {
                Console.WriteLine("El producto no se encuentra en el deposito");
            }
            return d;
        }

        /// <summary>
        /// Conversion explicita a int, devuelve la capacidad restante
        /// </summary>
        /// <param name="t"></param>
        public static explicit operator int(Deposito<T> t)
        {
            int espacioLibre = 0;
            try
            {
                espacioLibre = t.capacidad - t.lista.Count;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return espacioLibre;
        }

        /// <summary>
        /// Devuelve la cantidad total de productos en deposito
        /// </summary>
        /// <returns></returns>
        public int TotalProductosFabricados()
        {
            int TotalProductosFabricados = 0;

            foreach (T item in this.lista)
            {
                TotalProductosFabricados += item.Cantidad;
            }
            return TotalProductosFabricados;
        }

        /// <summary>
        /// Devuelve un string con los datos del deposito y de los productos
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Capacidad del deposito: " + this.capacidad);
            sb.AppendLine("Cantidad de productos actual: " + this.lista.Count + " cajas");
            sb.AppendLine();

            foreach(T item in this.lista)
            {
                sb.AppendLine(item.ToString());
            }

            sb.AppendLine("-----------------------------------------");

            return sb.ToString();
        }
    }
}

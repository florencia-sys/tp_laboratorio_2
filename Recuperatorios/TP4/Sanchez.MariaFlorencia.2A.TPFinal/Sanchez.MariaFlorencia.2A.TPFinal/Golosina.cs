using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Golosina
    {
        private string nombre;
        private string sabor;
        private int cantidad;
        private double peso;

        public string Nombre
        {
            get { return this.nombre; }
            set { this.nombre = value; }
        }

        public string Sabor
        {
            get { return this.sabor; }
            set { this.sabor = value; }
        }

        public int Cantidad
        {
            get { return this.cantidad; }
            set { this.cantidad = value; }
        }

        public double Peso
        {
            get { return this.peso; }
            set { this.peso = value; }
        }

        public Golosina()
        {

        }

        public Golosina(string sabor, int cantidad, double peso) :this()
        {
            this.sabor = sabor;
            this.cantidad = cantidad;
            this.peso = peso;
        }

        public Golosina(string nombre, string sabor, int cantidad, double peso) :this(sabor, cantidad, peso)
        {
            this.nombre = nombre;
            this.sabor = sabor;
            this.cantidad = cantidad;
            this.peso = peso;
        }

        private string MostrarGolosina()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" Sabor: " + this.sabor);
            sb.AppendLine(" Cantidad de la caja: " + this.cantidad);
            sb.AppendLine(" Peso total caja: " + this.peso + "gr");

            return sb.ToString();
        }

        public override string ToString()
        {
            return MostrarGolosina();
        }

    }
}

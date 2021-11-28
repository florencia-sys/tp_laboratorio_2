using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Chocolates : Golosina
    {
        private EFormato formato;

        public EFormato Formato
        {
            get { return this.formato; }
            set { this.formato = value; }
        }

        public Chocolates()
            : base(string.Empty, 0, 0)
        {

        }

        public Chocolates(string sabor, int cantidad, double peso, EFormato formato)
           : base(sabor, cantidad, peso)
        {
            this.formato = formato;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Producto: {0}\n", this.GetType().Name);
            sb.AppendLine(" Formato: " + this.formato);
            sb.AppendLine(base.ToString());

            return sb.ToString();
        }
    }
}

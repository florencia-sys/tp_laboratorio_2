using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Entidades
{
    public class Caramelos : Golosina, ISerializacion, IDeserializacion
    {
        private ETipo tipo;

        public ETipo Tipo
        {
            get { return this.tipo; }
            set { this.tipo = value; }
        }

        /// <summary>
        /// Propiedad que devuelve la ruta donde se escribira o leera el archivo xml
        /// </summary>
        public string Path
        {
            get { return Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Deposito.Xml"; }
        }

        public Caramelos()
            : base(string.Empty, 0, 0)
        {

        }

        public Caramelos(string sabor, int cantidad, double peso, ETipo tipo)
            : base(sabor, cantidad, peso)
        {
            this.tipo = tipo;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Producto: {0}\n", this.GetType().Name);
            sb.AppendLine(" Tipo de caramelos: " + this.tipo);
            sb.AppendLine(base.ToString());

            return sb.ToString();
        }


        public bool Xml()
        {
            bool rta = true;
            try
            {
                using (XmlTextWriter w = new XmlTextWriter(this.Path, Encoding.UTF8))
                {
                    XmlSerializer ser = new XmlSerializer(typeof(Caramelos));

                    ser.Serialize(w, this);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                rta = false;
            }
            return rta;
        }

        bool IDeserializacion.Xml()
        {
            bool rta = true;

            Caramelos caramelo = new Caramelos();
            try
            {
                using (XmlTextReader r = new XmlTextReader(this.Path))
                {
                    XmlSerializer ser = new XmlSerializer(typeof(Caramelos));

                    caramelo = (Caramelos)ser.Deserialize(r);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                rta = false;
            }
            return rta;
        }
    }
}

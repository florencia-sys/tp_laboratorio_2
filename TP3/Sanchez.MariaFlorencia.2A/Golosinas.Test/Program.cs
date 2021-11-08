using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Golosinas.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Deposito<Chocolates> depo1 = new Deposito<Chocolates>(300);
            Chocolates choco = new Chocolates("Chocolate negro", 100, 10.6, EFormato.Tableta);
            Chocolates bombon = new Chocolates("Chocolate blanco", 100, 10.6, EFormato.Bombones);

            Deposito<Caramelos> depo2 = new Deposito<Caramelos>(300);
            Caramelos caramelo1 = new Caramelos("Limon", 150, 3.7, ETipo.Masticables);
            Caramelos caramelo2 = new Caramelos("Menta", 150, 3.7, ETipo.NoMasticables);

            depo1 += choco;
            depo1 += bombon;

            depo2 += caramelo1;
            depo2 += caramelo2;

            Console.WriteLine(depo1.ToString());
            Console.WriteLine(depo2.ToString());

            if(depo1.Xml())
            {
                Console.WriteLine("Se serializo el archivo correctamente");
            }
            else
            {
                Console.WriteLine("No se pudo serializar el archivo");
            }

            if (((IDeserializacion)depo1).Xml())
            {
                Console.WriteLine("Se deserializo el archivo correctamente");
            }
            else
            {
                Console.WriteLine("No se pudo deserializar el archivo");
            }

            Console.ReadKey();
        }
    }
}

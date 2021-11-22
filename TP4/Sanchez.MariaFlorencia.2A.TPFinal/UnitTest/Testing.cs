using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Entidades;

namespace UnitTest
{
    [TestClass]
    public class Testing
    {
        [TestMethod]
        public void VerificarIgualdadCaramelosNull_Ok()
        {
            //Arrange
            Chocolates dic1 = null;
            Chocolates dic2 = null;

            //Act
            bool rta = dic1 == dic2;

            //Assert
            Assert.IsTrue(rta);
        }

        [TestMethod]
        public void VerificarIgualdadNullCaramelos_False()
        {
            //Arrange
            Caramelos c1 = null;
            Caramelos c2 = new Caramelos("Limon", 300, 12.8, ETipo.NoMasticables);

            //Act
            bool rta = c1 == c2;

            //Assert
            Assert.IsFalse(rta);
        }

        [TestMethod]
        public void VerificarIgualdadCaramelos_False()
        {
            //Arrange
            Caramelos c1 = new Caramelos("Menta", 300, 12.8, ETipo.NoMasticables);
            Caramelos c2 = new Caramelos("Tutti-Fruti", 300, 12.8, ETipo.NoMasticables);

            //Act
            bool rta = c1 == c2;

            //Assert
            Assert.IsFalse(rta);
        }

        [TestMethod]
        public void DepositoIsNotNull()
        {
            //Arrange
            Deposito<Golosina> dep = new Deposito<Golosina>(10);

            //Act
            Caramelos c1 = new Caramelos("Menta", 300, 12.8, ETipo.NoMasticables);
            dep.Lista.Add(c1);

            //Assert
            Assert.IsNotNull(dep);
        }

        [TestMethod]
        public void AgregarGolosina_Ok()
        {
            //Arrange
            Deposito<Golosina> dep = new Deposito<Golosina>(10);
            Caramelos c1 = new Caramelos("Menta", 300, 12.8, ETipo.NoMasticables);
            Chocolates choco1 = new Chocolates("Chocolate blanco", 350, 120.8, EFormato.Tableta);
            int espacioLibre = 0;
            int espacioLibreEsperado = 8;

            //Act
            dep += c1;
            dep += choco1;

            espacioLibre = (int)dep;

            //Assert
            Assert.AreEqual(espacioLibre, espacioLibreEsperado);
        }

        [TestMethod]
        public void AgregarLibro_Falla()
        {
            //Arrange
            Deposito<Golosina> dep = new Deposito<Golosina>(10);
            Caramelos c1 = new Caramelos("Menta", 300, 12.8, ETipo.NoMasticables);
            Chocolates choco1 = new Chocolates("Chocolate blanco", 350, 120.8, EFormato.Tableta);

            //Act
            try
            {
                dep += c1;
                dep += choco1;
            }

            catch (Exception ex)
            {
                //Assert
                Assert.IsInstanceOfType(ex, typeof(ArgumentOutOfRangeException));
            }
        }
    }
}

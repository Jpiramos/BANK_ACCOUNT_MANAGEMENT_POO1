using ControleContas.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestControleContas
{
    [TestClass]
    public class ContaEspecialTests
    {
        [TestMethod]
        public void TransferenciaEntreContasEspeciais()
        {
            //cenario
            var cliente = CriarCliente();
            decimal saldoInicial = 1500;

            decimal valorTransferencia = 1500;
            var contaSaque = new ContaEspecial("2000", saldoInicial, cliente);
            var contaDestino = new ContaEspecial("2001", saldoInicial, cliente);

            //acao
            contaSaque.Transferir(contaDestino, valorTransferencia);

        }

        [TestMethod]
        public void ContaEspecial_DefinirLimite_LimiteDefinido()
        {
            // Arrange
            Cliente cliente = CriarCliente();
            ContaEspecial contaEspecial = new ContaEspecial("12345", cliente);

            // Act
            contaEspecial.DefinirLimite(2000);

            // Assert
            Assert.AreEqual(2000, contaEspecial.Limite);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ContaEspecial_DefinirLimite_Negativo_Falha()
        {
            // Arrange
            Cliente cliente = new Cliente("Julio", "12345678910", 2000);
            ContaEspecial contaEspecial = new ContaEspecial("12345", cliente);

            // Act
            contaEspecial.DefinirLimite(-500);


        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ContaEspecial_Sacar_LimiteExcedido_Falha()
        {
            // Arrange
            Cliente cliente = CriarCliente();
            ContaEspecial contaEspecial = new ContaEspecial("12345", cliente);

            // Act
            contaEspecial.Sacar(11000);
        }

        [TestMethod]
        public void ContaEspecial_EhInstanciaDeConta_Sucesso()
        {
            // Arrange
            Cliente cliente = CriarCliente();
            ContaEspecial contaEspecial = new ContaEspecial("12345", cliente);

            // Act
            bool ehInstanciaDeConta = contaEspecial is Conta;

            // Assert
            Assert.IsTrue(ehInstanciaDeConta);
        }
        private Cliente CriarCliente()
        {
            return new Cliente("Fulano", "12345678901", 2000);
        }
    }
}

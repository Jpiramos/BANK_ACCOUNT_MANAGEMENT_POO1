using ControleContas.Model;

namespace TestControleContas
{
    [TestClass]
    public class ControleContasTests
    {
        [TestMethod]
        public void SaqueComSaldoSuficiente()
        {
            //cenario
            decimal saldoInicial = 1000;
            decimal valorSaque = 500;
            decimal novoSaldo = 499.9m;
            Cliente cliente = new Cliente("Fulano", "12345678901", 2000);
            Conta conta = new Conta("10000", saldoInicial, cliente);

            //acao
            conta.Sacar(valorSaque);

            //verificacao
            decimal saldoAtual = conta.Saldo;
            Assert.AreEqual(novoSaldo, saldoAtual, 0.001m, "O saque nao foi debitado corretamente");
        }

        [TestMethod]
        public void SaqueComValorMaiorQueSaldo()
        {
            //cenario
            decimal saldoInicial = 1000;
            decimal valorSaque = 1500;
            Cliente cliente = new Cliente("Fulano", "12345678901", 2000);
            Conta conta = new Conta("10000", saldoInicial, cliente);

            //acao 
            try
            {
                conta.Sacar(valorSaque);
            }
            catch(ArgumentOutOfRangeException e)
            {
                //verificacao
                StringAssert.Contains(e.Message, Conta.SaqueMaiorQueSaldoMessage);
                return;
            }
            Assert.Fail("A excecao experada nao foi lancada");
        }

        [TestMethod]
        public void DepositoValorPositivo()
        {
            //cenario
            decimal saldoInicial = 1000;
            decimal valorDeposito = 1000;
            decimal novoSaldo = 2000;
            Cliente cliente = new Cliente("Fulano", "12345678901", 2000);
            Conta conta = new Conta("1000", saldoInicial, cliente);

            //acao
            conta.Depositar(valorDeposito);

            //verificacao
            Assert.AreEqual(novoSaldo, conta.Saldo, 0.001m, "Depósito não foi realizado corretamente");
        }
    }
}
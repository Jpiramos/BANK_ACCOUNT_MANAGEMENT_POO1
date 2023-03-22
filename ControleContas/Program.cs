
using ControleContas.Model;

Conta conta = new Conta("1234");
Conta conta2 = new Conta("4321", 1000.99m);
Console.WriteLine($"Conta: {conta.Numero}; Saldo: {conta.Saldo}");
Conta conta3 = new Conta("654321", 2341.42m);

Console.WriteLine($"O saldo total é {conta2.SaldoTotal}");
Console.WriteLine($"A conta de maior saldo é {conta2.ContaMaiorSaldo}");

Cliente cliente1 = new Cliente("Fred", "12345678901", 2000);

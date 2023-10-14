using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleContas.Model
{
    public class Conta
    {
        public const string SaqueMenorQueZeroMessage = "Valor informado para saque nao pode ser negativo";
        public const string SaqueMaiorQueSaldoMessage = "Valor informado para saque ultrapassa o saldo disponivel";
        private string _numero;
        private decimal _saldo;
        private static decimal _saldoTotal;
        private static string _contaMaiorSaldo = "";
        private static decimal _maiorSaldo = 0;
        public Cliente Titular { get; set; }

        //Polimorfismo de sobrecarga
        public Conta(string numero, Cliente titular)
        {
            _numero = numero;
            Titular = titular;
        }

        public Conta(string numero, decimal saldo, Cliente titular) 
        {
            _saldo = saldo;
            _numero = numero;
            _saldoTotal += saldo;
            Titular = titular;
            if (_saldo > _maiorSaldo)
            {
                _maiorSaldo = _saldo;
                _contaMaiorSaldo = _numero;
            }
        }

        public string Numero {
            get => _numero; 
            private set => _numero = value; 
        }
        public decimal Saldo { 
            get => _saldo; 
            private set => _saldo = value; 
        }
        public decimal SaldoTotal { 
            get => _saldoTotal; 
            private set => _saldoTotal = value; 
        }

        public string ContaMaiorSaldo
        {
            get => _contaMaiorSaldo;
        }

        public bool Sacar(decimal valor)
        {
            
            if(_saldo + 0.10m < valor)
            {
                throw new ArgumentOutOfRangeException("Valor do Saque", valor, SaqueMaiorQueSaldoMessage);
            }
            if(valor < 0)
            {
                throw new ArgumentOutOfRangeException("Valor do Saque", valor, SaqueMenorQueZeroMessage);
            }
            _saldo -= valor + 0.10m;
            return true;
        }

        public bool Depositar(decimal valor)
        {
            if(valor < 0)
            {
                throw new ArgumentOutOfRangeException("Deposito Invalido", valor.ToString(), "Valor para depósito não pode ser negativo");
            }
            _saldo += valor;
            return true;
        }

        public bool Transferir(Conta destino, decimal valor)
        {
            if (destino.Sacar(valor))
            {
                Depositar(valor);
                return true;
            }
               
            return false;
        }

    }
}

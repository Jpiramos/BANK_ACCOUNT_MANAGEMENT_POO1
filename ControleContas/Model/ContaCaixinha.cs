using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleContas.Model
{
    public class ContaCaixinha : Conta
    {


        public ContaCaixinha(string numero, Cliente titular) : base(numero, titular)
        {
        }

        public ContaCaixinha(string numero, decimal saldo, Cliente titular) : base(numero, saldo, titular)
        {
        }

        public decimal taxaIncremento = 1;

        public decimal taxaDecremento = 0.5m;

        public override bool Sacar(decimal valor)
        {

            if (valor > _saldo)
            {

                throw new InvalidOperationException("Valor do Saque é maior que o Saldo Disponivel");

            }
            _saldo -= valor + taxaDecremento;

            return true;






        }




        public override bool Depositar(decimal valor)
        {
            if (valor < 1)
            {
                throw new ArgumentException("Valor do depósito deve ser maior que 1");
            }
            _saldo += valor + taxaIncremento;

            return true;




        }






    }
}

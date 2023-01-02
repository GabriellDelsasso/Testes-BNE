using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteDeMesaPOO2
{
    public class CalculoRendimento
    {
        private int Mes, MesCont;
        private float TaxaJuros, PeriodoDias;
        private double ValorPresente, ValorFuturo, RendaLiquida, RendaAcumulada;
        private double[] Saldo = new double[10];
        private double[] Resgate = new double[10];

        public void ReceberValores()
        {
            this.MesCont = 1;
            try
            {
                Console.Write("Informe o Valor Presente (Investimento): R$ ");
                this.Investimento = float.Parse(Console.ReadLine());
                Console.Write("Ïnforme a Taxa de Juros (%): ");
                this.Juros = float.Parse(Console.ReadLine());
                Console.Write("Informe um valor a ser retirado no 5º mês: ");
                this.Resgate[5] = double.Parse(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void CalcTabela()
        {
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("| Valor Presente | Taxa de Juros | Período a.m. | Rendimento | Renda Líquida | Renda Acumulada |  Resgate  |   Saldo  |");
            Console.WriteLine("|---------------------------------------------------------------------------------------------------------------------|");

            for (PeriodoMes = 1; PeriodoMes <= 8; PeriodoMes++)
            {
                Resultado = Investimento * Math.Pow((1 + (Juros / 100)), PeriodoMes);
                Liquido = Resultado - Investimento;
                Acumulado = Investimento + Liquido - ResgateMes;
                SaldoMes = Resultado - ResgateMes;

                if (PeriodoMes < 3)
                {
                    Console.WriteLine("|   R$ {0}   |      {1}%       |       {2}      |   {3}  |      {4}    |      {5}    |    {6}   |  {7} |", Investimento.ToString("F2"), Juros, PeriodoMes, Resultado.ToString("F2"), Liquido.ToString("F2"), Acumulado.ToString("F2"), ResgateMes.ToString("F2"), SaldoMes.ToString("F2"));
                }
                else if (PeriodoMes == 3)
                {
                    Console.WriteLine("|   R$ {0}   |      {1}%       |       {2}      |   {3}  |      {4}    |      {5}    |    {6}   |  {7} |", Investimento.ToString("F2"), Juros, PeriodoMes, Resultado.ToString("F2"), Liquido.ToString("F2"), Acumulado.ToString("F2"), ResgateMes.ToString("F2"), SaldoMes.ToString("F2"));
                }
                else if (PeriodoMes == 5)
                {
                    if (ResgateMes < SaldoMes)
                    {
                        Console.WriteLine("|   R$ {0}   |      {1}%       |       {2}      |   {3}  |     {4}    |       {5}    |  {6}   |   {7} |", Investimento.ToString("F2"),  Juros, PeriodoMes, Resultado.ToString("F2"), Liquido.ToString("F2"), Acumulado.ToString("F2"), ResgateMes.ToString("F2"), SaldoMes.ToString("F2"));
                        Investimento = SaldoMes;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Não a valor suficiente para retirada!!");
                        goto fim;
                    }
                }
                else if (PeriodoMes != 6 && PeriodoMes < 6)
                {
                    Console.WriteLine("|   R$ {0}   |      {1}%       |       {2}      |   {3}  |     {4}    |      {5}    |    {6}   |  {7} |", Investimento.ToString("F2"), Juros, PeriodoMes, Resultado.ToString("F2"), Liquido.ToString("F2"), Acumulado.ToString("F2"), ResgateMes.ToString("F2"), SaldoMes.ToString("F2"));
                }
                else
                {
                    Resultado = Investimento * Math.Pow((1 + (Juros / 100)), PeriodoMesCont);
                    Liquido = Resultado - Investimento;
                    Acumulado = Investimento + Liquido - ResgateMes;
                    SaldoMes = Resultado - ResgateMes;
                    Console.WriteLine("|    R$ {0}   |      {1}%       |       {2}      |    {3}  |      {4}    |       {5}    |    {6}   |   {7} |", Investimento.ToString("F2"), Juros, PeriodoMesCont, Resultado.ToString("F2"), Liquido.ToString("F2"), Acumulado.ToString("F2"), ResgateMes.ToString("F2"), SaldoMes.ToString("F2"));
                    MesCont++;
                }
            }

            Dias = 0.33f;
            Investimento = Saldo[8];
            Resultado = Investimento * Math.Pow((1 + (Juros / 100)), Dias);
            Liquido = Resultado - Investimento;
            Acumulado = Investimento + Liquido - ResgateMes;
            SaldoMes = Resultado - ResgateMes;

            Console.WriteLine("|    R$ {0}   |      {1}%       |     {2}     |    {3}  |       {4}    |       {5}    |    {6}   |   {7} |", Investimento.ToString("F2"), Juros, Dias, Resultado.ToString("F2"), Liquido.ToString("F2"), Acumulado.ToString("F2"), ResgateMes.ToString("F2"), SaldoMes.ToString("F2"));;

            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------");
        fim:
            Console.ReadLine();
        }

        public int PeriodoMes
        {
            get { return Mes; }
            set { Mes = value; }
        }

        public int PeriodoMesCont
        {
            get { return MesCont; }
            set { MesCont = value; }
        }

        public float Juros
        {
            get { return TaxaJuros; }
            set { TaxaJuros = value; }
        }

        public float Dias
        {
            get { return PeriodoDias; }
            set { PeriodoDias = value; }
        }

        public double Investimento
        {
            get { return ValorPresente; }
            set { ValorPresente = value; }
        }

        public double Resultado
        {
            get { return ValorFuturo; }
            set { ValorFuturo = value; }
        }

        public double Liquido
        {
            get { return RendaLiquida; }
            set { RendaLiquida = value; }
        }

        public double Acumulado
        {
            get { return RendaAcumulada; }
            set { RendaAcumulada = value; }
        }

        public double ResgateMes
        {
            get { return Resgate[PeriodoMes]; }
            set { Resgate[PeriodoMes] = value; }
        }

        public double SaldoMes
        {
            get { return Saldo[PeriodoMes]; }
            set { Saldo[PeriodoMes] = value; }
        }
    }

    internal class Program
    {
        static void Main()
        {
            CalculoRendimento calculoJuros = new CalculoRendimento();

            calculoJuros.ReceberValores();
            calculoJuros.CalcTabela();

            Console.ReadLine();
        }
    }
}

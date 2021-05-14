using System;
using Clube_da_leitura.Controladores;
using Clube_da_leitura.Dominio;

namespace Clube_da_leitura.Telas
{
    class TelaEmprestimo : TelaBase
    {
        private readonly ControladorEmprestimo controladorEmprestimo;
        private readonly TelaRevista telaRevista;
        private readonly TelaCrianca telaCrianca;

        public TelaEmprestimo(ControladorEmprestimo controladorEmprestimo, TelaRevista telaRevista, TelaCrianca telaCrianca) : base("Amiguinhos")
        {
            this.controladorEmprestimo = controladorEmprestimo;
            this.telaRevista = telaRevista;
            this.telaCrianca = telaCrianca;
        }

        public string ObterOpcao()
        {
            Console.WriteLine("Digite 1 para Reagistrar um Emprestimo");
            Console.WriteLine("Digite 2 para Reagistrar uma Devolução");
            Console.WriteLine("Digite 3 para Vilzualizar os Emprestimos abertos");
            Console.WriteLine("Digite 4 para Vilzualizar os Emprestimos do Mês");
            Console.WriteLine("Digite S para Sair");

            return Console.ReadLine();
        }

        public void MontarCabecalhoTabela()
        {
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine("{0,-3} | {1,-20} | {2,-20} | {3, -16} | {4, -16}", "Id", "Amiguinho", "Revista",
                "Data Empréstimo", "Data Devolução");

            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");

            Console.ResetColor();
        }
    }
}

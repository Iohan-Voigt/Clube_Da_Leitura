using System;
using Clube_da_leitura.Controladores;
using Clube_da_leitura.Dominio;

namespace Clube_da_leitura.Telas
{
    class TelaPrincipal : TelaBase
    {
        protected readonly ControladorCaixa controladorCaixa;
        protected readonly ControladorCrianca controladorCrianca;
        protected readonly ControladorEmprestimo controladorEmprestimo;
        protected readonly ControladorRevista controladorRevista;

        protected readonly TelaCaixa telaCaixa;
        protected readonly TelaCrianca telaCrianca;
        protected readonly TelaEmprestimo telaEmprestimo;
        protected readonly TelaRevista telaRevista;

        public TelaPrincipal(ControladorCaixa ctrCaixa, ControladorCrianca ctrCrianca, ControladorRevista ctrRevista,
                             ControladorEmprestimo ctrEmprestimo, TelaCaixa tlCaixa, TelaCrianca tlCrianca, TelaRevista tlRevista,
                             TelaEmprestimo tlEmprestimo) : base("Principal") 
        {
            controladorCaixa      = ctrCaixa;
            controladorCrianca    = ctrCrianca;
            controladorRevista    = ctrRevista;
            controladorEmprestimo = ctrEmprestimo;

            telaCaixa      = tlCaixa;
            telaCrianca    = tlCrianca;
            telaRevista    = tlRevista;
            telaEmprestimo = tlEmprestimo;
        }

        public TelaBase ObterOpcao()
        {
            TelaBase telaselecionada = null;
            string opcao;

            do
            {
                Console.Clear();

                Console.WriteLine("Digite 1 para Acessar o menu de Revistas");
                Console.WriteLine("Digite 2 para Acessar o menu de Caixas");
                Console.WriteLine("Digite 3 para Acessar o menu de Amigos");
                Console.WriteLine("Digite 4 para Acessar o menu de Emprestimos");
                Console.WriteLine("Digite S para Sair");

                opcao = Console.ReadLine();

                if (opcao == "1")
                    telaselecionada = telaRevista;
                else if (opcao == "2")
                    telaselecionada = telaCaixa;
                else if (opcao == "3")
                    telaselecionada = telaCrianca;
                else if (opcao == "4")
                    telaselecionada = telaEmprestimo;
                else if (opcao.Equals("s", StringComparison.OrdinalIgnoreCase))
                    telaselecionada = null;

            } while (OpcaoInvalida(opcao));

            return telaselecionada;
        }

        private bool OpcaoInvalida(string opcao)
        {
            if (opcao != "1" && opcao != "2" && opcao != "3" && opcao != "4" && opcao != "s" && opcao != "S")
            {
                Console.WriteLine("Opção inválida");
                Console.ReadLine();
                return true;
            }
            else {
                return false;
            }
        }
    }
}

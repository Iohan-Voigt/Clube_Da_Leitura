using System;
using Clube_da_leitura.Controladores;
using Clube_da_leitura.Dominio;

namespace Clube_da_leitura.Telas
{
    class TelaCrianca : TelaBase , IEditavel
    {
        private ControladorCrianca controladorCrianca;
        public TelaCrianca(ControladorCrianca controladorCrianca) : base("Amiguinhos")
        {
            this.controladorCrianca = controladorCrianca;
        }

        public string ObterOpcao()
        {
            Console.WriteLine("Digite 1 para Registrar um novo amiguinho");
            Console.WriteLine("Digite 2 para Listar os amiguinhos");
            Console.WriteLine("Digite 3 para editar um amiguinho");
            Console.WriteLine("Digite 4 para excluir um amiguinho");
            Console.WriteLine("Digite S para Sair");

            return Console.ReadLine();
        }

        public override void InserirNovoRegistro()
        {
            ConfigurarTela("Inserindo um novo amiguinho...");

            bool conseguiuGravar = GravarCrianca(0);
        }

        public override void VisualizarRegistros()
        {
            ConfigurarTela("Visualizando amiguinhos...");

            string configuracaColunasTabela = "{0,3} | {1,10} | {2,10} | {3,10} | {4,10} ";

            MontarCabecalhoTabela(configuracaColunasTabela);

            Crianca[] criancas = controladorCrianca.SelecionarTodasCriancas();

            if (criancas.Length == 0)
            {
                ApresentarMensagem("Nenhum amiguinho cadastrado!", TipoMensagem.Atencao);
                return;
            }

            for (int i = 0; i < criancas.Length; i++)
            {
                Console.WriteLine(configuracaColunasTabela,
                   criancas[i].id, criancas[i].nome, criancas[i].nomeResponsavel, criancas[i].telefone, criancas[i].endereco);
            }
        }

        public override void EditarRegistro()
        {
            ConfigurarTela("Editando um Amiguinho...");

            VisualizarRegistros();

            Console.WriteLine();

            Console.Write("Digite o id do Amiguinho que deseja editar: ");
            int id = Convert.ToInt32(Console.ReadLine());

            bool conseguiuGravar = GravarCrianca(id);

            if (conseguiuGravar)
                ApresentarMensagem("Amiguinho excluido com sucesso", TipoMensagem.Sucesso);
            else
            {
                ApresentarMensagem("Falha ao tentar editar o Amiguinho", TipoMensagem.Erro);
                Console.ReadLine();
                EditarRegistro();
            }
        }

        public override void ExcluirRegistro()
        {
            ConfigurarTela("Excluindo um Amiguinho...");

            VisualizarRegistros();

            Console.WriteLine();

            Console.Write("Digite o id do Amiguinho que deseja excluir: ");
            int idSelecionado = Convert.ToInt32(Console.ReadLine());

            bool conseguiuExcluir = controladorCrianca.ExcluirCrianca(idSelecionado);

            if (conseguiuExcluir)
                ApresentarMensagem("Amiguinho excluído com sucesso", TipoMensagem.Sucesso);
            else
            {
                ApresentarMensagem("Falha ao tentar excluir o Amiguinho", TipoMensagem.Erro);
                ExcluirRegistro();
            }
        }

        private static void MontarCabecalhoTabela(string configuracaoColunasTabela)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine(configuracaoColunasTabela, "id", "Nome", "Responsável", "Telefone", "Endereço");

            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");

            Console.ResetColor();
        }

        private bool GravarCrianca(int id)
        {
            string resultadoValidacao;
            bool conseguiuGravar = true;

            Console.Write("Digite o nome do Amiguinho: ");
            string nome = Console.ReadLine();

            Console.Write("Digite o nome do Responsável do Amiguinho: ");
            string nomeResponsavel = Console.ReadLine();

            Console.Write("Digite o Telefone do Amiguinho: ");
            string telefone = Console.ReadLine();

            Console.Write("Digite o Endereço do Amiguinho: ");
            string endereco = Console.ReadLine();


            resultadoValidacao = controladorCrianca.RegistrarCrianca(nome, nomeResponsavel,
                telefone, endereco, id);

            if (resultadoValidacao != "CRIANCA_VALIDA")
            {
                ApresentarMensagem(resultadoValidacao, TipoMensagem.Erro);
                conseguiuGravar = true;
            }

            return conseguiuGravar;
        }
    }
}

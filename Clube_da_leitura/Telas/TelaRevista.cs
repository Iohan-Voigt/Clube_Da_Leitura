using System;
using Clube_da_leitura.Controladores;
using Clube_da_leitura.Dominio;

namespace Clube_da_leitura.Telas
{
    class TelaRevista : TelaBase , IEditavel
    {
        private ControladorRevista controladorRevista;
        public TelaRevista(ControladorRevista controladorRevista) : base("Revistas")
        {
           this.controladorRevista = controladorRevista;
        }
        public string ObterOpcao()
        {
            Console.WriteLine("Digite 1 para Registrar nova revista");
            Console.WriteLine("Digite 2 para Listar as revistas");
            Console.WriteLine("Digite 3 para editar uma revistas");
            Console.WriteLine("Digite 4 para excluir uma revistas");
            Console.WriteLine("Digite S para Sair");

            return Console.ReadLine();
        }

        public override void InserirNovoRegistro() 
        {
            ConfigurarTela("Inserindo uma nova revista...");

            bool conseguiuGravar = GravarRevista(0);
        }

        public override void VisualizarRegistros()
        {
            ConfigurarTela("Visualizando revistas...");

            string configuracaColunasTabela = "{0,3} | {1,10} | {2,10} | {3,10} ";

            MontarCabecalhoTabela(configuracaColunasTabela);

            Revista[] revistas = controladorRevista.SelecionarTodasRevistas();

            if (revistas.Length == 0)
            {
                ApresentarMensagem("Nenhuma revista cadastrada!", TipoMensagem.Atencao);
                return;
            }

            for (int i = 0; i < revistas.Length; i++)
            {
                Console.WriteLine(configuracaColunasTabela,
                   revistas[i].id, revistas[i].nome, revistas[i].numeroEdicao, revistas[i].tipoColecao);
            }
        }

        public override void EditarRegistro()
        {
            ConfigurarTela("Editando uma revista...");

            VisualizarRegistros();

            Console.WriteLine();

            Console.Write("Digite o id da Revista que deseja editar: ");
            int id = Convert.ToInt32(Console.ReadLine());

            bool conseguiuGravar = GravarRevista(id);

            if (conseguiuGravar)
                ApresentarMensagem("Rrevista excluida com sucesso", TipoMensagem.Sucesso);
            else
            {        
                ApresentarMensagem("Falha ao tentar editar a revista", TipoMensagem.Erro);
                Console.ReadLine();
                EditarRegistro();
            }
        }

        public override void ExcluirRegistro()
        {
            ConfigurarTela("Excluindo uma revista...");

            VisualizarRegistros();

            Console.WriteLine();

            Console.Write("Digite o número da revista que deseja excluir: ");
            int idSelecionado = Convert.ToInt32(Console.ReadLine());

            bool conseguiuExcluir = controladorRevista.ExcluirRevista(idSelecionado);

            if (conseguiuExcluir)
                ApresentarMensagem("Revista excluído com sucesso", TipoMensagem.Sucesso);
            else
            {
                ApresentarMensagem("Falha ao tentar excluir a revista", TipoMensagem.Erro);
                ExcluirRegistro();
            }
        }

        private static void MontarCabecalhoTabela(string configuracaoColunasTabela)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine(configuracaoColunasTabela,"id", "Nome", "Edição", "Coleção");

            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");

            Console.ResetColor();
        }

        private bool GravarRevista(int id)
        {
            string resultadoValidacao;
            bool conseguiuGravar = true;

            Console.Write("Digite o nome da Revista: ");
            string nome = Console.ReadLine();

            Console.Write("Digite a coleção da Revista: ");
            string tipoColecao = Console.ReadLine();

            Console.Write("Digite o número da edição da Revista: ");
            string numeroEdicao = Console.ReadLine();

            Console.Write("Digite o ano da Revista: ");
            int ano = Convert.ToInt32(Console.ReadLine());


            resultadoValidacao = controladorRevista.RegistrarRevista(nome,tipoColecao,
                ano,numeroEdicao,id);

            if (resultadoValidacao != "REVISTA_VALIDA")
            {
                ApresentarMensagem(resultadoValidacao, TipoMensagem.Erro);
                conseguiuGravar = true;
            }

            return conseguiuGravar;
        }
    }
}

using System;
using Clube_da_leitura.Controladores;
using Clube_da_leitura.Dominio;

namespace Clube_da_leitura.Telas
{
    class TelaCaixa : TelaBase , IEditavel
    {
        private ControladorCaixa controladorCaixa;
        public TelaCaixa(ControladorCaixa controladorCaixa) : base("Caixas")
        {
            this.controladorCaixa = controladorCaixa;
        }

        public string ObterOpcao()
        {
            Console.WriteLine("Digite 1 para Registrar nova caixa");
            Console.WriteLine("Digite 2 para Listar as caixas");
            Console.WriteLine("Digite 3 para editar uma caixa");
            Console.WriteLine("Digite 4 para excluir uma caixa");
            Console.WriteLine("Digite S para Sair");

            return Console.ReadLine();
        }

        public override void InserirNovoRegistro()
        {
            ConfigurarTela("Inserindo uma nova caixa...");

            bool conseguiuGravar = GravarCaixa(0);
        }

        public override void VisualizarRegistros()
        {
            ConfigurarTela("Visualizando caixas...");

            string configuracaColunasTabela = "{0,3} | {1,10} | {2,10} | {3,10} ";

            MontarCabecalhoTabela(configuracaColunasTabela);

            Caixa[] caixas = controladorCaixa.SelecionarTodasCaixas();

            if (caixas.Length == 0)
            {
                ApresentarMensagem("Nenhuma caixa cadastrada!", TipoMensagem.Atencao);
                return;
            }

            for (int i = 0; i < caixas.Length; i++)
            {
                Console.WriteLine(configuracaColunasTabela,
                   caixas[i].id, caixas[i].cor, caixas[i].etiqueta, caixas[i].numero);
            }
        }

        public override void EditarRegistro()
        {
            ConfigurarTela("Editando uma caixa...");

            VisualizarRegistros();

            Console.WriteLine();

            Console.Write("Digite o id da Caixa que deseja editar: ");
            int id = Convert.ToInt32(Console.ReadLine());

            bool conseguiuGravar = GravarCaixa(id);

            if (conseguiuGravar)
                ApresentarMensagem("Caixa excluida com sucesso", TipoMensagem.Sucesso);
            else
            {
                ApresentarMensagem("Falha ao tentar editar a caixa", TipoMensagem.Erro);
                Console.ReadLine();
                EditarRegistro();
            }
        }

        public override void ExcluirRegistro()
        {
            ConfigurarTela("Excluindo uma caixa...");

            VisualizarRegistros();

            Console.WriteLine();

            Console.Write("Digite o id da Caixa que deseja excluir: ");
            int idSelecionado = Convert.ToInt32(Console.ReadLine());

            bool conseguiuExcluir = controladorCaixa.ExcluirCaixa(idSelecionado);

            if (conseguiuExcluir)
                ApresentarMensagem("Revista excluído com sucesso", TipoMensagem.Sucesso);
            else
            {
                ApresentarMensagem("Falha ao tentar excluir a caixa", TipoMensagem.Erro);
                ExcluirRegistro();
            }
        }

        private static void MontarCabecalhoTabela(string configuracaoColunasTabela)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine(configuracaoColunasTabela, "id", "Cor", "Etiqueta", "Número");

            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");

            Console.ResetColor();
        }

        private bool GravarCaixa(int id)
        {
            string resultadoValidacao;
            bool conseguiuGravar = true;

            Console.Write("Digite a cor da Caixa: ");
            string cor = Console.ReadLine();

            Console.Write("Digite a etiqueta da Caixa: ");
            string etiqueta = Console.ReadLine();

            Console.Write("Digite o número da Caixa: ");
            int numero = Convert.ToInt32(Console.ReadLine());


            resultadoValidacao = controladorCaixa.RegistrarCaixa(cor, etiqueta,
                numero,id);

            if (resultadoValidacao != "CAIXA_VALIDA")
            {
                ApresentarMensagem(resultadoValidacao, TipoMensagem.Erro);
                conseguiuGravar = false;
            }

            return conseguiuGravar;
        }
    }
}

using System;
using Clube_da_leitura.Dominio;

namespace Clube_da_leitura.Controladores
{
    class ControladorEmprestimo : ControladorBase
    {
        private readonly ControladorCrianca controladorCrianca;
        private readonly ControladorRevista controladorRevista;

        public ControladorEmprestimo(ControladorCrianca controladorCrianca, ControladorRevista controladorRevista)
        {
            this.controladorCrianca = controladorCrianca;
            this.controladorRevista = controladorRevista;
        }


        public string RegistrarEmprestimo(int id, int idCriancaEmprestimo, int idRevistaEmprestimo,
            DateTime dataEmprestimo, DateTime dataDevolucao)
        {
            Emprestimo emprestimo;
            int posicao;

            if (id == 0)
            {
                posicao = ObterPosicaoVaga();
                emprestimo = new Emprestimo();
            }
            else
            {
                posicao = ObterPosicaoOcupada(new Emprestimo(id));
                emprestimo = (Emprestimo)registros[posicao];
            }

            emprestimo.crianca = controladorCrianca.SelecionarCriancaPorId(idCriancaEmprestimo);
            emprestimo.revista = controladorRevista.SelecionarRevistaPorId(idRevistaEmprestimo);
            emprestimo.dataEmprestimo = dataEmprestimo;
            emprestimo.dataDevolucao = dataDevolucao;

            string resultadoValidacao = emprestimo.Validar();

            if (resultadoValidacao == "EMPRESTIMO_VALIDO")
            {
                registros[posicao] = emprestimo;
            }

            return resultadoValidacao;
        }


        public Emprestimo[] SelecionarTodosEmprestimos()
        {
            object[] arrayAux = SelecionarTodosRegistros();

            Emprestimo[] emprestimos = new Emprestimo[arrayAux.Length];

            Array.Copy(arrayAux, emprestimos, arrayAux.Length);

            return emprestimos;
        }

        public Emprestimo SelecionarEmprestimoPorId(int id)
        {
            return (Emprestimo)SelecionarRegistroPorId(new Emprestimo(id));
        }
    }
}

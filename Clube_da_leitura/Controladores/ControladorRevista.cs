using System;
using Clube_da_leitura.Dominio;

namespace Clube_da_leitura.Controladores
{
    public class ControladorRevista : ControladorBase
    {

        public string RegistrarRevista(string nome, string tipoColecao,
            int ano, string numeroEdicao, int id)
        {
            Revista revista;

            int posicao;

            if (id == 0)
            {
                revista = new Revista();
                posicao = ObterPosicaoVaga();
            }
            else
            {
                posicao = ObterPosicaoOcupada(new Revista(id));
                revista = (Revista)registros[posicao];
            }

            revista.nome = nome;
            revista.tipoColecao = tipoColecao;
            revista.numeroEdicao = numeroEdicao;
            revista.ano = ano;


            string resultadoValidacao = revista.Validar();

            if (resultadoValidacao == "REVISTA_VALIDA")
                registros[posicao] = revista;

            return resultadoValidacao;
        }

        public bool ExcluirRevista(int idSelecionado)
        {
            return ExcluirRegistro(new Revista(idSelecionado));
        }

        public Revista[] SelecionarTodasRevistas()
        {
            Revista[] revistaAux = new Revista[QtdRegistrosCadastrados()];

            Array.Copy(SelecionarTodosRegistros(), revistaAux, revistaAux.Length);

            return revistaAux;
        }

        public Revista SelecionarRevistaPorId(int id)
        {
            return (Revista)SelecionarRegistroPorId(new Revista(id));
        }
    }
}

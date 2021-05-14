using System;
using Clube_da_leitura.Dominio;

namespace Clube_da_leitura.Controladores
{
    class ControladorCrianca : ControladorBase
    {
        public string RegistrarCrianca(string nome, string nomeResponsavel, string telefone,
            string endereco, int id)
        {
            Crianca crianca;

            int posicao;

            if (id == 0)
            {
                crianca = new Crianca();
                posicao = ObterPosicaoVaga();
            }
            else
            {
                posicao = ObterPosicaoOcupada(new Crianca(id));
                crianca = (Crianca)registros[posicao];
            }

            crianca.nome = nome;
            crianca.nomeResponsavel = nomeResponsavel;
            crianca.telefone = telefone;
            crianca.endereco = endereco;


            string resultadoValidacao = crianca.Validar();

            if (resultadoValidacao == "CRIANCA_VALIDA")
                registros[posicao] = crianca;

            return resultadoValidacao;
        }

        public bool ExcluirCrianca(int idSelecionado)
        {
            return ExcluirRegistro(new Crianca(idSelecionado));
        }

        public Crianca[] SelecionarTodasCriancas()
        {
            Crianca[] revistaAux = new Crianca[QtdRegistrosCadastrados()];

            Array.Copy(SelecionarTodosRegistros(), revistaAux, revistaAux.Length);

            return revistaAux;
        }

        public Crianca SelecionarCriancaPorId(int id)
        {
            return (Crianca)SelecionarRegistroPorId(new Crianca(id));
        }
    }
}

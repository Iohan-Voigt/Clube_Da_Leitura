using System;
using Clube_da_leitura.Dominio;

namespace Clube_da_leitura.Dominio
{
    public class Crianca
    {
        public string nome, nomeResponsavel, telefone, endereco;
        public int id;

        public Crianca()
        {
            id = GeradorId.GerarIdCrianca();
        }

        public Crianca(int idSelecionado)
        {
            id = idSelecionado;
        }

        public string Validar()
        {
            string resultadoValidacao = "";

            if (string.IsNullOrEmpty(nome))
                resultadoValidacao += "O campo Nome é obrigatório \n";

            if (string.IsNullOrEmpty(nomeResponsavel))
                resultadoValidacao += "O campo Responsável é obrigatório \n";

            if (string.IsNullOrEmpty(telefone))
                resultadoValidacao += "O campo Telefone é obrigatório \n";

            if (string.IsNullOrEmpty(endereco))
                resultadoValidacao += "O campo Endereço é obrigatório \n";

            if (string.IsNullOrEmpty(resultadoValidacao))
                resultadoValidacao = "CRIANCA_VALIDA";

            return resultadoValidacao;
        }

        public override bool Equals(object obj)
        {
            Crianca crianca = (Crianca)obj;

            if (id == crianca.id)
                return true;
            else
                return false;
        }
    }
}

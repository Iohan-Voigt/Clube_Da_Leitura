namespace Clube_da_leitura.Dominio
{
    public class Revista
    {
        public string nome;
        public string tipoColecao;
        public string numeroEdicao;
        public int ano;
        public int id;
        public Revista()
        {
            id = GeradorId.GerarIdRevista();
        }

        public Revista(int idSelecionado)
        {
            id = idSelecionado;
        }

        public string Validar()
        {
            string resultadoValidacao = "";

            if (string.IsNullOrEmpty(nome))
                resultadoValidacao += "O campo Nome é obrigatório \n";
            
            if (string.IsNullOrEmpty(tipoColecao))
                resultadoValidacao += "O campo Coleção é obrigatório \n";

            if (ano == 0)
                resultadoValidacao += "O campo Ano é obrigatório \n";

            if (string.IsNullOrEmpty(resultadoValidacao))
                resultadoValidacao = "REVISTA_VALIDA";

            return resultadoValidacao;
        }

        public override bool Equals(object obj)
        {
            Revista revista = (Revista)obj;

            if (id == revista.id)
                return true;
            else
                return false;
        }

    }
}

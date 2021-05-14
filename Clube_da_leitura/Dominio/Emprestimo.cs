using System;

namespace Clube_da_leitura.Dominio
{
    public class Emprestimo
    {
        public Revista revista;
        public Crianca crianca;
        public string tipo;
        public DateTime dataEmprestimo, dataDevolucao;
        public int id;

        public Emprestimo()
        {
            id = GeradorId.GerarIdEmprestimo();
        }

        public Emprestimo(int id)
        {
            this.id = id;
        }

        public override bool Equals(object obj)
        {
            Emprestimo emprestimo = (Emprestimo)obj;

            if (emprestimo != null && emprestimo.id == this.id)
                return true;

            return false;
        }

        public string Validar()
        {
            string resultadoValidacao = "";

            if (crianca == null)
                resultadoValidacao += "O id do amiguinho informado está incorreto\n";

            if (revista == null)
                resultadoValidacao += "O id da revista informada está incorreto\n";


            //if (data > DateTime.Now)
            //    resultadoValidacao += "A data de registro não pode ser maior que a data atual\n";

            if (string.IsNullOrEmpty(resultadoValidacao))
                resultadoValidacao = "EMPRESTIMO_VALIDO";

            return resultadoValidacao;
        }

    }


}

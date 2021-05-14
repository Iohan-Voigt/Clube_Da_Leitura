using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clube_da_leitura
{
    class GeradorId
    {
        private static int idCaixa = 0, idCrianca = 0, idEmprestimo = 0, idRevista = 0;

        public static int GerarIdCaixa() { return ++idCaixa; }

        public static int GerarIdCrianca() { return ++idCrianca; }

        public static int GerarIdEmprestimo() { return ++idEmprestimo; }

        public static int GerarIdRevista() { return ++idRevista; }
    }
}

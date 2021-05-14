using System;

namespace Clube_da_leitura.Telas
{
    public class TelaBase 
    {
        private string titulo;

        public string Titulo { get { return titulo; } }

        public TelaBase(string ti) { titulo = ti; }

        public virtual void InserirNovoRegistro() { }

        public virtual void EditarRegistro() { }

        public virtual void ExcluirRegistro() { }

        protected void ApresentarMensagem(string mensagem, TipoMensagem tm)
        {
            switch (tm)
            {
                case TipoMensagem.Sucesso:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;

                case TipoMensagem.Atencao:
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    break;

                case TipoMensagem.Erro:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;

                default:
                    break;
            }
            Console.WriteLine(mensagem);
            Console.ResetColor();
            Console.ReadLine();

        }

        public virtual void VisualizarRegistros() { }

        protected void ConfigurarTela(string subtitulo)
        {
            Console.Clear();

            Console.WriteLine(titulo);

            Console.WriteLine();

            Console.WriteLine(subtitulo);

            Console.WriteLine();
        }


    }
}

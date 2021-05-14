using System;
using Clube_da_leitura.Controladores;
using Clube_da_leitura.Telas;

namespace Clube_da_leitura
{
    class Program
    {

        #region Objetivos
        // Criar as classes...........[OK]
        // Criar as interface.........[OK]
        // Criar as telas.............[]
        // Ajustar os controladores...[]
        // Botar pra funcionar........[]
        #endregion

        static void Main(string[] args)
        {
            ControladorCaixa controladorCaixa           = new ControladorCaixa();
            ControladorCrianca controladorCrianca       = new ControladorCrianca();
            ControladorRevista controladorRevista       = new ControladorRevista();
            ControladorEmprestimo controladorEmprestimo = new ControladorEmprestimo(controladorCrianca, controladorRevista);

            TelaCaixa telaCaixa           = new TelaCaixa(controladorCaixa);
            TelaCrianca telaCrianca       = new TelaCrianca(controladorCrianca);
            TelaRevista telaRevista       = new TelaRevista(controladorRevista);
            TelaEmprestimo telaEmprestimo = new TelaEmprestimo(controladorEmprestimo,telaRevista,telaCrianca);
            TelaPrincipal telaPrincipal   = new TelaPrincipal(controladorCaixa,controladorCrianca,controladorRevista,controladorEmprestimo,
                                                              telaCaixa,telaCrianca,telaRevista,telaEmprestimo);
            TelaBase telaSelecionada;



            while (true)
            {
                telaSelecionada = telaPrincipal.ObterOpcao();
                if (telaSelecionada == null)
                    break;

                if (!(telaSelecionada is IEditavel))
                {

                }
                else
                {

                    IEditavel auxTelaSelecionada = (IEditavel)telaSelecionada; 
                    Console.Clear();

                    string opcaoadastro = auxTelaSelecionada.ObterOpcao();

                    if (opcaoadastro.Equals("s", StringComparison.OrdinalIgnoreCase) || opcaoadastro.Equals("s", StringComparison.OrdinalIgnoreCase))
                        continue;
                    switch (opcaoadastro)
                    {
                        case "1":
                            auxTelaSelecionada.InserirNovoRegistro();
                            break;
                        case "2":
                            auxTelaSelecionada.VisualizarRegistros();
                            break;
                        case "3":
                            auxTelaSelecionada.EditarRegistro();
                            break;
                        case "4":
                            auxTelaSelecionada.ExcluirRegistro();
                            break;
                    }
                }
                //Console.WriteLine(telaSelecionada.Titulo);
                Console.ReadLine();  
            }
        }
    }
}


namespace Clube_da_leitura
{
    public interface IEditavel
    {
        void InserirNovoRegistro();
        void EditarRegistro();
        void ExcluirRegistro();
        void VisualizarRegistros();
        string ObterOpcao();
    }
}

using AlmoxarifadoBackAPI.Models;

namespace AlmoxarifadoBackAPI.Repositorio
{
    public interface IProdutoRepositorio
    {
        void Add(Produto produto);

        List<Produto> GetAll();

        
    }
}

using Entity;
using Entity.Interfaces;

namespace Application
{
    public class CategoriaService
    {
        private readonly IRepositoryElemento<Elemento> _repositoryElemento;

        public CategoriaService(IRepositoryElemento<Elemento> repository)
        {
            _repositoryElemento = repository;
        }

        public async Task<IEnumerable<Elemento>> CargarElementos() => await _repositoryElemento.GetAllAsync();
    }
}

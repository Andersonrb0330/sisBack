using Domain.Entity;
using Domain.IRepositories;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly SisContext _sisContext;

        public CategoriaRepository(
            SisContext sisContext) 
        { 
            _sisContext = sisContext;
        }

        public async Task<List<Categoria>> GetAll()
        {
            List<Categoria> listCategoria = await _sisContext.Categorias.ToListAsync();
            return listCategoria;
        }

        public async Task<Categoria> GetById(int id)
        {
            Categoria categoria = await _sisContext.Categorias.FirstOrDefaultAsync(c => c.Id == id);
            return categoria;
        }

        public async Task Create(Categoria categoria)
        {
            await _sisContext.Categorias.AddAsync(categoria);
        }

        public void Delete(Categoria categoria)
        {
            _sisContext.Categorias.Remove(categoria);
        }

        public async Task<List<Categoria>> GetPaginado(IQueryable<Categoria> queryable, int limite, int excluir)
        {
            return queryable
                   .OrderBy(p => p.Id)
                   .Skip(excluir)
                   .Take(limite)
                   .ToList();
        }

        public async Task<IQueryable<Categoria>> GetQueryable()
        {
            IQueryable<Categoria> categoria = _sisContext.Categorias.AsQueryable();
            return categoria;
        }

        public async Task<bool> verificarCategoria(int id)
        {
            bool verificarCategorias = await _sisContext.Categorias.AnyAsync(c => c.Id == id);
            return verificarCategorias;
        }
    }
}

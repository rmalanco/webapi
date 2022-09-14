using webapi;
using webapi.Models;

namespace webapi.Services;
public class categoriaService
{
    TareasContext _context;

    public categoriaService(TareasContext dbContext)
    {
        _context = dbContext;
    }

    public IEnumerable<Categoria> Get()
    {
        return _context.Categorias;
    }

    public async Task Save(Categoria categoria)
    {
        _context.Categorias.Add(categoria);
        await _context.SaveChangesAsync();
    }
}

public interface IcategoriaService
{

}
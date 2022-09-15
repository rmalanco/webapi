using webapi;
using webapi.Models;

namespace webapi.Services;
public class categoriaService : ICategoriaService
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

    public async Task Update(Guid id, Categoria categoria)
    {
        var categoriaActual = _context.Categorias.Find(id);
        if (categoriaActual != null)
        {
            categoriaActual.Nombre = categoria.Nombre;
            categoriaActual.Descripcion = categoria.Descripcion;
            categoriaActual.Peso = categoria.Peso;

            await _context.SaveChangesAsync();
        }
    }

    public async Task Delete(Guid id)
    {
        var categoriaActual = _context.Categorias.Find(id);

        if (categoriaActual != null)
        {
            _context.Remove(categoriaActual);
            await _context.SaveChangesAsync();
        }
    }
}

public interface ICategoriaService
{
    IEnumerable<Categoria> Get();
    Task Save(Categoria categoria);
    Task Update(Guid id, Categoria categoria);
    Task Delete(Guid id);
}
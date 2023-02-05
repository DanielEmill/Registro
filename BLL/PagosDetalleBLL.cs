using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
public class PagosDetalleBLL
{
    private Contexto _contexto;
    public PagosDetalleBLL(Contexto contexto){
        _contexto = contexto;
    }
    public bool Existe(int id){
        return _contexto.PagosDetalle.Any(o => o.Id == id);
    }
    public bool Inserta(PagosDetalle id){
        _contexto.PagosDetalle.Add(id);
        return _contexto.SaveChanges() > 0;
    }
    public bool Modificar(PagosDetalle id){
        _contexto.Entry(id).State = EntityState.Modified;
        return _contexto.SaveChanges() > 0;
    }
    public bool Guardar(PagosDetalle id){
        if(!Existe(id.Id))
            return this.Inserta(id);
        else
            return this.Modificar(id);
    }
    public bool Eliminar(PagosDetalle pagosDetalle){
        _contexto.Entry(pagosDetalle).State = EntityState.Deleted;
        return _contexto.SaveChanges() > 0;
    }
    public PagosDetalle? Buscar(int id){
        return _contexto.PagosDetalle.Where(o => o.Id == id).AsNoTracking().SingleOrDefault();
    }
    public List<PagosDetalle> GetList(Expression<Func<PagosDetalle, bool>> criterio){
        return _contexto.PagosDetalle.AsNoTracking().Where(criterio).ToList();
    }
}
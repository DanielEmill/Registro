using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
public class PrestamosBLL
{
    private Contexto _contexto;
    public PrestamosBLL(Contexto contexto){
        _contexto = contexto;
    }
    public bool Existe(int prestamoId){
        return _contexto.Prestamos.Any(o => o.PrestamoId == prestamoId);
    }
    public bool Inserta(Prestamos prestamos){
        _contexto.Prestamos.Add(prestamos);
        return _contexto.SaveChanges() > 0;
    }
    public bool Modificar(Prestamos prestamos){
        _contexto.Entry(prestamos).State = EntityState.Modified;
        return _contexto.SaveChanges() > 0;
    }
    public bool Guardar(Prestamos prestamos){
        if(!Existe(prestamos.PrestamoId))
            return this.Inserta(prestamos);
        else
            return this.Modificar(prestamos);
    }
    public bool Eliminar(Prestamos prestamos){
        _contexto.Entry(prestamos).State = EntityState.Deleted;
        return _contexto.SaveChanges() > 0;
    }
    public Prestamos? Buscar(int prestamoId){
        return _contexto.Prestamos.Where(o => o.PrestamoId == prestamoId).AsNoTracking().SingleOrDefault();
    }
    public List<Prestamos> GetList(){
        return _contexto.Prestamos.ToList();
    }
}
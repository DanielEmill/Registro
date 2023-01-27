using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
public class OcupacionesBLL{
    private Contexto _contexto;
    
    public OcupacionesBLL(Contexto contexto){
        _contexto = contexto;
    }
    public bool Existe(int ocupacionId){
        return _contexto.Ocupaciones.Any(o => o.OcupacionID == ocupacionId);
    }
    public bool Inserta(Ocupaciones ocupacion){
        _contexto.Ocupaciones.Add(ocupacion);
        return _contexto.SaveChanges() > 0;
    }
    public bool Modificar(Ocupaciones ocupacion){
        _contexto.Entry(ocupacion).State = EntityState.Modified;
        return _contexto.SaveChanges() > 0;
    }
    public bool Guardar(Ocupaciones ocupacion){
        if(!Existe(ocupacion.OcupacionID))
            return this.Inserta(ocupacion);
        else
            return this.Modificar(ocupacion);
    }
    public bool Eliminar(Ocupaciones ocupacion){
        _contexto.Entry(ocupacion).State = EntityState.Deleted;
        return _contexto.SaveChanges() > 0;
    }
    public Ocupaciones? Buscar(int ocupacionId){
        return _contexto.Ocupaciones.Where(o => o.OcupacionID == ocupacionId).AsNoTracking().SingleOrDefault();
    }
    public List<Ocupaciones> GetList(){
        return _contexto.Ocupaciones.ToList();
    }
    
}
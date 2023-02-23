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
    private bool Modificar(Ocupaciones ocupacion){
        var OcupacionExistente = _contexto.Ocupaciones.Find(ocupacion.OcupacionID);
        if(OcupacionExistente != null){
            _contexto.Entry(OcupacionExistente).CurrentValues.SetValues(ocupacion);
            return _contexto.SaveChanges() > 0;
        }
        return false;
    }
    public bool Guardar(Ocupaciones ocupacion){
        if(!Existe(ocupacion.OcupacionID))
            return this.Inserta(ocupacion);
        else
            return this.Modificar(ocupacion);
    }
    public bool Eliminar(int ocupacion){
        var OcupacionAEliminar = _contexto.Ocupaciones.Where(o=> o.OcupacionID == ocupacion).SingleOrDefault();

        if(OcupacionAEliminar!=null){
            _contexto.Entry(OcupacionAEliminar).State = EntityState.Deleted;
            return _contexto.SaveChanges() > 0;
        }
        return false;
    }
    public Ocupaciones? Buscar(int ocupacionId){
        return _contexto.Ocupaciones.Where(o => o.OcupacionID == ocupacionId).AsNoTracking().SingleOrDefault();
    }
    public List<Ocupaciones> GetList(Expression<Func<Ocupaciones, bool>> criterio){
        return _contexto.Ocupaciones.AsNoTracking().Where(criterio).ToList();
    }
    
}
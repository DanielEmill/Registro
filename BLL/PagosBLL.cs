using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
public class PagosBll
{
    private Contexto _contexto;
    public PagosBll(Contexto contexto){
        _contexto = contexto;
    }
    public bool Existe(int pagoId){
        return _contexto.Pagos.Any(o => o.PagoId == pagoId);
    }
    public bool Inserta(Pagos pagoId){
        _contexto.Pagos.Add(pagoId);
        return _contexto.SaveChanges() > 0;
    }
    public bool Modificar(Pagos pago){
        var PagoEncontrado = _contexto.Pagos.Find(pago.PagoId);
        
        if(PagoEncontrado != null){
            _contexto.Entry(PagoEncontrado).CurrentValues.SetValues(pago);
            return _contexto.SaveChanges() > 0;
        }
        return false;
    }
    public bool Guardar(Pagos pagoId){
        if(!Existe(pagoId.PagoId))
            return this.Inserta(pagoId);
        else
            return this.Modificar(pagoId);
    }
    public bool Eliminar(int pago){
    var pagoAEliminar = _contexto.Pagos.Where(o=> o.PagoId == pago).SingleOrDefault();
        if(pagoAEliminar!=null){
            _contexto.Entry(pagoAEliminar).State = EntityState.Deleted;
            return _contexto.SaveChanges() > 0;
        }
        return false;
    }
    public Pagos? Buscar(int pagoId){
        return _contexto.Pagos.Where(o => o.PagoId == pagoId).AsNoTracking().SingleOrDefault();
    }
    public List<Pagos> GetList(Expression<Func<Pagos, bool>> criterio){
        return _contexto.Pagos.AsNoTracking().Where(criterio).ToList();
    }
}
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

public class PagosBLL{
    private Contexto _Contexto;

    public PagosBLL(Contexto contexto) {
        _Contexto = contexto;
    }

    public bool Existe(int PagosId) {
        return _Contexto.Pagos.Any(o => o.PagoId == PagosId);
    }

    private bool Insertar(Pagos pago) {
        InsertarDetalle(pago);
        _Contexto.Pagos.Add(pago);
        return _Contexto.SaveChanges() > 0;
    }

    private bool Modificar(Pagos Pago) {
        ModificarDetalle(Pago);
        _Contexto.Entry(Pago).State = EntityState.Modified;
        return _Contexto.SaveChanges() > 0;
    }

    public bool Guardar(Pagos Pago) {
    if (!Existe(Pago.PagoId)) {
        return this.Insertar(Pago);
    } else {
        return this.Modificar(Pago);
    }
    }

    public bool Eliminar(Pagos pago) {
        EliminarDetalle(pago);
        _Contexto.Entry(pago).State = EntityState.Deleted;
        return _Contexto.SaveChanges() > 0;
    }

    public Pagos ? Buscar(int PagosId) {
        return _Contexto.Pagos
            .Include(o => o.PagosDetalle)
            .Where(o => o.PagoId == PagosId)
            .AsTracking()
            .SingleOrDefault();
    }

    public List < Pagos > GetList(Expression < Func < Pagos, bool >> criterio) {
        return _Contexto.Pagos.AsNoTracking().Where(criterio).ToList();
    }

    void InsertarDetalle(Pagos pago)
    {
        if (pago.PagosDetalle == null)
        {
            pago.PagosDetalle = new List<PagosDetalle>(); 
        }
        foreach (var item in pago.PagosDetalle)
        {
            var prestamo =  _Contexto.Prestamos.Find(item.PrestamoId);
            if (prestamo != null)
            {
                prestamo.Balance -= item.ValorPagado;
                _Contexto.Entry(prestamo).State = EntityState.Modified;
                _Contexto.SaveChanges();
            }
        }
        var persona =  _Contexto.Personas.Find(pago.PersonaId);
        if(persona!=null){
            persona.Balance -= pago.Monto;
            _Contexto.Entry(persona).State = EntityState.Modified;
            _Contexto.SaveChanges();
        }
    }
    void EliminarDetalle(Pagos pago)
    {
        var persona =  _Contexto.Personas.Find(pago.PersonaId);
        if(persona!=null){
            persona.Balance += pago.Monto;
            _Contexto.Entry(persona).State = EntityState.Modified;
            _Contexto.SaveChanges();
        }
        foreach (var item in pago.PagosDetalle)
        {
            var prestamo =  _Contexto.Prestamos.Find(item.PrestamoId);
            if (prestamo != null)
            {
                prestamo.Balance += item.ValorPagado;
            }
        }
        _Contexto.Entry(pago).State = EntityState.Modified;
        _Contexto.SaveChanges();
    }
void ModificarDetalle(Pagos pagoActual)
{
    var detallesOriginales = _Contexto.PagosDetalle.AsNoTracking().Where(d => d.PagoId == pagoActual.PagoId).ToList();
    foreach (var detalle in pagoActual.PagosDetalle)
    {
        if (detallesOriginales.Any(d => d.Id == detalle.Id))
        {
            var detalleOriginal = detallesOriginales.FirstOrDefault(d => d.Id == detalle.Id);
            var persona = _Contexto.Personas.Find(pagoActual.PersonaId);
            var prestamo = _Contexto.Prestamos.Find(detalle.PrestamoId);
            if (prestamo != null)
            {
                prestamo.Balance += detalleOriginal!.ValorPagado - detalle.ValorPagado;
                _Contexto.Entry(prestamo).State = EntityState.Modified;
                _Contexto.SaveChanges();

                persona!.Balance = prestamo.Balance;
                _Contexto.Entry(persona).State = EntityState.Modified;
                _Contexto.SaveChanges();
            }
        }
        else
        {
            var prestamo = _Contexto.Prestamos.Find(detalle.PrestamoId);
            var persona = _Contexto.Personas.Find(pagoActual.PersonaId);
            if (prestamo != null)
            {
                prestamo.Balance -= detalle.ValorPagado;
                _Contexto.Entry(prestamo).State = EntityState.Modified;
                _Contexto.SaveChanges();
                persona!.Balance = prestamo.Balance;
                _Contexto.Entry(persona).State = EntityState.Modified;
                _Contexto.SaveChanges();
            }
        }

    }
}


}
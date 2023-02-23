using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
public class PersonasBLL
{
    private Contexto _contexto;
    public PersonasBLL(Contexto contexto){
        _contexto = contexto;
    }
    public bool Existe(int personaId){
        return _contexto.Personas.Any(o => o.PersonaId == personaId);
    }
    public bool Inserta(Personas persona){
        _contexto.Personas.Add(persona);
        return _contexto.SaveChanges() > 0;
    }
    public bool Modificar(Personas persona){
        var PersonaEncontrada = _contexto.Personas.Find(persona.PersonaId);
        
        if(PersonaEncontrada != null){
            _contexto.Entry(PersonaEncontrada).CurrentValues.SetValues(persona);
            return _contexto.SaveChanges() > 0;
        }
        return false;
    }
    public bool Guardar(Personas persona){
        if(!Existe(persona.PersonaId))
            return this.Inserta(persona);
        else
            return this.Modificar(persona);
    }
    public bool Eliminar(int persona){
    var PersonaAEliminar = _contexto.Personas.Where(o=> o.PersonaId == persona).SingleOrDefault();
        if(PersonaAEliminar!=null){
            _contexto.Entry(PersonaAEliminar).State = EntityState.Deleted;
            return _contexto.SaveChanges() > 0;
        }
        return false;
    }
    public Personas? Buscar(int personaId){
        return _contexto.Personas.Where(o => o.PersonaId == personaId).AsNoTracking().SingleOrDefault();
    }
    public List<Personas> GetList(Expression<Func<Personas, bool>> criterio){
        return _contexto.Personas.AsNoTracking().Where(criterio).ToList();
    }
}
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Pagos
{
    [Key]
    public int PagoId { get; set; }

    [Required(ErrorMessage = "La fecha es requerida")]
    public DateTime Fecha { get; set;} = DateTime.Now;
    [Required(ErrorMessage = "La PersonaID es requerida")]
    public int PersonaId { get; set;}
    [Required(ErrorMessage = "El concepto es requerida")]
    public string? Concepto { get; set;}

    [Range(1, double.MaxValue, ErrorMessage = "El Monto debe estar en el rango valido {1} - {2}")]
    public double Monto { get; set;}
    
    [ForeignKey("PagoId")]
    public virtual List<PagosDetalle> PagosDetalle {get;set;} = new List<PagosDetalle> ();
}

public class PagosDetalle
{
    [Key]
    public int Id { get; set; }
    public int PagoId { get; set;}
    public int PrestamoId { get; set;}
    public double ValorPagado { get; set;}
}



using System.ComponentModel.DataAnnotations;

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
    [Required(ErrorMessage = "El Monto es requerida")]
    public double Monto { get; set;}
}


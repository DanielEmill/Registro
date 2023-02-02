using System.ComponentModel.DataAnnotations;
public class Prestamos
{
    [Key]
    public int PrestamoId { get; set; }
    [Required(ErrorMessage = "El campo PersonaId es requerida")]
    public int PersonaId { get; set;}
    [Required(ErrorMessage = "El campo Concepto es requerida")]
    public string? Concepto {get; set;}
    [Required(ErrorMessage = "El campo Monto es requerida")]
    public double Monto {get; set;}
    [Required(ErrorMessage = "El campo Balance es requerida")]
    public double Balance {get; set;}
    [Required(ErrorMessage = "El campo FechaInicio es requerida")]
    public DateTime? FechaInicio { get; set; }
    [Required(ErrorMessage = "El campo FechaVence es requerida")]
    public DateTime? FechaVence { get; set; }
}

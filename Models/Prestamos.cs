using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Prestamos
{
    [Key]
    public int PrestamoId { get; set; }
    [Required(ErrorMessage = "El campo PersonaId es requerida")]
    public int PersonaId { get; set;}
    [Required(ErrorMessage = "El campo Concepto es requerida")]
    public string? Concepto {get; set;}
    [Range(1, double.MaxValue, ErrorMessage = "El Monto debe estar en el rango valido {1} - {2}")]
    public double Monto {get; set;}
    [Range(1, double.MaxValue, ErrorMessage = "El balance debe estar en el rango valido {1} - {2}")]
    public double Balance {get; set;}
    [Required(ErrorMessage = "El campo FechaInicio es requerida")]
    public DateTime? FechaInicio { get; set; } = DateTime.Now;
    [Required(ErrorMessage = "El campo FechaVence es requerida")]
    public DateTime? FechaVence { get; set; }

}

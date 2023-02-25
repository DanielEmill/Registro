using System.ComponentModel.DataAnnotations;

public class PagosDetalle
{
    [Key]
    public int Id { get; set; }
    [Required(ErrorMessage = "El PagoId es necesario para completar la acción")]
    public int PagoId { get; set;}

    [Range(1, int.MaxValue, ErrorMessage = "Debes colocar un Prestamos")]
    public int PrestamoId { get; set;}

    [Range(1, double.MaxValue, ErrorMessage = "El ValorPagado debe estar en el rango valido {1} - {2}")]
    public double ValorPagado { get; set;}
}

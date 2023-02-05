using System.ComponentModel.DataAnnotations;
public class PagosDetalle
{
    [Key]
    public int Id { get; set; }
    [Required(ErrorMessage = "El pagoID es requerida")]
    public int PagoId { get; set;}
    [Required(ErrorMessage = "El PrestamosID es requerida")]
    public int PrestamoId { get; set;}
    [Required(ErrorMessage = "El ValorPagado es requerida")]
    public double ValorPagado { get; set;}
}

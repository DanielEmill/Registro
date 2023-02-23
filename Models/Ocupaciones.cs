using System.ComponentModel.DataAnnotations;

public class Ocupaciones
{
    [Key]
    public int OcupacionID { get; set; }
    [Required(ErrorMessage = "La Descripcion es requerida")]
    public string? Descripcion { get; set;}
    
    [Range(1, float.MaxValue, ErrorMessage = "El Precio debe estar en el rango valido {1} - {2}")]
    public float salario { get; set;}
}
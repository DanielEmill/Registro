using System.ComponentModel.DataAnnotations;

public class Ocupaciones
{
    [Key]
    public int OcupacionID { get; set; }
    [Required(ErrorMessage = "La Descripcion es requerida")]
    public string? Descripcion { get; set;}
    public float salario { get; set;}
}
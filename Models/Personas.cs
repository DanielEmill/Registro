using System.ComponentModel.DataAnnotations;

public class Personas
{
    [Key]
    public int PersonaId { get; set; }
    [Required(ErrorMessage = "El campo Nombre es requerida")]
    public string? Nombres { get; set;}
    [Required(ErrorMessage = "El campo Telefono es requerida")]
    public string? Telefono {get; set;}
    [Required(ErrorMessage = "El Campo Celular es requerida")]
    public string? Celular {get; set;}
    [Required(ErrorMessage = "El Campo Email es requerida")]
    public string? Email {get; set;}
    [Required(ErrorMessage = "El Campo Direccion es requerida")]
    public string? Direccion { get; set; }
    [Required(ErrorMessage = "El Campo FechaNacimiento es requerida")]
    public DateTime? FechaNacimiento { get; set; }
    [Required(ErrorMessage = "El Campo OcupacionId es requerida")]
    public int OcupacionId { get; set; }
    public double Balance {get; set;}

}

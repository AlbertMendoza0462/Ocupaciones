using System.ComponentModel.DataAnnotations;

public class Ocupacion
{
    [Key]
    public int OcupacionID { get; set; }
    public string? Descripcion { get; set; }
    public double Salario { get; set; }
}
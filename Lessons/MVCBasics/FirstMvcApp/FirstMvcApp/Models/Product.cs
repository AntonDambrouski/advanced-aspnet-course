using System.ComponentModel.DataAnnotations;

namespace FirstMvcApp.Models;

public class Product
{
    public int Id { get; set; }
    [StringLength(15)]
    [Required]
    public string Name { get; set; }
    [Range(0, 1000)]
    public decimal Price { get; set; }
}

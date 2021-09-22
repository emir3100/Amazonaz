using System.ComponentModel.DataAnnotations;
namespace Amazonaz.Server.Models;

public class ProductModel
{
    [Key]
    public Guid Id { get; set; }
    public int TotalSupply { get; set; }
    public double Price { get; set; }
    [MaxLength(32)]
    public string Name {  get; set; }
    [MaxLength(64)]
    public string? Description {  get; set; }
    public DateTime CreationDate { get; set; }
    public Guid CreatedById { get; set; }
    
}

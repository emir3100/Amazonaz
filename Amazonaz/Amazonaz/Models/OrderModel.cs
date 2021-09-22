using System.ComponentModel.DataAnnotations;

namespace Amazonaz.Server.Models;

public class OrderModel
{
    [Key]
    public Guid Id { get; set; }
    
    public Guid UserId { get; set; }

    public Guid ProductId { get; set; }

    [Required]
    public int Quantity { get; set; }

    [MaxLength(64)]
    [Required]
    public string ToAdress { get; set; }

    [Required]
    public DateTime OrderDate { get; set; }

    public UserModel User {  get; set; }

    public ProductModel Product { get; set; }

    public OrderModel()
    {
        Id = Guid.NewGuid();
    }
}

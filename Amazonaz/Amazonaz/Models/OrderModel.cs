using System.ComponentModel.DataAnnotations;
namespace Amazonaz.Server.Models;

#nullable disable
public class OrderModel
{
    [Key]
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
    [MaxLength(64)]
    public string ToAdress { get; set; }
    public DateTime OrderDate { get; set; }
}

using System.ComponentModel.DataAnnotations;
namespace Amazonaz.Server.Models;

#nullable disable
public class UserModel
{
    [Key]
    public Guid Id { get; set; }
    [MaxLength(32)]
    public string FirstName { get; set; }
    [MaxLength(32)]
    public string LastName { get; set; }
    [MaxLength(64)]
    public string Address { get; set; }

}

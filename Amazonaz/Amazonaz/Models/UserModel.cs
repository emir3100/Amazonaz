using System.ComponentModel.DataAnnotations;

namespace Amazonaz.Server.Models;

public class UserModel
{
    [Key]
    public Guid Id { get; set; }

    [MaxLength(32)]
    [Required]
    public string FirstName { get; set; }

    [MaxLength(32)]
    [Required]
    public string LastName { get; set; }

    [MaxLength(64)]
    [Required]
    public string Address { get; set; }

    public UserModel()
    {
        Id = Guid.NewGuid();
    }
}

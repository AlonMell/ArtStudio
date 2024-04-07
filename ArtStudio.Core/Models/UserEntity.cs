using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArtStudio.Core.Models;

public class UserEntity
{
    [Key, Column("Id")]
    public Guid Id { get; set; }
    
    [Column(TypeName = "TIMESTAMP")]
    public DateTime CreatedOn { get; set; }
    
    [Required, Column(TypeName = "VARCHAR(50)")]
    public string Name { get; set; }

    [Required, Column(TypeName = "VARCHAR(50)")]
    public string Email { get; set; }

    [Required, Column(TypeName = "VARCHAR(100)")]
    public string PasswordHash { get; set; }
}
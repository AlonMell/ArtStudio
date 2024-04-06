using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArtStudio.Core.Models;

public class ArtEntity
{
    [Key, Column("Id")]
    public Guid Id { get; set; }
    
    [Column(TypeName = "TIMESTAMP")]
    public DateTime CreatedOn { get; set; }
    
    [Required, Column(TypeName = "VARCHAR(50)")]
    public string Name { get; set; }
    
    [Column(TypeName = "DECIMAL(18, 2)")]
    public decimal Price { get; set; } 
    
    [Column(TypeName = "TEXT")]
    public string Description { get; set; }
}
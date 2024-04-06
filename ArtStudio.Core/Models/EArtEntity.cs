using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArtStudio.Core.Models;

public class EArtEntity
{
    [Key, Column("Id")]
    public Guid Id { get; set; }
    
    [Required, Column(TypeName = "TIMESTAMP")]
    public DateTime CreatedOn { get; set; } = DateTime.Today;
    
    [Required, Column(TypeName = "VARCHAR(50)")]
    public string Name { get; set; }
    
    [Column(TypeName = "DECIMAL(18, 2)")]
    public decimal? Price { get; set; } = 0;
    
    [Column(TypeName = "TEXT")]
    public string? Description { get; set; } = string.Empty;
}
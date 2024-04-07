using System.ComponentModel.DataAnnotations;

namespace ArtStudio.Core.Dto;

public record RegisterUserRequest(
    [Required] string Name, 
    [Required] string Email, 
    [Required] string Password);
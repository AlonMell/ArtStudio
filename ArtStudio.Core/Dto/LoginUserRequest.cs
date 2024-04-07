using System.ComponentModel.DataAnnotations;

namespace ArtStudio.Core.Dto;

public record LoginUserRequest(
    [Required] string Email, 
    [Required] string Password);
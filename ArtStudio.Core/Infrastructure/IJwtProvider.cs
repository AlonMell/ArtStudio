using ArtStudio.Core.Models;

namespace ArtStudio.Core.Infrastructure;

public interface IJwtProvider
{
    string Generate(UserEntity user);
}
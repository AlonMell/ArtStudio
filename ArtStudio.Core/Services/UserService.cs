using ArtStudio.Core.Context;
using ArtStudio.Core.Dto;
using ArtStudio.Core.Errors;
using ArtStudio.Core.Infrastructure;
using ArtStudio.Core.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;


namespace ArtStudio.Core.Services;

public class UserService(
    IPasswordHasher passwordHasher, 
    IJwtProvider jwtProvider,
    ArtStudioDbContext dbContext) : IUserService
{
    public async Task<string> Register(RegisterUserRequest userRequest)
    {
        var passwordHash = passwordHasher.Generate(userRequest.Password);
        var user = new UserEntity
        {
            Id = Guid.NewGuid(),
            Name = userRequest.Name, 
            Email = userRequest.Email, 
            PasswordHash = passwordHash
        };
        await dbContext.AddAsync(user);
        await dbContext.SaveChangesAsync();
        var token = jwtProvider.Generate(user);
        
        return token;
    }

    public async Task<string> Login(LoginUserRequest loginRequest)
    {
        var user = await dbContext.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.Email == loginRequest.Email);
        if (user is null) throw ServiceException.NotFound("User not found.");
        var result = passwordHasher.Verify(loginRequest.Password, user.PasswordHash);
        if (!result) throw ServiceException.BadRequest("Wrong password.");
        
        var token = jwtProvider.Generate(user);
        return token;
    }

    public Task Get()
    {
        throw new NotImplementedException();
    }
}
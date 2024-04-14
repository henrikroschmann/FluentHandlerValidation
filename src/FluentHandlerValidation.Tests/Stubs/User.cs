using FluentHandlerValidation.Domain.Models;

namespace FluentHandlerValidation.Tests.Stubs;

public class User
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public string FullName { get; set; }
    public string LastName { get; set; }

    public static Result<User, string> Create(Guid id, string email, string fullName, string lastName)
    {
        return Result<User, string>.Success(new User
        {
            Id = id,
            Email = email,
            FullName = fullName,
            LastName = lastName
        });
    }
}

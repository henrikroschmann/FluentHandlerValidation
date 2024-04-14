using FluentHandlerValidation.Domain.Models;

public class User
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public static Result<User, string> Create(Guid id,
                                              string email,
                                              string firstName,
                                              string lastName)
    {
        return Result<User, string>.Success(new User
        {
            Id = id,
            Email = email,
            FirstName = firstName,
            LastName = lastName
        });
    }
}

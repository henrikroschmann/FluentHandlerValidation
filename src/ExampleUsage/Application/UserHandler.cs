using FluentHandlerValidation.Domain.Extensions;
using FluentHandlerValidation.Domain.Models;

public class UserHandler
{
    public Result<Guid, string> Handler(UserDto request) =>
        User.Create(
                Guid.NewGuid(),
                request.Email,
                request.FirstName,
                request.LastName
            )
        .Bind(IsEmailValid)
        .Map(user => user.Id);

    /// <summary>
    /// Validates if email is not null and if the email contains @
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    private Result<User, string> IsEmailValid(User user)
    {
        if (!string.IsNullOrEmpty(user.Email) && user.Email.Contains('@'))
        {
            return Result<User, string>.Success(user);
        }
        return Result<User, string>.Failure("Email is not valid");
    }
 
    
}

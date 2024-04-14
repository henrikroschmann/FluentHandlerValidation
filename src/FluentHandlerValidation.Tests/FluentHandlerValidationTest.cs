using AutoFixture;
using FluentHandlerValidation.Domain.Extensions;
using FluentHandlerValidation.Domain.Models;
using FluentHandlerValidation.Tests.Stubs;
using NSubstitute;

namespace FluentHandlerValidation.Tests;

public class FluentHandlerValidationTest
{
    public Fixture _autoFixture = new();

    [Fact]
    public void FluentHandlerValidation_HappyPath_Success()
    {
        var id = Guid.NewGuid();
        var userDto = _autoFixture.Create<UserDto>();
        var user = _autoFixture.Create<User>();
        
        var result = User.Create(
            id,
            userDto.Email,
            userDto.FullName,
            userDto.LastName
            )
            .Bind(IsValidInput)
            .Tap(user => user.FullName = "Manipulated")
            .Map(user => user);

        Assert.True(result.IsSuccess);
        Assert.Equal(result.Value.Id, id);
        Assert.Equal(result.Value.FullName, "Manipulated");
    }

    [Fact]
    public void FluentHandlerValidation_SadPath_Success()
    {
        var id = Guid.NewGuid();
        var userDto = _autoFixture.Create<UserDto>();
        var user = _autoFixture.Create<User>();

        var result = User.Create(
            id,
            null,
            userDto.FullName,
            userDto.LastName
            )
            .Bind(IsValidInput)
            .Tap(user => InputManipulation(user))
            .Tap(() => Console.WriteLine("Saving...."))
            .Map(user => user.Id);

        Assert.False(result.IsSuccess);
        Assert.Equal(result.Error, "Email is null");
    }

    private Result<User, string> IsValidInput(User user)
    {
        if (!string.IsNullOrEmpty(user.Email))
        {
            return Result<User, string>.Success(user);
        }
        return Result<User, string>.Failure("Email is null");
    }

    private Result<User, string> InputManipulation(User user)
    {
        user.FullName = "Manipulation";
        return Result<User, string>.Success(user);
    }
}

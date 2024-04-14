var user = new UserDto
{
    Email = "MyEmailgmail.com",
    FirstName = "MyFirstName",
    LastName = "MyLastName"
};

var exampleHandler = new UserHandler();
var result = exampleHandler.Handler(user);
if (result.IsSuccess)
{
    Console.WriteLine($"User id is {result.Value}");
}
else
{
    Console.WriteLine($"Something went wrong {result.Error}");
}

Console.WriteLine();
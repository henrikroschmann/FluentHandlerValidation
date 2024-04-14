var user = new UserDto
{
    Email = "MyEmailgmail.com",
    FirstName = "MyFirstName",
    LastName = "MyLastName"
};

var exampleHander = new UserHandler();
var result = exampleHander.Handler(user);
if (result.IsSuccess)
{
    Console.WriteLine($"User id is {result.Value}");
}
else
{
    Console.WriteLine($"Something went wrong {result.Error}");
}

Console.WriteLine();
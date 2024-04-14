# FluentHandlerValidation
A library providing extension methods to facilitate functional data handling, validation, and manipulation in C#, with a focus on robust error handling using Result types.

# Overview
This library provides a set of extension methods to create fluent and expressive validation chains in C#. It integrates with Result types for improved error handling and promotes a functional programming style.

# Key Features
-   **Chaining:**  Easily chain multiple validation steps using the  `Bind`  extension method.
-   **Error Handling:**  Result types make error handling explicit, preventing unhandled exceptions.
-   **Readability:**  The fluent syntax improves code readability.
-   **Customizable:**  Write your own validation functions that return Result types.

# Installation
```csharp
dotnet add package FluentValidationPipeline
```
# **Usage Example**
```csharp
using FluentValidationPipeline;

// ... Validation functions ...

public Result<Guid, string> Handler(UserDto request) =>
	User.Create(...)
	.Bind(ValidateEmail)
	.Bind(ValidateNameUniqueness)
	.Tap(_repository.Insert)
	.Tap(_repository.SaveChanges)
	.Map(user => user.Id);
```

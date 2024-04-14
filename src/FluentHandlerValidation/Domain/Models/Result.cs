namespace FluentHandlerValidation.Domain.Models;

/// <summary>
/// Represents the outcome of an operation, encapsulating either a successful value or an error.
/// </summary>
/// <typeparam name="TValue">The type of the value contained in a successful result.</typeparam>
/// <typeparam name="TError">The type of the error contained in a failure result.</typeparam>

public class Result<TValue, TError>
{
    /// <summary>
    /// Indicates whether the result represents a success or a failure.
    /// </summary>
    public bool IsSuccess { get; }

    /// <summary>
    /// The value contained in the result if successful. Will be null if IsSuccess is false.
    /// </summary>
    public TValue? Value { get; }

    /// <summary>
    /// The error contained in the result if a failure. Will be null if IsSuccess is true.
    /// </summary>
    public TError? Error { get; }

    /// <summary>
    /// Private constructor for creating a successful result.
    /// </summary>
    /// <param name="value">The value to be contained in the successful result.</param>
    private Result(TValue value)
    {
        IsSuccess = true;
        Value = value;
        Error = default;
    }

    /// <summary>
    /// Private constructor for creating a failure result.
    /// </summary>
    /// <param name="error">The error to be contained in the failure result.</param>
    private Result(TError error)
    {
        IsSuccess = false;
        Value = default;
        Error = error;
    }

    /// <summary>
    /// Creates a new successful result containing the specified value.
    /// </summary>
    /// <param name="value">The value to be contained in the result.</param>
    /// <returns>A new Result instance representing success.</returns>
    public static Result<TValue, TError> Success(TValue? value) =>
        new(value);

    /// <summary>
    /// Creates a new failure result containing the specified error.
    /// </summary>
    /// <param name="error">The error to be contained in the result.</param>
    /// <returns>A new Result instance representing failure.</returns>
    public static Result<TValue, TError> Failure(TError? error) =>
        new(error);
}

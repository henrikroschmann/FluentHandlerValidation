using FluentHandlerValidation.Domain.Models;

namespace FluentHandlerValidation.Domain.Extensions;

/// <summary>
/// Provides a set of extension methods designed to streamline operations on the Result type.
/// </summary>
public static class TesutExtension
{
    /// <summary>
    /// Conditionally chains another operation on a successful Result. If the current Result is a success,
    /// the provided predicate function is executed. If the current Result is a failure, it is returned unchanged.
    /// </summary>
    /// <typeparam name="T">The type of the value contained in the Result.</typeparam>
    /// <typeparam name="E">The type of the error contained in the Result.</typeparam>
    /// <param name="result">The Result instance to operate on.</param>
    /// <param name="predicate">A function that takes the value of the Result and returns a new Result.</param>
    /// <returns>A Result that either represents the outcome of the predicate or the original failure.</returns>
    public static Result<T, E> Bind<T, E>(this Result<T, E> result, Func<T, Result<T, E>> predicate)
    {
        return result.IsSuccess
            ? predicate(result.Value)
            : result;
    }

    /// <summary>
    /// Executes an action on the value of a successful Result without modifying it. 
    /// </summary>
    /// <typeparam name="T">The type of the value contained in the Result.</typeparam>
    /// <typeparam name="E">The type of the error contained in the Result.</typeparam>
    /// <param name="result">The Result instance.</param>
    /// <param name="action">An action to perform on the value of the Result if it is a success.</param>
    /// <returns>The original Result, unmodified.</returns>
    public static Result<T, E> Tap<T, E>(this Result<T, E> result, Action<T> action)
    {
        if (result.IsSuccess) 
        { 
            action(result.Value); 
        }
        return result;
    }

    /// <summary>
    /// Executes an action regardless of the Result's success or failure state.
    /// </summary>
    /// <typeparam name="T">The type of the value contained in the Result.</typeparam>
    /// <typeparam name="E">The type of the error contained in the Result.</typeparam>
    /// <param name="result">The Result instance.</param>
    /// <param name="action">An action to perform.</param>
    /// <returns>The original Result, unmodified.</returns>
    public static Result<T, E> Tap<T, E>(this Result<T, E> result, Action action)
    {
        action();
        return result;
    }

    /// <summary>
    /// Transforms the value contained in a successful Result using a provided function. If the Result is a failure,
    /// the original error is preserved.
    /// </summary>
    /// <typeparam name="T1">The original value type in the Result.</typeparam>
    /// <typeparam name="T2">The transformed value type.</typeparam>
    /// <typeparam name="E">The type of the error contained in the Result.</typeparam>
    /// <param name="result">The Result instance.</param>
    /// <param name="func">A function to transform the value of the Result.</param>
    /// <returns>A new Result containing either the transformed value (if successful) or the original error.</returns>
    public static Result<T2, E> Map<T1, T2, E>(this Result<T1, E> result, Func<T1, T2> func)
    {
        return result.IsSuccess
            ? Result<T2, E>.Success(func(result.Value))
            : Result<T2, E>.Failure(result.Error);
    }
}

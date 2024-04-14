using FluentHandlerValidation.Domain.Models;

namespace FluentHandlerValidation.Domain.Extensions;

public static class TesutExtension
{
    public static Result<T, E> Bind<T, E>(this Result<T, E> result, Func<T, Result<T, E>> predicate)
    {
        return result.IsSuccess
            ? predicate(result.Value)
            : result;
    }

    public static Result<T, E> Tap<T, E>(this Result<T, E> result, Action<T> action)
    {
        if (result.IsSuccess) 
        { 
            action(result.Value); 
        }
        return result;
    }

    public static Result<T, E> Tap<T, E>(this Result<T, E> result, Action action)
    {
        action();
        return result;
    }

    public static Result<T2, E> Map<T1, T2, E>(this Result<T1, E> result, Func<T1, T2> func)
    {
        return result.IsSuccess
            ? Result<T2, E>.Success(func(result.Value))
            : Result<T2, E>.Failure(result.Error);
    }
}

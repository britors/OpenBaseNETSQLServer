using Azure;

namespace OpenBaseNET.Infra.Resilience.Azure.ExceptionPredicate;

internal static class AzureStorageExceptionPredicate
{
    private const string EntityNotFound = "404";
    private const string EntityAlreadyExists = "409";
    private const string InvalidInput = "400";

    internal static bool ShouldRetryOn(RequestFailedException exception)
    {
        return exception.ErrorCode switch
        {
            EntityNotFound
                or EntityAlreadyExists
                or InvalidInput => true,
            _ => false
        };
    }
}
using System.ComponentModel;

namespace OpenBaseNET.Infra.Resilience.Core.ExceptionPredicate;

internal static class Win32ExceptionPredicate
{
    private const int FileNotFound = 0x02;
    private const int NoMoreItens = 0x102;
    private const int CannotCreateAnoterSystemSemaphore = 0x64;
    private const int SemaphoreTimeoutExpired = 0x121;
    private const int PipeHasBeenEnded = 0x6B;

    internal static bool ShouldRetryOn(Win32Exception exception)
    {
        return exception.NativeErrorCode switch
        {
            FileNotFound
                or NoMoreItens
                or SemaphoreTimeoutExpired
                or PipeHasBeenEnded
                or CannotCreateAnoterSystemSemaphore => true,
            _ => false
        };
    }
}
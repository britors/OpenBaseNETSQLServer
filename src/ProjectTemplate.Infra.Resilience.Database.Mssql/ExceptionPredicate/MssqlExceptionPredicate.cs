using System.Data.SqlClient;

namespace ProjectTemplate.Infra.Resilience.Database.Mssql.ExceptionPredicate;

internal static class MssqlExceptionPredicate
{
    #region constantes

    private const int CannotProcessRequest = 49920;
    private const int CannotProcessCreateOrUpdateRequest = 49919;
    private const int NotEnoughResoucesToProcessRequest = 49918;
    private const int TransactionExceedeMaximumNumberOfCommitDependencies = 41839;
    private const int CommitTransactionSerializableFailed = 41325;
    private const int CommitTransactionRepeatableFailed = 41305;
    private const int UpdateaRecordThatBeebUpdatedSizeTransactionStarted = 41302;
    private const int DependencyFalilure = 41301;
    private const int ServiceIsCurrentlyBusy = 40501;
    private const int ServiceEncounteredErrorProcessingYourRequest = 40197;
    private const int ConnectAttemptFailed = 10929;
    private const int ServerIsCurrentlyTooBusy = 10929;
    private const int ResourceIdLimitDatabaseHasBeenReached = 10928;
    private const int ServerNotFoundOrNotAllow = 10060;
    private const int AExistingConnectionWasForciblyClosedByTheRemoteHost = 10054;
    private const int ConnectionWasAbortedBySoftwareInYourHostMachine = 10053;
    private const int Deadlock = 1205;
    private const int ClientWasUnableToEstablishAConnection = 233;
    private const int SemaphoreTimeout = 121;
    private const int ErrorInLoginProcess = 64;
    private const int EncryptionSuportNotSupport = 20;

    #endregion constantes

    internal static bool ShouldRetryOn(SqlException exception)
    {
        foreach (SqlError error in exception.Errors)
        {
            var result = error.Number switch
            {
                CannotProcessRequest
                or CannotProcessCreateOrUpdateRequest
                or NotEnoughResoucesToProcessRequest
                or TransactionExceedeMaximumNumberOfCommitDependencies
                or CommitTransactionSerializableFailed
                or CommitTransactionRepeatableFailed
                or UpdateaRecordThatBeebUpdatedSizeTransactionStarted
                or DependencyFalilure
                or ServiceIsCurrentlyBusy
                or ServiceEncounteredErrorProcessingYourRequest
                or ConnectAttemptFailed
                or ServerIsCurrentlyTooBusy
                or ResourceIdLimitDatabaseHasBeenReached
                or ServerNotFoundOrNotAllow
                or AExistingConnectionWasForciblyClosedByTheRemoteHost
                or ConnectionWasAbortedBySoftwareInYourHostMachine
                or Deadlock
                or ClientWasUnableToEstablishAConnection
                or SemaphoreTimeout
                or ErrorInLoginProcess
                or EncryptionSuportNotSupport
                    => true,
                _ => false
            };
            if (result) return result;
        }
        return false;
    }
}
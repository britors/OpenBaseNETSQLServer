using MediatR;
using Microsoft.Extensions.Logging;
using ProjectTemplate.Domain.Context;
using System.Reflection;


namespace ProjectTemplate.Application.Pipeline;

public class LoggingBehaviour<TRequest, TResponse> :
    IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    private readonly ILogger<LoggingBehaviour<TRequest, TResponse>> _logger;
    private readonly SessionContext _sessionContext;

    public LoggingBehaviour(ILogger<LoggingBehaviour<TRequest, TResponse>> logger, SessionContext sessionContext)
    {
        _logger = logger;
        _sessionContext = sessionContext;
    }

    public async Task<TResponse> Handle(TRequest request,
        CancellationToken cancellationToken,
        RequestHandlerDelegate<TResponse> next)
    {
        _logger.LogInformation($"Inicio da Sessão: {_sessionContext.Correlationid}");
        _logger.LogInformation($"Handling {typeof(TRequest).Name}");
        Type myType = request.GetType();
        var props = new List<PropertyInfo>(myType.GetProperties());
        foreach (var prop in props)
        {
            if (prop is not null)
            {
                object propValue = prop.GetValue(request, null) ?? "";
                if (propValue is not null)
                {
                    _logger.LogInformation("{Property} : {@Value}", prop.Name, propValue);
                }
            }

        }
        var response = await next();
        _logger.LogInformation($"Handled {typeof(TResponse).Name}");
        _logger.LogInformation($"Fim da Sessão: {_sessionContext.Correlationid}");
        return response;
    }
}
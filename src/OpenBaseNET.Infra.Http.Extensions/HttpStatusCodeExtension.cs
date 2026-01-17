/*
 * Name: HttpStatusCodeExtension
 * Author: Rodrigo Brito <rodrigo@w3ti.com.br>
 * Type: Extension Class
 * Create At:   10/25/2025
 * Last Update: 10/25/2025
 * Description:
 *     Extensão para a enumeração HttpStatusCode, 
 *     fornecendo métodos auxiliares para verificar categorias de status HTTP.
 * Versions:
 * |--------------------------------------------------------------|
 * | Date           | Description                                 |
 * | 10/25/2025     | Criação do HttpStatusCodeExtension          |
 * |--------------------------------------------------------------|
 */
using System.Net;

namespace OpenBaseNET.Infra.Http.Extensions;

public static class HttpStatusCodeExtension
{
    public static bool IsInformationalStatus(this HttpStatusCode statusCode)
    {
        return (int)statusCode >= 100 && (int)statusCode <= 199;
    }

    public static bool IsSuccessStatus(this HttpStatusCode statusCode)
    {
        return (int)statusCode >= 200 && (int)statusCode <= 299;
    }

    public static bool IsRedirectionStatus(this HttpStatusCode statusCode)
    {
        return (int)statusCode >= 300 && (int)statusCode <= 399;
    }

    public static bool IsClientErrorStatus(this HttpStatusCode statusCode)
    {
        return (int)statusCode >= 400 && (int)statusCode <= 499;
    }

    public static bool IsServerErrorStatus(this HttpStatusCode statusCode)
    {
        return (int)statusCode >= 500 && (int)statusCode <= 599;
    }
}
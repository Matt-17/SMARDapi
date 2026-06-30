using System.Net;

namespace SMARDapi.Models;

/// <summary>
/// Represents an error returned by, or encountered while calling, the SMARD API.
/// </summary>
public sealed class SmardApiException : Exception
{
    internal SmardApiException(string message, string? endpoint = null, HttpStatusCode? statusCode = null, Exception? innerException = null)
        : base(message, innerException)
    {
        Endpoint = endpoint;
        StatusCode = statusCode;
    }

    /// <summary>
    /// The relative SMARD endpoint that caused the error, if available.
    /// </summary>
    public string? Endpoint { get; }

    /// <summary>
    /// The HTTP status code returned by SMARD, if the request reached the server.
    /// </summary>
    public HttpStatusCode? StatusCode { get; }
}

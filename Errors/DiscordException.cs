using System.Net;

namespace SharpCord.Errors;

/// <summary>
/// 
/// </summary>
public class DiscordException : Exception
{
    
    /// <summary>
    /// 
    /// </summary>
    public int? ErrorCode { get; }

    /// <summary>
    /// 
    /// </summary>
    public string? Message { get; }
    
    /// <summary>
    /// 
    /// </summary>
    public HttpStatusCode StatusCode { get; }
    
    /// <summary>
    /// 
    /// </summary>
    public string RawJson { get; }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="statusCode"></param>
    /// <param name="message"></param>
    /// <param name="errorCode"></param>
    /// <param name="rawJson"></param>
    public DiscordException(HttpStatusCode statusCode, string message, int? errorCode = null, string rawJson = "") : base(message)
    {
        StatusCode = statusCode;
        ErrorCode = errorCode;
        RawJson = rawJson;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="code"></param>
    /// <param name="message"></param>
    public DiscordException(int? code, string? message) : base(message)
    {
        ErrorCode = code;
        Message = message;
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        return $"[DiscordException] {StatusCode} {(ErrorCode is not null ? $"(Code {ErrorCode})" : "")}: {Message}";
    }
}

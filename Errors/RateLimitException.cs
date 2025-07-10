namespace SharpCord.Errors;

public class RateLimitException : DiscordException
{
    public TimeSpan RetryAfter { get; }
    
    public RateLimitException(TimeSpan retryAfter) : base(429, $"Rate limit exceeded. Retry after: {retryAfter.TotalSeconds} seconds.") 
        => RetryAfter = retryAfter;
}
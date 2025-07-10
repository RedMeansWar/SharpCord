namespace SharpCord.Errors;

public class ShardException : Exception
{
    public int ShardId { get; }

    protected ShardException(string message, int shardId) : base($"[Shard {shardId}] {message}") => ShardId = shardId;

    protected ShardException(string message, int shardId, Exception inner) : base($"[Shard {shardId}] {message}", inner) => ShardId = shardId;
}

public class ShardHeartbeatTimeoutException : ShardException
{
    public TimeSpan Elapsed { get; }
    
    public ShardHeartbeatTimeoutException(int shardId, TimeSpan elapsed) : base($"Shard missed heartbeat for {elapsed.TotalSeconds} seconds.", shardId)
        => Elapsed = elapsed;
}

public class ShardConnectionException : ShardException
{
    public ShardConnectionException(int shardId, string? reason = null) : base(reason ?? "Failed to connect to shard.", shardId) { }
}

public class ShardIdentifyRateLimitException : ShardException
{
    public TimeSpan RetryAfter { get; }
    
    public ShardIdentifyRateLimitException(int shardId, TimeSpan retryAfter) 
        : base($"Shard {shardId} was rate-limited when identifying. Retry after {retryAfter.TotalSeconds} seconds.", shardId) => RetryAfter = retryAfter;
}

public class ShardUnexpectedDisconnectException : ShardException
{
    public int CloseCode { get; }
    public string? CloseReason { get; }

    public ShardUnexpectedDisconnectException(int shardId, int closeCode, string? reason) 
        : base($"Shard disconnected unexpectedly. Close Code: {closeCode}, Reason: {reason}", shardId)
    {
        CloseCode = closeCode;
        CloseReason = reason;
    }
}

public class ShardReconnectionFailureException : ShardException
{
    public int AttemptCount { get; }

    public ShardReconnectionFailureException(int shardId, int attempts)
        : base($"Shard {shardId} failed to reconnect after {attempts} attempts.", shardId) => AttemptCount = attempts;
}


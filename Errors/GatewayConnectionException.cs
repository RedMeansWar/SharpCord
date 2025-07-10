namespace SharpCord.Errors;

public class GatewayConnectionException : Exception
{
    public GatewayConnectionException(string? detail = null) : base($"Failed to connect to Discord Gateway. {detail}") { }
}
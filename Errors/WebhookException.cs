namespace SharpCord.Errors;

public class WebhookException : Exception
{
    public WebhookException(string message) : base($"Webhook Error: {message}") { }
}
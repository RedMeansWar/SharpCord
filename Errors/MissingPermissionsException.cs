namespace SharpCord.Errors;

public class MissingPermissionsException : DiscordException
{
    public string RequiredPermissions { get; }
    
    public MissingPermissionsException(string requiredPermissions) : base(403, $"Missing permissions: {requiredPermissions}")
        => RequiredPermissions = requiredPermissions;
}
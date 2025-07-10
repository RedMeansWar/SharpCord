using SharpCord.Types;

namespace SharpCord.Errors;

public class UserNotFoundException : Exception
{
    public UserNotFoundException(Snowflake userId) : base($"User {userId} not found or inaccessible.") { }
}
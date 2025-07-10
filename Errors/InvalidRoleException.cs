using SharpCord.Types;

namespace SharpCord.Errors;

public class InvalidRoleException : Exception
{
    public InvalidRoleException(Snowflake roleId) : base($"Role with ID {roleId} not found or not accessible.") { }
}
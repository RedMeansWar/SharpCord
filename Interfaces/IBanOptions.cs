namespace SharpCord.Interfaces;

public interface IBanOptions
{
    int DeleteMessagesAfter { get; }
    string? Reason { get; }
}
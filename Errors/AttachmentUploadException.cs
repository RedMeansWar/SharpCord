namespace SharpCord.Errors;

public class AttachmentUploadException : Exception
{
    public AttachmentUploadException(string filename, long size) : base($"Failed to upload '{filename}'. Size: {size} bytes.") { }
}
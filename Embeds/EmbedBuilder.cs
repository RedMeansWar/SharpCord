using SharpCord.Models;

namespace SharpCord.Embeds;

public class EmbedBuilder : Embed
{
    public EmbedBuilder WithTitle(string title) { Title = title; return this; }
    public EmbedBuilder WithDescription(string description) { Description = description; return this; }
    public EmbedBuilder WithUrl(string url) { Url = url; return this; }
    public EmbedBuilder WithColor(uint color) { Color = color; return this; }
    public EmbedBuilder WithTimestamp(DateTimeOffset timestamp) { Timestamp = timestamp; return this; }
    
    public EmbedBuilder WithAuthor(string name, string? iconUrl = null, string? url = null)
    {
        Author = new EmbedAuthor
        {
            Name = name,
            IconUrl = iconUrl,
            Url = url
        };

        return this;
    }

    public EmbedBuilder WithFooter(string text, string? iconUrl = null)
    {
        Footer = new EmbedFooter
        {
            Text = text,
            IconUrl = iconUrl
        };

        return this;
    }

    public EmbedBuilder AddField(string name, string value, bool inline = false)
    {
        Fields?.Add(new EmbedField
        {
            Name = name,
            Value = value,
            Inline = inline
        });
        
        return this;
    }

    public EmbedBuilder AddFields(IEnumerable<EmbedField> fields)
    {
        Fields?.AddRange(fields);
        return this;
    }

    public EmbedBuilder AddFields(params EmbedField[] fields)
    {
        Fields?.AddRange(fields);
        return this;
    }

    public EmbedBuilder AddFields(params (string Name, string Value, bool Inline)[] fields)
    {
        foreach (var (name, value, inline) in fields)
            Fields.Add(new EmbedField(name, value, inline));

        return this;
    }
    
    public EmbedBuilder WithImage(string url)
    {
        Image = new() { Url = url };
        return this;
    }
    
    public EmbedBuilder WithThumbnail(string url)
    {
        Thumbnail = new() { Url = url };
        return this;
    }

    public Embed Build()
    {
        return new Embed
        {
            Title = Title,
            Description = Description,
            Url = Url,
            Color = Color,
            Timestamp = Timestamp,
            Author = Author,
            Footer = Footer,
            Fields = Fields,
            Image = Image,
        };
    }
}
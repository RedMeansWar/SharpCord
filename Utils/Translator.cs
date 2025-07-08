using System.Text.Json;
using Microsoft.VisualBasic;
using SharpCord.Errors;

namespace SharpCord.Utils;

/// <summary>
/// 
/// </summary>
public static class Translator
{
    public static int? TryExtractCode(string json)
    {
        try
        {
            using var doc = JsonDocument.Parse(json);
            return ExtractCodeRecursive(doc.RootElement);
        }
        catch
        {
            return null;
        }
    }

    public static string TranslateFromJson(string json)
    {
        try
        {
            using var doc = JsonDocument.Parse(json);
            var root = doc.RootElement;

            int? code = ExtractCodeRecursive(root);
            switch (code is not null)
            {
                case true when GatewayCodesTranslator.TryGetValue(code.Value, out var knownGateway): return $"[Discord Error {code}] {knownGateway}";
                case true when RestCodeTranslator.TryGetValue(code.Value, out var knownRest): return $"[Discord Error {code}] {knownRest}";
                case true when VoiceCodeTranslator.TryGetValue(code.Value, out var knownVoiceCode): return $"[Discord Error {code}] {knownVoiceCode} (Reconnect: {knownVoiceCode.shouldReconnect})";
                case true: return $"[Discord Error {code}] {root.GetProperty("message").GetString()}";
                case false: return "Unknown Discord error (no code/message found)";
            }
        }
        catch (Exception ex)
        {
            Log.Error($"[Discord API Error] Status: {ex}, Message: {ex.Message}");
            return $"Failed to parse Discord error JSON: {ex.Message}";
        }
    }

    public static int? ExtractCodeRecursive(JsonElement element)
    {
        if (element.ValueKind == JsonValueKind.Object)
        {
            foreach (var prop in element.EnumerateObject())
            {
                if (prop.NameEquals("code"))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Number)
                        return prop.Value.GetInt32();

                    if (prop.Value.ValueKind == JsonValueKind.String &&
                        int.TryParse(prop.Value.GetString(), out var parsed))
                        return parsed;
                }

                var nested = ExtractCodeRecursive(prop.Value);
                if (nested is not null)
                    return nested;
            }
        }
        else if (element.ValueKind == JsonValueKind.Array)
        {
            foreach (var item in element.EnumerateArray())
            {
                var nested = ExtractCodeRecursive(item);
                if (nested is not null)
                    return nested;
            }
        }

        return null;
    }
}
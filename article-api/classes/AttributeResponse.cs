using System.Text.Json.Serialization;
public class ArticleAttribute
{
    [JsonPropertyName("key")]
    public string Key { get; set; }

    [JsonPropertyName("source")]
    public string Source { get; set; }

    [JsonPropertyName("value")]
    public string Value { get; set; }

    [JsonPropertyName("label")]
    public string Label { get; set; }

    [JsonPropertyName("language")]
    public string Language { get; set; }

    public ArticleAttribute(string key, string source, string value, string label, string language)
    {
        Key = key;
        Source = source;
        Value = value;
        Label = label;
        Language = language;
    }
}
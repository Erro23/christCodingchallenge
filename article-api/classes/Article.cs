using System.Text.Json.Serialization;
public class Article
{
    [JsonPropertyName("articleId")]
    public string ArticleId { get; set; }

    [JsonPropertyName("attributes")]
    public ArticleAttribute[] ArticleAttributes { get; set; }

    public Article() { }
}
using System.Text.Json.Serialization;
public class ArticleItem
{
    public string ArticleId { get; set; }

    public string ArticleKey { get; set; }
    public string Source { get; set; }
    public string ArticleValue { get; set; }
    public string Label { get; set; }
    public string Language { get; set; }
    public ArticleItem() { }
}
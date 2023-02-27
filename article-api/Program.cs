using System.Text.Json;
using Dapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using MySql.Data.MySqlClient;

namespace MyApi
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            await GetArticlesAsync();
            await CreateHostBuilder(args).Build().RunAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseUrls("http://localhost:5000");
                    webBuilder.UseStartup<Startup>();
                });

        private static async Task GetArticlesAsync()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://christ-coding-challenge.test.pub.k8s.christ.de/");
            HttpResponseMessage response = await client.GetAsync("Article/GetArticles");
            if (!response.IsSuccessStatusCode)
            {
                return;
            }
            string[] relevantArticleAttributeKeys = { "MRK", "MAT", "MAT2", "MAT3", "LEG", "LEG2", "LEG3", "KOLL", "WRG_2", "WHG_2", "ZIEL" };
            string responseContentJson = await response.Content.ReadAsStringAsync();
            Article[] articlesResponse = JsonSerializer.Deserialize<Article[]>(responseContentJson);
            Article[] articles = articlesResponse.Select(articleResponse =>
            {
                ArticleAttribute[] attributes = articleResponse.ArticleAttributes
                .Where(attribute => relevantArticleAttributeKeys.Contains(attribute.Key))
                .ToArray();

                return new Article
                {
                    ArticleId = articleResponse.ArticleId,
                    ArticleAttributes = attributes
                };
            }).ToArray();

            string connectionString = "server=127.0.0.1;database=article;user=root;password=pp";
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string deleteQuery = "DELETE FROM articles";
                connection.Execute(deleteQuery);

                string insertQuery = @"INSERT INTO articles (articleId, articleKey, source, articleValue, label, language) 
                VALUES (@articleId, @articleKey, @source, @articleValue, @label, @language)";

                // connection.Execute(
                //     insertQuery,
                //     new { articleId = "111", articleKey = "222", source = "333", articleValue = "444", label = "555", language = "666" }
                // );

                foreach (Article article in articles)
                {
                    foreach (ArticleAttribute attribute in article.ArticleAttributes)
                    {
                        connection.Execute(insertQuery,
                        new
                        {
                            articleId = article.ArticleId,
                            articleKey = attribute.Key,
                            source = attribute.Source,
                            articleValue = attribute.Value,
                            label = attribute.Label,
                            language = attribute.Language
                        });
                    }
                }
            }
        }
    }
}

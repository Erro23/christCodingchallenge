using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using Dapper;
using Microsoft.AspNetCore.Cors;

namespace MyApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [EnableCors("ArticlePolicy")]
    public class ArticlesController : ControllerBase
    {
        [HttpGet]
        public ArticleItem[] Get()
        {
            string connectionString = "server=127.0.0.1;database=article;user=root;password=pp";
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string selectQuery = "select * from articles";
                ArticleItem[] allArticles = connection.Query<ArticleItem>(selectQuery).ToArray();
                return allArticles;
            }
        }
    }
}
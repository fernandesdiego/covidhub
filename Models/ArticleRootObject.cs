using System.Text.Json;
using System.Text.Json.Serialization;

namespace HNEWS.Models
{
    public class ArticleRootObject
    {
        [JsonPropertyName("articles")]
        public Article[] Article { get; set; }
    }
}
using System;
using System.Text.Json.Serialization;


namespace HNEWS.Models
{
    public class Article
    {   
        [JsonPropertyName("_id")]
        public string Id { get; set; }
        [JsonPropertyName("_score")]
        public double Score { get; set; }
        [JsonPropertyName("summary")]
        public string Summary { get; set; }
        [JsonPropertyName("country")]
        public string Country { get; set; }
        [JsonPropertyName("author")]
        public string Author { get; set; }
        [JsonPropertyName("link")]
        public string Link { get; set; }
        [JsonPropertyName("language")]
        public string Language { get; set; }
        [JsonPropertyName("media")]
        public string Media { get; set; }
        [JsonPropertyName("title")]
        public string Title { get; set; }
        [JsonPropertyName("media_content")]
        public string MediaContent { get; set; }
        [JsonPropertyName("clean_url")]
        public string CleanURL { get; set; }
        [JsonPropertyName("rights")]
        public string Rights { get; set; }
        [JsonPropertyName("rank")]
        public string Rank { get; set; }
        [JsonPropertyName("topic")]
        public string Topic { get; set; }
        [JsonPropertyName("published_date")]
        public string PublishedDateTime { get; set; }

        public string PublishedDateNormalized
        {
             get
             {
                 return DateTime.Parse(PublishedDateTime).ToString("dd/MM/yyyy");
             }
        }

        public string Cover
        {
            get
            {
                return Media != null ? Media : "./img/not-found.jpg";
            }
        }

    }
}
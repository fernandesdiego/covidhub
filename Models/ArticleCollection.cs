using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace HNEWS.Models
{
    public class ArticleCollection
    {        
        public IList<Article> TopRanked { get; set; }
        public IList<Article> Recent { get; set; }
        public IList<Article> Relevant { get; set; }
    }
}
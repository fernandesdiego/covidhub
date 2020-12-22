using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using HNEWS.Models;
using Microsoft.Extensions.Configuration;

namespace HNEWS.Data
{
    class ArticleRepository : IArticleRepository
    {
        private static string baseUrl = "https://covid-19-news.p.rapidapi.com/v1/covid?";
        private static string apiKey = "94a1cd9be3msh7ff8e0c18de8068p175de7jsn63d54ff5fffc";

        public ArticleRepository()
        {

        }
        public async Task<ArticleCollection> GetArticleAsync()
        {
            var col = new ArticleCollection(){
                TopRanked = await GetTopRanked(),
                Relevant = await GetRelevant(),
                Recent = await GetRecent()
            };
            
            return col;
        }        

        public async Task<IList<Article>> GetTopRanked()
        {
            var articleJs = await GetStringAsync(baseUrl+"q=covid&lang=pt&media=True&page_size=5&sort_by=rank");
            return JsonSerializer.Deserialize<ArticleRootObject>(articleJs).Article;
        }

        public async Task<IList<Article>> GetRecent()
        {
            var articleJs = await GetStringAsync(baseUrl+"q=covid&lang=pt&media=True&page_size=5&sort_by=date");
            return JsonSerializer.Deserialize<ArticleRootObject>(articleJs).Article;
        }

        public async Task<IList<Article>> GetRelevant()
        {
            var articleJs = await GetStringAsync(baseUrl+"q=covid&lang=pt&media=True&page_size=10&sort_by=relevancy");
            return JsonSerializer.Deserialize<ArticleRootObject>(articleJs).Article;
        }    

        private static async Task<string> GetStringAsync(string url)
        {
            using (var client = new HttpClient())
            {
                var request = new HttpRequestMessage()
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri(url),
                    Headers = {{ "x-rapidapi-key", apiKey }}                    
                };
                
                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    return await response.Content.ReadAsStringAsync();
                }
            }
        }

    }
}
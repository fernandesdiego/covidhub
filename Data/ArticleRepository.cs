using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using HNEWS.Models;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Http;

namespace HNEWS.Data
{
    class ArticleRepository : IArticleRepository
    {
        private static string _baseUrl = "https://covid-19-news.p.rapidapi.com/v1/covid?";
        private static string _apiKey = "94a1cd9be3msh7ff8e0c18de8068p175de7jsn63d54ff5fffc";                
                
        public async Task<ArticleCollection> GetArticleAsync(string lang)
        {
            var col = new ArticleCollection(){
                TopRanked = await GetTopRanked(lang),
                Relevant = await GetRelevant(lang),
                Recent = await GetRecent(lang)
            };
            
            return col;
        }        

        public async Task<IList<Article>> GetTopRanked(string lang)
        {
            var articleJs = await GetStringAsync(_baseUrl+$"q=covid&lang={lang}&media=True&page_size=5&sort_by=rank");
            return JsonSerializer.Deserialize<ArticleRootObject>(articleJs).Article;
        }

        public async Task<IList<Article>> GetRecent(string lang)
        {
            var articleJs = await GetStringAsync(_baseUrl+$"q=covid&lang={lang}&media=True&page_size=5&sort_by=date");
            return JsonSerializer.Deserialize<ArticleRootObject>(articleJs).Article;
        }

        public async Task<IList<Article>> GetRelevant(string lang)
        {
            var articleJs = await GetStringAsync(_baseUrl+$"q=covid&lang={lang}&media=True&page_size=10&sort_by=relevancy");
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
                    Headers = {{ "x-rapidapi-key", _apiKey }}                    
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
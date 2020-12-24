using System.Collections.Generic;
using System.Threading.Tasks;
using HNEWS.Models;

namespace HNEWS.Data
{
    public interface IArticleRepository
    {
        Task<ArticleCollection> GetArticleAsync(string lang);
        Task<IList<Article>> GetTopRanked(string lang);        
        Task<IList<Article>> GetRecent(string lang);
        Task<IList<Article>> GetRelevant(string lang);
        
            
    }
}
using System.Collections.Generic;
using System.Threading.Tasks;
using HNEWS.Models;

namespace HNEWS.Data
{
    public interface IArticleRepository
    {
        Task<ArticleCollection> GetArticleAsync();
        Task<IList<Article>> GetTopRanked();        
        Task<IList<Article>> GetRecent();
        Task<IList<Article>> GetRelevant();
        
            
    }
}
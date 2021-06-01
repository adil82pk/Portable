
namespace RepositoryLayer.Interface
{
    using RepositoryLayer.Context;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IPinArticleRepository
    {
        Task PinArticles(List<PinArticle> articleDTOs);
    }
}

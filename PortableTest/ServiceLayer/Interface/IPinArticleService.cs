namespace ServiceLayer.Interface
{
    using ServiceLayer.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IPinArticleService
    {
        Task PinArticle(int userId, List<PinArticleDTO> articleDTOs);
    }
}

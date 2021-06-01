namespace RepositoryLayer.Class
{
    using RepositoryLayer.Context;
    using RepositoryLayer.Interface;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Linq;

    public class PinArticleRepository : IPinArticleRepository
    {
        private readonly NewsSiteDbContext newsSiteDbContext;

        public PinArticleRepository(NewsSiteDbContext newsSiteDbContext)
        {
            this.newsSiteDbContext = newsSiteDbContext;
        }

        public async Task PinArticles(List<PinArticle> articleDTOs)
        {
            if (articleDTOs.Count() > 0)
            {
                var userId = articleDTOs.First().UserId;
                foreach (var entity in this.newsSiteDbContext.PinArticles.Where(x => x.UserId == userId))
                {
                    this.newsSiteDbContext.PinArticles.Remove(entity);
                }

                foreach (var article in articleDTOs)
                {
                    await this.newsSiteDbContext.AddAsync(article);
                }

                await this.newsSiteDbContext.SaveChangesAsync();
            }
        }
    }
}
namespace Blog.Services.Data
{
    using Blog.Web.ViewModels.Genre;
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IGenreService
    {
        Task<ICollection<ListGenreArticleAddViewModel>> GetAllAsync();
    }
}

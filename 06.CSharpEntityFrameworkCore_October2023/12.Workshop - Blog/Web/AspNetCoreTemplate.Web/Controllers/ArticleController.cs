namespace Blog.Web.Controllers
{
    using Blog.Services.Data;
    using Blog.Web.ViewModels.Article;
    using Blog.Web.ViewModels.Genre;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class ArticleController : Controller
    {
        private readonly IGenreService genereService;

        public ArticleController(IGenreService genereService)
        {
            this.genereService = genereService;
        }

        public async Task<IActionResult> Add()
        {
            ICollection<ListGenreArticleAddViewModel> genres =
                await this.genereService.GetAllAsync();

            ArticleAddViewModel vm = new ArticleAddViewModel()
            {
                Genres = genres
            };

            return View(vm);
        }
    }
}

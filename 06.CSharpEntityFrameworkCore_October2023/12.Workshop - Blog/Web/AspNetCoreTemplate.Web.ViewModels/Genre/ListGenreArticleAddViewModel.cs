namespace Blog.Web.ViewModels.Genre
{
    using Blog.Services.Mapping;
    using Blog.Data.Models;
    public class ListGenreArticleAddViewModel : IMapFrom<Genre>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}

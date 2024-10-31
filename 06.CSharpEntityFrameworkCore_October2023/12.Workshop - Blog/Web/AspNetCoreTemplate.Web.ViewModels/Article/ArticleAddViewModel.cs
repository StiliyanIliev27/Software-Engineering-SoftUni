namespace Blog.Web.ViewModels.Article
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Blog.Common.Validation;
    using Blog.Web.ViewModels.Genre;

    public class ArticleAddViewModel
    {
        public ArticleAddViewModel()
        {
            this.Genres = new HashSet<ListGenreArticleAddViewModel>();
        }

        [Required]
        [MinLength(ArticleAddValidationConstants.TitleMinLength)]
        [MaxLength(ArticleAddValidationConstants.TitleMaxLength)]
        public string Title { get; set; } = null!;

        [Required]
        [MinLength(ArticleAddValidationConstants.ContentMinLength)]
        [MaxLength(ArticleAddValidationConstants.ContentMaxLength)]
        public string Content { get; set; } = null!;

        public int GenreId { get; set; } //Selected Genre

        public ICollection<ListGenreArticleAddViewModel> Genres { get; set; }
    }
}

namespace Blog.Data.Models
{
    using Blog.Data.Common.Validation;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Article
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(ArticleValidationConstants.TitleMaxLength)]
        public string Title { get; set; } = null!;

        [Required]
        [MaxLength(ArticleValidationConstants.ContentMaxLength)]
        public string Content { get; set; } = null!;

        [Required]
        public DateTime CreatedOn { get; set; }

        [Required]
        [ForeignKey(nameof(AuthorId))]
        public string AuthorId { get; set; } = null!;

        public virtual ApplicationUser Author { get; set; }

        [Required]
        [ForeignKey(nameof(GenreId))]
        public int GenreId { get; set; }

        public virtual Genre Genre { get; set; }
    }
}

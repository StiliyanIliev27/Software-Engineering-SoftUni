using Blog.Data.Common.Validation;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Blog.Data.Models
{
    public class ApplicationUser
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid().ToString();

            this.Articles = new HashSet<Article>();
        }

        [Key]
        public string Id { get; set; } = null!;

        [Required]
        [MaxLength(ApplicationUserValidationConstants.UsenameMaxLength)]
        public string Username { get; set; } = null!;

        [Required]
        [MaxLength(ApplicationUserValidationConstants.EmailMaxLength)]
        public string Email { get; set; } = null!;

        [Required]
        [MaxLength(ApplicationUserValidationConstants.PasswordMaxLength)]
        public string Password { get; set; } = null!;

        [Required]
        [MaxLength(ApplicationUserValidationConstants.PasswordSaltMaxLength)]
        public string PasswordSalt { get; set; } = null!;

        public virtual ICollection<Article> Articles { get; set; }
    }
}

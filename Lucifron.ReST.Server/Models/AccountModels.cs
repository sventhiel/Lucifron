using System.ComponentModel.DataAnnotations;

namespace Lucifron.ReST.Server.Models
{
    public class SignInModel
    {
        [Required]
        [Display(Name = "Token")]
        public string Token { get; set; }
    }
}
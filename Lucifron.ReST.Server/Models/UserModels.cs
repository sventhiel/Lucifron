using Lucifron.ReST.Server.Entities;
using System.ComponentModel.DataAnnotations;

namespace Lucifron.ReST.Server.Models
{
    public class ReadUserModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Prefix { get; set; }
        public string Pattern { get; set; }
        public string IPv4 { get; set; }
        public string Token { get; set; }
        public long CredentialId { get; set; }

        public static ReadUserModel Convert(User user)
        {
            return new ReadUserModel()
            {
                Id = user.Id,
                Name = user.Name,
                Prefix = user.Prefix,
                Pattern = user.Pattern,
                IPv4 = user.IPv4,
                Token = user.Token,
                CredentialId = user.Credential.Id
            };
        }
    }

    public class CreateUserModel
    {
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Prefix")]
        public string Prefix { get; set; }

        [Required]
        [Display(Name = "Pattern")]
        public string Pattern { get; set; }

        [Required]
        [Display(Name = "IPv4")]
        public string IPv4 { get; set; }

        [Required]
        [Display(Name = "CredentialId")]
        public long CredentialId { get; set; }
    }
}
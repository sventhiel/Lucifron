using Lucifron.ReST.Server.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lucifron.ReST.Server.Models
{
    public class ReadCredentialModel
    {
        public string Host { get; set; }
        public string User { get; set; }
        public string Password { get; set; }

        public static ReadCredentialModel Convert(Credential credential)
        {
            return new ReadCredentialModel()
            {
                Host = credential.Host,
                User = credential.User,
                Password = credential.Password
            };
        }
    }

    public class CreateCredentialModel
    {
        [Required]
        [Display(Name = "Host")]
        public string Host { get; set; }

        [Required]
        [Display(Name = "User")]
        public string User { get; set; }

        [Required]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}
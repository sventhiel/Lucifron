using Lucifron.ReST.Server.Entities;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Lucifron.ReST.Server.Models
{
    public class PlaceholdersModel
    {
        [JsonProperty("placeholders")]
        public Dictionary<string, string> Placeholders { get; set; }
    }

    public class ReadPlaceholderModel
    {
        public long Id { get; set; }
        public string Expression { get; set; }
        public string RegularExpression { get; set; }
        public long UserId { get; set; }
        public string UserName { get; set; }

        public static ReadPlaceholderModel Convert(Placeholder placeholder)
        {
            return new ReadPlaceholderModel()
            {
                Id = placeholder.Id,
                Expression = placeholder.Expression,
                RegularExpression = placeholder.RegularExpression,
                UserId = placeholder.User.Id,
                UserName = placeholder.User.Name
            };
        }
    }

    public class CreatePlaceholderModel
    {
        [Required]
        [Display(Name = "Expression")]
        public string Expression { get; set; }

        [Required]
        [Display(Name = "RegularExpression")]
        public string RegularExpression { get; set; }

        [Required]
        [Display(Name = "UserId")]
        public long UserId { get; set; }
    }
}
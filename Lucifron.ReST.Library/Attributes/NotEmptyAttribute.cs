using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lucifron.ReST.Library.Attributes
{
    public class NotEmptyAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            // if not type of collection
            // return false

            var col = value as ICollection;

            return col.Count > 0;
        }
    }
}

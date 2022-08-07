using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace Lucifron.ReST.Library.Attributes
{
    public class NotEmptyAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value.GetType() == typeof(ICollection))
            {
                var collection = (ICollection)value;
                return collection.Count > 0;
            }

            return false;
        }
    }
}
using Lucifron.ReST.Library.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lucifron.ReST.Library.Enumerations
{
    public enum Placeholder
    {
        [PlaceholderValue("{DatasetId}")]
        DatasetId,
        [PlaceholderValue("{VersionId}")]
        VersionId,
        [PlaceholderValue("{Version}")]
        Version
    }
}

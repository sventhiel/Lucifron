using Lucifron.ReST.Library.Attributes;

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
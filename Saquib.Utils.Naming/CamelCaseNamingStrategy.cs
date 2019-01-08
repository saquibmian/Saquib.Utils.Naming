using System.Linq;

namespace Saquib.Utils.Naming {
    /// <summary>
    /// Converts a name using camel-casing rules.
    /// </summary>
    /// <remarks>
    /// For example, `last_modified_to` is converted to `lastModifiedTo`.
    /// </remarks>
    public sealed class CamelCaseNamingStrategy : NamingStrategy {
        public override string Apply( string name ) {
            var parts = SplitNames( name )
                .Select( ( part, i ) => i == 0 ? part : Capitalize( part ) )
                .ToArray();
            return string.Join( "", parts );
        }
    }
}
using System.Linq;

namespace Saquib.Utils.Naming {
    /// <summary>
    /// Converts a name using Pascal-casing rules.
    /// </summary>
    /// <remarks>
    /// For example, `last_modified_to` is converted to `LastModifiedTo`.
    /// </remarks>
    public sealed class PascalCaseNamingStrategy : NamingStrategy {
        public override string Apply( string name ) {
            var parts = SplitNames( name )
                .Select( Capitalize )
                .ToArray();
            return string.Join( "", parts );
        }
    }
}
using System.Linq;

namespace Saquib.Utils.Naming {
    /// <summary>
    /// Converts a name using Train-casing rules.
    /// </summary>
    /// <remarks>
    /// For example, `lastModifiedTo` is converted to `Last-Modified-To`.
    /// </remarks>
    public sealed class TrainCaseNamingStrategy : NamingStrategy {
        public override string Apply( string name ) {
            var upper = SplitNames( name )
                .Select( Capitalize )
                .ToArray();
            return string.Join( "-", upper );
        }
    }
}
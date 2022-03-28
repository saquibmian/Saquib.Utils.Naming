using System.Linq;

namespace Saquib.Utils.Naming {
    /// <summary>
    /// Converts a name using Sentence-casing rules.
    /// </summary>
    /// <remarks>
    /// For example, `lastModifiedTo` is converted to `Last modified to`.
    /// </remarks>
    public sealed class SentenceCaseNamingStrategy : NamingStrategy {
        public bool PreserveCase { get; init; }
        public override string Apply( string name ) {
            var upper = SplitNames( name, PreserveCase )
                .Select( ( str, i ) => i == 0 ? Capitalize( str ) : str )
                .ToArray();
            return string.Join( " ", upper );
        }
    }
}

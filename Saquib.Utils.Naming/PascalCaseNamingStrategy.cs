using System.Linq;

namespace Saquib.Utils.Naming {
    public sealed class PascalCaseNamingStrategy : NamingStrategy {
        public override string Apply( string name ) {
            var parts = SplitNames( name )
                .Select( Capitalize )
                .ToArray();
            return string.Join( "", parts );
        }
    }
}
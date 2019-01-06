using System.Linq;

namespace Saquib.Utils.Naming {
    public sealed class CamelCaseNamingStrategy : NamingStrategy {
        public override string Apply( string name ) {
            var parts = SplitNames( name )
                .Select( ( part, i ) => i == 0 ? part : Capitalize( part ) )
                .ToArray();
            return string.Join( "", parts );
        }
    }
}
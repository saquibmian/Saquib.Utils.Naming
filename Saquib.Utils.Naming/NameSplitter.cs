using System.Collections.Generic;
using System.Linq;

namespace Saquib.Utils.Naming {
    internal static class NameSplitter {
        private static readonly char[] SPLIT_CHARS = new[] { '_', '-' };

        /// <summary>
        /// Splits a name into logical parts, lowercasing them.
        /// </summary>
        public static string[] Split( string name ) {
            return SplitInternal( name ).ToArray();
        }

        private static IEnumerable<string> SplitInternal( string name ) {
            foreach ( var separated in SplitBySeparators( name ) ) {
                foreach ( var part in SplitByCapitalization( separated ) ) {
                    yield return part.ToLower();
                }
            }
        }

        private static IEnumerable<string> SplitBySeparators( string name ) {
            return name.Split( SPLIT_CHARS );
        }

        private static IEnumerable<string> SplitByCapitalization( string name ) {
            int start = 0;
            for ( int i = 1; i < name.Length; ++i ) {
                if ( char.IsUpper( name[i - 1] ) && char.IsUpper( name[i] ) ) {
                    // we went from 'A' to 'A', treat this as a part
                    yield return name.Substring( start, i - start );
                    start = i;
                } else if ( !char.IsUpper( name[i - 1] ) && char.IsUpper( name[i] ) ) {
                    // we went from 'a' to 'A', treat this as a part
                    yield return name.Substring( start, i - start );
                    start = i;
                }
            }
            yield return name.Substring( start );
        }
    }
}
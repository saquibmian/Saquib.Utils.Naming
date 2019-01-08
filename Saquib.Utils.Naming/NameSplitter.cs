using System;
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
            return SplitBySeparators( name )
                .SelectMany( SplitByAlphanumericMixing )
                .SelectMany( SplitByCapitalization )
                .Select( part => part.ToLower() );
        }

        private static IEnumerable<string> SplitBySeparators( string name ) {
            return name.Split( SPLIT_CHARS );
        }

        private static IEnumerable<string> SplitByAlphanumericMixing( string name ) {
            return ConditionalSplit( name, ( previous, current ) => {
                return (
                    // we went from '1' to 'A', treat this as a part
                    char.IsNumber( previous ) && char.IsLetter( current )
                ) || (
                    // we went from 'A' to '1', treat this as a part
                    char.IsLetter( previous ) && char.IsNumber( current )
                );
            } );
        }

        private static IEnumerable<string> SplitByCapitalization( string name ) {
            return ConditionalSplit( name, ( previous, current ) => {
                return (
                    // we went from 'A' to 'A', treat this as a part
                    char.IsUpper( previous ) && char.IsUpper( current )
                ) || (
                    // we went from 'a' to 'A', treat this as a part
                    !char.IsUpper( previous ) && char.IsUpper( current )
                );
            } );
        }

        private static IEnumerable<string> ConditionalSplit( string name, Func<char, char, bool> shouldSplit ) {
            int start = 0;
            for ( int i = 1; i < name.Length; ++i ) {
                var (previous, current) = (name[i - 1], name[i]);
                if ( shouldSplit( previous, current ) ) {
                    yield return name.Substring( start, i - start );
                    start = i;
                }
            }
            yield return name.Substring( start );
        }
    }
}
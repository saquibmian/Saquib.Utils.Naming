using System;
using System.Collections.Generic;
using System.Linq;

namespace Saquib.Utils.Naming {
    internal static class NameSplitter {
        private static readonly char[] SPLIT_CHARS = new[] { '_', '-' };

        /// <summary>
        /// Splits a name into logical parts, lowercasing them.
        /// </summary>
        public static string[] Split( string name, bool preserveCase = false ) {
            return SplitInternal( name, preserveCase ).ToArray();
        }

        private static IEnumerable<string> SplitInternal( ReadOnlySpan<char> name, bool preserveCase ) {
            var ranges = ConditionalSplit( name, ( previous, current ) => {
                return (
                   // we went from '1' to 'A', treat this as a part
                   char.IsNumber( previous ) && char.IsLetter( current )
                ) || (
                   // we went from 'A' to '1', treat this as a part
                   char.IsLetter( previous ) && char.IsNumber( current )
                ) || (
                   // we went from 'a' to 'A', treat this as a part
                   !char.IsUpper( previous ) && char.IsUpper( current )
                );
            } );
            var parts = new List<string>( ranges.Count );
            foreach (var range in ranges) {
                var part = name[range].ToString();
                parts.Add( preserveCase ? part : part.ToLower() );
            }
            return parts;
        }

        private static List<Range> ConditionalSplit( ReadOnlySpan<char> name, Func<char, char, bool> shouldSplit ) {
            var ranges = new List<Range>();

            var start = 0;
            for (var i = 1; i < name.Length; ++i) {
                var (previous, current) = (name[i - 1], name[i]);
                if (SPLIT_CHARS.Contains( previous )) {
                    if (i == start) {
                        ++start;
                    } else {
                        ranges.Add( new Range( start, i - 1 ) );
                        start = i;
                    }
                    continue;
                }
                if (shouldSplit( previous, current )) {
                    ranges.Add( new Range( start, i ) );
                    start = i;
                }
            }
            ranges.Add( new Range( start, name.Length ) );

            return ranges;
        }
    }
}

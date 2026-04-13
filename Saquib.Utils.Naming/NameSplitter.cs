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
            var ranges = SplitIntoRanges( name );
            var parts = new List<string>( ranges.Count );
            foreach (var range in ranges) {
                var part = name[range].ToString();
                parts.Add( preserveCase ? part : part.ToLower() );
            }
            return parts;
        }

        private static List<Range> SplitIntoRanges( ReadOnlySpan<char> name ) {
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
                // we went from '1' to 'A' or 'A' to '1', treat this as a part
                if ((char.IsNumber( previous ) && char.IsLetter( current )) || (char.IsLetter( previous ) && char.IsNumber( current ))) {
                    ranges.Add( new Range( start, i ) );
                    start = i;
                    continue;
                }
                // we went from 'a' to 'A', treat this as a part
                if (!char.IsUpper( previous ) && char.IsUpper( current )) {
                    ranges.Add( new Range( start, i ) );
                    start = i;
                    continue;
                }
                // we went from an acronym like "URL" into a new word like "Options":
                // split before the last uppercase letter so that "URL" and "Options" are separate parts
                if (char.IsUpper( previous ) && char.IsLower( current ) && i - 1 > start) {
                    ranges.Add( new Range( start, i - 1 ) );
                    start = i - 1;
                }
            }
            ranges.Add( new Range( start, name.Length ) );

            return ranges;
        }
    }
}

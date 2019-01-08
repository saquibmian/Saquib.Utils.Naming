using Xunit;

namespace Saquib.Utils.Naming {
    public sealed class NameSplitterTests {

        [Theory]
        [InlineData( "lastModifiedDate" )]
        [InlineData( "LastModifiedDate" )]
        [InlineData( "last-modified-date" )]
        [InlineData( "last_modified_date" )]
        public void Split__SimpleNames( string input ) {
            var expected = new[] { "last", "modified", "date" };

            var parts = NameSplitter.Split( input );

            Assert.Equal( expected, parts );
        }

        [Theory]
        [InlineData( "last222modifiedDates" )]
        [InlineData( "last222ModifiedDates" )]
        [InlineData( "Last222ModifiedDates" )]
        [InlineData( "last-222-modified-dates" )]
        [InlineData( "last_222_modified_dates" )]
        public void Split__WithNumbers( string input ) {
            var expected = new[] { "last", "222", "modified", "dates" };

            var parts = NameSplitter.Split( input );

            Assert.Equal( expected, parts );
        }

    }
}
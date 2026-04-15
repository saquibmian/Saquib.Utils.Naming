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
        [InlineData( "Last-222-Modified-Dates" )]
        public void Split__WithNumbers( string input ) {
            var expected = new[] { "last", "222", "modified", "dates" };

            var parts = NameSplitter.Split( input );

            Assert.Equal( expected, parts );
        }

        [Fact]
        public void Split__StandaloneAcronym() {
            var expected = new[] { "url" };

            var parts = NameSplitter.Split( "URL" );

            Assert.Equal( expected, parts );
        }

        [Fact]
        public void Split__AcronymFollowedByWord() {
            var expected = new[] { "url", "options" };

            var parts = NameSplitter.Split( "URLOptions" );

            Assert.Equal( expected, parts );
        }

        [Fact]
        public void Split__WordFollowedByAcronym() {
            var expected = new[] { "my", "url" };

            var parts = NameSplitter.Split( "myURL" );

            Assert.Equal( expected, parts );
        }

        [Fact]
        public void Split__WordAcronymWord() {
            var expected = new[] { "my", "url", "options" };

            var parts = NameSplitter.Split( "myURLOptions" );

            Assert.Equal( expected, parts );
        }

    }
}

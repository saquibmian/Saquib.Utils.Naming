using Xunit;

namespace Saquib.Utils.Naming {
    public sealed class NameSplitterTests {

        [Theory]
        [InlineData( "lastModifiedDate" )]
        [InlineData( "LastModifiedDate" )]
        [InlineData( "last-modified-date" )]
        [InlineData( "last_modified_date" )]
        public void Split( string input ) {
            var expected = new[] { "last", "modified", "date" };

            var parts = NameSplitter.Split( input );

            Assert.Equal( expected, parts );
        }

    }
}
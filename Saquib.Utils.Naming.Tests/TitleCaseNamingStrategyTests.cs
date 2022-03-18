using Xunit;

namespace Saquib.Utils.Naming {
    public sealed class TitleCaseNamingStrategyTests {
        private readonly TitleCaseNamingStrategy _strategy = new TitleCaseNamingStrategy();

        [Theory]
        [InlineData( "last22modifiedDate" )]
        [InlineData( "last22ModifiedDate" )]
        [InlineData( "Last22ModifiedDate" )]
        [InlineData( "last-22-modified-date" )]
        [InlineData( "Last-22-Modified-Date" )]
        [InlineData( "last_22_modified_date" )]
        public void Apply( string input ) {
            var expected = "Last 22 Modified Date";

            var actual = _strategy.Apply( input );

            Assert.Equal( expected, actual );
        }
    }
}

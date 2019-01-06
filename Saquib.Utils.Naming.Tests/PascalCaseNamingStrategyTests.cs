using Xunit;

namespace Saquib.Utils.Naming {
    public sealed class PascalCaseNamingStrategyTests {
        private readonly PascalCaseNamingStrategy _strategy = new PascalCaseNamingStrategy();

        [Theory]
        [InlineData( "lastModifiedDate" )]
        [InlineData( "LastModifiedDate" )]
        [InlineData( "last-modified-date" )]
        [InlineData( "last_modified_date" )]
        public void Apply( string input ) {
            var expected = "LastModifiedDate";

            var actual = _strategy.Apply( input );

            Assert.Equal( expected, actual );
        }
    }
}
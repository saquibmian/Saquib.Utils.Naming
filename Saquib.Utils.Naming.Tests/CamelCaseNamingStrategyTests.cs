using Xunit;

namespace Saquib.Utils.Naming {
    public sealed class CamelCaseNamingStrategyTests {
        private readonly CamelCaseNamingStrategy _strategy = new CamelCaseNamingStrategy();

        [Theory]
        [InlineData( "lastModifiedDate" )]
        [InlineData( "LastModifiedDate" )]
        [InlineData( "last-modified-date" )]
        [InlineData( "last_modified_date" )]
        public void Apply( string input ) {
            var expected = "lastModifiedDate";

            var actual = _strategy.Apply( input );

            Assert.Equal( expected, actual );
        }
    }
}
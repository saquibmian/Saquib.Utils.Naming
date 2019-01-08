using Xunit;

namespace Saquib.Utils.Naming {
    public sealed class CamelCaseNamingStrategyTests {
        private readonly CamelCaseNamingStrategy _strategy = new CamelCaseNamingStrategy();

        [Theory]
        [InlineData( "last22modifiedDate" )]
        [InlineData( "last22ModifiedDate" )]
        [InlineData( "Last22ModifiedDate" )]
        [InlineData( "last-22-modified-date" )]
        [InlineData( "last_22_modified_date" )]
        public void Apply( string input ) {
            var expected = "last22ModifiedDate";

            var actual = _strategy.Apply( input );

            Assert.Equal( expected, actual );
        }
    }
}
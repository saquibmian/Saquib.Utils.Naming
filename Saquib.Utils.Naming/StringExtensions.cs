namespace Saquib.Utils.Naming {
    public static class CaseConversionStringExtensions {
        private static readonly NamingStrategy _camelCase = new CachedNamingStrategy( new CamelCaseNamingStrategy() );
        private static readonly NamingStrategy _pascalCase = new CachedNamingStrategy( new PascalCaseNamingStrategy() );
        private static readonly NamingStrategy _kebabCase = new CachedNamingStrategy( new KebabCaseNamingStrategy() );
        private static readonly NamingStrategy _snakeCase = new CachedNamingStrategy( new SnakeCaseNamingStrategy() );
        private static readonly NamingStrategy _trainCase = new CachedNamingStrategy( new TrainCaseNamingStrategy() );

        public static string ToCamelCase( this string name ) => _camelCase.Apply( name );
        public static string ToPascalCase( this string name ) => _pascalCase.Apply( name );
        public static string ToKebabCase( this string name ) => _kebabCase.Apply( name );
        public static string ToSnakeCase( this string name ) => _snakeCase.Apply( name );
        public static string ToTrainCase( this string name ) => _trainCase.Apply( name );
    }
}
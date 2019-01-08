namespace Saquib.Utils.Naming {
    /// <summary>
    /// Converts a name using kebab-casing rules.
    /// </summary>
    /// <remarks>
    /// For example, `lastModifiedTo` is converted to `last-modified-to`.
    /// </remarks>
    public sealed class KebabCaseNamingStrategy : NamingStrategy {
        public override string Apply( string name ) {
            return string.Join( "-", SplitNames( name ) );
        }
    }
}
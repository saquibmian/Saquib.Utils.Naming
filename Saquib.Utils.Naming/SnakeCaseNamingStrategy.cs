namespace Saquib.Utils.Naming {
    /// <summary>
    /// Converts a name using snake-casing rules.
    /// </summary>
    /// <remarks>
    /// For example, `lastModifiedTo` is converted to `last_modified_to`.
    /// </remarks>
    public sealed class SnakeCaseNamingStrategy : NamingStrategy {
        public override string Apply( string name ) {
            return string.Join( "_", SplitNames( name ) );
        }
    }
}
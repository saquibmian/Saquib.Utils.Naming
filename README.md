# Saquib.Utils.Naming

Contains a set of strategies for altering names to a casing style. Currently supported strategies include:

- camelCase
- PascalCase
- snake_case
- kebab-case
- Train-Case

## Usage

Usage is as follows:

```csharp
var strategy = new PascalCaseNamingStrategy();
var canonicalName = strategy.Apply( "last_modified_date" );
Assert.Equal( "LastModifiedDate", canonicalName );
```

You can also use the convenience extension methods, but you will not be able to configure the applied strategies (default options are used_). The convenience functions are memoized, so they can be called repeated on the same input with no performance penalty.

```csharp
var converted = "lastModifiedDate".ToKebabCase();
```

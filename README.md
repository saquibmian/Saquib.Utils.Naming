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

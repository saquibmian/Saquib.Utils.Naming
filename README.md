# Saquib.Utils.Naming

Contains a set of strategies for altering names. Current strategies include:

- camelCase
- PascalCase
- snake_case

The following four source naming conventions are supported:

- lastModifiedDate
- LastModifiedDate
- last-modified-date
- last_modified_date

## Usage

Usage is as follows:

```csharp
var strategy = new PascalCaseNamingStrategy();
var canonicalName = strategy.Apply( "last_modified_date" );
Assert.Equal( "LastModifiedDate", canonicalName );
```

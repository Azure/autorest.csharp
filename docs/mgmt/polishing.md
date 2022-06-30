# Management SDK polishing configurations

- [Rename Rules](#rename-rules)
- [Change Format by Name Rules](#change-format-by-name-rules)
- [Rename Mapping](#rename-mapping)

## Rename rules

A mechanism of renaming is introduced in the generator to unify the casing of some words.

```yaml
rename-rules:
  Ip: IP
  Ips: IPs
```

The above configuration will search case sensitively in the public API of generated resources/collections/models, and replace the occurrences to the corresponding value to keep the casing of some acronyms unified across the generated SDK.

## Change format by name rules

This is a bulk update rule to change property's format by its name which this name demonstrates a specific type implicitly. This is a convenient configuration to replace using directive change the property format attribute.

```yaml
format-by-name-rules:
  'ETag': 'etag'
  'location': 'azure-location'
  '*Uri': 'Uri'
  '*Uris': 'Uri'
```

The key is the name of property, and the value is the data type.

The name match supports 3 patterns: full, start-with, and end-with. And it’s case sensitive compare. 
For example, in the above configuration, the `ETag` and `location` are full match, `*Uri` and `*Uris` are end-with match.

Here is list of the format we support:
| Format | Data type |
| :--- | :--- |
| arm-id | [ResourceIdentifier](https://docs.microsoft.com/en-us/dotnet/api/azure.core.resourceidentifier?view=azure-dotnet) |
| azure-location | [AzureLocation](https://docs.microsoft.com/en-us/dotnet/api/azure.core.azurelocation?view=azure-dotnet) |
| duration-constant | [TimeSpan](https://docs.microsoft.com/en-us/dotnet/api/system.timespan) |
| etag | [ETag](https://docs.microsoft.com/en-us/dotnet/api/azure.etag?view=azure-dotnet) |
| resource-type | [ResourceType](https://docs.microsoft.com/en-us/dotnet/api/azure.core.resourcetype?view=azure-dotnet) |
| date-time | [DateTimeOffset](https://docs.microsoft.com/en-us/dotnet/api/system.datetimeoffset?view=net-6.0) |
| uri | [Uri](https://docs.microsoft.com/en-us/dotnet/api/system.uri?view=net-6.0) |
| uuid | [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid?view=net-6.0) |

## Rename mapping



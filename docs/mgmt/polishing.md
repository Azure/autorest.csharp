# Management SDK polishing configurations

- [Rename Rules](#rename-rules)
- [Change Format by Name Rules](#change-format-by-name-rules)
- [Rename Mapping](#rename-mapping)
    - [Rename a Type](#rename-a-type)
    - [Rename a Property in a Class](#rename-a-property-in-a-class)
    - [Rename an Enumeration Value in an Enumeration Type](#rename-an-enumeration-value-in-an-enumeration-type)
- [Irregular Plural Words](#irregular-plural-words)

## Rename rules

A mechanism of renaming is introduced in the generator to unify the casing of some words.

```yaml
rename-rules:
  Ip: IP
  Ips: IPs
```

The above configuration will search case sensitively in the public API of generated resources/collections/models, and replace the occurrences to the corresponding value to keep the casing of some acronyms unified across the generated SDK.

The `rename-rules` configuration also supports parameter name because in some cases the default logic to get the variable name form from a property name might be problematic. For instance, we usually could have a class like this:
```csharp
public partial class PublicIPAddress
{
    public PublicIPAddress()
    {
    }

    internal PublicIPAddress(IReadOnlyList<string> iPs)
    {
        IPs = iPs;
    }

    public IReadOnlyList<string> IPs { get; }
}
```
The default logic to create a variable name from a property name is usually lower case the first letter. But this introduces a weird combination of `iPs` in the internal constructor. To fix this, you could manually assign a variable version of the replaced key:
```yaml
rename-rules:
  Ip: IP
  Ips: IPs|ips
```
and after applying this configuration and regenerating, you should see the following differences:
```diff
public partial class PublicIPAddress
{
    public PublicIPAddress()
    {
    }

-   internal PublicIPAddress(IReadOnlyList<string> iPs)
+   internal PublicIPAddress(IReadOnlyList<string> ips)
    {
        IPs = ips;
    }

    public IReadOnlyList<string> IPs { get; }
}
```

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
| datetime | [DateTimeOffset](https://docs.microsoft.com/en-us/dotnet/api/system.datetimeoffset?view=net-6.0) |
| duration-constant | [TimeSpan](https://docs.microsoft.com/en-us/dotnet/api/system.timespan) |
| etag | [ETag](https://docs.microsoft.com/en-us/dotnet/api/azure.etag?view=azure-dotnet) |
| ip-address | [IPAddress](https://docs.microsoft.com/en-us/dotnet/api/system.net.ipaddress?view=net-6.0) |
| object | [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object?view=net-6.0) |
| resource-type | [ResourceType](https://docs.microsoft.com/en-us/dotnet/api/azure.core.resourcetype?view=azure-dotnet) |
| uri | [Uri](https://docs.microsoft.com/en-us/dotnet/api/system.uri?view=net-6.0) |
| uuid | [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid?view=net-6.0) |

## Rename mapping

To rename an element in the generated SDK, like a type name, a property name, you could do that by writing `directive`s which autorest supports. You could refer [this document](https://github.com/Azure/autorest/blob/main/docs/generate/directives.md) for more details and usages.

But this configuration provides a simpler syntax for you to change the name of a type or a property.

### Rename a type

To rename a type (models and enumerations included), you could just use this syntax:
```yaml
rename-mapping:
  OriginalName: NewName
```
where the `OriginalName` is the original name of this model in the swagger. **Please be sure the name is its original swagger name**, because our generator will dynamically change names of some models from their context and roles inside the SDK.

After applying this configuration, you will see the following changes:
```diff
-public partial class OriginalName
+public partial class NewName
{
    /* other things inside the class */
}
```

### Rename a property in a class

To rename a property in a class, you could just use this syntax:
```yaml
rename-mapping:
  Model.oldProperty: NewProperty
```
where the `Model` is the original name of this model in the **swagger**, and the `oldProperty` is its original name of this property in the **swagger**.

After applying this configuration, you will see the following changes:
```diff
public partial class Model
{
    /* other things inside the class */

-    public string OldProperty { get; set; }
+    public string NewProperty { get; set; }

    /* other things inside the class */
}
```

It is special that some properties might be "flattened" from another model into this property. When this happens, you will have to include a full path of the property to make sure that the generator could precisely locate the property. For instance, we might have this inside our swagger:
```json
"definitions": {
    "Model": {
        "type": "object",
        "properties": {
            "properties": {
                "$ref": "#definitions/ModelProperties",
                "x-ms-client-flatten": true
            }
        }
    },
    "ModelProperties": {
        "type": "object",
        "properties": {
            "flattenedProperty": {
                "type": "string"
            }
        }
    }
}
```
This piece of swagger will generate into the following code:
```csharp
public partial class Model
{
    /* constructors */
    public string FlattenedProperty { get; set; }
}
```
The model `ModelProperties` will disappear in our generated code, and the properties inside `ModelProperties` will be promoted into the owner class. In case the name of this property needs to be changed, you will have to use the following configuration:
```yaml
rename-mapping:
  Model.properties.flattenedProperty: NewFlattenedProperty
```
After applying this configuration, you will see the following changes:
```diff
public partial class Model
{
    /* constructors */
-   public string FlattenedProperty { get; set; }
+   public string NewFlattenedProperty { get; set; }
}
```

### Rename an enumeration value in an enumeration type

The generator regards the enumeration values as static properties, therefore you could use basically the same syntax as renaming a property to rename an enumeration value:
```yaml
rename-mapping:
  EnumType.enum_value: NewValue
```
where the `EnumType` is the original name of the enumeration type in the **swagger**, and `enum_value` is the original name of the enumeration value in the **swagger**. In case we have spaces or other special character, you might need to use quotes to enclosing the key in this mapping to ensure everything is good without compile errors.

## Irregular Plural Words

The generator needs to convert word into its plural form or convert it back to its singular form in some circumstances. Our generator uses the [Humanizer](https://humanizr.net/) to do that. It has a dictionary of irregular words and if a word is not in the dictionary, it will use some built-in rules to convert the word.

We might have some new words that are not in the dictionary of Humanizer, and plurality rules applied on them might output wrong result, when this happens, you could use the `irregular-plural-words` configuration to add new word to the dictionary.

```yaml
irregular-plural-words:
  redis: redis
```
This configuration adds a new irregular word into the dictionary that the plural form of `redis` is still `redis`.

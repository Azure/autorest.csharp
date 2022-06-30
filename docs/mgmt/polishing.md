# Management SDK polishing configurations

- [Rename Rules](#rename-rules)
- [Change Format by Name Rules](#change-format-by-name-rules)
- [Rename Mapping](#rename-mapping)
    - [Rename a Type](#rename-a-type)
    - [Rename a Property in a Class](#rename-a-property-in-a-class)
    - [Rename an Enumeration Value in an Enumeration Type](#rename-an-enumeration-value-in-an-enumeration-type)

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

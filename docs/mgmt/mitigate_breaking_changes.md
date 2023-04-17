# Mitigate Breaking Changes

## Overview

Whenever an update is applied to an existing SDK library, there is a chance that the update will introduce breaking changes. Breaking changes are changes that are not backwards compatible and may require client code to be updated. For example, a method may be removed, a method may be renamed, or a method may have its signature changed. Breaking changes are inconvenient for clients that need to update their code in order to consume the latest version of the SDK. Therefore we would like to eliminate breaking changes whenever possible.

To enforce this, we have a check in `dotnet build` that will fail if a breaking change is detected. This check is performed by the APIComPat tool. The tool is run as part of the build process and will compare the current assembly with the previous assembly (if it exists). If any breaking changes are detected, the build will fail, and you will see the following error message:
```
error : MembersMustExist : Member '<MemberName>' does not exist in the implementation but it does exist in the contract.
```

## General Principles

1. We should never introduce API breaking changes. If there are breaking changes, we should always mitigate them in a non-breaking way.
1. We should try our best to avoid behavioral breaking changes. The way we mitigate breaking changes should not change the behavior of the API.
1. The SDK is designed to support multiple API versions, therefore we should ensure that the mitigation steps do not introduce breaking changes for older API versions.

## Mitigation Steps

### `MembersMustExist` Errors

`MembersMustExist` errors from ApiCompat are usually seen when a member is removed in the new version of the SDK. This can happen when a method/property/class is removed, or when a method/property/class is renamed. To mitigate this, we should introduce the removed member back and add the `[EditorBrowsable(EditorBrowsableState.Never)]` attribute to the member. This will hide the member from intellisense, and will prevent the member from being used in client code. This will not be a breaking change for clients that are using the member, but it will prevent new clients from using the member.

To mitigate a `MembersMustExist` error for removed **properties** or **methods**, follow these steps:

1. Create a file outside the `src/Generated` directory with the same name of its containing class. Usually they should go into the `src/Customization` or `src/Custom` directory, if there is not such a directory, please create one.
1. Create a partial class in the file with the same name as the containing class.
1. Introduce the property or method back (**including its original implementation and xml documentation**) with the `[EditorBrowsable(EditorBrowsableState.Never)]` attribute.
1. Introduce everything needed in the original implementation back as well, including any helper methods, classes, etc.

In addition, for removed properties, we need to do some additional steps to make sure our SDK still works for old API versions. Please see the section below for more details.

If the property no longer works in all API versions, please add the `[Obsolete("<Put a message here>", false)]` attribute to the property and just leave the property with its auto getter and setter.

```csharp
// in file `src/Customization/TheTypeContainingRemovedProperty.cs`
public partial class TheTypeContainingRemovedProperty
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This property no longer works in all API versions. Please use the <NewProperty> instead.", false)]
    public string RemovedProperty { get; } // if it previously does not have a setter
    //public string RemovedProperty { get; set; } // if it previously has a setter
}
```

If the property still works for old API versions, and it no longer works for newer API versions, please **DO NOT** add the `Obsolete` attribute to this property. In addition, to make sure our SDK still works for old API versions, please add a new internal constructor that takes all the properties including this removed property, and call the base generated internal constructor, and we need to add the removed property to its serialization method and deserialization method (if any).

```csharp
// in file `src/Customization/TheTypeContainingRemovedProperty.cs`
public partial class TheTypeContainingRemovedProperty
{
    internal TheTypeContainingRemovedProperty(string propertyThatDefinedInOtherPartialClassFiles, string removedProperty) : base(propertyThatDefinedInOtherPartialClassFiles)
    {
        RemovedProperty = removedProperty;
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public string RemovedProperty { get; } // if it previously does not have a setter
    //public string RemovedProperty { get; set; } // if it previously has a setter
}

// in file `src/Customization/TheTypeContainingRemovedProperty.Serialization.cs`
public partial class TheTypeContainingRemovedProperty : IUtf8JsonSerializable
{
    // the full method name here is required to make sure the generate do not generate another method with the same name
    void global::Azure.Core.IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
    {
        /* here we just copy the generated IUtf8JsonSerializable.Write method content here */
        writer.WriteStartObject(); // this is copied here
        writer.WritePropertyName("propertyThatDefinedInOtherPartialClassFiles"); // this is copied here
        writer.WriteStringValue(PropertyThatDefinedInOtherPartialClassFiles); // this is copied here
        // these lines are the serialization of the removed property - it should change based on the type of the property
        writer.WritePropertyName("removedProperty");
        writer.WriteStringValue(RemovedProperty);
        writer.WriteEndObject(); // this is copied here
    }

    internal static TheTypeContainingRemovedProperty DeserializeTheTypeContainingRemovedProperty(JsonElement element)
    {
        /* here we just copy the generated DeserializeTheTypeContainingRemovedProperty method content here */
        Optional<string> propertyThatDefinedInOtherPartialClassFiles = default; // this is copied here
        Optional<string> removedProperty = default;
        foreach (var property in element.EnumerateObject()) // this is copied here
        {
            if (property.NameEquals("propertyThatDefinedInOtherPartialClassFiles")) // this is copied here
            {
                if (property.Value.ValueKind == JsonValueKind.Null) // this is copied here
                {
                    continue; // this is copied here
                }
                propertyThatDefinedInOtherPartialClassFiles = property.Value.GetString(); // this is copied here
                continue; // this is copied here
            }
            // these lines are the deserialization of the new property - it should change based on the type of the property
            if (property.NameEquals("removedProperty"))
            {
                if (property.Value.ValueKind == JsonValueKind.Null)
                {
                    continue;
                }
                removedProperty = property.Value.GetString();
                continue;
            }
        }
        return new TheTypeContainingRemovedProperty(propertyThatDefinedInOtherPartialClassFiles, removedProperty); // change this line to use the new constructor
    }
}
```

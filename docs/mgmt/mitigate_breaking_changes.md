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
1. Create a partial class in the file with the same name as the containing class, and introduce the property or method back with the `[EditorBrowsable(EditorBrowsableState.Never)]` attribute.

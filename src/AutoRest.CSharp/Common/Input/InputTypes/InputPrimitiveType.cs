// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace AutoRest.CSharp.Common.Input;

internal record InputPrimitiveType(InputTypeKind Kind, bool IsConfident, bool IsNullable = false) : InputType(Kind.ToString(), IsConfident, IsNullable: IsNullable)
{
    public static InputPrimitiveType AzureLocation { get; } = new(InputTypeKind.AzureLocation, true);
    public static InputPrimitiveType BinaryData { get; } = new(InputTypeKind.BinaryData, true);
    public static InputPrimitiveType Boolean { get; } = new(InputTypeKind.Boolean, true);
    public static InputPrimitiveType Bytes { get; } = new(InputTypeKind.Bytes, true);
    public static InputPrimitiveType BytesBase64Url { get; } = new(InputTypeKind.BytesBase64Url, true);
    public static InputPrimitiveType ContentType { get; } = new(InputTypeKind.ContentType, true);
    public static InputPrimitiveType Date { get; } = new(InputTypeKind.Date, true);
    public static InputPrimitiveType DateTime { get; } = new(InputTypeKind.DateTime, true);
    public static InputPrimitiveType DateTimeISO8601 { get; } = new(InputTypeKind.DateTimeISO8601, true);
    public static InputPrimitiveType DateTimeRFC1123 { get; } = new(InputTypeKind.DateTimeRFC1123, true);
    public static InputPrimitiveType DateTimeUnix { get; } = new(InputTypeKind.DateTimeUnix, true);
    public static InputPrimitiveType DurationISO8601 { get; } = new(InputTypeKind.DurationISO8601, true);
    public static InputPrimitiveType DurationConstant { get; } = new(InputTypeKind.DurationConstant, true);
    public static InputPrimitiveType ETag { get; } = new(InputTypeKind.ETag, true);
    public static InputPrimitiveType Float32 { get; } = new(InputTypeKind.Float32, true);
    public static InputPrimitiveType Float64 { get; } = new(InputTypeKind.Float64, true);
    public static InputPrimitiveType Float128 { get; } = new(InputTypeKind.Float128, true);
    public static InputPrimitiveType Guid { get; } = new(InputTypeKind.Guid, true);
    public static InputPrimitiveType Int32 { get; } = new(InputTypeKind.Int32, true);
    public static InputPrimitiveType Int64 { get; } = new(InputTypeKind.Int64, true);
    public static InputPrimitiveType IPAddress { get; } = new(InputTypeKind.IPAddress, true);
    public static InputPrimitiveType Object { get; } = new(InputTypeKind.Object, false); // we always regard Object is low confident
    public static InputPrimitiveType RequestMethod { get; } = new(InputTypeKind.RequestMethod, true);
    public static InputPrimitiveType ResourceIdentifier { get; } = new(InputTypeKind.ResourceIdentifier, true);
    public static InputPrimitiveType ResourceType { get; } = new(InputTypeKind.ResourceType, true);
    public static InputPrimitiveType Stream { get; } = new(InputTypeKind.Stream, true);
    public static InputPrimitiveType String { get; } = new(InputTypeKind.String, true);
    public static InputPrimitiveType Time { get; } = new(InputTypeKind.Time, true);
    public static InputPrimitiveType Uri { get; } = new(InputTypeKind.Uri, true);

    public bool IsNumber => Kind is InputTypeKind.Int32 or InputTypeKind.Int64 or InputTypeKind.Float32 or InputTypeKind.Float64 or InputTypeKind.Float128;
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.Output.Models.Serialization;

namespace AutoRest.CSharp.Common.Input;

internal record InputPrimitiveType(InputTypePrimitiveKind Kind, SerializationFormat Format, bool IsNullable) : InputType(Kind.ToString(), IsNullable)
{
    private InputPrimitiveType(InputTypePrimitiveKind kind, SerializationFormat format) : this(kind, format, false) { }

    public static InputPrimitiveType AzureLocation { get; } = new(InputTypePrimitiveKind.AzureLocation, SerializationFormat.Default);
    public static InputPrimitiveType Boolean { get; } = new(InputTypePrimitiveKind.Boolean, SerializationFormat.Default);
    public static InputPrimitiveType Bytes { get; } = new(InputTypePrimitiveKind.Bytes, SerializationFormat.Bytes_Base64);
    public static InputPrimitiveType BytesBase64Url { get; } = new(InputTypePrimitiveKind.BytesBase64Url, SerializationFormat.Bytes_Base64Url);
    public static InputPrimitiveType ContentType { get; } = new(InputTypePrimitiveKind.ContentType, SerializationFormat.Default);
    public static InputPrimitiveType Date { get; } = new(InputTypePrimitiveKind.Date, SerializationFormat.Date_ISO8601);
    public static InputPrimitiveType DateTime { get; } = new(InputTypePrimitiveKind.DateTime, SerializationFormat.DateTime_RFC3339);
    public static InputPrimitiveType DateTimeRFC1123 { get; } = new(InputTypePrimitiveKind.DateTimeRFC1123, SerializationFormat.DateTime_RFC1123);
    public static InputPrimitiveType DateTimeUnix { get; } = new(InputTypePrimitiveKind.DateTimeUnix, SerializationFormat.DateTime_Unix);
    public static InputPrimitiveType DurationISO8601 { get; } = new(InputTypePrimitiveKind.DurationISO8601, SerializationFormat.Duration_ISO8601);
    public static InputPrimitiveType DurationConstant { get; } = new(InputTypePrimitiveKind.DurationConstant, SerializationFormat.Duration_Constant);
    public static InputPrimitiveType ETag { get; } = new(InputTypePrimitiveKind.ETag, SerializationFormat.Default);
    public static InputPrimitiveType Float32 { get; } = new(InputTypePrimitiveKind.Float32, SerializationFormat.Default);
    public static InputPrimitiveType Float64 { get; } = new(InputTypePrimitiveKind.Float64, SerializationFormat.Default);
    public static InputPrimitiveType Float128 { get; } = new(InputTypePrimitiveKind.Float128, SerializationFormat.Default);
    public static InputPrimitiveType Guid { get; } = new(InputTypePrimitiveKind.Guid, SerializationFormat.Default);
    public static InputPrimitiveType Int32 { get; } = new(InputTypePrimitiveKind.Int32, SerializationFormat.Default);
    public static InputPrimitiveType Int64 { get; } = new(InputTypePrimitiveKind.Int64, SerializationFormat.Default);
    public static InputPrimitiveType IPAddress { get; } = new(InputTypePrimitiveKind.IPAddress, SerializationFormat.Default);
    public static InputPrimitiveType Object { get; } = new(InputTypePrimitiveKind.Object, SerializationFormat.Default);
    public static InputPrimitiveType RequestMethod { get; } = new(InputTypePrimitiveKind.RequestMethod, SerializationFormat.Default);
    public static InputPrimitiveType ResourceIdentifier { get; } = new(InputTypePrimitiveKind.ResourceIdentifier, SerializationFormat.Default);
    public static InputPrimitiveType ResourceType { get; } = new(InputTypePrimitiveKind.ResourceType, SerializationFormat.Default);
    public static InputPrimitiveType Stream { get; } = new(InputTypePrimitiveKind.Stream, SerializationFormat.Default);
    public static InputPrimitiveType String { get; } = new(InputTypePrimitiveKind.String, SerializationFormat.Default);
    public static InputPrimitiveType Time { get; } = new(InputTypePrimitiveKind.Time, SerializationFormat.Time_ISO8601);
    public static InputPrimitiveType Uri { get; } = new(InputTypePrimitiveKind.Uri, SerializationFormat.Default);

    public bool IsNumber => Kind is InputTypePrimitiveKind.Int32 or InputTypePrimitiveKind.Int64 or InputTypePrimitiveKind.Float32 or InputTypePrimitiveKind.Float64 or InputTypePrimitiveKind.Float128;
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace AutoRest.CSharp.Common.Input;

internal record InputPrimitiveType(InputPrimitiveTypeKind Kind, string Name, string CrossLanguageDefinitionId) : InputType(Name)
{
    #region Scalars defined in typespec-azure-core
    internal const string UuidId = "Azure.Core.uuid";
    internal const string IPv4AddressId = "Azure.Core.ipV4Address";
    internal const string IPv6AddressId = "Azure.Core.ipV6Address";
    internal const string ETagId = "Azure.Core.eTag";
    internal const string AzureLocationId = "Azure.Core.azureLocation";
    internal const string ArmIdId = "Azure.Core.armResourceIdentifier";
    #endregion

    #region Types we supported but not yet added to typespec-azure-core
    internal const string CharId = "Azure.Core.char";
    internal const string ContentTypeId = "Azure.Core.contentType";
    internal const string ResourceTypeId = "Azure.Core.resourceType";
    internal const string RequestMethodId = "Azure.Core.requestMethod";
    #endregion

    #region These types are here only for backward compatibility
    internal const string ObjectId = "Obsolete.object";
    internal const string IPAddressId = "Temp.ipAddress";
    #endregion

    internal InputPrimitiveType(InputPrimitiveTypeKind kind, string name, string crossLanguageDefinitionId, string? encode) : this(kind, name, crossLanguageDefinitionId)
    {
        Encode = encode;
    }
    internal InputPrimitiveType(InputPrimitiveTypeKind kind, string name, string crossLanguageDefinitionId, string? encode, InputPrimitiveType? baseType) : this(kind, name, crossLanguageDefinitionId)
    {
        Encode = encode;
        BaseType = baseType;
    }

    public string? Encode { get; init; }
    public InputPrimitiveType? BaseType { get; init; }

    public static InputPrimitiveType AzureLocation { get; } = new(InputPrimitiveTypeKind.String, "azureLocation", AzureLocationId);
    public static InputPrimitiveType Boolean { get; } = new(InputPrimitiveTypeKind.Boolean, "boolean", "TypeSpec.boolean");
    public static InputPrimitiveType Base64 { get; } = new(InputPrimitiveTypeKind.Bytes, "bytes", "TypeSpec.bytes", BytesKnownEncoding.Base64);
    public static InputPrimitiveType Base64Url { get; } = new(InputPrimitiveTypeKind.Bytes, "bytes", "TypeSpec.bytes", BytesKnownEncoding.Base64Url);
    public static InputPrimitiveType Char { get; } = new(InputPrimitiveTypeKind.String, "char", CharId);
    public static InputPrimitiveType ContentType { get; } = new(InputPrimitiveTypeKind.String, "contentType", ContentTypeId);
    public static InputPrimitiveType PlainDate { get; } = new(InputPrimitiveTypeKind.PlainDate, "plainDate", "TypeSpec.plainDate");
    public static InputPrimitiveType ETag { get; } = new(InputPrimitiveTypeKind.String, "eTag", ETagId);
    public static InputPrimitiveType Float32 { get; } = new(InputPrimitiveTypeKind.Float32, "float32", "TypeSpec.float32");
    public static InputPrimitiveType Float64 { get; } = new(InputPrimitiveTypeKind.Float64, "float64", "TypeSpec.float64");
    public static InputPrimitiveType Decimal128 { get; } = new(InputPrimitiveTypeKind.Decimal128, "decimal128", "TypeSpec.decimal128");
    public static InputPrimitiveType Uuid { get; } = new(InputPrimitiveTypeKind.String, "uuid", UuidId);
    public static InputPrimitiveType Int32 { get; } = new(InputPrimitiveTypeKind.Int32, "int32", "TypeSpec.int32");
    public static InputPrimitiveType Int64 { get; } = new(InputPrimitiveTypeKind.Int64, "int64", "TypeSpec.int64");
    public static InputPrimitiveType ResourceIdentifier { get; } = new(InputPrimitiveTypeKind.String, "armResourceIdentifier", ArmIdId);
    public static InputPrimitiveType ResourceType { get; } = new(InputPrimitiveTypeKind.String, "resourceType", ResourceTypeId);
    public static InputPrimitiveType RequestMethod { get; } = new(InputPrimitiveTypeKind.String, "requestMethod", RequestMethodId);
    public static InputPrimitiveType Stream { get; } = new(InputPrimitiveTypeKind.Stream, "stream", "TypeSpec.Stream"); // TODO -- this is not a builtin type
    public static InputPrimitiveType String { get; } = new(InputPrimitiveTypeKind.String, "string", "TypeSpec.string");
    public static InputPrimitiveType PlainTime { get; } = new(InputPrimitiveTypeKind.PlainTime, "plainTime", "TypeSpec.plainTime");
    public static InputPrimitiveType Url { get; } = new(InputPrimitiveTypeKind.Url, "url", "TypeSpec.url");
    public static InputPrimitiveType Unknown { get; } = new(InputPrimitiveTypeKind.Unknown, "unknown", string.Empty);
    public static InputPrimitiveType Object { get; } = new(InputPrimitiveTypeKind.Unknown, "object", ObjectId);

    public static InputPrimitiveType IPAddress { get; } = new(InputPrimitiveTypeKind.String, "ipAddress", IPAddressId);

    public bool IsNumber => Kind is InputPrimitiveTypeKind.Integer or InputPrimitiveTypeKind.Float or InputPrimitiveTypeKind.Int32 or InputPrimitiveTypeKind.Int64 or InputPrimitiveTypeKind.Float32 or InputPrimitiveTypeKind.Float64 or InputPrimitiveTypeKind.Decimal or InputPrimitiveTypeKind.Decimal128 or InputPrimitiveTypeKind.Numeric;
}

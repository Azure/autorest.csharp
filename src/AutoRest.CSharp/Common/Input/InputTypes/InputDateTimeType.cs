// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace AutoRest.CSharp.Common.Input;

internal record InputDateTimeType(DateTimeKnownEncoding Encode, InputPrimitiveType WireType, bool IsNullable) : InputType("DateTime", IsNullable)
{
    public static InputDateTimeType Rfc3339 { get; } = new(DateTimeKnownEncoding.Rfc3339, InputPrimitiveType.String, false);
    public static InputDateTimeType Rfc7231 { get; } = new(DateTimeKnownEncoding.Rfc7231, InputPrimitiveType.String, false);
    public static InputDateTimeType LongUnixTimestamp { get; } = new(DateTimeKnownEncoding.UnixTimestamp, InputPrimitiveType.Int64, false);
}

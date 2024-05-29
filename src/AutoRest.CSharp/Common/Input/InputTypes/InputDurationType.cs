// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace AutoRest.CSharp.Common.Input;

internal record InputDurationType(DurationKnownEncoding Encode, InputPrimitiveType WireType, bool IsNullable) : InputType("Duration", IsNullable)
{
    public static InputDurationType Iso8601 { get; } = new(DurationKnownEncoding.Iso8601, InputPrimitiveType.String, false);
    public static InputDurationType Seconds { get; } = new(DurationKnownEncoding.Seconds, InputPrimitiveType.Int32, false);
    public static InputDurationType SecondsFloat { get; } = new(DurationKnownEncoding.Seconds, InputPrimitiveType.Float32, false);
    public static InputDurationType SecondsDouble { get; } = new(DurationKnownEncoding.Seconds, InputPrimitiveType.Float64, false);
    public static InputDurationType Constant { get; } = new(DurationKnownEncoding.Constant, InputPrimitiveType.String, false);
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace AutoRest.CSharp.Common.Input;

internal record InputDurationType(DurationKnownEncoding Encode, InputPrimitiveType WireType, bool IsNullable) : InputType("Duration", IsNullable);

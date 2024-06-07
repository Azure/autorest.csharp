// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace AutoRest.CSharp.Common.Input;

internal record InputDateTimeType(DateTimeKnownEncoding Encode, InputPrimitiveType WireType) : InputType("DateTime");

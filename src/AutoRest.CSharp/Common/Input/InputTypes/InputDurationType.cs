// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace AutoRest.CSharp.Common.Input;

internal record InputDurationType(DurationKnownEncoding Encode, InputPrimitiveType WireType) : InputType("Duration");

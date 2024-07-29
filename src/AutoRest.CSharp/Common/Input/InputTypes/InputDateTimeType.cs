// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace AutoRest.CSharp.Common.Input;

internal record InputDateTimeType(DateTimeKnownEncoding Encode, InputPrimitiveType WireType, IReadOnlyList<InputDecoratorInfo> Decorators) : InputType("DateTime", Decorators);

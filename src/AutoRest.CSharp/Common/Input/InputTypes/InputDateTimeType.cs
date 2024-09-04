// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace AutoRest.CSharp.Common.Input;

internal record InputDateTimeType(DateTimeKnownEncoding Encode, string Name, string CrossLanguagueDefinitionId, InputPrimitiveType WireType, InputDateTimeType? BaseType = null) : InputType(Name);

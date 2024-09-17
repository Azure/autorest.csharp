// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace AutoRest.CSharp.Common.Input;

internal record InputDurationType(DurationKnownEncoding Encode, string Name, string CrossLanguageDefinitionId, InputPrimitiveType WireType, InputDurationType? BaseType = null) : InputType(Name);

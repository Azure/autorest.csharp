// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;

namespace AutoRest.CSharp.Output.Models.Serialization.Json;

internal record JsonObjectSerialization(CSharpType Type, IReadOnlyList<Parameter> ConstructorParameters, IReadOnlyList<JsonPropertySerialization> Properties, JsonAdditionalPropertiesSerialization? AdditionalProperties, ObjectTypeDiscriminator? Discriminator, bool IncludeConverter);

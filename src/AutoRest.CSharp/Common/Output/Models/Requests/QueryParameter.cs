// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Output.Models.Serialization;

namespace AutoRest.CSharp.Output.Models.Requests
{
    internal record QueryParameter(string Name, ReferenceOrConstant Value, string? Delimiter, CollectionFormat arrayFormat, bool Escape, SerializationFormat SerializationFormat, bool Explode);
}

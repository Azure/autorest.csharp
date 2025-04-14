// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Linq;

namespace AutoRest.CSharp.Common.Input
{
    internal static class InputTypeExtensions
    {
        public static bool ShouldDeserializeEmptyStringAsNull(this InputModelProperty property)
             => property.Decorators.Any(d => d.Name == "Azure.ClientGenerator.Core.@deserializeEmptyStringAsNull");
    }
}

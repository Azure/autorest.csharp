// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using AutoRest.CSharp.Generation.Writers;
using Azure.ResourceManager.Models;

namespace AutoRest.CSharp.Common.Output.Expressions.ValueExpressions
{
    internal sealed record NewJsonSerializerOptionsExpression : ValueExpression
    {
        public override void Write(CodeWriter writer)
        {
            writer.UseNamespace("Azure.ResourceManager.Models");
            writer.Append($"new {typeof(JsonSerializerOptions)} {{ Converters = {{ new {nameof(ManagedServiceIdentityTypeV3Converter)}() }} }}");
        }
    }
}

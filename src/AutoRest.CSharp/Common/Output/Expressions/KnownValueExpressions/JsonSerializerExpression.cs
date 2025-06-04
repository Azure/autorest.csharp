// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Text.Json;
using AutoRest.CSharp.Common.Output.Expressions.Statements;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Generation.Types;
using Azure.ResourceManager.Models;
using AutoRest.CSharp.Common.Output.Models;

namespace AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions
{
    internal static class JsonSerializerExpression
    {
        internal const string SystemAssignedUserAssignedV3Value = "SystemAssigned,UserAssigned";
        public static MethodBodyStatement SerializeIJsonModel(CSharpType type, Utf8JsonWriterExpression writer, TypedValueExpression value, ValueExpression? options, bool UsingSystemAssignedUserAssignedV3Value = false)
        {
            if (UsingSystemAssignedUserAssignedV3Value && type.Equals(ManagedServiceIdentityType.SystemAssignedUserAssigned))
            {
                writer.WriteStringValue(Snippets.Literal(SystemAssignedUserAssignedV3Value));
            }

            return value.CastTo(new CSharpType(typeof(IJsonModel<>), type)).Invoke("Write", [writer, options ?? ModelReaderWriterOptionsExpression.Wire]).ToStatement();
        }

        public static InvokeStaticMethodExpression Serialize(ValueExpression writer, ValueExpression value, ValueExpression? options = null)
        {
            var arguments = options is null
                ? new[] { writer, value }
                : new[] { writer, value, options };
            return new InvokeStaticMethodExpression(typeof(JsonSerializer), nameof(JsonSerializer.Serialize), arguments);
        }
    }
}

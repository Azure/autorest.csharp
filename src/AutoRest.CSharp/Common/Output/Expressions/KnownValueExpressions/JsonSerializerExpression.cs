// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Text.Json;
using AutoRest.CSharp.Common.Output.Expressions.Statements;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Output.Models.Types;

namespace AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions
{
    internal static class JsonSerializerExpression
    {
        internal const string SystemAssignedUserAssignedV3Value = "SystemAssigned,UserAssigned";
        public static MethodBodyStatement SerializeIJsonModel(CSharpType type, Utf8JsonWriterExpression writer, TypedValueExpression value, ValueExpression? options, bool UsingSystemAssignedUserAssignedV3Value = false)
        {
            if (UsingSystemAssignedUserAssignedV3Value)
            {
                return ModelSerializationExtensionsProvider.Serialize(writer, value, useManagedServiceIdentityV3: true);
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

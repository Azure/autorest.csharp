// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;
using AutoRest.CSharp.Common.Output.Expressions.Statements;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Generation.Types;
using Azure.Core.Expressions.DataFactory;
using Azure.ResourceManager.Models;
using static AutoRest.CSharp.Common.Output.Models.Snippets;

namespace AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions
{
    internal class ModelReaderWriterExpression
    {
        public static ValueExpression Read(CSharpType type, JsonElementExpression element, ModelReaderWriterOptionsExpression? options = null, bool useManagedServiceIdentityV3 = false)
        {
            if (type.IsGenericType && type.GetGenericTypeDefinition().FrameworkType.Equals(typeof(DataFactoryElement<>)))
            {
                // MRW can't handle DataFactoryElement<> for now, so we use JsonSerializerExpression directly
                return JsonSerializerExpression.Deserialize(element, type, options);
            }

            return
                new IfElsePreprocessorExpression(
                    "NET9_0_OR_GREATER",
                    new InvokeStaticMethodExpression(
                        typeof(ModelReaderWriter),
                        nameof(ModelReaderWriter.Read),
                        [
                                New.Instance(typeof(BinaryData), [new InvokeStaticMethodExpression(typeof(JsonMarshal), nameof(JsonMarshal.GetRawUtf8Value), [element]).Invoke("ToArray")]),
                            useManagedServiceIdentityV3 ? ModelReaderWriterOptionsExpression.UsingSystemAssignedUserAssignedV3(options) : options ?? ModelReaderWriterOptionsExpression.Wire,
                            ModelReaderWriterContextExpression.Default
                        ],
                    TypeArguments: [type]),
                    new InvokeStaticMethodExpression(
                        typeof(ModelReaderWriter),
                        nameof(ModelReaderWriter.Read),
                        [
                            New.Instance(typeof(BinaryData), [new MemberExpression(typeof(Encoding), nameof(Encoding.UTF8)).Invoke(nameof(UTF8Encoding.GetBytes), [element.GetRawText()])]),
                            useManagedServiceIdentityV3 ? ModelReaderWriterOptionsExpression.UsingSystemAssignedUserAssignedV3(options) : options ?? ModelReaderWriterOptionsExpression.Wire,
                            ModelReaderWriterContextExpression.Default
                        ],
                        TypeArguments: [type]));
        }

        public static InvokeInstanceMethodExpression Write(ValueExpression value, CSharpType type, Utf8JsonWriterExpression writer, ModelReaderWriterOptionsExpression? options = null, bool useManagedServiceIdentityV3 = false)
        {
            return value.CastTo(new CSharpType(typeof(IJsonModel<>), type)).Invoke(
                nameof(IJsonModel<object>.Write),
                [
                    writer,
                    useManagedServiceIdentityV3 ? ModelReaderWriterOptionsExpression.UsingSystemAssignedUserAssignedV3(options) : options ?? ModelReaderWriterOptionsExpression.Wire
                ]);
        }
    }
}

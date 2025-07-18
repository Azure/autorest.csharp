// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text;
using AutoRest.CSharp.Common.Output.Expressions.Statements;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Output.Models.Types;
using Azure.Core.Expressions.DataFactory;
using static AutoRest.CSharp.Common.Output.Models.Snippets;

namespace AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions
{
    internal class ModelReaderWriterExpression
    {
        private static readonly HashSet<string> _dataFactoryTypesNotImplementingIJsonModel = new()
        {
            $"Azure.Core.Expressions.DataFactory.{nameof(DataFactoryLinkedServiceReference)}",
            $"Azure.Core.Expressions.DataFactory.{nameof(DataFactoryKeyVaultSecret)}",
            $"Azure.Core.Expressions.DataFactory.{nameof(DataFactorySecret)}",
            $"Azure.Core.Expressions.DataFactory.{nameof(DataFactorySecretString)}"
        };

        public static ValueExpression Read(CSharpType type, JsonElementExpression element, ModelReaderWriterOptionsExpression? options = null, bool useManagedServiceIdentityV3 = false)
        {
            if (IsDataFactoryType(type))
            {
                return JsonSerializerExpression.Deserialize(element, type);
            }

            return new InvokeStaticMethodExpression(
                        typeof(ModelReaderWriter),
                        nameof(ModelReaderWriter.Read),
                        [
                            New.Instance(typeof(BinaryData), [new MemberExpression(typeof(Encoding), nameof(Encoding.UTF8)).Invoke(nameof(UTF8Encoding.GetBytes), [element.GetRawText()])]),
                            useManagedServiceIdentityV3 ? ModelReaderWriterOptionsExpression.UsingSystemAssignedUserAssignedV3(options) : options ?? ModelReaderWriterOptionsExpression.Wire,
                            ModelReaderWriterContextExpression.Default
                        ],
                        TypeArguments: [type]);
        }

        // MRW can't handle DataFactoryElement<> for now, so we use JsonSerializerExpression directly
        // TODO: remove this when we have AOT-safe ready for DataFactoryElement related types
        private static bool IsDataFactoryType(CSharpType type)
        {
            return (type.IsGenericType && type.GetGenericTypeDefinition().FrameworkType.Equals(typeof(DataFactoryElement<>)))
                            || (!type.IsFrameworkType && type.Implementation is SystemObjectType && _dataFactoryTypesNotImplementingIJsonModel.Contains($"{type.Namespace}.{type.Name}"));
        }

        public static MethodBodyStatement Write(ValueExpression value, CSharpType type, Utf8JsonWriterExpression writer, ModelReaderWriterOptionsExpression? options = null, bool useManagedServiceIdentityV3 = false)
        {
            if (IsDataFactoryType(type))
            {
                return JsonSerializerExpression.Serialize(writer, value).ToStatement();
            }

            return value.CastTo(new CSharpType(typeof(IJsonModel<>), type)).Invoke(
                nameof(IJsonModel<object>.Write),
                [
                    writer,
                    useManagedServiceIdentityV3 ? ModelReaderWriterOptionsExpression.UsingSystemAssignedUserAssignedV3(options) : options ?? ModelReaderWriterOptionsExpression.Wire
                ]).ToStatement();
        }
    }
}

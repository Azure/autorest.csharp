// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Linq;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions;
using AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions.Azure;
using AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions.System;
using AutoRest.CSharp.Common.Output.Expressions.Statements;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;
using Azure.Core;

namespace AutoRest.CSharp.Common.Output.Models
{
    internal static partial class Snippets
    {
        public static ValueExpression GetConversion(this ValueExpression expression, CSharpType from, CSharpType to)
        {
            if (CSharpType.RequiresToList(from, to))
            {
                if (from.IsNullable)
                    expression = new NullConditionalExpression(expression);
                return new InvokeStaticMethodExpression(typeof(Enumerable), nameof(Enumerable.ToList), new[] { expression }, CallAsExtension: true);
            }

            // null value cannot directly assign to extensible enum from string, because it invokes the implicit operator from string which invokes the ctor, and the ctor does not allow the value to be null
            if (RequiresNullCheckForExtensibleEnum(from, to))
            {
                expression = new TernaryConditionalOperator(
                    Equal(expression, Null),
                    to.IsNullable ? Null.CastTo(to) : Default.CastTo(to),
                    New.Instance(to, expression));
            }

            return expression;
        }

        public static ValueExpression GetConversionToProtocol(this Parameter convenience, CSharpType toType, string? contentType)
        {
            // deal with the cases of converting to RequestContent
            if (toType.EqualsIgnoreNullable(Configuration.ApiTypes.RequestContentType))
            {
                return GetConversionToRequestContent(convenience, contentType);
            }

            TypedValueExpression expression = new ParameterReference(convenience);
            // converting to anything else should be path, query, head parameters
            if (expression.Type is { IsFrameworkType: false, Implementation: EnumType enumType })
            {
                if (convenience.Type.IsNullable)
                {
                    expression = expression.NullConditional();
                }
                expression = new EnumExpression(enumType, expression).ToSerial();
            }

            return expression;

            static ValueExpression GetConversionToRequestContent(Parameter convenience, string? contentType)
            {
                switch (convenience.Type)
                {
                    case { IsFrameworkType: true }:
                        return GetConversionFromFrameworkToRequestContent(convenience, contentType);
                    case { IsFrameworkType: false, Implementation: EnumType enumType }:
                        TypedValueExpression enumExpression = new ParameterReference(convenience);
                        if (convenience.IsOptionalInSignature)
                        {
                            enumExpression = enumExpression.NullableStructValue();
                        }
                        var convenienceEnum = new EnumExpression(enumType, enumExpression);
                        return Extensible.RequestContent.Create(BinaryDataExpression.FromObjectAsJson(convenienceEnum.ToSerial()));
                    case { IsFrameworkType: false, Implementation: ModelTypeProvider model }:
                        TypedValueExpression modelExpression = new ParameterReference(convenience);
                        if (convenience.IsOptionalInSignature)
                        {
                            modelExpression = modelExpression.NullConditional();
                        }
                        var serializableObjectExpression = new SerializableObjectTypeExpression(model, modelExpression);
                        if (contentType != null && FormattableStringHelpers.ToMediaType(contentType) == BodyMediaType.Multipart)
                        {
                            return serializableObjectExpression.ToMultipartRequestContent();
                        }
                        return serializableObjectExpression.ToRequestContent();
                    default:
                        throw new InvalidOperationException($"Unhandled type: {convenience.Type}");
                }
            }

            static ValueExpression GetConversionFromFrameworkToRequestContent(Parameter parameter, string? contentType)
            {
                if (parameter.Type.IsReadWriteDictionary)
                {
                    var expression = RequestContentHelperProvider.Instance.FromDictionary(parameter);
                    if (parameter.IsOptionalInSignature)
                    {
                        expression = new TernaryConditionalOperator(NotEqual(parameter, Null), expression, Null);
                    }
                    return expression;
                }

                if (parameter.Type.IsList)
                {
                    var content = (ValueExpression)parameter;
                    content = parameter.Type.IsReadOnlyMemory
                        ? content.Property(nameof(ReadOnlyMemory<byte>.Span)) // for ReadOnlyMemory, we need to get the Span and pass it through
                        : content;
                    var expression = RequestContentHelperProvider.Instance.FromEnumerable(content);
                    if (parameter.IsOptionalInSignature)
                    {
                        expression = new TernaryConditionalOperator(NotEqual(parameter, Null), expression, Null);
                    }
                    return expression;
                }

                if (parameter.Type.IsFrameworkType == true && parameter.Type.FrameworkType == typeof(AzureLocation))
                {
                    return RequestContentHelperProvider.Instance.FromObject(((ValueExpression)parameter).InvokeToString());
                }

                BodyMediaType? mediaType = contentType == null ? null : FormattableStringHelpers.ToMediaType(contentType);
                if (parameter.RequestLocation == RequestLocation.Body && mediaType == BodyMediaType.Binary)
                {
                    return parameter;
                }
                // TODO: Here we only consider the case when body is string type. We will add support for other types.
                if (parameter.RequestLocation == RequestLocation.Body && mediaType == BodyMediaType.Text && parameter.Type.FrameworkType == typeof(string))
                {
                    return parameter;
                }

                return RequestContentHelperProvider.Instance.FromObject(parameter);
            }
        }

        /// <summary>
        /// null value cannot directly assign to extensible enum from string, because it invokes the implicit operator from string which invokes the ctor, and the ctor does not allow the value to be null
        /// This method checks if we need an explicitly null check
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        private static bool RequiresNullCheckForExtensibleEnum(CSharpType from, CSharpType to)
        {
            return from is { IsFrameworkType: true, FrameworkType: { } frameworkType } && frameworkType == typeof(string)
                && to is { IsFrameworkType: false, Implementation: EnumType { IsExtensible: true } };
        }

        internal static MethodBodyStatement Increment(ValueExpression value) => new UnaryOperatorStatement(new UnaryOperatorExpression("++", value, true));

        public static class InvokeConvert
        {
            public static ValueExpression ToDouble(StringExpression value) => new InvokeStaticMethodExpression(typeof(Convert), nameof(Convert.ToDouble), Arguments: new[] { value });
            public static ValueExpression ToInt32(StringExpression value) => new InvokeStaticMethodExpression(typeof(Convert), nameof(Convert.ToInt32), Arguments: new[] { value });
        }
    }
}

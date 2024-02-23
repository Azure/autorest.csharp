// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Text.Json;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions;
using AutoRest.CSharp.Common.Output.Expressions.Statements;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input.Source;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;
using static AutoRest.CSharp.Common.Output.Models.Snippets;

namespace AutoRest.CSharp.Common.Output.Models.Types
{
    internal class ModelSerializationExtensionsTypeProvider : ExpressionTypeProvider
    {
        private static readonly Lazy<ModelSerializationExtensionsTypeProvider> _instance = new Lazy<ModelSerializationExtensionsTypeProvider>(() => new ModelSerializationExtensionsTypeProvider(Configuration.Namespace, null));
        public static ModelSerializationExtensionsTypeProvider Instance => _instance.Value;

        private readonly MethodSignatureModifiers _methodModifiers = MethodSignatureModifiers.Public | MethodSignatureModifiers.Static | MethodSignatureModifiers.Extension;
        public ModelSerializationExtensionsTypeProvider(string defaultNamespace, SourceInputModel? sourceInputModel) : base(defaultNamespace, sourceInputModel)
        {
            IsStatic = true;
        }

        protected override string DefaultName { get; } = "ModelSerializationExtensions";

        protected override string DefaultAccessibility { get; } = "internal";

        protected override IEnumerable<Method> BuildMethods()
        {
            #region JsonElementExtensions
            yield return BuildGetObjectMethod();
            #endregion

            #region Utf8JsonWriterExtensions
            yield return BuildWriteObjectValueMethod();
            #endregion
        }

        public const string GetBytesFromBase64 = "GetBytesFromBase64";
        public const string GetChar = "GetChar";
        public const string GetDateTimeOffset = "GetDateTimeOffset";
        public const string GetObject = "GetObject";
        public const string GetTimeSpan = "GetTimeSpan";
        public const string ThrowNonNullablePropertyIsNull = "ThrowNonNullablePropertyIsNull";
        public const string WriteNumberValue = "WriteNumberValue";
        public const string WriteStringValue = "WriteStringValue";
        public const string WriteBase64StringValue = "WriteBase64StringValue";
        public const string WriteObjectValue = "WriteObjectValue";

        private Method BuildGetObjectMethod()
        {
            var elementParameter = new Parameter("element", null, typeof(JsonElement), null, ValidationType.None, null);
            var signature = new MethodSignature(
                Name: GetObject,
                Summary: null,
                Description: null,
                Modifiers: _methodModifiers,
                ReturnType: typeof(object),
                ReturnDescription: null,
                Parameters: new[] { elementParameter });
            var element = new JsonElementExpression(elementParameter);
            var body = new SwitchStatement(element.ValueKind)
            {
                new(JsonValueKindExpression.String, Return(element.GetString())),
                new(JsonValueKindExpression.Number, new MethodBodyStatement[]
                {
                    new IfStatement(element.TryGetInt32(out var intValue))
                    {
                        Return(intValue)
                    },
                    new IfStatement(element.TryGetInt64(out var longValue))
                    {
                        Return(longValue)
                    },
                    Return(element.GetDouble())
                }),
                new(JsonValueKindExpression.True, Return(True)),
                new(JsonValueKindExpression.False, Return(False)),
                new(new ValueExpression[] { JsonValueKindExpression.Undefined, JsonValueKindExpression.Null }, Return(Null)),
                new(JsonValueKindExpression.Object, new MethodBodyStatement[]
                {
                    Var("dictionary", New.Dictionary(typeof(string), typeof(object)), out var dictionary),
                    new ForeachStatement("jsonProperty", element.EnumerateObject(), out var jsonProperty)
                    {
                        dictionary.Add(jsonProperty.Property(nameof(JsonProperty.Name)), new JsonElementExpression(jsonProperty.Property(nameof(JsonProperty.Value))).GetObject())
                    },
                    Return(dictionary)
                }),
                new(JsonValueKindExpression.Array, new MethodBodyStatement[]
                {
                    Var("list", New.List(typeof(object)), out var list),
                    new ForeachStatement("item", element.EnumerateArray(), out var item)
                    {
                        list.Add(new JsonElementExpression(item).GetObject())
                    },
                    Return(list.ToArray())
                }),
                SwitchCase.Default(Throw(New.Instance(typeof(NotSupportedException), new FormattableStringExpression("Not supported value kind {0}", element.ValueKind))))
            };
            return new Method(signature, body);
        }

        private Method BuildWriteObjectValueMethod()
        {
            var valueParameter = new Parameter("value", null, typeof(object), null, ValidationType.None, null);
            var signature = new MethodSignature(
                Name: WriteObjectValue,
                Summary: null,
                Description: null,
                Modifiers: _methodModifiers,
                ReturnType: null,
                ReturnDescription: null,
                Parameters: new[] { KnownParameters.Serializations.Utf8JsonWriter, valueParameter });
            var value = (ValueExpression)valueParameter;
            var writer = new Utf8JsonWriterExpression(KnownParameters.Serializations.Utf8JsonWriter);
            var body = new SwitchStatement(value)
            {
                // null case
                new(Null, new MethodBodyStatement[]
                {
                    writer.WriteNullValue(),
                    Break
                }),
                // serializable case
                BuildWriteObjectValueSwitchCase(Configuration.ApiTypes.IUtf8JsonSerializableType, "serializable", serializableVariable => new MethodBodyStatement[]
                {
                    new InvokeInstanceMethodStatement(serializableVariable, Configuration.ApiTypes.IUtf8JsonSerializableWriteName, writer),
                    Break
                }),
                // byte[] case
                BuildWriteObjectValueSwitchCase(typeof(byte[]), "bytes", bytes => new MethodBodyStatement[]
                {
                    writer.WriteBase64StringValue(bytes),
                    Break
                }),
                // BinaryData case
                BuildWriteObjectValueSwitchCase(typeof(BinaryData), "bytes", bytes => new MethodBodyStatement[]
                {
                    writer.WriteBase64StringValue(bytes),
                    Break
                }),
                // JsonElement case
                BuildWriteObjectValueSwitchCase(typeof(JsonElement), "json", json => new MethodBodyStatement[]
                {
                    new JsonElementExpression(json).WriteTo(writer),
                    Break
                }),
                // int case
                BuildWriteObjectValueSwitchCase(typeof(int), "i", i => new MethodBodyStatement[]
                {
                    writer.WriteNumberValue(i),
                    Break
                }),
                // decimal case
                BuildWriteObjectValueSwitchCase(typeof(decimal), "d", dec => new MethodBodyStatement[]
                {
                    writer.WriteNumberValue(dec),
                    Break
                }),
                // double case
                BuildWriteObjectValueSwitchCase(typeof(double), "d", d => new MethodBodyStatement[]
                {
                    new IfElseStatement(
                        DoubleExpression.IsNan(d),
                        writer.WriteStringValue(Literal("NaN")),
                        writer.WriteNumberValue(d)),
                    Break
                }),
                // float case
                BuildWriteObjectValueSwitchCase(typeof(float), "f", f => new MethodBodyStatement[]
                {
                    writer.WriteNumberValue(f),
                    Break
                }),
                // long case
                BuildWriteObjectValueSwitchCase(typeof(long), "l", l => new MethodBodyStatement[]
                {
                    writer.WriteNumberValue(l),
                    Break
                }),
                // string case
                BuildWriteObjectValueSwitchCase(typeof(string), "s", s => new MethodBodyStatement[]
                {
                    writer.WriteStringValue(s),
                    Break
                }),
                // bool case
                BuildWriteObjectValueSwitchCase(typeof(bool), "b", b => new MethodBodyStatement[]
                {
                    writer.WriteBooleanValue(b),
                    Break
                }),
                // Guid case
                BuildWriteObjectValueSwitchCase(typeof(Guid), "g", g => new MethodBodyStatement[]
                {
                    writer.WriteStringValue(g),
                    Break
                }),
                // DateTimeOffset case
                BuildWriteObjectValueSwitchCase(typeof(DateTimeOffset), "dateTimeOffset", dateTimeOffset => new MethodBodyStatement[]
                {
                    writer.WriteStringValue(dateTimeOffset, "O"),
                    Break
                }),
                // DateTime case
                BuildWriteObjectValueSwitchCase(typeof(DateTime), "dateTime", dateTime => new MethodBodyStatement[]
                {
                    writer.WriteStringValue(dateTime, "O"),
                    Break
                }),
                // IEnumerable<KeyValuePair<>> case
                BuildWriteObjectValueSwitchCase(typeof(IEnumerable<KeyValuePair<string, object>>), "enumerable", enumerable => new MethodBodyStatement[]
                {
                    writer.WriteStartObject(),
                    new ForeachStatement("pair", new EnumerableExpression(typeof(KeyValuePair<string, object>), enumerable), out var pair)
                    {
                        writer.WritePropertyName(pair.Property(nameof(KeyValuePair<string, object>.Key))),
                        writer.WriteObjectValue(pair.Property(nameof(KeyValuePair<string, object>.Value)))
                    },
                    writer.WriteEndObject(),
                    Break
                }),
                // IEnumerable<object> case
                BuildWriteObjectValueSwitchCase(typeof(IEnumerable<object>), "objectEnumerable", objectEnumerable => new MethodBodyStatement[]
                {
                    writer.WriteStartArray(),
                    new ForeachStatement("item", new EnumerableExpression(typeof(object), objectEnumerable), out var item)
                    {
                        writer.WriteObjectValue(item)
                    },
                    writer.WriteEndArray(),
                    Break
                }),
                // TimeSpan case
                BuildWriteObjectValueSwitchCase(typeof(TimeSpan), "timeSpan", timeSpan => new MethodBodyStatement[]
                {
                    writer.WriteStringValue(timeSpan, "P"),
                    Break
                }),
                // default
                SwitchCase.Default(Throw(New.Instance(typeof(NotSupportedException), new FormattableStringExpression("Not supported type {0}", value.InvokeGetType()))))
            };

            return new Method(signature, body);

            static SwitchCase BuildWriteObjectValueSwitchCase(CSharpType type, string varName, Func<VariableReference, MethodBodyStatement> bodyFunc)
            {
                var declaration = new DeclarationExpression(type, varName, out var variable);
                var body = bodyFunc(variable);

                return new(declaration, body);
            }
        }
    }
}

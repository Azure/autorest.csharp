// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
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
using Azure.Core;
using static AutoRest.CSharp.Common.Output.Models.Snippets;

namespace AutoRest.CSharp.Common.Output.Models.Types
{
    internal class ModelSerializationExtensionsProvider : ExpressionTypeProvider
    {
        private static readonly Lazy<ModelSerializationExtensionsProvider> _instance = new Lazy<ModelSerializationExtensionsProvider>(() => new ModelSerializationExtensionsProvider(Configuration.Namespace, null));
        public static ModelSerializationExtensionsProvider Instance => _instance.Value;

        private readonly MethodSignatureModifiers _methodModifiers = MethodSignatureModifiers.Public | MethodSignatureModifiers.Static | MethodSignatureModifiers.Extension;
        public ModelSerializationExtensionsProvider(string defaultNamespace, SourceInputModel? sourceInputModel) : base(defaultNamespace, sourceInputModel)
        {
            IsStatic = true;
        }

        protected override string DefaultName { get; } = "ModelSerializationExtensions";

        protected override string DefaultAccessibility { get; } = "internal";

        protected override IEnumerable<Method> BuildMethods()
        {
            #region JsonElementExtensions
            yield return BuildGetObjectMethod();

            yield return BuildGetBytesFromBase64();

            yield return BuildGetDateTimeOffsetMethod();

            yield return BuildGetTimeSpanMethod();

            yield return BuildGetCharMethod();

            yield return BuildThrowNonNullablePropertyIsNullMethod();

            yield return BuildGetRequiredStringMethod();
            #endregion

            #region Utf8JsonWriterExtensions
            foreach (var method in BuildWriteStringValueMethods())
            {
                yield return method;
            }

            yield return BuildWriteNonEmptyArrayMethod();

            yield return BuildWriteBase64StringValueMethod();

            yield return BuildWriteNumberValueMethod();

            yield return BuildWriteObjectValueMethod();
            #endregion
        }

        public const string GetBytesFromBase64 = "GetBytesFromBase64";
        public const string GetChar = "GetChar";
        public const string GetDateTimeOffset = "GetDateTimeOffset";
        public const string GetObject = "GetObject";
        public const string GetTimeSpan = "GetTimeSpan";
        public const string ThrowNonNullablePropertyIsNull = "ThrowNonNullablePropertyIsNull";
        public const string GetRequiredString = "GetRequiredString";
        public const string WriteNumberValue = "WriteNumberValue";
        public const string WriteStringValue = "WriteStringValue";
        public const string WriteNonEmptyArray = "WriteNonEmptyArray";
        public const string WriteBase64StringValue = "WriteBase64StringValue";
        public const string WriteObjectValue = "WriteObjectValue";

        private readonly Parameter _formatParameter = new Parameter("format", null, typeof(string), null, ValidationType.None, null);
        private readonly Parameter _propertyParameter = new Parameter("property", null, typeof(JsonProperty), null, ValidationType.None, null);

        #region JsonElementExtensions methods
        private Method BuildGetObjectMethod()
        {
            var signature = new MethodSignature(
                Name: GetObject,
                Summary: null,
                Description: null,
                Modifiers: _methodModifiers,
                ReturnType: typeof(object),
                ReturnDescription: null,
                Parameters: new[] { KnownParameters.Serializations.JsonElement });
            var element = new JsonElementExpression(KnownParameters.Serializations.JsonElement);
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

        private Method BuildGetBytesFromBase64()
        {
            var signature = new MethodSignature(
                Name: GetBytesFromBase64,
                Modifiers: _methodModifiers,
                Parameters: new[] { KnownParameters.Serializations.JsonElement, _formatParameter },
                ReturnType: typeof(byte[]),
                Summary: null, Description: null, ReturnDescription: null);
            var element = new JsonElementExpression(KnownParameters.Serializations.JsonElement);
            var format = new StringExpression(_formatParameter);
            var body = new MethodBodyStatement[]
            {
                new IfStatement(element.ValueKindEqualsNull())
                {
                    Return(Null)
                },
                EmptyLine,
                Return(new SwitchExpression(format,
                    new SwitchCaseExpression(Literal("U"), new InvokeStaticMethodExpression(typeof(TypeFormatters), nameof(TypeFormatters.FromBase64UrlString), new[] { new InvokeStaticMethodExpression(Type, GetRequiredString, new[] { element }, CallAsExtension: true) })),
                    new SwitchCaseExpression(Literal("D"), element.GetBytesFromBase64()),
                    SwitchCaseExpression.Default(ThrowExpression(New.Instance(typeof(ArgumentException), new FormattableStringExpression("Format is not supported: '{0}'", format), Nameof(format))))
                    ))
            };

            return new Method(signature, body);
        }

        private Method BuildGetDateTimeOffsetMethod()
        {
            var signature = new MethodSignature(
                Name: GetDateTimeOffset,
                Modifiers: _methodModifiers,
                Parameters: new[] { KnownParameters.Serializations.JsonElement, _formatParameter },
                ReturnType: typeof(DateTimeOffset),
                Summary: null, Description: null, ReturnDescription: null);
            var element = new JsonElementExpression(KnownParameters.Serializations.JsonElement);
            var format = new StringExpression(_formatParameter);
            var body = new SwitchExpression(format,
                SwitchCaseExpression.When(Literal("U"), Equal(element.ValueKind, JsonValueKindExpression.Number), DateTimeOffsetExpression.FromUnixTimeSeconds(element.GetInt64())),
                // relying on the param check of the inner call to throw ArgumentNullException if GetString() returns null
                SwitchCaseExpression.Default(new InvokeStaticMethodExpression(typeof(TypeFormatters), nameof(TypeFormatters.ParseDateTimeOffset), new[] { element.GetString(), format }))
                );

            return new Method(signature, body);
        }

        private Method BuildGetTimeSpanMethod()
        {
            var signature = new MethodSignature(
                Name: GetTimeSpan,
                Modifiers: _methodModifiers,
                Parameters: new[] { KnownParameters.Serializations.JsonElement, _formatParameter },
                ReturnType: typeof(TimeSpan),
                Summary: null, Description: null, ReturnDescription: null);
            var element = new JsonElementExpression(KnownParameters.Serializations.JsonElement);
            // relying on the param check of the inner call to throw ArgumentNullException if GetString() returns null
            var body = new InvokeStaticMethodExpression(typeof(TypeFormatters), nameof(TypeFormatters.ParseTimeSpan), new ValueExpression[] { element.GetString(), _formatParameter });

            return new Method(signature, body);
        }

        private Method BuildGetCharMethod()
        {
            var signature = new MethodSignature(
                Name: GetChar,
                Modifiers: _methodModifiers,
                Parameters: new[] { KnownParameters.Serializations.JsonElement },
                ReturnType: typeof(char),
                Summary: null, Description: null, ReturnDescription: null);
            var element = new JsonElementExpression(KnownParameters.Serializations.JsonElement);
            var body = new IfElseStatement(
                element.ValueKindEqualsNull(),
                new MethodBodyStatement[]
                {
                    Var("text", element.GetString(), out var text),
                    new IfStatement(Equal(text, Null).Or(NotEqual(text.Length, Literal(1))))
                    {
                        Throw(New.Instance(typeof(NotSupportedException), new FormattableStringExpression("Cannot convert \\\"{0}\\\" to a char", text)))
                    },
                    Return(text.Index(0))
                },
                Throw(New.Instance(typeof(NotSupportedException), new FormattableStringExpression("Cannot convert {0} to a char", element.ValueKind)))
                );

            return new Method(signature, body);
        }

        private Method BuildThrowNonNullablePropertyIsNullMethod()
        {
            var signature = new MethodSignature(
                Name: ThrowNonNullablePropertyIsNull,
                Modifiers: _methodModifiers,
                Parameters: new[] { _propertyParameter },
                ReturnType: null,
                Attributes: new[]
                {
                    new CSharpAttribute(typeof(ConditionalAttribute), Literal("DEBUG"))
                },
                Summary: null, Description: null, ReturnDescription: null);
            var property = new JsonPropertyExpression(_propertyParameter);
            var body = Throw(New.Instance(typeof(JsonException), new FormattableStringExpression("A property '{0}' defined as non-nullable but received as null from the service. This exception only happens in DEBUG builds of the library and would be ignored in the release build", property.Name)));

            return new Method(signature, body);
        }

        private Method BuildGetRequiredStringMethod()
        {
            var signature = new MethodSignature(
                Name: GetRequiredString,
                Modifiers: _methodModifiers,
                Parameters: new[] { KnownParameters.Serializations.JsonElement },
                ReturnType: typeof(string),
                Summary: null, Description: null, ReturnDescription: null);
            var element = new JsonElementExpression(KnownParameters.Serializations.JsonElement);
            var body = new MethodBodyStatement[]
            {
                Var("value", element.GetString(), out var value),
                new IfStatement(Equal(value, Null))
                {
                    Throw(New.Instance(typeof(InvalidOperationException), new FormattableStringExpression("The requested operation requires an element of type 'String', but the target element has type '{0}'.", element.ValueKind)))
                },
                Return(value)
            };

            return new Method(signature, body);
        }
        #endregion

        #region Utf8JsonWriterExtension methods
        private IEnumerable<Method> BuildWriteStringValueMethods()
        {
            var writer = new Utf8JsonWriterExpression(KnownParameters.Serializations.Utf8JsonWriter);
            var dateTimeOffsetValueParameter = new Parameter("value", null, typeof(DateTimeOffset), null, ValidationType.None, null);
            yield return new Method(
                new MethodSignature(
                    Name: WriteStringValue,
                    Modifiers: _methodModifiers,
                    ReturnType: null,
                    Parameters: new[] { KnownParameters.Serializations.Utf8JsonWriter, dateTimeOffsetValueParameter, _formatParameter },
                    Summary: null, Description: null, ReturnDescription: null),
                writer.WriteStringValue(new InvokeStaticMethodExpression(typeof(TypeFormatters), "ToString", new ValueExpression[] { dateTimeOffsetValueParameter, _formatParameter })) // TODO -- TypeFormatters also need to convert to a typeprovider
                );

            var dateTimeValueParameter = new Parameter("value", null, typeof(DateTime), null, ValidationType.None, null);
            yield return new Method(
                new MethodSignature(
                    Name: WriteStringValue,
                    Modifiers: _methodModifiers,
                    ReturnType: null,
                    Parameters: new[] { KnownParameters.Serializations.Utf8JsonWriter, dateTimeValueParameter, _formatParameter },
                    Summary: null, Description: null, ReturnDescription: null),
                writer.WriteStringValue(new InvokeStaticMethodExpression(typeof(TypeFormatters), "ToString", new ValueExpression[] { dateTimeValueParameter, _formatParameter })) // TODO -- TypeFormatters also need to convert to a typeprovider
                );

            var timeSpanValueParameter = new Parameter("value", null, typeof(TimeSpan), null, ValidationType.None, null);
            yield return new Method(
                new MethodSignature(
                    Name: WriteStringValue,
                    Modifiers: _methodModifiers,
                    ReturnType: null,
                    Parameters: new[] { KnownParameters.Serializations.Utf8JsonWriter, timeSpanValueParameter, _formatParameter },
                    Summary: null, Description: null, ReturnDescription: null),
                writer.WriteStringValue(new InvokeStaticMethodExpression(typeof(TypeFormatters), "ToString", new ValueExpression[] { timeSpanValueParameter, _formatParameter })) // TODO -- TypeFormatters also need to convert to a typeprovider
                );

            var charValueParameter = new Parameter("value", null, typeof(char), null, ValidationType.None, null);
            yield return new Method(
                new MethodSignature(
                    Name: WriteStringValue,
                    Modifiers: _methodModifiers,
                    ReturnType: null,
                    Parameters: new[] { KnownParameters.Serializations.Utf8JsonWriter, charValueParameter, _formatParameter },
                    Summary: null, Description: null, ReturnDescription: null),
                writer.WriteStringValue(((ValueExpression)charValueParameter).Invoke(nameof(char.ToString), new MemberExpression(typeof(CultureInfo), nameof(CultureInfo.InvariantCulture))))
                );
        }

        private Method BuildWriteNonEmptyArrayMethod()
        {
            var nameParameter = new Parameter("name", null, typeof(string), null, ValidationType.None, null);
            var valuesParameter = new Parameter("values", null, typeof(IReadOnlyList<string>), null, ValidationType.None, null);
            var signature = new MethodSignature(
                Name: WriteNonEmptyArray,
                Modifiers: _methodModifiers,
                ReturnType: null,
                Parameters: new[] { KnownParameters.Serializations.Utf8JsonWriter, nameParameter, valuesParameter },
                Summary: null, Description: null, ReturnDescription: null);
            var writer = new Utf8JsonWriterExpression(KnownParameters.Serializations.Utf8JsonWriter);
            var name = new StringExpression(nameParameter);
            var values = new EnumerableExpression(typeof(string), valuesParameter);
            var body = new IfStatement(values.Any())
            {
                writer.WriteStartArray(name),
                new ForeachStatement("s", values, out var s)
                {
                    writer.WriteStringValue(s)
                },
                writer.WriteEndArray()
            };
            return new Method(signature, body);
        }

        private Method BuildWriteBase64StringValueMethod()
        {
            var valueParameter = new Parameter("value", null, typeof(byte[]), null, ValidationType.None, null);
            var signature = new MethodSignature(
                Name: WriteBase64StringValue,
                Modifiers: _methodModifiers,
                Parameters: new[] { KnownParameters.Serializations.Utf8JsonWriter, valueParameter, _formatParameter },
                ReturnType: null,
                Summary: null, Description: null, ReturnDescription: null);
            var writer = new Utf8JsonWriterExpression(KnownParameters.Serializations.Utf8JsonWriter);
            var value = (ValueExpression)valueParameter;
            var format = new StringExpression(_formatParameter);
            var body = new MethodBodyStatement[]
            {
                new IfStatement(Equal(value, Null))
                {
                    writer.WriteNullValue(),
                    Return()
                },
                new SwitchStatement(format)
                {
                    new(Literal("U"), new MethodBodyStatement[]
                    {
                        writer.WriteStringValue(new InvokeStaticMethodExpression(typeof(TypeFormatters), "ToBase64UrlString", new ValueExpression[] { value })),
                        Break
                    }),
                    new(Literal("D"), new MethodBodyStatement[]
                    {
                        writer.WriteBase64StringValue(value),
                        Break
                    }),
                    SwitchCase.Default(Throw(New.Instance(typeof(ArgumentException), new FormattableStringExpression("Format is not supported: '{0}'", format), Nameof(format))))
                }
            };

            return new Method(signature, body);
        }

        private Method BuildWriteNumberValueMethod()
        {
            var valueParameter = new Parameter("value", null, typeof(DateTimeOffset), null, ValidationType.None, null);
            var signature = new MethodSignature(
                Name: WriteNumberValue,
                Modifiers: _methodModifiers,
                Parameters: new[] { KnownParameters.Serializations.Utf8JsonWriter, valueParameter, _formatParameter },
                ReturnType: null,
                Summary: null, Description: null, ReturnDescription: null);
            var writer = new Utf8JsonWriterExpression(KnownParameters.Serializations.Utf8JsonWriter);
            var value = new DateTimeOffsetExpression(valueParameter);
            var format = new StringExpression(_formatParameter);
            var body = new MethodBodyStatement[]
            {
                new IfStatement(NotEqual(format, Literal("U")))
                {
                    Throw(New.Instance(typeof(ArgumentOutOfRangeException), format, Literal("Only 'U' format is supported when writing a DateTimeOffset as a Number."))),
                },
                writer.WriteNumberValue(value.ToUnixTimeSeconds())
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
        #endregion
    }
}

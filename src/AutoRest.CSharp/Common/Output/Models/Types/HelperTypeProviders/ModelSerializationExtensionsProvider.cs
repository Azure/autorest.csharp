// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Text.Json;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions;
using AutoRest.CSharp.Common.Output.Expressions.Statements;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Common.Output.Models;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Output.Models.Shared;
using Azure.Core;
using static AutoRest.CSharp.Common.Output.Models.Snippets;

namespace AutoRest.CSharp.Output.Models.Types
{
    internal class ModelSerializationExtensionsProvider : ExpressionTypeProvider
    {
        private static readonly Lazy<ModelSerializationExtensionsProvider> _instance = new Lazy<ModelSerializationExtensionsProvider>(() => new ModelSerializationExtensionsProvider());
        public static ModelSerializationExtensionsProvider Instance => _instance.Value;
        private class WriteObjectValueTemplate<T> { }

        private readonly CSharpType _t = typeof(WriteObjectValueTemplate<>).GetGenericArguments()[0];

        private readonly MethodSignatureModifiers _methodModifiers = MethodSignatureModifiers.Public | MethodSignatureModifiers.Static | MethodSignatureModifiers.Extension;
        private readonly TypeFormattersProvider _typeFormattersProvider;

        public ModelSerializationExtensionsProvider() : base(Configuration.HelperNamespace, null)
        {
            DeclarationModifiers = TypeSignatureModifiers.Internal | TypeSignatureModifiers.Static;
            _typeFormattersProvider = new TypeFormattersProvider(this);

            _wireOptionsField = new FieldDeclaration(
                modifiers: FieldModifiers.Internal | FieldModifiers.Static | FieldModifiers.ReadOnly,
                type: typeof(ModelReaderWriterOptions),
                name: _wireOptionsName)
            {
                InitializationValue = New.Instance(typeof(ModelReaderWriterOptions), Literal("W"))
            };

            if (Configuration.EnableInternalRawData)
            {
                // when we have this configuration, we have a sentinel value for raw data values to let us skip values
                _sentinelBinaryDataField = new FieldDeclaration(
                    modifiers: FieldModifiers.Internal | FieldModifiers.Static | FieldModifiers.ReadOnly,
                    type: typeof(BinaryData),
                    name: _sentinelBinaryDataName)
                {
                    InitializationValue = BinaryDataExpression.FromBytes(
                        // since this is a hard-coded value, we can just hard-code the bytes directly instead of
                        // using the BinaryData.FromObjectAsJson method
                        new InvokeInstanceMethodExpression(
                            LiteralU8("\"__EMPTY__\""), "ToArray", [], null, false))
                };
            }
        }

        private const string _wireOptionsName = "WireOptions";
        private readonly FieldDeclaration _wireOptionsField;
        private const string _sentinelBinaryDataName = "SentinelValue";
        private readonly FieldDeclaration? _sentinelBinaryDataField;

        private ModelReaderWriterOptionsExpression? _wireOptions;
        public ModelReaderWriterOptionsExpression WireOptions => _wireOptions ??= new ModelReaderWriterOptionsExpression(new MemberExpression(Type, _wireOptionsName));

        protected override string DefaultName => "ModelSerializationExtensions";

        protected override IEnumerable<FieldDeclaration> BuildFields()
        {
            yield return _wireOptionsField;

            if (_sentinelBinaryDataField != null)
            {
                yield return _sentinelBinaryDataField;
            }
        }

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
            yield return BuildWriteBase64StringValueMethod();
            yield return BuildWriteNumberValueMethod();
            yield return BuildWriteObjectValueMethodGeneric();
            yield return BuildWriteObjectValueMethod();
            #endregion

            #region Sentinel Value related methods
            if (_sentinelBinaryDataField != null)
            {
                var valueParameter = new Parameter("value", null, typeof(BinaryData), null, ValidationType.None, null);
                var signature = new MethodSignature(
                    Name: _isSentinelValueMethodName,
                    Modifiers: MethodSignatureModifiers.Static | MethodSignatureModifiers.Internal,
                    ReturnType: typeof(bool),
                    Parameters: new[] { valueParameter },
                    Summary: null, Description: null, ReturnDescription: null);

                var sentinelValue = new BinaryDataExpression(_sentinelBinaryDataField);
                var value = new BinaryDataExpression(valueParameter);
                var indexer = new VariableReference(typeof(int), "i");
                var body = new MethodBodyStatement[]
                {
                    Declare("sentinelSpan", new TypedValueExpression(typeof(ReadOnlySpan<byte>), sentinelValue.ToMemory().Property(nameof(ReadOnlyMemory<byte>.Span))), out var sentinelSpan),
                    Declare("valueSpan", new TypedValueExpression(typeof(ReadOnlySpan<byte>), value.ToMemory().Property(nameof(ReadOnlyMemory<byte>.Span))), out var valueSpan),
                    Return(new InvokeStaticMethodExpression(typeof(MemoryExtensions), nameof(MemoryExtensions.SequenceEqual), new[] { sentinelSpan, valueSpan }, CallAsExtension: true)),
                };

                yield return new(signature, body);
            }
            #endregion
        }

        private const string _isSentinelValueMethodName = "IsSentinelValue";

        #region JsonElementExtensions method builders
        private const string _getBytesFromBase64MethodName = "GetBytesFromBase64";
        private const string _getCharMethodName = "GetChar";
        private const string _getDateTimeOffsetMethodName = "GetDateTimeOffset";
        private const string _getObjectMethodName = "GetObject";
        private const string _getTimeSpanMethodName = "GetTimeSpan";
        private const string _throwNonNullablePropertyIsNullMethodName = "ThrowNonNullablePropertyIsNull";
        private const string _getRequiredStringMethodName = "GetRequiredString";

        private readonly Parameter _formatParameter = new Parameter("format", null, typeof(string), null, ValidationType.None, null);
        private readonly Parameter _propertyParameter = new Parameter("property", null, typeof(JsonProperty), null, ValidationType.None, null);

        private Method BuildGetObjectMethod()
        {
            var signature = new MethodSignature(
                Name: _getObjectMethodName,
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
                SwitchCase.Default(Throw(New.NotSupportedException(new FormattableStringExpression("Not supported value kind {0}", element.ValueKind))))
            };
            return new Method(signature, body);
        }

        public InvokeStaticMethodExpression GetObject(JsonElementExpression element)
            => new InvokeStaticMethodExpression(Type, _getObjectMethodName, new ValueExpression[] { element }, CallAsExtension: true);

        private Method BuildGetBytesFromBase64()
        {
            var signature = new MethodSignature(
                Name: _getBytesFromBase64MethodName,
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
                    new SwitchCaseExpression(Literal("U"), _typeFormattersProvider.FromBase64UrlString(GetRequiredString(element))),
                    new SwitchCaseExpression(Literal("D"), element.GetBytesFromBase64()),
                    SwitchCaseExpression.Default(ThrowExpression(New.ArgumentException(format, new FormattableStringExpression("Format is not supported: '{0}'", format))))
                    ))
            };

            return new Method(signature, body);
        }

        public InvokeStaticMethodExpression GetBytesFromBase64(JsonElementExpression element, string? format)
            => new InvokeStaticMethodExpression(Type, _getBytesFromBase64MethodName, new ValueExpression[] { element, Literal(format) }, CallAsExtension: true);

        private Method BuildGetDateTimeOffsetMethod()
        {
            var signature = new MethodSignature(
                Name: _getDateTimeOffsetMethodName,
                Modifiers: _methodModifiers,
                Parameters: new[] { KnownParameters.Serializations.JsonElement, _formatParameter },
                ReturnType: typeof(DateTimeOffset),
                Summary: null, Description: null, ReturnDescription: null);
            var element = new JsonElementExpression(KnownParameters.Serializations.JsonElement);
            var format = new StringExpression(_formatParameter);
            var body = new SwitchExpression(format,
                SwitchCaseExpression.When(Literal("U"), Equal(element.ValueKind, JsonValueKindExpression.Number), DateTimeOffsetExpression.FromUnixTimeSeconds(element.GetInt64())),
                // relying on the param check of the inner call to throw ArgumentNullException if GetString() returns null
                SwitchCaseExpression.Default(_typeFormattersProvider.ParseDateTimeOffset(element.GetString(), format))
                );

            return new Method(signature, body);
        }

        public InvokeStaticMethodExpression GetDateTimeOffset(JsonElementExpression element, string? format)
            => new InvokeStaticMethodExpression(Type, _getDateTimeOffsetMethodName, new ValueExpression[] { element, Literal(format) }, CallAsExtension: true);

        private Method BuildGetTimeSpanMethod()
        {
            var signature = new MethodSignature(
                Name: _getTimeSpanMethodName,
                Modifiers: _methodModifiers,
                Parameters: new[] { KnownParameters.Serializations.JsonElement, _formatParameter },
                ReturnType: typeof(TimeSpan),
                Summary: null, Description: null, ReturnDescription: null);
            var element = new JsonElementExpression(KnownParameters.Serializations.JsonElement);
            // relying on the param check of the inner call to throw ArgumentNullException if GetString() returns null
            var body = _typeFormattersProvider.ParseTimeSpan(element.GetString(), _formatParameter);

            return new Method(signature, body);
        }

        public InvokeStaticMethodExpression GetTimeSpan(JsonElementExpression element, string? format)
            => new InvokeStaticMethodExpression(Type, _getTimeSpanMethodName, new ValueExpression[] { element, Literal(format) }, CallAsExtension: true);

        private Method BuildGetCharMethod()
        {
            var signature = new MethodSignature(
                Name: _getCharMethodName,
                Modifiers: _methodModifiers,
                Parameters: new[] { KnownParameters.Serializations.JsonElement },
                ReturnType: typeof(char),
                Summary: null, Description: null, ReturnDescription: null);
            var element = new JsonElementExpression(KnownParameters.Serializations.JsonElement);
            var body = new IfElseStatement(
                element.ValueKindEqualsString(),
                new MethodBodyStatement[]
                {
                    Var("text", element.GetString(), out var text),
                    new IfStatement(Equal(text, Null).Or(NotEqual(text.Length, Literal(1))))
                    {
                        Throw(New.NotSupportedException(new FormattableStringExpression("Cannot convert \\\"{0}\\\" to a char", text)))
                    },
                    Return(text.Index(0))
                },
                Throw(New.NotSupportedException(new FormattableStringExpression("Cannot convert {0} to a char", element.ValueKind)))
                );

            return new Method(signature, body);
        }

        public InvokeStaticMethodExpression GetChar(JsonElementExpression element)
            => new InvokeStaticMethodExpression(Type, _getCharMethodName, new ValueExpression[] { element }, CallAsExtension: true);

        private Method BuildThrowNonNullablePropertyIsNullMethod()
        {
            var signature = new MethodSignature(
                Name: _throwNonNullablePropertyIsNullMethodName,
                Modifiers: _methodModifiers,
                Parameters: new[] { _propertyParameter },
                ReturnType: null,
                Attributes: new[]
                {
                    new CSharpAttribute(typeof(ConditionalAttribute), Literal("DEBUG"))
                },
                Summary: null, Description: null, ReturnDescription: null);
            var property = new JsonPropertyExpression(_propertyParameter);
            var body = Throw(New.JsonException(new FormattableStringExpression("A property '{0}' defined as non-nullable but received as null from the service. This exception only happens in DEBUG builds of the library and would be ignored in the release build", property.Name)));

            return new Method(signature, body);
        }

        public MethodBodyStatement ThrowNonNullablePropertyIsNull(JsonPropertyExpression property)
            => new InvokeStaticMethodStatement(Type, _throwNonNullablePropertyIsNullMethodName, new[] { property }, CallAsExtension: true);

        private Method BuildGetRequiredStringMethod()
        {
            var signature = new MethodSignature(
                Name: _getRequiredStringMethodName,
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
                    Throw(New.InvalidOperationException(new FormattableStringExpression("The requested operation requires an element of type 'String', but the target element has type '{0}'.", element.ValueKind)))
                },
                Return(value)
            };

            return new Method(signature, body);
        }

        public InvokeStaticMethodExpression GetRequiredString(JsonElementExpression element)
            => new InvokeStaticMethodExpression(Type, _getRequiredStringMethodName, new[] { element }, CallAsExtension: true);
        #endregion

        #region Utf8JsonWriterExtensions method builders
        private const string _writeStringValueMethodName = "WriteStringValue";
        private const string _writeBase64StringValueMethodName = "WriteBase64StringValue";
        private const string _writeNumberValueMethodName = "WriteNumberValue";
        private const string _writeObjectValueMethodName = "WriteObjectValue";

        private IEnumerable<Method> BuildWriteStringValueMethods()
        {
            var writer = new Utf8JsonWriterExpression(KnownParameters.Serializations.Utf8JsonWriter);
            var dateTimeOffsetValueParameter = new Parameter("value", null, typeof(DateTimeOffset), null, ValidationType.None, null);
            yield return new Method(
                new MethodSignature(
                    Name: _writeStringValueMethodName,
                    Modifiers: _methodModifiers,
                    ReturnType: null,
                    Parameters: new[] { KnownParameters.Serializations.Utf8JsonWriter, dateTimeOffsetValueParameter, _formatParameter },
                    Summary: null, Description: null, ReturnDescription: null),
                writer.WriteStringValue(_typeFormattersProvider.ToString(dateTimeOffsetValueParameter, _formatParameter))
                );

            var dateTimeValueParameter = new Parameter("value", null, typeof(DateTime), null, ValidationType.None, null);
            yield return new Method(
                new MethodSignature(
                    Name: _writeStringValueMethodName,
                    Modifiers: _methodModifiers,
                    ReturnType: null,
                    Parameters: new[] { KnownParameters.Serializations.Utf8JsonWriter, dateTimeValueParameter, _formatParameter },
                    Summary: null, Description: null, ReturnDescription: null),
                writer.WriteStringValue(_typeFormattersProvider.ToString(dateTimeValueParameter, _formatParameter))
                );

            var timeSpanValueParameter = new Parameter("value", null, typeof(TimeSpan), null, ValidationType.None, null);
            yield return new Method(
                new MethodSignature(
                    Name: _writeStringValueMethodName,
                    Modifiers: _methodModifiers,
                    ReturnType: null,
                    Parameters: new[] { KnownParameters.Serializations.Utf8JsonWriter, timeSpanValueParameter, _formatParameter },
                    Summary: null, Description: null, ReturnDescription: null),
                writer.WriteStringValue(_typeFormattersProvider.ToString(timeSpanValueParameter, _formatParameter))
                );

            var charValueParameter = new Parameter("value", null, typeof(char), null, ValidationType.None, null);
            var value = new CharExpression(charValueParameter);
            yield return new Method(
                new MethodSignature(
                    Name: _writeStringValueMethodName,
                    Modifiers: _methodModifiers,
                    ReturnType: null,
                    Parameters: new[] { KnownParameters.Serializations.Utf8JsonWriter, charValueParameter },
                    Summary: null, Description: null, ReturnDescription: null),
                writer.WriteStringValue(value.InvokeToString(new MemberExpression(typeof(CultureInfo), nameof(CultureInfo.InvariantCulture))))
                );
        }

        public MethodBodyStatement WriteStringValue(Utf8JsonWriterExpression writer, ValueExpression value, string? format)
            => new InvokeStaticMethodStatement(Type, _writeStringValueMethodName, new[] { writer, value, Literal(format) }, CallAsExtension: true);

        private Method BuildWriteBase64StringValueMethod()
        {
            var valueParameter = new Parameter("value", null, typeof(byte[]), null, ValidationType.None, null);
            var signature = new MethodSignature(
                Name: _writeBase64StringValueMethodName,
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
                        writer.WriteStringValue(_typeFormattersProvider.ToBase64UrlString(value)),
                        Break
                    }),
                    new(Literal("D"), new MethodBodyStatement[]
                    {
                        writer.WriteBase64StringValue(value),
                        Break
                    }),
                    SwitchCase.Default(Throw(New.ArgumentException(format, new FormattableStringExpression("Format is not supported: '{0}'", format))))
                }
            };

            return new Method(signature, body);
        }

        public MethodBodyStatement WriteBase64StringValue(Utf8JsonWriterExpression writer, ValueExpression value, string? format)
            => new InvokeStaticMethodStatement(Type, _writeBase64StringValueMethodName, new[] { writer, value, Literal(format) }, CallAsExtension: true);

        private Method BuildWriteNumberValueMethod()
        {
            var valueParameter = new Parameter("value", null, typeof(DateTimeOffset), null, ValidationType.None, null);
            var signature = new MethodSignature(
                Name: _writeNumberValueMethodName,
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
                    Throw(New.ArgumentOutOfRangeException(format, "Only 'U' format is supported when writing a DateTimeOffset as a Number.")),
                },
                writer.WriteNumberValue(value.ToUnixTimeSeconds())
            };

            return new Method(signature, body);
        }

        public MethodBodyStatement WriteNumberValue(Utf8JsonWriterExpression writer, ValueExpression value, string? format)
            => new InvokeStaticMethodStatement(Type, _writeNumberValueMethodName, new[] { writer, value, Literal(format) }, CallAsExtension: true);

        private Method BuildWriteObjectValueMethod()
        {
            ValueExpression value;
            Utf8JsonWriterExpression writer;
            ParameterReference options;
            MethodSignature signature = GetWriteObjectValueMethodSignature(null, out value, out writer, out options);
            return new Method(signature, new MethodBodyStatement[]
            {
                writer.WriteObjectValue(new TypedValueExpression(typeof(object), value), options)
            });
        }

        private Method BuildWriteObjectValueMethodGeneric()
        {
            ValueExpression value;
            Utf8JsonWriterExpression writer;
            ParameterReference options;
            MethodSignature signature = GetWriteObjectValueMethodSignature(_t, out value, out writer, out options);
            List<SwitchCase> cases = new List<SwitchCase>
            {
                new(Null, new MethodBodyStatement[]
                {
                    writer.WriteNullValue(),
                    Break
                })
            };
            if (Configuration.UseModelReaderWriter)
            {
                cases.Add(
                  BuildWriteObjectValueSwitchCase(new CSharpType(typeof(IJsonModel<>), _t), "jsonModel", jsonModel => new MethodBodyStatement[]
                  {
                        new InvokeInstanceMethodStatement(jsonModel, nameof(IJsonModel<object>.Write), writer, NullCoalescing(options, ModelReaderWriterOptionsExpression.Wire)),
                        Break
                  }));
            }
            if (Configuration.IsBranded)
            {
                cases.Add(
                    BuildWriteObjectValueSwitchCase(typeof(IUtf8JsonSerializable), "serializable", serializable => new MethodBodyStatement[]
                    {
                        new InvokeInstanceMethodStatement(serializable, nameof(IUtf8JsonSerializable.Write), writer),
                        Break
                    }));
            }
            cases.AddRange(new[]
            {
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
                        writer.WriteObjectValue(new TypedValueExpression(typeof(object), pair.Property(nameof(KeyValuePair<string, object>.Value))), options)
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
                        writer.WriteObjectValue(new TypedValueExpression(typeof(object), item), options)
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
                SwitchCase.Default(Throw(New.NotSupportedException(new FormattableStringExpression("Not supported type {0}", value.InvokeGetType()))))
            });

            return new Method(signature, new SwitchStatement(value, cases));

            static SwitchCase BuildWriteObjectValueSwitchCase(CSharpType type, string varName, Func<VariableReference, MethodBodyStatement> bodyFunc)
            {
                var declaration = new DeclarationExpression(type, varName, out var variable);
                var body = bodyFunc(variable);

                return new(declaration, body);
            }
        }

        private MethodSignature GetWriteObjectValueMethodSignature(CSharpType? genericArgument, out ValueExpression value, out Utf8JsonWriterExpression writer, out ParameterReference options)
        {
            var valueParameter = new Parameter("value", null, genericArgument ?? typeof(object), null, ValidationType.None, null);
            var optionsParameter = new Parameter("options", null, typeof(ModelReaderWriterOptions), Constant.Default(new CSharpType(typeof(ModelReaderWriterOptions)).WithNullable(true)), ValidationType.None, null);
            var parameters = Configuration.UseModelReaderWriter
                ? new[] { KnownParameters.Serializations.Utf8JsonWriter, valueParameter, optionsParameter }
                : new[] { KnownParameters.Serializations.Utf8JsonWriter, valueParameter };
            var signature = new MethodSignature(
                Name: _writeObjectValueMethodName,
                Summary: null,
                Description: null,
                Modifiers: _methodModifiers,
                ReturnType: null,
                ReturnDescription: null,
                Parameters: parameters,
                GenericArguments: genericArgument != null ? new[] { genericArgument } : null);
            value = (ValueExpression)valueParameter;
            writer = new Utf8JsonWriterExpression(KnownParameters.Serializations.Utf8JsonWriter);
            options = new ParameterReference(optionsParameter);
            return signature;
        }

        public MethodBodyStatement WriteObjectValue(Utf8JsonWriterExpression writer, TypedValueExpression value, ValueExpression? options = null)
        {
            var parameters = options is null
                ? new ValueExpression[] { writer, value }
                : new ValueExpression[] { writer, value, options };
            return new InvokeStaticMethodStatement(Type, _writeObjectValueMethodName, parameters, CallAsExtension: true, TypeArguments: new[] { value.Type });
        }
        #endregion

        public BoolExpression IsSentinelValue(ValueExpression value)
        {
            return new(new InvokeStaticMethodExpression(Type, _isSentinelValueMethodName, new[] { value }));
        }

        protected override IEnumerable<ExpressionTypeProvider> BuildNestedTypes()
        {
            yield return _typeFormattersProvider; // TODO -- we should remove this and move `TypeFormattersProvider.Instance` to the list of helper providers
        }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Xml;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions;
using AutoRest.CSharp.Common.Output.Expressions.Statements;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Common.Output.Models;
using AutoRest.CSharp.Output.Models.Shared;
using static AutoRest.CSharp.Common.Output.Models.Snippets;
using ValidationType = AutoRest.CSharp.Output.Models.Shared.ValidationType;

namespace AutoRest.CSharp.Output.Models.Types
{
    internal class XmlWriterExtensionsProvider : ExpressionTypeProvider
    {
        private static readonly Lazy<XmlWriterExtensionsProvider> _instance = new(() => new XmlWriterExtensionsProvider());
        public static XmlWriterExtensionsProvider Instance => _instance.Value;

        // TODO -- workaround to be removed
        private readonly TypeFormattersProvider _typeFormatters;

        private XmlWriterExtensionsProvider() : base(Configuration.HelperNamespace, null)
        {
            DeclarationModifiers = TypeSignatureModifiers.Internal | TypeSignatureModifiers.Static;
            _typeFormatters = (TypeFormattersProvider)ModelSerializationExtensionsProvider.Instance.NestedTypes[0];
        }

        protected override string DefaultName { get; } = "XmlWriterExtensions";

        private readonly Parameter _writerParameter = new Parameter("writer", null, typeof(XmlWriter), null, ValidationType.None, null);
        private readonly Parameter _formatParameter = new Parameter("format", null, typeof(string), null, ValidationType.None, null);

        protected override IEnumerable<Method> BuildMethods()
        {
            yield return BuildWriteObjectValueMethod();
            yield return BuildWriteValueMethod<DateTimeOffset>();
            yield return BuildWriteValueMethod<TimeSpan>();
            yield return BuildWriteValueMethod<byte[]>();
        }

        private const string _writeObjectValue = "WriteObjectValue";
        private Method BuildWriteObjectValueMethod()
        {
            var valueParameter = new Parameter("value", null, typeof(object), null, ValidationType.None, null);
            var nameHintParameter = new Parameter("nameHint", null, typeof(string), null, ValidationType.None, null);
            var signature = new MethodSignature(
                Name: _writeObjectValue,
                ReturnType: null,
                Modifiers: MethodSignatureModifiers.Public | MethodSignatureModifiers.Static | MethodSignatureModifiers.Extension,
                Parameters: new[] { _writerParameter, valueParameter, nameHintParameter },
                Summary: null, Description: null, ReturnDescription: null);

            var writer = new XmlWriterExpression(_writerParameter);
            var value = (ValueExpression)valueParameter;
            var body = new SwitchStatement(value)
            {
                new SwitchCase(new DeclarationExpression(Configuration.ApiTypes.IXmlSerializableType, "serializable", out var serializable), new MethodBodyStatement[]
                {
                    new InvokeInstanceMethodStatement(serializable, "Write", writer, nameHintParameter),
                    Return()
                }),
                SwitchCase.Default(Throw(New.NotImplementedException()))
            };

            return new(signature, body);
        }

        private const string _writeValue = "WriteValue";
        private Method BuildWriteValueMethod<T>()
        {
            var valueParameter = new Parameter("value", null, typeof(T), null, ValidationType.None, null);
            var signature = new MethodSignature(
                Name: _writeValue,
                Modifiers: MethodSignatureModifiers.Public | MethodSignatureModifiers.Static | MethodSignatureModifiers.Extension,
                ReturnType: null,
                Parameters: new[] { _writerParameter, valueParameter, _formatParameter },
                Summary: null, Description: null, ReturnDescription: null);

            var writer = new XmlWriterExpression(_writerParameter);
            var body = writer.WriteValue(_typeFormatters.ToString(valueParameter, _formatParameter));

            return new(signature, body);
        }

        public MethodBodyStatement WriteObjectValue(XmlWriterExpression xmlWriter, ValueExpression value, string? nameHint)
            => new InvokeStaticMethodStatement(Type, _writeObjectValue, new[] { xmlWriter, value, Literal(nameHint) }, CallAsExtension: true);

        public MethodBodyStatement WriteValue(XmlWriterExpression xmlWriter, ValueExpression value, string format)
            => new InvokeStaticMethodStatement(Type, _writeValue, new[] { xmlWriter, value, Literal(format) }, CallAsExtension: true);
    }
}

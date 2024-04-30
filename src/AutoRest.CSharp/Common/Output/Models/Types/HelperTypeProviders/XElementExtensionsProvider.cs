// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Xml.Linq;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Common.Output.Models;
using AutoRest.CSharp.Output.Models.Shared;
using static AutoRest.CSharp.Common.Output.Models.Snippets;

namespace AutoRest.CSharp.Output.Models.Types
{
    internal class XElementExtensionsProvider : ExpressionTypeProvider
    {
        private static readonly Lazy<XElementExtensionsProvider> _instance = new(() => new XElementExtensionsProvider());
        public static XElementExtensionsProvider Instance => _instance.Value;

        // TODO -- workaround to be removed
        private readonly TypeFormattersProvider _typeFormatters;

        private XElementExtensionsProvider() : base(Configuration.HelperNamespace, null)
        {
            DeclarationModifiers = TypeSignatureModifiers.Internal | TypeSignatureModifiers.Static;
            _typeFormatters = (TypeFormattersProvider)ModelSerializationExtensionsProvider.Instance.NestedTypes[0];
        }

        protected override string DefaultName { get; } = "XElementExtensions";

        private readonly Parameter _elementParameter = new Parameter("element", null, typeof(XElement), null, ValidationType.None, null);
        private readonly Parameter _formatParameter = new Parameter("format", null, typeof(string), null, ValidationType.None, null);

        protected override IEnumerable<Method> BuildMethods()
        {
            yield return BuildGetBytesFromBase64ValueMethod();
            yield return BuildGetDateTimeOffsetValueMethod();
            yield return BuildGetTimeSpanValueMethod();
        }

        private const string _getBytesFromBase64Value = "GetBytesFromBase64Value";
        private Method BuildGetBytesFromBase64ValueMethod()
        {
            var signature = new MethodSignature(
                Name: _getBytesFromBase64Value,
                ReturnType: typeof(byte[]),
                Modifiers: MethodSignatureModifiers.Public | MethodSignatureModifiers.Static | MethodSignatureModifiers.Extension,
                Parameters: new[] { _elementParameter, _formatParameter },
                Summary: null, Description: null, ReturnDescription: null);

            var element = new XElementExpression(_elementParameter);
            var format = new StringExpression(_formatParameter);
            var body = new SwitchExpression(format, new[]
            {
                new SwitchCaseExpression(Literal("U"), _typeFormatters.FromBase64UrlString(element.Value)),
                new SwitchCaseExpression(Literal("D"), InvokeConvert.FromBase64String(element.Value)),
                SwitchCaseExpression.Default(ThrowExpression(New.ArgumentException(format, new FormattableStringExpression("Format is not supported: '{0}'", format))))
            });

            return new(signature, body);
        }

        private const string _getDateTimeOffsetValue = "GetDateTimeOffsetValue";
        private Method BuildGetDateTimeOffsetValueMethod()
        {
            var signature = new MethodSignature(
                Name: _getDateTimeOffsetValue,
                ReturnType: typeof(DateTimeOffset),
                Modifiers: MethodSignatureModifiers.Public | MethodSignatureModifiers.Static | MethodSignatureModifiers.Extension,
                Parameters: new[] { _elementParameter, _formatParameter },
                Summary: null, Description: null, ReturnDescription: null);

            var element = new XElementExpression(_elementParameter);
            var format = new StringExpression(_formatParameter);
            var body = new SwitchExpression(new StringExpression(_formatParameter), new[]
            {
                new SwitchCaseExpression(Literal("U"), DateTimeOffsetExpression.FromUnixTimeSeconds(element.CastTo(typeof(long)))),
                SwitchCaseExpression.Default(_typeFormatters.ParseDateTimeOffset(element.Value, format))
            });

            return new(signature, body);
        }

        private const string _getTimeSpanValue = "GetTimeSpanValue";
        private Method BuildGetTimeSpanValueMethod()
        {
            var signature = new MethodSignature(
                Name: _getTimeSpanValue,
                Modifiers: MethodSignatureModifiers.Public | MethodSignatureModifiers.Static | MethodSignatureModifiers.Extension,
                ReturnType: typeof(TimeSpan),
                Parameters: new[] { _elementParameter, _formatParameter },
                Summary: null, Description: null, ReturnDescription: null);

            var element = new XElementExpression(_elementParameter);
            var format = new StringExpression(_formatParameter);
            var body = _typeFormatters.ParseTimeSpan(element.Value, format);

            return new(signature, body);
        }

        public ValueExpression GetBytesFromBase64Value(XElementExpression element, string? format)
            => new InvokeStaticMethodExpression(Type, _getBytesFromBase64Value, new ValueExpression[] { element, Literal(format) }, CallAsExtension: true);

        public ValueExpression GetDateTimeOffsetValue(XElementExpression element, string? format)
            => new InvokeStaticMethodExpression(Type, _getDateTimeOffsetValue, new ValueExpression[] { element, Literal(format) }, CallAsExtension: true);

        public ValueExpression GetTimeSpanValue(XElementExpression element, string? format)
            => new InvokeStaticMethodExpression(Type, _getTimeSpanValue, new ValueExpression[] { element, Literal(format) }, CallAsExtension: true);
    }
}

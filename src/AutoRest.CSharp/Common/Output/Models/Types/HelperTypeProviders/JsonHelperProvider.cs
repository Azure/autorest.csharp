// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions;
using AutoRest.CSharp.Common.Output.Expressions.Statements;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Common.Output.Models;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Output.Models.Serialization;
using AutoRest.CSharp.Output.Models.Shared;
using Azure.Core;
using static AutoRest.CSharp.Common.Output.Models.Snippets;

namespace AutoRest.CSharp.Output.Models.Types
{
    internal class JsonHelperProvider : ExpressionTypeProvider
    {
        private static readonly Lazy<JsonHelperProvider> _instance = new(() => new JsonHelperProvider());
        public static JsonHelperProvider Instance => _instance.Value;

        private FieldDeclaration _prettyJsonOptions;
        private FieldDeclaration _compactJsonOptions;
        private VariableReference _stream;
        private VariableReference _writerVariable;
        private Utf8JsonWriterExpression _writer;

        public JsonHelperProvider()
            : base(Configuration.HelperNamespace, null)
        {
            DeclarationModifiers = TypeSignatureModifiers.Internal | TypeSignatureModifiers.Static;
            _prettyJsonOptions = BuildPrettyJsonOptions();
            _compactJsonOptions = BuildCompactJsonOptions();
            _stream = new VariableReference(typeof(MemoryStream), new CodeWriterDeclaration("stream"));
            _writerVariable = new VariableReference(typeof(Utf8JsonWriter), new CodeWriterDeclaration("writer"));
            _writer = new Utf8JsonWriterExpression(_writerVariable);
        }

        protected override string DefaultName => "JsonHelper";

        protected override IEnumerable<FieldDeclaration> BuildFields()
        {
            yield return _prettyJsonOptions;
            yield return _compactJsonOptions;
        }

        private FieldDeclaration BuildCompactJsonOptions()
        {
            return new FieldDeclaration(
                FieldModifiers.Private | FieldModifiers.ReadOnly | FieldModifiers.Static,
                typeof(JsonWriterOptions),
                "PrettyJsonOptions");
        }

        private FieldDeclaration BuildPrettyJsonOptions()
        {
            return new FieldDeclaration(
                FieldModifiers.Private | FieldModifiers.ReadOnly | FieldModifiers.Static,
                typeof(JsonWriterOptions),
                "PrettyJsonOptions",
                New.Instance(
                    typeof(JsonWriterOptions),
                    new Dictionary<string, ValueExpression>()
                    {
                        { "Indented", True }
                    }),
                SerializationFormat.Default);
        }

        protected override IEnumerable<Method> BuildMethods()
        {
            yield return BuildSerializeToString();
            yield return BuildSerializePropertiesToString();
        }

        private Method BuildSerializePropertiesToString()
        {
            MethodSignature signature = GetMethodSignature("SerializePropertiesToString", out var indented, out var data);
            return new Method(signature, new MethodBodyStatement[]
           {
                Declare(_stream, New.Instance(_stream.Type)),
                Declare(_writerVariable, New.Instance(_writer.Type, _stream, new TernaryConditionalOperator(indented, _prettyJsonOptions.Reference, _compactJsonOptions.Reference))),
                _writer.WriteStartObject(),
                _writer.WritePropertyName("properties"),
                _writer.WriteObjectValue(data),
                _writer.WriteEndObject(),
                _writer.Flush(),
                Return(new InvokeStaticMethodExpression(typeof(Encoding), "UTF8.GetString", new[] { _stream.Invoke("ToArray") }))
           });
        }

        private static MethodSignature GetMethodSignature(string name, out ParameterReference indented, out ParameterReference data)
        {
            var indentedParam = new Parameter("indented", null, typeof(bool), new Constant(false, typeof(bool)), ValidationType.None, null);
            var dataParam = new Parameter("data", null, typeof(IUtf8JsonSerializable), null, ValidationType.None, null);
            var parameters = new List<Parameter> { dataParam, indentedParam };
            indented = new ParameterReference(indentedParam);
            data = new ParameterReference(dataParam);
            return new MethodSignature(name, null, null, MethodSignatureModifiers.Public | MethodSignatureModifiers.Static, typeof(string), null, parameters);
        }

        private Method BuildSerializeToString()
        {
            MethodSignature signature = GetMethodSignature("SerializeToString", out var indented, out var data);
            return new Method(signature, new MethodBodyStatement[]
            {
                Declare(_stream, New.Instance(_stream.Type)),
                Declare(_writerVariable, New.Instance(_writer.Type, _stream, new TernaryConditionalOperator(indented, _prettyJsonOptions.Reference, _compactJsonOptions.Reference))),
                _writer.WriteObjectValue(data),
                _writer.Flush(),
                Return(new InvokeStaticMethodExpression(typeof(Encoding), "UTF8.GetString", new[] { _stream.Invoke("ToArray") }))
            });
        }
    }
}

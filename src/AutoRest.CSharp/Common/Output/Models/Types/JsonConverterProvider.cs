// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions;
using AutoRest.CSharp.Common.Output.Expressions.Statements;
using AutoRest.CSharp.Common.Output.Models;
using AutoRest.CSharp.Common.Output.Models.Types;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input.Source;
using AutoRest.CSharp.Output.Models.Shared;
using static AutoRest.CSharp.Common.Output.Models.Snippets;

namespace AutoRest.CSharp.Output.Models.Types
{
    internal class JsonConverterProvider : ExpressionTypeProvider
    {
        private readonly bool _includeSerializer;
        private readonly bool _includeDeserializer;
        private readonly SerializableObjectType _model;

        public JsonConverterProvider(SerializableObjectType model, SourceInputModel? sourceInputModel) : base(model.Declaration.Namespace, sourceInputModel)
        {
            _model = model;
            _includeSerializer = model.IncludeSerializer;
            _includeDeserializer = model.IncludeDeserializer;
            DefaultName = $"{model.Declaration.Name}Converter";
            Inherits = new CSharpType(typeof(JsonConverter<>), model.Type);
        }

        protected override string DefaultName { get; }

        protected override string DefaultAccessibility => "internal";

        protected override IEnumerable<Method> BuildMethods()
        {
            var modelParameter = new Parameter("model", null, _model.Type, null, ValidationType.None, null);
            var writeMethodSignature = new MethodSignature(
                Name: nameof(JsonConverter<object>.Write),
                Summary: null,
                Description: null,
                Modifiers: MethodSignatureModifiers.Public | MethodSignatureModifiers.Override,
                ReturnType: null,
                ReturnDescription: null,
                Parameters: new[]
                {
                    KnownParameters.Serializations.Utf8JsonWriter,
                    modelParameter,
                    KnownParameters.Serializations.JsonOptions
                });
            var writer = new Utf8JsonWriterExpression(KnownParameters.Serializations.Utf8JsonWriter);
            MethodBodyStatement writeMethodBody;
            if (_includeSerializer)
            {
                writeMethodBody = writer.WriteObjectValue(modelParameter, ModelReaderWriterOptionsExpression.Wire);
            }
            else
            {
                writeMethodBody = Throw(New.Instance(typeof(NotImplementedException)));
            }
            yield return new Method(writeMethodSignature, writeMethodBody);

            var readMethodSignature = new MethodSignature(
                Name: nameof(JsonConverter<object>.Read),
                Summary: null,
                Description: null,
                Modifiers: MethodSignatureModifiers.Public | MethodSignatureModifiers.Override,
                ReturnType: _model.Type,
                ReturnDescription: null,
                Parameters: new[]
                {
                    KnownParameters.Serializations.Utf8JsonReader,
                    new Parameter("typeToConvert", null, typeof(Type), null, ValidationType.None, null),
                    KnownParameters.Serializations.JsonOptions
                });
            MethodBodyStatement readMethodBody;
            if (_includeDeserializer)
            {
                readMethodBody = new MethodBodyStatement[]
                {
                    UsingVar("document", JsonDocumentExpression.ParseValue(KnownParameters.Serializations.Utf8JsonReader), out var doc),
                    Return(SerializableObjectTypeExpression.Deserialize(_model, doc.RootElement))
                };
            }
            else
            {
                readMethodBody = Throw(New.Instance(typeof(NotImplementedException)));
            }
            yield return new Method(readMethodSignature, readMethodBody);
        }
    }
}

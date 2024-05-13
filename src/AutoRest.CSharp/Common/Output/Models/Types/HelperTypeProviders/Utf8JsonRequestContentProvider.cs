// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.ClientModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions;
using AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions.Azure;
using AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions.System;
using AutoRest.CSharp.Common.Output.Expressions.Statements;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Common.Output.Models;
using AutoRest.CSharp.Output.Models.Shared;
using Azure.Core;
using static AutoRest.CSharp.Common.Output.Models.Snippets;

namespace AutoRest.CSharp.Output.Models.Types
{
    internal class Utf8JsonRequestContentProvider : ExpressionTypeProvider
    {
        private static readonly Lazy<Utf8JsonRequestContentProvider> _instance = new Lazy<Utf8JsonRequestContentProvider>(() => new Utf8JsonRequestContentProvider());
        public static Utf8JsonRequestContentProvider Instance => _instance.Value;

        private Utf8JsonRequestContentProvider() : base(Configuration.HelperNamespace, null)
        {
            DeclarationModifiers = TypeSignatureModifiers.Internal;
            DefaultName = $"Utf8Json{Configuration.ApiTypes.RequestContentType.Name}";
            Inherits = Configuration.ApiTypes.RequestContentType;

            _streamField = new FieldDeclaration(
                modifiers: FieldModifiers.Private | FieldModifiers.ReadOnly,
                type: typeof(MemoryStream),
                name: "_stream");
            _contentField = new FieldDeclaration(
                modifiers: FieldModifiers.Private | FieldModifiers.ReadOnly,
                type: Inherits,
                name: "_content");
            _writerProperty = new PropertyDeclaration(
                description: null,
                modifiers: MethodSignatureModifiers.Public,
                propertyType: typeof(Utf8JsonWriter),
                name: _jsonWriterName,
                propertyBody: new AutoPropertyBody(false));
        }

        private readonly FieldDeclaration _streamField;
        private readonly FieldDeclaration _contentField;
        private readonly PropertyDeclaration _writerProperty;

        protected override string DefaultName { get; }

        protected override IEnumerable<FieldDeclaration> BuildFields()
        {
            yield return _streamField;
            yield return _contentField;
        }

        protected override IEnumerable<PropertyDeclaration> BuildProperties()
        {
            yield return _writerProperty;
        }

        protected override IEnumerable<Method> BuildConstructors()
        {
            var signature = new ConstructorSignature(
                Type: Type,
                Modifiers: MethodSignatureModifiers.Public,
                Parameters: Array.Empty<Parameter>(),
                Summary: null, Description: null);

            var stream = (ValueExpression)_streamField;
            var content = (ValueExpression)_contentField;
            var writer = (ValueExpression)_writerProperty;
            var body = new MethodBodyStatement[]
            {
                Assign(stream, New.Instance(typeof(MemoryStream))),
                Assign(content, new InvokeStaticMethodExpression(null, Configuration.ApiTypes.RequestContentCreateName, new[] { stream })),
                Assign(writer, New.Instance(typeof(Utf8JsonWriter), stream))
            };
            yield return new Method(signature, body);
        }

        protected override IEnumerable<Method> BuildMethods()
        {
            yield return BuildWriteToAsyncMethod();
            yield return BuildWriteToMethod();
            yield return BuildTryComputeLengthMethod();
            yield return BuildDisposeMethod();
        }

        public Utf8JsonWriterExpression JsonWriterProperty(ValueExpression instance)
            => new(instance.Property(_jsonWriterName));

        private const string _jsonWriterName = "JsonWriter";

        private static readonly string WriteToAsync = Configuration.IsBranded ? nameof(RequestContent.WriteToAsync) : nameof(BinaryContent.WriteToAsync);
        private static readonly string WriteTo = Configuration.IsBranded ? nameof(RequestContent.WriteTo) : nameof(BinaryContent.WriteTo);
        private static readonly string TryComputeLength = Configuration.IsBranded ? nameof(RequestContent.TryComputeLength) : nameof(BinaryContent.TryComputeLength);
        private static readonly string Dispose = nameof(IDisposable.Dispose);

        private Method BuildWriteToAsyncMethod()
        {
            var signature = new MethodSignature(
                Name: WriteToAsync,
                Modifiers: MethodSignatureModifiers.Public | MethodSignatureModifiers.Override | MethodSignatureModifiers.Async,
                ReturnType: typeof(Task),
                Parameters: new[] { _streamParameter, KnownParameters.CancellationTokenParameter },
                Summary: null, Description: null, ReturnDescription: null);

            var writer = new Utf8JsonWriterExpression(_writerProperty);
            var stream = new StreamExpression(_streamParameter);
            var content = (ValueExpression)_contentField;
            var cancellationToken = (ValueExpression)KnownParameters.CancellationTokenParameter;
            var body = new MethodBodyStatement[]
            {
                writer.FlushAsync(),
                new InvokeInstanceMethodStatement(content, WriteToAsync, new[] { stream, cancellationToken }, true)
            };

            return new Method(signature, body);
        }

        private Method BuildWriteToMethod()
        {
            var signature = new MethodSignature(
                Name: WriteTo,
                Modifiers: MethodSignatureModifiers.Public | MethodSignatureModifiers.Override,
                ReturnType: null,
                Parameters: new[] { _streamParameter, KnownParameters.CancellationTokenParameter },
                Summary: null, Description: null, ReturnDescription: null);

            var writer = new Utf8JsonWriterExpression(_writerProperty);
            var stream = new StreamExpression(_streamParameter);
            var content = (ValueExpression)_contentField;
            var cancellationToken = (ValueExpression)KnownParameters.CancellationTokenParameter;
            var body = new MethodBodyStatement[]
            {
                writer.Flush(),
                new InvokeInstanceMethodStatement(content, WriteTo, new[] { stream, cancellationToken }, false)
            };

            return new Method(signature, body);
        }

        private Method BuildTryComputeLengthMethod()
        {
            var lengthParameter = new Parameter("length", null, typeof(long), null, ValidationType.None, null, IsOut: true);
            var signature = new MethodSignature(
                Name: TryComputeLength,
                Modifiers: MethodSignatureModifiers.Public | MethodSignatureModifiers.Override,
                Parameters: new[] { lengthParameter },
                ReturnType: typeof(bool),
                Summary: null, Description: null, ReturnDescription: null);

            var length = (ValueExpression)lengthParameter;
            var writer = new Utf8JsonWriterExpression(_writerProperty);
            var body = new MethodBodyStatement[]
            {
                Assign(length, new BinaryOperatorExpression("+", writer.BytesCommitted, writer.BytesPending)),
                Return(True)
            };

            return new Method(signature, body);
        }

        private Method BuildDisposeMethod()
        {
            var signature = new MethodSignature(
                Name: Dispose,
                Modifiers: MethodSignatureModifiers.Public | MethodSignatureModifiers.Override,
                Parameters: Array.Empty<Parameter>(),
                ReturnType: null,
                Summary: null, Description: null, ReturnDescription: null);

            var stream = new StreamExpression(_streamField);
            TypedValueExpression content = Configuration.IsBranded
                ? new RequestContentExpression(_contentField)
                : new BinaryContentExpression(_contentField);
            var writer = new Utf8JsonWriterExpression(_writerProperty);
            var body = new MethodBodyStatement[]
            {
                InvokeDispose(writer),
                InvokeDispose(content),
                InvokeDispose(stream)
            };
            return new Method(signature, body);

            static MethodBodyStatement InvokeDispose(TypedValueExpression instance)
                => new InvokeInstanceMethodStatement(instance, Dispose);
        }

        private readonly Parameter _streamParameter = new Parameter("stream", null, typeof(Stream), null, ValidationType.None, null);
    }
}

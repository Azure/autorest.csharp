// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions;
using AutoRest.CSharp.Common.Output.Expressions.Statements;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Serialization;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;
using static AutoRest.CSharp.Common.Output.Models.Snippets;

namespace AutoRest.CSharp.Common.Output.Models.Types.HelperTypeProviders
{
    internal class MultipartFormDataBinaryContentProvider : ExpressionTypeProvider
    {
        private static readonly Lazy<MultipartFormDataBinaryContentProvider> _instance = new(() => new MultipartFormDataBinaryContentProvider());
        private class FormDataItemTemplate<T> { }
        public static MultipartFormDataBinaryContentProvider Instance => _instance.Value;
        private MultipartFormDataBinaryContentProvider() : base(Configuration.HelperNamespace, null)
        {
            Inherits = Configuration.ApiTypes.RequestContentType;
            _multipartContentField = new FieldDeclaration(
                modifiers: FieldModifiers.Private | FieldModifiers.ReadOnly,
                type: typeof(MultipartFormDataContent),
                name: "_content");
            _randomField = new FieldDeclaration(
                modifiers: FieldModifiers.Private | FieldModifiers.Static | FieldModifiers.ReadOnly,
                type: typeof(Random),
                name: "_random");
            _boundaryValuesFields = new FieldDeclaration(
                modifiers: FieldModifiers.Private | FieldModifiers.Static | FieldModifiers.ReadOnly,
                type: typeof(char[]),
                name: "_boundaryValues",
                initializationValue: Snippets.Literal("0123456789=ABCDEFGHIJKLMNOPQRSTUVWXYZ_abcdefghijklmnopqrstuvwxyz").ToCharArray(),
                serializationFormat: SerializationFormat.Default);
            _contentTypeProperty = new PropertyDeclaration(
                description: null,
                modifiers: MethodSignatureModifiers.Public,
                propertyType: typeof(string),
                name: _contentTypePropertyName,
                propertyBody: new MethodPropertyBody(new MethodBodyStatement[]
                {
                    /*TODO add parameter validation*/
                    Return(new FormattableStringExpression($"_multipartContent.Headers.ContentType!.ToString()"))
                }));
            _httpContentProperty = new PropertyDeclaration(
                description: null,
                modifiers: MethodSignatureModifiers.Internal,
                propertyType: typeof(HttpContent),
                name: _httpContentPropertyName,
                propertyBody: new ExpressionPropertyBody(_multipartContentField)
                );
        }
        private readonly FieldDeclaration _multipartContentField;
        private readonly FieldDeclaration _randomField;
        private readonly FieldDeclaration _boundaryValuesFields;

        private readonly PropertyDeclaration _contentTypeProperty;
        private const string _contentTypePropertyName = "ContentType";
        private readonly PropertyDeclaration _httpContentProperty;
        private const string _httpContentPropertyName = "HttpContent";
        protected override string DefaultName { get; } = "MultipartFormDataRequestContent";
        private const string _createBoundaryMethodName = "CreateBoundary";
        protected override IEnumerable<FieldDeclaration> BuildFields()
        {
            yield return _multipartContentField;
            yield return _randomField;
            yield return _boundaryValuesFields;
        }
        protected override IEnumerable<PropertyDeclaration> BuildProperties()
        {
            yield return _contentTypeProperty;
            yield return _httpContentProperty;
        }
        protected override IEnumerable<Method> BuildConstructors()
        {
            var signature = new ConstructorSignature(
                Type: Type,
            Modifiers: MethodSignatureModifiers.Public,
            Parameters: Array.Empty<Parameter>(),
                Summary: null, Description: null);
            var body = new MethodBodyStatement[]
            {
                Assign(_multipartContentField, New.Instance(typeof(MultipartFormDataContent), new[]{CreateBoundary()})),
            };
            yield return new Method(signature, body);
        }
        protected override IEnumerable<Method> BuildMethods()
        {
            yield return BuildCreateBoundaryMethod();
            foreach (var method in BuildAddMethods())
            {
                yield return method;
            }
            yield return BuildAddFilenameHeaderMethod();
            yield return BuildTryComputeLengthMethod();
            yield return BuildWriteToMethod();
            yield return BuildWriteToAsyncMethod();
            yield return BuildDisposeMethod();
        }
        private Method BuildCreateBoundaryMethod()
        {
            var signature = new MethodSignature(
                Name: _createBoundaryMethodName,
                Summary: null,
                Description: null,
                Modifiers: MethodSignatureModifiers.Private | MethodSignatureModifiers.Static,
                ReturnType: typeof(string),
                ReturnDescription: null,
                Parameters: Array.Empty<Parameter>());
            var i = new VariableReference(typeof(int), "i");
            var body = new MethodBodyStatement[]
            {
                Declare(typeof(Span<char>), "chars", New.Array(typeof(char), Literal(70)), out var chars),
                Declare(typeof(byte[]), "random", New.Array(typeof(byte), Literal(70)), out var random),
                new InvokeInstanceMethodStatement(_randomField, nameof(Random.NextBytes), new[]{random }, false),
                Declare(typeof(int), "mask", new BinaryOperatorExpression(">>", Literal(255), Literal(2)), out var mask),
                new ForStatement(
                    new AssignmentExpression(i, Int(0)),
                    LessThan(i, Literal(70)),
                    new UnaryOperatorExpression("++", i,true))
                {
                    Assign(new ArrayElementExpression(chars, i), new ArrayElementExpression(_boundaryValuesFields, new BinaryOperatorExpression("&", new ArrayElementExpression(random, i), mask))),
                },
                Return(chars.Untyped.InvokeToString())
            };
            return new Method(signature, body);
        }
        private IEnumerable<Method> BuildAddMethods()
        {
            yield return BuildAddMethod<string>();
            yield return BuildAddMethod<int>();
            yield return BuildAddMethod<long>();
            yield return BuildAddMethod<float>();
            yield return BuildAddMethod<double>();
            yield return BuildAddMethod<decimal>();
            yield return BuildAddMethod<bool>();
            yield return BuildAddMethod<Guid>();
            yield return BuildAddMethod<DateTime>();
            yield return BuildAddMethod<TimeSpan>();
            yield return BuildAddMethod<Stream>();
            yield return BuildAddMethod<FileInfo>();
            yield return BuildAddMethod<byte[]>();
            yield return BuildAddMethod<JsonElement>();
            yield return BuildAddHttpContentMethod();
        }
        private Method BuildAddMethod<T>()
        {
            var signature = new MethodSignature(
                Name: "Add",
                Summary: null,
                Description: null,
                Modifiers: MethodSignatureModifiers.Public,
                ReturnType: null,
                ReturnDescription: null,
                Parameters: new[]
                {
                    new Parameter("content", null, typeof(T), null, ValidationType.None, null),
                    new Parameter("name", null, typeof(string),null, ValidationType.None, null),
                    new Parameter("filename", null, ((CSharpType)typeof(string)).WithNullable(true), Constant.Default(typeof(string)), ValidationType.None, null),
                });
            var body = new MethodBodyStatement[]
            {
            };
            return new Method(signature, body);
        }
        private Method BuildAddHttpContentMethod()
        {
            var contentParam = new Parameter("content", null, typeof(HttpContent), null, ValidationType.None, null);
            var nameParam = new Parameter("name", null, typeof(string), null, ValidationType.None, null);
            var filenameParam = new Parameter("filename", null, ((CSharpType)typeof(string)).WithNullable(true), null, ValidationType.None, null);
            var signature = new MethodSignature(
                Name: "Add",
                Summary: null,
                Description: null,
                Modifiers: MethodSignatureModifiers.Private,
                ReturnType: null,
                ReturnDescription: null,
                Parameters: new[]
                {
                    contentParam,
                    nameParam,
                    filenameParam,
                });
            var multipartContentExpression = new MultipartFormDataContentExpression(_multipartContentField);
            var body = new MethodBodyStatement[]
            {
                multipartContentExpression.Add(contentParam, nameParam, filenameParam)
            };
            return new Method(signature, body);
        }
        private Method BuildAddFilenameHeaderMethod()
        {
            var signature = new MethodSignature(
                Name: "AddFilenameHeader",
                Summary: null,
                Description: null,
                Modifiers: MethodSignatureModifiers.Public | MethodSignatureModifiers.Override,
                ReturnType: null,
                ReturnDescription: null,
                Parameters: new[]
                {
                    new Parameter("content", null, typeof(HttpContent), null, ValidationType.None, null),
                    new Parameter("name", null, typeof(string),null, ValidationType.None, null),
                    new Parameter("filename", null, typeof(string), null, ValidationType.None, null),
                });
            var body = new MethodBodyStatement[]
            {
            };
            return new Method(signature, body);
        }

        private Method BuildTryComputeLengthMethod()
        {
            var signature = new MethodSignature(
                Name: "TryComputeLength",
                Summary: null,
                Description: null,
                Modifiers: MethodSignatureModifiers.Public | MethodSignatureModifiers.Override,
                ReturnType: null,
                ReturnDescription: null,
                Parameters: new[]
                {
                    new Parameter("length", null, typeof(long), null, ValidationType.None, null, IsOut:true),
                });
            var body = new MethodBodyStatement[]
            {
            };
            return new Method(signature, body);
        }
        private Method BuildWriteToMethod()
        {
            var signature = new MethodSignature(
                Name: "WriteTo",
                Summary: null,
                Description: null,
                Modifiers: MethodSignatureModifiers.Public | MethodSignatureModifiers.Override,
                ReturnType: null,
                ReturnDescription: null,
                Parameters: new[]
                {
                    new Parameter("stream", null, typeof(Stream), null, ValidationType.None, null),
                    new Parameter("cancellationToken ", null, typeof(CancellationToken), null, ValidationType.None, null),
                });
            var body = new MethodBodyStatement[]
            {
            };
            return new Method(signature, body);
        }

        private Method BuildWriteToAsyncMethod()
        {
            var signature = new MethodSignature(
                Name: "WriteToAsync",
                Summary: null,
                Description: null,
                Modifiers: MethodSignatureModifiers.Public | MethodSignatureModifiers.Override | MethodSignatureModifiers.Async,
                ReturnType: typeof(Task),
                ReturnDescription: null,
                Parameters: new[]
                {
                    new Parameter("stream", null, typeof(Stream), null, ValidationType.None, null),
                    new Parameter("cancellationToken ", null, typeof(CancellationToken), null, ValidationType.None, null),
                });
            var body = new MethodBodyStatement[]
            {
            };
            return new Method(signature, body);
        }

        private Method BuildDisposeMethod()
        {
            var signature = new MethodSignature(
                Name: "Dispose",
                Summary: null,
                Description: null,
                Modifiers: MethodSignatureModifiers.Public | MethodSignatureModifiers.Override,
                ReturnType: null,
                ReturnDescription: null,
                Parameters: Array.Empty<Parameter>());
            var body = new MethodBodyStatement[]
            {
            };
            return new Method(signature, body);
        }
        public ValueExpression CreateBoundary()
            => new InvokeStaticMethodExpression(Type, _createBoundaryMethodName, new ValueExpression[] { });
    }
}

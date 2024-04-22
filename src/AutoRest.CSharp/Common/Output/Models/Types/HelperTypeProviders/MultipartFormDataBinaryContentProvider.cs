// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions;
using AutoRest.CSharp.Common.Output.Expressions.Statements;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;
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
            DeclarationModifiers = TypeSignatureModifiers.Internal;
            Inherits = Configuration.ApiTypes.RequestContentType;
            _multipartContentField = new FieldDeclaration(
                modifiers: FieldModifiers.Private | FieldModifiers.ReadOnly,
                type: typeof(MultipartFormDataContent),
                name: "_multipartContent");
            _randomField = new FieldDeclaration(
                modifiers: FieldModifiers.Private | FieldModifiers.Static | FieldModifiers.ReadOnly,
                type: typeof(Random),
                name: "_random",
                initializationValue: New.Instance(typeof(Random), Array.Empty<ValueExpression>()),
                serializationFormat: SerializationFormat.Default);
            _boundaryValuesFields = new FieldDeclaration(
                modifiers: FieldModifiers.Private | FieldModifiers.Static | FieldModifiers.ReadOnly,
                type: typeof(char[]),
                name: "_boundaryValues",
                initializationValue: Literal("0123456789=ABCDEFGHIJKLMNOPQRSTUVWXYZ_abcdefghijklmnopqrstuvwxyz").ToCharArray(),
                serializationFormat: SerializationFormat.Default);
            ValueExpression contentTypeHeaderExpression = new UnaryOperatorExpression("!", new MultipartFormDataContentExpression(_multipartContentField).Property("Headers").Property("ContentType"), true);
            ValueExpression contentTypeHeaderValueExpression = new InvokeInstanceMethodExpression(contentTypeHeaderExpression, nameof(MediaTypeHeaderValue.ToString), Array.Empty<ValueExpression>(), null, false);
            _contentTypeProperty = new PropertyDeclaration(
                description: null,
                modifiers: MethodSignatureModifiers.Public,
                propertyType: typeof(string),
                name: _contentTypePropertyName,
                propertyBody: new MethodPropertyBody(new MethodBodyStatement[]
                {
                    Return(contentTypeHeaderValueExpression)
                }));
            _httpContentProperty = new PropertyDeclaration(
                description: null,
                modifiers: MethodSignatureModifiers.Internal,
                propertyType: typeof(HttpContent),
                name: _httpContentPropertyName,
                propertyBody: new ExpressionPropertyBody(_multipartContentField)
                );
            _multipartContentExpression = new MultipartFormDataContentExpression(_multipartContentField);
        }
        private readonly FieldDeclaration _multipartContentField;
        private readonly FieldDeclaration _randomField;
        private readonly FieldDeclaration _boundaryValuesFields;

        private readonly PropertyDeclaration _contentTypeProperty;
        private const string _contentTypePropertyName = "ContentType";
        private readonly PropertyDeclaration _httpContentProperty;
        private const string _httpContentPropertyName = "HttpContent";
        protected override string DefaultName { get; } = "MultipartFormDataBinaryContent";
        private const string _createBoundaryMethodName = "CreateBoundary";
        private const string _addMethodName = "Add";
        private const string _addFilenameHeaderMethodName = "AddFilenameHeader";
        private const string _addContentTypeHeaderMethodName = "AddContentTypeHeader";
        private const string _writeToMethodName = "WriteTo";
        private const string _writeToAsyncMethodName = "WriteToAsync";

        private readonly MultipartFormDataContentExpression _multipartContentExpression;
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
            yield return BuildAddContentTypeHeaderMethod();
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
            //yield return BuildAddMethod<Guid>();
            //yield return BuildAddMethod<DateTime>();
            //yield return BuildAddMethod<TimeSpan>();
            yield return BuildAddMethod<Stream>();
            //yield return BuildAddMethod<FileInfo>();
            yield return BuildAddMethod<byte[]>();
            //yield return BuildAddMethod<JsonElement>();
            yield return BuildAddMethod<BinaryData>();
            yield return BuildAddHttpContentMethod();
        }
        private Method BuildAddMethod<T>()
        {
            var contentParam = new Parameter("content", null, typeof(T), null, ValidationType.None, null);
            var nameParam = new Parameter("name", null, typeof(string), null, ValidationType.None, null);
            var filenameParam = new Parameter("filename", null, new CSharpType(typeof(string), true),
                        Constant.Default(new CSharpType(typeof(string), true)), ValidationType.None, null);
            var contentTypeParam = new Parameter("contentType", null, new CSharpType(typeof(string), true),
                        Constant.Default(new CSharpType(typeof(string), true)), ValidationType.None, null);
            var signature = new MethodSignature(
                Name: _addMethodName,
                Summary: null,
                Description: null,
                Modifiers: MethodSignatureModifiers.Public,
                ReturnType: null,
                ReturnDescription: null,
                Parameters: new[]
                {
                    contentParam,
                    nameParam,
                    filenameParam,
                    contentTypeParam
                });
            MethodBodyStatement? valueDelareStatement = null;
            ValueExpression contentExpression;
            contentExpression = New.Instance(typeof(ByteArrayContent), contentParam);
            switch (typeof(T))
            {
                case Type type when type == typeof(Stream):
                    contentExpression = New.Instance(typeof(StreamContent), contentParam);
                    break;
                case Type type when type == typeof(string):
                    contentExpression = New.Instance(typeof(StringContent), contentParam);
                    break;
                case Type btype when btype == typeof(bool):
                    var boolToStringValue = new TernaryConditionalOperator(contentParam, Literal("true"), Literal("false"));
                    valueDelareStatement = Declare(typeof(string), "value", boolToStringValue, out TypedValueExpression boolVariable);
                    contentExpression = New.Instance(typeof(StringContent), boolVariable);
                    break;
                case Type itype when itype == typeof(int):
                case Type ftype when ftype == typeof(float):
                case Type ltype when ltype == typeof(long):
                case Type dtype when dtype == typeof(double):
                case Type detype when detype == typeof(decimal):
                    ValueExpression invariantCulture = new MemberExpression(typeof(CultureInfo), nameof(CultureInfo.InvariantCulture));
                    var invariantCultureValue = new InvokeInstanceMethodExpression(contentParam, nameof(Int32.ToString), new[] { Literal("G"), invariantCulture }, null, false);
                    valueDelareStatement = Declare(typeof(string), "value", invariantCultureValue, out TypedValueExpression variable);
                    contentExpression = New.Instance(typeof(StringContent), variable);
                    break;
                case Type bdtype when bdtype == typeof(BinaryData):
                    contentExpression = New.Instance(typeof(ByteArrayContent), new BinaryDataExpression(contentParam).ToArray());
                    break;
            }
            List<MethodBodyStatement> addContentStatements = new List<MethodBodyStatement>();
            if (valueDelareStatement != null)
            {
                addContentStatements.Add(valueDelareStatement);
            }
            addContentStatements.Add(new InvokeInstanceMethodStatement(null, _addMethodName, new[] { contentExpression, nameParam, filenameParam, contentTypeParam }, false));
            var body = new MethodBodyStatement[]
            {
                Argument.AssertNotNull(contentParam),
                Argument.AssertNotNullOrEmpty(nameParam),
                new EmptyLineStatement(),
                addContentStatements.ToArray(),
            };
            return new Method(signature, body);
        }
        private Method BuildAddHttpContentMethod()
        {
            var contentParam = new Parameter("content", null, typeof(HttpContent), null, ValidationType.None, null);
            var nameParam = new Parameter("name", null, typeof(string), null, ValidationType.None, null);
            var filenameParam = new Parameter("filename", null, new CSharpType(typeof(string), true), null, ValidationType.None, null);
            var contentTypeParam = new Parameter("contentType", null, new CSharpType(typeof(string), true), null, ValidationType.None, null);
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
                    contentTypeParam,
                });
            var multipartContentExpression = new MultipartFormDataContentExpression(_multipartContentField);
            var body = new MethodBodyStatement[]
            {
                new IfStatement(NotEqual(filenameParam, Null))
                {
                    Argument.AssertNotNullOrEmpty(filenameParam),
                    AddFilenameHeader(contentParam, nameParam, filenameParam),
                },
                new IfStatement(NotEqual(contentTypeParam, Null))
                {
                    Argument.AssertNotNullOrEmpty(contentTypeParam),
                    AddContentTypeHeader(contentParam, contentTypeParam),
                },
                multipartContentExpression.Add(contentParam, nameParam)
            };
            return new Method(signature, body);
        }
        private Method BuildAddFilenameHeaderMethod()
        {
            var contentParam = new Parameter("content", null, typeof(HttpContent), null, ValidationType.None, null);
            var nameParam = new Parameter("name", null, typeof(string), null, ValidationType.None, null);
            var filenameParam = new Parameter("filename", null, typeof(string), null, ValidationType.None, null);
            var signature = new MethodSignature(
                Name: "AddFilenameHeader",
                Summary: null,
                Description: null,
                Modifiers: MethodSignatureModifiers.Public | MethodSignatureModifiers.Static,
                ReturnType: null,
                ReturnDescription: null,
                Parameters: new[]
                {
                    contentParam,
                    nameParam,
                    filenameParam,
                });
            var initialProperties = new Dictionary<string, ValueExpression>
            {
                { "Name", nameParam },
                { "FileName", filenameParam },
            };
            ValueExpression ContentDispositionHeaderExpression = ((ValueExpression)contentParam).Property("Headers").Property("ContentDisposition");
            var body = new MethodBodyStatement[]
            {
                Declare(typeof(ContentDispositionHeaderValue), "header", New.Instance(typeof(ContentDispositionHeaderValue), new[]{ Literal("form-data") }, initialProperties), out var header),
                Assign(ContentDispositionHeaderExpression, header),
            };
            return new Method(signature, body);
        }

        private Method BuildAddContentTypeHeaderMethod()
        {
            var contentParam = new Parameter("content", null, typeof(HttpContent), null, ValidationType.None, null);
            var contentTypeParam = new Parameter("contentType", null, typeof(string), null, ValidationType.None, null);
            var signature = new MethodSignature(
                Name: _addContentTypeHeaderMethodName,
                Summary: null,
                Description: null,
                Modifiers: MethodSignatureModifiers.Public | MethodSignatureModifiers.Static,
                ReturnType: null,
                ReturnDescription: null,
                Parameters: new[]
                {
                    contentParam,
                    contentTypeParam,
                });
            var contentTypeExpression = (ValueExpression)contentTypeParam;
            ValueExpression ContentTypeHeaderExpression = ((ValueExpression)contentParam).Property("Headers").Property("ContentType");
            var body = new MethodBodyStatement[]
            {
                Declare(typeof(MediaTypeHeaderValue), "header", New.Instance(typeof(MediaTypeHeaderValue), new[]{ contentTypeExpression }), out var header),
                Assign(ContentTypeHeaderExpression, header),
            };
            return new Method(signature, body);
        }

        private Method BuildTryComputeLengthMethod()
        {
            var lengthParameter = new Parameter("length", null, typeof(long), null, ValidationType.None, null, IsOut: true);
            var signature = new MethodSignature(
                Name: "TryComputeLength",
                Summary: null,
                Description: null,
                Modifiers: MethodSignatureModifiers.Public | MethodSignatureModifiers.Override,
                ReturnType: typeof(bool),
                ReturnDescription: null,
                Parameters: new[]
                {
                    lengthParameter,
                });
            ValueExpression contentLengthHeaderExpression = new MultipartFormDataContentExpression(_multipartContentField).Property("Headers").Property("ContentLength");
            var declaration = new CodeWriterDeclaration("contentLength");
            VariableReference contentLengthVariable = new VariableReference(typeof(long), declaration);
            var contentLengthDeclaration = new DeclarationExpression(contentLengthVariable, false);
            var body = new MethodBodyStatement[]
            {
                new IfStatement(BoolExpression.Is(contentLengthHeaderExpression, contentLengthDeclaration))
                {
                    Assign(lengthParameter, contentLengthVariable),
                    Return(Literal(true)),
                },
                Assign(lengthParameter, Literal(0)),
                Return(Literal(false)),
            };
            return new Method(signature, body);
        }
        private Method BuildWriteToMethod()
        {
            var streamParam = new Parameter("stream", null, typeof(Stream), null, ValidationType.None, null);
            var streamExpression = (ValueExpression)streamParam;
            var cancellationTokenParam = KnownParameters.CancellationTokenParameter;
            var cancellatinTokenExpression = (ValueExpression)cancellationTokenParam;
            var signature = new MethodSignature(
                Name: "WriteTo",
                Summary: null,
                Description: null,
                Modifiers: MethodSignatureModifiers.Public | MethodSignatureModifiers.Override,
                ReturnType: null,
                ReturnDescription: null,
                Parameters: new[]
                {
                    streamParam,
                    cancellationTokenParam
                });
            ValueExpression getTaskWaiterExpression = new InvokeInstanceMethodExpression(_multipartContentExpression.CopyToAsyncExpression(streamParam), nameof(Task.GetAwaiter), Array.Empty<ValueExpression>(), null, false);
            var body = new MethodBodyStatement[]
            {
                new IfElsePreprocessorDirective(
                    "NET6_0_OR_GREATER",
                    /*_multipartContent.CopyTo(stream, default, cancellationToken );*/
                    new InvokeInstanceMethodStatement(_multipartContentField, nameof(MultipartFormDataContent.CopyTo), new[] { streamExpression, Snippets.Default ,cancellatinTokenExpression }, false),
                    new MethodBodyStatement[]
                    {
                        new PragmaWarningPreprocessorDirective("disable", "AZC0107"),
                        /*_multipartContent.CopyToAsync(stream).GetAwaiter().GetResult();*/
                        new InvokeInstanceMethodStatement(getTaskWaiterExpression, nameof(TaskAwaiter.GetResult), Array.Empty<ValueExpression>(), false),
                        new PragmaWarningPreprocessorDirective("restore", "AZC0107")
                    }
                    ),
            };
            return new Method(signature, body);
        }

        private Method BuildWriteToAsyncMethod()
        {
            var streamParam = new Parameter("stream", null, typeof(Stream), null, ValidationType.None, null);
            var streamExpression = (ValueExpression)streamParam;
            var cancellationTokenParam = KnownParameters.CancellationTokenParameter;
            var cancellatinTokenExpression = (ValueExpression)cancellationTokenParam;
            //var multipartContentExpression = new MultipartFormDataContentExpression(_multipartContentField);
            var signature = new MethodSignature(
                Name: "WriteToAsync",
                Summary: null,
                Description: null,
                Modifiers: MethodSignatureModifiers.Public | MethodSignatureModifiers.Override | MethodSignatureModifiers.Async,
                ReturnType: typeof(Task),
                ReturnDescription: null,
                Parameters: new[]
                {
                    streamParam,
                    cancellationTokenParam
                });
            var body = new MethodBodyStatement[]
            {
                new IfElsePreprocessorDirective(
                    "NET6_0_OR_GREATER",
                    /*await _multipartContent.CopyToAsync(stream, cancellationToken).ConfigureAwait(false);,*/
                    _multipartContentExpression.CopyToAsync(streamExpression, cancellatinTokenExpression, true),
                    /*await _multipartContent.CopyToAsync(stream).ConfigureAwait(false);*/
                    _multipartContentExpression.CopyToAsync(streamExpression, true)
                    )
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
                new InvokeInstanceMethodStatement(_multipartContentField, nameof(MultipartFormDataContent.Dispose), new ValueExpression[] { }, false)
            };
            return new Method(signature, body);
        }
        public ValueExpression CreateBoundary()
            => new InvokeStaticMethodExpression(Type, _createBoundaryMethodName, new ValueExpression[] { });
        public MethodBodyStatement AddFilenameHeader(ValueExpression httpContent, ValueExpression name, ValueExpression filename)
            => new InvokeInstanceMethodStatement(null, _addFilenameHeaderMethodName, new[] { httpContent, name, filename }, false);
        public MethodBodyStatement AddContentTypeHeader(ValueExpression httpContent, ValueExpression contentType)
            => new InvokeInstanceMethodStatement(null, _addContentTypeHeaderMethodName, new[] { httpContent, contentType }, false);
        public MethodBodyStatement Add(VariableReference multipartContent, ValueExpression content, ValueExpression name, ValueExpression? filename, ValueExpression? contentType)
        {
            var arguments = new List<ValueExpression>() { content, name };
            if (filename != null)
            {
                arguments.Add(filename);
            }
            if (contentType != null)
            {
                if (filename == null)
                    arguments.Add(Null);
                arguments.Add(contentType);
            }
            return new InvokeInstanceMethodStatement(multipartContent.Untyped, _addMethodName, arguments.ToArray(), false);
        }
        public MethodBodyStatement WriteTo(VariableReference multipartContent, ValueExpression stream, ValueExpression? cancellationToken)
        {
            if (cancellationToken == null)
            {
                return new InvokeInstanceMethodStatement(multipartContent.Untyped, _writeToMethodName, new[] { stream }, false);
            } else
            {
                return new InvokeInstanceMethodStatement(multipartContent.Untyped, _writeToMethodName, new[] { stream, cancellationToken }, false);
            }
        }
        public MethodBodyStatement WriteToAsync(VariableReference multipartContent, ValueExpression stream, ValueExpression? cancellationToken)
        {
            if (cancellationToken == null)
            {
                return new InvokeInstanceMethodStatement(multipartContent.Untyped, _writeToAsyncMethodName, new[] { stream }, false);
            }
            else
            {
                return new InvokeInstanceMethodStatement(multipartContent.Untyped, _writeToAsyncMethodName, new[] { stream, cancellationToken }, false);
            }
        }
        public ValueExpression ContentTypeProperty(ValueExpression instance) => instance.Property(_contentTypePropertyName);
    }
}

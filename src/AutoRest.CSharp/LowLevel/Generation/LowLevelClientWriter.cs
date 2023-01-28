// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoRest.CSharp.Common.Generation.Writers;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Common.Output.Models;
using AutoRest.CSharp.Common.Output.Models.Responses;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Output.Builders;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Utilities;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using static AutoRest.CSharp.Output.Models.MethodSignatureModifiers;
using Operation = Azure.Operation;
using Response = Azure.Response;
using StatusCodes = AutoRest.CSharp.Output.Models.Responses.StatusCodes;

namespace AutoRest.CSharp.Generation.Writers
{
    internal class LowLevelClientWriter : ClientWriter
    {
        private static readonly FormattableString LroProcessMessageMethodName = $"{typeof(ProtocolOperationHelpers)}.{nameof(ProtocolOperationHelpers.ProcessMessage)}";
        private static readonly FormattableString LroProcessMessageMethodAsyncName = $"{typeof(ProtocolOperationHelpers)}.{nameof(ProtocolOperationHelpers.ProcessMessageAsync)}";
        private static readonly FormattableString LroProcessMessageWithoutResponseValueMethodName = $"{typeof(ProtocolOperationHelpers)}.{nameof(ProtocolOperationHelpers.ProcessMessageWithoutResponseValue)}";
        private static readonly FormattableString LroProcessMessageWithoutResponseValueMethodAsyncName = $"{typeof(ProtocolOperationHelpers)}.{nameof(ProtocolOperationHelpers.ProcessMessageWithoutResponseValueAsync)}";

        private readonly CodeWriter _writer;
        private readonly XmlDocWriter _xmlDocWriter;
        private readonly LowLevelClient _client;
        private readonly LowLevelExampleComposer _exampleComposer;

        public LowLevelClientWriter(CodeWriter writer, XmlDocWriter xmlDocWriter, LowLevelClient client)
        {
            _writer = writer;
            _xmlDocWriter = xmlDocWriter;
            _client = client;
            _exampleComposer = new LowLevelExampleComposer(client);
        }

        public void WriteClient()
        {
            var clientType = _client.Type;
            using (_writer.Namespace(clientType.Namespace))
            {
                WriteDPGIdentificationComment();
                _writer.WriteXmlDocumentationSummary($"{_client.Description}");
                using (_writer.Scope($"{_client.Declaration.Accessibility} partial class {clientType:D}", scopeDeclarations: _client.Fields.ScopeDeclarations))
                {
                    WriteClientFields();
                    WriteConstructors();

                    foreach (var clientMethod in _client.ClientMethods)
                    {
                        var longRunning = clientMethod.LongRunning;
                        var pagingInfo = clientMethod.PagingInfo;

                        if (clientMethod.ConvenienceMethod is { } convenienceMethod)
                        {
                            WriteConvenienceMethod(clientMethod, convenienceMethod, longRunning, pagingInfo, true);
                            WriteConvenienceMethod(clientMethod, convenienceMethod, longRunning, pagingInfo, false);
                        }

                        WriteProtocolMethodDocumentationWithExternalXmlDoc(clientMethod, true);
                        WriteProtocolMethod(_writer, clientMethod, _client.Fields, longRunning, pagingInfo, true);
                        WriteProtocolMethodDocumentationWithExternalXmlDoc(clientMethod, false);
                        WriteProtocolMethod(_writer, clientMethod, _client.Fields, longRunning, pagingInfo, false);
                    }

                    WriteSubClientFactoryMethod();

                    foreach (var method in _client.RequestMethods)
                    {
                        WriteRequestCreationMethod(_writer, method, _client.Fields);
                    }

                    if (_client.ClientMethods.Any(cm => cm.ConvenienceMethod is not null))
                    {
                        WriteCancellationTokenToRequestContextMethod();
                    }
                    WriteResponseClassifierMethod(_writer, _client.ResponseClassifierTypes);
                }
            }
        }

        public static void WriteProtocolMethods(CodeWriter writer, ClientFields fields, LowLevelClientMethod clientMethod)
        {
            WriteRequestCreationMethod(writer, clientMethod.RequestMethod, fields);

            var longRunning = clientMethod.LongRunning;
            var pagingInfo = clientMethod.PagingInfo;
            WriteProtocolMethodDocumentation(writer, clientMethod);
            WriteProtocolMethod(writer, clientMethod, fields, longRunning, pagingInfo, true);
            WriteProtocolMethodDocumentation(writer, clientMethod);
            WriteProtocolMethod(writer, clientMethod, fields, longRunning, pagingInfo, false);
        }

        private static void WriteProtocolMethod(CodeWriter writer, LowLevelClientMethod clientMethod, ClientFields fields, OperationLongRunning? longRunning, ProtocolMethodPaging? pagingInfo, bool async)
        {
            switch (longRunning, pagingInfo)
            {
                case { longRunning: not null, pagingInfo: not null }:
                    WriteProtocolPageableLroMethod(writer, clientMethod, fields, pagingInfo, longRunning, async);
                    break;
                case { longRunning: null, pagingInfo: not null }:
                    WriteProtocolPageableMethod(writer, clientMethod, fields, pagingInfo, async);
                    break;
                case { longRunning: not null, pagingInfo: null }:
                    WriteProtocolLroMethod(writer, clientMethod, fields, longRunning, async);
                    break;
                default:
                    WriteProtocolMethod(writer, clientMethod, fields, async);
                    break;
            }
        }

        private void WriteConvenienceMethod(LowLevelClientMethod clientMethod, ConvenienceMethod convenienceMethod, OperationLongRunning? longRunning, ProtocolMethodPaging? pagingInfo, bool async)
        {
            switch (longRunning, pagingInfo)
            {
                case { longRunning: not null, pagingInfo: not null }:
                    // Not supported yet
                    break;
                case { longRunning: null, pagingInfo: not null }:
                    WriteConveniencePageableMethod(clientMethod, convenienceMethod, pagingInfo, _client.Fields, async);
                    break;
                case { longRunning: not null, pagingInfo: null }:
                    WriteConvenienceLroMethod(clientMethod, convenienceMethod, _client.Fields, async);
                    break;
                default:
                    WriteConvenienceMethod(clientMethod, convenienceMethod, _client.Fields, async);
                    break;
            }
        }

        private void WriteDPGIdentificationComment() => _writer.Line($"// Data plane generated {(_client.IsSubClient ? "sub-client" : "client")}.");

        private void WriteClientFields()
        {
            foreach (var field in _client.Fields)
            {
                _writer.WriteField(field, declareInCurrentScope: false);
            }

            //TODO: make this a field??
            _writer
                .Line()
                .WriteXmlDocumentationSummary($"The HTTP pipeline for sending and receiving REST requests and responses.")
                .Line($"public virtual {typeof(HttpPipeline)} Pipeline => {_client.Fields.PipelineField.Name};");

            _writer.Line();
        }

        private void WriteConstructors()
        {
            foreach (var constructor in _client.SecondaryConstructors)
            {
                WriteSecondaryPublicConstructor(constructor);
            }

            foreach (var constructor in _client.PrimaryConstructors)
            {
                WritePrimaryPublicConstructor(constructor);
            }

            if (_client.IsSubClient)
            {
                WriteSubClientInternalConstructor(_client.SubClientInternalConstructor);
            }
        }

        private void WriteSecondaryPublicConstructor(ConstructorSignature signature)
        {
            _writer.WriteMethodDocumentation(signature);
            using (_writer.WriteMethodDeclaration(signature))
            {
            }
            _writer.Line();
        }

        private void WritePrimaryPublicConstructor(ConstructorSignature signature)
        {
            _writer.WriteMethodDocumentation(signature);
            using (_writer.WriteMethodDeclaration(signature))
            {
                _writer.WriteParametersValidation(signature.Parameters);
                _writer.Line();

                var clientOptionsParameter = signature.Parameters.Last(p => p.Type.EqualsIgnoreNullable(_client.ClientOptions.Type));
                _writer.Line($"{_client.Fields.ClientDiagnosticsProperty.Name:I} = new {_client.Fields.ClientDiagnosticsProperty.Type}({clientOptionsParameter.Name:I}, true);");

                FormattableString perCallPolicies = $"Array.Empty<{typeof(HttpPipelinePolicy)}>()";
                FormattableString perRetryPolicies = $"Array.Empty<{typeof(HttpPipelinePolicy)}>()";

                var credentialParameter = signature.Parameters.FirstOrDefault(p => p.Name == "credential");
                if (credentialParameter != null)
                {
                    var credentialField = _client.Fields.GetFieldByParameter(credentialParameter);
                    if (credentialField != null)
                    {
                        var fieldName = credentialField.Name;
                        _writer.Line($"{fieldName:I} = {credentialParameter.Name:I};");
                        if (credentialField.Type.Equals(typeof(AzureKeyCredential)))
                        {
                            perRetryPolicies = $"new {typeof(HttpPipelinePolicy)}[] {{new {typeof(AzureKeyCredentialPolicy)}({fieldName:I}, {_client.Fields.AuthorizationHeaderConstant!.Name})}}";
                        }
                        else if (credentialField.Type.Equals(typeof(TokenCredential)))
                        {
                            perRetryPolicies = $"new {typeof(HttpPipelinePolicy)}[] {{new {typeof(BearerTokenAuthenticationPolicy)}({fieldName:I}, {_client.Fields.ScopesConstant!.Name})}}";
                        }
                    }
                }

                _writer.Line($"{_client.Fields.PipelineField.Name:I} = {typeof(HttpPipelineBuilder)}.{nameof(HttpPipelineBuilder.Build)}({clientOptionsParameter.Name:I}, {perCallPolicies}, {perRetryPolicies}, new {typeof(ResponseClassifier)}());");

                foreach (var parameter in _client.Parameters)
                {
                    var field = _client.Fields.GetFieldByParameter(parameter);
                    if (field != null)
                    {
                        if (parameter.IsApiVersionParameter)
                        {
                            _writer.Line($"{field.Name:I} = {clientOptionsParameter.Name:I}.Version;");
                        }
                        else
                        {
                            _writer.Line($"{field.Name:I} = {parameter.Name:I};");
                        }
                    }
                }
            }
            _writer.Line();
        }

        private void WriteSubClientInternalConstructor(ConstructorSignature signature)
        {
            _writer.WriteMethodDocumentation(signature);
            using (_writer.WriteMethodDeclaration(signature))
            {
                _writer.WriteParametersValidation(signature.Parameters);
                _writer.Line();

                foreach (var parameter in signature.Parameters)
                {
                    var field = _client.Fields.GetFieldByParameter(parameter);
                    if (field != null)
                    {
                        _writer.Line($"{field.Name:I} = {parameter.Name:I};");
                    }
                }
            }
            _writer.Line();
        }

        private void WriteSpreadBodyConverter(CodeWriter writer, ConvenienceMethod convenienceMethod, FormattableString? spreadVariable)
        {
            var convenienceSpread = convenienceMethod.ProtocolToConvenienceParameters.Select(converter => converter.ConvenienceSpread).WhereNotNull().SingleOrDefault();
            if (convenienceSpread != null)
            {
                var ctor = convenienceSpread.BackingModel.SerializationConstructor;
                var initializers = new List<PropertyInitializer>();
                foreach (var parameter in convenienceSpread.SpreadedParameters)
                {
                    var property = ctor.FindPropertyInitializedByParameter(parameter);
                    if (property == null)
                        continue;
                    initializers.Add(new PropertyInitializer(property.Declaration.Name, property.Declaration.Type, property.IsReadOnly, $"{parameter.Name:I}", parameter.Type));
                }

                writer.WriteInitialization(v => writer.Line($"{convenienceSpread.BackingModel.Type} {spreadVariable} = {v};"), convenienceSpread.BackingModel, ctor, initializers);
            }
        }

        private void WriteConvenienceMethod(LowLevelClientMethod clientMethod, ConvenienceMethod convenienceMethod, ClientFields fields, bool async)
        {
            using (WriteConvenienceMethodDeclaration(_writer, convenienceMethod, fields, async))
            {
                var contextVariable = new CodeWriterDeclaration(KnownParameters.RequestContext.Name);
                var (parameters, spreadVariable) = PrepareConvenienceMethodParameters(convenienceMethod, contextVariable);

                WriteSpreadBodyConverter(_writer, convenienceMethod, spreadVariable);
                WriteCancellationTokenToRequestContext(_writer, contextVariable);

                var responseVariable = new CodeWriterDeclaration("response");
                _writer
                    .Append($"{typeof(Response)} {responseVariable:D} = ")
                    .WriteMethodCall(clientMethod.ProtocolMethodSignature, parameters, async)
                    .LineRaw(";");

                var responseType = convenienceMethod.ResponseType;
                if (responseType == null)
                {
                    _writer.Line($"return {responseVariable:I};");
                }
                else
                {
                    _writer.Line($"return {typeof(Response)}.{nameof(Response.FromValue)}({responseType}.FromResponse({responseVariable:I}), {responseVariable:I});");
                }
            }
            _writer.Line();
        }

        private void WriteConvenienceLroMethod(LowLevelClientMethod clientMethod, ConvenienceMethod convenienceMethod, ClientFields fields, bool async)
        {
            using (WriteConvenienceMethodDeclaration(_writer, convenienceMethod, fields, async))
            {
                var contextVariable = new CodeWriterDeclaration(KnownParameters.RequestContext.Name);

                var (parameters, spreadVariable) = PrepareConvenienceMethodParameters(convenienceMethod, contextVariable);

                WriteSpreadBodyConverter(_writer, convenienceMethod, spreadVariable);
                WriteCancellationTokenToRequestContext(_writer, contextVariable);

                var responseType = convenienceMethod.ResponseType;
                if (responseType == null)
                {
                    // return [await] protocolMethod(parameters...)[.ConfigureAwait(false)];
                    _writer
                        .Append($"return ")
                        .WriteMethodCall(clientMethod.ProtocolMethodSignature, parameters, async)
                        .LineRaw(";");
                }
                else
                {
                    // Operation<BinaryData> response = [await] protocolMethod(parameters...)[.ConfigureAwait(false)];
                    var responseVariable = new CodeWriterDeclaration("response");
                    _writer
                        .Append($"{clientMethod.ProtocolMethodSignature.ReturnType} {responseVariable:D} = ")
                        .WriteMethodCall(clientMethod.ProtocolMethodSignature, parameters, async)
                        .LineRaw(";");
                    // return ProtocolOperationHelpers.Convert(response, r => responseType.FromResponse(r), ClientDiagnostics, scopeName);
                    var diagnostic = convenienceMethod.Diagnostic ?? clientMethod.ProtocolMethodDiagnostic;
                    _writer.Line($"return {typeof(ProtocolOperationHelpers)}.{nameof(ProtocolOperationHelpers.Convert)}({responseVariable:I}, {responseType}.FromResponse, {fields.ClientDiagnosticsProperty.Name}, {diagnostic.ScopeName:L});");
                }
            }
            _writer.Line();
        }

        // RequestContext context = FromCancellationToken(cancellationToken);
        private static void WriteCancellationTokenToRequestContext(CodeWriter writer, CodeWriterDeclaration contextVariable)
        {
            writer.Line($"{typeof(RequestContext)} {contextVariable:D} = FromCancellationToken({KnownParameters.CancellationTokenParameter.Name});");
        }

        private static (IReadOnlyList<FormattableString> Parameters, FormattableString? SpreadBodyVariable) PrepareConvenienceMethodParameters(ConvenienceMethod convenienceMethod, CodeWriterDeclaration contextVariable)
        {
            FormattableString? spreadBodyVariable = null;
            var parameters = new List<FormattableString>();
            foreach (var converter in convenienceMethod.ProtocolToConvenienceParameters)
            {
                var protocolParameter = converter.Protocol;
                var convenienceParameter = converter.Convenience;
                if (convenienceParameter == KnownParameters.CancellationTokenParameter)
                {
                    parameters.Add($"{contextVariable:I}");
                }
                else if (convenienceParameter != null)
                {
                    parameters.Add(convenienceParameter.GetConversionFormattable(protocolParameter.Type));
                }
                else
                {
                    throw new InvalidOperationException($"{protocolParameter.Name} protocol method parameter doesn't have matching field or parameter in convenience method {convenienceMethod.Signature.Name}");
                }

                if (converter.ConvenienceSpread != null)
                {
                    // we put a declaration here to avoid possible local variable naming collisions
                    var declaration = new CodeWriterDeclaration(convenienceParameter.Name);
                    spreadBodyVariable = $"{declaration:D}";
                }
            }

            return (parameters, spreadBodyVariable);
        }

        private void WriteConveniencePageableMethod(LowLevelClientMethod clientMethod, ConvenienceMethod convenienceMethod, ProtocolMethodPaging pagingInfo, ClientFields fields, bool async)
        {
            WriteConvenienceMethodDocumentation(_writer, convenienceMethod.Signature);
            _writer.WritePageable(convenienceMethod, clientMethod.RequestMethod, pagingInfo.NextPageMethod, fields.ClientDiagnosticsProperty, fields.PipelineField, clientMethod.ProtocolMethodDiagnostic.ScopeName, pagingInfo.ItemName, pagingInfo.NextLinkName, async);
        }

        private static void WriteProtocolPageableMethod(CodeWriter writer, LowLevelClientMethod clientMethod, ClientFields fields, ProtocolMethodPaging pagingInfo, bool async)
        {
            writer.WritePageable(clientMethod.ProtocolMethodSignature, typeof(BinaryData), null, clientMethod.RequestMethod, pagingInfo.NextPageMethod, fields.ClientDiagnosticsProperty, fields.PipelineField, clientMethod.ProtocolMethodDiagnostic.ScopeName, pagingInfo.ItemName, pagingInfo.NextLinkName, async);
        }

        private static void WriteProtocolPageableLroMethod(CodeWriter writer, LowLevelClientMethod clientMethod, ClientFields fields, ProtocolMethodPaging pagingInfo, OperationLongRunning longRunning, bool async)
        {
            writer.WriteLongRunningPageable(clientMethod.ProtocolMethodSignature, typeof(BinaryData), null, clientMethod.RequestMethod, pagingInfo.NextPageMethod, fields.ClientDiagnosticsProperty, fields.PipelineField, clientMethod.ProtocolMethodDiagnostic, longRunning.FinalStateVia, pagingInfo.ItemName, pagingInfo.NextLinkName, async);
        }

        private static void WriteProtocolLroMethod(CodeWriter writer, LowLevelClientMethod clientMethod, ClientFields fields, OperationLongRunning longRunning, bool async)
        {
            using (writer.WriteMethodDeclaration(clientMethod.ProtocolMethodSignature.WithAsync(async)))
            {
                writer.WriteParametersValidation(clientMethod.ProtocolMethodSignature.Parameters);
                var startMethod = clientMethod.RequestMethod;
                var finalStateVia = longRunning.FinalStateVia;
                var scopeName = clientMethod.ProtocolMethodDiagnostic.ScopeName;

                using (writer.WriteDiagnosticScope(clientMethod.ProtocolMethodDiagnostic, fields.ClientDiagnosticsProperty))
                {
                    var messageVariable = new CodeWriterDeclaration("message");
                    var processMessageParameters = (FormattableString)$"{fields.PipelineField.Name:I}, {messageVariable}, {fields.ClientDiagnosticsProperty.Name:I}, {scopeName:L}, {typeof(OperationFinalStateVia)}.{finalStateVia}, {KnownParameters.RequestContext.Name:I}, {KnownParameters.WaitForCompletion.Name:I}";

                    writer
                        .Line($"using {typeof(HttpMessage)} {messageVariable:D} = {RequestWriterHelpers.CreateRequestMethodName(startMethod.Name)}({startMethod.Parameters.GetIdentifiersFormattable()});")
                        .AppendRaw("return ")
                        .WriteMethodCall(async, clientMethod.ResponseBodyType != null ? LroProcessMessageMethodAsyncName : LroProcessMessageWithoutResponseValueMethodAsyncName, clientMethod.ResponseBodyType != null ? LroProcessMessageMethodName : LroProcessMessageWithoutResponseValueMethodName, processMessageParameters);
                }
            }
            writer.Line();
        }

        public static void WriteProtocolMethod(CodeWriter writer, LowLevelClientMethod clientMethod, ClientFields fields, bool async)
        {
            using (writer.WriteMethodDeclaration(clientMethod.ProtocolMethodSignature.WithAsync(async)))
            {
                writer.WriteParametersValidation(clientMethod.ProtocolMethodSignature.Parameters);
                var restMethod = clientMethod.RequestMethod;
                var headAsBoolean = restMethod.Request.HttpMethod == RequestMethod.Head && Configuration.HeadAsBoolean;

                if (clientMethod.ConditionHeaderFlag != RequestConditionHeaders.None && clientMethod.ConditionHeaderFlag != (RequestConditionHeaders.IfMatch | RequestConditionHeaders.IfNoneMatch | RequestConditionHeaders.IfModifiedSince | RequestConditionHeaders.IfUnmodifiedSince))
                {
                    writer.WriteRequestConditionParameterChecks(restMethod.Parameters, clientMethod.ConditionHeaderFlag);
                    writer.Line();
                }

                using (writer.WriteDiagnosticScope(clientMethod.ProtocolMethodDiagnostic, fields.ClientDiagnosticsProperty))
                {
                    var messageVariable = new CodeWriterDeclaration("message");
                    writer.Line($"using {typeof(HttpMessage)} {messageVariable:D} = {RequestWriterHelpers.CreateRequestMethodName(restMethod.Name)}({restMethod.Parameters.GetIdentifiersFormattable()});");

                    var methodName = async
                        ? headAsBoolean ? nameof(HttpPipelineExtensions.ProcessHeadAsBoolMessageAsync) : nameof(HttpPipelineExtensions.ProcessMessageAsync)
                        : headAsBoolean ? nameof(HttpPipelineExtensions.ProcessHeadAsBoolMessage) : nameof(HttpPipelineExtensions.ProcessMessage);

                    FormattableString paramString = headAsBoolean
                        ? (FormattableString)$"{messageVariable}, {fields.ClientDiagnosticsProperty.Name}, {KnownParameters.RequestContext.Name:I}"
                        : (FormattableString)$"{messageVariable}, {KnownParameters.RequestContext.Name:I}";

                    writer.AppendRaw("return ").WriteMethodCall(async, $"{fields.PipelineField.Name:I}.{methodName}", paramString);
                }
            }
            writer.Line();
        }

        private void WriteSubClientFactoryMethod()
        {
            foreach (var field in _client.SubClients.Select(s => s.FactoryMethod?.CachingField))
            {
                if (field != null)
                {
                    _writer.WriteField(field);
                }
            }

            _writer.Line();

            foreach (var (methodSignature, field, constructorCallParameters) in _client.SubClients.Select(s => s.FactoryMethod).WhereNotNull())
            {
                _writer.WriteMethodDocumentation(methodSignature);
                using (_writer.WriteMethodDeclaration(methodSignature))
                {
                    _writer.WriteParametersValidation(methodSignature.Parameters);
                    _writer.Line();

                    var references = constructorCallParameters
                        .Select(p => _client.Fields.GetFieldByParameter(p) ?? (Reference)p)
                        .ToArray();

                    if (field != null)
                    {
                        _writer
                            .Append($"return {typeof(Volatile)}.{nameof(Volatile.Read)}(ref {field.Name})")
                            .Append($" ?? {typeof(Interlocked)}.{nameof(Interlocked.CompareExchange)}(ref {field.Name}, new {methodSignature.ReturnType}({references.GetIdentifiersFormattable()}), null)")
                            .Line($" ?? {field.Name};");
                    }
                    else
                    {
                        _writer.Line($"return new {methodSignature.ReturnType}({references.GetIdentifiersFormattable()});");
                    }
                }
                _writer.Line();
            }
        }

        public static void WriteRequestCreationMethod(CodeWriter writer, RestClientMethod restMethod, ClientFields fields)
        {
            RequestWriterHelpers.WriteRequestCreation(writer, restMethod, "internal", fields, restMethod.ResponseClassifierType.Name, false);
        }

        public static void WriteResponseClassifierMethod(CodeWriter writer, IEnumerable<ResponseClassifierType> responseClassifierTypes)
        {
            foreach ((string name, StatusCodes[] statusCodes) in responseClassifierTypes.Distinct())
            {
                WriteResponseClassifier(writer, name, statusCodes);
            }
        }

        private static void WriteResponseClassifier(CodeWriter writer, string responseClassifierTypeName, StatusCodes[] statusCodes)
        {
            var hasStatusCodeRanges = statusCodes.Any(statusCode => statusCode.Family != null);
            if (hasStatusCodeRanges)
            {
                // After fixing https://github.com/Azure/autorest.csharp/issues/2018 issue remove "hasStatusCodeRanges" condition and this class
                using (writer.Scope($"private sealed class {responseClassifierTypeName}Override : {typeof(ResponseClassifier)}"))
                {
                    using (writer.Scope($"public override bool {nameof(ResponseClassifier.IsErrorResponse)}({typeof(HttpMessage)} message)"))
                    {
                        using (writer.Scope($"return message.{nameof(HttpMessage.Response)}.{nameof(Response.Status)} switch", end: "};"))
                        {
                            foreach (var statusCode in statusCodes)
                            {
                                writer.Line($">= {statusCode.Family * 100:L} and < {statusCode.Family * 100 + 100:L} => false,");
                            }

                            writer.LineRaw("_ => true");
                        }
                    }
                }
                writer.Line();
            }

            writer.Line($"private static {typeof(ResponseClassifier)} _{responseClassifierTypeName.FirstCharToLowerCase()};");
            writer.Append($"private static {typeof(ResponseClassifier)} {responseClassifierTypeName} => _{responseClassifierTypeName.FirstCharToLowerCase()} ??= new ");
            if (hasStatusCodeRanges)
            {
                writer.Line($"{responseClassifierTypeName}Override();");
            }
            else
            {
                writer.Append($"{typeof(StatusCodeClassifier)}(stackalloc ushort[]{{");
                foreach (var statusCode in statusCodes)
                {
                    if (statusCode.Code != null)
                    {
                        writer.Append($"{statusCode.Code}, ");
                    }
                }
                writer.RemoveTrailingComma();
                writer.Line($"}});");
            }
        }

        private void WriteProtocolMethodDocumentationWithExternalXmlDoc(LowLevelClientMethod clientMethod, bool async)
        {
            var methodSignature = clientMethod.ProtocolMethodSignature.WithAsync(async);

            var remarks = CreateSchemaDocumentationRemarks(clientMethod, out var hasRequestRemarks, out var hasResponseRemarks);
            WriteMethodDocumentation(_writer, methodSignature, clientMethod, hasResponseRemarks);
            var docRef = GetMethodSignatureString(methodSignature);
            _writer.Line($"/// <include file=\"Docs/{_client.Type.Name}.xml\" path=\"doc/members/member[@name='{docRef}']/*\" />");
            using (_xmlDocWriter.CreateMember(docRef))
            {
                _xmlDocWriter.WriteXmlDocumentation("example", _exampleComposer.Compose(clientMethod, async));
                WriteDocumentationRemarks(_xmlDocWriter.WriteXmlDocumentation, clientMethod, methodSignature, remarks, hasRequestRemarks, hasResponseRemarks);
            }
        }

        private static string GetMethodSignatureString(MethodSignature signature)
        {
            var builder = new StringBuilder(signature.Name);
            builder.Append("(");
            builder.Append(string.Join(",", signature.Parameters.Select(p => p.Type.Name)));
            builder.Append(")");
            return builder.ToString();
        }

        private static void WriteProtocolMethodDocumentation(CodeWriter writer, LowLevelClientMethod clientMethod)
        {
            var methodSignature = clientMethod.ProtocolMethodSignature;
            var remarks = CreateSchemaDocumentationRemarks(clientMethod, out var hasRequestRemarks, out var hasResponseRemarks);
            WriteMethodDocumentation(writer, methodSignature, clientMethod, hasResponseRemarks);
            WriteDocumentationRemarks((tag, text) => writer.WriteXmlDocumentation(tag, text), clientMethod, methodSignature, remarks, hasRequestRemarks, hasResponseRemarks);
        }

        private static IDisposable WriteConvenienceMethodDeclaration(CodeWriter writer, ConvenienceMethod convenienceMethod, ClientFields fields, bool async)
        {
            WriteConvenienceMethodDocumentation(writer, convenienceMethod.Signature);

            var methodSignature = convenienceMethod.Signature.WithAsync(async);
            var scope = writer.WriteMethodDeclaration(methodSignature);
            writer.WriteParametersValidation(methodSignature.Parameters);

            if (convenienceMethod.Diagnostic != null)
            {
                var diagnosticScope = writer.WriteDiagnosticScope(convenienceMethod.Diagnostic, fields.ClientDiagnosticsProperty);
                return Disposable.Create(() =>
                {
                    diagnosticScope.Dispose();
                    scope.Dispose();
                });
            }

            return scope;
        }

        private static void WriteConvenienceMethodDocumentation(CodeWriter writer, MethodSignature convenienceMethod)
        {
            writer.WriteMethodDocumentation(convenienceMethod);
            writer.WriteXmlDocumentation("remarks", $"{convenienceMethod.DescriptionText}");
        }

        private void WriteCancellationTokenToRequestContextMethod()
        {
            var defaultRequestContext = new CodeWriterDeclaration("DefaultRequestContext");
            _writer.Line($"private static {typeof(RequestContext)} {defaultRequestContext:D} = new {typeof(RequestContext)}();");

            var methodSignature = new MethodSignature("FromCancellationToken", null, null, Internal | Static, typeof(RequestContext), null, new List<Parameter> { KnownParameters.CancellationTokenParameter });
            using (_writer.WriteMethodDeclaration(methodSignature))
            {
                using (_writer.Scope($"if (!{KnownParameters.CancellationTokenParameter.Name}.{nameof(CancellationToken.CanBeCanceled)})"))
                {
                    _writer.Line($"return {defaultRequestContext:I};");
                }

                _writer.Line().Line($"return new {typeof(RequestContext)}() {{ CancellationToken = {KnownParameters.CancellationTokenParameter.Name} }};");
            }
            _writer.Line();
        }

        private static void WriteMethodDocumentation(CodeWriter codeWriter, MethodSignature methodSignature, LowLevelClientMethod clientMethod, bool hasResponseRemarks)
        {
            codeWriter.WriteMethodDocumentation(methodSignature);
            codeWriter.WriteXmlDocumentationException(typeof(RequestFailedException), $"Service returned a non-success status code.");

            if (methodSignature.ReturnType == null)
            {
                return;
            }

            if (!methodSignature.ReturnType.IsFrameworkType)
            {
                throw new InvalidOperationException($"Xml documentation generation is supported only for protocol methods. {methodSignature.ReturnType} can't be a return type of a protocol method.");
            }

            var returnType = methodSignature.ReturnType;

            FormattableString text;
            if (clientMethod.PagingInfo != null && clientMethod.LongRunning != null)
            {
                CSharpType pageableType = methodSignature.Modifiers.HasFlag(Async) ? typeof(AsyncPageable<>) : typeof(Pageable<>);
                text = $"The <see cref=\"{nameof(Operation)}{{T}}\"/> from the service that will contain a <see cref=\"{pageableType.Name}{{T}}\"/> containing a list of <see cref=\"{nameof(BinaryData)}\"/> objects once the asynchronous operation on the service has completed. Details of the body schema for the operation's final value are in the Remarks section below.";
            }
            else if (clientMethod.PagingInfo != null)
            {
                text = $"The <see cref=\"{returnType.Name}{{T}}\"/> from the service containing a list of <see cref=\"{returnType.Arguments[0]}\"/> objects. Details of the body schema for each item in the collection are in the Remarks section below.";
            }
            else if (clientMethod.LongRunning != null)
            {
                text = hasResponseRemarks
                    ? $"The <see cref=\"{nameof(Operation)}{{T}}\"/> from the service that will contain a <see cref=\"{nameof(BinaryData)}\"/> object once the asynchronous operation on the service has completed. Details of the body schema for the operation's final value are in the Remarks section below."
                    : (FormattableString)$"The <see cref=\"{nameof(Operation)}\"/> representing an asynchronous operation on the service.";
            }
            else if (returnType.EqualsIgnoreNullable(typeof(Task<Response>)) || returnType.EqualsIgnoreNullable(typeof(Response)))
            {
                text = hasResponseRemarks
                    ? $"The response returned from the service. Details of the response body schema are in the Remarks section below."
                    : (FormattableString)$"The response returned from the service.";
            }
            else if (returnType.EqualsIgnoreNullable(typeof(Task<Response<bool>>)) || returnType.EqualsIgnoreNullable(typeof(Response<bool>)))
            {
                text = $"The response returned from the service.";
            }
            else
            {
                throw new InvalidOperationException($"Xml documentation generation for return type {methodSignature.ReturnType} is not supported!");
            }

            codeWriter.WriteXmlDocumentationReturns(text);
        }


        private static IReadOnlyList<FormattableString> CreateSchemaDocumentationRemarks(LowLevelClientMethod clientMethod, out bool hasRequestSchema, out bool hasResponseSchema)
        {
            var schemas = new List<FormattableString>();

            hasRequestSchema = AddRequestOrResponseInputType(schemas, clientMethod.RequestBodyType, "Request Body");

            if (clientMethod.PagingInfo != null && clientMethod.ResponseBodyType is InputModelType modelType)
            {
                var itemType = modelType.Properties.FirstOrDefault(p => p.Name == clientMethod.PagingInfo.ItemName)?.Type;
                hasResponseSchema = AddRequestOrResponseSchema(schemas, itemType, "Response Body");
            }
            else
            {
                hasResponseSchema = AddRequestOrResponseInputType(schemas, clientMethod.ResponseBodyType, "Response Body");
            }

            return schemas;

            static bool AddRequestOrResponseInputType(List<FormattableString> formattedSchemas, InputType? bodyType, string schemaName) =>
                bodyType switch
                {
                    InputListType listType => AddRequestOrResponseInputType(formattedSchemas, listType.ElementType, schemaName),
                    InputDictionaryType dictionaryType => AddRequestOrResponseInputType(formattedSchemas, dictionaryType.ValueType, schemaName),
                    _ => AddRequestOrResponseSchema(formattedSchemas, bodyType, schemaName),
                };

            static bool AddRequestOrResponseSchema(List<FormattableString> formattedSchemas, InputType? type, string schemaName)
            {
                if (type is null)
                {
                    return false;
                }

                var schemasToAdd = new List<FormattableString>();
                if (type is InputModelType { DerivedModels.Count: > 0 } modelType)
                {
                    var derivedModels = modelType.GetAllDerivedModels();
                    if (derivedModels.Count > 1)
                    {
                        schemasToAdd.Add($"This method takes one of the JSON objects below as a payload. Please select a JSON object to view the schema for this.{Environment.NewLine}");
                    }

                    for (var index = 0; index < derivedModels.Count; index++)
                    {
                        var derivedModel = derivedModels[index];
                        if (index == 1)
                        {
                            schemasToAdd.Add($"<details><summary>~+ {derivedModels.Count - 1} more JSON objects</summary>");
                        }

                        var docs = GetSchemaDocumentationsForSchema(derivedModel, $"{derivedModel.Name.ToCleanName()} {schemaName}");
                        if (docs != null)
                        {
                            schemasToAdd.Add($"<details><summary>{derivedModel.Name.ToCleanName()}</summary>");
                            schemasToAdd.Add($"Schema for <c>{derivedModel.Name.ToCleanName()}</c>:{Environment.NewLine}<code>{BuildSchemaFromDocs(docs)}</code>{Environment.NewLine}");
                            schemasToAdd.Add($"</details>{Environment.NewLine}");
                        }
                    }
                    if (derivedModels.Count > 1)
                    {
                        schemasToAdd.Add($"</details>{Environment.NewLine}");
                    }
                }
                else
                {
                    var docs = GetSchemaDocumentationsForSchema(type, schemaName);
                    if (docs != null)
                    {
                        schemasToAdd.Add($"Schema for <c>{type.Name.ToCleanName()}</c>:{Environment.NewLine}<code>{BuildSchemaFromDocs(docs)}</code>{Environment.NewLine}");
                    }
                }

                if (schemasToAdd.Count > 0)
                {
                    formattedSchemas.Add($"{Environment.NewLine}{schemaName}:{Environment.NewLine}{Environment.NewLine}");
                    formattedSchemas.AddRange(schemasToAdd);
                    return true;
                }

                return false;
            }
        }
        private static void WriteDocumentationRemarks(Action<string, FormattableString?> writeXmlDocumentation, LowLevelClientMethod clientMethod, MethodSignature methodSignature, IReadOnlyCollection<FormattableString> schemas, bool hasRequestRemarks, bool hasResponseRemarks)
        {
            if (schemas.Count <= 0)
            {
                writeXmlDocumentation("remarks", $"{methodSignature.DescriptionText}");
                return;
            }

            var docInfo = clientMethod.RequestMethod.Operation.ExternalDocsUrl != null
                ? $"Additional information can be found in the service REST API documentation:{Environment.NewLine}{clientMethod.RequestMethod.Operation.ExternalDocsUrl}{Environment.NewLine}"
                : (FormattableString)$"";

            var schemaDesription = "";
            if (hasRequestRemarks && hasResponseRemarks)
            {
                if (clientMethod.PagingInfo == null)
                {
                    schemaDesription = "Below is the JSON schema for the request and response payloads.";
                }
                else
                {
                    schemaDesription = "Below is the JSON schema for the request payload and one item in the pageable response.";
                }
            }
            else if (hasRequestRemarks)
            {
                schemaDesription = "Below is the JSON schema for the request payload.";
            }
            else if (hasResponseRemarks)
            {
                if (clientMethod.PagingInfo == null)
                {
                    schemaDesription = "Below is the JSON schema for the response payload.";
                }
                else
                {
                    schemaDesription = "Below is the JSON schema for one item in the pageable response.";
                }
            }

            if (!methodSignature.DescriptionText.IsNullOrEmpty())
            {
                schemaDesription = $"{methodSignature.DescriptionText}{Environment.NewLine}{Environment.NewLine}{schemaDesription}";
            }

            writeXmlDocumentation("remarks", $"{schemaDesription}{Environment.NewLine}{docInfo}{schemas}");
        }

        private static string BuildSchemaFromDocs(SchemaDocumentation[] docs)
        {
            var docDict = docs.ToDictionary(d => d.SchemaName, d => d);
            var builder = new StringBuilder();
            builder.AppendLine("{");
            BuildSchemaFromDoc(builder, docs.First(), docDict, 2);
            builder.AppendLine("}");
            return builder.ToString();
        }

        private static void BuildSchemaFromDoc(StringBuilder builder, SchemaDocumentation doc, IDictionary<string, SchemaDocumentation> docDict, int indentation = 0)
        {
            foreach (var row in doc.DocumentationRows)
            {
                var required = row.Required ? " # Required." : " # Optional.";
                var description = row.Description.IsNullOrEmpty() ? string.Empty : (required.IsNullOrEmpty() ? $" # {row.Description}" : $" {row.Description}");
                var isArray = row.Type.EndsWith("[]");
                var rowType = isArray ? row.Type.Substring(0, row.Type.Length - 2) : row.Type;
                builder.AppendIndentation(indentation).Append($"{row.Name}: ");
                if (isArray)
                {
                    if (docDict.ContainsKey(rowType))
                    {
                        builder.AppendLine("[");
                        var docToProcess = docDict[rowType];
                        docDict.Remove(rowType); // In the case of cyclic reference where A has a property type of A itself, we just show the type A if it's not the first time we meet A.
                        builder.AppendIndentation(indentation + 2).AppendLine("{");
                        BuildSchemaFromDoc(builder, docToProcess, docDict, indentation + 4);
                        builder.AppendIndentation(indentation + 2).AppendLine("}");
                        builder.AppendIndentation(indentation).AppendLine($"],{required}{description}");
                    }
                    else
                        builder.AppendLine($"[{rowType}],{required}{description}");
                }
                else
                {
                    if (docDict.ContainsKey(rowType))
                    {
                        builder.AppendLine("{");
                        var docToProcess = docDict[rowType];
                        docDict.Remove(rowType); // In the case of cyclic reference where A has a property type of A itself, we just show the type A if it's not the first time we meet A.
                        BuildSchemaFromDoc(builder, docToProcess, docDict, indentation + 2);
                        builder.AppendIndentation(indentation).Append("}").AppendLine($",{required}{description}");
                    }
                    else
                        builder.AppendLine($"{rowType},{required}{description}");
                }
            }
        }

        private static SchemaDocumentation[]? GetSchemaDocumentationsForSchema(InputType type, string schemaName)
        {
            // Visit each schema in the graph and for object schemas, collect information about all the properties.
            var visitedSchema = new HashSet<string>();
            var typesToExplore = new Queue<InputType>(new[] { type });
            var documentationObjects = new List<(string SchemaName, List<SchemaDocumentation.DocumentationRow> Rows)>();

            while (typesToExplore.Any())
            {
                InputType toExplore = typesToExplore.Dequeue();

                if (visitedSchema.Contains(toExplore.Name))
                {
                    continue;
                }

                switch (toExplore)
                {
                    case InputModelType modelType:
                        List<SchemaDocumentation.DocumentationRow> propertyDocumentation = new();

                        // We must also include any properties introduced by our parent chain.
                        foreach (InputModelType modelOrBase in modelType.GetSelfAndBaseModels())
                        {
                            foreach (InputModelProperty property in modelOrBase.Properties)
                            {
                                if (property.IsDiscriminator && property.Type is InputEnumType { IsExtensible: true } && modelType.DiscriminatorValue != null)
                                {
                                    propertyDocumentation.Add(new SchemaDocumentation.DocumentationRow(
                                        property.SerializedName ?? property.Name,
                                        modelType.DiscriminatorValue,
                                        property.IsRequired,
                                        BuilderHelpers.EscapeXmlDescription(property.Description)));

                                    typesToExplore.Enqueue(property.Type);
                                    continue;
                                }

                                propertyDocumentation.Add(new SchemaDocumentation.DocumentationRow(
                                    property.SerializedName ?? property.Name,
                                    BuilderHelpers.EscapeXmlDescription(StringifyTypeForTable(property.Type)),
                                    property.IsRequired,
                                    BuilderHelpers.EscapeXmlDescription(property.Description)));

                                typesToExplore.Enqueue(property.Type);
                            }
                        }

                        documentationObjects.Add(new(toExplore == type ? schemaName : BuilderHelpers.EscapeXmlDescription(StringifyTypeForTable(toExplore)), propertyDocumentation));
                        break;
                    case InputListType listType:
                        typesToExplore.Enqueue(listType.ElementType);
                        break;
                    case InputDictionaryType dictionaryType:
                        typesToExplore.Enqueue(dictionaryType.ValueType);
                        break;
                }

                visitedSchema.Add(toExplore.Name);
            }

            if (!documentationObjects.Any())
            {
                return null;
            }

            return documentationObjects.Select(o => new SchemaDocumentation(o.SchemaName, o.Rows.ToArray())).ToArray();
        }

        private static string StringifyTypeForTable(InputType type)
        {
            static string RemovePrefix(string s, string prefix)
                => s.StartsWith(prefix) ? s[prefix.Length..] : s;

            return type switch
            {
                InputPrimitiveType { IsNumber: true } => "number",
                InputPrimitiveType { Kind: InputTypeKind.Boolean } => "boolean",
                InputPrimitiveType { Kind: InputTypeKind.String } => "string",
                InputPrimitiveType { Kind: InputTypeKind.Object } => "object",
                InputPrimitiveType { Kind: InputTypeKind.Date } => "string (date)",
                InputPrimitiveType { Kind: InputTypeKind.DateTime } => "string (date & time)",
                InputPrimitiveType { Kind: InputTypeKind.DateTimeISO8601 } => "string (ISO 8601 Format)",
                InputPrimitiveType { Kind: InputTypeKind.DateTimeRFC1123 } => "string (RFC1123 Format)",
                InputPrimitiveType { Kind: InputTypeKind.DateTimeUnix } => "string (Unix Format)",
                InputPrimitiveType { Kind: InputTypeKind.DurationISO8601 } => "string (duration ISO 8601 Format)",
                InputPrimitiveType { Kind: InputTypeKind.DurationConstant } => "string (duration)",
                InputPrimitiveType { Kind: InputTypeKind.Time } => "string (time)",
                InputEnumType enumType => string.Join(" | ", enumType.AllowedValues.Select(c => $"\"{c.Value}\"")),
                InputDictionaryType dictionaryType => $"Dictionary<string, {StringifyTypeForTable(dictionaryType.ValueType)}>",
                InputListType listType => $"{StringifyTypeForTable(listType.ElementType)}[]",
                _ => RemovePrefix(type.Name, "Json")
            };
        }

        private class SchemaDocumentation
        {
            internal record DocumentationRow(string Name, string Type, bool Required, string Description);

            public string SchemaName { get; }
            public DocumentationRow[] DocumentationRows { get; }

            public SchemaDocumentation(string schemaName, DocumentationRow[] documentationRows)
            {
                SchemaName = schemaName;
                DocumentationRows = documentationRows;
            }
        }

    }
}

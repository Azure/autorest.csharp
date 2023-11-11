﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading;
using AutoRest.CSharp.Common.Generation.Writers;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Common.Output.Models;
using AutoRest.CSharp.Common.Output.Models.Responses;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Utilities;
using Azure;
using Azure.Core;
using static AutoRest.CSharp.Output.Models.MethodSignatureModifiers;
using Operation = Azure.Operation;
using StatusCodes = AutoRest.CSharp.Output.Models.Responses.StatusCodes;

namespace AutoRest.CSharp.Generation.Writers
{
    internal class DpgClientWriter : ClientWriter
    {
        private static readonly FormattableString LroProcessMessageMethodName = $"{typeof(ProtocolOperationHelpers)}.{nameof(ProtocolOperationHelpers.ProcessMessage)}";
        private static readonly FormattableString LroProcessMessageMethodAsyncName = $"{typeof(ProtocolOperationHelpers)}.{nameof(ProtocolOperationHelpers.ProcessMessageAsync)}";
        private static readonly FormattableString LroProcessMessageWithoutResponseValueMethodName = $"{typeof(ProtocolOperationHelpers)}.{nameof(ProtocolOperationHelpers.ProcessMessageWithoutResponseValue)}";
        private static readonly FormattableString LroProcessMessageWithoutResponseValueMethodAsyncName = $"{typeof(ProtocolOperationHelpers)}.{nameof(ProtocolOperationHelpers.ProcessMessageWithoutResponseValueAsync)}";

        private readonly DpgOutputLibrary _library;
        private readonly CodeWriter _writer;
        private readonly XmlDocWriter _xmlDocWriter;
        private readonly LowLevelClient _client;

        public DpgClientWriter(DpgOutputLibrary library, LowLevelClient client)
        {
            _writer = new CodeWriter();
            _library = library;
            _xmlDocWriter = new XmlDocWriter($"Docs/{client.Type.Name}.xml");
            _client = client;
        }

        public XmlDocWriter XmlDocWriter => _xmlDocWriter;

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
                            var samples = clientMethod.Samples.Where(s => s.IsConvenienceSample);
                            WriteConvenienceMethodDocumentationWithExternalXmlDoc(convenienceMethod, true);
                            WriteConvenienceMethod(clientMethod, convenienceMethod, longRunning, pagingInfo, true);
                            WriteConvenienceMethodDocumentationWithExternalXmlDoc(convenienceMethod, false);
                            WriteConvenienceMethod(clientMethod, convenienceMethod, longRunning, pagingInfo, false);
                        }

                        WriteProtocolMethodDocumentationWithExternalXmlDoc(clientMethod, true);
                        WriteProtocolMethod(_writer, clientMethod, _client.Fields, longRunning, pagingInfo, true);
                        WriteProtocolMethodDocumentationWithExternalXmlDoc(clientMethod, false);
                        WriteProtocolMethod(_writer, clientMethod, _client.Fields, longRunning, pagingInfo, false);
                    }

                    foreach (var clientMethod in _client.CustomMethods())
                    {
                        //TODO: Write example docs for custom methods
                        //WriteProtocolMethodDocumentationWithExternalXmlDoc(clientMethod, true);
                        //WriteProtocolMethodDocumentationWithExternalXmlDoc(clientMethod, false);
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
                    WriteLongRunningResultRetrievalMethods();
                }
            }
        }

        private void WriteLongRunningResultRetrievalMethods()
        {
            foreach (var method in _client.ClientMethods.Select(c => c.LongRunningResultRetrievalMethod).WhereNotNull())
            {
                _writer.Line();
                WriteLroResultRetrievalMethod(method);
            }
        }

        public static void WriteProtocolMethods(CodeWriter writer, ClientFields fields, LowLevelClientMethod clientMethod)
        {
            WriteRequestCreationMethod(writer, clientMethod.RequestMethod, fields);

            var longRunning = clientMethod.LongRunning;
            var pagingInfo = clientMethod.PagingInfo;
            WriteProtocolMethodDocumentation(writer, clientMethod, true);
            WriteProtocolMethod(writer, clientMethod, fields, longRunning, pagingInfo, true);
            WriteProtocolMethodDocumentation(writer, clientMethod, false);
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
                .Line($"public virtual {Configuration.ApiTypes.HttpPipelineType} Pipeline => {_client.Fields.PipelineField.Name};");

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

                FormattableString perCallPolicies = $"Array.Empty<{Configuration.ApiTypes.HttpPipelinePolicyType}>()";
                FormattableString perRetryPolicies = $"Array.Empty<{Configuration.ApiTypes.HttpPipelinePolicyType}>()";

                var credentialParameter = signature.Parameters.FirstOrDefault(p => p.Name == "credential");
                if (credentialParameter != null)
                {
                    var credentialField = _client.Fields.GetFieldByParameter(credentialParameter);
                    if (credentialField != null)
                    {
                        var fieldName = credentialField.Name;
                        _writer.Line($"{fieldName:I} = {credentialParameter.Name:I};");
                        if (credentialField.Type.Equals(Configuration.ApiTypes.KeyCredentialType))
                        {
                            string prefixString = _client.Fields.AuthorizationApiKeyPrefixConstant != null ? $", {_client.Fields.AuthorizationApiKeyPrefixConstant.Name}" : "";
                            perRetryPolicies = $"new {Configuration.ApiTypes.HttpPipelinePolicyType}[] {{new {Configuration.ApiTypes.KeyCredentialPolicyType}({fieldName:I}, {_client.Fields.AuthorizationHeaderConstant!.Name}{prefixString})}}";
                        }
                        else if (credentialField.Type.Equals(typeof(TokenCredential)))
                        {
                            perRetryPolicies = $"new {Configuration.ApiTypes.HttpPipelinePolicyType}[] {{new {Configuration.ApiTypes.BearerAuthenticationPolicyType}({fieldName:I}, {_client.Fields.ScopesConstant!.Name})}}";
                        }
                    }
                }

                _writer.Line(Configuration.ApiTypes.GetHttpPipelineClassifierString(_client.Fields.PipelineField.Name, clientOptionsParameter.Name, perCallPolicies, perRetryPolicies));

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

        private void WriteConvenienceMethod(LowLevelClientMethod clientMethod, ConvenienceMethod convenienceMethod, ClientFields fields, bool async)
        {
            using (WriteConvenienceMethodDeclaration(_writer, convenienceMethod, fields, async))
            {
                var contextVariable = new CodeWriterDeclaration(KnownParameters.RequestContext.Name);

                var (parameterValues, converter) = convenienceMethod.GetParameterValues(contextVariable);

                // write whatever we need to convert the parameters
                converter(_writer);

                var responseVariable = new CodeWriterDeclaration(Configuration.ApiTypes.ResponseParameterName);
                _writer
                    .Append($"{clientMethod.ProtocolMethodSignature.ReturnType} {responseVariable:D} = ")
                    .WriteMethodCall(clientMethod.ProtocolMethodSignature, parameterValues, async)
                    .LineRaw(";");

                string rawResponseVariable = Configuration.ApiTypes.GetRawResponseString(responseVariable.ActualName);

                var responseType = convenienceMethod.ResponseType;
                if (responseType == null)
                {
                    _writer.Line($"return {responseVariable:I};");
                }
                else if (TypeFactory.IsReadOnlyList(responseType) || TypeFactory.IsReadOnlyDictionary(responseType))
                {
                    ResponseWriterHelpers.WriteRawResponseToGeneric(_writer, clientMethod.RequestMethod, clientMethod.RequestMethod.Responses[0], async, null, $"{responseVariable.ActualName}");
                }
                else if (responseType is { IsFrameworkType: false, Implementation: EnumType enumType })
                {
                    string declaredTypeName = enumType.Declaration.Name;
                    if (enumType.IsExtensible)
                    {
                        _writer.Line($"return {Configuration.ApiTypes.ResponseType}.{Configuration.ApiTypes.FromValueName}(new {declaredTypeName}({rawResponseVariable}.Content.ToObjectFromJson<{enumType.ValueType}>()), {rawResponseVariable});");
                    }
                    else
                    {
                        _writer.Line($"return {Configuration.ApiTypes.ResponseType}.{Configuration.ApiTypes.FromValueName}({rawResponseVariable}.Content.ToObjectFromJson<{enumType.ValueType}>().To{declaredTypeName}(), {rawResponseVariable});");
                    }
                }
                else if (responseType.IsFrameworkType && responseType.FrameworkType == typeof(BinaryData))
                {
                    _writer.Line($"return {Configuration.ApiTypes.ResponseType}.{Configuration.ApiTypes.FromValueName}({responseVariable:I}.Content, {responseVariable:I});");
                }
                else if (responseType.IsFrameworkType)
                {
                    _writer.Line($"return {Configuration.ApiTypes.ResponseType}.{Configuration.ApiTypes.FromValueName}({rawResponseVariable}.Content.ToObjectFromJson<{responseType}>(), {rawResponseVariable});");
                }
                else
                {
                    _writer.Line($"return {Configuration.ApiTypes.ResponseType}.{Configuration.ApiTypes.FromValueName}({responseType}.{Configuration.ApiTypes.FromResponseName}({rawResponseVariable}), {rawResponseVariable});");
                }
            }
            _writer.Line();
        }

        private void WriteConvenienceLroMethod(LowLevelClientMethod clientMethod, ConvenienceMethod convenienceMethod, ClientFields fields, bool async)
        {
            using (WriteConvenienceMethodDeclaration(_writer, convenienceMethod, fields, async))
            {
                var contextVariable = new CodeWriterDeclaration(KnownParameters.RequestContext.Name);

                var (parameterValues, converter) = convenienceMethod.GetParameterValues(contextVariable);

                // write whatever we need to convert the parameters
                converter(_writer);

                var responseType = convenienceMethod.ResponseType;
                if (responseType == null)
                {
                    // return [await] protocolMethod(parameters...)[.ConfigureAwait(false)];
                    _writer
                        .Append($"return ")
                        .WriteMethodCall(clientMethod.ProtocolMethodSignature, parameterValues, async)
                        .LineRaw(";");
                }
                else
                {
                    // Operation<BinaryData> response = [await] protocolMethod(parameters...)[.ConfigureAwait(false)];
                    var responseVariable = new CodeWriterDeclaration(Configuration.ApiTypes.ResponseParameterName);
                    _writer
                        .Append($"{clientMethod.ProtocolMethodSignature.ReturnType} {responseVariable:D} = ")
                        .WriteMethodCall(clientMethod.ProtocolMethodSignature, parameterValues, async)
                        .LineRaw(";");
                    // return ProtocolOperationHelpers.Convert(response, r => responseType.FromResponse(r), ClientDiagnostics, scopeName);
                    var diagnostic = convenienceMethod.Diagnostic ?? clientMethod.ProtocolMethodDiagnostic;
                    _writer.Line($"return {typeof(ProtocolOperationHelpers)}.{nameof(ProtocolOperationHelpers.Convert)}({responseVariable:I}, {GetConversionMethodStatement(clientMethod.LongRunningResultRetrievalMethod, responseType)}, {fields.ClientDiagnosticsProperty.Name}, {diagnostic.ScopeName:L});");
                }
            }
            _writer.Line();
        }

        private FormattableString GetConversionMethodStatement(LongRunningResultRetrievalMethod? convertMethod, CSharpType responseType)
        {
            if (convertMethod is null)
            {
                return $"{responseType}.FromResponse";
            }
            return $"{convertMethod.MethodSignature.Name}";
        }

        private void WriteLroResultRetrievalMethod(LongRunningResultRetrievalMethod method)
        {
            using (_writer.WriteMethodDeclaration(method.MethodSignature))
            {
                _writer.Line($"var resultJsonElement = {typeof(JsonDocument)}.{nameof(JsonDocument.Parse)}(response.{nameof(Response.Content)}).{nameof(JsonDocument.RootElement)}.{nameof(JsonElement.GetProperty)}(\"{method.ResultPath}\");");
                _writer.Line($"return {method.ReturnType}.Deserialize{method.ReturnType.Name}(resultJsonElement);");
            }
        }

        private void WriteConveniencePageableMethod(LowLevelClientMethod clientMethod, ConvenienceMethod convenienceMethod, ProtocolMethodPaging pagingInfo, ClientFields fields, bool async)
        {
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
                        .Line($"using {Configuration.ApiTypes.HttpMessageType} {messageVariable:D} = {RequestWriterHelpers.CreateRequestMethodName(startMethod.Name)}({startMethod.Parameters.GetIdentifiersFormattable()});")
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
                    writer
                        .Line($"using {Configuration.ApiTypes.HttpMessageType} {messageVariable:D} = {RequestWriterHelpers.CreateRequestMethodName(restMethod.Name)}({restMethod.Parameters.GetIdentifiersFormattable()});")
                        .WriteEnableHttpRedirectIfNecessary(clientMethod.RequestMethod, messageVariable);

                    writer.UseNamespace(Configuration.ApiTypes.PipelineExtensionsType.Namespace!);
                    var methodName = headAsBoolean ? Configuration.ApiTypes.GetProcessHeadAsBoolMessageName(async) : Configuration.ApiTypes.GetProcessMessageName(async);

                    FormattableString paramString = headAsBoolean
                        ? (FormattableString)$"{messageVariable}, {fields.ClientDiagnosticsProperty.Name}, {KnownParameters.RequestContext.Name:I}"
                        : (FormattableString)$"{messageVariable}, {KnownParameters.RequestContext.Name:I}";

                    if (headAsBoolean && !Configuration.IsBranded)
                    {
                        writer.Append($"var {Configuration.ApiTypes.ResponseParameterName} = ").WriteMethodCall(async, $"{fields.PipelineField.Name:I}.{methodName}", paramString).Line($";");
                        writer.Line($"return {Configuration.ApiTypes.ResponseType}.{Configuration.ApiTypes.FromValueName}({Configuration.ApiTypes.ResponseParameterName}.Value, {Configuration.ApiTypes.ResponseParameterName}.{Configuration.ApiTypes.GetRawResponseName}());");
                    }
                    else
                    {
                        writer.Append(Configuration.ApiTypes.ProtocolReturnStartString).WriteMethodCall(async, $"{fields.PipelineField.Name:I}.{methodName}", paramString).Line(Configuration.ApiTypes.ProtocolReturnEndString);
                    }
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
                using (writer.Scope($"private sealed class {responseClassifierTypeName}Override : {Configuration.ApiTypes.ResponseClassifierType}"))
                {
                    using (writer.Scope($"public override bool {Configuration.ApiTypes.ResponseClassifierIsErrorResponseName}({Configuration.ApiTypes.HttpMessageType} message)"))
                    {
                        using (writer.Scope($"return message.{Configuration.ApiTypes.HttpMessageResponseName}.{Configuration.ApiTypes.HttpMessageResponseStatusName} switch", end: "};"))
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

            writer.Line($"private static {Configuration.ApiTypes.ResponseClassifierType} _{responseClassifierTypeName.FirstCharToLowerCase()};");
            writer.Append($"private static {Configuration.ApiTypes.ResponseClassifierType} {responseClassifierTypeName} => _{responseClassifierTypeName.FirstCharToLowerCase()} ??= new ");
            if (hasStatusCodeRanges)
            {
                writer.Line($"{responseClassifierTypeName}Override();");
            }
            else
            {
                writer.Append($"{Configuration.ApiTypes.StatusCodeClassifierType}(stackalloc ushort[]{{");
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

        private void WriteProtocolMethodDocumentationWithExternalXmlDoc(LowLevelClientMethod clientMethod, bool isAsync)
        {
            var methodSignature = clientMethod.ProtocolMethodSignature.WithAsync(isAsync);

            WriteConvenienceMethodOmitReasonIfNecessary(clientMethod.ConvenienceMethodOmittingMessage);

            WriteMethodDocumentation(_writer, methodSignature, clientMethod, isAsync);

            WriteSampleRefsIfNecessary(methodSignature, isAsync);
        }

        private void WriteConvenienceMethodOmitReasonIfNecessary(ConvenienceMethodOmittingMessage? message)
        {
            // TODO -- create wiki links to provide guidance here: https://github.com/Azure/autorest.csharp/issues/3624
            if (message == null)
                return;

            _writer.Line($"// {message.Message}");
        }

        private void WriteConvenienceMethodDocumentationWithExternalXmlDoc(ConvenienceMethod convenienceMethod, bool isAsync)
        {
            var methodSignature = convenienceMethod.Signature.WithAsync(isAsync);

            _writer.WriteMethodDocumentation(methodSignature);
            _writer.WriteXmlDocumentation("remarks", methodSignature.DescriptionText);

            WriteSampleRefsIfNecessary(methodSignature, isAsync);
        }

        private void WriteSampleRefsIfNecessary(MethodSignature methodSignature, bool isAsync)
        {
            if (!Configuration.IsBranded)
                return;

            var sampleProvider = _library.GetSampleForClient(_client);
            // do not write this part when there is no sample provider
            if (sampleProvider == null)
                return;

            var samples = sampleProvider.GetSampleInformation(methodSignature, isAsync);
            // do not write this part when there is no sample for this method
            if (!samples.Any())
                return;

            var docRef = methodSignature.ToStringForDocs();
            _writer.Line($"/// <include file=\"{XmlDocWriter.Filename}\" path=\"doc/members/member[@name='{docRef}']/*\" />");

            _xmlDocWriter.AddMember(docRef);
            _xmlDocWriter.AddExamples(samples);
        }

        private static void WriteProtocolMethodDocumentation(CodeWriter writer, LowLevelClientMethod clientMethod, bool isAsync)
        {
            var methodSignature = clientMethod.ProtocolMethodSignature.WithAsync(isAsync);
            WriteMethodDocumentation(writer, methodSignature, clientMethod, isAsync);
        }

        private static IDisposable WriteConvenienceMethodDeclaration(CodeWriter writer, ConvenienceMethod convenienceMethod, ClientFields fields, bool async)
        {
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

        private void WriteCancellationTokenToRequestContextMethod()
        {
            var defaultRequestContext = new CodeWriterDeclaration("DefaultRequestContext");
            _writer.Line($"private static {Configuration.ApiTypes.RequestContextType} {defaultRequestContext:D} = new {Configuration.ApiTypes.RequestContextType}();");

            var methodSignature = new MethodSignature("FromCancellationToken", null, null, Internal | Static, Configuration.ApiTypes.RequestContextType, null, new List<Parameter> { KnownParameters.CancellationTokenParameter });
            using (_writer.WriteMethodDeclaration(methodSignature))
            {
                using (_writer.Scope($"if (!{KnownParameters.CancellationTokenParameter.Name}.{nameof(CancellationToken.CanBeCanceled)})"))
                {
                    _writer.Line($"return {defaultRequestContext:I};");
                }

                _writer.Line().Line($"return new {Configuration.ApiTypes.RequestContextType}() {{ CancellationToken = {KnownParameters.CancellationTokenParameter.Name} }};");
            }
            _writer.Line();
        }

        private static FormattableString BuildProtocolMethodSummary(MethodSignature methodSignature, LowLevelClientMethod clientMethod, bool async)
        {
            var builder = new StringBuilder();
            builder.AppendLine($"[Protocol Method] {methodSignature.SummaryText}");
            builder.AppendLine($"<list type=\"bullet\">");
            builder.AppendLine($"<item>{Environment.NewLine}<description>{Environment.NewLine}This <see href=\"https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md\">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.{Environment.NewLine}</description>{Environment.NewLine}</item>");

            // we only append the relative convenience method information when the convenience method is public
            if (clientMethod.ShouldGenerateConvenienceMethodRef())
            {
                var convenienceDocRef = clientMethod.ConvenienceMethod!.Signature.WithAsync(async).ToStringForDocs();
                builder.AppendLine($"<item>{Environment.NewLine}<description>{Environment.NewLine}Please try the simpler <see cref=\"{convenienceDocRef}\"/> convenience overload with strongly typed models first.{Environment.NewLine}</description>{Environment.NewLine}</item>");
            }
            builder.AppendLine($"</list>");
            return $"{builder.ToString().Trim(Environment.NewLine.ToCharArray())}";
        }

        private static void WriteMethodDocumentation(CodeWriter codeWriter, MethodSignature methodSignature, LowLevelClientMethod clientMethod, bool async)
        {
            codeWriter.WriteMethodDocumentation(methodSignature, BuildProtocolMethodSummary(methodSignature, clientMethod, async));
            codeWriter.WriteXmlDocumentationException(Configuration.ApiTypes.RequestFailedExceptionType, $"Service returned a non-success status code.");

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
                text = (FormattableString)$"The <see cref=\"{nameof(Operation)}\"/> representing an asynchronous operation on the service.";
            }
            else if (returnType.EqualsIgnoreNullable(Configuration.ApiTypes.GetTaskOfResponse()) || returnType.EqualsIgnoreNullable(Configuration.ApiTypes.ResponseType))
            {
                text = (FormattableString)$"The response returned from the service.";
            }
            else if (returnType.EqualsIgnoreNullable(Configuration.ApiTypes.GetTaskOfResponse(typeof(bool))) || returnType.EqualsIgnoreNullable(Configuration.ApiTypes.GetResponseOfT<bool>()))
            {
                text = $"The response returned from the service.";
            }
            else
            {
                throw new InvalidOperationException($"Xml documentation generation for return type {methodSignature.ReturnType} is not supported!");
            }

            codeWriter.WriteXmlDocumentationReturns(text);
        }

        //TODO: We should be able to deep link to the service schema documentation instead of creating our own.  Keeping this function here until we confirm
        private static void WriteDocumentationRemarks(Action<string, FormattableString?> writeXmlDocumentation, RestClientMethod requestMethod, bool isPagingMethod, MethodSignature methodSignature, IReadOnlyCollection<FormattableString> schemas, bool hasRequestRemarks, bool hasResponseRemarks, bool addDescription)
        {
            if (requestMethod.Operation.ExternalDocsUrl == null)
                return;

            var docInfo = requestMethod.Operation.ExternalDocsUrl != null
                ? $"Additional information can be found in the service REST API documentation:{Environment.NewLine}{requestMethod.Operation.ExternalDocsUrl}{Environment.NewLine}"
                : (FormattableString)$"";

            var schemaDesription = "";
            if (hasRequestRemarks && hasResponseRemarks)
            {
                if (isPagingMethod)
                {
                    schemaDesription = "Below is the JSON schema for the request payload and one item in the pageable response.";
                }
                else
                {
                    schemaDesription = "Below is the JSON schema for the request and response payloads.";
                }
            }
            else if (hasRequestRemarks)
            {
                schemaDesription = "Below is the JSON schema for the request payload.";
            }
            else if (hasResponseRemarks)
            {
                if (isPagingMethod)
                {
                    schemaDesription = "Below is the JSON schema for one item in the pageable response.";
                }
                else
                {
                    schemaDesription = "Below is the JSON schema for the response payload.";
                }
            }

            if (addDescription && !string.IsNullOrEmpty(methodSignature.DescriptionText?.ToString()))
            {
                schemaDesription = $"{methodSignature.DescriptionText}{Environment.NewLine}{Environment.NewLine}{schemaDesription}";
            }

            writeXmlDocumentation("remarks", $"{schemaDesription}{Environment.NewLine}{docInfo}{schemas}");
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
                InputPrimitiveType { Kind: InputTypeKind.DateTimeRFC3339 } => "string (RFC3339 Format)",
                InputPrimitiveType { Kind: InputTypeKind.DateTimeRFC7231 } => "string (RFC7231 Format)",
                InputPrimitiveType { Kind: InputTypeKind.DateTimeUnix } => "string (Unix Format)",
                InputPrimitiveType { Kind: InputTypeKind.DurationISO8601 } => "string (duration ISO 8601 Format)",
                InputPrimitiveType { Kind: InputTypeKind.DurationConstant } => "string (duration)",
                InputPrimitiveType { Kind: InputTypeKind.Time } => "string (time)",
                InputEnumType enumType => string.Join(" | ", enumType.AllowedValues.Select(c => $"\"{c.Value}\"")),
                InputDictionaryType dictionaryType => $"Dictionary<string, {StringifyTypeForTable(dictionaryType.ValueType)}>",
                InputListType listType => $"{StringifyTypeForTable(listType.ElementType)}[]",
                InputIntrinsicType { Kind: InputIntrinsicTypeKind.Unknown } => "any",
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

        public override string ToString()
        {
            return _writer.ToString();
        }
    }
}

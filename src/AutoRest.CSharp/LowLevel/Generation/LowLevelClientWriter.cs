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
        private static readonly Parameter ScopeNameParameter = new("diagnosticsScopeName", null, new CSharpType(typeof(string)), null, ValidationType.None, null);
        private static readonly Parameter ResponseParameter = new("response", null, typeof(Response), null, ValidationType.None, null);
        private static readonly Parameter NextLinkParameter = new("nextLink", null, new CSharpType(typeof(string), true), null, ValidationType.None, null);
        private static readonly Parameter PageSizeHintParameter = new("pageSizeHint", null, new CSharpType(typeof(int), true), null, ValidationType.None, null);

        private static readonly FormattableString PageableProcessMessageMethodName = $"{typeof(LowLevelPageableHelpers)}.{nameof(LowLevelPageableHelpers.ProcessMessage)}";
        private static readonly FormattableString PageableProcessMessageMethodAsyncName = $"{typeof(LowLevelPageableHelpers)}.{nameof(LowLevelPageableHelpers.ProcessMessageAsync)}";
        private static readonly FormattableString LroProcessMessageMethodName = $"{typeof(ProtocolOperationHelpers)}.{nameof(ProtocolOperationHelpers.ProcessMessage)}";
        private static readonly FormattableString LroProcessMessageMethodAsyncName = $"{typeof(ProtocolOperationHelpers)}.{nameof(ProtocolOperationHelpers.ProcessMessageAsync)}";
        private static readonly FormattableString LroProcessMessageWithoutResponseValueMethodName = $"{typeof(ProtocolOperationHelpers)}.{nameof(ProtocolOperationHelpers.ProcessMessageWithoutResponseValue)}";
        private static readonly FormattableString LroProcessMessageWithoutResponseValueMethodAsyncName = $"{typeof(ProtocolOperationHelpers)}.{nameof(ProtocolOperationHelpers.ProcessMessageWithoutResponseValueAsync)}";
        private static readonly FormattableString CreatePageableMethodName = $"{typeof(PageableHelpers)}.{nameof(PageableHelpers.CreatePageable)}";
        private static readonly FormattableString CreateAsyncPageableMethodName = $"{typeof(PageableHelpers)}.{nameof(PageableHelpers.CreateAsyncPageable)}";


        private static readonly CodeWriterDeclaration DefaultRequestContext = new CodeWriterDeclaration("DefaultRequestContext");
        private static readonly MethodSignature FromCancellationTokenMethodSignature = new MethodSignature("FromCancellationToken", null, null, Internal | Static, typeof(RequestContext), null, new List<Parameter> { KnownParameters.CancellationTokenParameter });

        private CodeWriter writer { get; init; }
        private XmlDocWriter xmlDocWriter { get; init; }
        private LowLevelClient client { get; init; }
        private LowLevelExampleComposer exampleComposer { get; init; }

        public LowLevelClientWriter(CodeWriter writer, XmlDocWriter xmlDocWriter, LowLevelClient client)
        {
            this.writer = writer;
            this.xmlDocWriter = xmlDocWriter;
            this.client = client;
            exampleComposer = new LowLevelExampleComposer(client);
        }

        public void WriteClient()
        {
            var clientType = client.Type;
            using (writer.Namespace(clientType.Namespace))
            {
                WriteDPGIdentificationComment();
                writer.WriteXmlDocumentationSummary($"{client.Description}");
                using (writer.Scope($"{client.Declaration.Accessibility} partial class {clientType:D}", scopeDeclarations: client.Fields.ScopeDeclarations))
                {
                    WriteClientFields();
                    WriteConstructors();

                    foreach (var pagingMethod in client.PagingMethods)
                    {
                        DataPlaneClientWriter.WritePagingOperation(writer, pagingMethod, true, client.Fields.ClientDiagnosticsProperty.Name, false);
                        DataPlaneClientWriter.WritePagingOperation(writer, pagingMethod, false, client.Fields.ClientDiagnosticsProperty.Name, false);

                        RestClientWriter.WriteOperation(writer, pagingMethod.Method, client.Fields.PipelineField.Name, true, WriteFuncBodyWithProcessMessage, $"{pagingMethod.Method.Name}FirstPage", MethodSignatureModifiers.Private);
                        RestClientWriter.WriteOperation(writer, pagingMethod.Method, client.Fields.PipelineField.Name, false, WriteFuncBodyWithProcessMessage, $"{pagingMethod.Method.Name}FirstPage", MethodSignatureModifiers.Private);
                        if (pagingMethod.NextPageMethod != null)
                        {
                            RestClientWriter.WriteOperation(writer, pagingMethod.NextPageMethod, client.Fields.PipelineField.Name, true, WriteFuncBodyWithProcessMessage, null, MethodSignatureModifiers.Private);
                            RestClientWriter.WriteOperation(writer, pagingMethod.NextPageMethod, client.Fields.PipelineField.Name, false, WriteFuncBodyWithProcessMessage, null, MethodSignatureModifiers.Private);
                        }
                    }

                    foreach (var clientMethod in client.ClientMethods)
                    {
                        var longRunning = clientMethod.LongRunning;
                        if (longRunning != null)
                        {
                            WriteLongRunningOperationMethods(clientMethod, client.Fields, longRunning, true);
                            WriteLongRunningOperationMethods(clientMethod, client.Fields, longRunning, false);
                        }
                        else if (clientMethod.PagingInfo != null)
                        {
                            WritePagingMethod(clientMethod, client.Fields, true);
                            WritePagingMethod(clientMethod, client.Fields, false);
                        }
                        else
                        {
                            if (clientMethod.ConvenienceMethod is not null)
                            {
                                WriteConvenienceMethod(clientMethod.ProtocolMethodSignature, clientMethod.ConvenienceMethod, client.Fields, true);
                                WriteConvenienceMethod(clientMethod.ProtocolMethodSignature, clientMethod.ConvenienceMethod, client.Fields, false);
                            }
                            WriteClientMethod(clientMethod, client.Fields, true);
                            WriteClientMethod(clientMethod, client.Fields, false);
                        }
                    }

                    WriteSubClientFactoryMethod();

                    foreach (var method in client.RequestMethods)
                    {
                        WriteRequestCreationMethod(writer, method, client.Fields);
                    }

                    if (client.ClientMethods.Any(cm => cm.ConvenienceMethod is not null))
                    {
                        WriteCancellationTokenToRequestContextMethod();
                    }
                    WriteResponseClassifierMethod(writer, client.ResponseClassifierTypes);
                }
            }
        }

        private void WriteFuncBodyWithProcessMessage(CodeWriter writer, CodeWriterDeclaration messageVariable, RestClientMethod operation, string pipelineName, bool async)
        {
            var contextVariable = new CodeWriterDeclaration(KnownParameters.RequestContext.Name);
            WriteCancellationTokenToRequestContext(writer, contextVariable);

            var requestMethodName = RequestWriterHelpers.CreateRequestMethodName(operation.Name);
            var responseVariable = new CodeWriterDeclaration("response");

            writer
                .Line($"using var {messageVariable:D} = {requestMethodName}({operation.Parameters.GetIdentifiersFormattable()});")
                .Append($"{typeof(Response)} {responseVariable:D} = ")
                .WriteMethodCall(async, $"{pipelineName}.ProcessMessageAsync", $"{pipelineName}.ProcessMessage", $"{messageVariable}, {KnownParameters.RequestContext.Name}");

            writer.Line($"return {typeof(Response)}.{nameof(Response.FromValue)}({operation.ReturnType}.FromResponse({responseVariable:I}), {responseVariable:I});");
        }

        private void WriteDPGIdentificationComment()
        {
            writer.Line($"// Data plane generated {(client.IsSubClient ? "sub-client" : "client")}.");
        }

        private void WriteClientFields()
        {
            foreach (var field in client.Fields)
            {
                writer.WriteField(field, declareInCurrentScope: false);
            }

            //TODO: make this a field??
            writer
                .Line()
                .WriteXmlDocumentationSummary($"The HTTP pipeline for sending and receiving REST requests and responses.")
                .Line($"public virtual {typeof(HttpPipeline)} Pipeline => {client.Fields.PipelineField.Name};");

            writer.Line();
        }

        private void WriteConstructors()
        {
            foreach (var constructor in client.SecondaryConstructors)
            {
                WriteSecondaryPublicConstructor(constructor);
            }

            foreach (var constructor in client.PrimaryConstructors)
            {
                WritePrimaryPublicConstructor(constructor);
            }

            if (client.IsSubClient)
            {
                WriteSubClientInternalConstructor(client.SubClientInternalConstructor);
            }
        }

        private void WriteSecondaryPublicConstructor(ConstructorSignature signature)
        {
            writer.WriteMethodDocumentation(signature);
            using (writer.WriteMethodDeclaration(signature))
            {
            }
            writer.Line();
        }

        private void WritePrimaryPublicConstructor(ConstructorSignature signature)
        {
            writer.WriteMethodDocumentation(signature);
            using (writer.WriteMethodDeclaration(signature))
            {
                writer.WriteParametersValidation(signature.Parameters);
                writer.Line();

                var clientOptionsParameter = signature.Parameters.Last(p => p.Type.EqualsIgnoreNullable(client.ClientOptions.Type));
                writer.Line($"{client.Fields.ClientDiagnosticsProperty.Name:I} = new {client.Fields.ClientDiagnosticsProperty.Type}({clientOptionsParameter.Name:I}, true);");

                FormattableString perCallPolicies = $"Array.Empty<{typeof(HttpPipelinePolicy)}>()";
                FormattableString perRetryPolicies = $"Array.Empty<{typeof(HttpPipelinePolicy)}>()";

                var credentialParameter = signature.Parameters.FirstOrDefault(p => p.Name == "credential");
                if (credentialParameter != null)
                {
                    var credentialField = client.Fields.GetFieldByParameter(credentialParameter);
                    if (credentialField != null)
                    {
                        var fieldName = credentialField.Name;
                        writer.Line($"{fieldName:I} = {credentialParameter.Name:I};");
                        if (credentialField.Type.Equals(typeof(AzureKeyCredential)))
                        {
                            perRetryPolicies = $"new {typeof(HttpPipelinePolicy)}[] {{new {typeof(AzureKeyCredentialPolicy)}({fieldName:I}, {client.Fields.AuthorizationHeaderConstant!.Name})}}";
                        }
                        else if (credentialField.Type.Equals(typeof(TokenCredential)))
                        {
                            perRetryPolicies = $"new {typeof(HttpPipelinePolicy)}[] {{new {typeof(BearerTokenAuthenticationPolicy)}({fieldName:I}, {client.Fields.ScopesConstant!.Name})}}";
                        }
                    }
                }

                writer.Line($"{client.Fields.PipelineField.Name:I} = {typeof(HttpPipelineBuilder)}.{nameof(HttpPipelineBuilder.Build)}({clientOptionsParameter.Name:I}, {perCallPolicies}, {perRetryPolicies}, new {typeof(ResponseClassifier)}());");

                foreach (var parameter in client.Parameters)
                {
                    var field = client.Fields.GetFieldByParameter(parameter);
                    if (field != null)
                    {
                        if (parameter.IsApiVersionParameter)
                        {
                            writer.Line($"{field.Name:I} = {clientOptionsParameter.Name:I}.Version;");
                        }
                        else
                        {
                            writer.Line($"{field.Name:I} = {parameter.Name:I};");
                        }
                    }
                }
            }
            writer.Line();
        }

        private void WriteSubClientInternalConstructor(ConstructorSignature signature)
        {
            writer.WriteMethodDocumentation(signature);
            using (writer.WriteMethodDeclaration(signature))
            {
                writer.WriteParametersValidation(signature.Parameters);
                writer.Line();

                foreach (var parameter in signature.Parameters)
                {
                    var field = client.Fields.GetFieldByParameter(parameter);
                    if (field != null)
                    {
                        writer.Line($"{field.Name:I} = {parameter.Name:I};");
                    }
                }
            }
            writer.Line();
        }

        public void WriteClientMethod(LowLevelClientMethod clientMethod, ClientFields fields, bool async)
        {
            using (WriteClientMethodDeclarationWithExternalXmlDoc(clientMethod, async))
            {
                WriteProtocolMethodBody(writer, clientMethod, fields, async);
            }
            writer.Line();
        }

        public static void WriteClientMethod(CodeWriter writer, LowLevelClientMethod clientMethod, ClientFields fields, bool async)
        {
            using (WriteClientMethodDeclaration(writer, clientMethod, async))
            {
                WriteProtocolMethodBody(writer, clientMethod, fields, async);
            }
            writer.Line();
        }

        private void WriteConvenienceMethod(MethodSignature protocolMethodSignature, ConvenienceMethod convenienceMethod, ClientFields fields, bool async)
        {
            using (WriteConvenienceMethodDeclaration(writer, convenienceMethod.Signature, async))
            {
                if (convenienceMethod.Diagnostic != null)
                {
                    using (WriteDiagnosticScope(writer, convenienceMethod.Diagnostic, fields.ClientDiagnosticsProperty.Name))
                    {
                        WriteConvenienceMethodBody(writer, protocolMethodSignature, convenienceMethod, async);
                    }
                }
                else
                {
                    WriteConvenienceMethodBody(writer, protocolMethodSignature, convenienceMethod, async);
                }
            }
            writer.Line();
        }

        private static void WriteProtocolMethodBody(CodeWriter writer, LowLevelClientMethod clientMethod, ClientFields fields, bool async)
        {
            var restMethod = clientMethod.RequestMethod;
            var headAsBoolean = restMethod.Request.HttpMethod == RequestMethod.Head && Configuration.HeadAsBoolean;

            if (clientMethod.ConditionHeaderFlag != RequestConditionHeaders.None && clientMethod.ConditionHeaderFlag != (RequestConditionHeaders.IfMatch | RequestConditionHeaders.IfNoneMatch | RequestConditionHeaders.IfModifiedSince | RequestConditionHeaders.IfUnmodifiedSince))
            {
                writer.WriteRequestConditionParameterChecks(restMethod.Parameters, clientMethod.ConditionHeaderFlag);
                writer.Line();
            }

            using (WriteDiagnosticScope(writer, clientMethod.ProtocolMethodDiagnostic, fields.ClientDiagnosticsProperty.Name))
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

        private static void WriteConvenienceMethodBody(CodeWriter writer, MethodSignature protocolMethodSignature, ConvenienceMethod convenienceMethod, bool async)
        {
            var contextVariable = new CodeWriterDeclaration(KnownParameters.RequestContext.Name);
            WriteCancellationTokenToRequestContext(writer, contextVariable);

            IReadOnlyList<FormattableString> parameters = prepareConvenienceMethodParameters(convenienceMethod, contextVariable);

            var responseVariable = new CodeWriterDeclaration("response");
            writer
                .Append($"{typeof(Response)} {responseVariable:D} = ")
                .WriteMethodCall(protocolMethodSignature, parameters, async)
                .LineRaw(";");

            var responseType = convenienceMethod.ResponseType;
            if (responseType == null)
            {
                writer.Line($"return {responseVariable:I};");
            }
            else
            {
                writer.Line($"return {typeof(Response)}.{nameof(Response.FromValue)}({responseType}.FromResponse({responseVariable:I}), {responseVariable:I});");
            }
        }

        private static void WriteNonPageableLongRunningOperationConvenienceMethodBody(CodeWriter writer, MethodSignature protocolMethodSignature, ConvenienceMethod convenienceMethod, string clientDiagnosticsPropertyName, Diagnostic diagnostic, bool async)
        {
            var contextVariable = new CodeWriterDeclaration(KnownParameters.RequestContext.Name);
            WriteCancellationTokenToRequestContext(writer, contextVariable);

            IReadOnlyList<FormattableString> parameters = prepareConvenienceMethodParameters(convenienceMethod, contextVariable);

            using (WriteDiagnosticScope(writer, diagnostic, clientDiagnosticsPropertyName))
            {
                var responseType = convenienceMethod.ResponseType;
                if (responseType == null)
                {
                    // return [await] protocolMethod(parameters...)[.ConfigureAwait(failse)];
                    writer
                        .Append($"return ")
                        .WriteMethodCall(protocolMethodSignature, parameters, async)
                        .LineRaw(";");
                }
                else
                {
                    // Operation<BinaryData> response = [await] protocolMethod(parameters...)[.ConfigureAwait(false)];
                    var responseVariable = new CodeWriterDeclaration("response");
                    writer
                        .Append($"{protocolMethodSignature.ReturnType} {responseVariable:D} = ")
                        .WriteMethodCall(protocolMethodSignature, parameters, async)
                        .LineRaw(";");
                    // return ProtocolOperationHelpers.Convert(response, r => responseType.FromResponse(r), ClientDiagnostics, scopeName);
                    writer.Line($"return {typeof(ProtocolOperationHelpers)}.{nameof(ProtocolOperationHelpers.Convert)}({responseVariable:I}, r => {responseType}.FromResponse(r), {clientDiagnosticsPropertyName}, \"{diagnostic.ScopeName}\");");
                }

            }
        }

        // RequestContext context = FromCancellationToken(cancellationToken);
        private static void WriteCancellationTokenToRequestContext(CodeWriter writer, CodeWriterDeclaration contextVariable)
        {
            writer.Line($"{typeof(RequestContext)} {contextVariable:D} = FromCancellationToken({KnownParameters.CancellationTokenParameter.Name});");
        }

        private static IReadOnlyList<FormattableString> prepareConvenienceMethodParameters(ConvenienceMethod convenienceMethod, CodeWriterDeclaration contextVariable)
        {
            var parameters = new List<FormattableString>();
            foreach (var (protocolParameter, convenienceParameter) in convenienceMethod.ProtocolToConvenienceParameters)
            {
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
            }

            return parameters;
        }

        public void WritePagingMethod(LowLevelClientMethod clientMethod, ClientFields fields, bool async)
        {
            MethodSignature privateMethodSignature = PreparePrivatePagingMethodSignature(clientMethod, async);

            using (WriteClientMethodDeclarationWithExternalXmlDoc(clientMethod, async))
            {
                writer.Line($"return {privateMethodSignature.Name}({clientMethod.ProtocolMethodDiagnostic.ScopeName:L}, {clientMethod.ProtocolMethodSignature.Parameters.GetIdentifiersFormattable()});");
            }

            writer.Line();

            WritePagingPrivateMethod(writer, clientMethod, fields, privateMethodSignature, async);

            writer.Line();
        }

        public static void WritePagingMethod(CodeWriter writer, LowLevelClientMethod clientMethod, ClientFields fields, bool async)
        {
            MethodSignature privateMethodSignature = PreparePrivatePagingMethodSignature(clientMethod, async);

            using (WriteClientMethodDeclaration(writer, clientMethod, async))
            {
                writer.Line($"return {privateMethodSignature.Name}({clientMethod.ProtocolMethodDiagnostic.ScopeName:L}, {clientMethod.ProtocolMethodSignature.Parameters.GetIdentifiersFormattable()});");
            }

            writer.Line();

            WritePagingPrivateMethod(writer, clientMethod, fields, privateMethodSignature, async);

            writer.Line();
        }

        private static MethodSignature PreparePrivatePagingMethodSignature(LowLevelClientMethod clientMethod, bool async)
        {
            return (clientMethod.ProtocolMethodSignature with
            {
                Name = $"{clientMethod.ProtocolMethodSignature.Name}Implementation",
                Summary = null,
                Modifiers = Private,
                Description = null,
                Parameters = clientMethod.ProtocolMethodSignature.Parameters
                    .Select(p => p with { DefaultValue = null })
                    .Prepend(ScopeNameParameter).ToArray()
            }).WithAsync(async);
        }

        private static void WritePagingPrivateMethod(CodeWriter writer, LowLevelClientMethod clientMethod, ClientFields fields, MethodSignature privateMethodSignature, bool async)
        {
            var method = clientMethod.RequestMethod;
            var pagingInfo = clientMethod.PagingInfo!;
            var nextPageMethod = pagingInfo.NextPageMethod;

            using (writer.WriteMethodDeclaration(privateMethodSignature))
            {
                var createEnumerableMethodSignature = new MethodSignature("CreateEnumerable", null, null, None, typeof(IEnumerable<Page<BinaryData>>), null, new[] { NextLinkParameter, PageSizeHintParameter }).WithAsync(async);
                var createEnumerableMethod = new CodeWriterDeclaration(createEnumerableMethodSignature.Name);

                var createPageableMethodName = async ? CreateAsyncPageableMethodName : CreatePageableMethodName;
                writer.Line($"return {createPageableMethodName}({createEnumerableMethod:D}, {fields.ClientDiagnosticsProperty.Name:I}, {ScopeNameParameter.Name:I});");

                // We don't properly handle the case when one of the parameters has a name "nextLink" but isn't a continuation token
                // So we assume that it is a string and use variable "nextLink" without declaration.

                using (writer.WriteMethodDeclaration(createEnumerableMethodSignature with { Name = createEnumerableMethod.ActualName }))
                {
                    var messageVariable = new CodeWriterDeclaration("message");
                    var pageVariable = new CodeWriterDeclaration("page");
                    FormattableString processMessageMethodParameters = $"{fields.PipelineField.Name:I}, {messageVariable}, {KnownParameters.RequestContext.Name:I}, {pagingInfo.ItemName:L}, {pagingInfo.NextLinkName:L}{(async ? $", {KnownParameters.EnumeratorCancellationTokenParameter.Name:I}" : "")}";

                    if (nextPageMethod == null)
                    {
                        writer
                            .Line($"using var {messageVariable:D} = Create{method.Name}Request({method.Parameters.GetIdentifiersFormattable()});")
                            .Append($"var {pageVariable:D} = ").WriteMethodCall(async, PageableProcessMessageMethodAsyncName, PageableProcessMessageMethodName, processMessageMethodParameters)
                            .Line($"yield return {pageVariable};");
                    }
                    else
                    {
                        using (writer.Scope($"do", newLine: false))
                        {
                            if (method != nextPageMethod)
                            {
                                writer
                                    .Line($"var {messageVariable:D} = string.IsNullOrEmpty(nextLink)")
                                    .Line($"    ? Create{method.Name}Request({method.Parameters.GetIdentifiersFormattable()})")
                                    .Line($"    : Create{nextPageMethod.Name}Request({nextPageMethod.Parameters.GetIdentifiersFormattable()});");
                            }
                            else
                            {
                                writer.Line($"var {messageVariable:D} = Create{method.Name}Request({method.Parameters.GetIdentifiersFormattable()});");
                            }

                            writer
                                .Append($"var {pageVariable:D} = ").WriteMethodCall(async, PageableProcessMessageMethodAsyncName, PageableProcessMessageMethodName, processMessageMethodParameters)
                                .Line($"nextLink = {pageVariable}.{nameof(Page<BinaryData>.ContinuationToken)};")
                                .Line($"yield return {pageVariable};");
                        }

                        writer.Line($"while (!string.IsNullOrEmpty(nextLink));");
                    }
                }
            }
        }

        /// <summary>
        /// Write protocol method and convenience method (optional) of a long running operation.
        /// </summary>
        /// <param name="clientMethod"></param>
        /// <param name="fields"></param>
        /// <param name="longRunning"></param>
        /// <param name="async"></param>
        private void WriteLongRunningOperationMethods(LowLevelClientMethod clientMethod, ClientFields fields, OperationLongRunning longRunning, bool async)
        {
            var pagingInfo = clientMethod.PagingInfo;
            var nextPageMethod = pagingInfo?.NextPageMethod;

            if (pagingInfo != null && nextPageMethod != null)
            {
                WritePageableLongRunningOperationMethods(clientMethod, fields, pagingInfo, nextPageMethod, longRunning, async);
            }
            else
            {
                WriteNonPageableLongRunningOperationMethods(clientMethod, fields, longRunning, async);
            }

            writer.Line();
        }

        public static void WriteLongRunningOperationMethod(CodeWriter writer, LowLevelClientMethod clientMethod, ClientFields fields, OperationLongRunning longRunning, bool async)
        {
            var pagingInfo = clientMethod.PagingInfo;
            var nextPageMethod = pagingInfo?.NextPageMethod;

            if (pagingInfo != null && nextPageMethod != null)
            {
                WritePageableLongRunningOperationMethod(writer, clientMethod, fields, pagingInfo, nextPageMethod, longRunning, async);
            }
            else
            {
                WriteNonPageableLongRunningOperationMethod(writer, clientMethod, fields, longRunning, async);
            }

            writer.Line();
        }

        private void WriteNonPageableLongRunningOperationMethods(LowLevelClientMethod clientMethod, ClientFields fields, OperationLongRunning longRunning, bool async)
        {
            if (clientMethod.ConvenienceMethod is not null)
            {
                if (clientMethod.ConvenienceMethod.Diagnostic != null)
                {
                    WriteNonPageableLongRunningOperationConvenienceMethod(clientMethod.ProtocolMethodSignature, clientMethod.ConvenienceMethod, clientMethod.ConvenienceMethod.Diagnostic, fields.ClientDiagnosticsProperty.Name, async);
                }
                else
                {
                    WriteNonPageableLongRunningOperationConvenienceMethod(clientMethod.ProtocolMethodSignature, clientMethod.ConvenienceMethod, clientMethod.ProtocolMethodDiagnostic, fields.ClientDiagnosticsProperty.Name, async);
                }
            }

            using (WriteClientMethodDeclarationWithExternalXmlDoc(clientMethod, async))
            {
                WriteNonPageableLongRunningOperationMethodBody(writer, clientMethod, fields, longRunning, async);
            }
        }

        private void WriteNonPageableLongRunningOperationConvenienceMethod(MethodSignature protocolMethodSignature, ConvenienceMethod convenienceMethod, Diagnostic diagnostic, string clientDiagnosticsPropertyName, bool async)
        {
            using (WriteConvenienceMethodDeclaration(writer, convenienceMethod.Signature, async))
            {
                WriteNonPageableLongRunningOperationConvenienceMethodBody(writer, protocolMethodSignature, convenienceMethod, clientDiagnosticsPropertyName, diagnostic, async);
            }
            writer.Line();
        }

        private static void WriteNonPageableLongRunningOperationMethod(CodeWriter writer, LowLevelClientMethod clientMethod, ClientFields fields, OperationLongRunning longRunning, bool async)
        {
            using (WriteClientMethodDeclaration(writer, clientMethod, async))
            {
                WriteNonPageableLongRunningOperationMethodBody(writer, clientMethod, fields, longRunning, async);
            }
        }

        private static void WriteNonPageableLongRunningOperationMethodBody(CodeWriter writer, LowLevelClientMethod clientMethod, ClientFields fields, OperationLongRunning longRunning, bool async)
        {
            var startMethod = clientMethod.RequestMethod;
            var finalStateVia = longRunning.FinalStateVia;
            var scopeName = clientMethod.ProtocolMethodDiagnostic.ScopeName;

            using (WriteDiagnosticScope(writer, clientMethod.ProtocolMethodDiagnostic, fields.ClientDiagnosticsProperty.Name))
            {
                var messageVariable = new CodeWriterDeclaration("message");
                var processMessageParameters = (FormattableString)$"{fields.PipelineField.Name:I}, {messageVariable}, {fields.ClientDiagnosticsProperty.Name:I}, {scopeName:L}, {typeof(OperationFinalStateVia)}.{finalStateVia}, {KnownParameters.RequestContext.Name:I}, {KnownParameters.WaitForCompletion.Name:I}";

                writer
                    .Line($"using {typeof(HttpMessage)} {messageVariable:D} = {RequestWriterHelpers.CreateRequestMethodName(startMethod.Name)}({startMethod.Parameters.GetIdentifiersFormattable()});")
                    .AppendRaw("return ")
                    .WriteMethodCall(async, clientMethod.ResponseBodyType != null ? LroProcessMessageMethodAsyncName : LroProcessMessageWithoutResponseValueMethodAsyncName, clientMethod.ResponseBodyType != null ? LroProcessMessageMethodName : LroProcessMessageWithoutResponseValueMethodName, processMessageParameters);
            }
        }

        public void WritePageableLongRunningOperationMethods(LowLevelClientMethod clientMethod, ClientFields fields, ProtocolMethodPaging pagingInfo, RestClientMethod nextPageMethod, OperationLongRunning longRunning, bool async)
        {
            using (WriteClientMethodDeclarationWithExternalXmlDoc(clientMethod, async))
            {
                WritePageableLongRunningOperationMethodBody(writer, clientMethod, fields, pagingInfo, nextPageMethod, longRunning, async);
            }
        }

        public static void WritePageableLongRunningOperationMethod(CodeWriter writer, LowLevelClientMethod clientMethod, ClientFields fields, ProtocolMethodPaging pagingInfo, RestClientMethod nextPageMethod, OperationLongRunning longRunning, bool async)
        {
            using (WriteClientMethodDeclaration(writer, clientMethod, async))
            {
                WritePageableLongRunningOperationMethodBody(writer, clientMethod, fields, pagingInfo, nextPageMethod, longRunning, async);
            }
        }

        private static void WritePageableLongRunningOperationMethodBody(CodeWriter writer, LowLevelClientMethod clientMethod, ClientFields fields, ProtocolMethodPaging pagingInfo, RestClientMethod nextPageMethod, OperationLongRunning longRunning, bool async)
        {
            var startMethod = clientMethod.RequestMethod;
            var finalStateVia = longRunning.FinalStateVia;
            var scopeName = clientMethod.ProtocolMethodDiagnostic.ScopeName;

            var createEnumerableMethodSignature = new MethodSignature("CreateEnumerable", null, null, None, typeof(IEnumerable<Page<BinaryData>>), null, new[] { ResponseParameter, NextLinkParameter, PageSizeHintParameter }).WithAsync(async);
            var createEnumerableMethod = new CodeWriterDeclaration(createEnumerableMethodSignature.Name);

            using (WriteDiagnosticScope(writer, clientMethod.ProtocolMethodDiagnostic, fields.ClientDiagnosticsProperty.Name))
            {
                var messageVariable = new CodeWriterDeclaration("message");
                var processMessageParameters = (FormattableString)$"{fields.PipelineField.Name:I}, {messageVariable}, {fields.ClientDiagnosticsProperty.Name:I}, {scopeName:L}, {typeof(OperationFinalStateVia)}.{finalStateVia}, {KnownParameters.RequestContext.Name:I}, {KnownParameters.WaitForCompletion.Name:I}, {createEnumerableMethod:D}";

                writer
                    .Line($"using {typeof(HttpMessage)} {messageVariable:D} = {RequestWriterHelpers.CreateRequestMethodName(startMethod.Name)}({startMethod.Parameters.GetIdentifiersFormattable()});")
                    .AppendRaw("return ")
                    .WriteMethodCall(async, clientMethod.ResponseBodyType != null ? LroProcessMessageMethodAsyncName : LroProcessMessageWithoutResponseValueMethodAsyncName, clientMethod.ResponseBodyType != null ? LroProcessMessageMethodName : LroProcessMessageWithoutResponseValueMethodName, processMessageParameters);
            }

            using (writer.Line().WriteMethodDeclaration(createEnumerableMethodSignature with { Name = createEnumerableMethod.ActualName }))
            {
                var pageVariable = new CodeWriterDeclaration("page");
                writer.Line($"Page<BinaryData> {pageVariable:D};");

                // We don't properly handle the case when one of the parameters has a name "nextLink" but isn't a continuation token
                // So we assume that it is a string and use variable "nextLink" without declaration.
                using (writer.Scope($"if ({NextLinkParameter.Name} == null)"))
                {
                    writer
                        .Line($"{pageVariable} = {typeof(LowLevelPageableHelpers)}.{nameof(LowLevelPageableHelpers.BuildPageForResponse)}(response, {pagingInfo.ItemName:L}, {pagingInfo.NextLinkName:L});")
                        .Line($"{NextLinkParameter.Name} = {pageVariable}.{nameof(Page<BinaryData>.ContinuationToken)};")
                        .Line($"yield return {pageVariable};");
                }

                using (writer.Scope($"while (!string.IsNullOrEmpty({NextLinkParameter.Name}))"))
                {
                    var messageVariable = new CodeWriterDeclaration("message");
                    writer.Line($"var {messageVariable:D} = Create{nextPageMethod.Name}Request({nextPageMethod.Parameters.GetIdentifiersFormattable()});");

                    FormattableString pageableProcessMessageParameters = $"{fields.PipelineField.Name:I}, {messageVariable}, {KnownParameters.RequestContext.Name:I}, {pagingInfo.ItemName:L}, {pagingInfo.NextLinkName:L}{(async ? $", {KnownParameters.EnumeratorCancellationTokenParameter.Name:I}" : "")}";

                    writer
                        .Append($"{pageVariable} = ").WriteMethodCall(async, PageableProcessMessageMethodAsyncName, PageableProcessMessageMethodName, pageableProcessMessageParameters)
                        .Line($"{NextLinkParameter.Name} = {pageVariable}.{nameof(Page<BinaryData>.ContinuationToken)};")
                        .Line($"yield return {pageVariable};");
                }
            }
        }

        private void WriteSubClientFactoryMethod()
        {
            foreach (var field in client.SubClients.Select(s => s.FactoryMethod?.CachingField))
            {
                if (field != null)
                {
                    writer.WriteField(field);
                }
            }

            writer.Line();

            foreach (var (methodSignature, field, constructorCallParameters) in client.SubClients.Select(s => s.FactoryMethod).WhereNotNull())
            {
                writer.WriteMethodDocumentation(methodSignature);
                using (writer.WriteMethodDeclaration(methodSignature))
                {
                    writer.WriteParametersValidation(methodSignature.Parameters);
                    writer.Line();

                    var references = constructorCallParameters
                        .Select(p => client.Fields.GetFieldByParameter(p) ?? (Reference)p)
                        .ToArray();

                    if (field != null)
                    {
                        writer
                            .Append($"return {typeof(Volatile)}.{nameof(Volatile.Read)}(ref {field.Name})")
                            .Append($" ?? {typeof(Interlocked)}.{nameof(Interlocked.CompareExchange)}(ref {field.Name}, new {methodSignature.ReturnType}({references.GetIdentifiersFormattable()}), null)")
                            .Line($" ?? {field.Name};");
                    }
                    else
                    {
                        writer.Line($"return new {methodSignature.ReturnType}({references.GetIdentifiersFormattable()});");
                    }
                }
                writer.Line();
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

        private IDisposable WriteClientMethodDeclarationWithExternalXmlDoc(LowLevelClientMethod clientMethod, bool async)
        {
            var methodSignature = clientMethod.ProtocolMethodSignature.WithAsync(async);

            var remarks = CreateSchemaDocumentationRemarks(clientMethod, out var hasRequestRemarks, out var hasResponseRemarks);
            WriteMethodDocumentation(writer, methodSignature, clientMethod, hasResponseRemarks);
            var docRef = GetMethodSingatureString(clientMethod.ProtocolMethodSignature, async);
            writer.Line($"/// <include file=\"Docs/{client.Type.Name}.xml\" path=\"doc/members/member[@name='{docRef}']/*\" />");
            using (xmlDocWriter.CreateMember(docRef))
            {
                xmlDocWriter.WriteXmlDocumentation("example", exampleComposer.Compose(clientMethod, async));
                WriteDocumentationRemarks(xmlDocWriter.WriteXmlDocumentation, clientMethod, methodSignature, remarks, hasRequestRemarks, hasResponseRemarks);
            }

            var scope = writer.WriteMethodDeclaration(methodSignature);
            writer.WriteParametersValidation(methodSignature.Parameters);
            return scope;
        }

        private static string GetMethodSingatureString(MethodSignature signature, bool async)
        {
            var builder = new StringBuilder(signature.Name);
            if (async)
            {
                builder.Append("Async");
            }
            builder.Append("(");
            builder.Append(string.Join(",", signature.Parameters.Select(p => p.Type.Name)));
            builder.Append(")");
            return builder.ToString();
        }

        private static IDisposable WriteClientMethodDeclaration(CodeWriter writer, LowLevelClientMethod clientMethod, bool async)
        {
            var methodSignature = clientMethod.ProtocolMethodSignature.WithAsync(async);

            var remarks = CreateSchemaDocumentationRemarks(clientMethod, out var hasRequestRemarks, out var hasResponseRemarks);
            WriteMethodDocumentation(writer, methodSignature, clientMethod, hasResponseRemarks);
            WriteDocumentationRemarks((string tag, FormattableString? text) => writer.WriteXmlDocumentation(tag, text), clientMethod, methodSignature, remarks, hasRequestRemarks, hasResponseRemarks);

            var scope = writer.WriteMethodDeclaration(methodSignature);
            writer.WriteParametersValidation(methodSignature.Parameters);
            return scope;
        }

        private static IDisposable WriteConvenienceMethodDeclaration(CodeWriter writer, MethodSignature convenienceMethod, bool async)
        {
            var methodSignature = convenienceMethod.WithAsync(async);
            writer
                .WriteMethodDocumentation(methodSignature)
                .WriteXmlDocumentation("remarks", $"{methodSignature.DescriptionText}");

            var scope = writer.WriteMethodDeclaration(methodSignature);
            writer.WriteParametersValidation(methodSignature.Parameters);
            return scope;
        }

        private void WriteCancellationTokenToRequestContextMethod()
        {
            writer.Line($"private static {typeof(RequestContext)} {DefaultRequestContext:D} = new {typeof(RequestContext)}();");

            using (writer.WriteMethodDeclaration(FromCancellationTokenMethodSignature))
            {
                using (writer.Scope($"if (!{KnownParameters.CancellationTokenParameter.Name}.{nameof(CancellationToken.CanBeCanceled)})"))
                {
                    writer.Line($"return {DefaultRequestContext:I};");
                }

                writer.Line().Line($"return new {typeof(RequestContext)}() {{ CancellationToken = {KnownParameters.CancellationTokenParameter.Name} }};");
            }
            writer.Line();
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

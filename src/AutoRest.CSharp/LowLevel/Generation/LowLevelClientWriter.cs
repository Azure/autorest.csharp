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
using AutoRest.CSharp.Common.Output.Models.Responses;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Output.Builders;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;
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
        private readonly CodeWriter _writer;
        private readonly XmlDocWriter _xmlDocWriter;
        private readonly LowLevelClient _client;
        private readonly LowLevelExampleComposer _exampleComposer;

        public LowLevelClientWriter(CodeWriter writer, XmlDocWriter xmlDocWriter, LowLevelClient client, LowLevelExampleComposer exampleComposer)
        {
            _writer = writer;
            _xmlDocWriter = xmlDocWriter;
            _client = client;
            _exampleComposer = exampleComposer;
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
                        if (clientMethod.Convenience.Any())
                        {
                            WriteConvenienceMethodDocumentationWithExternalXmlDoc(clientMethod, (MethodSignature)clientMethod.Convenience[0].Signature, true);
                            _writer.WriteMethod(clientMethod.Convenience[0]);
                            WriteConvenienceMethodDocumentationWithExternalXmlDoc(clientMethod, (MethodSignature)clientMethod.Convenience[1].Signature, false);
                            _writer.WriteMethod(clientMethod.Convenience[1]);

                            WriteProtocolMethodDocumentationWithExternalXmlDoc(clientMethod, (MethodSignature)clientMethod.Protocol[0].Signature, (MethodSignature)clientMethod.Convenience[0].Signature, true);
                            _writer.WriteMethod(clientMethod.Protocol[0]);
                            WriteProtocolMethodDocumentationWithExternalXmlDoc(clientMethod, (MethodSignature)clientMethod.Protocol[1].Signature, (MethodSignature)clientMethod.Convenience[1].Signature, false);
                            _writer.WriteMethod(clientMethod.Protocol[1]);
                        }
                        else
                        {
                            WriteProtocolMethodDocumentationWithExternalXmlDoc(clientMethod, (MethodSignature)clientMethod.Protocol[0].Signature, null, true);
                            _writer.WriteMethod(clientMethod.Protocol[0]);
                            WriteProtocolMethodDocumentationWithExternalXmlDoc(clientMethod, (MethodSignature)clientMethod.Protocol[1].Signature, null, false);
                            _writer.WriteMethod(clientMethod.Protocol[1]);
                        }
                    }

                    WriteSubClientFactoryMethod();

                    foreach (var method in _client.RequestMethods)
                    {
                        _writer.WriteMethod(method);
                    }

                    foreach (var method in _client.RequestNextPageMethods)
                    {
                        _writer.WriteMethod(method);
                    }

                    if (_client.ClientMethods.Any(cm => cm.Convenience.Any()))
                    {
                        WriteCancellationTokenToRequestContextMethod();
                    }
                    WriteResponseClassifierMethod(_writer, _client.ResponseClassifierTypes);
                }
            }
        }

        public static void WriteProtocolMethods(CodeWriter writer, ClientFields fields, LowLevelClientMethod clientMethod)
        {
            foreach (var requestMethod in clientMethod.CreateRequest)
            {
                writer.WriteMethod(requestMethod);
            }

            foreach (var protocolMethod in clientMethod.Protocol)
            {
                WriteProtocolMethodDocumentation(writer, clientMethod, (MethodSignature)protocolMethod.Signature);
                writer.WriteMethod(protocolMethod);
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

        public static void WriteResponseClassifierMethod(CodeWriter writer, IEnumerable<ResponseClassifierType> responseClassifierTypes)
        {
            foreach ((string name, StatusCodes[] statusCodes) in responseClassifierTypes)
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

        private void WriteProtocolMethodDocumentationWithExternalXmlDoc(LowLevelClientMethod clientMethod, MethodSignature protocolMethod, MethodSignature? convenienceMethod, bool async)
        {
            WriteMethodDocumentation(_writer, protocolMethod, convenienceMethod, clientMethod);
            var docRef = GetMethodSignatureString(protocolMethod);
            _writer.Line($"/// <include file=\"Docs/{_client.Type.Name}.xml\" path=\"doc/members/member[@name='{docRef}']/*\" />");
            using (_xmlDocWriter.CreateMember(docRef))
            {
                _xmlDocWriter.WriteXmlDocumentation("example", _exampleComposer.ComposeProtocol(clientMethod, protocolMethod, async));
                WriteDocumentationRemarks(_xmlDocWriter.WriteXmlDocumentation, clientMethod, protocolMethod, false);
            }
        }

        private void WriteConvenienceMethodDocumentationWithExternalXmlDoc(LowLevelClientMethod clientMethod, MethodSignature convenienceMethod, bool async)
        {
            _writer.WriteMethodDocumentation(convenienceMethod);
            _writer.WriteXmlDocumentation("remarks", $"{convenienceMethod.DescriptionText}");
            var docRef = GetMethodSignatureString(convenienceMethod);
            _writer.Line($"/// <include file=\"Docs/{_client.Type.Name}.xml\" path=\"doc/members/member[@name='{docRef}']/*\" />");
            using (_xmlDocWriter.CreateMember(docRef))
            {
                _xmlDocWriter.WriteXmlDocumentation("example", _exampleComposer.ComposeConvenience(convenienceMethod, async));
                WriteDocumentationRemarks(_xmlDocWriter.WriteXmlDocumentation, clientMethod, convenienceMethod, false);
            }
        }

        private static string GetMethodSignatureString(MethodSignature signature)
            => $"{signature.Name}({string.Join(",", signature.Parameters.Select(p => p.Type.ToStringForDocs()))})";

        private static void WriteProtocolMethodDocumentation(CodeWriter writer, LowLevelClientMethod clientMethod, MethodSignature methodSignature)
        {
            WriteMethodDocumentation(writer, methodSignature, null, clientMethod);
            WriteDocumentationRemarks((tag, text) => writer.WriteXmlDocumentation(tag, text), clientMethod, methodSignature, false);
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

        private static FormattableString BuildProtocolMethodSummary(MethodSignature protocolMethod, MethodSignature? convenienceMethod)
        {
            var builder = new StringBuilder();
            builder.AppendLine($"[Protocol Method] {protocolMethod.SummaryText}");
            builder.AppendLine($"<list type=\"bullet\">");
            builder.AppendLine($"<item>{Environment.NewLine}<description>{Environment.NewLine}This <see href=\"https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md\">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.{Environment.NewLine}</description>{Environment.NewLine}</item>");

            if (convenienceMethod != null)
            {
                var convenienceDocRef = GetMethodSignatureString(convenienceMethod);
                builder.AppendLine($"<item>{Environment.NewLine}<description>{Environment.NewLine}Please try the simpler <see cref=\"{convenienceDocRef}\"/> convenience overload with strongly typed models first.{Environment.NewLine}</description>{Environment.NewLine}</item>");
            }

            builder.AppendLine($"</list>");
            return $"{builder.ToString().Trim(Environment.NewLine.ToCharArray())}";
        }

        private static void WriteMethodDocumentation(CodeWriter codeWriter, MethodSignature protocolMethod, MethodSignature? convenienceMethod, LowLevelClientMethod clientMethod)
        {
            codeWriter.WriteXmlDocumentationSummary(BuildProtocolMethodSummary(protocolMethod, convenienceMethod));
            codeWriter.WriteMethodDocumentationSignature(protocolMethod);
            codeWriter.WriteXmlDocumentationException(typeof(RequestFailedException), $"Service returned a non-success status code.");

            if (protocolMethod.ReturnType == null)
            {
                return;
            }

            if (!protocolMethod.ReturnType.IsFrameworkType)
            {
                throw new InvalidOperationException($"Xml documentation generation is supported only for protocol methods. {protocolMethod.ReturnType} can't be a return type of a protocol method.");
            }

            var returnType = protocolMethod.ReturnType;

            FormattableString text;
            if (clientMethod is { Operation.Paging: not null, Operation.LongRunning: not null })
            {
                CSharpType pageableType = protocolMethod.Modifiers.HasFlag(Async) ? typeof(AsyncPageable<>) : typeof(Pageable<>);
                text = $"The <see cref=\"{nameof(Operation)}{{T}}\"/> from the service that will contain a <see cref=\"{pageableType.Name}{{T}}\"/> containing a list of <see cref=\"{nameof(BinaryData)}\"/> objects once the asynchronous operation on the service has completed. Details of the body schema for the operation's final value are in the Remarks section below.";
            }
            else if (clientMethod.Operation.Paging is not null)
            {
                text = $"The <see cref=\"{returnType.Name}{{T}}\"/> from the service containing a list of <see cref=\"{returnType.Arguments[0]}\"/> objects. Details of the body schema for each item in the collection are in the Remarks section below.";
            }
            else if (clientMethod.Operation.LongRunning is not null)
            {
                text = $"The <see cref=\"{nameof(Operation)}\"/> representing an asynchronous operation on the service.";
            }
            else if (returnType.EqualsIgnoreNullable(typeof(Task<Response>)) || returnType.EqualsIgnoreNullable(typeof(Response)))
            {
                text = $"The response returned from the service.";
            }
            else if (returnType.EqualsIgnoreNullable(typeof(Task<Response<bool>>)) || returnType.EqualsIgnoreNullable(typeof(Response<bool>)))
            {
                text = $"The response returned from the service.";
            }
            else
            {
                throw new InvalidOperationException($"Xml documentation generation for return type {protocolMethod.ReturnType} is not supported!");
            }

            codeWriter.WriteXmlDocumentationReturns(text);
        }

        private static void WriteDocumentationRemarks(Action<string, FormattableString?> writeXmlDocumentation, LowLevelClientMethod clientMethod, MethodSignature methodSignature, bool addDescription)
        {
            if (clientMethod.Operation.ExternalDocsUrl == null)
            {
                return;
            }

            var docInfo = clientMethod.Operation.ExternalDocsUrl is {} externalDocsUrl
                ? $"Additional information can be found in the service REST API documentation:{Environment.NewLine}{externalDocsUrl}{Environment.NewLine}"
                : (FormattableString)$"";

            var schemaDesription = "";
            if (addDescription && !methodSignature.DescriptionText.IsNullOrEmpty())
            {
                schemaDesription = $"{methodSignature.DescriptionText}{Environment.NewLine}{Environment.NewLine}{schemaDesription}";
            }

            writeXmlDocumentation("remarks", $"{schemaDesription}{Environment.NewLine}{docInfo}");
        }
    }
}

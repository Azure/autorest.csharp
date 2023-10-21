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
using AutoRest.CSharp.Common.Output.Expressions.Statements;
using AutoRest.CSharp.Common.Output.Models;
using AutoRest.CSharp.Common.Output.Models.Responses;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.LowLevel.Output.Samples;
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
    internal class DpgClientWriter : ClientWriter
    {
        private readonly CodeWriter _writer;
        private readonly XmlDocWriter _xmlDocWriter;
        private readonly DpgClient _client;
        private readonly DpgClientSampleProvider _sampleComposer;

        public DpgClientWriter(DpgClient client, DpgClientSampleProvider sampleComposer, CodeWriter writer, XmlDocWriter xmlDocWriter)
        {
            _writer = writer;
            _xmlDocWriter = xmlDocWriter;
            _client = client;
            _sampleComposer = sampleComposer;
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

                    // Temporary sorting to minimize amount of changes in generated code.
                    foreach (var clientMethod in _client.OperationMethods.OrderBy(b => b.Order))
                    {
                        if (clientMethod.ConvenienceAsync is {} convenienceAsync)
                        {
                            WriteConvenienceMethodDocumentationWithExternalXmlDoc(convenienceAsync);
                            _writer.WriteMethod(convenienceAsync);
                        }

                        if (clientMethod.Convenience is {} convenience)
                        {
                            WriteConvenienceMethodDocumentationWithExternalXmlDoc(convenience);
                            _writer.WriteMethod(convenience);
                        }

                        if (clientMethod.ProtocolAsync is {} protocolAsync)
                        {
                            WriteProtocolMethodDocumentationWithExternalXmlDoc(clientMethod, protocolAsync, clientMethod.ConvenienceAsync?.Signature as MethodSignature);
                            _writer.WriteMethod(protocolAsync);
                        }

                        if (clientMethod.Protocol is {} protocol1)
                        {
                            WriteProtocolMethodDocumentationWithExternalXmlDoc(clientMethod, protocol1, clientMethod.Convenience?.Signature as MethodSignature);
                            _writer.WriteMethod(protocol1);
                        }
                    }

                    WriteSubClientFactoryMethod();

                    foreach (var method in _client.OperationMethods.Select(m => m.CreateRequest))
                    {
                        _writer.WriteMethod(method);
                    }

                    foreach (var method in _client.OperationMethods.Select(m => m.CreateNextPageMessage).WhereNotNull())
                    {
                        _writer.WriteMethod(method);
                    }

                    if (_client.OperationMethods.Any(cm => cm.Convenience is not null))
                    {
                        WriteCancellationTokenToRequestContextMethod();
                    }
                    WriteResponseClassifierMethod(_writer, _client.ResponseClassifierTypes);
                }
            }
        }

        public static void WriteProtocolMethod(CodeWriter writer, Method method, RestClientOperationMethods operationMethods)
        {
            WriteProtocolMethodDocumentation(writer, operationMethods, method.Signature);
            writer.WriteMethod(method);
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

        private void WriteProtocolMethodDocumentationWithExternalXmlDoc(RestClientOperationMethods operationMethods, Method protocolMethod, MethodSignature? convenienceMethodSignature)
        {
            var signature = (MethodSignature)protocolMethod.Signature;
            WriteMethodDocumentation(_writer, signature, convenienceMethodSignature, operationMethods);
            WriteSampleRefsIfNecessary(signature);
        }

        private void WriteConvenienceMethodDocumentationWithExternalXmlDoc(Method convenienceMethod)
        {
            var signature = (MethodSignature)convenienceMethod.Signature;
            _writer.WriteMethodDocumentation(signature);
            _writer.WriteXmlDocumentation("remarks", $"{signature.DescriptionText}");
            WriteSampleRefsIfNecessary(signature);
        }

        private void WriteSampleRefsIfNecessary(MethodSignatureBase signature)
        {
            if (!Configuration.IsBranded)
                return;

            var samples = _sampleComposer.GetSampleInformation(signature).ToList();
            if (!samples.Any())
            {
                // do not write this part when there is no sample for this method
                return;
            }

            var docRef = GetMethodSignatureString(signature);
            _writer.WriteXmlDocumentationInclude(_client.Type, docRef);
            _xmlDocWriter.AddMember(docRef);
            _xmlDocWriter.AddExamples(samples.Select(s => (s.ExampleInformation, GetSampleString(s.TestMethodBody))));
        }

        private static string GetSampleString(MethodBodyStatement statement)
        {
            using var codeWriter = new CodeWriter(appendTypeNameOnly: true);
            codeWriter.WriteMethodBodyStatement(statement);
            return SamplesFormattingSyntaxRewriter.FormatCodeBlock(codeWriter.ToString(false));
        }

        private static string GetMethodSignatureString(MethodSignatureBase signature)
            => $"{signature.Name}({string.Join(",", signature.Parameters.Select(p => p.Type.ToStringForDocs()))})";

        private static void WriteProtocolMethodDocumentation(CodeWriter writer, RestClientOperationMethods operationMethods, MethodSignatureBase methodSignature)
        {
            WriteMethodDocumentation(writer, (MethodSignature)methodSignature, null, operationMethods);
            WriteDocumentationRemarks((tag, text) => writer.WriteXmlDocumentation(tag, text), operationMethods, methodSignature, false);
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

        private static FormattableString BuildProtocolMethodSummary(MethodSignatureBase protocolMethod, MethodSignature? convenienceMethod)
        {
            var builder = new StringBuilder();
            builder.AppendLine($"[Protocol Method] {protocolMethod.SummaryText}");
            builder.AppendLine($"<list type=\"bullet\">");
            builder.AppendLine($"<item>{Environment.NewLine}<description>{Environment.NewLine}This <see href=\"https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md\">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.{Environment.NewLine}</description>{Environment.NewLine}</item>");

            if (convenienceMethod is not null && convenienceMethod.Modifiers.HasFlag(Public))
            {
                var convenienceDocRef = GetMethodSignatureString(convenienceMethod);
                builder.AppendLine($"<item>{Environment.NewLine}<description>{Environment.NewLine}Please try the simpler <see cref=\"{convenienceDocRef}\"/> convenience overload with strongly typed models first.{Environment.NewLine}</description>{Environment.NewLine}</item>");
            }

            builder.AppendLine($"</list>");
            return $"{builder.ToString().Trim(Environment.NewLine.ToCharArray())}";
        }

        private static void WriteMethodDocumentation(CodeWriter codeWriter, MethodSignature protocolMethod, MethodSignature? convenienceMethod, RestClientOperationMethods operationMethods)
        {
            if (protocolMethod.NonDocumentComment is { } comment)
            {
                codeWriter.Line($"// {comment}");
            }

            codeWriter.WriteXmlDocumentationSummary(BuildProtocolMethodSummary(protocolMethod, convenienceMethod));
            codeWriter.WriteMethodDocumentationSignature(protocolMethod);
            codeWriter.WriteXmlDocumentationException(Configuration.ApiTypes.RequestFailedExceptionType, $"Service returned a non-success status code.");

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
            if (operationMethods is { Operation.Paging: not null, Operation.LongRunning: not null })
            {
                CSharpType pageableType = protocolMethod.Modifiers.HasFlag(Async) ? typeof(AsyncPageable<>) : typeof(Pageable<>);
                text = $"The <see cref=\"{nameof(Operation)}{{T}}\"/> from the service that will contain a <see cref=\"{pageableType.Name}{{T}}\"/> containing a list of <see cref=\"{nameof(BinaryData)}\"/> objects once the asynchronous operation on the service has completed. Details of the body schema for the operation's final value are in the Remarks section below.";
            }
            else if (operationMethods.Operation.Paging is not null)
            {
                text = $"The <see cref=\"{returnType.Name}{{T}}\"/> from the service containing a list of <see cref=\"{returnType.Arguments[0]}\"/> objects. Details of the body schema for each item in the collection are in the Remarks section below.";
            }
            else if (operationMethods.Operation.LongRunning is not null)
            {
                text = $"The <see cref=\"{nameof(Operation)}\"/> representing an asynchronous operation on the service.";
            }
            else if (returnType.EqualsIgnoreNullable(Configuration.ApiTypes.GetTaskOfResponse()) || returnType.EqualsIgnoreNullable(Configuration.ApiTypes.ResponseType))
            {
                text = $"The response returned from the service.";
            }
            else if (returnType.EqualsIgnoreNullable(Configuration.ApiTypes.GetTaskOfResponse(typeof(bool))) || returnType.EqualsIgnoreNullable(Configuration.ApiTypes.GetResponseOfT<bool>()))
            {
                text = $"The response returned from the service.";
            }
            else
            {
                throw new InvalidOperationException($"Xml documentation generation for return type {protocolMethod.ReturnType} is not supported!");
            }

            codeWriter.WriteXmlDocumentationReturns(text);
        }

        private static void WriteDocumentationRemarks(Action<string, FormattableString?> writeXmlDocumentation, RestClientOperationMethods operationMethods, MethodSignatureBase methodSignature, bool addDescription)
        {
            if (operationMethods.Operation.ExternalDocsUrl == null)
            {
                return;
            }

            var docInfo = operationMethods.Operation.ExternalDocsUrl is {} externalDocsUrl
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

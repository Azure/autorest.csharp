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
using Response = Azure.Response;
using StatusCodes = AutoRest.CSharp.Output.Models.Responses.StatusCodes;
using static AutoRest.CSharp.Output.Models.MethodSignatureModifiers;
using Operation = Azure.Operation;

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

        public void WriteClient(CodeWriter writer, LowLevelClient client)
        {
            var clientType = client.Type;
            using (writer.Namespace(clientType.Namespace))
            {
                writer.WriteXmlDocumentationSummary($"{client.Description}");
                using (writer.Scope($"{client.Declaration.Accessibility} partial class {clientType:D}"))
                {
                    WriteClientFields(writer, client);
                    WriteConstructors(writer, client);

                    var exampleComposer = new LowLevelExampleComposer(client);
                    foreach (var clientMethod in client.ClientMethods)
                    {
                        var longRunning = clientMethod.LongRunning;
                        if (longRunning != null)
                        {
                            WriteLongRunningOperationMethod(writer, clientMethod, client.Fields, longRunning, exampleComposer, true);
                            WriteLongRunningOperationMethod(writer, clientMethod, client.Fields, longRunning, exampleComposer, false);
                        }
                        else if (clientMethod.PagingInfo != null)
                        {
                            WritePagingMethod(writer, clientMethod, client.Fields, exampleComposer, true);
                            WritePagingMethod(writer, clientMethod, client.Fields, exampleComposer, false);
                        }
                        else
                        {
                            WriteClientMethod(writer, clientMethod, client.Fields, exampleComposer, true);
                            WriteClientMethod(writer, clientMethod, client.Fields, exampleComposer, false);
                        }
                    }

                    WriteSubClientFactoryMethod(writer, client);

                    var responseClassifierTypes = new List<ResponseClassifierType>();
                    foreach (var method in client.RequestMethods)
                    {
                        WriteRequestCreationMethod(writer, method, client.Fields, responseClassifierTypes);
                    }

                    WriteResponseClassifierMethod(writer, responseClassifierTypes);
                }
            }
        }

        private static void WriteClientFields(CodeWriter writer, LowLevelClient client)
        {
            foreach (var field in client.Fields)
            {
                writer.WriteFieldDeclaration(field);
            }

            writer
                .Line()
                .WriteXmlDocumentationSummary($"The HTTP pipeline for sending and receiving REST requests and responses.")
                .Line($"public virtual {typeof(HttpPipeline)} Pipeline => {client.Fields.PipelineField.Name};");

            writer.Line();
        }

        private static void WriteConstructors(CodeWriter writer, LowLevelClient client)
        {
            foreach (var constructor in client.SecondaryConstructors)
            {
                WriteSecondaryPublicConstructor(writer, constructor);
            }

            foreach (var constructor in client.PrimaryConstructors)
            {
                WritePrimaryPublicConstructor(writer, client, constructor);
            }

            if (client.IsSubClient)
            {
                WriteSubClientInternalConstructor(writer, client, client.SubClientInternalConstructor);
            }
        }

        private static void WriteSecondaryPublicConstructor(CodeWriter writer, ConstructorSignature signature)
        {
            writer.WriteMethodDocumentation(signature);
            using (writer.WriteMethodDeclaration(signature))
            {
            }
            writer.Line();
        }

        private static void WritePrimaryPublicConstructor(CodeWriter writer, LowLevelClient client, ConstructorSignature signature)
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

        private static void WriteSubClientInternalConstructor(CodeWriter writer, LowLevelClient client, ConstructorSignature signature)
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

        public static void WriteClientMethod(CodeWriter writer, LowLevelClientMethod clientMethod, ClientFields fields, bool async)
        {
            using (WriteClientMethodDeclaration(writer, clientMethod, async))
            {
                WriteClientMethodBody(writer, clientMethod, fields, async);
            }
            writer.Line();
        }

        public static void WriteClientMethod(CodeWriter writer, LowLevelClientMethod clientMethod, ClientFields fields, LowLevelExampleComposer exampleComposer, bool async)
        {
            using (WriteClientMethodDeclaration(writer, clientMethod, exampleComposer, async))
            {
                WriteClientMethodBody(writer, clientMethod, fields, async);
            }
            writer.Line();
        }

        private static void WriteClientMethodBody(CodeWriter writer, LowLevelClientMethod clientMethod, ClientFields fields, bool async)
        {
            var restMethod = clientMethod.RequestMethod;
            var headAsBoolean = restMethod.Request.HttpMethod == RequestMethod.Head && Configuration.HeadAsBoolean;

            if (restMethod.ConditionHeaderFlag != RequestConditionHeaders.None && clientMethod.RequestMethod.ConditionHeaderFlag != (RequestConditionHeaders.IfMatch | RequestConditionHeaders.IfNoneMatch | RequestConditionHeaders.IfModifiedSince | RequestConditionHeaders.IfUnmodifiedSince))
            {
                writer.WriteRequestConditionParameterChecks(restMethod.Parameters, clientMethod.RequestMethod.ConditionHeaderFlag);
                writer.Line();
            }
            using (WriteDiagnosticScope(writer, clientMethod.Diagnostic, fields.ClientDiagnosticsProperty.Name))
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

        public static void WritePagingMethod(CodeWriter writer, LowLevelClientMethod clientMethod, ClientFields fields, bool async)
        {
            MethodSignature privateMethodSignature = PreparePrivatePagingMethodSignature(clientMethod, async);

            using (WriteClientMethodDeclaration(writer, clientMethod, async))
            {
                writer.Line($"return {privateMethodSignature.Name}({clientMethod.Diagnostic.ScopeName:L}, {clientMethod.Signature.Parameters.GetIdentifiersFormattable()});");
            }

            writer.Line();

            WritePagingPrivateMethod(writer, clientMethod, fields, privateMethodSignature, async);

            writer.Line();
        }

        public static void WritePagingMethod(CodeWriter writer, LowLevelClientMethod clientMethod, ClientFields fields, LowLevelExampleComposer exampleComposer, bool async)
        {
            MethodSignature privateMethodSignature = PreparePrivatePagingMethodSignature(clientMethod, async);

            using (WriteClientMethodDeclaration(writer, clientMethod, exampleComposer, async))
            {
                writer.Line($"return {privateMethodSignature.Name}({clientMethod.Diagnostic.ScopeName:L}, {clientMethod.Signature.Parameters.GetIdentifiersFormattable()});");
            }

            writer.Line();

            WritePagingPrivateMethod(writer, clientMethod, fields, privateMethodSignature, async);

            writer.Line();
        }

        private static MethodSignature PreparePrivatePagingMethodSignature(LowLevelClientMethod clientMethod, bool async)
        {
            return (clientMethod.Signature with
            {
                Name = $"{clientMethod.Signature.Name}Implementation",
                Summary = null,
                Modifiers = Private,
                Description = null,
                Parameters = clientMethod.Signature.Parameters
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

        public static void WriteLongRunningOperationMethod(CodeWriter writer, LowLevelClientMethod clientMethod, ClientFields fields, OperationLongRunning longRunning, LowLevelExampleComposer exampleComposer, bool async)
        {
            var pagingInfo = clientMethod.PagingInfo;
            var nextPageMethod = pagingInfo?.NextPageMethod;

            if (pagingInfo != null && nextPageMethod != null)
            {
                WritePageableLongRunningOperationMethod(writer, clientMethod, fields, pagingInfo, nextPageMethod, longRunning, exampleComposer, async);
            }
            else
            {
                WriteNonPageableLongRunningOperationMethod(writer, clientMethod, fields, longRunning, exampleComposer, async);
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

        private static void WriteNonPageableLongRunningOperationMethod(CodeWriter writer, LowLevelClientMethod clientMethod, ClientFields fields, OperationLongRunning longRunning, LowLevelExampleComposer exampleComposer, bool async)
        {
            using (WriteClientMethodDeclaration(writer, clientMethod, exampleComposer, async))
            {
                WriteNonPageableLongRunningOperationMethodBody(writer, clientMethod, fields, longRunning, async);
            }
        }

        private static void WriteNonPageableLongRunningOperationMethodBody(CodeWriter writer, LowLevelClientMethod clientMethod, ClientFields fields, OperationLongRunning longRunning, bool async)
        {
            var startMethod = clientMethod.RequestMethod;
            var finalStateVia = longRunning.FinalStateVia;
            var scopeName = clientMethod.Diagnostic.ScopeName;

            using (WriteDiagnosticScope(writer, clientMethod.Diagnostic, fields.ClientDiagnosticsProperty.Name))
            {
                var messageVariable = new CodeWriterDeclaration("message");
                var processMessageParameters = (FormattableString)$"{fields.PipelineField.Name:I}, {messageVariable}, {fields.ClientDiagnosticsProperty.Name:I}, {scopeName:L}, {typeof(OperationFinalStateVia)}.{finalStateVia}, {KnownParameters.RequestContext.Name:I}, {KnownParameters.WaitForCompletion.Name:I}";

                writer
                    .Line($"using {typeof(HttpMessage)} {messageVariable:D} = {RequestWriterHelpers.CreateRequestMethodName(startMethod.Name)}({startMethod.Parameters.GetIdentifiersFormattable()});")
                    .AppendRaw("return ")
                    .WriteMethodCall(async, clientMethod.ResponseBodyType != null ? LroProcessMessageMethodAsyncName : LroProcessMessageWithoutResponseValueMethodAsyncName, clientMethod.ResponseBodyType != null ? LroProcessMessageMethodName : LroProcessMessageWithoutResponseValueMethodName, processMessageParameters);
            }
        }

        public static void WritePageableLongRunningOperationMethod(CodeWriter writer, LowLevelClientMethod clientMethod, ClientFields fields, LowLevelPagingInfo pagingInfo, RestClientMethod nextPageMethod, OperationLongRunning longRunning, bool async)
        {
            using (WriteClientMethodDeclaration(writer, clientMethod, async))
            {
                WritePageableLongRunningOperationMethodBody(writer, clientMethod, fields, pagingInfo, nextPageMethod, longRunning, async);
            }
        }

        public static void WritePageableLongRunningOperationMethod(CodeWriter writer, LowLevelClientMethod clientMethod, ClientFields fields, LowLevelPagingInfo pagingInfo, RestClientMethod nextPageMethod, OperationLongRunning longRunning, LowLevelExampleComposer exampleComposer, bool async)
        {
            using (WriteClientMethodDeclaration(writer, clientMethod, exampleComposer, async))
            {
                WritePageableLongRunningOperationMethodBody(writer, clientMethod, fields, pagingInfo, nextPageMethod, longRunning, async);
            }
        }

        private static void WritePageableLongRunningOperationMethodBody(CodeWriter writer, LowLevelClientMethod clientMethod, ClientFields fields, LowLevelPagingInfo pagingInfo, RestClientMethod nextPageMethod, OperationLongRunning longRunning, bool async)
        {
            var startMethod = clientMethod.RequestMethod;
            var finalStateVia = longRunning.FinalStateVia;
            var scopeName = clientMethod.Diagnostic.ScopeName;

            var createEnumerableMethodSignature = new MethodSignature("CreateEnumerable", null, null, None, typeof(IEnumerable<Page<BinaryData>>), null, new[] { ResponseParameter, NextLinkParameter, PageSizeHintParameter }).WithAsync(async);
            var createEnumerableMethod = new CodeWriterDeclaration(createEnumerableMethodSignature.Name);

            using (WriteDiagnosticScope(writer, clientMethod.Diagnostic, fields.ClientDiagnosticsProperty.Name))
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

        private void WriteSubClientFactoryMethod(CodeWriter writer, LowLevelClient client)
        {
            foreach (var field in client.SubClients.Select(s => s.FactoryMethod?.CachingField))
            {
                if (field != null)
                {
                    writer.WriteFieldDeclaration(field);
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

        public static void WriteRequestCreationMethod(CodeWriter writer, RestClientMethod restMethod, ClientFields fields, List<ResponseClassifierType> responseClassifierTypes)
        {
            var responseClassifierType = CreateResponseClassifierType(restMethod);
            responseClassifierTypes.Add(responseClassifierType);
            RequestWriterHelpers.WriteRequestCreation(writer, restMethod, "internal", fields, responseClassifierType.Name, false);
        }

        public static void WriteResponseClassifierMethod(CodeWriter writer, List<ResponseClassifierType> responseClassifierTypes)
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

        private static CodeWriter.CodeWriterScope WriteClientMethodDeclaration(CodeWriter writer, LowLevelClientMethod clientMethod, bool async)
        {
            var methodSignature = clientMethod.Signature.WithAsync(async);

            var remarks = CreateSchemaDocumentationRemarks(clientMethod, out var hasRequestRemarks, out var hasResponseRemarks);
            WriteMethodDocumentation(writer, methodSignature, clientMethod, hasResponseRemarks);
            WriteDocumentationRemarks(writer, clientMethod, methodSignature, remarks, hasRequestRemarks, hasResponseRemarks);

            var scope = writer.WriteMethodDeclaration(methodSignature);
            writer.WriteParametersValidation(methodSignature.Parameters);
            return scope;
        }

        private static CodeWriter.CodeWriterScope WriteClientMethodDeclaration(CodeWriter writer, LowLevelClientMethod clientMethod, LowLevelExampleComposer exampleComposer, bool async)
        {
            var methodSignature = clientMethod.Signature.WithAsync(async);

            var remarks = CreateSchemaDocumentationRemarks(clientMethod, out var hasRequestRemarks, out var hasResponseRemarks);
            WriteMethodDocumentation(writer, methodSignature, clientMethod, hasResponseRemarks);
            writer.WriteXmlDocumentation("example", exampleComposer.Compose(clientMethod, async));
            WriteDocumentationRemarks(writer, clientMethod, methodSignature, remarks, hasRequestRemarks, hasResponseRemarks);

            var scope = writer.WriteMethodDeclaration(methodSignature);
            writer.WriteParametersValidation(methodSignature.Parameters);
            return scope;
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

        private static ResponseClassifierType CreateResponseClassifierType(RestClientMethod method)
        {
            var statusCodes = method.Responses
                .SelectMany(r => r.StatusCodes)
                .Distinct()
                .OrderBy(c => c.Code ?? c.Family * 100);
            return new ResponseClassifierType(statusCodes);
        }

        private static IReadOnlyList<FormattableString> CreateSchemaDocumentationRemarks(LowLevelClientMethod clientMethod, out bool hasRequestSchema, out bool hasResponseSchema)
        {
            var schemas = new List<FormattableString>();

            hasRequestSchema = AddRequestOrResponseInputType(schemas, clientMethod.RequestBodyType, "Request Body");

            if (clientMethod.PagingInfo != null && clientMethod.ResponseBodyType is CodeModelType { Schema: ObjectSchema responseObj })
            {
                Schema? itemSchema = responseObj.Properties.FirstOrDefault(p => p.Language.Default.Name == clientMethod.PagingInfo.ItemName)?.Schema;
                hasResponseSchema = AddRequestOrResponseSchema(schemas, itemSchema, "Response Body");
            }
            else
            {
                hasResponseSchema = AddRequestOrResponseInputType(schemas, clientMethod.ResponseBodyType, "Response Body");
            }

            return schemas;

            static bool AddRequestOrResponseInputType(List<FormattableString> formattedSchemas, InputType? bodyType, string schemaName) =>
                bodyType switch
                {
                    {Kind: InputTypeKind.List or InputTypeKind.Dictionary} => AddRequestOrResponseInputType(formattedSchemas, bodyType.ValuesType!, schemaName),
                    CodeModelType {Schema: { } schema} => AddRequestOrResponseSchema(formattedSchemas, schema, schemaName),
                    _ => false
                };

            static bool AddRequestOrResponseSchema(List<FormattableString> formattedSchemas, Schema? schema, string schemaName)
            {
                if (schema == null)
                {
                    return false;
                }

                var schemasToAdd = new List<FormattableString>();
                // check if it is base schema. if so, add children schemas.
                if (schema is ObjectSchema {Children: { }} objSchema && objSchema.Children.All.Count > 0)
                {
                    if (objSchema.Children.All.Count > 1) schemasToAdd.Add($"This method takes one of the JSON objects below as a payload. Please select a JSON object to view the schema for this.{Environment.NewLine}");
                    foreach (var child in objSchema.Children.All.Select((schema, index) => (schema, index)))
                    {
                        if (child.index == 1)
                        {
                            schemasToAdd.Add($"<details><summary>~+ {objSchema.Children.All.Count - 1} more JSON objects</summary>");
                        }

                        var docs = GetSchemaDocumentationsForSchema(child.schema, $"{child.schema.CSharpName()} {schemaName}");
                        if (docs != null)
                        {
                            schemasToAdd.Add($"<details><summary>{child.schema.CSharpName()}</summary>");
                            schemasToAdd.Add($"Schema for <c>{child.schema.CSharpName()}</c>:{Environment.NewLine}<code>{BuildSchemaFromDocs(docs)}</code>{Environment.NewLine}");
                            schemasToAdd.Add($"</details>{Environment.NewLine}");
                        }
                    }
                    if (objSchema.Children.All.Count > 1)
                    {
                        schemasToAdd.Add($"</details>{Environment.NewLine}");
                    }
                }
                else
                {
                    var docs = GetSchemaDocumentationsForSchema(schema, schemaName);
                    if (docs != null)
                    {
                        schemasToAdd.Add($"Schema for <c>{schema.CSharpName()}</c>:{Environment.NewLine}<code>{BuildSchemaFromDocs(docs)}</code>{Environment.NewLine}");
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

        private static void WriteDocumentationRemarks(CodeWriter writer, LowLevelClientMethod clientMethod, MethodSignature methodSignature, IReadOnlyCollection<FormattableString> schemas, bool hasRequestRemarks, bool hasResponseRemarks)
        {
            if (schemas.Count <= 0)
            {
                writer.WriteXmlDocumentation("remarks", $"{methodSignature.DescriptionText}");
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

            writer.WriteXmlDocumentation("remarks", $"{schemaDesription}{Environment.NewLine}{docInfo}{schemas}");
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

        private static SchemaDocumentation[]? GetSchemaDocumentationsForSchema(Schema schema, string schemaName)
        {
            // Visit each schema in the graph and for object schemas, collect information about all the properties.
            var visitedSchema = new HashSet<string>();
            var schemasToExplore = new Queue<Schema>(new[] { schema });
            var documentationObjects = new List<(string SchemaName, List<SchemaDocumentation.DocumentationRow> Rows)>();

            while (schemasToExplore.Any())
            {
                Schema toExplore = schemasToExplore.Dequeue();

                if (visitedSchema.Contains(toExplore.Name))
                {
                    continue;
                }

                switch (toExplore)
                {
                    case ObjectSchema o:
                        List<SchemaDocumentation.DocumentationRow> propertyDocumentation = new();

                        // We must also include any properties introduced by our parent chain.
                        foreach (ObjectSchema s in (o.Parents?.All ?? Array.Empty<ComplexSchema>()).Concat(new ComplexSchema[] { o }).OfType<ObjectSchema>())
                        {
                            foreach (Property prop in s.Properties)
                            {
                                if (prop.Schema is ChoiceSchema cs && o.DiscriminatorValue != null)
                                {
                                    if (s.Discriminator != null && s.Discriminator.Property.Language.Default.Name == prop.Language.Default.Name)
                                    {
                                        propertyDocumentation.Add(new SchemaDocumentation.DocumentationRow(
                                            prop.SerializedName,
                                            o.DiscriminatorValue,
                                            prop.Required ?? false,
                                            BuilderHelpers.EscapeXmlDescription(prop.Language.Default.Description)));

                                        schemasToExplore.Enqueue(prop.Schema);
                                        continue;
                                    }
                                }
                                propertyDocumentation.Add(new SchemaDocumentation.DocumentationRow(
                                    prop.SerializedName,
                                    BuilderHelpers.EscapeXmlDescription(StringifyTypeForTable(prop.Schema)),
                                    prop.Required ?? false,
                                    BuilderHelpers.EscapeXmlDescription(prop.Language.Default.Description)));

                                schemasToExplore.Enqueue(prop.Schema);
                            }
                        }

                        documentationObjects.Add(new(schema == o ? schemaName : BuilderHelpers.EscapeXmlDescription(StringifyTypeForTable(o)), propertyDocumentation));
                        break;

                    case OrSchema o:
                        foreach (ComplexSchema s in o.AnyOf)
                        {
                            schemasToExplore.Enqueue(s);
                        }
                        break;
                    case DictionarySchema d:
                        schemasToExplore.Enqueue(d.ElementType);
                        break;
                    case ArraySchema a:
                        schemasToExplore.Enqueue(a.ElementType);
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

        private static string StringifyTypeForTable(Schema schema)
        {
            string RemovePrefix(string s, string prefix)
            {
                return s.StartsWith(prefix) ? s[prefix.Length..] : s;
            }

            return schema switch
            {
                BooleanSchema => "boolean",
                StringSchema => "string",
                NumberSchema => "number",
                AnySchema => "object",
                DateTimeSchema => "string (ISO 8601 Format)",
                ChoiceSchema choiceSchema => string.Join(" | ", choiceSchema.Choices.Select(c => $"\"{c.Value}\"")),
                DictionarySchema d => $"Dictionary<string, {StringifyTypeForTable(d.ElementType)}>",
                ArraySchema a => $"{StringifyTypeForTable(a.ElementType)}[]",
                _ => $"{RemovePrefix(schema.Name, "Json")}"
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

        public readonly struct ResponseClassifierType : IEquatable<ResponseClassifierType>
        {
            public string Name { get; }
            private readonly StatusCodes[] _statusCodes;

            public ResponseClassifierType(IOrderedEnumerable<StatusCodes> statusCodes)
            {
                _statusCodes = statusCodes.ToArray();
                Name = nameof(ResponseClassifier) + string.Join("", _statusCodes.Select(c => c.Code?.ToString() ?? $"{c.Family * 100}To{(c.Family + 1) * 100}"));
            }

            public bool Equals(ResponseClassifierType other) => Name == other.Name;

            public override bool Equals(object? obj) => obj is ResponseClassifierType other && Equals(other);

            public override int GetHashCode() => Name.GetHashCode();

            internal void Deconstruct(out string name, out StatusCodes[] statusCodes)
            {
                name = Name;
                statusCodes = _statusCodes;
            }
        }
    }
}

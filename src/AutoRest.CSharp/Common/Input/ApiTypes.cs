// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.ClientModel.Primitives;
using System.Threading.Tasks;
using AutoRest.CSharp.Common.Output.Expressions;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Shared;

namespace AutoRest.CSharp.Common.Input
{
    internal abstract class ApiTypes
    {
        public abstract Type ResponseType { get; }
        public abstract Type ResponseOfTType { get; }

        public string FromResponseName => "FromResponse";
        public abstract string ResponseParameterName { get; }
        public abstract string ContentStreamName { get; }
        public abstract string StatusName { get; }

        public abstract string GetRawResponseName { get; }

        public Type GetResponseOfT<T>() => ResponseOfTType.MakeGenericType(typeof(T));
        public Type GetTaskOfResponse(Type? valueType = default) =>
            valueType is null ? typeof(Task<>).MakeGenericType(ResponseType) : typeof(Task<>).MakeGenericType(ResponseOfTType.MakeGenericType(valueType));
        public Type GetValueTaskOfResponse(Type? valueType = default) =>
            valueType is null ? typeof(ValueTask<>).MakeGenericType(ResponseType) : typeof(ValueTask<>).MakeGenericType(ResponseOfTType.MakeGenericType(valueType));

        public abstract Type HttpPipelineType { get; }
        public abstract CSharpType PipelineExtensionsType { get; }
        public abstract string HttpPipelineCreateMessageName { get; }
        public FormattableString GetHttpPipelineCreateMessageFormat(bool withContext)
        {
            FormattableString context = withContext ? (FormattableString)$"{KnownParameters.RequestContext.Name:I}" : $"";
            return $"_pipeline.{Configuration.ApiTypes.HttpPipelineCreateMessageName}({context}";
        }

        public abstract FormattableString CredentialDescription { get; }

        public abstract Type HttpMessageType { get; }
        public abstract string HttpMessageResponseName { get; }
        public string HttpMessageResponseStatusName => nameof(PipelineResponse.Status);

        public Type GetNextPageFuncType() => typeof(Func<,,>).MakeGenericType(typeof(int?), typeof(string), HttpMessageType);

        public abstract Type ClientOptionsType { get; }

        public abstract Type RequestContextType { get; }
        public abstract string RequestContextName { get; }
        public abstract string RequestContextDescription { get; }
        public string CancellationTokenName = nameof(RequestOptions.CancellationToken);

        public abstract Type HttpPipelineBuilderType { get; }
        public abstract Type BearerAuthenticationPolicyType { get; }
        public abstract Type KeyCredentialPolicyType { get; }
        public abstract Type KeyCredentialType { get; }
        public FormattableString GetHttpPipelineBearerString(string pipelineField, string optionsVariable, string credentialVariable, CodeWriterDeclaration? scopesParam)
            => $"{pipelineField} = {HttpPipelineBuilderType}.Build({optionsVariable}, new {BearerAuthenticationPolicyType}({credentialVariable}, {scopesParam}));";
        public FormattableString GetHttpPipelineKeyCredentialString(string pipelineField, string optionsVariable, string credentialVariable, string keyName)
            => $"{pipelineField} = {HttpPipelineBuilderType}.Build({optionsVariable}, new {KeyCredentialPolicyType}({credentialVariable}, \"{keyName}\"));";
        public abstract FormattableString GetHttpPipelineClassifierString(string pipelineField, string optionsVariable, FormattableString perCallPolicies, FormattableString perRetryPolicies, FormattableString beforeTransportPolicies);

        public abstract Type HttpPipelinePolicyType { get; }
        public abstract string HttpMessageRequestName { get; }

        public abstract FormattableString GetSetMethodString(string requestName, string method);
        public abstract FormattableString GetSetUriString(string requestName, string uriName);

        public abstract Action<CodeWriter, CodeWriterDeclaration, RequestHeader, ClientFields> WriteHeaderMethod { get; }

        public abstract FormattableString GetSetContentString(string requestName, string contentName);

        public abstract CSharpType RequestUriType { get; }
        public abstract Type RequestContentType { get; }
        public abstract string ToRequestContentName { get; }
        public abstract string MultipartRequestContentTypeName { get; }
        public abstract string ToMultipartRequestContentName { get; }
        public abstract string RequestContentCreateName { get; }

        public abstract Type IXmlSerializableType { get; }

        public abstract Type RequestFailedExceptionType { get; }

        public abstract string ResponseClassifierIsErrorResponseName { get; }

        public abstract string EndPointSampleValue { get; }

        public abstract string JsonElementVariableName { get; }
        public abstract Type ResponseClassifierType { get; }
        public abstract Type StatusCodeClassifierType { get; }

        public abstract ValueExpression GetCreateFromStreamSampleExpression(ValueExpression freeFormObjectExpression);

        public abstract ValueExpression GetKeySampleExpression(string clientName);

        public abstract ExtensibleSnippets ExtensibleSnippets { get; }

        public abstract string LicenseString { get; }
    }
}

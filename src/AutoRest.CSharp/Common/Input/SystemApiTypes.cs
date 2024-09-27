// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using AutoRest.CSharp.Common.Output.Expressions;
using AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions;
using AutoRest.CSharp.Common.Output.Expressions.System;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Types.System;
using Azure.Core.Pipeline; //needed because BearerTokenAuthenticationPolicy doesn't exist in System.ServiceModel.Rest yet
using BinaryContent = System.ClientModel.BinaryContent;

namespace AutoRest.CSharp.Common.Input
{
    internal class SystemApiTypes : ApiTypes
    {
        public override Type ResponseType => typeof(ClientResult);
        public override Type ResponseOfTType => typeof(ClientResult<>);
        public override string ResponseParameterName => "result";
        public override string ContentStreamName => $"{GetRawResponseName}().{nameof(PipelineResponse.ContentStream)}";
        public override string StatusName => $"{GetRawResponseName}().{nameof(PipelineResponse.Status)}";
        public override string GetRawResponseName => nameof(ClientResult<object>.GetRawResponse);

        public override Type HttpPipelineType => typeof(ClientPipeline);
        public override CSharpType PipelineExtensionsType => ClientPipelineExtensionsProvider.Instance.Type;
        public override string HttpPipelineCreateMessageName => nameof(ClientPipeline.CreateMessage);

        public override Type HttpMessageType => typeof(PipelineMessage);
        public override string HttpMessageResponseName => nameof(PipelineMessage.Response);

        public override Type ClientOptionsType => typeof(ClientPipelineOptions);

        public override Type RequestContextType => typeof(RequestOptions);

        public override string RequestContextName => "options";
        public override string RequestContextDescription => "The request options, which can override default behaviors of the client pipeline on a per-call basis.";

        public override Type BearerAuthenticationPolicyType => typeof(BearerTokenAuthenticationPolicy);
        public override Type KeyCredentialType => typeof(ApiKeyCredential);
        public override Type HttpPipelineBuilderType => typeof(ClientPipeline);
        public override Type KeyCredentialPolicyType => typeof(ApiKeyAuthenticationPolicy);
        public override FormattableString GetHttpPipelineClassifierString(string pipelineField, string optionsVariable, FormattableString perCallPolicies, FormattableString perRetryPolicies, FormattableString beforeTransportPolicies)
            => $"{pipelineField:I} = {typeof(ClientPipeline)}.{nameof(ClientPipeline.Create)}({optionsVariable:I}, {perCallPolicies}, {perRetryPolicies}, {beforeTransportPolicies});";

        public override FormattableString CredentialDescription => $"A credential used to authenticate to the service.";

        public override Type HttpPipelinePolicyType => typeof(PipelinePolicy);

        public override string HttpMessageRequestName => nameof(PipelineMessage.Request);

        public override FormattableString GetSetMethodString(string requestName, string method)
        {
            return $"{requestName}.{nameof(PipelineRequest.Method)} = \"{method}\";";
        }

        private string GetHttpMethodName(string method)
        {
            return $"{method[0]}{method.Substring(1).ToLowerInvariant()}";
        }

        public override FormattableString GetSetUriString(string requestName, string uriName)
            => $"{requestName}.Uri = {uriName}.ToUri();";

        public override Action<CodeWriter, CodeWriterDeclaration, RequestHeader, ClientFields> WriteHeaderMethod => RequestWriterHelpers.WriteHeaderSystem;

        public override FormattableString GetSetContentString(string requestName, string contentName)
            => $"{requestName}.Content = {contentName};";

        public override CSharpType RequestUriType => ClientUriBuilderProvider.Instance.Type;
        public override string MultipartRequestContentTypeName => "MultipartFormDataBinaryContent";
        public override Type RequestContentType => typeof(BinaryContent);
        public override string ToRequestContentName => "ToBinaryContent";
        public override string ToMultipartRequestContentName => "ToMultipartBinaryBody";
        public override string RequestContentCreateName => nameof(BinaryContent.Create);

        public override Type IXmlSerializableType => throw new NotSupportedException("Xml serialization is not supported in non-branded libraries yet");

        public override Type RequestFailedExceptionType => typeof(ClientResultException);

        public override Type ResponseClassifierType => typeof(PipelineMessageClassifier);
        public override Type StatusCodeClassifierType => typeof(PipelineMessageClassifier);

        public override ValueExpression GetCreateFromStreamSampleExpression(ValueExpression freeFormObjectExpression)
            => new InvokeStaticMethodExpression(Configuration.ApiTypes.RequestContentType, Configuration.ApiTypes.RequestContentCreateName, new[] { BinaryDataExpression.FromObjectAsJson(freeFormObjectExpression).ToStream() });

        public override string EndPointSampleValue => "https://my-service.com";

        public override string JsonElementVariableName => "element";

        public override ValueExpression GetKeySampleExpression(string clientName)
            => new InvokeStaticMethodExpression(typeof(Environment), nameof(Environment.GetEnvironmentVariable), new[] { new StringLiteralExpression($"{clientName}_KEY", false) });

        public override ExtensibleSnippets ExtensibleSnippets { get; } = new SystemExtensibleSnippets();

        public override string LicenseString => Configuration.CustomHeader ?? string.Empty;

        public override string ResponseClassifierIsErrorResponseName => nameof(PipelineMessageClassifier.TryClassify);
    }
}

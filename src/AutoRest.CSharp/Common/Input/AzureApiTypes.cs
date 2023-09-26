// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions.Azure;
using AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions.Base;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Utilities;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;

namespace AutoRest.CSharp.Common.Input
{
    internal class AzureApiTypes : ApiTypes
    {
        public override BaseResponseExpression GetResponseExpression(ValueExpression untyped) => new ResponseExpression(untyped);
        public override BaseResponseExpression GetFromResponseExpression(ValueExpression untyped) => new ResponseExpression(untyped);

        public override Type ResponseType => typeof(Response);
        public override Type ResponseOfTType => typeof(Response<>);
        public override Type FromResponseType => typeof(Response);
        public override string FromResponseName => "FromResponse";
        public override string ResponseParameterName => "response";
        public override string ContentStreamName => nameof(Response.ContentStream);
        public override string StatusName => nameof(Response.Status);
        public override string GetRawResponseName => nameof(Response<object>.GetRawResponse);
        public override string GetRawResponseString(string responseVariable) => responseVariable;

        public override Type PipelineExtensionsType => typeof(HttpPipelineExtensions);
        protected override string ProcessHeadAsBoolMessageName => nameof(HttpPipelineExtensions.ProcessHeadAsBoolMessage);
        protected override string ProcessMessageName => nameof(HttpPipelineExtensions.ProcessMessage);

        public override Type HttpPipelineType => typeof(HttpPipeline);
        public override string HttpPipelineCreateMessageName => nameof(HttpPipeline.CreateMessage);

        public override Type HttpMessageType => typeof(HttpMessage);
        public override string HttpMessageResponseName => nameof(HttpMessage.Response);

        public override Type ClientDiagnosticsType => typeof(ClientDiagnostics);
        public override string ClientDiagnosticsCreateScopeName => nameof(ClientDiagnostics.CreateScope);

        public override Type ClientOptionsType => typeof(ClientOptions);

        public override Type ArgumentType => typeof(Argument);

        public override Type RequestContextType => typeof(RequestContext);

        public override Type ChangeTrackingListType => typeof(ChangeTrackingList<>);
        public override Type ChangeTrackingDictionaryType => typeof(ChangeTrackingDictionary<,>);

        public override Type BearerAuthenticationPolicyType => typeof(BearerTokenAuthenticationPolicy);
        public override Type KeyCredentialType => typeof(AzureKeyCredential);
        public override Type HttpPipelineBuilderType => typeof(HttpPipelineBuilder);
        public override Type KeyCredentialPolicyType => typeof(AzureKeyCredentialPolicy);
        public override FormattableString GetHttpPipelineClassifierString(string pipelineField, string optionsVariable, FormattableString perCallPolicies, FormattableString perRetryPolicies)
            => $"{pipelineField:I} = {typeof(HttpPipelineBuilder)}.{nameof(HttpPipelineBuilder.Build)}({optionsVariable:I}, {perCallPolicies}, {perRetryPolicies}, new {typeof(ResponseClassifier)}());";

        public override Type HttpPipelinePolicyType => typeof(HttpPipelinePolicy);

        public override FormattableString ProtocolReturnStartString => $"return ";
        public override FormattableString ProtocolReturnEndString => $";";

        public override string HttpMessageRequestName => nameof(HttpMessage.Request);

        public override FormattableString GetSetMethodString(string requestName, string method)
            => $"{requestName}.Method = {typeof(RequestMethod)}.{RequestMethod.Parse(method).ToRequestMethodName()};";
        public override FormattableString GetSetUriString(string requestName, string uriName)
            => $"{requestName}.Uri = {uriName};";

        public override Action<CodeWriter, CodeWriterDeclaration, RequestHeader, ClientFields?> WriteHeaderMethod => RequestWriterHelpers.WriteHeader;

        public override FormattableString GetSetContentString(string requestName, string contentName)
            => $"{requestName}.Content = {contentName};";
    }
}

﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ServiceModel.Rest;
using System.ServiceModel.Rest.Core;
using System.ServiceModel.Rest.Experimental;
using System.ServiceModel.Rest.Experimental.Core;
using System.ServiceModel.Rest.Experimental.Core.Pipeline;
using System.ServiceModel.Rest.Experimental.Core.Serialization;
using AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions.Base;
using AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions.System;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Common.Output.Models;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Requests;
using Azure.Core.Pipeline; //needed because BearerTokenAuthenticationPolicy doesn't exist in System.ServiceModel.Rest yet
using RequestBody = System.ServiceModel.Rest.Core.RequestBody;

namespace AutoRest.CSharp.Common.Input
{
    internal class SystemApiTypes : ApiTypes
    {
        public override BaseResponseExpression GetResponseExpression(ValueExpression untyped) => new ResultExpression(untyped);
        public override BaseResponseExpression GetFromResponseExpression(ValueExpression untyped) => new PipelineResponseExpression(untyped);

        public override Type ResponseType => typeof(Result);
        public override Type ResponseOfTType => typeof(Result<>);
        public override Type FromResponseType => typeof(PipelineResponse);
        public override string FromResponseName => "FromResponse";
        public override string ResponseParameterName => "result";
        public override string ContentStreamName => $"{GetRawResponseName}().{nameof(PipelineResponse.ContentStream)}";
        public override string StatusName => $"{GetRawResponseName}().{nameof(PipelineResponse.Status)}";
        public override string GetRawResponseName => nameof(Result<object>.GetRawResponse);
        public override string GetRawResponseString(string responseVariable) => $"{responseVariable}.{GetRawResponseName}()";

        public override Type PipelineExtensionsType => typeof(PipelineProtocolExtensions);
        protected override string ProcessHeadAsBoolMessageName => nameof(PipelineProtocolExtensions.ProcessHeadAsBoolMessage);
        protected override string ProcessMessageName => nameof(PipelineProtocolExtensions.ProcessMessage);

        public override Type HttpPipelineType => typeof(MessagePipeline);
        public override string HttpPipelineCreateMessageName => nameof(MessagePipeline.CreateMessage);

        public override Type HttpMessageType => typeof(PipelineMessage);
        public override string HttpMessageResponseName => nameof(PipelineMessage.PipelineResponse);

        public override Type ClientDiagnosticsType => typeof(TelemetrySource);
        public override string ClientDiagnosticsCreateScopeName => nameof(TelemetrySource.CreateSpan);

        public override Type ClientOptionsType => typeof(RequestOptions);

        public override Type ArgumentType => typeof(ClientUtilities);

        public override Type RequestContextType => typeof(RequestOptions);

        public override Type ChangeTrackingListType => typeof(OptionalList<>);
        public override Type ChangeTrackingDictionaryType => typeof(OptionalDictionary<,>);

        public override Type BearerAuthenticationPolicyType => typeof(BearerTokenAuthenticationPolicy);
        public override Type KeyCredentialType => typeof(KeyCredential);
        public override Type HttpPipelineBuilderType => typeof(MessagePipeline);
        public override Type KeyCredentialPolicyType => typeof(KeyCredentialPolicy);
        public override FormattableString GetHttpPipelineClassifierString(string pipelineField, string optionsVariable, FormattableString perCallPolicies, FormattableString perRetryPolicies)
            => $"{pipelineField:I} = {typeof(MessagePipeline)}.{nameof(MessagePipeline.Create)}(new {typeof(MessagePipelineTransport)}(), {optionsVariable:I}, {perRetryPolicies}, {perCallPolicies});";

        public override Type HttpPipelinePolicyType => typeof(IPipelinePolicy<PipelineMessage>);

        public override FormattableString ProtocolReturnStartString => $"return {ResponseType}.{FromResponseName}(";
        public override FormattableString ProtocolReturnEndString => $");";

        public override string HttpMessageRequestName => nameof(PipelineMessage.PipelineRequest);

        public override FormattableString GetSetMethodString(string requestName, string method)
            => $"{requestName}.SetMethod(\"{method}\");";
        public override FormattableString GetSetUriString(string requestName, string uriName)
            => $"{requestName}.SetUri({uriName});";

        public override Action<CodeWriter, CodeWriterDeclaration, RequestHeader, ClientFields?> WriteHeaderMethod => RequestWriterHelpers.WriteHeaderSystem;

        public override FormattableString GetSetContentString(string requestName, string contentName)
            => $"{requestName}.SetContent({contentName});";

        public override Type RequestContentType => typeof(RequestBody);
        public override string ToRequestContentName => "ToRequestBody";
        public override string RequestContentCreateName => nameof(RequestBody.CreateFromStream);

        public override BaseRawRequestUriBuilderExpression GetRequestUriBuiilderExpression(ValueExpression? valueExpression = null)
            => new RequestUriExpression(valueExpression ?? Snippets.New.Instance(typeof(RequestUri)));
    }
}

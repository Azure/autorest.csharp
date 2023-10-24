// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net.ClientModel;
using System.Net.ClientModel.Core;
using System.Net.ClientModel.Core.Pipeline;
using System.Net.ClientModel.Internal;
using AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions;
using AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions.Azure;
using AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions.Base;
using AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions.System;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Common.Output.Models;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Requests;
using Azure.Core;
using Azure.Core.Pipeline; //needed because BearerTokenAuthenticationPolicy doesn't exist in System.ServiceModel.Rest yet

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
        public override string ContentStreamName => $"{GetRawResponseName}().{nameof(PipelineResponse.Content)}";
        public override string StatusName => $"{GetRawResponseName}().{nameof(PipelineResponse.Status)}";
        public override string GetRawResponseName => nameof(Result<object>.GetRawResponse);
        public override string GetRawResponseString(string responseVariable) => $"{responseVariable}.{GetRawResponseName}()";

        public override Type PipelineExtensionsType => typeof(PipelineProtocolExtensions);
        protected override string ProcessHeadAsBoolMessageName => nameof(PipelineProtocolExtensions.ProcessHeadAsBoolMessage);
        protected override string ProcessMessageName => nameof(PipelineProtocolExtensions.ProcessMessage);

        public override Type HttpPipelineType => typeof(MessagePipeline);
        public override string HttpPipelineCreateMessageName => nameof(MessagePipeline.CreateMessage);

        public override Type HttpMessageType => typeof(PipelineMessage);
        public override string HttpMessageResponseName => nameof(PipelineMessage.Response);

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
            => $"{pipelineField:I} = {typeof(MessagePipeline)}.{nameof(MessagePipeline.Create)}({optionsVariable:I}, {perRetryPolicies}, {perCallPolicies});";

        public override Type HttpPipelinePolicyType => typeof(PipelinePolicy<PipelineMessage>);

        public override FormattableString ProtocolReturnStartString => $"return {ResponseType}.{FromResponseName}(";
        public override FormattableString ProtocolReturnEndString => $");";

        public override string HttpMessageRequestName => nameof(PipelineMessage.Request);

        public override FormattableString GetSetMethodString(string requestName, string method)
            => $"{requestName}.Method = {method:L};";

        private string GetHttpMethodName(string method)
        {
            return $"{method[0]}{method.Substring(1).ToLowerInvariant()}";
        }

        public override FormattableString GetSetUriString(string requestName, string uriName)
            => $"{requestName}.Uri = {uriName}.{nameof(UriBuilder.Uri)};";

        public override Action<CodeWriter, CodeWriterDeclaration, RequestHeader, ClientFields?> WriteHeaderMethod => RequestWriterHelpers.WriteHeaderSystem;

        public override FormattableString GetSetContentString(string requestName, string contentName)
            => $"{requestName}.Content = {contentName};";

        public override Type RequestContentType => typeof(PipelineContent);
        public override string ToRequestContentName => "ToPipelineContent";
        public override string RequestContentCreateName => nameof(PipelineContent.CreateContent);

        public override BaseRawRequestUriBuilderExpression GetRequestUriBuiilderExpression(ValueExpression? valueExpression = null)
            => new UriBuilderExpression(valueExpression ?? Snippets.New.Instance(typeof(UriBuilder)));

        public override Type? IUtf8JsonSerializableType => null;

        public override Type Utf8JsonWriterExtensionsType => typeof(ModelReaderWriterExtensions);

        public override BaseUtf8JsonRequestContentExpression GetUtf8JsonRequestContentExpression(ValueExpression? untyped = null)
            => new Utf8JsonRequestBodyExpression(untyped ?? Snippets.New.Instance(typeof(Utf8JsonContentWriter)));

        public override Type OptionalType => typeof(OptionalProperty);
        public override Type OptionalPropertyType => typeof(OptionalProperty<>);

        public override Type RequestFailedExceptionType => typeof(MessageFailedException);

        public override Type ResponseClassifierType => typeof(ResponseErrorClassifier);
        public override Type StatusCodeClassifierType => typeof(StatusResponseClassifier);

        public override Type JsonElementExtensionsType => typeof(ModelReaderWriterExtensions);

        public override ValueExpression GetCreateFromStreamSampleExpression(ValueExpression freeFormObjectExpression)
            => new TypeReference(Configuration.ApiTypes.RequestContentType)
            .InvokeStatic(
                Configuration.ApiTypes.RequestContentCreateName,
                BinaryDataExpression.FromObjectAsJson(freeFormObjectExpression).ToStream());

        public override string EndPointSampleValue => "https://my-service.com";

        public override string JsonElementVariableName => "element";

        public override ValueExpression GetKeySampleExpression(string clientName)
            => new InvokeStaticMethodExpression(typeof(Environment), nameof(Environment.GetEnvironmentVariable), new[] { new StringLiteralExpression($"{clientName}_KEY", false) });

        public override string LiscenseString => string.Empty;
    }
}

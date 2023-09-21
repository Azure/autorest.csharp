// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ServiceModel.Rest;
using System.ServiceModel.Rest.Core.Pipeline;
using System.ServiceModel.Rest.Shared.Core.Pipeline;
using AutoRest.CSharp.Output.Models.Shared;
using Azure.Core;

namespace AutoRest.CSharp.Common.Input
{
    internal class SystemApiTypes : ApiTypes
    {
        public override Type ResponseType => typeof(Result);
        public override Type ResponseOfTType => typeof(Result<>);
        public override string FromResponseName => "FromResult";
        public override string ResponseParameterName => "result";
        public override string GetRawResponseName => nameof(Result<object>.GetRawResult);

        public override Type PipelineExtensionsType => typeof(PipelineProtocolExtensions);
        protected override string ProcessHeadAsBoolMessageName => nameof(PipelineProtocolExtensions.ProcessHeadAsBoolMessage);
        protected override string ProcessMessageName => nameof(PipelineProtocolExtensions.ProcessMessage);

        public override Type HttpPipelineType => typeof(MessagePipeline);
        public override string HttpPipelineCreateMessageName => nameof(MessagePipeline.CreateRestMessage);
        public override FormattableString GetHttpPipelineCreateMessageFormat(bool withContext)
        {
            FormattableString context = withContext ? (FormattableString)$"{KnownParameters.RequestContext.Name:I}" : $"";
            return $"new {typeof(HttpMessage)}(_pipeline.{Configuration.ApiTypes.HttpPipelineCreateMessageName}({context}";
        }

        public override Type HttpMessageType => typeof(HttpMessage);
        public override string HttpMessageResponseName => nameof(HttpMessage.Response);

        public override Type ClientDiagnosticsType => typeof(TelemetrySource);
        public override string ClientDiagnosticsCreateScopeName => nameof(TelemetrySource.CreateSpan);
    }
}

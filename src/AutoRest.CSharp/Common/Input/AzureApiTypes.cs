// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions.Azure;
using AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions.Base;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Output.Models.Shared;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;

namespace AutoRest.CSharp.Common.Input
{
    internal class AzureApiTypes : ApiTypes
    {
        public override BaseResponseExpression GetResponseExpression(ValueExpression untyped) => new ResponseExpression(untyped);

        public override Type ResponseType => typeof(Response);
        public override Type ResponseOfTType => typeof(Response<>);
        public override string FromResponseName => "FromResponse";
        public override string ResponseParameterName => "response";
        public override string GetRawResponseName => nameof(Response<object>.GetRawResponse);

        public override Type PipelineExtensionsType => typeof(HttpPipelineExtensions);
        protected override string ProcessHeadAsBoolMessageName => nameof(HttpPipelineExtensions.ProcessHeadAsBoolMessage);
        protected override string ProcessMessageName => nameof(HttpPipelineExtensions.ProcessMessage);

        public override Type HttpPipelineType => typeof(HttpPipeline);
        public override string HttpPipelineCreateMessageName => nameof(HttpPipeline.CreateMessage);
        public override FormattableString GetHttpPipelineCreateMessageFormat(bool withContext)
        {
            FormattableString context = withContext ? (FormattableString)$"{KnownParameters.RequestContext.Name:I}" : $"";
            return $"_pipeline.{Configuration.ApiTypes.HttpPipelineCreateMessageName}({context}";
        }

        public override Type HttpMessageType => typeof(HttpMessage);
        public override string HttpMessageResponseName => nameof(HttpMessage.Response);

        public override Type ClientDiagnosticsType => typeof(ClientDiagnostics);
        public override string ClientDiagnosticsCreateScopeName => nameof(ClientDiagnostics.CreateScope);
    }
}

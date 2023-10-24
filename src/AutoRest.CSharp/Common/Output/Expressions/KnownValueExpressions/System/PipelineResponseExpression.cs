// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Net.ClientModel;
using System.Net.ClientModel.Core;
using AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions.Base;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Generation.Types;

namespace AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions.System
{
    internal record PipelineResponseExpression(ValueExpression Untyped) : BaseResponseExpression(typeof(Result), Untyped)
    {
        public override ValueExpression Value => throw new InvalidOperationException("PipelineResponse does not have a Value.");
        public override BinaryDataExpression Content => new(Property(nameof(PipelineResponse.Content)));
        public override StreamExpression ContentStream => new(Property(nameof(PipelineResponse.Content)).CastTo(typeof(Stream)));

        public override BaseResponseExpression FromValue(ValueExpression value) => throw new InvalidOperationException("PipelineResponse does not have a FromValue.");

        public override BaseResponseExpression FromValue(CSharpType explicitValueType, ValueExpression value) => throw new InvalidOperationException("PipelineResponse does not have a FromValue.");

        public override BaseResponseExpression GetRawResponse() => throw new InvalidOperationException("PipelineResponse does not have a GetRawResponse.");
    }
}

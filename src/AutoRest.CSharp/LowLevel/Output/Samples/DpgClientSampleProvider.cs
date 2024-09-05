// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Common.Input.Examples;
using AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions;
using AutoRest.CSharp.Common.Output.Expressions.Statements;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Common.Output.Models;
using AutoRest.CSharp.Input.Source;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Samples.Models;
using AutoRest.CSharp.Utilities;
using NUnit.Framework;
using static AutoRest.CSharp.Common.Output.Models.Snippets;

namespace AutoRest.CSharp.LowLevel.Output.Samples
{
    internal class DpgClientSampleProvider : DpgClientTestProvider
    {
        public DpgClientSampleProvider(string defaultNamespace, LowLevelClient client, SourceInputModel? sourceInputModel) : base($"{defaultNamespace}.Samples", $"Samples_{client.Declaration.Name}", client, sourceInputModel)
        {
            _samples = client.ClientMethods.SelectMany(m => m.Samples);
        }

        protected override IEnumerable<string> BuildUsings()
        {
            if (Configuration.IsBranded)
                yield return "Azure.Identity"; // we need this using because we might need to call `new DefaultAzureCredential` from `Azure.Identity` package, but Azure.Identity package is not a dependency of the generator project.
        }

        private readonly IEnumerable<DpgOperationSample> _samples;
        private Dictionary<MethodSignature, List<DpgOperationSample>>? methodToSampleDict;
        private Dictionary<MethodSignature, List<DpgOperationSample>> MethodToSampleDict => methodToSampleDict ??= BuildMethodToSampleCache();

        private Dictionary<MethodSignature, List<DpgOperationSample>> BuildMethodToSampleCache()
        {
            var result = new Dictionary<MethodSignature, List<DpgOperationSample>>();
            foreach (var sample in _samples)
            {
                result.AddInList(sample.OperationMethodSignature.WithAsync(false), sample);
                result.AddInList(sample.OperationMethodSignature.WithAsync(true), sample);
            }

            return result;
        }

        public IEnumerable<(string ExampleInformation, string TestMethodName)> GetSampleInformation(MethodSignature signature, bool isAsync)
        {
            if (MethodToSampleDict.TryGetValue(signature, out var result))
            {
                foreach (var sample in result)
                {
                    yield return (sample.GetSampleInformation(isAsync), GetMethodName(sample, isAsync));
                }
            }
        }

        protected override IEnumerable<Method> BuildMethods()
        {
            foreach (var sample in _client.ClientMethods.SelectMany(m => m.Samples))
            {
                yield return BuildSampleMethod(sample, false);
                yield return BuildSampleMethod(sample, true);
            }
        }

        protected override string GetMethodName(DpgOperationSample sample, bool isAsync)
        {
            var builder = new StringBuilder("Example_");

            if (sample.ResourceName is not null)
                builder.Append(sample.ResourceName).Append("_");

            builder.Append(sample.InputOperationName)
                .Append('_').Append(sample.ExampleKey);

            if (sample.IsConvenienceSample)
            {
                builder.Append("_Convenience");
            }
            if (isAsync)
            {
                builder.Append("_Async");
            }
            return builder.ToString();
        }

        protected override CSharpAttribute[] GetMethodAttributes() => _attributes;

        private readonly CSharpAttribute[] _attributes = new[] { new CSharpAttribute(typeof(TestAttribute)), new CSharpAttribute(typeof(IgnoreAttribute), Literal("Only validating compilation of examples")) };

        protected override IEnumerable<MethodBodyStatement> BuildResponseStatements(DpgOperationSample sample, VariableReference resultVar)
        {
            if (sample.IsResponseStream)
            {
                return BuildResponseForStream(resultVar);
            }
            else
            {
                return BuildNormalResponse(sample, resultVar);
            }
        }

        private IEnumerable<MethodBodyStatement> BuildResponseForStream(VariableReference resultVar)
        {
            var contentStreamExpression = new StreamExpression(resultVar.Property(Configuration.ApiTypes.ContentStreamName));
            yield return new IfStatement(NotEqual(contentStreamExpression, Null))
            {
                UsingDeclare("outFileStream", InvokeFileOpenWrite("<filepath>"), out var streamVariable),
                contentStreamExpression.CopyTo(streamVariable)
            };
        }

        private IEnumerable<MethodBodyStatement> BuildNormalResponse(DpgOperationSample sample, VariableReference responseVar)
        {
            // we do not write response handling for convenience method samples
            if (sample.IsConvenienceSample)
                yield break;

            ValueExpression streamVar;
            var responseType = responseVar.Type;
            if (responseType.EqualsIgnoreNullable(typeof(BinaryData)))
                streamVar = responseVar.Invoke(nameof(BinaryData.ToStream));
            else if (responseType.EqualsIgnoreNullable(Configuration.ApiTypes.ResponseType))
                streamVar = responseVar.Property(Configuration.ApiTypes.ContentStreamName);
            else if (responseType.IsResponseOfT)
                streamVar = responseVar.Invoke(Configuration.ApiTypes.GetRawResponseName);
            else
                yield break;

            var returnValue = sample.ReturnValue;

            if (returnValue != null)
            {
                var resultVar = new VariableReference(typeof(JsonElement), Configuration.ApiTypes.JsonElementVariableName);
                yield return Declare(resultVar, JsonDocumentExpression.Parse(new StreamExpression(streamVar)).RootElement);

                var responseParsingStatements = new List<MethodBodyStatement>();
                if (sample.IsPageable && returnValue is InputExampleListValue listValue)
                {
                    // for pageable operations, this return value is an array value, but we are writing them in a foreach, therefore here we just take the first item
                    returnValue = listValue.Values.FirstOrDefault() ?? InputExampleValue.Null(returnValue.Type);
                }

                BuildResponseStatements(returnValue, resultVar, responseParsingStatements);

                yield return responseParsingStatements;
            }
            else
            {
                // if there is not a schema for us to show, just print status code
                ValueExpression statusVar = responseVar;
                if (responseType.IsResponseOfT)
                    statusVar = responseVar.Invoke(Configuration.ApiTypes.GetRawResponseName);
                if (responseType.IsResponseOfT || responseType.IsResponse)
                    yield return InvokeConsoleWriteLine(statusVar.Property(Configuration.ApiTypes.StatusName));
            }
        }

        private static void BuildResponseStatements(InputExampleValue responseValue, ValueExpression invocation, List<MethodBodyStatement> statements)
        {
            switch (responseValue)
            {
                case InputExampleListValue listValue:
                    BuildResponseStatementsForList(listValue, invocation, statements);
                    break;
                case InputExampleObjectValue objOrModelValue:
                    BuildResponseStatementsForModelOrDict(objOrModelValue, invocation, statements);
                    break;
                default:
                    BuildResponseStatementsForInlineValue(responseValue, invocation, statements);
                    break;
            }
        }

        private static void BuildResponseStatementsForList(InputExampleListValue listValue, ValueExpression invocation, List<MethodBodyStatement> statements)
        {
            for (int i = 0; i < listValue.Values.Count; i++)
            {
                // recursively handle the result of this
                BuildResponseStatements(listValue.Values[i], new IndexerExpression(invocation, Literal(i)), statements);
            }
        }

        private static void BuildResponseStatementsForModelOrDict(InputExampleObjectValue objectValue, ValueExpression invocation, List<MethodBodyStatement> statements)
        {
            foreach (var (key, value) in objectValue.Values)
            {
                // recursively handle the result of this
                BuildResponseStatements(value, invocation.Invoke("GetProperty", Literal(key)), statements);
            }
        }

        private static void BuildResponseStatementsForInlineValue(InputExampleValue value, ValueExpression invocation, List<MethodBodyStatement> statements)
        {
            statements.Add(InvokeConsoleWriteLine(invocation.InvokeToString()));
        }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Common.Input.Examples;
using AutoRest.CSharp.Common.Output.Builders;
using AutoRest.CSharp.Common.Output.Expressions.Statements;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Common.Output.Models;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.LowLevel.Extensions;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Serialization;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Utilities;
using Azure;
using static AutoRest.CSharp.Common.Output.Models.Snippets;

namespace AutoRest.CSharp.Output.Samples.Models
{
    internal class DpgOperationSample
    {
        public IReadOnlyList<MethodSignatureBase> ClientInvocationChain { get; }
        public MethodSignature OperationMethodSignature { get; }
        public bool IsLongRunning { get; }
        public bool IsAllParametersUsed { get; }
        public bool IsConvenienceSample { get; }
        public string ExampleKey { get; }
        public CSharpType? ResponseType { get; }
        public CSharpType? PageItemType { get; }

        private readonly InputType? _requestBodyType;
        private readonly IEnumerable<InputParameterExample> _inputClientParameterExamples;
        private readonly InputOperationExample _inputOperationExample;

        public DpgOperationSample(IReadOnlyList<MethodSignatureBase> clientInvocationChain, MethodSignature signature, InputType? requestBodyType, CSharpType? responseType, CSharpType? pageItemType, IEnumerable<InputParameterExample> inputClientParameterExamples, InputOperationExample inputOperationExample, bool isConvenienceSample, string exampleKey)
        {
            _requestBodyType = requestBodyType;
            _inputClientParameterExamples = inputClientParameterExamples;
            _inputOperationExample = inputOperationExample;
            IsConvenienceSample = isConvenienceSample;
            ExampleKey = exampleKey;
            IsAllParametersUsed = exampleKey == ExampleMockValueBuilder.MockExampleAllParameterKey; // TODO -- only work around for the response usage building.

            ClientInvocationChain = clientInvocationChain;
            OperationMethodSignature = signature;
            ResponseType = responseType;
            IsLongRunning = signature.ReturnType is {} && (TypeFactory.IsOperation(signature.ReturnType) || TypeFactory.IsTaskOfOperation(signature.ReturnType));
            PageItemType = pageItemType;
        }

        public IEnumerable<ValueExpression> GetValueExpressionsForParameters(IEnumerable<Parameter> parameters, List<MethodBodyStatement> variableDeclarationStatements)
        {
            foreach (var parameter in parameters)
            {
                ValueExpression parameterExpression;
                if (ParameterValueMapping.TryGetValue(parameter.Name, out var exampleValue))
                {
                    // if we could get an example value out of the map, we just use it.
                    parameterExpression = exampleValue.Expression;
                }
                else
                {
                    // if we cannot get an example value out of the map, we should skip it, unless it is required
                    // in the required case, we should return the default value of the type.
                    // but we should not abuse `default` because it might cause ambiguous calls which leads to compilation errors
                    if (parameter.IsOptionalInSignature)
                        continue;

                    parameterExpression = parameter.Type.IsValueType && !parameter.Type.IsNullable ? Default : Null;
                }
                if (IsInlineParameter(parameter))
                {
                    yield return parameter.IsOptionalInSignature ? new PositionalParameterReference(parameter.Name, parameterExpression) : parameterExpression;
                }
                else
                {
                    // when it is not inline parameter, we add the declaration of the parameter into the statements, and returns the parameter name reference
                    var parameterReference = new VariableReference(parameter.Type, parameter.Name);
                    var declaration = Declare(parameterReference, parameterExpression);
                    variableDeclarationStatements.Add(declaration);
                    yield return parameter.IsOptionalInSignature ? new PositionalParameterReference(parameter.Name, parameterReference) : parameterReference; // returns the parameter name reference
                }
            }
        }

        private Dictionary<string, InputExampleParameterValue>? _parameterValueMapping;
        public Dictionary<string, InputExampleParameterValue> ParameterValueMapping => _parameterValueMapping ??= EnsureParameterValueMapping();

        private Dictionary<string, InputExampleParameterValue> EnsureParameterValueMapping()
        {
            var result = new Dictionary<string, InputExampleParameterValue>();
            var parameters = GetAllParameters();
            var parameterExamples = GetAllParameterExamples();

            foreach (var parameter in parameters)
            {
                if (ProcessKnownParameters(result, parameter))
                {
                    continue;
                }

                // find the corresponding input parameter
                var exampleValue = FindExampleValueBySerializedName(parameterExamples, parameter.Name);

                if (exampleValue == null)
                {
                    // if this is a required parameter and we did not find the corresponding parameter in the examples, we put the null
                    if (parameter.DefaultValue == null)
                    {
                        result.Add(parameter.Name, new InputExampleParameterValue(parameter, Null));
                    }
                    // if it is optional, we just do not put it in the map indicates that in the invocation we could omit it
                }
                else
                {
                    // add it into the mapping
                    var serializationFormat = SerializationBuilder.GetSerializationFormat(exampleValue.Type);
                    result.Add(parameter.Name, new InputExampleParameterValue(parameter, ExampleValueSnippets.GetExpression(parameter.Type, exampleValue, serializationFormat)));
                }
            }

            return result;
        }

        /// <summary>
        /// Returns all the parameters that should be used in this sample
        /// Only required parameters on this operation will be included if useAllParameters is false
        /// Includes all parameters if useAllParameters is true
        /// </summary>
        /// <returns></returns>
        private IEnumerable<Parameter> GetAllParameters()
        {
            // here we should gather all the parameters from my client, and my parent client, and the parent client of my parent client, etc
            foreach (var method in ClientInvocationChain)
            {
                foreach (var parameter in method.Parameters)
                {
                    yield return parameter;
                }
            }

            // then we return all the parameters on this operation
            var parameters = IsAllParametersUsed
                ? OperationMethodSignature.Parameters
                : OperationMethodSignature.Parameters.Where(p => p.DefaultValue == null);

            foreach (var parameter in parameters)
            {
                yield return parameter;
            }
        }

        /// <summary>
        /// This method returns all the related parameter examples on this particular method
        /// </summary>
        /// <returns></returns>
        private IEnumerable<InputParameterExample> GetAllParameterExamples()
        {
            // first we return all the client parameters for reference
            foreach (var parameter in _inputClientParameterExamples)
                yield return parameter;
            foreach (var parameter in _inputOperationExample.Parameters)
                yield return parameter;
        }

        private bool ProcessKnownParameters(Dictionary<string, InputExampleParameterValue> result, Parameter parameter)
        {
            if (parameter == KnownParameters.WaitForCompletion)
            {
                result.Add(parameter.Name, new InputExampleParameterValue(parameter, new TypeReference(typeof(WaitUntil)).Property(nameof(WaitUntil.Completed))));
                return true;
            }

            if (parameter == KnownParameters.CancellationTokenParameter)
            {
                // we usually do not set this parameter in generated test cases
                return true;
            }

            if (IsSameParameter(parameter, KnownParameters.RequestContext) && !parameter.IsOptionalInSignature)
            {
                // we need the RequestContext to disambiguiate from the convenience method - but passing in a null value is allowed.
                result.Add(parameter.Name, new InputExampleParameterValue(parameter, Null));
                return true;
            }

            // endpoint we kind of will change its description therefore here we only find it for name and type
            if (IsSameParameter(parameter, KnownParameters.Endpoint))
            {
                result.Add(parameter.Name, new InputExampleParameterValue(parameter, ExampleValueSnippets.GetExpression(parameter.Type, GetEndpointValue(parameter.Name), SerializationFormat.Default)));
                return true;
            }

            // request content is also special
            if (IsSameParameter(parameter, KnownParameters.RequestContent) || IsSameParameter(parameter, KnownParameters.RequestContentNullable))
            {
                result.Add(parameter.Name, new InputExampleParameterValue(parameter, ExampleValueSnippets.GetExpression(parameter.Type,  GetBodyParameterValue(), SerializationFormat.Default)));
                return true;
            }

            if (IsSameParameter(parameter, KnownParameters.RequestConditionsParameter) || IsSameParameter(parameter, KnownParameters.MatchConditionsParameter))
            {
                // temporarily just return null value
                result.Add(parameter.Name, new InputExampleParameterValue(parameter, Null));
                return true;
            }

            // handle credentials
            if (parameter.Type.EqualsIgnoreNullable(KnownParameters.KeyAuth.Type))
            {
                result.Add(parameter.Name, new InputExampleParameterValue(parameter, New.Instance(typeof(AzureKeyCredential), Literal("<key>"))));
                return true;
            }

            if (parameter.Type.EqualsIgnoreNullable(KnownParameters.TokenAuth.Type))
            {
                result.Add(parameter.Name, new InputExampleParameterValue(parameter, new FormattableStringToExpression($"new DefaultAzureCredential()"))); // TODO -- we have to workaround here because we do not have the Azure.Identity dependency here
                return true;
            }

            return false;
        }

        protected InputExampleValue? FindExampleValueBySerializedName(IEnumerable<InputParameterExample> parameterExamples, string name)
        {
            foreach (var parameterExample in parameterExamples)
            {
                var parameter = parameterExample.Parameter;
                // TODO -- we might need to refactor this when we finally separate protocol method and convenience method from the LowLevelClientMethod class
                if (parameter.Kind == InputOperationParameterKind.Spread)
                {
                    // when it is a spread parameter, it should always be InputModelType
                    var modelType = parameter.Type as InputModelType;
                    var objectExampleValue = parameterExample.ExampleValue as InputExampleObjectValue;
                    Debug.Assert(modelType != null);
                    Debug.Assert(objectExampleValue != null);

                    foreach (var modelOrBase in modelType.GetSelfAndBaseModels())
                    {
                        foreach (var property in modelOrBase.Properties)
                        {
                            if (property.Name.ToVariableName() == name)
                            {
                                return objectExampleValue.Values[property.SerializedName];
                            }
                        }
                    }
                }
                else
                {
                    if (parameter.Name.ToVariableName() == name)
                    {
                        return parameterExample.ExampleValue;
                    }
                }
            }
            return null;
        }

        public InputExampleValue GetEndpointValue(string parameterName)
        {
            var clientParameterValue = _inputClientParameterExamples.FirstOrDefault(e => e.Parameter.IsEndpoint)?.ExampleValue;
            if (clientParameterValue != null)
                return clientParameterValue;

            var operationParameterValue = _inputOperationExample.Parameters.FirstOrDefault(e => e.Parameter.IsEndpoint)?.ExampleValue;
            if (operationParameterValue != null)
                return operationParameterValue;

            // sometimes, especially in swagger projects, the parameter used as endpoint in our client, does not have the `IsEndpoint` flag, we have to fallback here so that we could at least have a value for it.
            return InputExampleValue.Value(InputPrimitiveType.String, $"<{parameterName}>");
        }

        private bool IsInlineParameter(Parameter parameter)
        {
            if (IsSameParameter(parameter, KnownParameters.RequestContent) || IsSameParameter(parameter, KnownParameters.RequestContentNullable))
                return false;

            if (IsSameParameter(parameter, KnownParameters.Endpoint))
                return false;

            if (parameter.Type.EqualsIgnoreNullable(KnownParameters.KeyAuth.Type))
                return false;

            if (parameter.Type.EqualsIgnoreNullable(KnownParameters.TokenAuth.Type))
                return false;

            if (parameter.Type is { IsFrameworkType: false, Implementation: ObjectType })
                return false;

            return true;
        }

        private InputExampleValue GetBodyParameterValue()
        {
            // we have a request body type
            if (_requestBodyType == null)
            {
                return InputExampleValue.Null(InputPrimitiveType.Object);
            }

            //if (Method.RequestBodyType is InputPrimitiveType { Kind: InputTypeKind.Stream })
            //    return InputExampleValue.Stream(Method.RequestBodyType, "<filePath>");

            // find the example value for this type
            // if there is only one parameter is body parameter, we return it.
            var bodyParameters = _inputOperationExample.Parameters.Where(e => e.Parameter is { Location: RequestLocation.Body }).ToArray();
            if (bodyParameters.Length == 1)
            {
                return bodyParameters.Single().ExampleValue;
            }
            // there could be multiple body parameters especially when we have a multiform content type operation
            // if we have more than one body parameters which should happen very rarely, we just search the type in all parameters we have and get the first one that matches.
            var bodyParameterExample = _inputOperationExample.Parameters.FirstOrDefault(e => e.Parameter.Type == _requestBodyType);
            if (bodyParameterExample != null)
            {
                return bodyParameterExample.ExampleValue;
            }

            return InputExampleValue.Null(_requestBodyType);
        }

        private static bool IsSameParameter(Parameter parameter, Parameter knownParameter)
            => parameter.Name == knownParameter.Name && parameter.Type.EqualsIgnoreNullable(knownParameter.Type);

        public bool HasResponseBody => ResponseType is not null;

        public string GetSampleInformation(MethodSignatureBase signature) => IsConvenienceSample
                ? GetSampleInformationForConvenience(signature)
                : GetSampleInformationForProtocol(signature);

        private string GetSampleInformationForConvenience(MethodSignatureBase methodSignature)
        {
            var methodName = methodSignature.Name;
            if (IsAllParametersUsed)
            {
                return $"This sample shows how to call {methodName} with all parameters.";
            }

            return $"This sample shows how to call {methodName}.";
        }

        private string GetSampleInformationForProtocol(MethodSignatureBase methodSignature)
        {
            var methodName = methodSignature.Name;
            if (IsAllParametersUsed)
            {
                return $"This sample shows how to call {methodName} with all {GenerateParameterAndRequestContentDescription(methodSignature.Parameters)}{(HasResponseBody ? " and parse the result" : "")}.";
            }

            return $"This sample shows how to call {methodName}{(HasResponseBody ? " and parse the result" : string.Empty)}.";
        }

        // RequestContext is excluded
        private static bool HasNonBodyCustomParameter(IReadOnlyList<Parameter> parameters)
            => parameters.Any(p => p.RequestLocation != RequestLocation.Body && !p.Equals(KnownParameters.RequestContext));

        private string GenerateParameterAndRequestContentDescription(IReadOnlyList<Parameter> parameters)
        {
            var hasNonBodyParameter = HasNonBodyCustomParameter(parameters);
            var hasBodyParameter = parameters.Any(p => p.RequestLocation == RequestLocation.Body);

            if (hasNonBodyParameter)
            {
                if (hasBodyParameter)
                {
                    return "parameters and request content";
                }
                return "parameters";
            }
            return "request content";
        }
    }
}

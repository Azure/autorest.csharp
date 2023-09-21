// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Common.Input.Examples;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Utilities;
using Azure;
using NUnit.Framework;

namespace AutoRest.CSharp.Output.Samples.Models
{
    internal class DpgOperationSample
    {
        public DpgOperationSample(LowLevelClient client, LowLevelClientMethod method, IEnumerable<InputParameterExample> inputClientParameterExamples, InputOperationExample inputOperationExample, bool isConvenienceSample, string exampleKey)
        {
            Client = client;
            Method = method;
            _inputClientParameterExamples = inputClientParameterExamples;
            _inputOperationExample = inputOperationExample;
            ClientInvocationChain = GetClientInvocationChain(client);
            IsConvenienceSample = isConvenienceSample;
            ExampleKey = exampleKey;
            _useAllParameters = exampleKey == ExampleMockValueBuilder.MockExampleAllParameterKey; // TODO -- only work around for the response usage building.
            _operationMethodSignature = isConvenienceSample ? method.ConvenienceMethod!.Signature : method.ProtocolMethodSignature;
        }

        protected readonly bool _useAllParameters;
        protected internal readonly IEnumerable<InputParameterExample> _inputClientParameterExamples;
        protected internal readonly InputOperationExample _inputOperationExample;
        protected readonly MethodSignature _operationMethodSignature;

        public string ExampleKey { get; }
        public bool IsConvenienceSample { get; }
        public LowLevelClient Client { get; }
        public LowLevelClientMethod Method { get; }

        public MethodSignature OperationMethodSignature => _operationMethodSignature;

        public bool IsLongRunning => IsConvenienceSample ? Method.ConvenienceMethod!.IsLongRunning : Method.LongRunning != null;

        public bool IsPageable => IsConvenienceSample ? Method.ConvenienceMethod!.IsPageable : Method.PagingInfo != null;

        public IReadOnlyList<MethodSignatureBase> ClientInvocationChain { get; }

        /// <summary>
        /// Get the methods to be called to get the client, it should be like `Client(...).GetXXClient(..).GetYYClient(..)`.
        /// It's composed of a constructor of non-subclient and a optional list of subclient factory methods.
        /// </summary>
        /// <returns></returns>
        protected virtual IReadOnlyList<MethodSignatureBase> GetClientInvocationChain(LowLevelClient client)
        {
            var callChain = new Stack<MethodSignatureBase>();
            while (client.FactoryMethod != null)
            {
                callChain.Push(client.FactoryMethod.Signature);
                if (client.ParentClient == null)
                {
                    break;
                }

                client = client.ParentClient;
            }
            callChain.Push(client.GetEffectiveCtor()!);

            return callChain.ToList();
        }

        protected virtual string GetMethodName(bool isAsync)
        {
            var builder = new StringBuilder("Example_").Append(_operationMethodSignature.Name);
            if (_useAllParameters)
            {
                builder.Append("_AllParameters");
            }
            if (IsConvenienceSample)
            {
                builder.Append("_Convenience");
            }
            if (isAsync)
            {
                builder.Append("_Async");
            }
            return builder.ToString();
        }

        protected virtual CSharpAttribute[] Attributes => new[] { new CSharpAttribute(typeof(TestAttribute)), new CSharpAttribute(typeof(IgnoreAttribute), "Only validating compilation of examples") };

        public MethodSignature GetExampleMethodSignature(bool isAsync) => new MethodSignature(
            GetMethodName(isAsync),
            null,
            null,
            isAsync ? MethodSignatureModifiers.Public | MethodSignatureModifiers.Async : MethodSignatureModifiers.Public,
            isAsync ? typeof(Task) : (CSharpType?)null,
            null,
            Array.Empty<Parameter>(),
            Attributes: Attributes);

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
                    continue;

                // find the corresponding input parameter
                var exampleValue = FindExampleValueBySerializedName(parameterExamples, parameter.Name);

                if (exampleValue == null)
                {
                    // if this is a required parameter and we did not find the corresponding parameter in the examples, we put the null
                    if (parameter.DefaultValue == null)
                    {
                        result.Add(parameter.Name, new InputExampleParameterValue(parameter, $"null"));
                    }
                    // if it is optional, we just do not put it in the map indicates that in the invocation we could omit it
                }
                else
                {
                    // add it into the mapping
                    result.Add(parameter.Name, new InputExampleParameterValue(parameter, exampleValue));
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
                    yield return parameter;
            }
            // then we return all the parameters on this operation
            var parameters = _useAllParameters ?
                _operationMethodSignature.Parameters :
                _operationMethodSignature.Parameters.Where(p => p.DefaultValue == null);
            foreach (var parameter in parameters)
                yield return parameter;
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
                result.Add(parameter.Name, new InputExampleParameterValue(parameter, $"{typeof(WaitUntil)}.{nameof(WaitUntil.Completed)}"));
                return true;
            }

            if (parameter == KnownParameters.CancellationTokenParameter)
            {
                // we usually do not set this parameter in generated test cases
                return true;
            }

            if (parameter == KnownParameters.RequestContextRequired)
            {
                // we need the RequestContext to disambiguiate from the convenience method - but passing in a null value is allowed.
                result.Add(parameter.Name, new InputExampleParameterValue(parameter, $"null"));
                return true;
            }

            // endpoint we kind of will change its description therefore here we only find it for name and type
            if (IsSameParameter(parameter, KnownParameters.Endpoint))
            {
                result.Add(parameter.Name, new InputExampleParameterValue(parameter, GetEndpointValue(parameter.Name)));
                return true;
            }

            // request content is also special
            if (IsSameParameter(parameter, KnownParameters.RequestContent) || IsSameParameter(parameter, KnownParameters.RequestContentNullable))
            {
                result.Add(parameter.Name, new InputExampleParameterValue(parameter, GetBodyParameterValue()));
                return true;
            }

            if (IsSameParameter(parameter, KnownParameters.RequestConditionsParameter) || IsSameParameter(parameter, KnownParameters.MatchConditionsParameter))
            {
                // temporarily just return null value
                result.Add(parameter.Name, new InputExampleParameterValue(parameter, $"null"));
                return true;
            }

            // handle credentials
            if (parameter.Type.EqualsIgnoreNullable(KnownParameters.KeyAuth.Type))
            {
                result.Add(parameter.Name, new InputExampleParameterValue(parameter, $"new {typeof(AzureKeyCredential)}({"<key>":L})"));
                return true;
            }

            if (parameter.Type.EqualsIgnoreNullable(KnownParameters.TokenAuth.Type))
            {
                result.Add(parameter.Name, new InputExampleParameterValue(parameter, $"new DefaultAzureCredential()"));
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

        public bool IsInlineParameter(Parameter parameter)
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
            if (Method.RequestBodyType == null)
                return InputExampleValue.Null(InputPrimitiveType.Object);

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
            var bodyParameterExample = _inputOperationExample.Parameters.FirstOrDefault(e => e.Parameter.Type == Method.RequestBodyType);
            if (bodyParameterExample != null)
            {
                return bodyParameterExample.ExampleValue;
            }

            return InputExampleValue.Null(Method.RequestBodyType);
        }

        private static bool IsSameParameter(Parameter parameter, Parameter knownParameter)
            => parameter.Name == knownParameter.Name && parameter.Type.EqualsIgnoreNullable(knownParameter.Type);

        public bool HasResponseBody => Method.ResponseBodyType != null;
        public bool IsResponseStream => Method.ResponseBodyType is InputPrimitiveType { Kind: InputTypeKind.Stream };

        /// <summary>
        /// This method returns the Type we would like to deal with in the sample code.
        /// For normal operation and long running operation, it is just the InputType of the response
        /// For pageable operation, it is the InputType of the item
        /// </summary>
        /// <returns></returns>
        private InputType? GetEffectiveResponseType()
        {
            var responseType = Method.ResponseBodyType;
            if (Method.PagingInfo == null)
                return responseType;

            var pagingItemName = Method.PagingInfo.ItemName;
            var listResultType = responseType as InputModelType;
            var itemsArrayProperty = listResultType?.Properties.FirstOrDefault(p => p.SerializedName == pagingItemName && p.Type is InputListType);
            return itemsArrayProperty?.Type as InputListType;
        }

        public IEnumerable<IEnumerable<FormattableString>> ComposeResponseParsingCode(FormattableString rootElementVar)
        {
            var responseType = GetEffectiveResponseType();
            Debug.Assert(responseType != null);
            var apiInvocationChainList = new List<IReadOnlyList<FormattableString>>();
            ComposeResponseParsingCode(_useAllParameters, responseType, apiInvocationChainList, new Stack<FormattableString>(new FormattableString[] { rootElementVar }), new HashSet<InputType>());

            return apiInvocationChainList;
        }

        private static void ComposeResponseParsingCode(bool useAllProperties, InputType type, List<IReadOnlyList<FormattableString>> apiInvocationChainList, Stack<FormattableString> currentApiInvocationChain, HashSet<InputType> visitedTypes)
        {
            switch (type)
            {
                case InputListType listType:
                    if (visitedTypes.Contains(listType.ElementType))
                        return;
                    // {parentOp}[0]
                    var parentOp = currentApiInvocationChain.Pop();
                    currentApiInvocationChain.Push($"{parentOp}[0]");
                    ComposeResponseParsingCode(useAllProperties, listType.ElementType, apiInvocationChainList, currentApiInvocationChain, visitedTypes);
                    return;
                case InputDictionaryType dictionaryType:
                    if (visitedTypes.Contains(dictionaryType.ValueType))
                        return;
                    // .GetProrperty("<key>")
                    currentApiInvocationChain.Push($"GetProperty({"<key>":L})");
                    ComposeResponseParsingCode(useAllProperties, dictionaryType.ValueType, apiInvocationChainList, currentApiInvocationChain, visitedTypes);
                    currentApiInvocationChain.Pop();
                    return;
                case InputModelType modelType:
                    ComposeResponseParsingCodeForModel(useAllProperties, modelType, apiInvocationChainList, currentApiInvocationChain, visitedTypes);
                    return;
            }

            // primitive types, return
            AddApiInvocationChainResult(apiInvocationChainList, currentApiInvocationChain);
        }

        private static void ComposeResponseParsingCodeForModel(bool useAllProperties, InputModelType model, List<IReadOnlyList<FormattableString>> apiInvocationChainList, Stack<FormattableString> currentApiInvocationChain, HashSet<InputType> visitedTypes)
        {
            foreach (var modelOrBase in model.GetSelfAndBaseModels())
            {
                if (!modelOrBase.Properties.Any())
                    continue;

                var propertiesToExplore = useAllProperties ?
                    modelOrBase.Properties :
                    modelOrBase.Properties.Where(p => p.IsRequired);

                if (!propertiesToExplore.Any()) // if you have a required property, but its child properties are all optional
                {
                    // return the object
                    AddApiInvocationChainResult(apiInvocationChainList, currentApiInvocationChain);
                    return;
                }

                foreach (var property in propertiesToExplore)
                {
                    if (!visitedTypes.Contains(property.Type))
                    {
                        // .GetProperty("{propertyName}")
                        visitedTypes.Add(property.Type);
                        currentApiInvocationChain.Push($"GetProperty({property.SerializedName:L})");
                        ComposeResponseParsingCode(useAllProperties, property.Type, apiInvocationChainList, currentApiInvocationChain, visitedTypes);
                        currentApiInvocationChain.Pop();
                        visitedTypes.Remove(property.Type);
                    }
                }
            }
        }

        private static void AddApiInvocationChainResult(List<IReadOnlyList<FormattableString>> apiInvocationChainList, Stack<FormattableString> currentApiInvocationChain)
        {
            var finalChain = currentApiInvocationChain.ToList();
            finalChain.Reverse();
            apiInvocationChainList.Add(finalChain);
        }

        // TODO -- this needs a refactor when we consolidate things around customization code https://github.com/Azure/autorest.csharp/issues/3370
        public static bool ShouldGenerateShortVersion(LowLevelClient client, LowLevelClientMethod method)
        {
            if (method.ConvenienceMethod is not null)
            {
                if (method.ConvenienceMethod.Signature.Parameters.Count == method.ProtocolMethodSignature.Parameters.Count - 1 &&
                    !method.ConvenienceMethod.Signature.Parameters.Last().Type.Equals(typeof(CancellationToken)))
                {
                    bool allEqual = true;
                    for (int i = 0; i < method.ConvenienceMethod.Signature.Parameters.Count; i++)
                    {
                        if (!method.ConvenienceMethod.Signature.Parameters[i].Type.Equals(method.ProtocolMethodSignature.Parameters[i].Type))
                        {
                            allEqual = false;
                            break;
                        }
                    }
                    if (allEqual)
                    {
                        return false;
                    }
                }
            }
            else
            {
                if (client.HasMatchingCustomMethod(method))
                    return false;
            }

            return true;
        }

        public static bool ShouldGenerateSample(LowLevelClient client, MethodSignature protocolMethodSignature)
        {
            return protocolMethodSignature.Modifiers.HasFlag(MethodSignatureModifiers.Public) &&
                !protocolMethodSignature.Attributes.Any(a => a.Type.Equals(typeof(ObsoleteAttribute))) &&
                !client.IsMethodSuppressed(protocolMethodSignature) &&
                (client.IsSubClient ? true : client.GetEffectiveCtor() is not null);
        }

        public string GetSampleInformation(bool isAsync) => IsConvenienceSample
                ? GetSampleInformationForConvenience(Method.ConvenienceMethod!.Signature.WithAsync(isAsync))
                : GetSampleInformationForProtocol(Method.ProtocolMethodSignature.WithAsync(isAsync));

        private string GetSampleInformationForConvenience(MethodSignature methodSignature)
        {
            var methodName = methodSignature.Name;
            if (_useAllParameters)
            {
                return $"This sample shows how to call {methodName} with all parameters.";
            }

            return $"This sample shows how to call {methodName}.";
        }

        private string GetSampleInformationForProtocol(MethodSignature methodSignature)
        {
            var methodName = methodSignature.Name;
            if (_useAllParameters)
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

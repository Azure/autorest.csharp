// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Common.Input.Examples;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Utilities;
using Azure;
using NUnit.Framework;

namespace AutoRest.CSharp.Output.Samples.Models
{
    internal class DpgOperationSample
    {
        public DpgOperationSample(LowLevelClient client, LowLevelClientMethod method, IEnumerable<InputParameterExample> inputClientParameterExamples, InputOperationExample inputOperationExample)
        {
            Client = client;
            Method = method;
            _inputClientParameterExamples = inputClientParameterExamples;
            _inputOperationExample = inputOperationExample;
            ClientInvocationChain = GetClientInvocationChain(client);
        }

        private readonly IEnumerable<InputParameterExample> _inputClientParameterExamples;
        private readonly InputOperationExample _inputOperationExample;

        public LowLevelClient Client { get; }

        public IReadOnlyList<MethodSignatureBase> ClientInvocationChain { get; }

        /// <summary>
        /// Get the methods to be called to get the client, it should be like `Client(...).GetXXClient(..).GetYYClient(..)`.
        /// It's composed of a constructor of non-subclient and a optional list of subclient factory methods.
        /// </summary>
        /// <returns></returns>
        private static IReadOnlyList<MethodSignatureBase> GetClientInvocationChain(LowLevelClient client)
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

        private string GetMethodName(bool useAllParameters, bool isAsync)
        {
            var builder = new StringBuilder("Example_").Append(Method.ProtocolMethodSignature.Name);
            if (useAllParameters)
            {
                builder.Append("_AllParameters");
            }
            //if (isConvenienceMethod)
            //{
            //    builder.Append("_Convenience");
            //}
            if (isAsync)
            {
                builder.Append("_Async");
            }
            return builder.ToString();
        }

        public MethodSignature GetExampleMethodSignature(bool useAllParameters, bool isAsync) => new MethodSignature(
            GetMethodName(useAllParameters, isAsync),
            null,
            null,
            isAsync ? MethodSignatureModifiers.Public | MethodSignatureModifiers.Async : MethodSignatureModifiers.Public,
            isAsync ? typeof(Task) : (CSharpType?)null,
            null,
            Array.Empty<Parameter>(),
            Attributes: new CSharpAttribute[] { new CSharpAttribute(typeof(TestAttribute)), new CSharpAttribute(typeof(IgnoreAttribute), "Only validating compilation of examples") });

        public LowLevelClientMethod Method { get; }

        private Dictionary<string, ExampleParameterValue>? _parameterValueMapping;
        public Dictionary<string, ExampleParameterValue> ParameterValueMapping => _parameterValueMapping ??= EnsureParameterValueMapping();

        private Dictionary<string, ExampleParameterValue> EnsureParameterValueMapping()
        {
            var result = new Dictionary<string, ExampleParameterValue>();
            // TODO -- now we only consider protocol method. Convenience method will be added into this later
            var parameters = GetAllParameters();

            foreach (var parameter in parameters)
            {
                if (ProcessKnownParameters(result, parameter))
                    continue;

                var exampleParameter = FindExampleParameterBySerializedName(GetAllParameterExamples(), parameter.Name);

                var exampleValue = exampleParameter?.ExampleValue;
                if (exampleValue == null)
                {
                    // if this is a required parameter and we did not find the corresponding parameter in the examples, we throw an exception.
                    if (parameter.DefaultValue == null)
                        throw new InvalidOperationException($"Cannot find an example value for required parameter `{parameter.Name}` for operation {Method.RequestMethod.Name}");
                    // if it is optional, we just do not put it in the map indicates that in the invocation we could omit it
                }
                else
                {
                    // add it into the mapping
                    result.Add(parameter.Name, new ExampleParameterValue(parameter, exampleValue));
                }
            }

            return result;
        }

        private IEnumerable<Parameter> GetAllParameters()
        {
            // here we should gather all the parameters from my client, and my parent client, and the parent client of my parent client, etc
            foreach (var method in ClientInvocationChain)
            {
                foreach (var parameter in method.Parameters)
                    yield return parameter;
            }
            // then we return all the parameters on this operation
            foreach (var parameter in Method.ProtocolMethodSignature.Parameters)
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

        private bool ProcessKnownParameters(Dictionary<string, ExampleParameterValue> result, Parameter parameter)
        {
            if (parameter == KnownParameters.WaitForCompletion)
            {
                result.Add(parameter.Name, new ExampleParameterValue(parameter, $"{typeof(WaitUntil)}.{nameof(WaitUntil.Completed)}"));
                return true;
            }

            if (parameter == KnownParameters.CancellationTokenParameter)
            {
                // we usually do not set this parameter in generated test cases
                return true;
            }

            if (parameter == KnownParameters.RequestContextRequired)
            {
                // we need the RequestContext to disambiguiate from the convenience method
                result.Add(parameter.Name, new ExampleParameterValue(parameter, $"new {typeof(RequestContext)}()"));
                return true;
            }

            // endpoint we kind of will change its description therefore here we only find it for name and type
            if (IsSameParameter(parameter, KnownParameters.Endpoint))
            {
                result.Add(parameter.Name, new ExampleParameterValue(parameter, GetEndpointValue()));
                return true;
            }

            // request content is also special
            if (IsSameParameter(parameter, KnownParameters.RequestContent) || IsSameParameter(parameter, KnownParameters.RequestContentNullable))
            {
                result.Add(parameter.Name, new ExampleParameterValue(parameter, GetBodyParameterValue()));
                return true;
            }

            // handle credentials
            if (parameter.Type.EqualsIgnoreNullable(KnownParameters.KeyAuth.Type))
            {
                result.Add(parameter.Name, new ExampleParameterValue(parameter, $"new {typeof(AzureKeyCredential)}({"<key>":L})"));
                return true;
            }

            if (parameter.Type.EqualsIgnoreNullable(KnownParameters.TokenAuth.Type))
            {
                result.Add(parameter.Name, new ExampleParameterValue(parameter, $"new DefaultAzureCredential()"));
                return true;
            }

            return false;
        }

        protected InputParameterExample? FindExampleParameterBySerializedName(IEnumerable<InputParameterExample> parameters, string name)
            => parameters.FirstOrDefault(p => p.Parameter.Name == name);

        public InputExampleValue GetEndpointValue()
        {
            var clientParameterValue = _inputClientParameterExamples.FirstOrDefault(e => e.Parameter.IsEndpoint)?.ExampleValue;
            if (clientParameterValue != null)
                return clientParameterValue;

            return _inputOperationExample.Parameters.First(e => e.Parameter.IsEndpoint).ExampleValue;
        }

        public bool IsInlineParameter(Parameter parameter)
        {
            // TODO -- maybe we should store it here?
            // temporarily only RequestContent is not inline parameter
            if (IsSameParameter(parameter, KnownParameters.RequestContent) || IsSameParameter(parameter, KnownParameters.RequestContentNullable))
                return false;

            if (IsSameParameter(parameter, KnownParameters.Endpoint))
                return false;

            if (parameter.Type.EqualsIgnoreNullable(KnownParameters.KeyAuth.Type))
                return false;

            if (parameter.Type.EqualsIgnoreNullable(KnownParameters.TokenAuth.Type))
                return false;

            return true;
        }

        private InputExampleValue GetBodyParameterValue()
        {
            return _inputOperationExample.Parameters.Single(e => e.Parameter is { Location: RequestLocation.Body }).ExampleValue;
        }

        private static bool IsSameParameter(Parameter parameter, Parameter knownParameter)
            => parameter.Name == knownParameter.Name && parameter.Type.EqualsIgnoreNullable(knownParameter.Type);
    }
}

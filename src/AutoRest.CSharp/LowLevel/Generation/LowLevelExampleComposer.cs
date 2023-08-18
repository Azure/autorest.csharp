// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Shared;

namespace AutoRest.CSharp.Generation.Writers
{
    internal class LowLevelExampleComposer
    {
        private LowLevelClient _client;


        public LowLevelExampleComposer(LowLevelClient client)
        {
            _client = client;
        }

        public FormattableString Compose(LowLevelClientMethod clientMethod, bool async)
        {
            //skip non public protocol methods
            if (!clientMethod.ProtocolMethodSignature.Modifiers.HasFlag(MethodSignatureModifiers.Public))
                return $"";

            //skip obsolete protocol methods
            if (clientMethod.ProtocolMethodSignature.Attributes.Any(a => a.Type.Equals(typeof(ObsoleteAttribute))))
                return $"";

            //skip suppressed protocol methods
            if (_client.IsMethodSuppressed(clientMethod.ProtocolMethodSignature))
                return $"";

            //skip if there are no valid ctors
            if (!_client.IsSubClient && _client.GetEffectiveCtor() is null)
                return $"";

            var methodSignature = clientMethod.ProtocolMethodSignature.WithAsync(async);
            var requestBodyType = clientMethod.RequestBodyType;
            var builder = new StringBuilder();

            if (HasNoCustomInput(methodSignature.Parameters)) // client.GetAllItems(RequestContext context = null)
            {
                ComposeExampleWithoutParameter(clientMethod, methodSignature.Name, async, true, builder);
            }
            else if (HasOptionalInputValue(methodSignature.Parameters, requestBodyType, out var requestModel))
            {
                if (methodSignature.Parameters.All(p => p.IsOptionalInSignature))
                {
                    ComposeExampleWithoutParameter(clientMethod, methodSignature.Name, async, false, builder);
                }
                else if (requestBodyType != null && (requestModel == null || HasRequiredAndWritablePropertyFromTop(requestModel)))
                {
                    ComposeExampleWithParametersAndRequestContent(clientMethod, methodSignature.Name, async, false, builder);
                }
                else
                {
                    ComposeExampleWithoutRequestContent(clientMethod, methodSignature.Name, async, builder);
                }
                builder.AppendLine();
                ComposeExampleWithParametersAndRequestContent(clientMethod, methodSignature.Name, async, true, builder);
            }
            else
            {
                // client.GetAllItems(int a, RequestContext context = null)
                ComposeExampleWithRequiredParameters(clientMethod, methodSignature.Name, async, builder);
            }

            return $"{builder.ToString()}";
        }

        public FormattableString Compose(ConvenienceMethod convenienceMethod, bool async)
        {
            //skip when body param is obsolete
            if (convenienceMethod.IsDeprecatedForExamples())
                return $"";

            //skip if not public
            if (!convenienceMethod.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Public))
                return $"";

            //skip if there are no valid ctors
            if (!_client.IsSubClient && _client.GetEffectiveCtor() is null)
                return $"";

            //skip suppressed convenience methods
            if (_client.IsMethodSuppressed(convenienceMethod.Signature))
                return $"";

            var methodSignature = convenienceMethod.Signature.WithAsync(async);
            var builder = new StringBuilder();

            ComposeConvenienceMethodExample(convenienceMethod, async, methodSignature.Name, builder);

            return $"{builder.ToString()}";
        }

        internal void ComposeConvenienceMethodExample(ConvenienceMethod convenienceMethod, bool isAsync, string methodName, StringBuilder builder)
        {
            if (HasNoCustomInput(convenienceMethod.Signature.Parameters)) // client.GetAllItems(CancellationToken cancellationToken = default)
            {
                ComposeExampleWithoutParameter(convenienceMethod, methodName, isAsync, true, builder);
            }
            else
            {
                // client.GetAllItems(int a, RequestContext context = null)
                ComposeExampleWithRequiredParameters(convenienceMethod, methodName, isAsync, builder);
            }
        }

        // `RequestContext = null` or `cancellationToken = default` is excluded
        private static bool HasNoCustomInput(IReadOnlyList<Parameter> parameters)
            => parameters.Count == 0 || (parameters.Count == 1 && (parameters[0].Equals(KnownParameters.RequestContext) || parameters[0].Equals(KnownParameters.CancellationTokenParameter)));

        // RequestContext is excluded
        private static bool HasNonBodyCustomParameter(IReadOnlyList<Parameter> parameters)
            => parameters.Any(p => p.RequestLocation != RequestLocation.Body && !p.Equals(KnownParameters.RequestContext));

        private void ComposeExampleWithoutRequestContent(LowLevelClientMethod clientMethod, string methodName, bool isAsync, StringBuilder builder)
        {
            // TODO -- will refactor later to remove these and return the message and test method name from the instance of `DpgOperationSample` instead
            var hasNonBodyParameter = HasNonBodyCustomParameter(clientMethod.ProtocolMethodSignature.Parameters);
            builder.AppendLine($"This sample shows how to call {methodName}{(hasNonBodyParameter ? " with required parameters" : "")}{(clientMethod.ResponseBodyType != null ? " and parse the result" : "")}.");
            WriteTestMethodName(clientMethod.ProtocolMethodSignature.Name, false, isAsync, false, builder);
        }

        private void ComposeExampleWithRequiredParameters(LowLevelClientMethod clientMethod, string methodName, bool isAsync, StringBuilder builder)
        {
            builder.AppendLine($"This sample shows how to call {methodName} with required {GenerateParameterAndRequestContentDescription(clientMethod.ProtocolMethodSignature.Parameters)}{(clientMethod.ResponseBodyType != null ? " and parse the result" : "")}.");
            WriteTestMethodName(clientMethod.ProtocolMethodSignature.Name, true, isAsync, false, builder);
        }

        private void ComposeExampleWithRequiredParameters(ConvenienceMethod convenienceMethod, string methodName, bool isAsync, StringBuilder builder)
        {
            builder.AppendLine($"This sample shows how to call {methodName} with required parameters.");
            WriteTestMethodName(convenienceMethod.Signature.Name, true, isAsync, true, builder);
        }

        /// <summary>
        /// Check top level properties of the given model, return true if a required and writable property is found.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        private bool HasRequiredAndWritablePropertyFromTop(InputModelType model)
            => GetConcreteChildModel(model).GetSelfAndBaseModels().Any(m => m.Properties.Any(p => p.IsRequired && !p.IsReadOnly));

        private bool HasOptionalInputValue(IReadOnlyList<Parameter> parameters, InputType? requestBodyType, out InputModelType? requestModel)
        {
            requestModel = requestBodyType as InputModelType;
            if (parameters.Any(p => p.IsOptionalInSignature && !p.Equals(KnownParameters.RequestContext)))
            {
                return true;
            }

            return requestModel != null && HasOptionalAndWritableProperty(requestModel);
        }

        /// <summary>
        /// Check if there is any optional and writable property in the given model hierarchy.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        private bool HasOptionalAndWritableProperty(InputModelType model)
        {
            // Visit each schema in the graph and for object schemas, check if any property is optional
            var visitedModels = new HashSet<InputModelType>();
            var modelsToExplore = new Queue<InputModelType>(new[] { model });

            while (modelsToExplore.Any())
            {
                var toExplore = modelsToExplore.Dequeue();

                if (visitedModels.Contains(toExplore))
                {
                    continue;
                }

                foreach (var modelOrBase in GetConcreteChildModel(toExplore).GetSelfAndBaseModels())
                {
                    foreach (var prop in modelOrBase.Properties)
                    {
                        if (!prop.IsRequired && !prop.IsReadOnly)
                        {
                            return true;
                        }

                        if (prop.Type is InputModelType modelType)
                        {
                            modelsToExplore.Enqueue(modelType);
                        }
                    }
                }

                visitedModels.Add(toExplore);
            }

            return false;
        }

        private void ComposeExampleWithParametersAndRequestContent(LowLevelClientMethod clientMethod, string methodName, bool isAsync, bool useAllParameters, StringBuilder builder)
        {
            builder.AppendLine($"This sample shows how to call {methodName} with {(useAllParameters ? "all" : "required")} {GenerateParameterAndRequestContentDescription(clientMethod.ProtocolMethodSignature.Parameters)}{(clientMethod.ResponseBodyType != null ? ", and how to parse the result" : "")}.");
            WriteTestMethodName(clientMethod.ProtocolMethodSignature.Name, useAllParameters, isAsync, false, builder);
        }

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

        private void ComposeExampleWithoutParameter(LowLevelClientMethod clientMethod, string methodName, bool isAsync, bool useAllParameters, StringBuilder builder)
        {
            builder.AppendLine($"This sample shows how to call {methodName}{(clientMethod.ResponseBodyType != null ? " and parse the result" : "")}.");
            WriteTestMethodName(clientMethod.ProtocolMethodSignature.Name, useAllParameters, isAsync, false, builder);
        }

        private void ComposeExampleWithoutParameter(ConvenienceMethod convenienceMethod, string methodName, bool isAsync, bool useAllParameters, StringBuilder builder)
        {
            builder.AppendLine($"This sample shows how to call {methodName}.");
            WriteTestMethodName(convenienceMethod.Signature.Name, useAllParameters, isAsync, true, builder);
        }

        private static InputModelType GetConcreteChildModel(InputModelType model)
            => model.DerivedModels.Any() ? model.DerivedModels[0] : model;

        private void WriteTestMethodName(string methodName, bool useAllParameters, bool isAsync, bool isConvenienceMethod, StringBuilder builder)
        {
            // TODO -- maybe use XDocument to refactor
            builder.Append("<code>");
            builder.Append(GetTestMethodName(methodName, useAllParameters, isAsync, isConvenienceMethod));
            builder.Append("</code>");
        }

        // TOFO -- refactor
        internal string GetTestMethodName(string methodName, bool useAllParameters, bool isAsync, bool isConvenienceMethod)
        {
            var builder = new StringBuilder("Example_").Append(methodName);
            if (useAllParameters)
            {
                builder.Append("_AllParameters");
            }
            if (isConvenienceMethod)
            {
                builder.Append("_Convenience");
            }
            if (isAsync)
            {
                builder.Append("_Async");
            }
            return builder.ToString();
        }
    }
}

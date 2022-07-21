// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using Azure;
using Azure.Core;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Shared;

namespace AutoRest.CSharp.Generation.Writers
{
    internal class LowLevelExampleComposer
    {
        private static readonly CSharpType UriType = new CSharpType(typeof(Uri));
        private static readonly CSharpType KeyAuthType = KnownParameters.KeyAuth.Type;
        private static readonly CSharpType TokenAuthType = KnownParameters.TokenAuth.Type;

        private string ClientTypeName { get; }
        private IReadOnlyList<MethodSignatureBase> ClientInvocationChain { get; }


        public LowLevelExampleComposer(LowLevelClient client)
        {
            ClientTypeName = client.Type.Name;
            ClientInvocationChain = GetClientInvocationChain(client);
        }

        public FormattableString Compose(LowLevelClientMethod clientMethod, bool async)
        {
            var methodSignature = clientMethod.Signature.WithAsync(async);
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

        // `RequestContext = null` is excluded
        private static bool HasNoCustomInput(IReadOnlyList<Parameter> parameters)
            => parameters.Count == 0 || parameters.Count == 1 && parameters[0].Equals(KnownParameters.RequestContext);

        // RequestContext is excluded
        private static bool HasNonBodyCustomParameter(IReadOnlyList<Parameter> parameters)
            => parameters.Any(p => p.RequestLocation != RequestLocation.Body && !p.Equals(KnownParameters.RequestContext));

        private void ComposeExampleWithoutRequestContent(LowLevelClientMethod clientMethod, string methodName, bool async, StringBuilder builder)
        {
            var hasNonBodyParameter = HasNonBodyCustomParameter(clientMethod.Signature.Parameters);
            builder.AppendLine($"This sample shows how to call {methodName}{(hasNonBodyParameter ? " with required parameters" : "")}{(clientMethod.ResponseBodyType != null ? " and parse the result" : "")}.");
            ComposeCodeSnippet(clientMethod, methodName, async, false, builder);
        }

        private void ComposeExampleWithRequiredParameters(LowLevelClientMethod clientMethod, string methodName, bool async, StringBuilder builder)
        {
            builder.AppendLine($"This sample shows how to call {methodName} with required {GenerateParameterAndRequestContentDescription(clientMethod.Signature.Parameters)}{(clientMethod.ResponseBodyType != null ? " and parse the result" : "")}.");
            ComposeCodeSnippet(clientMethod, methodName, async, true, builder);
        }

        /// <summary>
        /// Check top level properties of the given model, return true if a required and writable property is found.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        private bool HasRequiredAndWritablePropertyFromTop(InputModel model)
            => GetConcreteChildModel(model).GetSelfAndBaseModels().Any(m => m.Properties.Any(p => p.IsRequired && !p.IsReadOnly));

        private bool HasOptionalInputValue(IReadOnlyList<Parameter> parameters, InputType? requestBodyType, out InputModel? requestModel)
        {
            requestModel = requestBodyType?.Model;
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
        private bool HasOptionalAndWritableProperty(InputModel model)
        {
            // Visit each schema in the graph and for object schemas, check if any property is optional
            var visitedModels = new HashSet<InputModel>();
            var modelsToExplore = new Queue<InputModel>(new[] { model });

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

                        if (prop.Type.Model != null)
                        {
                            modelsToExplore.Enqueue(prop.Type.Model);
                        }
                    }
                }

                visitedModels.Add(toExplore);
            }

            return false;
        }

        private void ComposeExampleWithParametersAndRequestContent(LowLevelClientMethod clientMethod, string methodName, bool async, bool allParameters, StringBuilder builder)
        {
            builder.AppendLine($"This sample shows how to call {methodName} with {(allParameters ? "all" : "required")} {GenerateParameterAndRequestContentDescription(clientMethod.Signature.Parameters)}{(clientMethod.ResponseBodyType != null ? ", and how to parse the result" : "")}.");
            ComposeCodeSnippet(clientMethod, methodName, async, allParameters, builder);
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

        private void ComposeExampleWithoutParameter(LowLevelClientMethod clientMethod, string methodName, bool async, bool allParameters, StringBuilder builder)
        {
            builder.AppendLine($"This sample shows how to call {methodName}{(clientMethod.ResponseBodyType != null ? " and parse the result" : "")}.");
            ComposeCodeSnippet(clientMethod, methodName, async, allParameters, builder);
        }

        private void ComposeCodeSnippet(LowLevelClientMethod clientMethod, string methodName, bool async, bool allParameters, StringBuilder builder)
        {
            builder.AppendLine("<code><![CDATA[");
            ComposeGetClientCodes(builder);
            builder.AppendLine();
            if (clientMethod.RequestBodyType != null)
            {
                ComposeRequestContent(allParameters, clientMethod.RequestBodyType, builder);
                builder.AppendLine();
            }

            if (clientMethod.LongRunning != null)
            {
                if (clientMethod.PagingInfo != null && clientMethod.PagingInfo?.NextPageMethod != null)
                {
                    ComposeHandleLongRunningPageableResponseCode(clientMethod, methodName, async, allParameters, builder);
                }
                else
                {
                    ComposeHandleLongRunningResponseCode(clientMethod, methodName, async, allParameters, builder);
                }
            }
            else if (clientMethod.PagingInfo != null)
            {
                ComposeHandlePageableResponseCode(clientMethod, methodName, async, allParameters, builder);
            }
            else
            {
                ComposeHandleNormalResponseCode(clientMethod, methodName, async, allParameters, builder);
            }

            builder.Append("]]></code>");
        }

        private void ComposeHandleLongRunningPageableResponseCode(LowLevelClientMethod clientMethod, string methodName, bool async, bool allParameters, StringBuilder builder)
        {
            if (clientMethod is not { ResponseBodyType.Model: {} responseModel})
            {
                return;
            }

            /* CODE PATTEN
             * var operation = await client.{methodName}(...);
             *
             * var response = await operation.WaitForCompletionAsync();
             * await foreach (var data in response.Value)
             * {
             *     Console.WriteLine(data.ToString());
             * or
             *     JsonElement result = JsonDocument.Parse(data.ToStream()).RootElement;
             *     Console.WriteLine(result[.GetProperty(...)...].ToString());
             *     ...
             * }
             */
            builder.AppendLine($"var operation = {(async ? "await " : "")}client.{methodName}({MockParameterValues(clientMethod.Signature.Parameters.SkipLast(1).ToList(), allParameters)});");
            builder.AppendLine();
            builder.AppendLine($"var response = {(async ? "await " : "")}operation.WaitForCompletion{(async ? "Async" : "")}();");
            using (Scope($"{(async ? "await " : "")}foreach (var data in response.Value)", 0, builder, true))
            {
                ComposeParsingPageableResponseCodes(responseModel, clientMethod.PagingInfo!.ItemName, allParameters, builder);
            }
        }

        private void ComposeHandleLongRunningResponseCode(LowLevelClientMethod clientMethod, string methodName, bool async, bool allParameters, StringBuilder builder)
        {
            /* GENERATED CODE PATTERN
             * var operation = await client.{methodName}(...);
             *
             * var response = await operation.WaitForCompletionResponseAsync();
             * Console.WriteLine(response.Status);
             * or
             * BinaryData data = await operation.WaitForCompletionAsync();
             * JsonElement result = JsonDocument.Parse(data.ToStream()).RootElement;
             * Console.WriteLine(result[.GetProperty(...)...].ToString());
             * ...
             */
            builder.AppendLine($"var operation = {(async ? "await " : "")}client.{methodName}({MockParameterValues(clientMethod.Signature.Parameters.SkipLast(1).ToList(), allParameters)});");
            builder.AppendLine();

            if (clientMethod.ResponseBodyType == null)
            {
                builder.AppendLine($"var response = {(async ? "await " : "")}operation.WaitForCompletionResponse{(async ? "Async" : "")}();");
                builder.AppendLine("Console.WriteLine(response.Status)");
            }
            else
            {
                builder.AppendLine($"BinaryData data = {(async ? "await " : "")}operation.WaitForCompletion{(async ? "Async" : "")}();");
                ComposeParsingLongRunningResponseCodes(allParameters, clientMethod.ResponseBodyType, builder);
            }
        }

        private void ComposeParsingLongRunningResponseCodes(bool allProperties, InputType inputType, StringBuilder builder)
        {
            if (inputType is {Kind: InputTypeKind.Stream})
            {
                using (Scope("using(Stream outFileStream = File.OpenWrite(\"<filePath>\")", 0, builder, true))
                {
                    builder.AppendLine("    data.ToStream().CopyTo(outFileStream);");
                }
                return;
            }

            var apiInvocationChainList = new List<IReadOnlyList<string>>();
            ComposeResponseParsingCode(allProperties, inputType, apiInvocationChainList, new Stack<string>(new[] { "result" }), new HashSet<InputModel>());

            if (apiInvocationChainList.Count == 0)
            {
                builder.AppendLine($"Console.WriteLine(data.ToString());");
            }
            else
            {
                builder.AppendLine($"JsonElement result = JsonDocument.Parse(data.ToStream()).RootElement;");
                foreach (var apiInvocationChain in apiInvocationChainList)
                {
                    builder.AppendLine($"Console.WriteLine({string.Join(".", apiInvocationChain)}.ToString());");
                }
            }
        }

        private void ComposeHandlePageableResponseCode(LowLevelClientMethod clientMethod, string methodName, bool async, bool allParameters, StringBuilder builder)
        {
            if (clientMethod.ResponseBodyType is not { Model: { } model })
            {
                return;
            }

            /* GENERATED CODE PATTERN
             * await foreach (var data in client.{methodName}(...))
             * {
             *     Console.WriteLine(data.ToString());
             * or
             *     JsonElement result = JsonDocument.Parse(data.ToStream()).RootElement;
             *     Console.WriteLine(result[.GetProperty(...)...].ToString());
             *     ...
             * }
             */
            using (Scope($"{(async ? "await " : "")}foreach (var data in client.{methodName}({MockParameterValues(clientMethod.Signature.Parameters.SkipLast(1).ToList(), allParameters)}))", 0, builder, true))
            {
                ComposeParsingPageableResponseCodes(model, clientMethod.PagingInfo!.ItemName, allParameters, builder);
            }
        }

        private void ComposeParsingPageableResponseCodes(InputModel responseModel, string pagingItemName, bool allProperties, StringBuilder builder)
        {
            foreach (var property in responseModel.Properties)
            {
                if (property.SerializedName == pagingItemName && property is {Type.Kind: InputTypeKind.List})
                {
                    var apiInvocationChainList = new List<IReadOnlyList<string>>();
                    ComposeResponseParsingCode(allProperties, property.Type.ValuesType!, apiInvocationChainList, new Stack<string>(new[] { "result" }), new HashSet<InputModel>() { responseModel });
                    var parsingCodes = new List<string>(apiInvocationChainList.Count + 1);

                    if (apiInvocationChainList.Count == 0)
                    {
                        builder.Append(' ', 4);
                        builder.AppendLine($"Console.WriteLine(data.ToString());");
                    }
                    else
                    {
                        builder.Append(' ', 4);
                        builder.AppendLine($"JsonElement result = JsonDocument.Parse(data.ToStream()).RootElement;");
                        foreach (var apiInvocationChain in apiInvocationChainList)
                        {
                            builder.Append(' ', 4);
                            builder.AppendLine($"Console.WriteLine({string.Join(".", apiInvocationChain)}.ToString());");
                        }
                    }
                    break;
                }
            }
        }

        private void ComposeHandleNormalResponseCode(LowLevelClientMethod clientMethod, string methodName, bool async, bool allParameters, StringBuilder builder)
        {
            builder.AppendLine($"Response response = {(async ? "await " : "")}client.{methodName}({MockParameterValues(clientMethod.Signature.Parameters.SkipLast(1).ToList(), allParameters)});");
            if (clientMethod.ResponseBodyType != null)
            {
                ComposeParsingNormalResponseCodes(allParameters, clientMethod.ResponseBodyType, builder);
            }
            else
            {
                builder.AppendLine("Console.WriteLine(response.Status);");
            }
        }

        private void ComposeParsingNormalResponseCodes(bool allProperties, InputType responseBodyType, StringBuilder builder)
        {
            if (responseBodyType is {Kind: InputTypeKind.Stream})
            {
                using (Scope("if (response.ContentStream != null)", 0, builder, true))
                {
                    using (Scope("    using(Stream outFileStream = File.OpenWrite(\"<filePath>\")", 4, builder, true))
                    {
                        builder.AppendLine("        response.ContentStream.CopyTo(outFileStream);");
                    }
                }
                return;
            }

            var apiInvocationChainList = new List<IReadOnlyList<string>>();
            ComposeResponseParsingCode(allProperties, responseBodyType, apiInvocationChainList, new Stack<string>(new[] { "result" }), new HashSet<InputModel>());

            builder.AppendLine();

            if (apiInvocationChainList.Count == 0)
            {
                builder.AppendLine($"Console.WriteLine(response.ToString());");
            }
            else
            {
                builder.AppendLine($"JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;");
                foreach (var apiInvocationChain in apiInvocationChainList)
                {
                    builder.AppendLine($"Console.WriteLine({string.Join(".", apiInvocationChain)}.ToString());");
                }
            }
        }

        private void ComposeResponseParsingCode(bool allProperties, InputType type, List<IReadOnlyList<string>> apiInvocationChainList, Stack<string> currentApiInvocationChain, HashSet<InputModel> visitedModels)
        {
            InputType? nextType = type;
            while (nextType != null)
            {
                if (nextType.Model != null && visitedModels.Contains(nextType.Model))
                {
                    return;
                }

                nextType = nextType.ValuesType;
            }

            switch (type)
            {
                case { Kind: InputTypeKind.List }:
                    // {parentOp}[0]
                    var parentOp = currentApiInvocationChain.Pop();
                    currentApiInvocationChain.Push($"{parentOp}[0]");
                    ComposeResponseParsingCode(allProperties, type.ValuesType!, apiInvocationChainList, currentApiInvocationChain, visitedModels);
                    return;
                case { Kind: InputTypeKind.Dictionary }:
                    // .GetProperty("<test>")
                    currentApiInvocationChain.Push("GetProperty(\"<test>\")");
                    ComposeResponseParsingCode(allProperties, type.ValuesType!, apiInvocationChainList, currentApiInvocationChain, visitedModels);
                    currentApiInvocationChain.Pop();
                    return;
                case { Model: {} model }:
                    visitedModels.Add(model);
                    ComposeResponseParsingCode(allProperties, model, apiInvocationChainList, currentApiInvocationChain, visitedModels);
                    visitedModels.Remove(model);
                    return;
            }

            // primitive types, return
            AddApiInvocationChainResult(apiInvocationChainList, currentApiInvocationChain);
        }

        private void ComposeResponseParsingCode(bool allProperties, InputModel model, List<IReadOnlyList<string>> apiInvocationChainList, Stack<string> currentApiInvocationChain, HashSet<InputModel> visitedModels)
        {
            foreach (var modelOrBase in model.GetSelfAndBaseModels())
            {
                if (!modelOrBase.Properties.Any())
                {
                    continue;
                }

                var propertiesToExplore = modelOrBase.Properties;
                if (!allProperties)
                {
                    propertiesToExplore = modelOrBase.Properties.Where(p => p.IsRequired).ToArray();
                }

                if (propertiesToExplore.Count == 0) // if you have a required property, but its child properties are all optional
                {
                    // return the object
                    AddApiInvocationChainResult(apiInvocationChainList, currentApiInvocationChain);
                    return;
                }

                foreach (var property in propertiesToExplore)
                {
                    var propertyModel = property.Type.Model;
                    if (propertyModel != null && visitedModels.Contains(propertyModel))
                    {
                        continue;
                    }

                    // .GetProperty("{property_name}")
                    currentApiInvocationChain.Push($"GetProperty(\"{property.SerializedName}\")");
                    ComposeResponseParsingCode(allProperties, property.Type, apiInvocationChainList, currentApiInvocationChain, visitedModels);
                    currentApiInvocationChain.Pop();
                }
            }
        }

        private void AddApiInvocationChainResult(List<IReadOnlyList<string>> apiInvocationChainList, Stack<string> currentApiInvocationChain)
        {
            var finalChain = currentApiInvocationChain.ToList();
            finalChain.Reverse();
            apiInvocationChainList.Add(finalChain);
        }

        private string MockParameterValues(IReadOnlyList<Parameter> parameters, bool allParameters)
        {
            if (parameters.Count == 0)
            {
                return "";
            }

            var parameterValues = new List<string>(parameters.Count);
            for (int i = 0; i < parameters.Count; i++)
            {
                if (allParameters || parameters[i].DefaultValue == null)
                {
                    parameterValues.Add(MockParameterValue(parameters[i]));
                }
            }
            return string.Join(", ", parameterValues);
        }

        private string MockParameterValue(Parameter parameter)
        {
            if (parameter.RequestLocation == RequestLocation.Body)
            {
                return "RequestContent.Create(data)";
            }

            if (parameter.DefaultValue != null)
            {
                var defaultValue = parameter.DefaultValue.Value;
                if (defaultValue.IsNewInstanceSentinel && defaultValue.Type.IsValueType)
                {
                    return "default";
                }

                if (defaultValue.Value != null) // skip null default value like "string a = null"
                {
                    if (defaultValue.Type.IsFrameworkType && defaultValue.Type.FrameworkType == typeof(string))
                    {
                        return $"<{defaultValue.Value}>";
                    }
                    return JsonSerializer.Serialize(defaultValue.Value);
                }
            }
            return MockParameterTypeValue(parameter.Name, parameter.Type);
        }

        private string MockParameterTypeValue(string parameterName, CSharpType parameterType)
        {
            if (parameterType.IsFrameworkType)
            {
                var type = parameterType.FrameworkType;

                // Refer to TypeFactory.cs as how number type is created
                if (type == typeof(float) || type == typeof(decimal) || type == typeof(decimal) ||
                    type == typeof(double) || type == typeof(long) || type == typeof(int))
                {
                    return "1234";
                }

                if (type == typeof(string))
                {
                    return $"\"<{parameterName}>\"";
                }

                if (type == typeof(bool))
                {
                    return "true";
                }

                if (type == typeof(DateTimeOffset))
                {
                    return "DateTimeOffset.UtcNow";
                }

                if (type == typeof(DateTime))
                {
                    return "DateTime.UtcNow";
                }

                if (type == typeof(TimeSpan))
                {
                    return "new TimeSpan(1, 2, 3)";
                }

                if (type == typeof(MatchConditions))
                {
                    return "new MatchConditions { IfMatch = \"<YOUR_ETAG>\" }";
                }

                if (type == typeof(Guid))
                {
                    return "Guid.NewGuid()";
                }

                if (type.IsEnum)
                {
                    return $"{type.Name}.{Enum.GetNames(type)[0]}";
                }

                if (type == typeof(ContentType))
                {
                    return $"{nameof(ContentType)}.{nameof(ContentType.ApplicationOctetStream)}"; // stick to octect-stream?
                }

                if (type == typeof(IEnumerable<>))
                {
                    var elementType = parameterType.Arguments[0];
                    return $"new {elementType.Name}[]{{{MockParameterTypeValue(parameterName, elementType)}}}";
                }

                if (type == typeof(IDictionary<,>))
                {
                    var valueType = parameterType.Arguments[1];
                    return $"new Dictionary<string, {valueType.Name}>{{ \"<test>\" = {MockParameterTypeValue(parameterName, valueType)} }}";
                }
            }

            return "null"; // some unknown found
        }

        private void ComposeRequestContent(bool composeAll, InputType requestBodyType, StringBuilder builder)
        {
            // var data = {value_expression};
            builder.Append("var data = ");
            builder.Append(ComposeRequestContent(composeAll, requestBodyType, null, 0, new HashSet<InputModel>()));
            builder.AppendLine(";");
        }

        private string ComposeRequestContent(bool allProperties, InputType inputType, string? propertyDescription, int indent, HashSet<InputModel> visitedModels) => inputType switch
        {
            { Kind: InputTypeKind.List }           => ComposeArrayRequestContent(allProperties, inputType.ValuesType!, indent, visitedModels),
            { Kind: InputTypeKind.Dictionary }     => ComposeDictionaryRequestContent(allProperties, inputType.ValuesType!, indent, visitedModels),
            { Kind: InputTypeKind.Stream }         => "File.OpenRead(\"<filePath>\")",
            { Kind: InputTypeKind.Boolean }        => "true",
            { Kind: InputTypeKind.DateTime, SerializationFormat: InputTypeSerializationFormat.Date } => "\"2022-05-10\"",
            { Kind: InputTypeKind.DateTime }       => "\"2022-05-10T14:57:31.2311892-04:00\"",
            { Kind: InputTypeKind.Enum }           => $"\"{inputType.AllowedValues!.First().Value}\"",
            { Kind: InputTypeKind.ExtensibleEnum } => $"\"{inputType.AllowedValues!.First().Value}\"",
            { Kind: InputTypeKind.Float32 }        => "123.45f",
            { Kind: InputTypeKind.Float64 }        => "123.45d",
            { Kind: InputTypeKind.Float128 }       => "123.45m",
            { Kind: InputTypeKind.Guid }           => "\"73f411fe-4f43-4b4b-9cbd-6828d8f4cf9a\"",
            { Kind: InputTypeKind.Int32 }          => "1234",
            { Kind: InputTypeKind.Int64 }          => "1234L",
            { Kind: InputTypeKind.String }         => string.IsNullOrWhiteSpace(propertyDescription) ? "\"<String>\"" : $"\"<{propertyDescription}>\"",
            { Kind: InputTypeKind.Time, SerializationFormat: InputTypeSerializationFormat.Duration } => "PT1H23M45S",
            { Kind: InputTypeKind.Time }           => "01:23:45",
            { Kind: InputTypeKind.Model, Model: {} model } => ComposeModelRequestContent(allProperties, model, indent, visitedModels),
            _ => "new {}"
        };

        private string ComposeArrayRequestContent(bool allProperties, InputType elementType, int indent, HashSet<InputModel> visitedModels)
        {
            /* GENERATED CODE PATTERN
             * new[] {
             *     {element_expression}
             * }
             * or
             * new[] {}
             */

            var elementExpr = ComposeRequestContent(allProperties, elementType, null, indent + 4, visitedModels);
            if (elementExpr == "")
            {
                return "new[] {}";
            }

            var builder = new StringBuilder();
            using (Scope("new[] ", indent, builder))
            {
                builder.Append(' ', indent + 4).Append(elementExpr).AppendLine();
            }
            return builder.ToString();
        }

        private string ComposeDictionaryRequestContent(bool allProperties, InputType elementType, int indent, HashSet<InputModel> visitedModels)
        {
            /* GENERATED CODE PATTERN
             * new {
             *     key = {value_expression},
             * }
             * or
             * new {}
             */
            var valueExpr = ComposeRequestContent(allProperties, elementType, null, indent + 4, visitedModels);
            if (valueExpr == "")
            {
                return "new {}";
            }

            var builder = new StringBuilder();
            using (Scope("new ", indent, builder))
            {
                builder.Append(' ', indent + 4).AppendLine($"key = {valueExpr},");
            }
            return builder.ToString();
        }

        private string ComposeModelRequestContent(bool allProperties, InputModel model, int indent, HashSet<InputModel> visitedModels)
        {
            if (visitedModels.Contains(model))
            {
                return "";
            }

            /* GENERATED CODE PATTERN
                     * new {
                     *     prop1 = {value_expression},
                     *     prop2 = {value_expression},
                     *     ...
                     * }
                     * or
                     * new {}
                     */
            var properties = new List<InputModelProperty>();
            // We must also include any properties introduced by our parent chain.
            // Try to get the concrete child type for polymorphism
            var concreteModel = GetConcreteChildModel(model);
            foreach (var modelOrBase in concreteModel.GetSelfAndBaseModels())
            {
                if (allProperties)
                {
                    properties.AddRange(modelOrBase.Properties.Where(p => !p.IsReadOnly));
                }
                else
                {
                    properties.AddRange(modelOrBase.Properties.Where(p => p.IsRequired && !p.IsReadOnly));
                }
            }

            if (!properties.Any())
            {
                return "new {}";
            }

            visitedModels.Add(model);
            var propertyExpressions = new List<string>();
            foreach (var property in properties)
            {
                string propertyValueExpr = "";
                if (property.IsDiscriminator)
                {
                    propertyValueExpr = property is {Type.Kind: InputTypeKind.Boolean or InputTypeKind.Int32} ? $"{concreteModel.DiscriminatorValue}" : $"\"{concreteModel.DiscriminatorValue}\"";
                }
                else
                {
                    propertyValueExpr = ComposeRequestContent(allProperties, property.Type, property.SerializedName, indent + 4, visitedModels);

                }

                if (propertyValueExpr != "")
                {
                    var propertyExprBuilder = new StringBuilder();
                    propertyExprBuilder.Append(' ', indent + 4).Append($"{property.SerializedName} = {propertyValueExpr},");
                    propertyExpressions.Add(propertyExprBuilder.ToString());
                }
            }
            visitedModels.Remove(model);

            if (propertyExpressions.Count == 0)
            {
                return "new {}";
            }

            var builder = new StringBuilder();
            using (Scope("new ", indent, builder))
            {
                foreach (var expr in propertyExpressions)
                {
                    builder.AppendLine(expr);
                }
            }
            return builder.ToString();
        }

        private void ComposeGetClientCodes(StringBuilder builder)
        {
            var clientConstructor = ClientInvocationChain[0];
            if (clientConstructor.Parameters.Any(p => p.Type.EqualsIgnoreNullable(KeyAuthType)))
            {
                builder.AppendLine("var credential = new AzureKeyCredential(\"<key>\");");
            }
            else if (clientConstructor.Parameters.Any(p => p.Type.EqualsIgnoreNullable(TokenAuthType)))
            {
                builder.AppendLine("var credential = new DefaultAzureCredential();");
            }

            if (clientConstructor.Parameters.Any(p => p.Type.EqualsIgnoreNullable(UriType)))
            {
                builder.AppendLine($"var endpoint = new Uri(\"<{GetEndpoint()}>\");");
            }

            var code = $"var client = new {ClientInvocationChain[0].Name}({MockClientConstructorParameterValues(ClientInvocationChain[0].Parameters)})";

            if (ClientInvocationChain.Count > 1)
            {
                for (int i = 1; i < ClientInvocationChain.Count; i++)
                {
                    var factoryMethod = ClientInvocationChain[i];
                    code += GetFactoryMethodCode(factoryMethod);
                }
            }
            builder.Append(code).AppendLine(";");
        }

        private string MockClientConstructorParameterValues(IReadOnlyList<Parameter> parameters)
        {
            var parameterValues = new List<string>(parameters.Count);
            foreach (var parameter in parameters)
            {
                if (parameter.Type.EqualsIgnoreNullable(UriType))
                {
                    parameterValues.Add("endpoint");
                }
                else if (parameter.Name.Equals("endpoint", StringComparison.OrdinalIgnoreCase))
                {
                    // sometimes the endpoint parameter cannot be generated as Uri type, best efforts to guesss it
                    // see: https://github.com/Azure/autorest/issues/4571
                    parameterValues.Add($"\"<{GetEndpoint()}>\"");
                }
                else if (parameter.Type.EqualsIgnoreNullable(KeyAuthType) || parameter.Type.EqualsIgnoreNullable(TokenAuthType))
                {
                    parameterValues.Add("credential");
                }
                else
                {
                    parameterValues.Add(MockParameterValue(parameter));
                }
            }
            return string.Join(", ", parameterValues);
        }

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
            callChain.Push(client.SecondaryConstructors.Where(c => c.Modifiers == MethodSignatureModifiers.Public).OrderBy(c => c.Parameters.Count).First());

            return callChain.ToList();
        }

        private string GetFactoryMethodCode(MethodSignatureBase factoryMethod)
        {
            return $".{factoryMethod.Name}({MockParameterValues(factoryMethod.Parameters, true)})";
        }

        private static string GetEndpoint()
        {
            // TODO: is there a way to compose a data plane endpoint from swagger?
            return "https://my-service.azure.com";
        }

        private static InputModel GetConcreteChildModel(InputModel model)
            => model.DerivedModels.Any() ? model.DerivedModels[0] : model;

        private CodeScope Scope(string content, int indent, StringBuilder builder, bool encloseWithNewLine = false)
        {
            builder.Append(content);
            if (encloseWithNewLine)
            {
                builder.AppendLine().Append(' ', indent);
            }
            builder.AppendLine("{");
            return new CodeScope(builder, indent, encloseWithNewLine);
        }

        private class CodeScope : IDisposable
        {
            private StringBuilder Builder { get; }
            private int Indent { get; }
            private bool EncloseWithNewLine { get; }

            internal CodeScope(StringBuilder builder, int indent, bool encloseWithNewLine)
            {
                Builder = builder;
                Indent = indent;
                EncloseWithNewLine = encloseWithNewLine;
            }

            public void Dispose()
            {
                Builder.Append(' ', Indent).Append("}");
                if (EncloseWithNewLine)
                {
                    Builder.AppendLine();
                }
            }
        }
    }
}

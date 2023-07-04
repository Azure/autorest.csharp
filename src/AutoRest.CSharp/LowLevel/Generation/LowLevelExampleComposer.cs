// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.


using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;
using Azure;
using Azure.Core;
using Microsoft.CodeAnalysis.CSharp;

namespace AutoRest.CSharp.Generation.Writers
{
    internal class LowLevelExampleComposer
    {
        private static readonly CSharpType UriType = new CSharpType(typeof(Uri));
        private static readonly CSharpType KeyAuthType = KnownParameters.KeyAuth.Type;
        private static readonly CSharpType TokenAuthType = KnownParameters.TokenAuth.Type;

        private string ClientTypeName { get; }
        private IReadOnlyList<MethodSignatureBase> ClientInvocationChain { get; }
        private LowLevelClient _client;


        public LowLevelExampleComposer(LowLevelClient client)
        {
            _client = client;
            ClientTypeName = client.Type.Name;
            ClientInvocationChain = GetClientInvocationChain(client);
        }

        public FormattableString Compose(LowLevelClientMethod clientMethod, bool async)
        {
            //skip non public protocol methods
            if ((clientMethod.ProtocolMethodSignature.Modifiers & MethodSignatureModifiers.Public) == 0)
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

            ComposeConvenienceMethodExample(convenienceMethod, async, true, methodSignature.Name, builder);

            return $"{builder.ToString()}";
        }

        internal void ComposeConvenienceMethodExample(ConvenienceMethod convenienceMethod, bool async, bool shouldWrap, string methodName, StringBuilder builder)
        {
            if (HasNoCustomInput(convenienceMethod.Signature.Parameters)) // client.GetAllItems(CancellationToken cancellationToken = default)
            {
                ComposeExampleWithoutParameter(convenienceMethod, methodName, async, true, shouldWrap, builder);
            }
            else
            {
                // client.GetAllItems(int a, RequestContext context = null)
                ComposeExampleWithRequiredParameters(convenienceMethod, methodName, async, shouldWrap, builder);
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
            var hasNonBodyParameter = HasNonBodyCustomParameter(clientMethod.ProtocolMethodSignature.Parameters);
            builder.AppendLine($"This sample shows how to call {methodName}{(hasNonBodyParameter ? " with required parameters" : "")}{(clientMethod.ResponseBodyType != null ? " and parse the result" : "")}.");
            WriteTestMethodName(clientMethod.ProtocolMethodSignature.Name, false, isAsync, false, builder);
        }

        private void ComposeExampleWithRequiredParameters(LowLevelClientMethod clientMethod, string methodName, bool isAsync, StringBuilder builder)
        {
            builder.AppendLine($"This sample shows how to call {methodName} with required {GenerateParameterAndRequestContentDescription(clientMethod.ProtocolMethodSignature.Parameters)}{(clientMethod.ResponseBodyType != null ? " and parse the result" : "")}.");
            WriteTestMethodName(clientMethod.ProtocolMethodSignature.Name, true, isAsync, false, builder);
        }

        private void ComposeExampleWithRequiredParameters(ConvenienceMethod convenienceMethod, string methodName, bool async, bool shouldWrap, StringBuilder builder)
        {
            if (shouldWrap)
                builder.AppendLine($"This sample shows how to call {methodName} with required parameters.");
            ComposeCodeSnippet(convenienceMethod, methodName, async, true, shouldWrap, builder);
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

        private void ComposeExampleWithoutParameter(ConvenienceMethod convenienceMethod, string methodName, bool async, bool allParameters, bool shouldWrap, StringBuilder builder)
        {
            if (shouldWrap)
                builder.AppendLine($"This sample shows how to call {methodName}.");
            ComposeCodeSnippet(convenienceMethod, methodName, async, allParameters, shouldWrap, builder);
        }

        private void ComposeCodeSnippet(ConvenienceMethod convenienceMethod, string methodName, bool async, bool allParameters, bool shouldWrap, StringBuilder builder)
        {
            if (shouldWrap)
                builder.AppendLine("<code><![CDATA[");
            ComposeGetClientCodes(builder);
            builder.AppendLine();

            // get input parameters -- only body parameter is not initialized inline in the invocation, therefore we take out all the body parameters.
            var typeProviderTypedParameters = convenienceMethod.Signature.Parameters.Where(p => p.RequestLocation == RequestLocation.Body);
            foreach (var parameter in typeProviderTypedParameters)
            {
                ComposeBodyParameter(allParameters, parameter, builder);
            }

            if (convenienceMethod.IsLongRunning)
            {
                if (convenienceMethod.IsPageable)
                {
                    // do nothing, this never happen right now
                }
                else
                {
                    ComposeHandleLongRunningResponseCode(convenienceMethod, methodName, async, allParameters, builder);
                }
            }
            else if (convenienceMethod.IsPageable)
            {
                ComposeHandlePageableResponseCode(convenienceMethod, methodName, async, allParameters, builder);
            }
            else
            {
                ComposeHandleNormalResponseCode(convenienceMethod, methodName, async, allParameters, builder);
            }

            if (shouldWrap)
                builder.Append("]]></code>");
        }

        internal void ComposeCodeSnippet(CodeWriter codeWriter, LowLevelClientMethod clientMethod, string methodName, bool isAsync, bool useAllParameters)
        {
            ComposeGetClientCodes(codeWriter);

            if (clientMethod.RequestBodyType is { } requestBodyType)
            {
                ComposeRequestContent(codeWriter, useAllParameters, requestBodyType);
            }

            switch (clientMethod.LongRunning, clientMethod.PagingInfo)
            {
                case (not null, not null):
                    ComposeHandleLongRunningPageableResponseCode(codeWriter, clientMethod, methodName, isAsync, useAllParameters);
                    break;
                case (not null, null):
                    ComposeHandleLongRunningResponseCode(codeWriter, clientMethod, methodName, isAsync, useAllParameters);
                    break;
                case (null, not null):
                    ComposeHandlePageableResponseCode(codeWriter, clientMethod, methodName, isAsync, useAllParameters);
                    break;
                case (null, null):
                    ComposeHandleNormalResponseCode(codeWriter, clientMethod, methodName, isAsync, useAllParameters);
                    break;
            }
        }

        private void ComposeHandleLongRunningPageableResponseCode(CodeWriter writer, LowLevelClientMethod clientMethod, string methodName, bool isAsync, bool useAllParameters)
        {
            if (clientMethod is not { ResponseBodyType: InputModelType { } responseModel })
                return;

            /* CODE PATTEN
             * var operation = await client.{methodName}(WaitUntil.Completed, ...);
             *
             * await foreach (var item in operation.Value)
             * {
             *     Console.WriteLine(item.ToString());
             * or
             *     JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
             *     Console.WriteLine(result[.GetProperty(...)...].ToString());
             *     ...
             * }
             */
            var returnType = clientMethod.ProtocolMethodSignature.ReturnType!;
            writer.Append($"{returnType} operation = ")
                .AppendRawIf("await ", isAsync)
                .Append($"client.{methodName}(");

            foreach (var parameter in MockParameterValues2(clientMethod.ProtocolMethodSignature.Parameters, MockParameterValue2, useAllParameters))
            {
                writer.Append(parameter).AppendRaw(",");
            }
            writer.RemoveTrailingComma();
            writer.LineRaw(");");

            var itemType = returnType.Arguments.Single();
            writer.Line();
            writer.AppendRawIf("await ", isAsync)
                .Append($"foreach ({itemType} item in operation.Value)");
            using (writer.Scope())
            {
                ComposeParsingPageableResponseCodes(writer, responseModel, clientMethod.PagingInfo!.ItemName, useAllParameters);
            }
        }

        private void ComposeHandleLongRunningResponseCode(CodeWriter writer, LowLevelClientMethod clientMethod, string methodName, bool isAsync, bool useAllParameters)
        {
            /* GENERATED CODE PATTERN
             * var operation = await client.{methodName}(WaitUntil.Completed, ...);
             *
             * Console.WriteLine(operation.GetRawResponse().Status);
             * or
             * BinaryData responseData = operation.Value;
             * JsonElement result = JsonDocument.Parse(data.ToStream()).RootElement;
             * Console.WriteLine(result[.GetProperty(...)...].ToString());
             * ...
             */
            writer.Append($"{clientMethod.ProtocolMethodSignature.ReturnType} operation = ")
                .AppendRawIf("await ", isAsync)
                .Line($"client.{methodName}(");

            foreach (var parameter in MockParameterValues2(clientMethod.ProtocolMethodSignature.Parameters, MockParameterValue2, useAllParameters))
            {
                writer.Append(parameter).AppendRaw(",");
            }
            writer.RemoveTrailingComma();
            writer.LineRaw(");");

            writer.Line();

            if (clientMethod.ResponseBodyType == null)
            {
                ConsoleWriteLine(writer, $"operation.GetRawResponse().Status");
            }
            else
            {
                writer.Line($"{typeof(BinaryData)} responseData = operation.Value;");
                ComposeParsingLongRunningResponseCodes(writer, useAllParameters, clientMethod.ResponseBodyType);
            }
        }

        private void ComposeHandleLongRunningResponseCode(ConvenienceMethod convenienceMethod, string methodName, bool async, bool allParameters, StringBuilder builder)
        {
            /* GENERATED CODE PATTERN
             * var operation = await client.{methodName}(WaitUntil.Completed, ...);
             */
            builder.AppendLine($"var operation = {(async ? "await " : "")}client.{methodName}({MockParameterValues(convenienceMethod.Signature.Parameters.ToList(), MockConvenienceParameterValue, allParameters)});");
        }

        private void ComposeParsingLongRunningResponseCodes(CodeWriter writer, bool useAllProperties, InputType inputType)
        {
            if (inputType is InputPrimitiveType { Kind: InputTypeKind.Stream })
            {
                using (writer.Scope($"using({typeof(Stream)} outFileStream = {typeof(File)}.{nameof(File.OpenWrite)}({"<filePath>":L}))"))
                {
                    writer.Line($"responseData.ToStream().CopyTo(outFileStream);");
                }
                return;
            }

            var apiInvocationChainList = new List<IReadOnlyList<FormattableString>>();
            ComposeResponseParsingCode(useAllProperties, inputType, apiInvocationChainList, new Stack<FormattableString>(new FormattableString[] { $"result" }), new HashSet<InputType>());

            if (!apiInvocationChainList.Any())
            {
                ConsoleWriteLine(writer, $"responseData.ToString()");
            }
            else
            {
                writer.Line($"{typeof(JsonElement)} result = {typeof(JsonDocument)}.{nameof(JsonDocument.Parse)}(responseData.ToStream()).RootElement;");
                foreach (var apiInvocationChain in apiInvocationChainList)
                {
                    ConsoleWriteLine(writer, $"{apiInvocationChain.ToArray().Join(".")}.ToString()");
                }
            }
        }

        private void ComposeHandlePageableResponseCode(CodeWriter writer, LowLevelClientMethod clientMethod, string methodName, bool isAsync, bool useAllParameters)
        {
            if (clientMethod.ResponseBodyType is not InputModelType modelType)
                return;

            var itemType = clientMethod.ProtocolMethodSignature.ReturnType!.Arguments.Single();
            /* GENERATED CODE PATTERN
             * await foreach (var item in client.{methodName}(...))
             * {
             *     Console.WriteLine(item.ToString());
             * or
             *     JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
             *     Console.WriteLine(result[.GetProperty(...)...].ToString());
             *     ...
             * }
             */
            writer.AppendRawIf("await ", isAsync)
                .Append($"foreach ({itemType} item in client.{methodName}(");

            foreach (var parameter in MockParameterValues2(clientMethod.ProtocolMethodSignature.Parameters, MockParameterValue2, useAllParameters))
            {
                writer.Append(parameter).AppendRaw(",");
            }
            writer.RemoveTrailingComma();
            writer.AppendRaw("))");

            using (writer.Scope())
            {
                ComposeParsingPageableResponseCodes(writer, modelType, clientMethod.PagingInfo!.ItemName, useAllParameters);
            }
        }

        private void ComposeHandlePageableResponseCode(ConvenienceMethod convenienceMethod, string methodName, bool async, bool allParameters, StringBuilder builder)
        {
            var methodSignature = convenienceMethod.Signature;
            using (Scope($"{(async ? "await " : "")}foreach (var item in client.{methodName}({MockParameterValues(methodSignature.Parameters.ToList(), MockConvenienceParameterValue, allParameters)}))", 0, builder, true))
            {
            }
        }

        private void ComposeParsingPageableResponseCodes(CodeWriter writer, InputModelType responseModelType, string pagingItemName, bool useAllProperties)
        {
            foreach (var property in responseModelType.Properties)
            {
                if (property.SerializedName == pagingItemName && property.Type is InputListType listType)
                {
                    var apiInvocationChainList = new List<IReadOnlyList<FormattableString>>();
                    ComposeResponseParsingCode(useAllProperties, listType.ElementType, apiInvocationChainList, new Stack<FormattableString>(new FormattableString[] { $"result" }), new HashSet<InputType> { responseModelType });
                }
            }
        }

        private void ComposeHandleNormalResponseCode(CodeWriter writer, LowLevelClientMethod clientMethod, string methodName, bool isAsync, bool useAllParameters)
        {
            CSharpType responseType = typeof(Response);
            var responseVar = new CodeWriterDeclaration("response");
            FormattableString responseExpression = $"{responseVar}";
            if (clientMethod.RequestMethod.Operation.HttpMethod == RequestMethod.Head && Configuration.HeadAsBoolean)
            {
                responseType = typeof(Response<bool>);
                responseExpression = $"{responseVar}.GetRawResponse()";
            }
            writer.Append($"{responseType} {responseVar:D} = ")
                .AppendRawIf("await ", isAsync)
                .Append($"client.{methodName}(");

            foreach (var parameter in MockParameterValues2(clientMethod.ProtocolMethodSignature.Parameters, MockParameterValue2, useAllParameters))
            {
                writer.Append(parameter).AppendRaw(",");
            }
            writer.RemoveTrailingComma();
            writer.LineRaw(");");

            if (clientMethod.ResponseBodyType != null)
            {
                ComposeParsingNormalResponseCodes(writer, useAllParameters, clientMethod.ResponseBodyType, responseExpression);
            }
            else
            {
                ConsoleWriteLine(writer, $"{responseExpression}.Status");
            }
        }

        private void ComposeHandleNormalResponseCode(ConvenienceMethod convenienceMethod, string methodName, bool async, bool allParameters, StringBuilder builder)
        {
            // TODO -- need refactor to use CodeWriter and then reduce with Roslyn maybe?
            var methodSignature = convenienceMethod.Signature;
            builder.AppendLine($"var result = {(async ? "await " : string.Empty)}client.{methodName}({MockParameterValues(methodSignature.Parameters.ToList(), MockConvenienceParameterValue, allParameters)});");
        }

        private void ComposeParsingNormalResponseCodes(CodeWriter writer, bool useAllProperties, InputType responseBodyType, FormattableString responseExpression)
        {
            if (responseBodyType is InputPrimitiveType { Kind: InputTypeKind.Stream })
            {
                using (writer.Scope($"if ({responseExpression}.ContentStream != null)"))
                {
                    using (writer.Scope($"using({typeof(Stream)} outFileStream = {typeof(File)}.{nameof(File.OpenWrite)}({"<filePath>":L})"))
                    {
                        writer.Line($"{responseExpression}.ContentStream.CopyTo(outFileStream);");
                    }
                }
                return;
            }

            var apiInvocationChainList = new List<IReadOnlyList<FormattableString>>();
            ComposeResponseParsingCode(useAllProperties, responseBodyType, apiInvocationChainList, new Stack<FormattableString>(new FormattableString[] { $"result" }), new HashSet<InputType>());

            writer.Line();

            if (!apiInvocationChainList.Any())
            {
                ConsoleWriteLine(writer, $"response.ToString()");
            }
            else
            {
                writer.Line($"{typeof(JsonElement)} result = {typeof(JsonDocument)}.{nameof(JsonDocument.Parse)}(response.ContentStream).RootElement;");
                foreach (var apiInvocationChain in apiInvocationChainList)
                {
                    ConsoleWriteLine(writer, $"{apiInvocationChain.ToList().Join(".")}.ToString()");
                }
            }
        }

        private void ComposeResponseParsingCode(bool useAllProperties, InputType type, List<IReadOnlyList<FormattableString>> apiInvocationChainList, Stack<FormattableString> currentApiInvocationChain, HashSet<InputType> visitedTypes)
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
                    // .GetProrperty("<test>")
                    currentApiInvocationChain.Push($"GetProperty({"<test>":L})");
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

        private void ComposeResponseParsingCodeForModel(bool useAllProperties, InputModelType model, List<IReadOnlyList<FormattableString>> apiInvocationChainList, Stack<FormattableString> currentApiInvocationChain, HashSet<InputType> visitedTypes)
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

        private void AddApiInvocationChainResult(List<IReadOnlyList<FormattableString>> apiInvocationChainList, Stack<FormattableString> currentApiInvocationChain)
        {
            var finalChain = currentApiInvocationChain.ToList();
            finalChain.Reverse();
            apiInvocationChainList.Add(finalChain);
        }

        private IEnumerable<FormattableString> MockParameterValues2(IReadOnlyList<Parameter> parameters, Func<Parameter, FormattableString> parameterSelector, bool useAllParameters)
        {
            if (parameters.Count == 0)
                yield break;

            for (int i = 0; i < parameters.Count; i++)
            {
                var parameter = parameters[i];
                // skip last parameter if it is optional and it is CancellationToken or RequestContext
                if (i == parameters.Count - 1 && parameter.IsOptionalInSignature && (parameter.Type.Equals(typeof(CancellationToken)) || parameter.Type.Equals(typeof(RequestContext))))
                    continue;

                if (useAllParameters || parameter.DefaultValue == null)
                    yield return parameterSelector(parameter);
            }
        }

        private string MockParameterValues(IReadOnlyList<Parameter> parameters, Func<Parameter, string> parameterSelector, bool allParameters)
        {
            if (parameters.Count == 0)
            {
                return string.Empty;
            }

            var parameterValues = new List<string>(parameters.Count);
            for (int i = 0; i < parameters.Count; i++)
            {
                //skip last param if its optional and cancellation token or request context
                if (i == parameters.Count - 1 && parameters[i].IsOptionalInSignature && (parameters[i].Type.Equals(typeof(CancellationToken)) || parameters[i].Type.Equals(typeof(RequestContext))))
                    continue;

                if (allParameters || parameters[i].DefaultValue == null)
                {
                    parameterValues.Add(parameterSelector(parameters[i]));
                }
            }
            return string.Join(", ", parameterValues);
        }

        private string MockConvenienceParameterValue(Parameter parameter)
        {
            if (parameter.RequestLocation == RequestLocation.Body)
            {
                return $"{parameter.Name}";
            }

            return MockParameterValue(parameter);
        }

        private FormattableString MockParameterValue2(Parameter parameter)
        {
            if (parameter.RequestLocation == RequestLocation.Body)
            {
                return $"{typeof(RequestContent)}.{nameof(RequestContent.Create)}(data)";
            }

            if (parameter.DefaultValue is { } defaultValue)
            {
                if (defaultValue.IsNewInstanceSentinel && defaultValue.Type.IsValueType)
                {
                    return $"default";
                }

                if (defaultValue.Value is not null)
                {
                    if (defaultValue.Type.EqualsIgnoreNullable(typeof(string)))
                    {
                        return $"\"{defaultValue.Value}\"";
                    }
                    var value = JsonSerializer.Serialize(defaultValue.Value);
                    return $"{value}";
                }
            }

            return MockFrameworkTypeParameterValue(parameter.Name, parameter.Type);
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
                        return $"\"{defaultValue.Value}\"";
                    }
                    return JsonSerializer.Serialize(defaultValue.Value);
                }
            }
            return MockParameterTypeValue(parameter.Name, parameter.Type);
        }

        private FormattableString MockFrameworkTypeParameterValue(string parameterName, CSharpType parameterType)
        {
            if (parameterType.IsFrameworkType)
            {
                var type = parameterType.FrameworkType;

                // Refer to TypeFactory.cs as how number type is created
                if (type == typeof(long) || type == typeof(int))
                {
                    return $"1234";
                }

                if (type == typeof(float))
                {
                    return $"3.14f";
                }

                if (type == typeof(decimal) || type == typeof(double))
                {
                    return $"3.14";
                }

                if (type == typeof(string))
                {
                    return $"\"<{parameterName}>\"";
                }

                if (type == typeof(bool))
                {
                    return $"true";
                }

                if (type == typeof(DateTimeOffset))
                {
                    return $"{typeof(DateTimeOffset)}.{nameof(DateTimeOffset.UtcNow)}";
                }

                if (type == typeof(DateTime))
                {
                    return $"{typeof(DateTime)}.{nameof(DateTime.UtcNow)}";
                }

                if (type == typeof(TimeSpan))
                {
                    return $"new {typeof(TimeSpan)}(1, 2, 3)";
                }

                if (type == typeof(MatchConditions))
                {
                    return $"new {typeof(MatchConditions)} {{ {nameof(MatchConditions.IfMatch)} = new {typeof(ETag)}({"<YOUR_ETAG>":L}) }}";
                }

                if (type == typeof(Guid))
                {
                    return $"{typeof(Guid)}.{nameof(Guid.NewGuid)}()";
                }

                if (type == typeof(Uri))
                {
                    return $"new {typeof(Uri)}({"http://localhost:3000":L})";
                }

                if (type == typeof(WaitUntil))
                {
                    // use `Completed`, since we will not generate `operation.WaitForCompletion()` afterwards
                    return $"{nameof(WaitUntil)}.{nameof(WaitUntil.Completed)}";
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
                    var elementType = parameterType.Arguments.Single();
                    return $"new {elementType}[]{{{MockFrameworkTypeParameterValue(parameterName, elementType)}}}";
                }

                if (type == typeof(IDictionary<,>))
                {
                    var valueType = parameterType.Arguments[1];
                    var dictionaryType = TypeFactory.GetImplementationType(parameterType);
                    return $"new {dictionaryType}{{ \"<test>\" = {MockFrameworkTypeParameterValue(parameterName, valueType)} }}";
                }

                if (type == typeof(BinaryData))
                {
                    return $"{typeof(BinaryData)}.{nameof(BinaryData.FromString)}({"<your binary data content>":L})";
                }

                if (type == typeof(RequestContext))
                {
                    return $"new {typeof(RequestContext)}()";
                }

                if (type == typeof(JsonElement))
                {
                    return $"new {typeof(JsonElement)}()";
                }

                if (type == typeof(object))
                {
                    return $"new {typeof(object)}()";
                }
            }

            return $"null"; // some unknown found
        }

        private string MockParameterTypeValue(string parameterName, CSharpType parameterType)
        {
            if (parameterType.IsFrameworkType)
            {
                var type = parameterType.FrameworkType;

                // Refer to TypeFactory.cs as how number type is created
                if (type == typeof(long) || type == typeof(int))
                {
                    return "1234";
                }

                if (type == typeof(float))
                {
                    return "3.14f";
                }

                if (type == typeof(decimal) || type == typeof(double))
                {
                    return "3.14";
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
                    return "new MatchConditions { IfMatch = new ETag(\"<YOUR_ETAG>\") }";
                }

                if (type == typeof(Guid))
                {
                    return "Guid.NewGuid()";
                }

                if (type == typeof(Uri))
                {
                    return "new Uri(\"http://localhost:3000\")";
                }

                if (type == typeof(WaitUntil))
                {
                    // use `Completed`, since we will not generate `operation.WaitForCompletion()` afterwards
                    return $"{nameof(WaitUntil)}.{nameof(WaitUntil.Completed)}";
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

                if (type == typeof(BinaryData))
                {
                    return $"BinaryData.FromString(\"<your binary data content>\")";
                }

                if (type == typeof(RequestContext))
                {
                    return $"new RequestContext()";
                }

                if (type == typeof(JsonElement))
                {
                    return $"new JsonElement()";
                }

                if (type == typeof(object))
                {
                    return $"new object()";
                }
            }

            return "null"; // some unknown found
        }

        private void ComposeRequestContent(CodeWriter writer, bool useAllParameters, InputType requestBodyType)
        {
            writer.Append($"var data = ");
            ComposeRequestContent(writer, useAllParameters, requestBodyType, null, new HashSet<InputModelType>());
            writer.LineRaw(";");

            writer.Line();
        }

        private void ComposeBodyParameter(bool composeAll, Parameter bodyParameter, StringBuilder builder)
        {
            // var <parameterName> = {value_expression};
            builder.Append($"var {bodyParameter.Name} = ");
            builder.Append(ComposeCSharpType(composeAll, bodyParameter.Type, null, 0, true, new HashSet<ObjectType>()));
            builder.AppendLine(";");
        }

        private CodeWriter ComposeRequestContent(CodeWriter writer, bool useAllProperties, InputType inputType, string? propertyDescription, HashSet<InputModelType> visitedModels) => inputType switch
        {
            InputListType listType => ComposeArrayRequestContent(writer, useAllProperties, listType.ElementType, visitedModels),
            InputDictionaryType dictionaryType => ComposeDictionaryRequestContent(writer, useAllProperties, dictionaryType.ValueType, visitedModels),
            InputEnumType enumType => writer.Literal(enumType.AllowedValues.First().Value),
            InputPrimitiveType primitiveType => primitiveType.Kind switch
            {
                InputTypeKind.Stream => writer.Append($"{typeof(File)}.{nameof(File.OpenRead)}({"<filePath>":L})"),
                InputTypeKind.Boolean => writer.Literal(true),
                InputTypeKind.Date => writer.Literal("2022-05-10"),
                InputTypeKind.DateTime => writer.Literal("2022-05-10T14:57:31.2311892-04:00"),
                InputTypeKind.DateTimeISO8601 => writer.Literal("2022-05-10T18:57:31.2311892Z"),
                InputTypeKind.DateTimeRFC1123 => writer.Literal("Tue, 10 May 2022 18:57:31 GMT"),
                InputTypeKind.DateTimeRFC3339 => writer.Literal("2022-05-10T18:57:31.2311892Z"),
                InputTypeKind.DateTimeRFC7231 => writer.Literal("Tue, 10 May 2022 18:57:31 GMT"),
                InputTypeKind.DateTimeUnix => writer.Literal("1652209051"),
                InputTypeKind.Float32 => writer.Literal(123.45f),
                InputTypeKind.Float64 => writer.Literal(123.45d),
                InputTypeKind.Float128 => writer.Literal(123.45m),
                InputTypeKind.Guid => writer.Literal("73f411fe-4f43-4b4b-9cbd-6828d8f4cf9a"),
                InputTypeKind.Int32 => writer.Literal(1234),
                InputTypeKind.Int64 => writer.Literal(1234L),
                InputTypeKind.String => string.IsNullOrWhiteSpace(propertyDescription) ? writer.Literal("<String>") : writer.Literal($"<{propertyDescription}>"),
                InputTypeKind.DurationISO8601 => writer.Literal("PT1H23M45S"),
                InputTypeKind.DurationConstant => writer.Literal("01:23:45"),
                InputTypeKind.Time => writer.Literal("01:23:45"),
                InputTypeKind.Uri => writer.Literal("http://localhost:3000"),
                _ => writer.AppendRaw("new {}"),
            },
            InputLiteralType literalType => writer.Literal(literalType.Value),
            InputModelType modelType => ComposeModelRequestContent(writer, useAllProperties, modelType, visitedModels),
            _ => writer.AppendRaw("new {}"),
        };

        private string ComposeCSharpType(bool allProperties, CSharpType type, string? propertyDescription, int indent, bool includeCollectionInitialization, HashSet<ObjectType> visitedModels) => type switch
        {
            _ when TypeFactory.IsIEnumerableOfT(type) => ComposeArrayCSharpType(allProperties, type.Arguments.Single(), indent, includeCollectionInitialization, visitedModels), // IEnumerable<T> is guaranteed to have one and only one generic parameter
            _ when TypeFactory.IsReadWriteList(type) => ComposeArrayCSharpType(allProperties, type.Arguments.Single(), indent, includeCollectionInitialization, visitedModels), // IList<T> is guaranteed to have one and only one generic parameter
            _ when TypeFactory.IsReadWriteDictionary(type) => ComposeDictionaryCSharpType(allProperties, type.Arguments[0], type.Arguments[1], indent, includeCollectionInitialization, visitedModels), // IDictionary<K, V> is guaranteed to have two generic parameters
            { IsFrameworkType: true } => MockParameterTypeValue(propertyDescription ?? "null", type),
            { IsFrameworkType: false, Implementation: ObjectType objectType } => ComposeObjectType(allProperties, objectType, indent, visitedModels),
            { IsFrameworkType: false, Implementation: EnumType enumType } => $"{enumType.Type.Name}.{enumType.Values.First().Declaration.Name}",
            _ => "null",
        };

        private CodeWriter ComposeArrayRequestContent(CodeWriter writer, bool useAllProperties, InputType elementType, HashSet<InputModelType> visitedModels)
        {
            /* GENERATED CODE PATTERN
             * new[] {
             *     {element_expression}
             * }
             * or
             * new[] {}
             */

            writer.Append($"new[] ");
            using (writer.Scope($"", newLine: false))
            {
                ComposeRequestContent(writer, useAllProperties, elementType, null, visitedModels);
                writer.Line();
            }

            return writer;
        }

        private string ComposeArrayCSharpType(bool allProperties, CSharpType elementType, int indent, bool includeCollectionInitialization, HashSet<ObjectType> visitedModels)
        {
            /* GENERATED CODE PATTERN
             * new <TypeName>[] {
             *     {element_expression}
             * }
             * or
             * Array.Empty<TypeName>()
             */

            var elementName = elementType.ConvertParamNameForCode();
            if (elementName == "IList")
            {
                elementName = $"{elementType.Arguments[0].Name}[]";
            }
            if (elementName == "IDictionary")
            {
                elementName = $"Dictionary<string,{elementType.Arguments[1].Name}>";
            }

            var elementExpr = ComposeCSharpType(allProperties, elementType, null, indent + 4, includeCollectionInitialization, visitedModels);
            if (elementExpr == string.Empty)
            {
                return includeCollectionInitialization ? $"Array.Empty<{elementName}>()" : "{}";
            }

            var builder = new StringBuilder();
            builder.AppendLine(includeCollectionInitialization ? $"new {elementName}[] " : "");
            using (Scope("", indent, builder))
            {
                builder.Append(' ', indent + 4).Append(elementExpr).AppendLine();
            }
            return builder.ToString();
        }

        private CodeWriter ComposeDictionaryRequestContent(CodeWriter writer, bool useAllProperties, InputType elementType, HashSet<InputModelType> visitedModels)
        {
            /* GENERATED CODE PATTERN
             * new {
             *     key = {value_expression},
             * }
             * or
             * new {}
             */
            using (writer.Scope($"new ", newLine: false))
            {
                writer.Append($"key = ");
                ComposeRequestContent(writer, useAllProperties, elementType, null, visitedModels);
            }
            return writer;
        }

        private string ComposeDictionaryCSharpType(bool allProperties, CSharpType keyType, CSharpType valueType, int indent, bool includeCollectionInitialization, HashSet<ObjectType> visitedModels)
        {
            /* GENERATED CODE PATTERN
             * new Dictionary<{keyType}, {valueType}>{
             *     [key] = {value_expression},
             * }
             * or
             * new Dictionary<{keyType}, {valueType}>()
             */
            var valueExpr = ComposeCSharpType(allProperties, valueType, null, indent + 4, includeCollectionInitialization, visitedModels);
            var keyExpr = keyType.Equals(typeof(int)) ? "0" : "\"key\""; //handle dictionary with int key
            if (valueExpr == string.Empty)
            {
                return includeCollectionInitialization ? $"new Dictionary<{keyType.ConvertParamNameForCode()}, {valueType.ConvertParamNameForCode()}>()" : "{}";
            }

            var builder = new StringBuilder();
            builder.AppendLine(includeCollectionInitialization ? $"new Dictionary<{keyType.ConvertParamNameForCode()}, {valueType.ConvertParamNameForCode()}>" : "");
            using (Scope("", indent, builder))
            {
                builder.Append(' ', indent + 4).AppendLine($"[{keyExpr}] = {valueExpr},");
            }
            return builder.ToString();
        }

        private CodeWriter ComposeModelRequestContent(CodeWriter writer, bool useAllProperties, InputModelType model, HashSet<InputModelType> visitedModels)
        {
            visitedModels.Add(model);

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
                if (useAllProperties)
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
                return writer.Append($"new {{}}");
            }

            // remove references to my stack
            _ = properties.RemoveAll(p =>
                visitedModels.Contains(p.Type) ||
                (p.Type is InputListType listType && visitedModels.Contains(listType.ElementType)) ||
                (p.Type is InputDictionaryType dictionaryType && visitedModels.Contains(dictionaryType.ValueType)));

            using (writer.Scope($"new ", newLine: false))
            {
                foreach (var property in properties)
                {
                    writer.Append($"{FixKeyWords(property.SerializedName)} = ");
                    if (property.IsDiscriminator)
                    {
                        writer.Literal(concreteModel.DiscriminatorValue ?? "");
                    }
                    else
                    {
                        ComposeRequestContent(writer, useAllProperties, property.Type, property.SerializedName, visitedModels);
                    }
                    writer.AppendRaw(",");
                }
            }

            return writer;
        }

        private string ComposeObjectType(bool allProperties, ObjectType model, int indent, HashSet<ObjectType> visitedModels)
        {
            if (visitedModels.Contains(model))
                return string.Empty;

            visitedModels.Add(model);

            if (model.Discriminator != null && model.Discriminator.Implementations.Length > 0)
            {
                model = model.Discriminator.Implementations.Where(i => !i.Type.IsFrameworkType && i.Type.Implementation is ObjectType).Select(i => (i.Type.Implementation as ObjectType)!).First();
            }

            /* GENERATED CODE PATTERN
                     * new <ModelName>(parameterInCtor1, parameterInCtor2) {
                     *     propNotInCtor1 = {value_expression},
                     *     propNotInCtor2 = {value_expression},
                     *     ...
                     * }
                     */
            // TODO -- rewrite this logic to use CodeWriterExtensions.WriteInitialization when we migrate to use CodeWriter. The WriteInitialization method will make the logic here a lot simpler
            var builder = new StringBuilder();
            var concreteModel = GetConcreteChildModel(model);
            var ctor = model.InitializationConstructor;
            // write the ctor
            var parameterExpressions = new List<string>();
            foreach (var parameter in ctor.Signature.Parameters)
            {
                var parameterExpr = ComposeCSharpType(allProperties, parameter.Type, parameter.Name, indent, true, visitedModels);
                parameterExpressions.Add(parameterExpr);
            }
            builder.Append($"new {model.Type.Name}(")
                .Append(string.Join(", ", parameterExpressions))
                .Append(")");

            // find other properties
            if (allProperties)
            {
                // get all properties on this model, and then only keep those do not have an initializer on the ctor, which means they are not covered by the signature of the ctor
                var propertiesToWrite = model.EnumerateHierarchy().SelectMany(model => model.Properties).Distinct()
                    .Where(p => p.Declaration.Accessibility == "public" && ctor.FindParameterByInitializedProperty(p) == null && IsPropertyAssignable(p));

                var propertyExpressions = new List<string>();
                foreach (var property in propertiesToWrite)
                {
                    var propertyExpr = ComposeCSharpType(allProperties, property.Declaration.Type, property.Declaration.Name, indent + 4, false, visitedModels);
                    if (propertyExpr != string.Empty)
                    {
                        propertyExpressions.Add($"{property.Declaration.Name} = {propertyExpr},");
                    }
                }

                if (propertyExpressions.Any())
                {
                    builder.AppendLine();
                    using (Scope("", indent, builder))
                    {
                        foreach (var propertyExpr in propertyExpressions)
                        {
                            builder.Append(' ', indent + 4).AppendLine(propertyExpr);
                        }
                    }
                }
            }

            return builder.ToString();
        }

        private static bool IsPropertyAssignable(ObjectTypeProperty property)
            => TypeFactory.IsReadWriteDictionary(property.Declaration.Type) || TypeFactory.IsReadWriteList(property.Declaration.Type) || !property.IsReadOnly;

        private string FixKeyWords(string serializedName)
        {
            // TODO -- this is incorrect, we should never change the property name here otherwise the serialized request content is wrong
            // if the name changed after calling this method, we should use a dictionary instead of using anonymous object
            var result = serializedName.Replace('-', '_').Replace(".", string.Empty);
            return SyntaxFacts.GetKeywordKind(result) == SyntaxKind.None ? result : $"@{result}";
        }

        private void ComposeGetClientCodes(CodeWriter writer)
        {
            var clientConstructor = ClientInvocationChain[0];
            if (clientConstructor.Parameters.Any(p => p.Type.EqualsIgnoreNullable(KeyAuthType)))
            {
                writer.Line($"{typeof(AzureKeyCredential)} credential = new {typeof(AzureKeyCredential)}({"<key>":L});");
            }
            else if (clientConstructor.Parameters.Any(p => p.Type.EqualsIgnoreNullable(TokenAuthType)))
            {
                // we cannot use typeof(DefaultAzureCredential) here because autorest.csharp does not use `Azure.Identity` as a dependency
                writer.UseNamespace("Azure.Identity");
                writer.Line($"{typeof(TokenCredential)} credential = new DefaultAzureCredential();");
            }

            if (clientConstructor.Parameters.Any(p => p.Type.EqualsIgnoreNullable(UriType)))
            {
                writer.Line($"{typeof(Uri)} endpoint = new {typeof(Uri)}(\"<{GetEndpoint()}>\");");
            }

            writer.Append($"{_client.Type} client = new {ClientInvocationChain[0].Name}({MockClientConstructorParameterValues(ClientInvocationChain[0].Parameters)})");

            for (int i = 1; i < ClientInvocationChain.Count; i++)
            {
                var factoryMethod = ClientInvocationChain[i];
                writer.Append($".{factoryMethod.Name}({MockParameterValues(factoryMethod.Parameters, MockParameterValue, true)})");
            }
            writer.LineRaw(";");

            writer.Line();
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
            callChain.Push(client.GetEffectiveCtor()!);

            return callChain.ToList();
        }

        private string GetFactoryMethodCode(MethodSignatureBase factoryMethod)
        {
            return $".{factoryMethod.Name}({MockParameterValues(factoryMethod.Parameters, MockParameterValue, true)})";
        }

        private static string GetEndpoint()
        {
            // TODO: is there a way to compose a data plane endpoint from swagger?
            return "https://my-service.azure.com";
        }

        // TODO -- the model.DerivedModels is not properly contains the derived models now.
        private static InputModelType GetConcreteChildModel(InputModelType model)
            => model.DerivedModels.Any() ? model.DerivedModels[0] : model;

        private static ObjectType GetConcreteChildModel(ObjectType model)
        {
            if (!model.Declaration.IsAbstract || model.Discriminator is not { } discriminator || !discriminator.Implementations.Any())
                return model;

            var nonAbstractType = discriminator.Implementations.Select(impl => impl.Type).First(type => type.TryCast<ObjectType>(out var objectType) && !objectType.Declaration.IsAbstract);
            return (ObjectType)nonAbstractType.Implementation; // we selected this type by asserting it is ObjectType therefore this will never fail
        }

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

        private static void ConsoleWriteLine(CodeWriter writer, FormattableString content)
        {
            writer.Line($"{typeof(Console)}.{nameof(Console.WriteLine)}({content});");
        }

        private void WriteTestMethodName(string methodName, bool useAllParameters, bool isAsync, bool isConvenienceMethod, StringBuilder builder)
        {
            builder.Append("<code>");
            builder.Append(GetTestMethodName(methodName, useAllParameters, isAsync, isConvenienceMethod));
            builder.Append("</code>");
        }

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

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using Azure;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Output.Builders;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;
using Azure.Core;
using System.Xml.Schema;

namespace AutoRest.CSharp.Generation.Writers
{
    internal class LowLevelExampleComposer
    {
        private static readonly CSharpType UriType = new CSharpType(typeof(Uri));
        private static readonly CSharpType KeyAuthType = KnownParameters.KeyAuth.Type;
        private static readonly CSharpType TokenAuthType = KnownParameters.TokenAuth.Type;

        private string ClientTypeName { get; init; }
        private BuildContext<LowLevelOutputLibrary> Context { get; init; }
        private IReadOnlyList<MethodSignatureBase> ClientInvocationChain { get; init; }


        public LowLevelExampleComposer(LowLevelClient client, BuildContext<LowLevelOutputLibrary> context)
        {
            ClientTypeName = client.Type.Name;
            Context = context;
            ClientInvocationChain = GetClientInvocationChain(client);
        }

        public FormattableString Compose(LowLevelClientMethod clientMethod, bool async)
        {
            var methodSignature = clientMethod.Signature.WithAsync(async);
            var operationSchema = clientMethod.OperationSchemas;

            var builder = new StringBuilder();

            if (HasNoCustomInput(methodSignature.Parameters)) // client.GetAllItems(RequestContext context = null)
            {
                ComposeExampleWithoutParameter(clientMethod, methodSignature.Name, async, true, builder);
            }
            else if (HasOptionalInputValue(methodSignature.Parameters, operationSchema.RequestBodySchema))
            {
                if (AreAllParametersOptional(methodSignature.Parameters))
                {
                    ComposeExampleWithoutParameter(clientMethod, methodSignature.Name, async, false, builder);
                }
                else if (operationSchema.RequestBodySchema != null && HasRequiredAndWritablePropertyFromTop(operationSchema.RequestBodySchema))
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

        private bool HasNoCustomInput(IReadOnlyList<Parameter> parameters)
        {
            return !parameters.Any(p => p.Type.Name != nameof(RequestContext)); // `RequestContext = null` is excluded
        }

        private bool HasNonBodyCustomParameter(IReadOnlyList<Parameter> parameters)
        {
            return parameters.Any(p => p.RequestLocation != RequestLocation.Body && p.Type.Name != nameof(RequestContext));// RequestContext is excluded
        }

        private void ComposeExampleWithoutRequestContent(LowLevelClientMethod clientMethod, string methodName, bool async, StringBuilder builder)
        {
            var hasNonBodyParameter = HasNonBodyCustomParameter(clientMethod.Signature.Parameters);
            builder.AppendLine($"This sample shows how to call {methodName}{(hasNonBodyParameter ? " with required parameters" : "")}{(clientMethod.OperationSchemas.ResponseBodySchema != null ? " and parse the result" : "")}.");
            ComposeCodeSnippet(clientMethod, methodName, async, false, builder);
        }

        private void ComposeExampleWithRequiredParameters(LowLevelClientMethod clientMethod, string methodName, bool async, StringBuilder builder)
        {
            builder.AppendLine($"This sample shows how to call {methodName} with required {GenerateParameterAndRequestContentDescription(clientMethod.Signature.Parameters)}{(clientMethod.OperationSchemas.ResponseBodySchema != null ? " and parse the result" : "")}.");
            ComposeCodeSnippet(clientMethod, methodName, async, true, builder);
        }

        private bool AreAllParametersOptional(IReadOnlyList<Parameter> parameters)
        {
            return !parameters.Any(p => p.DefaultValue == null);
        }

        /// <summary>
        /// Check top level properties of the given schema, return true if a required and writable property is found.
        /// </summary>
        /// <param name="schema"></param>
        /// <returns></returns>
        private bool HasRequiredAndWritablePropertyFromTop(Schema schema)
        {
            switch (schema)
            {
                case OrSchema o:
                    foreach (Schema s in o.AnyOf)
                    {
                        if (HasRequiredAndWritablePropertyFromTop(s))
                        {
                            return true;
                        }
                    }
                    return false;
                case XorSchema o:
                    foreach (Schema s in o.OneOf)
                    {
                        if (HasRequiredAndWritablePropertyFromTop(s))
                        {
                            return true;
                        }
                    }
                    return false;
                case ObjectSchema o:
                    // We must also include any properties introduced by our parent chain.
                    // Try to get the concrete child type for polymorphism
                    foreach (ObjectSchema s in GetAllSchemaInherited(GetConcreteChildType(o)))
                    {
                        foreach (Property prop in s.Properties)
                        {
                            if (prop.IsRequired && !prop.IsReadOnly)
                            {
                                return true;
                            }
                        }
                    }
                    return false;
            }

            return true;
        }

        private bool HasOptionalInputValue(IReadOnlyList<Parameter> parameters, Schema? requestSchema)
        {
            foreach (var parameter in parameters.Where(p => p.Type.Name != nameof(RequestContext))) // exlucde RequestContext
            {
                if (parameter.DefaultValue != null)
                {
                    return true;
                }
            }

            if (requestSchema != null && HasOptionalAndWritableProperty(requestSchema!))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Check if there is any optional and wriable property in the given schema hierarchy.
        /// </summary>
        /// <param name="schema"></param>
        /// <returns></returns>
        private bool HasOptionalAndWritableProperty(Schema schema)
        {
            // Visit each schema in the graph and for object schemas, check if any property is optional
            var visitedSchema = new HashSet<Schema>();
            var schemasToExplore = new Queue<Schema>(new[] { schema });

            while (schemasToExplore.Any())
            {
                Schema toExplore = schemasToExplore.Dequeue();

                if (visitedSchema.Contains(toExplore))
                {
                    continue;
                }

                switch (toExplore)
                {
                    case OrSchema o:
                        foreach (Schema s in o.AnyOf)
                        {
                            schemasToExplore.Enqueue(s);
                        }
                        break;
                    case XorSchema o:
                        foreach (Schema s in o.OneOf)
                        {
                            schemasToExplore.Enqueue(s);
                        }
                        break;
                    case ObjectSchema o:
                        // We must also include any properties introduced by our parent chain.
                        // Try to get the concrete child type for polymorphism
                        foreach (ObjectSchema s in GetAllSchemaInherited(GetConcreteChildType(o)))
                        {
                            foreach (Property prop in s.Properties)
                            {
                                if (!prop.IsRequired && !prop.IsReadOnly)
                                {
                                    return true;
                                }
                                schemasToExplore.Enqueue(prop.Schema);
                            }
                        }
                        break;
                }
                visitedSchema.Add(toExplore);
            }

            return false;
        }

        private void ComposeExampleWithParametersAndRequestContent(LowLevelClientMethod clientMethod, string methodName, bool async, bool allParameters, StringBuilder builder)
        {
            builder.AppendLine($"This sample shows how to call {methodName} with {(allParameters ? "all" : "required")} {GenerateParameterAndRequestContentDescription(clientMethod.Signature.Parameters)}{(clientMethod.OperationSchemas.ResponseBodySchema != null ? ", and how to parse the result" : "")}.");
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
            builder.AppendLine($"This sample shows how to call {methodName}{(clientMethod.OperationSchemas.ResponseBodySchema != null ? " and parse the result" : "")}.");
            ComposeCodeSnippet(clientMethod, methodName, async, allParameters, builder);
        }

        private void ComposeCodeSnippet(LowLevelClientMethod clientMethod, string methodName, bool async, bool allParameters, StringBuilder builder)
        {
            builder.AppendLine("<code><![CDATA[");
            ComposeGetClientCodes(builder);
            builder.AppendLine();
            if (clientMethod.OperationSchemas.RequestBodySchema != null)
            {
                ComposeRequestContent(allParameters, clientMethod.OperationSchemas.RequestBodySchema!, builder);
                builder.AppendLine();
            }

            if (clientMethod.IsLongRunning)
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
                ComposeParsingPageableResponseCodes((ObjectSchema)clientMethod.OperationSchemas.ResponseBodySchema!, clientMethod.PagingInfo!.ItemName, allParameters, builder);
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

            if (clientMethod.OperationSchemas.ResponseBodySchema == null)
            {
                builder.AppendLine($"var response = {(async ? "await " : "")}operation.WaitForCompletionResponse{(async ? "Async" : "")}();");
                builder.AppendLine("Console.WriteLine(response.Status)");
            }
            else
            {
                builder.AppendLine($"BinaryData data = {(async ? "await " : "")}operation.WaitForCompletion{(async ? "Async" : "")}();");
                ComposeParsingLongRunningResponseCodes(allParameters, clientMethod.OperationSchemas.ResponseBodySchema, builder);
            }
        }

        private void ComposeParsingLongRunningResponseCodes(bool allProperties, Schema responseSchema, StringBuilder builder)
        {
            if (responseSchema is BinarySchema binarySchema)
            {
                using (Scope("using(Stream outFileStream = File.OpenWrite(\"<filePath>\")", 0, builder, true))
                {
                    builder.AppendLine("    data.ToStream().CopyTo(outFileStream);");
                }
                return;
            }

            var apiInvocationChainList = new List<IReadOnlyList<string>>();
            ComposeResponseParsingCode(allProperties, responseSchema, apiInvocationChainList, new Stack<string>(new[] { "result" }), new HashSet<Schema>() { responseSchema });
            var parsingCodes = new List<string>(apiInvocationChainList.Count + 1);

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
                ComposeParsingPageableResponseCodes((ObjectSchema)clientMethod.OperationSchemas.ResponseBodySchema!, clientMethod.PagingInfo!.ItemName, allParameters, builder);
            }
        }

        private void ComposeParsingPageableResponseCodes(ObjectSchema responseSchema, string pagingItemName, bool allProperties, StringBuilder builder)
        {
            foreach (var property in responseSchema.Properties)
            {
                if (property.SerializedName == pagingItemName && property.Schema is ArraySchema itemArraySchema)
                {
                    var apiInvocationChainList = new List<IReadOnlyList<string>>();
                    ComposeResponseParsingCode(allProperties, itemArraySchema.ElementType, apiInvocationChainList, new Stack<string>(new[] { "result" }), new HashSet<Schema>() { responseSchema });
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
            if (clientMethod.OperationSchemas.ResponseBodySchema != null)
            {
                ComposeParsingNormalResponseCodes(allParameters, clientMethod.OperationSchemas.ResponseBodySchema, builder);
            }
            else
            {
                builder.AppendLine("Console.WriteLine(response.Status);");
            }
        }

        private void ComposeParsingNormalResponseCodes(bool allProperties, Schema responseSchema, StringBuilder builder)
        {
            if (responseSchema is BinarySchema binarySchema)
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
            ComposeResponseParsingCode(allProperties, responseSchema, apiInvocationChainList, new Stack<string>(new[] { "result" }), new HashSet<Schema>() { responseSchema });
            var parsingCodes = new List<string>(apiInvocationChainList.Count + 1);

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

        private void ComposeResponseParsingCode(bool allProperties, Schema schema, List<IReadOnlyList<string>> apiInvocationChainList, Stack<string> currentAPIInvocationChain, HashSet<Schema> visitedSchema)
        {
            switch (schema)
            {
                case ArraySchema a:
                    // {parentOp}[0]
                    if (visitedSchema.Contains(a.ElementType))
                    {
                        return;
                    }
                    var parentOp = currentAPIInvocationChain.Pop();
                    currentAPIInvocationChain.Push($"{parentOp}[0]");
                    ComposeResponseParsingCode(allProperties, a.ElementType, apiInvocationChainList, currentAPIInvocationChain, visitedSchema);
                    return;
                case DictionarySchema d:
                    // .GetProperty("<test>")
                    if (visitedSchema.Contains(d.ElementType))
                    {
                        return;
                    }
                    currentAPIInvocationChain.Push("GetProperty(\"<test>\")");
                    ComposeResponseParsingCode(allProperties, d.ElementType, apiInvocationChainList, currentAPIInvocationChain, visitedSchema);
                    currentAPIInvocationChain.Pop();
                    return;
                case OrSchema o:
                    foreach (Schema s in o.AnyOf)
                    {
                        if (visitedSchema.Contains(s))
                        {
                            return;
                        }
                        ComposeResponseParsingCode(allProperties, s, apiInvocationChainList, currentAPIInvocationChain, visitedSchema);
                    }
                    return;
                case XorSchema o:
                    foreach (Schema s in o.OneOf)
                    {
                        if (visitedSchema.Contains(s))
                        {
                            return;
                        }
                        ComposeResponseParsingCode(allProperties, s, apiInvocationChainList, currentAPIInvocationChain, visitedSchema);
                    }
                    return;
                case ObjectSchema o:
                    // We must also include any properties introduced by our parent chain.
                    foreach (ObjectSchema s in GetAllSchemaInherited(o))
                    {
                        if (!s.Properties.Any())
                        {
                            continue;
                        }

                        var propertiesToExplore = s.Properties;
                        if (!allProperties)
                        {
                            propertiesToExplore = s.Properties.Where(p => p.IsRequired).ToArray();
                        }

                        if (propertiesToExplore.Count() == 0) // if you have a required property, but its child properties are all optional
                        {
                            // return the object
                            AddAPIInvocationChainResult(apiInvocationChainList, currentAPIInvocationChain);
                            return;
                        }

                        foreach (Property prop in propertiesToExplore)
                        {
                            if (visitedSchema.Contains(prop.Schema))
                            {
                                continue;
                            }
                            // .GetProperty("{property_name}")
                            visitedSchema.Add(prop.Schema);
                            currentAPIInvocationChain.Push($"GetProperty(\"{prop.SerializedName}\")");
                            ComposeResponseParsingCode(allProperties, prop.Schema, apiInvocationChainList, currentAPIInvocationChain, visitedSchema);
                            currentAPIInvocationChain.Pop();
                            visitedSchema.Remove(prop.Schema);
                        }
                    }
                    return;
            }
            // primitive types, return
            AddAPIInvocationChainResult(apiInvocationChainList, currentAPIInvocationChain);
        }

        private void AddAPIInvocationChainResult(List<IReadOnlyList<string>> apiInvocationChainList, Stack<string> currentAPIInvocationChain)
        {
            var finalChain = currentAPIInvocationChain.ToList();
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

        private void ComposeRequestContent(bool composeAll, Schema requestBodySchema, StringBuilder builder)
        {
            // var data = {value_expression};
            builder.Append("var data = ");
            builder.Append(ComposeRequestContent(composeAll, requestBodySchema, 0, new HashSet<Schema>()));
            builder.AppendLine(";");
        }

        private string ComposeRequestContent(bool allProperties, Schema schema, int indent, HashSet<Schema> visitedSchema)
        {
            if (visitedSchema.Contains(schema))
            {
                return "";
            }

            switch (schema)
            {
                case ArraySchema a:
                    /* GENERATED CODE PATTERN
                     * new[] {
                     *     {element_expression}
                     * }
                     * or
                     * new[] {}
                     */
                    var elementExpr = ComposeRequestContent(allProperties, a.ElementType, indent + 4, visitedSchema);
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
                case DictionarySchema d:
                    /* GENERATED CODE PATTERN
                     * new {
                     *     key = {value_expression},
                     * }
                     * or
                     * new {}
                     */
                    var valueExpr = ComposeRequestContent(allProperties, d.ElementType, indent + 4, visitedSchema);
                    if (valueExpr == "")
                    {
                        return "new {}";
                    }

                    builder = new StringBuilder();
                    using (Scope("new ", indent, builder))
                    {
                        builder.Append(' ', indent + 4).AppendLine($"key = {valueExpr},");
                    }
                    return builder.ToString();
                case OrSchema or:
                    foreach (var o in or.AnyOf)
                    {
                        if (!visitedSchema.Contains(o))
                        {
                            return ComposeRequestContent(allProperties, o, indent, visitedSchema);
                        }
                    }
                    return "";
                case XorSchema xor:
                    foreach (var o in xor.OneOf)
                    {
                        if (!visitedSchema.Contains(o))
                        {
                            return ComposeRequestContent(allProperties, o, indent, visitedSchema);
                        }
                    }
                    return "";
                case ObjectSchema obj:
                    /* GENERATED CODE PATTERN
                     * new {
                     *     prop1 = {value_expression},
                     *     prop2 = {value_expression},
                     *     ...
                     * }
                     * or
                     * new {}
                     */
                    var properties = new List<Property>();
                    // We must also include any properties introduced by our parent chain.
                    // Try to get the concrete child type for polymorphism
                    var concreteObj = GetConcreteChildType(obj);
                    foreach (ObjectSchema s in GetAllSchemaInherited(concreteObj))
                    {
                        if (allProperties)
                        {
                            properties.AddRange(s.Properties.Where(p => !p.IsReadOnly));
                        }
                        else
                        {
                            properties.AddRange(s.Properties.Where(p => p.IsRequired && !p.IsReadOnly));
                        }
                    }

                    if (!properties.Any())
                    {
                        return "new {}";
                    }

                    visitedSchema.Add(obj);
                    var propertyExpressions = new List<string>();
                    foreach (Property p in properties)
                    {
                        string propertyValueExpr = "";
                        if (p.IsDiscriminator == true)
                        {
                            propertyValueExpr = MockDiscriminatorValue(concreteObj.DiscriminatorValue!, p.Schema);
                        }
                        else
                        {
                            propertyValueExpr = ComposeRequestContent(allProperties, p.Schema, indent + 4, visitedSchema);

                        }

                        if (propertyValueExpr != "")
                        {
                            var propertyExprBuilder = new StringBuilder();
                            propertyExprBuilder.Append(' ', indent + 4).Append($"{p.SerializedName} = {propertyValueExpr},");
                            propertyExpressions.Add(propertyExprBuilder.ToString());
                        }
                    }
                    visitedSchema.Remove(obj);

                    if (propertyExpressions.Count == 0)
                    {
                        return "new {}";
                    }

                    builder = new StringBuilder();
                    using (Scope("new ", indent, builder))
                    {
                        foreach (var expr in propertyExpressions)
                        {
                            builder.AppendLine(expr);
                        }
                    }
                    return builder.ToString();
                case AnySchema a:
                    return $"\"<{a.DefaultValue ?? a.Name}>\"";
                case BooleanSchema b:
                    return $"{(b.DefaultValue ?? "true")}";
                case NumberSchema n:
                    return $"{(n.DefaultValue ?? "1234")}";
                case StringSchema s:
                    return $"\"<{(s.DefaultValue ?? s.Name)}>\"";
                case CharSchema c:
                    return $"\"<{(c.DefaultValue ?? "t")}>\"";
                case DateSchema d:
                    return $"\"<{(d.DefaultValue ?? "2022-05-10")}>\"";
                case TimeSchema t:
                    return $"\"<{(t.DefaultValue ?? "14:57:31.2311892")}>\"";
                case DateTimeSchema dt:
                    return $"\"<{(dt.DefaultValue ?? "2022-05-10T14:57:31.2311892-04:00")}>\"";
                case DurationSchema d:
                    // duration format is P1H2M3S
                    return $"\"<{(d.DefaultValue ?? "(1.)3:45:67")}>\"";
                case ChoiceSchema c:
                    return $"\"<{(c.DefaultValue ?? c.Choices.First().Value)}>\"";
                case ConstantSchema c:
                    if (c.Value == null)
                    {
                        return ComposeRequestContent(allProperties, c.ValueType, indent, visitedSchema);
                    }
                    return (c.ValueType is StringSchema ? $"\"<{c.Value.Value}>\"" : $"{c.Value.Value}");
                case SealedChoiceSchema c:
                    return $"\"<{(c.DefaultValue ?? c.Choices.First().Value)}>\"";
                case UuidSchema u:
                    return $"\"<{(u.DefaultValue ?? "73f411fe-4f43-4b4b-9cbd-6828d8f4cf9a")}>\"";
                case UriSchema u:
                    return $"\"<{(u.DefaultValue ?? "http://my-account-name.azure.com")}>\"";
                case BinarySchema b:
                    return "File.OpenRead(\"<filePath>\")";
                default:
                    // unknown type
                    return $"{(schema.DefaultValue ?? "new {}")}";
            }
        }

        private string MockDiscriminatorValue(string value, Schema discriminatorPropertySchema)
        {
            switch (discriminatorPropertySchema)
            {

                case BooleanSchema b:
                case NumberSchema n:
                    return value;
                case ConstantSchema c:
                    return MockDiscriminatorValue(value, c.ValueType);
                default:
                    return $"\"{value}\"";
            }
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

        private static ObjectSchema GetConcreteChildType(ObjectSchema o)
        {
            return (ObjectSchema)(o.Children != null && o.Children.All.Count > 0 ? o.Children!.All.First() : o);
        }

        private static IEnumerable<ObjectSchema> GetAllSchemaInherited(ObjectSchema o)
        {
            return (o.Parents?.All ?? Array.Empty<ComplexSchema>()).Concat(new ComplexSchema[] { o }).OfType<ObjectSchema>();
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
    }
}

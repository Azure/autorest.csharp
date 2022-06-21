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

namespace AutoRest.CSharp.Generation.Writers
{
    internal class LowLevelExampleComposer
    {
        private CodeWriter Writer { get; }
        private string ClientTypeName { get; }
        private BuildContext<LowLevelOutputLibrary> Context { get; }

        public LowLevelExampleComposer(CodeWriter writer, string clientTypeName, BuildContext<LowLevelOutputLibrary> context)
        {
            Writer = writer;
            ClientTypeName = clientTypeName;
            Context = context;
        }

        public void Write(LowLevelClientMethod clientMethod, bool async)
        {
            var methodSignature = clientMethod.Signature.WithAsync(async);
            var operationSchema = clientMethod.OperationSchemas;

            var examples = new List<string>();

            if (HasNoCustomInput(methodSignature.Parameters))
            {
                examples.Add(GenerateExampleWithoutParameter(clientMethod, methodSignature.Name, async, true));
            }
            else if (HasOptionalInputValue(methodSignature.Parameters, operationSchema.RequestBodySchema))
            {
                if (AreAllParametersOptional(methodSignature.Parameters))
                {
                    examples.Add(GenerateExampleWithoutParameter(clientMethod, methodSignature.Name, async, false));
                }
                else if (operationSchema.RequestBodySchema != null && HasRequiredAndWritablePropertyFromTop(operationSchema.RequestBodySchema))
                {
                    examples.Add(GenerateExampleWithParametersAndRequestContent(clientMethod, methodSignature.Name, async, false));
                }
                else
                {
                    examples.Add(GenerateExampleWithoutRequestContent(clientMethod, methodSignature.Name, async));
                }
                examples.Add(GenerateExampleWithParametersAndRequestContent(clientMethod, methodSignature.Name, async, true));
            }
            else
            {
                examples.Add(GenerateExampleWithRequiredParameters(clientMethod, methodSignature.Name, async));
            }

            Writer.WriteXmlDocumentation("example", $"{string.Join(Environment.NewLine, examples)}");
        }

        private bool HasNoCustomInput(IReadOnlyList<Parameter> parameters)
        {
            return parameters.Count() <= 1; // `RequestContext = null` is excluded
        }

        private string GenerateExampleWithoutRequestContent(LowLevelClientMethod clientMethod, string methodName, bool async)
        {
            var builder = new StringBuilder();
            var hasParameter = clientMethod.Signature.Parameters.SkipLast(1).Any(p => p.RequestLocation != RequestLocation.Body);
            builder.AppendLine($"This sample shows how to call {methodName}{(hasParameter ? " with required parameters" : "")}{(clientMethod.OperationSchemas.ResponseBodySchema != null ? " and parse the result" : "")}.");
            // in this case, we print the codes of parsing all properties from response
            ComposeCodeSnippet(clientMethod, methodName, async, false, builder);
            return builder.ToString();
        }

        private string GenerateExampleWithRequiredParameters(LowLevelClientMethod clientMethod, string methodName, bool async)
        {
            var builder = new StringBuilder();
            builder.AppendLine($"This sample shows how to call {methodName} with required {GenerateParameterAndRequestContentDescription(clientMethod.Signature.Parameters)}{(clientMethod.OperationSchemas.ResponseBodySchema != null ? " and parse the result" : "")}.");
            // in this case, we print the codes of parsing all properties from response
            ComposeCodeSnippet(clientMethod, methodName, async, true, builder);
            return builder.ToString();
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
                    foreach (ObjectSchema s in GetAllSchemaInherited(o))
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
            foreach (var parameter in parameters.SkipLast(1)) // exlucde RequestContext
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
            var visitedSchema = new HashSet<string>();
            var schemasToExplore = new Queue<Schema>(new[] { schema });

            while (schemasToExplore.Any())
            {
                Schema toExplore = schemasToExplore.Dequeue();

                if (visitedSchema.Contains(toExplore.Name))
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
                        foreach (ObjectSchema s in GetAllSchemaInherited(o))
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
                visitedSchema.Add(toExplore.Name);
            }

            return false;
        }

        private string GenerateExampleWithParametersAndRequestContent(LowLevelClientMethod clientMethod, string methodName, bool async, bool allParameters)
        {
            var builder = new StringBuilder();
            builder.AppendLine($"This sample shows how to call {methodName} with {(allParameters ? "all" : "required")} {GenerateParameterAndRequestContentDescription(clientMethod.Signature.Parameters)}{(clientMethod.OperationSchemas.ResponseBodySchema != null ? ", and how to parse the result" : "")}.");
            ComposeCodeSnippet(clientMethod, methodName, async, allParameters, builder);
            return builder.ToString();
        }

        private string GenerateParameterAndRequestContentDescription(IReadOnlyList<Parameter> parameters)
        {
            var hasNonBodyParameter = parameters.Where(p => p.RequestLocation != RequestLocation.Body).Count() > 1;// RequestContent is excluded
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

        private string GenerateExampleWithoutParameter(LowLevelClientMethod clientMethod, string methodName, bool async, bool allParameters)
        {
            var builder = new StringBuilder();
            builder.AppendLine($"This sample shows how to call {methodName}{(clientMethod.OperationSchemas.ResponseBodySchema != null ? " and parse the result" : "")}.");
            ComposeCodeSnippet(clientMethod, methodName, async, allParameters, builder);
            return builder.ToString();
        }

        private void ComposeCodeSnippet(LowLevelClientMethod clientMethod, string methodName, bool async, bool allParameters, StringBuilder builder)
        {
            builder.AppendLine("<code><![CDATA[");
            builder.AppendLine("var credential = new DefaultAzureCredential();");
            builder.AppendLine($"var endpoint = new Uri(\"<{GetEndpoint()}>\");");
            builder.AppendLine(ComposeGetClientCodes());
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
            // var operation = await client.{methodName}(...);
            //
            // var response = await operation.WaitForCompleteAsync();
            // await foreach (var data in response.Value)
            // {
            //     Console.WriteLine(data.ToString());
            // or
            //     JsonElement result = JsonDocument.Parse(data.ToStream()).RootElement;
            //     Console.WriteLine(result[.GetProperty(...)...].ToString());
            //     ...
            // }
            builder.AppendLine($"var operation = {(async ? "await " : "")}client.{methodName}({MockParameterValues(clientMethod.Signature.Parameters.SkipLast(1).ToList(), allParameters)});");
            builder.AppendLine();
            builder.AppendLine($"var response = {(async ? "await " : "")}operation.WaitForCompleteResponse{(async ? "Async" : "")}();");
            builder.AppendLine($"{(async ? "await " : "")}foreach (var data in response.Value)");
            builder.AppendLine("{");
            ComposeParsingPageableResponseCodes(allParameters, clientMethod.OperationSchemas.ResponseBodySchema!, builder);
            builder.AppendLine("}");
        }

        private void ComposeHandleLongRunningResponseCode(LowLevelClientMethod clientMethod, string methodName, bool async, bool allParameters, StringBuilder builder)
        {
            // var operation = await client.{methodName}(...);
            //
            // await operation.WaitForCompleteResponseAsync();
            // or
            // BinaryData data = await operation.WaitForCompleteAsync();
            // JsonElement result = JsonDocument.Parse(data.ToStream()).RootElement;
            // Console.WriteLine(result[.GetProperty(...)...].ToString());
            // ...
            // }
            builder.AppendLine($"var operation = {(async ? "await " : "")}client.{methodName}({MockParameterValues(clientMethod.Signature.Parameters.SkipLast(1).ToList(), allParameters)});");
            builder.AppendLine();

            if (clientMethod.OperationSchemas.ResponseBodySchema == null)
            {
                builder.AppendLine($"{(async ? "await " : "")}operation.WaitForCompleteResponse{(async ? "Async" : "")}();");
            }
            else
            {
                builder.AppendLine($"BinaryData data = {(async ? "await " : "")}operation.WaitForComplete{(async ? "Async" : "")}();");
                ComposeParsingLongRunningResponseCodes(allParameters, clientMethod.OperationSchemas.ResponseBodySchema, builder);
            }
        }

        private void ComposeParsingLongRunningResponseCodes(bool allProperties, Schema responseSchema, StringBuilder builder)
        {
            if (responseSchema is BinarySchema binarySchema)
            {
                builder.AppendLine($"using(Stream outFileStream = File.OpenWrite(\"<{responseSchema.Name}.data>\")");
                builder.AppendLine("{");
                builder.AppendLine("    data.ToStream().CopyTo(outFileStream);");
                builder.AppendLine("}");
                return;
            }

            var apiInvocationChainList = new List<IReadOnlyList<string>>();
            ComposeResponseParsingCode(allProperties, responseSchema, apiInvocationChainList, new Stack<string>(), new HashSet<string>() { responseSchema.Name });
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
                    builder.Append("Console.WriteLine(result.");
                    builder.Append(string.Join(".", apiInvocationChain));
                    builder.AppendLine($"{(apiInvocationChain.Count > 0 ? "." : "")}ToString());");
                }
            }
        }

        private void ComposeHandlePageableResponseCode(LowLevelClientMethod clientMethod, string methodName, bool async, bool allParameters, StringBuilder builder)
        {
            // await foreach (var data in client.{methodName}(...))
            // {
            //     Console.WriteLine(data.ToString());
            // or
            //     JsonElement result = JsonDocument.Parse(data.ToStream()).RootElement;
            //     Console.WriteLine(result[.GetProperty(...)...].ToString());
            //     ...
            // }
            builder.AppendLine($"{(async ? "await " : "")}foreach (var data in client.{methodName}({MockParameterValues(clientMethod.Signature.Parameters.SkipLast(1).ToList(), allParameters)}))");
            builder.AppendLine("{");
            ComposeParsingPageableResponseCodes(allParameters, clientMethod.OperationSchemas.ResponseBodySchema!, builder);
            builder.AppendLine("}");
        }

        private void ComposeParsingPageableResponseCodes(bool allProperties, Schema responseSchema, StringBuilder builder)
        {
            var apiInvocationChainList = new List<IReadOnlyList<string>>();
            ComposeResponseParsingCode(allProperties, responseSchema, apiInvocationChainList, new Stack<string>(), new HashSet<string>() { responseSchema.Name });
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
                    builder.Append("Console.WriteLine(result.");
                    builder.Append(string.Join(".", apiInvocationChain));
                    builder.AppendLine($"{(apiInvocationChain.Count > 0 ? "." : "")}ToString());");
                }
            }
        }

        private void ComposeHandleNormalResponseCode(LowLevelClientMethod clientMethod, string methodName, bool async, bool allParameters, StringBuilder builder)
        {
            // Respones response = await client.{methodName}(...);
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
                builder.AppendLine("if (response.ContentStream != null)");
                builder.AppendLine("{");
                builder.AppendLine($"    using(Stream outFileStream = File.OpenWrite(\"<{responseSchema.Name}.data>\")");
                builder.AppendLine("    {");
                builder.AppendLine("        response.ContentStream.CopyTo(outFileStream);");
                builder.AppendLine("    }");
                builder.AppendLine("}");
                return;
            }

            var apiInvocationChainList = new List<IReadOnlyList<string>>();
            ComposeResponseParsingCode(allProperties, responseSchema, apiInvocationChainList, new Stack<string>(), new HashSet<string>() { responseSchema.Name });
            var parsingCodes = new List<string>(apiInvocationChainList.Count + 1);

            builder.AppendLine();

            if (apiInvocationChainList.Count == 0)
            {
                builder.AppendLine($"Console.WriteLine(response.ToString());");
            }
            else
            {
                builder.AppendLine($"JsonElement result = JsonDocument.Parse(GetContentFromResponse(response)).RootElement;");
                foreach (var apiInvocationChain in apiInvocationChainList)
                {
                    builder.Append("Console.WriteLine(result.");
                    builder.Append(string.Join(".", apiInvocationChain));
                    builder.AppendLine($"{(apiInvocationChain.Count > 0 ? "." : "")}ToString());");
                }
            }
        }

        private void ComposeResponseParsingCode(bool allProperties, Schema schema, List<IReadOnlyList<string>> apiInvocationChainList, Stack<string> currentAPIInvocationChain, HashSet<string> visitedSchema)
        {
            switch (schema)
            {
                case ArraySchema a:
                    // .Item[0]
                    if (visitedSchema.Contains(a.ElementType.Name))
                    {
                        return;
                    }
                    currentAPIInvocationChain.Push("Item[0]");
                    ComposeResponseParsingCode(allProperties, a.ElementType, apiInvocationChainList, currentAPIInvocationChain, visitedSchema);
                    currentAPIInvocationChain.Pop();
                    return;
                case DictionarySchema d:
                    // .GetProperty("<test>")
                    if (visitedSchema.Contains(d.ElementType.Name))
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
                        if (visitedSchema.Contains(s.Name))
                        {
                            return;
                        }
                        ComposeResponseParsingCode(allProperties, s, apiInvocationChainList, currentAPIInvocationChain, visitedSchema);
                    }
                    return;
                case XorSchema o:
                    foreach (Schema s in o.OneOf)
                    {
                        if (visitedSchema.Contains(s.Name))
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
                            if (visitedSchema.Contains(prop.Schema.Name))
                            {
                                continue;
                            }
                            // .GetProperty("{property_name}")
                            visitedSchema.Add(prop.Schema.Name);
                            currentAPIInvocationChain.Push($"GetProperty(\"{prop.SerializedName}\")");
                            ComposeResponseParsingCode(allProperties, prop.Schema, apiInvocationChainList, currentAPIInvocationChain, visitedSchema);
                            currentAPIInvocationChain.Pop();
                            visitedSchema.Remove(prop.Schema.Name);
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
            // var data = {value_expressioin};
            builder.Append("var data = ");
            ComposeRequestContent(composeAll, requestBodySchema, builder, 0, new HashSet<string>());
            builder.AppendLine(";");
        }

        private void ComposeRequestContent(bool allProperties, Schema schema, StringBuilder builder, int indent, HashSet<string> visitedSchema)
        {
            if (visitedSchema.Contains(schema.Name))
            {
                return;
            }

            switch (schema)
            {
                case ArraySchema a:
                    // new[] {
                    //     {value_expression}
                    // }
                    builder.AppendLine("new[] {");
                    builder.Append(' ', indent + 4);
                    ComposeRequestContent(allProperties, a.ElementType, builder, indent + 4, visitedSchema);
                    builder.AppendLine();
                    builder.Append(' ', indent).Append("}");
                    return;
                case DictionarySchema d:
                    // new {
                    //     key = {value_expression},
                    // }
                    builder.AppendLine("new {");
                    builder.Append(' ', indent + 4).Append("key = ");
                    ComposeRequestContent(allProperties, d.ElementType, builder, indent + 4, visitedSchema);
                    builder.AppendLine(",");
                    builder.Append(' ', indent).Append("}");
                    return;
                case OrSchema or:
                    foreach (var o in or.AnyOf)
                    {
                        if (!visitedSchema.Contains(o.Name))
                        {
                            ComposeRequestContent(allProperties, or.AnyOf.First(), builder, indent, visitedSchema);
                            break;
                        }
                    }
                    return;
                case XorSchema xor:
                    foreach (var o in xor.OneOf)
                    {
                        if (!visitedSchema.Contains(o.Name))
                        {
                            ComposeRequestContent(allProperties, xor.OneOf.First(), builder, indent, visitedSchema);
                            break;
                        }
                    }
                    return;
                case ObjectSchema obj:
                    // new {
                    //     prop1 = {value_expression},
                    //     prop2 = {value_expression},
                    //     ...
                    // }
                    var properties = new List<Property>();
                    // We must also include any properties introduced by our parent chain.
                    foreach (ObjectSchema s in GetAllSchemaInherited(obj))
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

                    if (properties.Any())
                    {
                        visitedSchema.Add(obj.Name);
                        builder.AppendLine("new {");
                        foreach (Property p in properties)
                        {
                            builder.Append(' ', indent + 4).Append($"{p.SerializedName} = ");
                            ComposeRequestContent(allProperties, p.Schema, builder, indent + 4, visitedSchema);
                            builder.AppendLine(",");
                        }
                        builder.Append(' ', indent).Append("}");
                        visitedSchema.Remove(obj.Name);
                    }
                    else
                    {
                        builder.Append("new {}");
                    }
                    return;
                case AnySchema a:
                    builder.Append($"\"<{a.DefaultValue ?? a.Name}>\"");
                    return;
                case BooleanSchema b:
                    builder.Append($"{(b.DefaultValue ?? "true")}");
                    return;
                case NumberSchema n:
                    builder.Append($"{(n.DefaultValue ?? "1234")}");
                    return;
                case StringSchema s:
                    builder.Append($"\"<{(s.DefaultValue ?? s.Name)}>\"");
                    return;
                case CharSchema c:
                    builder.Append($"\"<{(c.DefaultValue ?? "t")}>\"");
                    return;
                case DateSchema d:
                    builder.Append($"\"<{(d.DefaultValue ?? "2022-05-10")}>\"");
                    return;
                case TimeSchema t:
                    builder.Append($"\"<{(t.DefaultValue ?? "14:57:31.2311892")}>\"");
                    return;
                case DateTimeSchema dt:
                    builder.Append($"\"<{(dt.DefaultValue ?? "2022-05-10T14:57:31.2311892-04:00")}>\"");
                    return;
                case DurationSchema d:
                    // duration format is P1H2M3S
                    builder.Append($"\"<{(d.DefaultValue ?? "(1.)3:45:67")}>\"");
                    return;
                case ChoiceSchema c:
                    builder.Append($"\"<{(c.DefaultValue ?? c.Choices.First().Value)}>\"");
                    return;
                case SealedChoiceSchema c:
                    builder.Append($"\"<{(c.DefaultValue ?? c.Choices.First().Value)}>\"");
                    return;
                case UuidSchema u:
                    builder.Append($"\"<{(u.DefaultValue ?? "73f411fe-4f43-4b4b-9cbd-6828d8f4cf9a")}>\"");
                    return;
                case UriSchema u:
                    builder.Append($"\"<{(u.DefaultValue ?? "http://my-account-name.azure.com")}>\"");
                    return;
                case BinarySchema b:
                    builder.Append($"File.OpenRead(\"<{b.Name}.data>\")");
                    return;
                default:
                    // unknown type
                    builder.Append($"{(schema.DefaultValue ?? "new {}")}");
                    return;
            }
        }

        private string ComposeGetClientCodes()
        {
            var invocationChain = GetClientInvocationChain();

            var code = $"var client = new {invocationChain[0].Name}(endpoint, credential)"; // TODO: webpubsub constructor

            if (invocationChain.Count > 1)
            {
                for (int i = 1; i < invocationChain.Count; i++)
                {
                    var factoryMethod = invocationChain[i];
                    code += GetFactoryMethodCode(factoryMethod);
                }
            }
            return code + ";";
        }

        /// <summary>
        /// Get the methods to be called to get the client, it should be like `Client(...).GetXXClient(..).GetYYClient(..)`.
        /// It's composed of a constructor of non-subclient and a optional list of subclient factory methods.
        /// </summary>
        /// <returns></returns>
        private IReadOnlyList<MethodSignatureBase> GetClientInvocationChain()
        {
            var chain = new List<MethodSignatureBase>();
            foreach (var client in Context.Library.RestClients.Where(r => !r.IsSubClient))
            {
                if (client.Type.Name == ClientTypeName)
                {
                    chain.Add(client.PrimaryConstructors.OrderBy(c => c.Parameters.Count).First());
                    return chain;
                }

                var childInvocation = GetSubClientInvocationChain(client.SubClients, client.SubClientFactoryMethods);
                if (childInvocation.Count > 0)
                {
                    chain.Add(client.PrimaryConstructors.OrderBy(c => c.Parameters.Count).First());
                    chain.AddRange(childInvocation);
                    return chain;
                }
            }
            return chain;
        }

        private IReadOnlyList<MethodSignatureBase> GetSubClientInvocationChain(IReadOnlyList<LowLevelClient> subClients, IReadOnlyList<LowLevelSubClientFactoryMethod> subClientFactoryMethods)
        {
            var chain = new List<MethodSignatureBase>();
            foreach (var factoryMethod in subClientFactoryMethods)
            {
                if (factoryMethod.ClientTypeName == ClientTypeName)
                {
                    chain.Add(factoryMethod.Signature);
                    return chain;
                }
            }

            foreach (var subClient in subClients)
            {
                var childInvocation = GetSubClientInvocationChain(subClient.SubClients, subClient.SubClientFactoryMethods);
                if (childInvocation.Count > 0)
                {
                    var factoryMethod = subClientFactoryMethods.First(m => m.ClientTypeName == subClient.Type.Name);
                    chain.Add(factoryMethod.Signature);
                    chain.AddRange(childInvocation);
                    return chain;
                }
            }
            return chain;
        }

        private string GetFactoryMethodCode(MethodSignatureBase factoryMethod)
        {
            return $".{factoryMethod.Name}({MockParameterValues(factoryMethod.Parameters, true)})";
        }

        private static string GetEndpoint()
        {
            // TODO: is there a way to compose a data plane endpoint from swagger?
            return "https://my-account-name.azure.com";
        }

        private static IEnumerable<ObjectSchema> GetAllSchemaInherited(ObjectSchema o)
        {
            return (o.Parents?.All ?? Array.Empty<ComplexSchema>()).Concat(new ComplexSchema[] { o }).OfType<ObjectSchema>();
        }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.


using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Common.Output.Models;
using AutoRest.CSharp.Common.Output.Models.KnownValueExpressions;
using AutoRest.CSharp.Common.Output.Models.Statements;
using AutoRest.CSharp.Common.Output.Models.ValueExpressions;
using AutoRest.CSharp.Common.Output.Models.Types;
using AutoRest.CSharp.Output.Builders;
using AutoRest.CSharp.Output.Models.Serialization;
using AutoRest.CSharp.Output.Models.Serialization.Json;
using AutoRest.CSharp.Utilities;
using Azure;
using Azure.Core;
using static AutoRest.CSharp.Common.Output.Models.Snippets;

namespace AutoRest.CSharp.Generation.Writers
{
    internal class LowLevelExampleComposer
    {
        private static readonly CSharpType UriType = new CSharpType(typeof(Uri));
        private static readonly CSharpType KeyAuthType = KnownParameters.KeyAuth.Type;
        private static readonly CSharpType TokenAuthType = KnownParameters.TokenAuth.Type;

        private readonly LowLevelClient _client;
        private readonly TypeFactory _typeFactory;
        private IReadOnlyList<LowLevelClient> ClientInvocationChain { get; }

        public LowLevelExampleComposer(LowLevelClient client, TypeFactory typeFactory)
        {
            _client = client;
            _typeFactory = typeFactory;
            ClientInvocationChain = GetClientInvocationChain(client);
        }

        public FormattableString ComposeProtocol(RestClientOperationMethods operationMethods, MethodSignature signature, bool async)
        {
            //skip non public protocol methods
            if ((signature.Modifiers & MethodSignatureModifiers.Public) == 0)
                return $"";

            //skip obsolete protocol methods
            if (signature.Attributes.Any(a => a.Type.Equals(typeof(ObsoleteAttribute))))
                return $"";

            //skip suppressed protocol methods
            if (_client.IsMethodSuppressed(signature))
                return $"";

            //skip if there are no valid ctors
            if (!_client.IsSubClient && _client.GetEffectiveCtor() is null)
                return $"";

            var requestBodyType = operationMethods.RequestBodyType;
            var builder = new StringBuilder();

            if (HasNoCustomInput(signature.Parameters)) // client.GetAllItems(RequestContext context = null)
            {
                ComposeProtocolExampleWithoutParameter(operationMethods, signature, async, true, builder);
            }
            else if (HasOptionalInputValue(signature.Parameters, requestBodyType, out var requestModel))
            {
                if (signature.Parameters.All(p => p.IsOptionalInSignature))
                {
                    ComposeProtocolExampleWithoutParameter(operationMethods, signature, async, false, builder);
                }
                else if (requestBodyType != null && (requestModel == null || HasRequiredAndWritablePropertyFromTop(requestModel)))
                {
                    ComposeProtocolExampleWithParametersAndRequestContent(operationMethods, signature, async, false, builder);
                }
                else
                {
                    ComposeProtocolExampleWithoutRequestContent(operationMethods, signature, async, builder);
                }
                builder.AppendLine();
                ComposeProtocolExampleWithParametersAndRequestContent(operationMethods, signature, async, true, builder);
            }
            else
            {
                // client.GetAllItems(int a, RequestContext context = null)
                ComposeProtocolExampleWithRequiredParameters(operationMethods, signature, async, builder);
            }

            return $"{builder.ToString()}";
        }

        public FormattableString ComposeConvenience(MethodSignature signature, bool async)
        {
            // Skip deprecated
            if (signature.Attributes.Any(c => c.Type.Equals(typeof(ObsoleteAttribute))))
            {
                return $"";
            }

            // Skip with deprecated parameters
            if (signature.Parameters.Any(p => p.Type is {IsFrameworkType: false, Implementation: ModelTypeProvider {Deprecated: not null}}))
            {
                return $"";
            }

            //skip if not public
            if (!signature.Modifiers.HasFlag(MethodSignatureModifiers.Public))
                return $"";

            //skip if there are no valid ctors
            if (!_client.IsSubClient && _client.GetEffectiveCtor() is null)
                return $"";

            //skip suppressed convenience methods
            if (_client.IsMethodSuppressed(signature))
                return $"";

            signature = signature.WithAsync(async);

            var builder = new StringBuilder();
            if (HasNoCustomInput(signature.Parameters))
            {
                // client.GetAllItems(CancellationToken cancellationToken = default)
                builder.AppendLine($"This sample shows how to call {signature.Name}.");
            }
            else
            {
                // client.GetAllItems(int a, RequestContext context = null)
                builder.AppendLine($"This sample shows how to call {signature.Name} with required parameters.");
            }

            WriteCodeSnippet(builder, ComposeConvenienceMethodExample(signature, async));

            return $"{builder.ToString()}";
        }

        internal MethodBodyStatement ComposeConvenienceMethodExample(MethodSignature signature, bool async)
            => ComposeConvenienceCodeSnippet(signature, async).AsStatement();

        // `RequestContext = null` or `cancellationToken = default` is excluded
        private static bool HasNoCustomInput(IReadOnlyList<Parameter> parameters)
            => parameters.Count == 0 || (parameters.Count == 1 && (parameters[0].Equals(KnownParameters.RequestContext) || parameters[0].Equals(KnownParameters.CancellationTokenParameter)));

        // RequestContext is excluded
        private static bool HasNonBodyCustomParameter(IReadOnlyList<Parameter> parameters)
            => parameters.Any(p => p.RequestLocation != RequestLocation.Body && !p.Equals(KnownParameters.RequestContext));

        private void ComposeProtocolExampleWithoutRequestContent(RestClientOperationMethods operationMethods, MethodSignature signature, bool async, StringBuilder builder)
        {
            var hasNonBodyParameter = HasNonBodyCustomParameter(signature.Parameters);
            builder.AppendLine($"This sample shows how to call {signature.Name}{(hasNonBodyParameter ? " with required parameters" : "")}{(operationMethods.ResponseType is not null ? " and parse the result" : "")}.");
            ComposeProtocolWrappedCodeSnippet(operationMethods, signature, async, false, builder);
        }

        private void ComposeProtocolExampleWithRequiredParameters(RestClientOperationMethods operationMethods, MethodSignature signature, bool async, StringBuilder builder)
        {
            builder.AppendLine($"This sample shows how to call {signature.Name} with required {GenerateParameterAndRequestContentDescription(signature.Parameters)}{(operationMethods.ResponseType is not null ? " and parse the result" : "")}.");
            ComposeProtocolWrappedCodeSnippet(operationMethods, signature, async, true, builder);
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

        private void ComposeProtocolExampleWithParametersAndRequestContent(RestClientOperationMethods operationMethods, MethodSignature signature, bool async, bool allParameters, StringBuilder builder)
        {
            builder.AppendLine($"This sample shows how to call {signature.Name} with {(allParameters ? "all" : "required")} {GenerateParameterAndRequestContentDescription(signature.Parameters)}{(operationMethods.ResponseType is not null ? ", and how to parse the result" : "")}.");
            ComposeProtocolWrappedCodeSnippet(operationMethods, signature, async, allParameters, builder);
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

        private void ComposeProtocolExampleWithoutParameter(RestClientOperationMethods operationMethods, MethodSignature signature, bool async, bool allParameters, StringBuilder builder)
        {
            builder.AppendLine($"This sample shows how to call {signature.Name}{(operationMethods.ResponseType is not null ? " and parse the result" : "")}.");
            ComposeProtocolWrappedCodeSnippet(operationMethods, signature, async, allParameters, builder);
        }

        private void ComposeProtocolWrappedCodeSnippet(RestClientOperationMethods operationMethods, MethodSignature signature, bool async, bool allParameters, StringBuilder builder)
        {
            var statement = ComposeProtocolCodeSnippet(operationMethods, signature, allParameters, async).AsStatement();
            WriteCodeSnippet(builder, statement);
        }

        private static void WriteCodeSnippet(StringBuilder builder, MethodBodyStatement statement)
        {
            builder.AppendLine("<code><![CDATA[");

            var codeWriter = new CodeWriter(appendTypeNameOnly: true);
            codeWriter.WriteMethodBodyStatement(statement);
            var code = SamplesFormattingSyntaxRewriter.FormatCodeBlock(codeWriter.ToString(false));

            builder.Append(code);
            builder.Append("]]></code>");
        }

        private IEnumerable<MethodBodyStatement> ComposeConvenienceCodeSnippet(MethodSignature signature, bool async)
        {
            yield return ComposeGetClient(out var client);
            yield return EmptyLine;

            // get input parameters -- only body parameter is not initialized inline in the invocation, therefore we take out all the body parameters.
            var bodyArguments = new Dictionary<Parameter, ValueExpression>();
            foreach (var parameter in signature.Parameters.Where(p => p.RequestLocation == RequestLocation.Body))
            {
                yield return Var(parameter.Name, ComposeConvenienceCSharpTypeInstance(true, parameter.Type, null, true, new HashSet<ObjectType>()), out var bodyArgument);
                bodyArguments[parameter] = bodyArgument;
            }

            var arguments = signature.Parameters
                //skip last param if its optional and cancellation token or request context
                .Where((p, i) => i != signature.Parameters.Count - 1 || !p.IsOptionalInSignature || !p.Type.Equals(typeof(CancellationToken)))
                .Select(p => p.RequestLocation == RequestLocation.Body ? bodyArguments[p] : MockParameterValue(p))
                .ToList();

            var returnType = signature.ReturnType;

            if (returnType is null)
            {
                yield return ComposeConvenienceHandleNormalResponseCode(client, signature.Name, arguments, async);
            }
            else if (TypeFactory.IsOperationOfAsyncPageable(returnType) || TypeFactory.IsOperationOfPageable(returnType))
            {
                // do nothing, this never happen right now
            }
            else if (TypeFactory.IsOperation(returnType))
            {
                yield return ComposeConvenienceHandleLongRunningResponseCode(client, signature.Name, arguments, async);
            }
            else if (TypeFactory.IsAsyncPageable(returnType) || TypeFactory.IsPageable(returnType))
            {
                yield return ComposeConvenienceHandlePageableResponseCode(client, signature.Name, arguments, async);
            }
            else
            {
                yield return ComposeConvenienceHandleNormalResponseCode(client, signature.Name, arguments, async);
            }
        }

        internal IEnumerable<MethodBodyStatement> ComposeProtocolCodeSnippet(RestClientOperationMethods operationMethods, MethodSignature signature, bool allParameters, bool async)
        {
            yield return ComposeGetClient(out var client);
            yield return EmptyLine;

            ValueExpression? data = null;
            if (operationMethods.RequestBodyType != null)
            {
                yield return Var("data", ComposeProtocolCSharpTypeInstance(allParameters, GetTypeSerialization(operationMethods.RequestBodyType), null, new HashSet<ObjectType>()), out data);
                yield return EmptyLine;
            }

            var arguments = signature.Parameters
                //skip last param if its optional and cancellation token or request context
                .Where((p, i) => !(i == signature.Parameters.Count - 1 && p.IsOptionalInSignature && p.Type.Equals(typeof(RequestContext))))
                .Where(p => allParameters || !p.IsOptionalInSignature)
                .Select(p => p.RequestLocation == RequestLocation.Body ? RequestContentExpression.Create(data!) : MockParameterValue(p))
                .ToList();

            var responseType = operationMethods.ResponseType;
            var pageItemType = operationMethods.PageItemType;
            var isLongRunning = signature.ReturnType is not null && (TypeFactory.IsOperation(signature.ReturnType) || TypeFactory.IsTaskOfOperation(signature.ReturnType));
            if (isLongRunning)
            {
                if (pageItemType is not null)
                {
                    yield return ComposeProtocolHandleLongRunningPageableResponseCode(client, signature.Name, arguments, pageItemType, allParameters, async);
                }
                else
                {
                    yield return ComposeProtocolHandleLongRunningResponseCode(client, signature.Name, arguments, responseType, allParameters, async);
                }
            }
            else if (pageItemType is not null)
            {
                yield return ComposeProtocolHandlePageableResponseCode(client, signature.Name, arguments, pageItemType, allParameters, async);
            }
            else if (signature.ReturnType is {} returnType && (returnType.Equals(typeof(Response<bool>)) || returnType.Equals(typeof(Task<Response<bool>>))))
            {
                yield return ComposeProtocolHandleHeadAsBoolean(client, signature.Name, arguments, async);
            }
            else
            {
                yield return ComposeProtocolHandleNormalResponse(client, signature.Name, arguments, responseType, allParameters, async);
            }
        }

        private MethodBodyStatement ComposeProtocolHandleLongRunningPageableResponseCode(ValueExpression client, string methodName, IReadOnlyList<ValueExpression> arguments, CSharpType? conveniencePageItemType, bool allParameters, bool async)
        {
            if (conveniencePageItemType is null)
            {
                return new MethodBodyStatement();
            }

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

            return new[]
            {
                Var("operation", new OperationExpression(client.Invoke(methodName, arguments, async)), out var operation),
                EmptyLine,
                new ForeachStatement("item", operation.Value, async, out var binaryDataItem)
                {
                    ComposeParsingPageableResponse(new BinaryDataExpression(binaryDataItem), conveniencePageItemType, allParameters)
                }
            };
        }

        private MethodBodyStatement ComposeProtocolHandleLongRunningResponseCode(ValueExpression client, string methodName, IReadOnlyList<ValueExpression> arguments, CSharpType? operationValueType, bool allProperties, bool async)
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

            return new[]
            {
                Var("operation", new OperationExpression(client.Invoke(methodName, arguments, async)), out var operation),
                EmptyLine, operationValueType is null
                    ? InvokeConsoleWriteLine(operation.GetRawResponse().Status)
                    : new[]
                    {
                        Declare("responseData", new BinaryDataExpression(operation.Value), out var responseData),
                        ComposeParsingLongRunningResponse(responseData, operationValueType, allProperties)
                    }
            };
        }

        private MethodBodyStatement ComposeConvenienceHandleLongRunningResponseCode(ValueExpression client, string methodName, IReadOnlyList<ValueExpression> arguments, bool async)
        {
            /* GENERATED CODE PATTERN
             * var operation = await client.{methodName}(WaitUntil.Completed, ...);
             */
            return Var("operation", new InvokeInstanceMethodExpression(client, methodName, arguments, null, async), out _);
        }

        private MethodBodyStatement ComposeParsingLongRunningResponse(BinaryDataExpression responseData, CSharpType operationValueType, bool allProperties)
        {
            if (operationValueType.Equals(typeof(Stream)))
            {
                return new MethodBodyStatement[]
                {
                    new UsingDeclareVariableStatement(typeof(Stream), "outFileStream", InvokeFileOpenWrite(Literal("<filePath>")), out var outFileStream),
                    new InvokeInstanceMethodStatement(responseData.ToStream(), nameof(Stream.CopyTo), outFileStream)
                };
            }

            var declareElementStatement = Declare("result", JsonDocumentExpression.Parse(responseData.ToStream()).RootElement, out var result);

            var elementPropertiesStatements = ComposeResponseParsing(result, operationValueType, allProperties, new HashSet<CSharpType> { operationValueType });
            if (elementPropertiesStatements.Count == 0)
            {
                return InvokeConsoleWriteLine(responseData.InvokeToString());
            }

            return new[]
            {
                declareElementStatement,
                elementPropertiesStatements.AsStatement()
            };
        }

        private MethodBodyStatement ComposeProtocolHandlePageableResponseCode(ValueExpression client, string methodName, IReadOnlyList<ValueExpression> arguments, CSharpType conveniencePageItemType, bool allParameters, bool async)
        {
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

            return new ForeachStatement("item", client.Invoke(methodName, arguments, async), async, out var binaryDataItem)
            {
                ComposeParsingPageableResponse(new BinaryDataExpression(binaryDataItem), conveniencePageItemType, allParameters)
            };
        }

        private MethodBodyStatement ComposeConvenienceHandlePageableResponseCode(ValueExpression client, string methodName, IReadOnlyList<ValueExpression> arguments, bool async)
            => new ForeachStatement("item", new InvokeInstanceMethodExpression(client, methodName, arguments, null, async), async, out _);

        private MethodBodyStatement ComposeParsingPageableResponse(BinaryDataExpression item, CSharpType itemModelType, bool allProperties)
        {
            var declareElementStatement = Declare("result", JsonDocumentExpression.Parse(item.ToStream()).RootElement, out var result);
            var elementPropertiesStatements = ComposeResponseParsing(result, itemModelType, allProperties, new HashSet<CSharpType> { itemModelType });
            if (elementPropertiesStatements.Count == 0)
            {
                return InvokeConsoleWriteLine(item.InvokeToString());
            }

            return new[]
            {
                declareElementStatement,
                elementPropertiesStatements.AsStatement()
            };
        }

        private MethodBodyStatement ComposeProtocolHandleHeadAsBoolean(ValueExpression client, string methodName, IReadOnlyList<ValueExpression> arguments, bool async)
        {
            return new[]
            {
                new DeclareVariableStatement(typeof(Response<bool>), "response", client.Invoke(methodName, arguments, async), out var response),
                InvokeConsoleWriteLine(new ResponseExpression(response.Invoke(nameof(Response<bool>.GetRawResponse))).Status)
            };
        }

        private MethodBodyStatement ComposeProtocolHandleNormalResponse(ValueExpression client, string methodName, IReadOnlyList<ValueExpression> arguments, CSharpType? responseType, bool allProperties, bool async)
        {
            return new[]
            {
                Declare("response", new ResponseExpression(client.Invoke(methodName, arguments, async)), out var response),
                responseType is null
                    ? InvokeConsoleWriteLine(response.Status)
                    : ComposeParsingNormalResponseCodes(response, responseType, allProperties)
            };
        }

        private MethodBodyStatement ComposeConvenienceHandleNormalResponseCode(ValueExpression client, string methodName, IReadOnlyList<ValueExpression> arguments, bool async)
            => Var("result", client.Invoke(methodName, arguments, async), out _);

        private MethodBodyStatement ComposeParsingNormalResponseCodes(ResponseExpression response, CSharpType responseType, bool allProperties)
        {
            if (responseType.Equals(typeof(Stream)))
            {
                return new IfStatement(NotEqual(response.ContentStream, Null))
                {
                    new UsingDeclareVariableStatement(typeof(Stream), "outFileStream", InvokeFileOpenWrite(Literal("<filePath>")), out var outFileStream),
                    new InvokeInstanceMethodStatement(response.ContentStream, nameof(Stream.CopyTo), outFileStream)
                };
            }

            var declareResultStatement = Declare("result", JsonDocumentExpression.Parse(response.ContentStream).RootElement, out var result);
            var elementPropertiesStatements = ComposeResponseParsing(result, responseType, allProperties, new HashSet<CSharpType> { responseType });
            if (elementPropertiesStatements.Count == 0)
            {
                return new[]
                {
                    EmptyLine,
                    InvokeConsoleWriteLine(response.InvokeToString())
                };
            }

            return new[]
            {
                EmptyLine,
                declareResultStatement,
                elementPropertiesStatements.AsStatement()
            };
        }

        private IReadOnlyList<MethodBodyStatement> ComposeResponseParsing(JsonElementExpression jsonElement, CSharpType expectedJsonElementType, bool allProperties, HashSet<CSharpType> visitedTypes)
        {
            if (TypeFactory.IsList(expectedJsonElementType))
            {
                var elementType = expectedJsonElementType.Arguments[0];
                return !visitedTypes.Contains(elementType)
                    ? ComposeResponseParsing(jsonElement[0], elementType, allProperties, visitedTypes)
                    : Array.Empty<MethodBodyStatement>();
            }

            if (TypeFactory.IsDictionary(expectedJsonElementType))
            {
                var valueType = expectedJsonElementType.Arguments[1];
                return !visitedTypes.Contains(valueType)
                    ? ComposeResponseParsing(jsonElement.GetProperty("<test>"), valueType, allProperties, visitedTypes)
                    : Array.Empty<MethodBodyStatement>();
            }

            if (expectedJsonElementType is { IsFrameworkType: false, Implementation: {} implementation })
            {
                switch (implementation)
                {
                    case SerializableObjectType objectType: return ComposeResponseParsing(jsonElement, objectType, allProperties, visitedTypes);
                    case SystemObjectType objectType: return ComposeResponseParsing(jsonElement, objectType, allProperties, visitedTypes);
                }
            }

            return new[]{InvokeConsoleWriteLine(jsonElement.InvokeToString())};
        }

        private IReadOnlyList<MethodBodyStatement> ComposeResponseParsing(JsonElementExpression jsonElement, SystemObjectType systemObjectType, bool allProperties, HashSet<CSharpType> visitedTypes)
        {
            var propertiesToExplore = allProperties
                ? systemObjectType.Properties
                : systemObjectType.Properties.Where(p => p.IsRequired).ToArray();

            var statements = new List<MethodBodyStatement>();
            foreach (var property in propertiesToExplore)
            {
                var propertyType = property.ValueType;
                if (property.SchemaProperty is null || visitedTypes.Contains(propertyType))
                {
                    continue;
                }

                var propertyName = property.SchemaProperty.SerializedName;
                visitedTypes.Add(propertyType);
                statements.AddRange(ComposeResponseParsing(jsonElement.GetProperty(propertyName), propertyType, allProperties, visitedTypes));
                visitedTypes.Remove(propertyType);
            }

            return statements;
        }

        private IReadOnlyList<MethodBodyStatement> ComposeResponseParsing(JsonElementExpression jsonElement, SerializableObjectType model, bool allProperties, HashSet<CSharpType> visitedTypes)
        {
            var propertiesToExplore = allProperties
                ? model.JsonSerialization?.Properties
                : model.JsonSerialization?.Properties.Where(p => p.IsRequired).ToArray();

            if (propertiesToExplore is null || !propertiesToExplore.Any()) // if you have a required property, but its child properties are all optional
            {
                // return the object
                return new[] {InvokeConsoleWriteLine(jsonElement.InvokeToString())};
            }

            var statements = new List<MethodBodyStatement>();
            foreach (var propertySerialization in propertiesToExplore)
            {
                var propertyType = propertySerialization.ValueType;
                if (visitedTypes.Contains(propertyType))
                {
                    continue;
                }

                var propertyName = propertySerialization.SerializedName;
                visitedTypes.Add(propertyType);
                statements.AddRange(ComposeResponseParsing(jsonElement.GetProperty(propertyName), propertyType, allProperties, visitedTypes));
                visitedTypes.Remove(propertyType);
            }

            return statements;
        }

        private ValueExpression MockParameterValue(Parameter parameter)
        {
            if (parameter.DefaultValue == null)
            {
                return MockParameterTypeValue(parameter.Name, parameter.Type, null);
            }

            var defaultValue = parameter.DefaultValue.Value;
            if (defaultValue is { IsNewInstanceSentinel: true, Type.IsValueType: true })
            {
                return Default;
            }

            // skip null default value like "string a = null"
            if (defaultValue.Value == null)
            {
                return MockParameterTypeValue(parameter.Name, parameter.Type, null);
            }

            if (defaultValue.Type.IsFrameworkType && defaultValue.Type.FrameworkType == typeof(string))
            {
                return Literal(defaultValue.Value.ToString());
            }

            return new ConstantExpression(defaultValue);
        }

        private ValueExpression MockParameterTypeValue(string? parameterName, CSharpType parameterType, SerializationFormat? serializationFormat)
        {
            if (parameterType.IsFrameworkType)
            {
                var type = parameterType.FrameworkType;
                var format = serializationFormat?.ToFormatSpecifier();

                // Refer to TypeFactory.cs as how number type is created
                if (type == typeof(int))
                {
                    return Int(1234);
                }

                if (type == typeof(long))
                {
                    return Long(1234L);
                }

                if (type == typeof(float))
                {
                    return Float(3.14f);
                }

                if (type == typeof(decimal) || type == typeof(double))
                {
                    return Double(3.14);
                }

                if (type == typeof(string))
                {
                    return string.IsNullOrWhiteSpace(parameterName) ? Literal("<String>") : Literal($"<{parameterName}>");
                }

                if (type == typeof(bool))
                {
                    return Bool(true);
                }

                if (type == typeof(DateTimeOffset))
                {
                    return format is null
                        ? new MemberExpression(typeof(DateTimeOffset), nameof(DateTimeOffset.UtcNow))
                        : Literal(TypeFormatters.ToString(new DateTimeOffset(2022, 05, 10, 10, 14, 57, 31, TimeSpan.FromHours(-4)), format));
                }

                if (type == typeof(DateTime))
                {
                    return format is null
                        ? new MemberExpression(typeof(DateTime), nameof(DateTime.UtcNow))
                        : Literal(TypeFormatters.ToString(new DateTime(2022, 05, 10, 10, 14, 57, 31), format));
                }

                if (type == typeof(TimeSpan))
                {
                    return format is null
                        ? New.TimeSpan(1, 23, 45)
                        : Literal(TypeFormatters.ToString(new TimeSpan(1, 23, 45), format));
                }

                if (type == typeof(MatchConditions))
                {
                    return new FormattableStringToExpression($"new MatchConditions {{ IfMatch = new ETag(\"<YOUR_ETAG>\") }}");
                }

                if (type == typeof(Guid))
                {
                    return serializationFormat.HasValue
                        ? Literal("73f411fe-4f43-4b4b-9cbd-6828d8f4cf9a")
                        : InvokeGuidNewGuid();
                }

                if (type == typeof(Uri))
                {
                    return serializationFormat.HasValue
                        ? Literal("http://localhost:3000")
                        : New.Uri("http://localhost:3000");
                }

                if (type == typeof(WaitUntil))
                {
                    // use `Completed`, since we will not generate `operation.WaitForCompletion()` afterwards
                    return FrameworkEnumValue(WaitUntil.Completed);
                }

                if (type.IsEnum)
                {
                    return serializationFormat.HasValue
                        ? Literal(Enum.GetNames(type)[0])
                        : new MemberExpression(type, Enum.GetNames(type)[0]);
                }

                if (type == typeof(ContentType))
                {
                    return new MemberExpression(typeof(ContentType), nameof(ContentType.ApplicationOctetStream)); // stick to octect-stream?
                }

                if (type == typeof(IEnumerable<>))
                {
                    var elementType = parameterType.Arguments[0];
                    return New.Array(elementType, true, MockParameterTypeValue(parameterName, elementType, null));
                }

                if (type == typeof(IDictionary<,>))
                {
                    var valueType = parameterType.Arguments[1];
                    return New.Dictionary(typeof(string), valueType, (Literal("test"), MockParameterTypeValue(parameterName, valueType, null)));
                }

                if (type == typeof(BinaryData))
                {
                    return BinaryDataExpression.FromString(Literal("<your binary data content>"));
                }

                if (type == typeof(Stream))
                {
                    return InvokeFileOpenRead(Literal("<filePath>"));
                }

                if (type == typeof(JsonElement))
                {
                    return serializationFormat.HasValue
                        ? Literal("{}")
                        : Default;
                }

                if (type.GetConstructor(Type.EmptyTypes) is not null)
                {
                    return New.Instance(type);
                }
            }

            return Null; // some unknown found
        }

        private JsonSerialization GetTypeSerialization(InputType inputType)
        {
            var outputType = _typeFactory.CreateType(inputType);

            return inputType switch
            {
                InputListType listType => new JsonArraySerialization(TypeFactory.GetImplementationType(outputType), GetTypeSerialization(listType.ElementType), false),
                InputDictionaryType dictionaryType => new JsonDictionarySerialization(TypeFactory.GetImplementationType(outputType), GetTypeSerialization(dictionaryType.ValueType), false),
                _ => new JsonValueSerialization(outputType, SerializationBuilder.GetSerializationFormat(inputType), false)
            };
        }

        private ValueExpression ComposeConvenienceCSharpTypeInstance(bool allProperties, CSharpType type, string? propertyDescription, bool includeCollectionInitialization, HashSet<ObjectType> visitedModels) => type switch
        {
            _ when TypeFactory.IsList(type) => ComposeConvenienceArrayCSharpType(allProperties, type.Arguments.Single(), includeCollectionInitialization, visitedModels), // IList<T> is guaranteed to have one and only one generic parameter
            _ when TypeFactory.IsDictionary(type) => ComposeConvenienceDictionaryInstance(allProperties, type.Arguments[0], type.Arguments[1], includeCollectionInitialization, visitedModels), // IDictionary<K, V> is guaranteed to have two generic parameters
            { IsFrameworkType: true } => MockParameterTypeValue(propertyDescription, type, null),
            { Implementation: SerializableObjectType objectType } => ComposeObjectType(GetMostConcreteModel(objectType), allProperties, visitedModels),
            { Implementation: EnumType enumType } => EnumValue(enumType, enumType.Values.First()),
            _ => Null
        };


        private ValueExpression ComposeProtocolCSharpTypeInstance(bool allProperties, JsonSerialization? serialization, string? propertyDescription, HashSet<ObjectType> visitedModels) => serialization switch
        {
            JsonArraySerialization array => ComposeProtocolArrayCSharpType(allProperties, array, visitedModels),
            JsonDictionarySerialization dictionary => ComposeProtocolDictionaryInstance(allProperties, dictionary, visitedModels),
            JsonValueSerialization { Type.IsFrameworkType: true } value => MockParameterTypeValue(propertyDescription, value.Type, value.Format),
            JsonValueSerialization { Type.Implementation: SerializableObjectType model } => ComposeAnonymousObjectType(GetMostConcreteModel(model), allProperties, visitedModels),
            JsonValueSerialization { Type.Implementation: EnumType enumType } => new ConstantExpression(enumType.Values.First().Value),
            _ => Null
        };

        private ValueExpression ComposeConvenienceArrayCSharpType(bool allProperties, CSharpType elementType, bool includeCollectionInitialization, HashSet<ObjectType> visitedModels)
        {
            /* GENERATED CODE PATTERN
             * new <TypeName>[] {
             *     {element_expression}
             * }
             * or
             * Array.Empty<TypeName>()
             */
            if (IsVisitedModel(elementType, visitedModels))
            {
                return includeCollectionInitialization
                    ? New.Array(elementType)
                    : new ArrayInitializerExpression(null, false);
            }

            var arrayElement = ComposeConvenienceCSharpTypeInstance(allProperties, elementType, null, includeCollectionInitialization, visitedModels);
            return includeCollectionInitialization
                ? New.Array(elementType, false, arrayElement)
                : new ArrayInitializerExpression(new[]{arrayElement}, false);
        }

        private ValueExpression ComposeProtocolArrayCSharpType(bool allProperties, JsonArraySerialization serialization, HashSet<ObjectType> visitedModels)
        {
            /* GENERATED CODE PATTERN
             * new[] {
             *     {element_expression}
             * }
             */
            return New.Array(null, ComposeProtocolCSharpTypeInstance(allProperties, serialization.ValueSerialization, null, visitedModels));
        }

        private ValueExpression ComposeConvenienceDictionaryInstance(bool allProperties, CSharpType keyType, CSharpType valueType, bool includeCollectionInitialization, HashSet<ObjectType> visitedModels)
        {
            /* GENERATED CODE PATTERN
             * new Dictionary<{keyType}, {valueType}>{
             *     [key] = {value_expression},
             * }
             * or
             * new Dictionary<{keyType}, {valueType}>()
             */

            if (IsVisitedModel(valueType, visitedModels))
            {
                return includeCollectionInitialization
                    ? New.Dictionary(keyType, valueType)
                    : new DictionaryInitializerExpression();
            }

            var keyExpr = keyType.Equals(typeof(int)) ? Int(0) : Literal("key"); //handle dictionary with int key
            var valueExpr = ComposeConvenienceCSharpTypeInstance(allProperties, valueType, null, includeCollectionInitialization, visitedModels);
            return includeCollectionInitialization
                ? New.Dictionary(keyType, valueType, (keyExpr, valueExpr))
                : new DictionaryInitializerExpression(new[]{(keyExpr, valueExpr)});
        }

        private ValueExpression ComposeProtocolDictionaryInstance(bool allProperties, JsonDictionarySerialization serialization, HashSet<ObjectType> visitedModels)
        {
            /* GENERATED CODE PATTERN
             * new Dictionary<{keyType}, {valueType}>{
             *     [key] = {value_expression},
             * }
             * or
             * new Dictionary<{keyType}, {valueType}>()
             */

            var keyType = serialization.Type.Arguments[0];  // IDictionary<K, V> is guaranteed to have two generic parameters
            var valueType = serialization.Type.Arguments[1];

            var valueExpr = ComposeProtocolCSharpTypeInstance(allProperties, serialization.ValueSerialization, null, visitedModels);
            if (keyType.Equals(typeof(int))) //handle dictionary with int key
            {
                return New.Dictionary(keyType, valueType, (Int(0), valueExpr));
            }

            return New.Anonymous("key", valueExpr);
        }

        private static bool IsVisitedModel(JsonSerialization? serialization, IReadOnlySet<ObjectType> visitedModels) => serialization switch
        {
            JsonArraySerialization array => IsVisitedModel(array.ValueSerialization, visitedModels),
            JsonDictionarySerialization dictionary => IsVisitedModel(dictionary.ValueSerialization, visitedModels),
            JsonValueSerialization { Type.IsFrameworkType: false, Type.Implementation: SerializableObjectType model } => visitedModels.Contains(GetMostConcreteModel(model)),
            _ => false
        };

        private static bool IsVisitedModel(CSharpType valueType, IReadOnlySet<ObjectType> visitedModels)
            => valueType is { IsFrameworkType: false, Implementation: ObjectType objectType } && visitedModels.Contains(objectType);

        private ValueExpression ComposeObjectType(ObjectType model, bool allProperties, HashSet<ObjectType> visitedModels)
        {
            visitedModels.Add(model);
            if (model.Discriminator is { Implementations.Length: > 0 })
            {
                model = model.Discriminator.Implementations
                    .Where(i => i.Type is { IsFrameworkType: false })
                    .Select(i => i.Type.Implementation as ObjectType)
                    .WhereNotNull()
                    .First();
            }

            /* GENERATED CODE PATTERN
             * new <ModelName>(parameterInCtor1, parameterInCtor2)
             * {
             *     propNotInCtor1 = {value_expression},
             *     propNotInCtor2 = {value_expression},
             *     ...
             * }
             */

            var ctor = model.InitializationConstructor;
            // write the ctor

            var arguments = ctor.Signature.Parameters
                .Select(parameter => ComposeConvenienceCSharpTypeInstance(allProperties, parameter.Type, parameter.Name, true, visitedModels))
                .ToList();

            // find other properties
            var propertyExpressions = allProperties
                    // get all properties on this model, and then only keep those do not have an initializer on the ctor, which means they are not covered by the signature of the ctor
                ? model.EnumerateHierarchy()
                    .SelectMany(m => m.Properties).Distinct()
                    .Where(p => p.Declaration.Accessibility == "public" && ctor.FindParameterByInitializedProperty(p) == null && IsPropertyAssignable(p))
                    .Where(p => !IsVisitedModel(p.Declaration.Type, visitedModels))
                    .ToDictionary(p => p.Declaration.Name, p => ComposeConvenienceCSharpTypeInstance(allProperties, p.Declaration.Type, p.Declaration.Name, false, visitedModels))
                : null;

            visitedModels.Remove(model);

            return new NewInstanceExpression(model.Type, arguments, new ObjectInitializerExpression(propertyExpressions, IsInline: false));
        }

        private ValueExpression ComposeAnonymousObjectType(SerializableObjectType model, bool allProperties, HashSet<ObjectType> visitedModels)
        {
            visitedModels.Add(model);
            /* GENERATED CODE PATTERN
             * new
             * {
             *     propNotInCtor1 = {value_expression},
             *     propNotInCtor2 = {value_expression},
             *     ...
             * }
             */

            var propertyExpressions = model.JsonSerialization?.Properties
                .Where(p => !p.ShouldSkipSerialization && !IsVisitedModel(p.ValueSerialization, visitedModels) && (allProperties || p.IsRequired))
                .ToDictionary(p => p.SerializedName, p => ComposeProtocolPropertyValue(p, visitedModels, model.Discriminator, allProperties));

            visitedModels.Remove(model);

            if (propertyExpressions is not null && propertyExpressions.Keys.Any(name => StringExtensions.IsCSharpKeyword(name) || !name.IsValidIdentifier()))
            {
                return New.Dictionary(typeof(string), typeof(object), propertyExpressions.Select(kvp => (Literal(kvp.Key), kvp.Value)).ToArray());
            }

            return New.Anonymous(propertyExpressions);
        }

        private ValueExpression ComposeProtocolPropertyValue(JsonPropertySerialization propertySerialization, HashSet<ObjectType> visitedModels, ObjectTypeDiscriminator? discriminator, bool allProperties)
            => discriminator is not null && discriminator.SerializedName == propertySerialization.SerializedName && discriminator.Value is {} discriminatorValue
                ? new ConstantExpression(discriminatorValue is {Value: EnumTypeValue enumValue} ? enumValue.Value : discriminatorValue) 
                : ComposeProtocolCSharpTypeInstance(allProperties, propertySerialization.ValueSerialization, propertySerialization.SerializedName, visitedModels);

        private static SerializableObjectType GetMostConcreteModel(SerializableObjectType model)
        {
            while (model.Discriminator is { Implementations.Length: > 0 })
            {
                model = model.Discriminator.Implementations
                    .Where(i => i.Type is { IsFrameworkType: false })
                    .Select(i => i.Type.Implementation as SerializableObjectType)
                    .WhereNotNull()
                    .First();
            }

            return model;
        }

        private static bool IsPropertyAssignable(ObjectTypeProperty property)
            => TypeFactory.IsReadWriteDictionary(property.Declaration.Type) || TypeFactory.IsReadWriteList(property.Declaration.Type) || !property.IsReadOnly;

        private MethodBodyStatement ComposeGetClient(out ValueExpression client)
        {
            var statements = new List<MethodBodyStatement>();
            var clientConstructor = ClientInvocationChain[0].GetEffectiveCtor()!;

            ValueExpression? credential = null;
            if (clientConstructor.Parameters.Any(p => p.Type.EqualsIgnoreNullable(KeyAuthType)))
            {
                statements.Add(Var("credential", New.Instance(KeyAuthType, Literal("<key>")), out credential));
            }
            else if (clientConstructor.Parameters.Any(p => p.Type.EqualsIgnoreNullable(TokenAuthType)))
            {
                statements.Add(Var("credential", new FormattableStringToExpression($"new Azure.Identity.DefaultAzureCredential()"), out credential));
            }

            ValueExpression? endpoint = null;
            if (clientConstructor.Parameters.Any(p => p.Type.EqualsIgnoreNullable(UriType)))
            {
                statements.Add(Var("endpoint", New.Uri($"<{GetEndpoint()}>"), out endpoint));
            }

            var newClientArguments = MockClientConstructorParameterValues(clientConstructor.Parameters, endpoint, credential);
            var newClientExpression = New.Instance(ClientInvocationChain[0].Type, newClientArguments);

            if (ClientInvocationChain.Count > 1)
            {
                for (int i = 1; i < ClientInvocationChain.Count; i++)
                {
                    var factoryMethod = ClientInvocationChain[i].FactoryMethod!.Signature;
                    newClientExpression = newClientExpression.Invoke(factoryMethod.Name, factoryMethod.Parameters.Select(MockParameterValue).ToList());
                }
            }

            statements.Add(Var("client", newClientExpression, out client));

            return statements;
        }

        private ValueExpression[] MockClientConstructorParameterValues(IReadOnlyList<Parameter> parameters, ValueExpression? endpoint, ValueExpression? credential)
        {
            var parameterValues = new ValueExpression[parameters.Count];
            for (var i = 0; i < parameters.Count; i++)
            {
                Parameter? parameter = parameters[i];
                if (parameter.Type.EqualsIgnoreNullable(UriType))
                {
                    parameterValues[i] = endpoint!;
                }
                else if (parameter.Name.Equals("endpoint", StringComparison.OrdinalIgnoreCase))
                {
                    // sometimes the endpoint parameter cannot be generated as Uri type, best efforts to guesss it
                    // see: https://github.com/Azure/autorest/issues/4571
                    parameterValues[i] = Literal($"<{GetEndpoint()}>");
                }
                else if (parameter.Type.EqualsIgnoreNullable(KeyAuthType) || parameter.Type.EqualsIgnoreNullable(TokenAuthType))
                {
                    parameterValues[i] = credential!;
                }
                else
                {
                    parameterValues[i] = MockParameterValue(parameter);
                }
            }

            return parameterValues;
        }

        /// <summary>
        /// Get the methods to be called to get the client, it should be like `Client(...).GetXXClient(..).GetYYClient(..)`.
        /// It's composed of a constructor of non-subclient and a optional list of subclient factory methods.
        /// </summary>
        /// <returns></returns>
        private static IReadOnlyList<LowLevelClient> GetClientInvocationChain(LowLevelClient client)
        {
            var callChain = new Stack<LowLevelClient>();
            while (client.FactoryMethod != null)
            {
                callChain.Push(client);
                if (client.ParentClient == null)
                {
                    break;
                }

                client = client.ParentClient;
            }
            callChain.Push(client);

            return callChain.ToList();
        }

        private static string GetEndpoint()
        {
            // TODO: is there a way to compose a data plane endpoint from swagger?
            return "https://my-service.azure.com";
        }

        private static InputModelType GetConcreteChildModel(InputModelType model)
            => model;//.DerivedModels.Any() ? model.DerivedModels[0] : model;
    }
}

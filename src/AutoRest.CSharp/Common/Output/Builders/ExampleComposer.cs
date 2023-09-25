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
using AutoRest.CSharp.Common.Output.Builders;
using AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions;
using AutoRest.CSharp.Common.Output.Expressions.Statements;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Common.Output.Models;
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
    internal class ExampleComposer
    {
        private static readonly CSharpType UriType = new CSharpType(typeof(Uri));
        private static readonly CSharpType KeyAuthType = KnownParameters.KeyAuth.Type;
        private static readonly CSharpType TokenAuthType = KnownParameters.TokenAuth.Type;
        private static readonly CSharpType DefaultAzureCredentialType = new DefaultAzureCredentialTypeProvider().Type;

        private readonly LowLevelClient _client;
        private readonly TypeFactory _typeFactory;
        private IReadOnlyList<LowLevelClient> ClientInvocationChain { get; }

        public ExampleComposer(LowLevelClient client, TypeFactory typeFactory)
        {
            _client = client;
            _typeFactory = typeFactory;
            ClientInvocationChain = GetClientInvocationChain(client);
        }

        public IReadOnlyDictionary<string, MethodBodyStatement> ComposeProtocolSamples(RestClientOperationMethods operationMethods, MethodSignature signature, bool async)
        {
            //skip non public protocol methods
            if ((signature.Modifiers & MethodSignatureModifiers.Public) == 0)
                return new Dictionary<string, MethodBodyStatement>();

            //skip obsolete protocol methods
            if (signature.Attributes.Any(a => a.Type.Equals(typeof(ObsoleteAttribute))))
                return new Dictionary<string, MethodBodyStatement>();

            //skip suppressed protocol methods
            if (_client.IsMethodSuppressed(signature))
                return new Dictionary<string, MethodBodyStatement>();

            //skip if there are no valid ctors
            if (!_client.IsSubClient && _client.GetEffectiveCtor() is null)
                return new Dictionary<string, MethodBodyStatement>();

            var allParametersSample = ComposeProtocolWrappedCodeSnippet(operationMethods, signature, async, true);
            // [TODO] Why do we create identical samples when all parameters are required?
            //if (HasNoCustomInput(signature.Parameters))
            //{
            //    // client.GetAllItems(RequestContext context = null)
            //    return new Dictionary<string, MethodBodyStatement>
            //    {
            //        [$"This sample shows how to call {signature.Name}{(operationMethods.ResponseType is not null ? " and parse the result" : "")}."] = allParametersSample
            //    };
            //}

            //if (!HasOptionalInputValue(signature.Parameters, operationMethods.RequestBodyType, out var requestModel))
            //{
            //    return new Dictionary<string, MethodBodyStatement>
            //    {
            //        [$"This sample shows how to call {signature.Name}{(operationMethods.ResponseType is not null ? " and parse the result" : "")}."] = allParametersSample
            //    };
            //}

            // client.GetAllItems(int a, RequestContext context = null)
            var statement = ComposeProtocolWrappedCodeSnippet(operationMethods, signature, async, false);
            return new Dictionary<string, MethodBodyStatement>
            {
                [$"This sample shows how to call {signature.Name}{(operationMethods.ResponseType is not null ? " and parse the result" : "")}."] = statement,
                [$"This sample shows how to call {signature.Name} with all {GenerateParameterAndRequestContentDescription(signature.Parameters)}{(operationMethods.ResponseType is not null ? " and parse the result" : "")}."] = allParametersSample
            };
        }

        public IReadOnlyDictionary<string, MethodBodyStatement> ComposeConvenienceSamples(RestClientOperationMethods operationMethods, MethodSignature signature, bool async)
        {
            signature = signature.WithAsync(async);

            // Skip deprecated
            if (signature.Attributes.Any(c => c.Type.Equals(typeof(ObsoleteAttribute))))
            {
                return new Dictionary<string, MethodBodyStatement>();
            }

            // Skip with deprecated parameters
            if (signature.Parameters.Any(p => p.Type is {IsFrameworkType: false, Implementation: ModelTypeProvider {Deprecated: not null}}))
            {
                return new Dictionary<string, MethodBodyStatement>();
            }

            //skip if not public
            if (!signature.Modifiers.HasFlag(MethodSignatureModifiers.Public))
            {
                return new Dictionary<string, MethodBodyStatement>();
            }

            //skip if there are no valid ctors
            if (!_client.IsSubClient && _client.GetEffectiveCtor() is null)
            {
                return new Dictionary<string, MethodBodyStatement>();
            }

            //skip suppressed convenience methods
            if (_client.IsMethodSuppressed(signature))
            {
                return new Dictionary<string, MethodBodyStatement>();
            }

            return new Dictionary<string, MethodBodyStatement>
            {
                [$"This sample shows how to call {signature.Name}."] =                     ComposeConvenienceMethodExample(signature, false, async),
                [$"This sample shows how to call {signature.Name} with all parameters."] = ComposeConvenienceMethodExample(signature, true, async)
            };
        }

        internal MethodBodyStatement ComposeConvenienceMethodExample(MethodSignature signature, bool allParameters, bool async)
            => ComposeConvenienceCodeSnippet(signature, allParameters, async).AsStatement();

        // `RequestContext = null` or `cancellationToken = default` is excluded
        private static bool HasNoCustomInput(IReadOnlyList<Parameter> parameters)
            => parameters.Count == 0 || (parameters.Count == 1 && (parameters[0].Equals(KnownParameters.RequestContext) || parameters[0].Equals(KnownParameters.CancellationTokenParameter)));

        // RequestContext is excluded
        private static bool HasNonBodyCustomParameter(IReadOnlyList<Parameter> parameters)
            => parameters.Any(p => p.RequestLocation != RequestLocation.Body && !p.Equals(KnownParameters.RequestContext));

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

        private MethodBodyStatement ComposeProtocolWrappedCodeSnippet(RestClientOperationMethods operationMethods, MethodSignature signature, bool async, bool allParameters)
            => ComposeProtocolCodeSnippet(operationMethods, signature, allParameters, async).AsStatement();

        private IEnumerable<MethodBodyStatement> ComposeConvenienceCodeSnippet(MethodSignature signature, bool allParameters, bool async)
        {
            yield return ComposeGetClient(out var client);
            yield return EmptyLine;

            var arguments = new List<ValueExpression>();
            foreach (var parameter in signature.Parameters.Where((p, i) => i != signature.Parameters.Count - 1 || !p.IsOptionalInSignature || !p.Type.Equals(typeof(CancellationToken))))
            {
                if (!allParameters && parameter.IsOptionalInSignature)
                {
                    continue;
                }

                if (parameter.Type is {IsFrameworkType: false, Implementation: SerializableObjectType})
                {
                    // model parameters can't be initialized in - create an instance in the variable
                    var argument = new VariableReference(parameter.Type, parameter.Name);
                    yield return Declare(argument, ComposeConvenienceCSharpTypeInstance(true, parameter.Type, null, true, new HashSet<ObjectType>()));
                    arguments.Add(argument);
                }
                else
                {
                    arguments.Add(MockParameterValue(parameter));
                }
            }

            var returnType = signature.ReturnType;

            if (returnType is null)
            {
                yield return ComposeConvenienceHandleNormalResponseCode(client, signature.Name, arguments, typeof(Response), async);
            }
            else if (TypeFactory.IsOperationOfAsyncPageable(returnType) || TypeFactory.IsOperationOfPageable(returnType))
            {
                // do nothing, this never happen right now
            }
            else if (TypeFactory.IsOperation(returnType))
            {
                yield return ComposeConvenienceHandleLongRunningResponseCode(client, signature.Name, arguments, returnType, async);
            }
            else if (TypeFactory.IsAsyncPageable(returnType) || TypeFactory.IsPageable(returnType))
            {
                yield return ComposeConvenienceHandlePageableResponseCode(client, signature.Name, arguments, async);
            }
            else
            {
                yield return ComposeConvenienceHandleNormalResponseCode(client, signature.Name, arguments, returnType, async);
            }
        }

        internal IEnumerable<MethodBodyStatement> ComposeProtocolCodeSnippet(RestClientOperationMethods operationMethods, MethodSignature signature, bool allParameters, bool async)
        {
            yield return ComposeGetClient(out var client);
            yield return EmptyLine;

            VariableReference? requestContent = null;
            if (operationMethods.RequestBodyType != null)
            {
                // This is a corner case in swagger DPG when body is a primitive type constant.
                // In matching legacy data plane case, public method has no body parameter
                // See StringClient.PutMbcs
                var dataValueExpression = operationMethods.RequestBodyType is InputPrimitiveType && operationMethods.Operation.Parameters.FirstOrDefault(p => p is { Location: RequestLocation.Body, DefaultValue: {}}) is {DefaultValue: {} defaultValue}
                    ? new ConstantExpression(BuilderHelpers.ParseConstant(defaultValue.Value, _typeFactory.CreateType(defaultValue.Type)))
                    : ComposeProtocolCSharpTypeInstance(allParameters, GetTypeSerialization(operationMethods.RequestBodyType), null, new HashSet<ObjectType>());

                requestContent = new VariableReference(typeof(RequestContent), "content");
                yield return Declare(requestContent, RequestContentExpression.Create(dataValueExpression));
                yield return EmptyLine;
            }

            var arguments = signature.Parameters
                //skip last param if its optional and cancellation token or request context
                .Where((p, i) => !(i == signature.Parameters.Count - 1 && p.IsOptionalInSignature && p.Type.Equals(typeof(RequestContext))))
                .Where(p => allParameters || !p.IsOptionalInSignature)
                .Select(p => p.RequestLocation == RequestLocation.Body ? requestContent! : MockParameterValue(p))
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
                Var("operation", new OperationExpression(InvokeClientMethod(client, methodName, arguments, async)), out var operation),
                EmptyLine,
                new ForeachStatement("item", new EnumerableExpression(typeof(BinaryData), operation.Value), async, out ValueExpression binaryDataItem)
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
                Var("operation", new OperationExpression(InvokeClientMethod(client, methodName, arguments, async)), out var operation),
                EmptyLine, operationValueType is null
                    ? InvokeConsoleWriteLine(operation.GetRawResponse().Status)
                    : new[]
                    {
                        Declare("responseData", new BinaryDataExpression(operation.Value), out var responseData),
                        ComposeParsingLongRunningResponse(responseData, operationValueType, allProperties)
                    }
            };
        }

        private MethodBodyStatement ComposeConvenienceHandleLongRunningResponseCode(ValueExpression client, string methodName, IReadOnlyList<ValueExpression> arguments, CSharpType returnType, bool async)
        {
            /* GENERATED CODE PATTERN
             * var operation = await client.{methodName}(WaitUntil.Completed, ...);
             */
            return Var(new VariableReference(returnType, "operation"), InvokeClientMethod(client, methodName, arguments, async));
        }

        private MethodBodyStatement ComposeParsingLongRunningResponse(BinaryDataExpression responseData, CSharpType operationValueType, bool allProperties)
        {
            if (operationValueType.Equals(typeof(Stream)))
            {
                return new[]
                {
                    UsingDeclare("outFileStream", InvokeFileOpenWrite("<filePath>"), out var outFileStream),
                    responseData.ToStream().CopyTo(outFileStream)
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

            return new ForeachStatement("item", new EnumerableExpression(typeof(BinaryData), InvokeClientMethod(client, methodName, arguments, false)), async, out ValueExpression binaryDataItem)
            {
                ComposeParsingPageableResponse(new BinaryDataExpression(binaryDataItem), conveniencePageItemType, allParameters)
            };
        }

        private MethodBodyStatement ComposeConvenienceHandlePageableResponseCode(ValueExpression client, string methodName, IReadOnlyList<ValueExpression> arguments, bool async)
            => new ForeachStatement("item", new EnumerableExpression(typeof(object), InvokeClientMethod(client, methodName, arguments, false)), async, out _);

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
                Declare(typeof(Response<bool>), "response", new ResponseExpression(InvokeClientMethod(client, methodName, arguments, async)), out var response),
                InvokeConsoleWriteLine(response.GetRawResponse().Status)
            };
        }

        private MethodBodyStatement ComposeProtocolHandleNormalResponse(ValueExpression client, string methodName, IReadOnlyList<ValueExpression> arguments, CSharpType? responseType, bool allProperties, bool async)
        {
            return new[]
            {
                Declare("response", new ResponseExpression(InvokeClientMethod(client, methodName, arguments, async)), out var response),
                responseType is null
                    ? InvokeConsoleWriteLine(response.Status)
                    : ComposeParsingNormalResponseCodes(response, responseType, allProperties)
            };
        }

        private MethodBodyStatement ComposeConvenienceHandleNormalResponseCode(ValueExpression client, string methodName, IReadOnlyList<ValueExpression> arguments, CSharpType returnType, bool async)
            => Declare(new VariableReference(async ? returnType.Arguments[0] : returnType, "response"), InvokeClientMethod(client, methodName, arguments, async));

        private MethodBodyStatement ComposeParsingNormalResponseCodes(ResponseExpression response, CSharpType responseType, bool allProperties)
        {
            if (responseType.Equals(typeof(Stream)))
            {
                return new IfStatement(NotEqual(response.ContentStream, Null))
                {
                    UsingDeclare("outFileStream", InvokeFileOpenWrite("<filePath>"), out var outFileStream),
                    response.ContentStream.CopyTo(outFileStream)
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
                var propertyType = propertySerialization.Value.Type;
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

        private ValueExpression MockParameterTypeValue(string? propertyName, CSharpType parameterType, SerializationFormat? serializationFormat)
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
                    return string.IsNullOrWhiteSpace(propertyName) ? Literal("<String>") : Literal($"<{propertyName}>");
                }

                if (type == typeof(bool))
                {
                    return Bool(true);
                }

                if (type == typeof(DateTimeOffset))
                {
                    return format is null
                        ? DateTimeOffsetExpression.UtcNow
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
                        : GuidExpression.Parse("73f411fe-4f43-4b4b-9cbd-6828d8f4cf9a");
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
                    return New.Array(elementType, true, MockParameterTypeValue(propertyName, elementType, null));
                }

                if (type == typeof(IDictionary<,>))
                {
                    var valueType = parameterType.Arguments[1];
                    return New.Dictionary(typeof(string), valueType, (Literal("test"), MockParameterTypeValue(propertyName, valueType, null)));
                }

                if (type == typeof(BinaryData))
                {
                    return BinaryDataExpression.FromString(Literal("<your binary data content>"));
                }

                if (type == typeof(Stream))
                {
                    return InvokeFileOpenRead("<filePath>");
                }

                if (type == typeof(JsonElement))
                {
                    return serializationFormat.HasValue
                        ? Literal("{}")
                        : Default;
                }

                if (type == typeof(RequestContext))
                {
                    return Null;
                }

                if (type.GetConstructor(Type.EmptyTypes) is not null)
                {
                    return New.Instance(type);
                }
            }
            else if (parameterType.Implementation is EnumType enumType)
            {
                return EnumValue(enumType, enumType.Values.First());
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


        private ValueExpression ComposeProtocolCSharpTypeInstance(bool allProperties, JsonSerialization? serialization, string? propertyName, HashSet<ObjectType> visitedModels) => serialization switch
        {
            JsonArraySerialization array => ComposeProtocolArrayCSharpType(allProperties, array, visitedModels),
            JsonDictionarySerialization dictionary => ComposeProtocolDictionaryInstance(allProperties, dictionary, visitedModels),
            JsonValueSerialization { Type.IsFrameworkType: true } value => MockParameterTypeValue(propertyName, value.Type, value.Format),
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

        private EnumerableExpression ComposeProtocolArrayCSharpType(bool allProperties, JsonArraySerialization serialization, HashSet<ObjectType> visitedModels)
        {
            /* GENERATED CODE PATTERN
             * new[] {
             *     {element_expression}
             * }
             */
            return New.Array(null, false, ComposeProtocolCSharpTypeInstance(allProperties, serialization.ValueSerialization, null, visitedModels));
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
                return New.Dictionary(typeof(string), typeof(object), propertyExpressions.Select(kvp => ((ValueExpression)Literal(kvp.Key), kvp.Value)).ToArray());
            }

            return New.Anonymous(propertyExpressions);
        }

        private ValueExpression ComposeProtocolPropertyValue(JsonPropertySerialization propertySerialization, HashSet<ObjectType> visitedModels, ObjectTypeDiscriminator? discriminator, bool allProperties)
        {
            if (discriminator is not null && discriminator.SerializedName == propertySerialization.SerializedName && discriminator.Value is {} discriminatorValue)
            {
                return new ConstantExpression(discriminatorValue is { Value: EnumTypeValue enumValue } ? enumValue.Value : discriminatorValue);
            }

            return ComposeProtocolCSharpTypeInstance(allProperties, propertySerialization.ValueSerialization, propertySerialization.SerializedName, visitedModels);
        }

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

        private MethodBodyStatement ComposeGetClient(out VariableReference client)
        {
            var statements = new List<MethodBodyStatement>();
            var clientConstructor = ClientInvocationChain[0].GetEffectiveCtor()!;

            ValueExpression? endpoint = null;
            if (clientConstructor.Parameters.Any(p => p.IsEndpoint && p.Type.EqualsIgnoreNullable(UriType)))
            {
                statements.Add(Declare("endpoint", New.Uri($"<{GetEndpoint()}>"), out endpoint));
            }

            VariableReference? credential = null;
            if (clientConstructor.Parameters.Any(p => p.Type.EqualsIgnoreNullable(KeyAuthType)))
            {
                credential = new VariableReference(KeyAuthType, "credential");
                statements.Add(Declare(credential, New.Instance(KeyAuthType, Literal("<key>"))));
            }
            else if (clientConstructor.Parameters.Any(p => p.Type.EqualsIgnoreNullable(TokenAuthType)))
            {
                credential = new VariableReference(TokenAuthType, "credential");
                statements.Add(Declare(credential, New.Instance(DefaultAzureCredentialType)));
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

            client = new VariableReference(ClientInvocationChain.Last().Type, "client");
            statements.Add(Declare(client, newClientExpression));

            return statements;
        }

        private ValueExpression[] MockClientConstructorParameterValues(IReadOnlyList<Parameter> parameters, ValueExpression? endpoint, ValueExpression? credential)
        {
            var parameterValues = new ValueExpression[parameters.Count];
            for (var i = 0; i < parameters.Count; i++)
            {
                Parameter? parameter = parameters[i];
                if (parameter.IsEndpoint)
                {
                    parameterValues[i] = parameter.Type.EqualsIgnoreNullable(UriType) ? endpoint! : Literal($"<{GetEndpoint()}>");
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
            => model.DerivedModels.Any() ? model.DerivedModels[0] : model;

        private static ValueExpression InvokeClientMethod(ValueExpression client, string methodName, IReadOnlyList<ValueExpression> arguments, bool async)
            => new InvokeInstanceMethodExpression(client, methodName, arguments, null, async, AddConfigureAwaitFalse: false);

        private class DefaultAzureCredentialTypeProvider : TypeProvider
        {
            public DefaultAzureCredentialTypeProvider() : base("Azure.Identity", null) { }

            protected override string DefaultName => "DefaultAzureCredential";
            protected override string DefaultAccessibility => "public";
        }
    }
}

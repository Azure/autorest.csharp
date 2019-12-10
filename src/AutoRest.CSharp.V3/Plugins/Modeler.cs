// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoRest.CSharp.V3.ClientModels;
using AutoRest.CSharp.V3.CodeGen;
using AutoRest.CSharp.V3.JsonRpc.MessageModels;
using AutoRest.CSharp.V3.Pipeline;
using AutoRest.CSharp.V3.Pipeline.Generated;
using Azure.Core;
using SerializationFormat = AutoRest.CSharp.V3.ClientModels.SerializationFormat;

namespace AutoRest.CSharp.V3.Plugins
{
    [PluginName("cs-modeler")]
    internal class Modeler : IPlugin
    {
        public async Task<bool> Execute(IAutoRestInterface autoRest, CodeModel codeModel, Configuration configuration)
        {
            var schemas = (codeModel.Schemas.Choices ?? Enumerable.Empty<ChoiceSchema>()).Cast<Schema>()
                .Concat(codeModel.Schemas.SealedChoices ?? Enumerable.Empty<SealedChoiceSchema>())
                .Concat(codeModel.Schemas.Objects ?? Enumerable.Empty<ObjectSchema>());

            var models = schemas.Select(BuildModel).ToArray();
            var clients = codeModel.OperationGroups.Select(BuildClient).ToArray();

            var typeProviders = models.OfType<ISchemaTypeProvider>().ToArray();
            var typeFactory = new TypeFactory(configuration.Namespace, typeProviders);

            foreach (var model in models)
            {
                var name = model.Name;
                var writer = new ModelWriter(typeFactory);
                writer.WriteModel(model);

                var serializeWriter = new SerializationWriter(typeFactory);
                serializeWriter.WriteSerialization(model);

                await autoRest.WriteFile($"Generated/Models/{name}.cs", writer.ToFormattedCode(), "source-file-csharp");
                await autoRest.WriteFile($"Generated/Models/{name}.Serialization.cs", serializeWriter.ToFormattedCode(), "source-file-csharp");
            }

            foreach (var client in clients)
            {
                var writer = new ClientWriter(typeFactory);
                writer.WriteClient(client);
                await autoRest.WriteFile($"Generated/Operations/{client.Name}.cs", writer.ToFormattedCode(), "source-file-csharp");
            }

            return true;
        }

        private static ServiceClient BuildClient(OperationGroup arg) =>
            new ServiceClient(arg.CSharpName(), arg.Operations.Select(BuildMethod).Where(method => method != null).ToArray()!);

        private static ClientConstant? CreateDefaultValueConstant(Parameter requestParameter) =>
            requestParameter.ClientDefaultValue != null ?
                ParseClientConstant(requestParameter.ClientDefaultValue, (FrameworkTypeReference) CreateType(requestParameter.Schema, requestParameter.IsNullable())) :
                (ClientConstant?)null;

        private static ClientMethod? BuildMethod(Operation operation)
        {
            var httpRequest = operation.Request.Protocol.Http as HttpRequest;
            var response = operation.Responses.FirstOrDefault();
            var httpResponse = response?.Protocol.Http as HttpResponse;

            if (httpRequest == null || httpResponse == null)
            {
                return null;
            }

            Dictionary<string, ConstantOrParameter> uriParameters = new Dictionary<string, ConstantOrParameter>();
            Dictionary<string, PathSegment> pathParameters = new Dictionary<string, PathSegment>();
            List<QueryParameter> query = new List<QueryParameter>();
            List<RequestHeader> headers = new List<RequestHeader>();

            List<ServiceClientMethodParameter> methodParameters = new List<ServiceClientMethodParameter>();

            ConstantOrParameter? body = null;
            foreach (Parameter requestParameter in operation.Request.Parameters ?? Array.Empty<Parameter>())
            {
                string defaultName = requestParameter.Language.Default.Name;
                string serializedName = requestParameter.Language.Default.SerializedName ?? defaultName;
                ConstantOrParameter? constantOrParameter;
                Schema valueSchema = requestParameter.Schema;

                switch (requestParameter.Schema)
                {
                    case ConstantSchema constant:
                        constantOrParameter = ParseClientConstant(constant.Value.Value, CreateType(constant.ValueType, true));
                        valueSchema = constant.ValueType;
                        break;
                    case BinarySchema _:
                        // skip
                        continue;
                    //TODO: Workaround for https://github.com/Azure/autorest.csharp/pull/275
                    case ArraySchema arraySchema when arraySchema.ElementType is ConstantSchema constantInnerType:
                        constantOrParameter = new ServiceClientMethodParameter(requestParameter.CSharpName(),
                            new CollectionTypeReference(CreateType(constantInnerType.ValueType, false), false),
                            CreateDefaultValueConstant(requestParameter));
                        break;
                    //TODO: Workaround for https://github.com/Azure/autorest.csharp/pull/275
                    case DictionarySchema dictionarySchema when dictionarySchema.ElementType is ConstantSchema constantInnerType:
                        constantOrParameter = new ServiceClientMethodParameter(requestParameter.CSharpName(),
                            new CollectionTypeReference(CreateType(constantInnerType.ValueType, false), false),
                            CreateDefaultValueConstant(requestParameter));
                        break;
                    default:
                        constantOrParameter = new ServiceClientMethodParameter(requestParameter.CSharpName(),
                            CreateType(requestParameter.Schema, requestParameter.IsNullable()),
                            CreateDefaultValueConstant(requestParameter));
                        break;
                }

                if (requestParameter.Protocol.Http is HttpParameter httpParameter)
                {
                    SerializationFormat serializationFormat = GetSerializationFormat(valueSchema);
                    switch (httpParameter.In)
                    {
                        case ParameterLocation.Header:
                            headers.Add(new RequestHeader(serializedName, constantOrParameter.Value, serializationFormat));
                            break;
                        case ParameterLocation.Query:
                            query.Add(new QueryParameter(serializedName, constantOrParameter.Value, true, serializationFormat));
                            break;
                        case ParameterLocation.Path:
                            pathParameters.Add(serializedName, new PathSegment(constantOrParameter.Value, true, serializationFormat));
                            break;
                        case ParameterLocation.Body:
                            body = constantOrParameter;
                            break;
                        case ParameterLocation.Uri:
                            uriParameters[defaultName] = constantOrParameter.Value;
                            break;
                    }
                }

                if (!constantOrParameter.Value.IsConstant)
                {
                    methodParameters.Add(constantOrParameter.Value.Parameter);
                }
            }

            if (httpRequest is HttpWithBodyRequest httpWithBodyRequest)
            {
                headers.AddRange(httpWithBodyRequest.MediaTypes.Select(mediaType => new RequestHeader("Content-Type", new ConstantOrParameter(StringConstant(mediaType)))));
            }

            var request = new ClientMethodRequest(
                httpRequest.Method.ToCoreRequestMethod() ?? RequestMethod.Get,
                ToParts(httpRequest.Uri, uriParameters),
                ToPathParts(httpRequest.Path, pathParameters),
                query.ToArray(),
                headers.ToArray(),
                httpResponse.StatusCodes.Select(ToStatusCode).ToArray(),
                body
            );

            ClientTypeReference? responseType = null;
            if (response is SchemaResponse schemaResponse)
            {
                var schema = schemaResponse.Schema is ConstantSchema constantSchema ? constantSchema.ValueType : schemaResponse.Schema;
                responseType = CreateType(schema, isNullable: false);
            }

            return new ClientMethod(
                operation.CSharpName(),
                request,
                methodParameters.ToArray(),
                responseType
            );
        }

        private static SerializationFormat GetSerializationFormat(Schema schema)
        {
            return schema switch
            {
                UnixTimeSchema _ => SerializationFormat.DateTimeUnix,
                DateTimeSchema dateTimeSchema when dateTimeSchema.Format == DateTimeSchemaFormat.DateTime => SerializationFormat.DateTimeISO8601,
                DateTimeSchema dateTimeSchema when dateTimeSchema.Format == DateTimeSchemaFormat.DateTimeRfc1123 => SerializationFormat.DateTimeRFC1123,
                DateSchema _ => SerializationFormat.Date,
                _ => SerializationFormat.Default,
            };
        }

        private static ConstantOrParameter[] ToParts(string httpRequestUri, Dictionary<string, ConstantOrParameter> parameters)
        {
            List<ConstantOrParameter> host = new List<ConstantOrParameter>();
            foreach ((string text, bool isLiteral) in GetPathParts(httpRequestUri))
            {
                host.Add(isLiteral ? StringConstant(text) : parameters[text]);
            }

            return host.ToArray();
        }

        private static PathSegment[] ToPathParts(string httpRequestUri, Dictionary<string, PathSegment> parameters)
        {
            PathSegment TextSegment(string text)
            {
                return new PathSegment(StringConstant(text), false, SerializationFormat.Default);
            }

            List<PathSegment> host = new List<PathSegment>();
            foreach ((string text, bool isLiteral) in GetPathParts(httpRequestUri))
            {
                if (!isLiteral)
                {

                    if (!parameters.TryGetValue(text, out var segment))
                    {
                        //TODO: WORKAROUND FOR https://github.com/Azure/autorest.modelerfour/issues/58
                        segment = TextSegment(text);
                    }
                    host.Add(segment);
                }
                else
                {
                    host.Add(TextSegment(text));
                }
            }

            return host.ToArray();
        }

        private static int ToStatusCode(StatusCodes arg) => int.Parse(arg.ToString().Trim('_'));

        private static ClientConstant StringConstant(string s) => ParseClientConstant(s, new FrameworkTypeReference(typeof(string)));

        private static ClientModel BuildClientEnum(SealedChoiceSchema sealedChoiceSchema) => new ClientEnum(
            sealedChoiceSchema,
            sealedChoiceSchema.CSharpName(),
            sealedChoiceSchema.Choices.Select(c => new ClientEnumValue(c.CSharpName(), StringConstant(c.Value))));

        private static ClientModel BuildClientEnum(ChoiceSchema choiceSchema) => new ClientEnum(
            choiceSchema,
            choiceSchema.CSharpName(),
            choiceSchema.Choices.Select(c => new ClientEnumValue(c.CSharpName(), StringConstant(c.Value))),
            true);

        private static ClientModel BuildClientObject(ObjectSchema objectSchema) => new ClientObject(
            objectSchema, objectSchema.CSharpName(),
            objectSchema.Properties.Where(property => !(property.Schema is ConstantSchema)).Select(CreateProperty),
            objectSchema.Properties.Where(property => property.Schema is ConstantSchema).Select(CreateConstant));

        private static ClientModel BuildModel(Schema schema) => schema switch
        {
            SealedChoiceSchema sealedChoiceSchema => BuildClientEnum(sealedChoiceSchema),
            ChoiceSchema choiceSchema => BuildClientEnum(choiceSchema),
            ObjectSchema objectSchema => BuildClientObject(objectSchema),
            _ => throw new NotImplementedException()
        };

        private static ClientObjectConstant CreateConstant(Property property)
        {
            var constantSchema = (ConstantSchema)property.Schema;
            FrameworkTypeReference type = (FrameworkTypeReference)CreateType(constantSchema.ValueType, false);
            return new ClientObjectConstant(property.CSharpName(), type, ParseClientConstant(constantSchema.Value.Value, type));
        }

        private static ClientObjectProperty CreateProperty(Property property) =>
            new ClientObjectProperty(property.CSharpName(), CreateType(property.Schema, property.IsNullable()), property.Schema.IsLazy(), property.SerializedName);

        //TODO: Handle nullability properly
        private static ClientTypeReference CreateType(Schema schema, bool isNullable) => schema switch
        {
            BinarySchema _ => (ClientTypeReference)new BinaryTypeReference(isNullable),
            ByteArraySchema _ => new BinaryTypeReference(isNullable),
            //https://devblogs.microsoft.com/dotnet/do-more-with-patterns-in-c-8-0/
            { Type: AllSchemaTypes.Binary } => new BinaryTypeReference(false),
            ArraySchema array => new CollectionTypeReference(CreateType(array.ElementType, false), isNullable),
            DictionarySchema dictionary => new DictionaryTypeReference(new FrameworkTypeReference(typeof(string)), CreateType(dictionary.ElementType, isNullable)),
            NumberSchema number => new FrameworkTypeReference(number.ToFrameworkType(), isNullable),
            _ when schema.Type.ToFrameworkCSharpType() is Type type => new FrameworkTypeReference(type, isNullable),
            _ => new SchemaTypeReference(schema, isNullable)
        };

        private static ClientConstant ParseClientConstant(object? value, ClientTypeReference type)
        {
            var normalizedValue = type switch
            {
                BinaryTypeReference _ when value is string base64String => Convert.FromBase64String(base64String),
                FrameworkTypeReference frameworkType when
                    frameworkType.Type == typeof(DateTimeOffset) &&
                    value is string dateTimeString => DateTimeOffset.Parse(dateTimeString, styles: DateTimeStyles.AssumeUniversal),
                FrameworkTypeReference frameworkType => Convert.ChangeType(value, frameworkType.Type),
                _ => null
            };
            return new ClientConstant(normalizedValue, type);
        }

        //TODO: Refactor as this is written quite... ugly.
        private static IEnumerable<(string Text, bool IsLiteral)> GetPathParts(string? path)
        {
            if (path == null)
            {
                yield break;
            }

            var index = 0;
            var currentPart = new StringBuilder();
            var innerPart = new StringBuilder();
            while (index < path.Length)
            {
                if (path[index] == '{')
                {
                    var innerIndex = index + 1;
                    while (innerIndex < path.Length)
                    {
                        if (path[innerIndex] == '}')
                        {
                            if (currentPart.Length > 0)
                            {
                                yield return (currentPart.ToString(), true);
                                currentPart.Clear();
                            }

                            yield return (innerPart.ToString(), false);
                            innerPart.Clear();

                            break;
                        }

                        innerPart.Append(path[innerIndex]);
                        innerIndex++;
                    }

                    if (innerPart.Length > 0)
                    {
                        currentPart.Append('{');
                        currentPart.Append(innerPart);
                    }
                    index = innerIndex + 1;
                    continue;
                }
                currentPart.Append(path[index]);
                index++;
            }

            if (currentPart.Length > 0)
            {
                yield return (currentPart.ToString(), true);
            }
        }
    }
}

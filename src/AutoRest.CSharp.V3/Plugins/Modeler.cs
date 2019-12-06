// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoRest.CSharp.V3.ClientModels;
using AutoRest.CSharp.V3.CodeGen;
using AutoRest.CSharp.V3.JsonRpc.MessageModels;
using AutoRest.CSharp.V3.Pipeline;
using AutoRest.CSharp.V3.Pipeline.Generated;
using Azure.Core;
using Microsoft.CodeAnalysis.CSharp.Syntax;

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
                new ClientConstant(requestParameter.ClientDefaultValue, (FrameworkTypeReference) CreateType(requestParameter.Schema, requestParameter.IsNullable())) :
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

            Dictionary<string, ConstantOrParameter> parameters = new Dictionary<string, ConstantOrParameter>();
            List<QueryParameter> query = new List<QueryParameter>();
            List<RequestHeader> headers = new List<RequestHeader>();

            ConstantOrParameter? body = null;
            foreach (Parameter requestParameter in operation.Request.Parameters ?? Array.Empty<Parameter>())
            {
                string defaultName = requestParameter.Language.Default.Name;
                string serializedName = requestParameter.Language.Default.SerializedName ?? defaultName;
                ConstantOrParameter? constantOrParameter;

                switch (requestParameter.Schema)
                {
                    case ConstantSchema constant:
                        constantOrParameter = new ClientConstant(constant.Value.Value, (FrameworkTypeReference)CreateType(constant.ValueType, false));
                        break;
                    case BinarySchema _:
                        // skip
                        continue;
                    //TODO: Workaround for https://github.com/Azure/autorest.csharp/pull/275
                    case ArraySchema arraySchema when arraySchema.ElementType is ConstantSchema constantInnerType:
                        constantOrParameter = new ServiceClientMethodParameter(requestParameter.CSharpName(),
                            new CollectionTypeReference(CreateType(constantInnerType.ValueType, false)),
                            CreateDefaultValueConstant(requestParameter));
                        break;
                    //TODO: Workaround for https://github.com/Azure/autorest.csharp/pull/275
                    case DictionarySchema dictionarySchema when dictionarySchema.ElementType is ConstantSchema constantInnerType:
                        constantOrParameter = new ServiceClientMethodParameter(requestParameter.CSharpName(),
                            new CollectionTypeReference(CreateType(constantInnerType.ValueType, false)),
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
                    switch (httpParameter.In)
                    {
                        case ParameterLocation.Header:
                            headers.Add(new RequestHeader(serializedName, constantOrParameter.Value, ToHeaderFormat(requestParameter.Schema)));
                            break;
                        case ParameterLocation.Query:
                            query.Add(new QueryParameter(serializedName, constantOrParameter.Value, true));
                            break;
                        case ParameterLocation.Body:
                            body = constantOrParameter;
                            break;
                    }
                }

                parameters[defaultName] = constantOrParameter.Value;
            }


            if (httpRequest is HttpWithBodyRequest httpWithBodyRequest)
            {
                headers.AddRange(httpWithBodyRequest.MediaTypes.Select(mediaType => new RequestHeader("Content-Type", new ConstantOrParameter(StringConstant(mediaType)))));
            }

            var request = new ClientMethodRequest(
                httpRequest.Method.ToCoreRequestMethod() ?? RequestMethod.Get,
                ToParts(httpRequest.Uri, parameters),
                ToPathParts(httpRequest.Path, parameters),
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
                parameters.Values.Where(parameter => !parameter.IsConstant).Select(parameter => parameter.Parameter).ToArray(),
                responseType
            );
        }

        private static HeaderSerializationFormat ToHeaderFormat(Schema schema)
        {
            return schema switch
            {
                DateTimeSchema dateTimeSchema when dateTimeSchema.Format == DateTimeSchemaFormat.DateTime => HeaderSerializationFormat.DateTimeISO8601,
                DateSchema _ => HeaderSerializationFormat.Date,
                DateTimeSchema dateTimeSchema when dateTimeSchema.Format == DateTimeSchemaFormat.DateTimeRfc1123 => HeaderSerializationFormat.DateTimeRFC1123,
                _ => HeaderSerializationFormat.Default,
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

        private static PathSegment[] ToPathParts(string httpRequestUri, Dictionary<string, ConstantOrParameter> parameters)
        {
            List<PathSegment> host = new List<PathSegment>();
            foreach ((string text, bool isLiteral) in GetPathParts(httpRequestUri))
            {
                //TODO: WORKAROUND FOR https://github.com/Azure/autorest.modelerfour/issues/58
                if (!isLiteral && !parameters.ContainsKey(text))
                {
                    parameters[text] = StringConstant(text);
                }
                host.Add(new PathSegment(isLiteral ? StringConstant(text) : parameters[text], !isLiteral));
            }

            return host.ToArray();
        }

        private static int ToStatusCode(StatusCodes arg) => int.Parse(arg.ToString().Trim('_'));

        private static ClientConstant StringConstant(string s) => new ClientConstant(s, new FrameworkTypeReference(typeof(string)));

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
            return new ClientObjectConstant(property.CSharpName(), type, new ClientConstant(constantSchema.Value.Value, type));
        }

        private static ClientObjectProperty CreateProperty(Property property) =>
            new ClientObjectProperty(property.CSharpName(), CreateType(property.Schema, property.IsNullable()), property.Schema.IsLazy(), property.SerializedName);

        //TODO: Handle nullability properly
        private static ClientTypeReference CreateType(Schema schema, bool isNullable) => schema switch
        {
            BinarySchema _ => (ClientTypeReference)new BinaryTypeReference(false),
            ByteArraySchema _ => new BinaryTypeReference(false),
            //https://devblogs.microsoft.com/dotnet/do-more-with-patterns-in-c-8-0/
            { Type: AllSchemaTypes.Binary } => new BinaryTypeReference(false),
            ArraySchema array => new CollectionTypeReference(CreateType(array.ElementType, false)),
            DictionarySchema dictionary => new DictionaryTypeReference(new FrameworkTypeReference(typeof(string)), CreateType(dictionary.ElementType, isNullable)),
            _ when schema.Type.ToFrameworkCSharpType() is Type type => new FrameworkTypeReference(type, isNullable),
            _ => new SchemaTypeReference(schema, isNullable)
        };

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

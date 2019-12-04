// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoRest.CSharp.V3.ClientModel;
using AutoRest.CSharp.V3.CodeGen;
using AutoRest.CSharp.V3.JsonRpc.MessageModels;
using AutoRest.CSharp.V3.Pipeline;
using AutoRest.CSharp.V3.Pipeline.Generated;
using Azure.Core;

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

            // CodeModel for debugging
            await autoRest.WriteFile($"CodeModel-{configuration.Title}.yaml", codeModel.Serialize(), "source-file-csharp");

            return true;
        }

        private ServiceClient BuildClient(OperationGroup arg)
        {
            List<ClientMethod> methods = new List<ClientMethod>();
            foreach (Operation operation in arg.Operations)
            {
                var method = BuildMethod(operation);
                if (method != null)
                {
                    methods.Add(method);
                }
            }
            return new ServiceClient(arg.CSharpName(), methods.ToArray());
        }

        private ClientMethod? BuildMethod(Operation operation)
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
            List<KeyValuePair<string, ConstantOrParameter>> headers = new List<KeyValuePair<string, ConstantOrParameter>>();

            ConstantOrParameter? body = null;

            foreach (Parameter requestParameter in operation.Request.Parameters ?? Array.Empty<Parameter>())
            {
                string defaultName = requestParameter.Language.Default.Name;
                string serializedName = requestParameter.Language.Default.SerializedName ?? defaultName;
                ConstantOrParameter ? constantOrParameter;

                switch (requestParameter.Schema)
                {
                    case ConstantSchema constant:
                        constantOrParameter = new ClientConstant(constant.Value.Value, (FrameworkTypeReference) CreateType(constant.ValueType, false));
                        break;
                    case BinarySchema _:
                        // skip
                        continue;
                    default:
                        constantOrParameter = new ServiceClientMethodParameter(requestParameter.CSharpName(),
                            CreateType(requestParameter.Schema, requestParameter.IsNullable()),
                            requestParameter.ClientDefaultValue != null ?
                                new ClientConstant(requestParameter.ClientDefaultValue, new FrameworkTypeReference(typeof(object))) :
                                (ClientConstant?)null);
                        break;
                }

                if (requestParameter.Protocol.Http is HttpParameter httpParameter)
                {
                    switch (httpParameter.In)
                    {
                        case ParameterLocation.Header:
                            headers.Add(KeyValuePair.Create(serializedName, constantOrParameter.Value));
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
                foreach (string mediaType in httpWithBodyRequest.MediaTypes)
                {
                    headers.Add(KeyValuePair.Create("Content-Type", new ConstantOrParameter(StringConstant(mediaType))));
                }
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
                if (schemaResponse.Schema is ConstantSchema constantSchema)
                {
                    responseType = CreateType(constantSchema.ValueType, isNullable: false);
                }
                else
                {
                    responseType = CreateType(schemaResponse.Schema, isNullable: false);
                }
            }

            return new ClientMethod(
                operation.CSharpName(),
                request,
                parameters.Values.Where(parameter => !parameter.IsConstant).Select(parameter => parameter.Parameter).ToArray(),
                responseType
            );

        }

        private ConstantOrParameter[] ToParts(string httpRequestUri, Dictionary<string, ConstantOrParameter> parameters)
        {
            List<ConstantOrParameter> host = new List<ConstantOrParameter>();
            foreach ((string text, bool isLiteral) in GetPathParts(httpRequestUri))
            {
                host.Add(isLiteral ? StringConstant(text) : parameters[text]);
            }

            return host.ToArray();
        }

        private PathSegment[] ToPathParts(string httpRequestUri, Dictionary<string, ConstantOrParameter> parameters)
        {
            List<PathSegment> host = new List<PathSegment>();
            foreach ((string text, bool isLiteral) in GetPathParts(httpRequestUri))
            {
                // WORKAROUND FOR https://github.com/Azure/autorest.modelerfour/issues/58
                if (!isLiteral && !parameters.ContainsKey(text))
                {
                    parameters[text] = StringConstant(text);
                }
                host.Add(new PathSegment(isLiteral ? StringConstant(text) : parameters[text], !isLiteral));
            }

            return host.ToArray();
        }

        private int ToStatusCode(StatusCodes arg)
        {
            return int.Parse(arg.ToString().Trim('_'));
        }

        private ClientConstant StringConstant(string s)
        {
            return new ClientConstant(s, new FrameworkTypeReference(typeof(string)));
        }

        private ClientModel.ClientModel BuildModel(Schema schema)
        {
            switch (schema)
            {
                case SealedChoiceSchema sealedChoiceSchema:
                    return new ClientEnum(sealedChoiceSchema, sealedChoiceSchema.CSharpName(),
                        sealedChoiceSchema.Choices.Select(c => new ClientEnumValue(c.CSharpName(), StringConstant(c.Value))))
                    {
                        IsStringBased = false
                    };
                case ChoiceSchema choiceSchema:
                    return new ClientEnum(choiceSchema,  choiceSchema.CSharpName(),
                        choiceSchema.Choices.Select(c => new ClientEnumValue(c.CSharpName(), StringConstant(c.Value))))
                    {
                        IsStringBased = true
                    };
                case ObjectSchema objectSchema:
                    return new ClientObject(objectSchema, objectSchema.CSharpName(),
                        objectSchema.Properties.Where(property => !(property.Schema is ConstantSchema)).Select(CreateProperty),
                        objectSchema.Properties.Where(property => property.Schema is ConstantSchema).Select(CreateConstant));
            }

            throw new NotImplementedException();
        }

        private static ClientObjectConstant CreateConstant(Property property)
        {
            var constantSchema = (ConstantSchema)property.Schema;
            FrameworkTypeReference type = (FrameworkTypeReference)CreateType(constantSchema.ValueType, false);
            return new ClientObjectConstant(property.CSharpName(), type, new ClientConstant(constantSchema.Value.Value, type));
        }

        private static ClientObjectProperty CreateProperty(Property property)
        {
            return new ClientObjectProperty(property.CSharpName(), CreateType(property.Schema, property.IsNullable()), property.Schema.IsLazy(), property.SerializedName);
        }

        private static ClientTypeReference CreateType(Schema schema, bool isNullable)
        {
            switch (schema)
            {
                case BinarySchema _:
                case ByteArraySchema _:
                case Schema s when s.Type == AllSchemaTypes.Binary:
                    return new BinaryTypeReference(false);
                case ArraySchema array:
                    return new CollectionTypeReference(CreateType(array.ElementType, false));
                case DictionarySchema dictionary:
                    return new DictionaryTypeReference(new FrameworkTypeReference(typeof(string)), CreateType(dictionary.ElementType, isNullable));
                case Schema s when s.Type.ToFrameworkCSharpType() is Type type:
                    return new FrameworkTypeReference(type, isNullable);
                default:
                    return new SchemaTypeReference(schema, isNullable);
            }
        }

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

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
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

            var entities = schemas.Select(BuildEntity).ToArray();
            var typeProviders = entities.OfType<ISchemaTypeProvider>().ToArray();
            var typeFactory = new TypeFactory(configuration.Namespace, typeProviders);

            foreach (var entity in entities)
            {
                var name = entity.Name;
                var writer = new SchemaWriter(typeFactory);
                writer.WriteSchema(entity);

                var serializeWriter = new SerializationWriter(typeFactory);
                serializeWriter.WriteSerialization(entity);

                await autoRest.WriteFile($"Generated/Models/{name}.cs", writer.ToFormattedCode(), "source-file-csharp");
                await autoRest.WriteFile($"Generated/Models/{name}.Serialization.cs", serializeWriter.ToFormattedCode(), "source-file-csharp");
            }

            var clients = codeModel.OperationGroups.Select(BuildClient);
            foreach (var client in clients)
            {
                var writer = new OperationWriter(typeFactory);
                writer.WriteOperationGroup(client);
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

        //TODO: This is written very... code smelly. Clean up.
        private static IEnumerable<(string Text, bool IsLiteral)> GetPathParts(string path)
        {
            var index = 0;
            var currentPart = new List<char>();
            while (index < path.Length)
            {
                if (path[index] == '{')
                {
                    var innerPart = new List<char>();
                    var innerIndex = index + 1;
                    while (innerIndex < path.Length)
                    {
                        if (path[innerIndex] == '}')
                        {
                            var innerString = new string(innerPart.ToArray());
                            var pathParameter = innerString;
                            if (pathParameter != null)
                            {
                                if (currentPart.Any())
                                {
                                    yield return (new string(currentPart.ToArray()), true);
                                }

                                var name = pathParameter;
                                yield return (name ?? "[NO NAME]", false);
                                currentPart.Clear();
                                innerPart.Clear();
                                break;
                            }
                        }
                        innerPart.Add(path[innerIndex]);
                        innerIndex++;
                    }

                    if (innerPart.Any())
                    {
                        currentPart.Add('{');
                        currentPart.AddRange(innerPart);
                    }
                    index = innerIndex + 1;
                    continue;
                }
                currentPart.Add(path[index]);
                index++;
            }

            if (currentPart.Any())
            {
                yield return (new string(currentPart.ToArray()), true);
            }
        }

        private ClientMethod? BuildMethod(Operation operation)
        {
            var httpRequest = operation.Request.Protocol.Http as HttpRequest;
            var response = operation.Responses.FirstOrDefault();
            var httpResponse = response?.Protocol.Http as HttpResponse;

            Dictionary<string, ConstantOrParameter> parameters = new Dictionary<string, ConstantOrParameter>();

            List<KeyValuePair<string, ConstantOrParameter>> query = new List<KeyValuePair<string, ConstantOrParameter>>();
            List<KeyValuePair<string, ConstantOrParameter>> headers = new List<KeyValuePair<string, ConstantOrParameter>>();

            ConstantOrParameter? body = null;

            foreach (Parameter requestParameter in operation.Request.Parameters ?? Array.Empty<Parameter>())
            {
                string defaultName = requestParameter.Language.Default.SerializedName ?? requestParameter.Language.Default.Name;
                ConstantOrParameter? constantOrParameter;

                if (requestParameter.Schema is ConstantSchema constant)
                {
                    constantOrParameter = new ConstantOrParameter(new ClientConstant(constant.Value.Value, (FrameworkTypeReference) CreateType(constant.ValueType, false)));
                }
                else if (requestParameter.Schema is BinarySchema)
                {
                    // skip
                    continue;
                }
                else
                {
                    constantOrParameter = new ConstantOrParameter(new ServiceClientMethodParameter(
                        requestParameter.CSharpName(),
                        CreateType(requestParameter.Schema, requestParameter.IsNullable()),
                        requestParameter.ClientDefaultValue != null ?
                            new ClientConstant(requestParameter.ClientDefaultValue, new FrameworkTypeReference(typeof(object))) :
                            (ClientConstant?)null));

                }

                if (requestParameter.Protocol.Http is HttpParameter httpParameter)
                {
                    switch (httpParameter.In)
                    {
                        case ParameterLocation.Header:
                            headers.Add(KeyValuePair.Create(defaultName, constantOrParameter.Value));
                            break;
                        case ParameterLocation.Query:
                            query.Add(KeyValuePair.Create(defaultName, constantOrParameter.Value));
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

            List<ConstantOrParameter> host = new List<ConstantOrParameter>();
            List<ConstantOrParameter> uri = new List<ConstantOrParameter>();
            if (httpRequest != null)
            {
                foreach ((string text, bool isLiteral) in GetPathParts(httpRequest.Uri ?? string.Empty))
                {
                    if (isLiteral)
                    {
                        host.Add(new ConstantOrParameter(StringConstant(text)));
                    }
                    else
                    {
                        host.Add(parameters[text]);
                    }
                }

                foreach ((string text, bool isLiteral) in GetPathParts(httpRequest.Path ?? string.Empty))
                {
                    if (isLiteral)
                    {
                        uri.Add(new ConstantOrParameter(StringConstant(text)));
                    }
                    else
                    {
                        uri.Add(parameters[text]);
                    }
                }
                var request = new ClientMethodRequest(
                    httpRequest.Method.ToCoreRequestMethod() ?? RequestMethod.Get,
                    host.ToArray(),
                    uri.ToArray(),
                    query.ToArray(),
                    headers.ToArray(),
                    httpResponse?.StatusCodes.Select(ToStatusCode).ToArray() ?? Array.Empty<int>(),
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
                    parameters.Values.Where(p => !p.IsConstant).Select(p => p.Parameter).ToArray(),
                    responseType
                );
            }

            return null;
        }

        private int ToStatusCode(StatusCodes arg)
        {
            return int.Parse(arg.ToString().Trim('_'));
        }

        private ClientConstant StringConstant(string s)
        {
            return new ClientConstant(s, new FrameworkTypeReference(typeof(string)));
        }

        private ClientModel.ClientModel BuildEntity(Schema schema)
        {
            switch (schema)
            {
                case SealedChoiceSchema sealedChoiceSchema:
                    return new ClientEnum(sealedChoiceSchema,
                        sealedChoiceSchema.CSharpName(),
                        sealedChoiceSchema.Choices.Select(c => new ClientEnumValue(c.CSharpName(), new ClientConstant(c.Value, new FrameworkTypeReference(typeof(string))))))
                    {
                        IsStringBased = false
                    };
                case ChoiceSchema choiceSchema:
                    return new ClientEnum(choiceSchema,
                        choiceSchema.CSharpName(),
                        choiceSchema.Choices.Select(c => new ClientEnumValue(c.CSharpName(), new ClientConstant(c.Value, new FrameworkTypeReference(typeof(string))))))
                    {
                        IsStringBased = true
                    };
                case ObjectSchema objectSchema:
                    return new ClientObject(objectSchema, objectSchema.CSharpName(),
                        objectSchema.Properties.Where(p => !(p.Schema is ConstantSchema)).Select(CreateProperty),
                        objectSchema.Properties.Where(p=>p.Schema is ConstantSchema).Select(CreateConstant));
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
    }
}

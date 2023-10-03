// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Common.Input.Examples;
using AutoRest.CSharp.Common.Output.Builders;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input.Source;
using AutoRest.CSharp.Output.Builders;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Utilities;
using Microsoft.CodeAnalysis;
using Configuration = AutoRest.CSharp.Common.Input.Configuration;

namespace AutoRest.CSharp.Output.Models
{
    internal class DpgOutputLibraryBuilder
    {
        private const string MaxCountParameterName = "maxCount";

        private readonly InputNamespace _rootNamespace;
        private readonly SourceInputModel? _sourceInputModel;
        private readonly string _defaultNamespace;
        private readonly string _libraryName;

        public DpgOutputLibraryBuilder(InputNamespace rootNamespace, SourceInputModel? sourceInputModel)
        {
            _rootNamespace = rootNamespace;
            _sourceInputModel = sourceInputModel;
            _defaultNamespace = Configuration.Namespace;
            _libraryName = Configuration.LibraryName;
        }

        public DpgOutputLibrary Build(bool isTspInput)
        {
            var inputClients = UpdateOperations();

            var clientInfosByName = inputClients
                .Select(og => CreateClientInfo(og, _sourceInputModel, _rootNamespace.Name))
                .ToDictionary(ci => ci.Name);
            AssignParentClients(inputClients, clientInfosByName);
            var topLevelClientInfos = SetHierarchy(clientInfosByName);
            var clientOptions = CreateClientOptions(topLevelClientInfos);

            SetRequestsToClients(clientInfosByName.Values);

            var enums = new Dictionary<InputEnumType, EnumType>(InputEnumType.IgnoreNullabilityComparer);
            var models = new Dictionary<InputModelType, ModelTypeProvider>();
            var clients = new List<LowLevelClient>();

            var library = new DpgOutputLibrary(_libraryName, enums, models, clients, clientOptions, isTspInput, _sourceInputModel);

            if (isTspInput)
            {
                CreateModels(models, library.TypeFactory);
                CreateEnums(enums, models, library.TypeFactory);
            }
            CreateClients(clients, topLevelClientInfos, library.TypeFactory, clientOptions);

            return library;
        }

        private void CreateEnums(IDictionary<InputEnumType, EnumType> dictionary, IDictionary<InputModelType, ModelTypeProvider> models, TypeFactory typeFactory)
        {
            foreach (var inputEnum in _rootNamespace.Enums)
            {
                dictionary.Add(inputEnum, new EnumType(inputEnum, TypeProvider.GetDefaultModelNamespace(null, _defaultNamespace), "public", typeFactory, _sourceInputModel));
            }

            Dictionary<InputModelType, (InputModelProperty, InputEnumType)> enumsToReplace = new Dictionary<InputModelType, (InputModelProperty, InputEnumType)>();
            foreach (var model in models.Keys)
            {
                foreach (var property in model.Properties)
                {
                    if (property.Type is not InputUnionType union)
                        continue;

                    if (union.IsAllLiteralString() || union.IsAllLiteralStringPlusString())
                    {
                        string modelname = models[model].Type.Name;
                        InputEnumType inputEnum = new InputEnumType(
                            $"{modelname}{GetNameWithCorrectPluralization(union, property.Name)}",
                            model.Namespace,
                            model.Accessibility,
                            null,
                            $"Enum for {property.Name} in {modelname}",
                            model.Usage,
                            InputPrimitiveType.String,
                            union.GetEnum(),
                            true,
                            union.IsNullable);
                        enumsToReplace.Add(model, (property, inputEnum));
                        dictionary.Add(inputEnum, new EnumType(inputEnum, TypeProvider.GetDefaultModelNamespace(null, _defaultNamespace), "public", typeFactory, _sourceInputModel));
                    }
                }
            }

            foreach (var pair in enumsToReplace)
            {
                models[pair.Key] = models[pair.Key].ReplaceProperty(pair.Value.Item1, pair.Value.Item2);
            }
        }

        private void CreateModels(IDictionary<InputModelType, ModelTypeProvider> models, TypeFactory typeFactory)
        {
            Dictionary<string, ModelTypeProvider> defaultDerivedTypes = new Dictionary<string, ModelTypeProvider>();

            HashSet<string> createdNames = new HashSet<string>();
            Dictionary<InputModelType, InputModelType> replacements = new Dictionary<InputModelType, InputModelType>();
            foreach (var model in _rootNamespace.Models)
            {
                InputModelType[] derivedTypesArray = model.DerivedModels.ToArray();
                ModelTypeProvider? defaultDerivedType = GetDefaultDerivedType(models, typeFactory, model, derivedTypesArray, defaultDerivedTypes);

                InputModelType? replacement = null;
                if (model.IsAnonymousModel)
                {
                    var newName = GetAnonModelName(model, createdNames);
                    if (newName is not null)
                    {
                        var containingType = models.Keys.Where(m => m.GetProperty(model) is not null).First();
                        replacement = model.Update(newName, containingType.Usage);
                        createdNames.Add(replacement.Name);
                        replacements.Add(model, replacement);
                    }
                }

                var typeProvider = new ModelTypeProvider(replacement ?? model, TypeProvider.GetDefaultModelNamespace(null, _defaultNamespace), _sourceInputModel, typeFactory, derivedTypesArray, defaultDerivedType);
                models.Add(replacement ?? model, typeProvider);
            }

            foreach (var pair in replacements)
            {
                var modelsNeedingReplacement = GetAllReferences(pair.Key, models);
                foreach (var (modelContainingEnum, property) in modelsNeedingReplacement)
                {
                    models[modelContainingEnum] = models[modelContainingEnum].ReplaceProperty(property, pair.Value);
                }
            }
        }

        private Dictionary<InputModelType, InputModelProperty> GetAllReferences(InputModelType key, IDictionary<InputModelType, ModelTypeProvider> models)
        {
            var result = new Dictionary<InputModelType, InputModelProperty>();
            foreach (var pair in models)
            {
                var property = pair.Value.GetProperty(key);
                if (property is not null)
                {
                    result.Add(pair.Key, property);
                }
            }
            return result;
        }

        private string? GetAnonModelName(InputModelType anonModel, HashSet<string> createdNames)
        {
            List<List<string>> names = new List<List<string>>();
            //check operation parameters first
            foreach (var client in _rootNamespace.Clients)
            {
                foreach (var operation in client.Operations)
                {
                    foreach (var parameter in operation.Parameters)
                    {
                        if (IsSameType(parameter.Type, anonModel))
                        {
                            names.Add(new List<string> { operation.Name.ToCleanName(), GetNameWithCorrectPluralization(parameter.Type, parameter.Name).ToCleanName() });
                        }
                        else
                        {
                            FindMatchesRecursively(parameter.Type, anonModel, createdNames, new List<string>() { operation.Name.FirstCharToUpperCase(), parameter.Type.Name }, names);
                        }
                    }
                    foreach (var response in operation.Responses)
                    {
                        if (response is null || response.BodyType is null || response.BodyType is not InputModelType responseType)
                            continue;

                        if (IsSameType(responseType, anonModel))
                        {
                            names.Add(new List<string> { operation.Name.ToCleanName(), GetNameWithCorrectPluralization(responseType, responseType.Name).ToCleanName() });
                        }
                        else
                        {
                            FindMatchesRecursively(responseType, anonModel, createdNames, new List<string>() { operation.Name.FirstCharToUpperCase(), responseType.Name }, names);
                        }
                    }
                }
            }

            if (names.Count == 1)
            {
                var newName = $"{names[0][0]}{names[0][names[0].Count - 1].FirstCharToUpperCase()}";
                if (createdNames.Contains(newName))
                {
                    if (names[0].Count >= 2)
                    {
                        newName = $"{names[0][1].FirstCharToUpperCase()}{names[0][names[0].Count - 1].FirstCharToUpperCase()}";
                    }
                    else
                    {
                        newName = $"{names[0][0].FirstCharToUpperCase()}{names[0][names[0].Count - 1].FirstCharToUpperCase()}";
                    }
                }
                return newName;
            }

            return null;
        }

        private void FindMatchesRecursively(InputType type, InputModelType anonModel, HashSet<string> createdNames, List<string> current, List<List<string>> names)
        {
            InputModelType? model = GetInputModelType(type);

            if (model is null)
                return;

            //check other model properties
            foreach (var property in model.Properties)
            {
                if (IsSameType(property.Type, anonModel))
                {
                    names.Add(new List<string>(current) { GetNameWithCorrectPluralization(property.Type, property.Name).ToCleanName() });
                }
                else
                {
                    FindMatchesRecursively(property.Type, anonModel, createdNames, new List<string>(current) { property.Name }, names);
                }
            }
        }

        private InputModelType? GetInputModelType(InputType type) => type switch
        {
            InputModelType model => model,
            InputListType listType => GetInputModelType(listType.ElementType),
            InputDictionaryType dictionaryType => GetInputModelType(dictionaryType.ValueType),
            _ => null
        };

        private string GetNameWithCorrectPluralization(InputType type, string name)
        {
            //TODO: Probably needs special casing for ipThing to become IPThing
            string result = name.FirstCharToUpperCase();
            switch (type)
            {
                case InputListType:
                case InputDictionaryType:
                    return result.ToSingular();
                default:
                    return result;
            }
        }

        private bool IsSameType(InputType type, InputModelType anonModel)
        {
            switch (type)
            {
                case InputListType listType:
                    return IsSameType(listType.ElementType, anonModel);
                case InputDictionaryType dictionaryType:
                    return IsSameType(dictionaryType.ValueType, anonModel);
                default:
                    return type.Equals(anonModel);
            }
        }

        private ModelTypeProvider? GetDefaultDerivedType(IDictionary<InputModelType, ModelTypeProvider> models, TypeFactory typeFactory, InputModelType model, IReadOnlyList<InputModelType> derivedTypesArray, Dictionary<string, ModelTypeProvider> defaultDerivedTypes)
        {
            //only want to create one instance of the default derived per polymorphic set
            ModelTypeProvider? defaultDerivedType = null;
            bool isBasePolyType = model.DiscriminatorPropertyName is not null;
            bool isChildPolyType = model.DiscriminatorValue is not null;
            if (isBasePolyType || isChildPolyType)
            {
                InputModelType actualBase = isBasePolyType ? model : model.BaseModel!;

                //Since the unknown type is used for deserialization only we don't need to create if its an input only model
                if (!actualBase.Usage.HasFlag(InputModelTypeUsage.Output))
                    return null;

                string defaultDerivedName = $"Unknown{actualBase.Name}";
                if (!defaultDerivedTypes.TryGetValue(defaultDerivedName, out defaultDerivedType))
                {
                    //create the "Unknown" version
                    var unknownDerviedType = new InputModelType(
                        defaultDerivedName,
                        actualBase.Namespace,
                        "internal",
                        null,
                        $"Unknown version of {actualBase.Name}",
                        InputModelTypeUsage.Output,
                        Array.Empty<InputModelProperty>(),
                        actualBase,
                        Array.Empty<InputModelType>(),
                        "Unknown", //TODO: do we need to support extensible enum / int values?
                        null,
                        false)
                    {
                        IsUnknownDiscriminatorModel = true
                    };
                    defaultDerivedType = new ModelTypeProvider(unknownDerviedType, TypeProvider.GetDefaultModelNamespace(null, _defaultNamespace), _sourceInputModel, typeFactory, Array.Empty<InputModelType>(), null);
                    defaultDerivedTypes.Add(defaultDerivedName, defaultDerivedType);
                    models.Add(unknownDerviedType, defaultDerivedType);
                }
            }

            return defaultDerivedType;
        }

        private IEnumerable<InputClient> UpdateOperations()
        {
            var defaultName = _rootNamespace.Name.ReplaceLast("Client", "");
            // this map of old/new InputOperation is to update the lazy initialization of `Paging.NextLinkOperation`
            var operationsMap = new Dictionary<InputOperation, InputOperation>();
            foreach (var client in _rootNamespace.Clients)
            {
                var clientName = client.Name.IsNullOrEmpty() ? defaultName : client.Name;
                yield return client with { Operations = client.Operations.Select(op => UpdateOperation(op, clientName, operationsMap)).ToList() };
            }
        }

        private static InputOperation UpdateOperation(InputOperation operation, string clientName, IDictionary<InputOperation, InputOperation> operationsMap)
        {
            InputOperation updatedOperation;
            if (operation.Paging != null && !Configuration.DisablePaginationTopRenaming && !operation.Parameters.Any(p => p.Name.Equals(MaxCountParameterName, StringComparison.OrdinalIgnoreCase)))
            {
                updatedOperation = operation with
                {
                    Name = UpdateOperationName(operation, operation.ResourceName ?? clientName),
                    Parameters = UpdateOperationParameters(operation.Parameters),
                    // to update the lazy initialization of `Paging.NextLinkOperation`
                    Paging = operation.Paging with { NextLinkOperationRef = operation.Paging.NextLinkOperation != null ? () => operationsMap[operation.Paging.NextLinkOperation] : null }
                };
            }
            else
            {
                updatedOperation = operation with { Name = UpdateOperationName(operation, operation.ResourceName ?? clientName) };
            }
            operationsMap.Add(operation, updatedOperation);

            return updatedOperation;

        }

        private static string UpdateOperationName(InputOperation operation, string clientName)
            => operation.CleanName.RenameGetMethod(clientName).RenameListToGet(clientName);

        private static IReadOnlyList<InputParameter> UpdateOperationParameters(IReadOnlyList<InputParameter> operationParameters)
        {
            var parameters = new List<InputParameter>(operationParameters.Count);
            foreach (var parameter in operationParameters)
            {
                if (parameter.Name.Equals("top", StringComparison.OrdinalIgnoreCase))
                {
                    parameters.Add(parameter with { Name = MaxCountParameterName });
                }
                else
                {
                    parameters.Add(parameter);
                }
            }

            return parameters;
        }

        private ClientOptionsTypeProvider CreateClientOptions(IReadOnlyList<ClientInfo> topLevelClientInfos)
        {
            var clientName = topLevelClientInfos.Count == 1
                ? topLevelClientInfos[0].Name
                : topLevelClientInfos.SingleOrDefault(c => string.IsNullOrEmpty(c.OperationGroupKey))?.Name;

            var clientOptionsName = $"{ClientBuilder.GetClientPrefix(clientName ?? _libraryName, _rootNamespace.Name)}ClientOptions";
            var description = clientName != null
                ? (FormattableString)$"Client options for {clientName}."
                : $"Client options for {_libraryName} library clients.";

            IReadOnlyList<string>? apiVersions = _sourceInputModel?.GetServiceVersionOverrides() ?? _rootNamespace.ApiVersions;
            if (!Configuration.IsBranded)
            {
                if (apiVersions.Count > 1)
                    throw new InvalidOperationException("Multiple API versions are not supported in the unbranded path.");
                apiVersions = null;
            }
            return new ClientOptionsTypeProvider(apiVersions, clientOptionsName, _defaultNamespace, description, _sourceInputModel);
        }

        private static ClientInfo CreateClientInfo(InputClient ns, SourceInputModel? sourceInputModel, string rootNamespaceName)
        {
            var clientNamePrefix = ClientBuilder.GetClientPrefix(ns.Name, rootNamespaceName);
            var clientNamespace = Configuration.Namespace;
            var clientDescription = ns.Description;
            var operations = ns.Operations;
            var clientParameters = RestClientBuilder.GetParametersFromOperations(operations).ToList();
            var resourceParameters = clientParameters.Where(cp => cp.IsResourceParameter).ToHashSet();
            var isSubClient = Configuration.SingleTopLevelClient && !string.IsNullOrEmpty(ns.Name) || resourceParameters.Any() || !string.IsNullOrEmpty(ns.Parent);
            var clientName = isSubClient ? clientNamePrefix : clientNamePrefix + ClientBuilder.GetClientSuffix();

            INamedTypeSymbol? existingType;
            if (sourceInputModel == null || (existingType = sourceInputModel.FindForType(clientNamespace, clientName)) == null)
            {
                return new ClientInfo(ns.Name, clientName, clientNamespace, clientDescription, operations, clientParameters, resourceParameters, ns.Examples);
            }

            clientName = existingType.Name;
            clientNamespace = existingType.ContainingNamespace.ToDisplayString();
            return new ClientInfo(ns.Name, clientName, clientNamespace, clientDescription, existingType, operations, clientParameters, resourceParameters, ns.Examples);
        }

        private IReadOnlyList<ClientInfo> SetHierarchy(IReadOnlyDictionary<string, ClientInfo> clientInfosByName)
        {
            if (_sourceInputModel != null)
            {
                foreach (var clientInfo in clientInfosByName.Values)
                {
                    AssignParents(clientInfo, clientInfosByName, _sourceInputModel);
                }
            }

            var topLevelClients = clientInfosByName.Values.Where(c => c.Parent == null).ToList();
            if (!Configuration.SingleTopLevelClient || topLevelClients.Count == 1)
            {
                return topLevelClients;
            }

            var topLevelClientInfo = topLevelClients.FirstOrDefault(c => string.IsNullOrEmpty(c.OperationGroupKey));
            if (topLevelClientInfo == null)
            {
                var clientName = ClientBuilder.GetClientPrefix(_libraryName, _rootNamespace.Name) + ClientBuilder.GetClientSuffix();
                var clientNamespace = _defaultNamespace;
                var infoForEndpoint = topLevelClients.FirstOrDefault(c => c.ClientParameters.Any(p => p.IsEndpoint));
                var endpointParameter = infoForEndpoint?.ClientParameters.FirstOrDefault(p => p.IsEndpoint);
                var clientParameters = endpointParameter != null ? new[] { endpointParameter } : Array.Empty<InputParameter>();
                var clientExamples = infoForEndpoint?.Examples ?? new Dictionary<string, InputClientExample>();

                topLevelClientInfo = new ClientInfo(clientName, clientNamespace, clientParameters, clientExamples);
            }

            foreach (var clientInfo in topLevelClients)
            {
                if (clientInfo != topLevelClientInfo)
                {
                    clientInfo.Parent = topLevelClientInfo;
                    topLevelClientInfo.Children.Add(clientInfo);
                }
            }

            return new[] { topLevelClientInfo };
        }

        // assign parent according to the information in the input Model
        private static void AssignParentClients(in IEnumerable<InputClient> clients, IReadOnlyDictionary<string, ClientInfo> clientInfosByName)
        {
            foreach (var client in clients)
            {
                if (!String.IsNullOrEmpty(client.Parent))
                {
                    ClientInfo? targetClient = null;
                    ClientInfo? targetParent = null;
                    foreach (var info in clientInfosByName.Values)
                    {
                        if (info.OperationGroupKey == client.Name)
                            targetClient = info;
                        if (info.OperationGroupKey == client.Parent)
                            targetParent = info;
                    }
                    if (targetClient != null && targetParent != null)
                    {
                        targetClient.Parent = targetParent;
                        targetParent.Children.Add(targetClient);
                    }
                }
            }
        }

        //Assgin parent according to the customized inputModel
        private static void AssignParents(in ClientInfo clientInfo, IReadOnlyDictionary<string, ClientInfo> clientInfosByName, SourceInputModel sourceInputModel)
        {
            var child = clientInfo;
            while (child.Parent == null && child.ExistingType != null && sourceInputModel.TryGetClientSourceInput(child.ExistingType, out var clientSourceInput) && clientSourceInput.ParentClientType != null)
            {
                var parent = clientInfosByName[clientSourceInput.ParentClientType.Name];
                if (clientInfo == parent)
                {
                    throw new InvalidOperationException("loop");
                }

                child.Parent = parent;
                parent.Children.Add(child);
                child = parent;
            }
        }

        private static void SetRequestsToClients(IEnumerable<ClientInfo> clientInfos)
        {
            foreach (var clientInfo in clientInfos)
            {
                foreach (var operation in clientInfo.Operations)
                {
                    SetRequestToClient(clientInfo, operation);
                }
            }
        }

        private static void SetRequestToClient(ClientInfo clientInfo, InputOperation operation)
        {
            switch (clientInfo.ResourceParameters.Count)
            {
                case 1:
                    var requestParameter = clientInfo.ResourceParameters.Single();
                    if (operation.Parameters.Contains(requestParameter))
                    {
                        break;
                    }

                    while (clientInfo.Parent != null && clientInfo.ResourceParameters.Count != 0)
                    {
                        clientInfo = clientInfo.Parent;
                    }
                    break;
                case > 1:
                    var requestParameters = operation.Parameters.ToHashSet();
                    while (clientInfo.Parent != null && !clientInfo.ResourceParameters.IsSubsetOf(requestParameters))
                    {
                        clientInfo = clientInfo.Parent;
                    }

                    break;
            }

            clientInfo.Requests.Add(operation);
        }

        private void CreateClients(List<LowLevelClient> allClients, IEnumerable<ClientInfo> topLevelClientInfos, TypeFactory typeFactory, ClientOptionsTypeProvider clientOptions)
        {
            var topLevelClients = CreateClients(topLevelClientInfos, typeFactory, clientOptions, null);

            // Simple implementation of breadth first traversal
            allClients.AddRange(topLevelClients);
            for (int i = 0; i < allClients.Count; i++)
            {
                allClients.AddRange(allClients[i].SubClients);
            }
        }

        private IEnumerable<LowLevelClient> CreateClients(IEnumerable<ClientInfo> clientInfos, TypeFactory typeFactory, ClientOptionsTypeProvider clientOptions, LowLevelClient? parentClient)
        {
            foreach (var clientInfo in clientInfos)
            {
                var description = string.IsNullOrWhiteSpace(clientInfo.Description)
                    ? $"The {ClientBuilder.GetClientPrefix(clientInfo.Name, _rootNamespace.Name)} {(parentClient == null ? "service client" : "sub-client")}."
                    : BuilderHelpers.EscapeXmlDocDescription(clientInfo.Description);

                var subClients = new List<LowLevelClient>();

                if (!Configuration.IsBranded)
                {
                    for (int i = 0; i < clientInfo.Requests.Count; i++)
                    {
                        clientInfo.Requests[i] = InputOperation.RemoveApiVersionParam(clientInfo.Requests[i]);
                    }
                }

                var client = new LowLevelClient(
                    clientInfo.Name,
                    clientInfo.Namespace,
                    description,
                    _libraryName,
                    parentClient,
                    clientInfo.Requests,
                    clientInfo.ClientParameters,
                    _rootNamespace.Auth,
                    _sourceInputModel,
                    clientOptions,
                    clientInfo.Examples,
                    typeFactory)
                {
                    SubClients = subClients
                };

                subClients.AddRange(CreateClients(clientInfo.Children, typeFactory, clientOptions, client));

                yield return client;
            }
        }

        private class ClientInfo
        {
            public string OperationGroupKey { get; }
            public string Name { get; }
            public string Namespace { get; }
            public string Description { get; }
            public INamedTypeSymbol? ExistingType { get; }
            public IReadOnlyList<InputOperation> Operations { get; }

            private IReadOnlyDictionary<string, InputClientExample> _initialExamples;
            private IReadOnlyDictionary<string, InputClientExample>? _examples;
            public IReadOnlyDictionary<string, InputClientExample> Examples => _examples ??= EnsureExamples();

            private IReadOnlyDictionary<string, InputClientExample> EnsureExamples()
            {
                // pick up all examples from child client infos here, since we might promote some parameters from child clients
                var examples = new Dictionary<string, InputClientExample>();
                foreach (var (key, example) in _initialExamples)
                {
                    var clientParameterExamples = new List<InputParameterExample>(example.ClientParameters);
                    foreach (var child in Children)
                    {
                        if (child.Examples.TryGetValue(key, out var childExamples))
                        {
                            clientParameterExamples.AddRange(childExamples.ClientParameters);
                        }
                    }

                    examples.Add(key, new(example.Client, clientParameterExamples));
                }

                return examples;
            }

            private IReadOnlyList<InputParameter>? _clientParameters;
            private IReadOnlyList<InputParameter> _initClientParameters;
            public IReadOnlyList<InputParameter> ClientParameters => _clientParameters ??= EnsureClientParameters();

            private IReadOnlyList<InputParameter> EnsureClientParameters()
            {
                if (_initClientParameters.Count == 0)
                {
                    var endpointParameter = this.Children.SelectMany(c => c.ClientParameters).FirstOrDefault(p => p.IsEndpoint);
                    return endpointParameter != null ? new[] { endpointParameter } : Array.Empty<InputParameter>();
                }
                return _initClientParameters;
            }

            public ISet<InputParameter> ResourceParameters { get; }

            public ClientInfo? Parent { get; set; }
            public IList<ClientInfo> Children { get; }
            public IList<InputOperation> Requests { get; }

            public ClientInfo(string operationGroupKey, string clientName, string clientNamespace, string clientDescription, IReadOnlyList<InputOperation> operations, IReadOnlyList<InputParameter> clientParameters, ISet<InputParameter> resourceParameters, IReadOnlyDictionary<string, InputClientExample> examples)
                : this(operationGroupKey, clientName, clientNamespace, clientDescription, null, operations, clientParameters, resourceParameters, examples)
            {
            }

            public ClientInfo(string operationGroupKey, string clientName, string clientNamespace, string clientDescription, INamedTypeSymbol? existingType, IReadOnlyList<InputOperation> operations, IReadOnlyList<InputParameter> clientParameters, ISet<InputParameter> resourceParameters, IReadOnlyDictionary<string, InputClientExample> examples)
            {
                OperationGroupKey = operationGroupKey;
                Name = clientName;
                Namespace = clientNamespace;
                Description = clientDescription;
                ExistingType = existingType;
                Operations = operations;
                _initClientParameters = clientParameters;
                ResourceParameters = resourceParameters;
                Children = new List<ClientInfo>();
                Requests = new List<InputOperation>();
                _initialExamples = examples;
            }

            public ClientInfo(string clientName, string clientNamespace, IReadOnlyList<InputParameter> clientParameters, IReadOnlyDictionary<string, InputClientExample> examples)
            {
                OperationGroupKey = string.Empty;
                Name = clientName;
                Namespace = clientNamespace;
                Description = string.Empty;
                ExistingType = null;
                Operations = Array.Empty<InputOperation>();
                _initClientParameters = clientParameters;
                ResourceParameters = new HashSet<InputParameter>();
                Children = new List<ClientInfo>();
                Requests = new List<InputOperation>();
                _initialExamples = examples;
            }
        }
    }
}

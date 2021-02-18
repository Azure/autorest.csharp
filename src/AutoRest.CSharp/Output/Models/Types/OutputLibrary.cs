// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Responses;

namespace AutoRest.CSharp.Output.Models.Types
{
    internal class OutputLibrary
    {
        private readonly CodeModel _codeModel;
        private readonly BuildContext _context;
        private Dictionary<Schema, TypeProvider>? _models;
        private Dictionary<OperationGroup, Client>? _clients;
        private Dictionary<OperationGroup, RestClient>? _restClients;
        private Dictionary<OperationGroup, ResourceOperation>? _resourceOperations;
        private Dictionary<OperationGroup, ResourceContainer>? _resourceContainers;
        private Dictionary<Operation, LongRunningOperation>? _operations;
        private Dictionary<Operation, ResponseHeaderGroupType>? _headerModels;
        private const string Providers = "/providers/";

        public OutputLibrary(CodeModel codeModel, BuildContext context)
        {
            _codeModel = codeModel;
            _context = context;
            if (context.Configuration.AzureArm)
            {
                DecorateOperationGroup();
            }
        }

        public IEnumerable<TypeProvider> Models => SchemaMap.Values;

        public IEnumerable<RestClient> RestClients => EnsureRestClients().Values;

        public IEnumerable<ResourceOperation> ResourceOperations => EnsureResourceOperations().Values;

        public IEnumerable<ResourceContainer> ResourceContainers => EnsureResourceContainers().Values;

        public IEnumerable<Client> Clients => EnsureClients().Values;

        public IEnumerable<LongRunningOperation> LongRunningOperations => EnsureLongRunningOperations().Values;

        public IEnumerable<ResponseHeaderGroupType> HeaderModels => (_headerModels ??= EnsureHeaderModels()).Values;

        private Dictionary<Operation, ResponseHeaderGroupType> EnsureHeaderModels()
        {
            if (_headerModels != null)
            {
                return _headerModels;
            }

            _headerModels = new Dictionary<Operation, ResponseHeaderGroupType>();
            foreach (var operationGroup in _codeModel.OperationGroups)
            {
                foreach (var operation in operationGroup.Operations)
                {
                    var headers = ResponseHeaderGroupType.TryCreate(operationGroup, operation, _context);
                    if (headers != null)
                    {
                        _headerModels.Add(operation, headers);
                    }
                }
            }

            return _headerModels;
        }

        private Dictionary<Operation, LongRunningOperation> EnsureLongRunningOperations()
        {
            if (_operations != null)
            {
                return _operations;
            }

            _operations = new Dictionary<Operation, LongRunningOperation>();

            if (_context.Configuration.PublicClients)
            {
                foreach (var operationGroup in _codeModel.OperationGroups)
                {
                    foreach (var operation in operationGroup.Operations)
                    {
                        if (operation.IsLongRunning)
                        {
                            _operations.Add(operation, new LongRunningOperation(operationGroup, operation, _context));
                        }
                    }
                }
            }

            return _operations;
        }

        private Dictionary<OperationGroup, Client> EnsureClients()
        {
            if (_clients != null)
            {
                return _clients;
            }

            _clients = new Dictionary<OperationGroup, Client>();

            if (_context.Configuration.PublicClients)
            {
                foreach (var operationGroup in _codeModel.OperationGroups)
                {
                    _clients.Add(operationGroup, new Client(operationGroup, _context));
                }
            }

            return _clients;
        }

        private Dictionary<OperationGroup, RestClient> EnsureRestClients()
        {
            if (_restClients != null)
            {
                return _restClients;
            }

            _restClients = new Dictionary<OperationGroup, RestClient>();
            foreach (var operationGroup in _codeModel.OperationGroups)
            {
                _restClients.Add(operationGroup, new RestClient(operationGroup, _context));
            }

            return _restClients;
        }

        private Dictionary<OperationGroup, ResourceOperation> EnsureResourceOperations()
        {
            if (_resourceOperations != null)
            {
                return _resourceOperations;
            }

            _resourceOperations = new Dictionary<OperationGroup, ResourceOperation>();
            foreach (var operationGroup in _codeModel.OperationGroups)
            {
                _resourceOperations.Add(operationGroup, new ResourceOperation(operationGroup, _context));
            }

            return _resourceOperations;
        }

        private Dictionary<OperationGroup, ResourceContainer> EnsureResourceContainers()
        {
            if (_resourceContainers != null)
            {
                return _resourceContainers;
            }

            _resourceContainers = new Dictionary<OperationGroup, ResourceContainer>();
            foreach (var operationGroup in _codeModel.OperationGroups)
            {
                _resourceContainers.Add(operationGroup, new ResourceContainer(operationGroup, _context));
            }

            return _resourceContainers;
        }

        public TypeProvider FindTypeForSchema(Schema schema)
        {
            return SchemaMap[schema];
        }

        private Dictionary<Schema, TypeProvider> SchemaMap => _models ??= BuildModels();

        private Dictionary<Schema, TypeProvider> BuildModels()
        {
            var allSchemas = _codeModel.Schemas.Choices.Cast<Schema>()
                .Concat(_codeModel.Schemas.SealedChoices)
                .Concat(_codeModel.Schemas.Objects)
                .Concat(_codeModel.Schemas.Groups);

            return allSchemas.ToDictionary(schema => schema, BuildModel);
        }

        private TypeProvider BuildModel(Schema schema) => schema switch
        {
            SealedChoiceSchema sealedChoiceSchema => (TypeProvider)new EnumType(sealedChoiceSchema, _context),
            ChoiceSchema choiceSchema => new EnumType(choiceSchema, _context),
            ObjectSchema objectSchema => new ObjectType(objectSchema, _context),
            _ => throw new NotImplementedException()
        };

        public LongRunningOperation FindLongRunningOperation(Operation operation)
        {
            Debug.Assert(operation.IsLongRunning);

            return EnsureLongRunningOperations()[operation];
        }

        public Client? FindClient(OperationGroup operationGroup)
        {
            EnsureClients().TryGetValue(operationGroup, out var client);
            return client;
        }

        public RestClient FindRestClient(OperationGroup operationGroup)
        {
            return EnsureRestClients()[operationGroup];
        }

        public ResponseHeaderGroupType? FindHeaderModel(Operation operation)
        {
            EnsureHeaderModels().TryGetValue(operation, out var model);
            return model;
        }

        private void DecorateOperationGroup()
        {
            foreach (var operationsGroup in _codeModel.OperationGroups)
            {
                MapHttpMethodToOperation(operationsGroup);
                string? resourceType;
                operationsGroup.ResourceType = _context.Configuration.OperationGroupToResourceType.TryGetValue(operationsGroup.Key, out resourceType) ? resourceType : ConstructOperationResourseType(operationsGroup);
                operationsGroup.IsTenantResource = IsTenantOnly(MakeTokens(operationsGroup), operationsGroup.ResourceType);
            }
        }

        private void MapHttpMethodToOperation(OperationGroup operationsGroup)
        {
            operationsGroup.OperationHttpMethodMapping = new Dictionary<HttpMethod, List<ServiceRequest>>();
            foreach (var operation in operationsGroup.Operations)
            {
                foreach (var serviceRequest in operation.Requests)
                {
                    if (serviceRequest.Protocol.Http is HttpRequest httpRequest)
                    {
                        List<ServiceRequest>? list;
                        if (!operationsGroup.OperationHttpMethodMapping.TryGetValue(httpRequest.Method, out list))
                        {
                            list = new List<ServiceRequest>();
                            operationsGroup.OperationHttpMethodMapping.Add(httpRequest.Method, list);
                        }
                        list.Add(serviceRequest);
                    }
                }
            }
        }

        private string ConstructOperationResourseType(OperationGroup operationsGroup)
        {
            var method = GetBestMethod(operationsGroup);
            if (method == null)
            {
                throw new ArgumentException($@"Could not set ResourceType for operations group {operationsGroup.Key} 
                                            Please try setting this value for this operations in the readme.md for this swagger in the operation-group-mapping section");
            }
            var indexOfProvider = method.Path.IndexOf(Providers);
            if (indexOfProvider < 0)
            {
                throw new ArgumentException($"Could not set ResourceType for operations group {operationsGroup.Key}. No {Providers} string found in the URI");
            }
            var resourceType = ConstructResourceType(method.Path.Substring(indexOfProvider + Providers.Length));

            return resourceType.ToString().TrimEnd('/');
        }

        private static string ConstructResourceType(string httpRequestUri)
        {
            var returnString = new StringBuilder();
            var insideBrace = false;

            foreach (var ch in httpRequestUri)
            {
                if (ch == '{')
                {
                    insideBrace = true;
                }
                else if (ch == '}')
                {
                    insideBrace = false;
                }
                else if (!insideBrace)
                {
                    returnString.Append(ch);
                }
            }
            return returnString.ToString();
        }

        private HttpRequest? GetBestMethod(OperationGroup operationsGroup)
        {
            List<ServiceRequest>? requests;
            if (operationsGroup.OperationHttpMethodMapping.TryGetValue(HttpMethod.Put, out requests))
            {
                return (HttpRequest?)requests[0].Protocol?.Http;
            }
            if (operationsGroup.OperationHttpMethodMapping.TryGetValue(HttpMethod.Delete, out requests))
            {
                return (HttpRequest?)requests[0].Protocol?.Http;
            }
            if (operationsGroup.OperationHttpMethodMapping.TryGetValue(HttpMethod.Patch, out requests))
            {
                return (HttpRequest?)requests[0].Protocol?.Http;
            }
            return null;
        }

        public bool IsTenantOnly(List<List<ProviderToken>> tokens, string providerName)
        {
            bool foundTenant = false;
            bool foundNonTenant = false;
            for (int j = 0; j < tokens.Count && (!foundTenant || !foundNonTenant); j++)
            {
                var tokenList = tokens[j];
                for (int i = 0; i < tokenList.Count && (!foundTenant || !foundNonTenant); i++)
                {
                    var token = tokenList[i];
                    foundNonTenant = !foundNonTenant ? token.isFullProvider && !token.noPred && VerifyOperation(token.tokenValue, providerName) : true;
                    foundTenant = !foundTenant ? token.isFullProvider && token.noPred && VerifyOperation(token.tokenValue, providerName) : true;
                }
            }
            return foundTenant && !foundNonTenant;
        }

        public static List<ProviderToken> Tokenize(string path)
        {
            string canidate = "";
            var currentToken = new ProviderToken();
            string currentConstant = "";
            var tokens = new List<ProviderToken>();
            foreach (var ch in path)
            {
                if (ch == '{')
                {
                    if (canidate != "" && canidate != "/")
                    {
                        var asSplit = canidate.Split('/', StringSplitOptions.RemoveEmptyEntries);
                        if (asSplit.Length != 0 && asSplit.First().Equals("providers"))
                        {
                            currentToken.tokenValue = canidate;
                            currentToken.noPred = currentConstant == "";
                            currentToken.isFullProvider = asSplit.Length > 1;
                        }
                        currentConstant = canidate;
                    }
                    canidate = "";
                }
                else if (ch == '}')
                {
                    if (canidate != "" && currentToken.tokenValue != "")
                    {
                        currentToken.hasReferenceSuccessor = currentConstant == currentToken.tokenValue;
                        tokens.Add(currentToken);
                        currentToken = new ProviderToken();
                    }
                    currentToken.hadSpecialReference = !currentToken.hadSpecialReference ? currentToken.tokenValue == "" && currentConstant == "" : true;
                    canidate = "";
                }
                else
                {
                    canidate += ch;
                }
            }

            if (canidate != "" && canidate != "/")
            {
                var asSplit = canidate.Split('/', StringSplitOptions.RemoveEmptyEntries);
                if (asSplit.Length > 1 && asSplit.First().Equals("providers"))
                {
                    currentToken.noPred = currentConstant == "";
                    currentToken.isFullProvider = true;
                    currentToken.tokenValue = canidate;
                    tokens.Add(currentToken);
                }
            }
            return tokens;
        }

        public List<List<ProviderToken>> MakeTokens(OperationGroup operationsGroup)
        {
            List<List<ProviderToken>> tokens = new List<List<ProviderToken>>();

            foreach (var op in operationsGroup.Operations)
            {
                foreach (var serviceRequest in op.Requests)
                {
                    if (serviceRequest.Protocol.Http is HttpRequest httpRequest)
                    {
                        tokens.Add(Tokenize(httpRequest.Path));
                    }
                }
            }
            return tokens;
        }

        public bool VerifyOperation(string tokenValue, string providerName)
        {
            return tokenValue.Substring(Providers.Length).Equals(providerName);
        }
    }
}

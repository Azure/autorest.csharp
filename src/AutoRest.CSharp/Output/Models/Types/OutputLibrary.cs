// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Responses;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Output.Models.Serialization;

namespace AutoRest.CSharp.Output.Models.Types
{
    internal class OutputLibrary
    {
        private readonly CodeModel _codeModel;
        private readonly BuildContext _context;
        private Dictionary<Schema, TypeProvider>? _models;
        private Dictionary<OperationGroup, Client>? _clients;
        private Dictionary<OperationGroup, RestClient>? _restClients;
        private Dictionary<Operation, LongRunningOperation>? _operations;
        private Dictionary<Operation, ResponseHeaderGroupType>? _headerModels;

        private static readonly int ProviderOffset = "providers".Length + 2;

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
            foreach (var operations in _codeModel.OperationGroups)
            {
                operations.ProviderName = _context.Configuration.OperationGroupMapping.ContainsKey(operations.Key) ? _context.Configuration.OperationGroupMapping[operations.Key] : ConstructOperationProviderName(operations);
                operations.IsTenantResource = IsTenantOnly(MakeTokens(operations), operations.ProviderName);
            }
        }

        private string ConstructOperationProviderName(OperationGroup operations)
        {

            string? providerName = "";
            var request = GetBestMethod(operations);
            bool adding = false;
            if (request != null)
            {
                foreach (var segment in GetPathSegments(request.Path))
                {
                    var asSplit = segment.Split('/', StringSplitOptions.RemoveEmptyEntries);
                    if (asSplit?.Length > 1 && asSplit.First().Equals("providers"))
                    {
                        adding = true;
                        providerName = segment.Substring(ProviderOffset).TrimEnd('/');
                    }
                    else if (adding)
                    {
                        providerName += segment.TrimEnd('/');
                    }
                }
            }
            return providerName.TrimEnd('/');
        }
        private static List<string> GetPathSegments(string httpRequestUri)
        {
            List<string> seg = new List<string>();
            string canidate = "";

            foreach (var ch in httpRequestUri)
            {
                if (ch == '{')
                {
                    if (canidate != "" && canidate != "/")
                    {
                        seg.Add(canidate);
                    }
                    canidate = "";
                }
                else if (ch == '}')
                {
                    canidate = "";
                }
                else
                {
                    canidate += ch;
                }
            }
            if (canidate != "" && canidate != "/")
            {
                seg.Add(canidate);
            }
            return seg;
        }

        private HttpRequest? GetBestMethod(OperationGroup operations)
        {
            HttpRequest? canidate = null;
            foreach (var x in operations.Operations)
            {
                foreach (var serviceRequest in x.Requests)
                {
                    if (serviceRequest.Protocol.Http is HttpRequest httpRequest)
                    {
                        if (httpRequest.Method == HttpMethod.Put)
                        {
                            return httpRequest;
                        }
                        else if (httpRequest.Method == HttpMethod.Delete)
                        {
                            canidate = httpRequest;
                        }
                        else if (httpRequest.Method == HttpMethod.Patch)
                        {
                            canidate ??= httpRequest;
                        }
                    }
                }
            }
            return canidate;
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

        public List<List<ProviderToken>> MakeTokens(OperationGroup operations)
        {
            List<List<ProviderToken>> tokens = new List<List<ProviderToken>>();

            foreach (var op in operations.Operations)
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
            return tokenValue.Substring(ProviderOffset).Equals(providerName);
        }
    }
}

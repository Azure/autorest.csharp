// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Common.Output.Builders;
using AutoRest.CSharp.Common.Output.Models.Responses;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Input.Source;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Utilities;
using static AutoRest.CSharp.Output.Models.MethodSignatureModifiers;

namespace AutoRest.CSharp.Output.Models
{
    internal class LowLevelClient : TypeProvider
    {
        private readonly string _libraryName;
        private readonly TypeFactory _typeFactory;
        private readonly IEnumerable<InputParameter> _clientParameters;
        private readonly InputAuth _authorization;
        private readonly IEnumerable<InputOperation> _operations;

        protected override string DefaultName { get; }
        protected override string DefaultNamespace { get; }
        protected override string DefaultAccessibility => "public";

        private ConstructorSignature? _subClientInternalConstructor;

        public string Description { get; }
        public ConstructorSignature SubClientInternalConstructor => _subClientInternalConstructor ??= BuildSubClientInternalConstructor();

        public IReadOnlyList<LowLevelClient> SubClients { get; init; }
        public LowLevelClient? ParentClient;

        public ClientOptionsTypeProvider ClientOptions { get; }

        public bool IsSubClient { get; }

        private bool? _isResourceClient;
        public bool IsResourceClient => _isResourceClient ??= Parameters.Any(p => p.IsResourceIdentifier);

        public LowLevelClient(string name, string ns, string description, string libraryName, LowLevelClient? parentClient, IEnumerable<InputOperation> operations, IEnumerable<InputParameter> clientParameters, InputAuth authorization, SourceInputModel? sourceInputModel, ClientOptionsTypeProvider clientOptions, TypeFactory typeFactory)
            : base(ns, sourceInputModel)
        {
            _libraryName = libraryName;
            _typeFactory = typeFactory;
            DefaultName = name;
            DefaultNamespace = ns;
            Description = description;
            IsSubClient = parentClient != null;
            ParentClient = parentClient;

            ClientOptions = clientOptions;

            _clientParameters = clientParameters;
            _authorization = authorization;
            _operations = operations;

            SubClients = Array.Empty<LowLevelClient>();
        }

        private IReadOnlyList<Parameter>? _parameters;
        public IReadOnlyList<Parameter> Parameters => _parameters ??= new RestClientBuilder(_clientParameters, _typeFactory).GetOrderedParametersByRequired();

        private ClientFields? _fields;
        public ClientFields Fields => _fields ??= ClientFields.CreateForClient(Parameters, _authorization);

        private (ConstructorSignature[] PrimaryConstructors, ConstructorSignature[] SecondaryConstructors)? _constructors;
        private (ConstructorSignature[] PrimaryConstructors, ConstructorSignature[] SecondaryConstructors) Constructors => _constructors ??= BuildPublicConstructors(Parameters);
        public ConstructorSignature[] PrimaryConstructors => Constructors.PrimaryConstructors;
        public ConstructorSignature[] SecondaryConstructors => Constructors.SecondaryConstructors;

        private IReadOnlyList<LowLevelClientMethod>? _allClientMethods;
        private IReadOnlyList<LowLevelClientMethod> AllClientMethods => _allClientMethods ??= BuildMethods(_typeFactory, _operations, Fields, Declaration.Name).ToArray();

        private IReadOnlyList<LowLevelClientMethod>? _clientMethods;
        public IReadOnlyList<LowLevelClientMethod> ClientMethods => _clientMethods ??= AllClientMethods
                .OrderBy(m => m.LongRunning != null ? 2 : m.PagingInfo != null ? 1 : 0) // Temporary sorting to minimize amount of changed files. Will be removed when new LRO is implemented
                .ToArray();

        private IReadOnlyList<RestClientMethod>? _requestMethods;
        public IReadOnlyList<RestClientMethod> RequestMethods => _requestMethods ??= AllClientMethods.Select(m => m.RequestMethod)
                .Concat(ClientMethods.Select(m => m.PagingInfo?.NextPageMethod).WhereNotNull())
                .Distinct()
                .ToArray();

        private IReadOnlyList<ResponseClassifierType>? _responseClassifierTypes;
        public IReadOnlyList<ResponseClassifierType> ResponseClassifierTypes => _responseClassifierTypes ??= RequestMethods.Select(m => m.ResponseClassifierType).ToArray();

        private LowLevelSubClientFactoryMethod? _factoryMethod;
        public LowLevelSubClientFactoryMethod? FactoryMethod => _factoryMethod ??= ParentClient != null ? BuildFactoryMethod(ParentClient.Fields, _libraryName) : null;

        public static IEnumerable<LowLevelClientMethod> BuildMethods(TypeFactory typeFactory, IEnumerable<InputOperation> operations, ClientFields fields, string clientName)
        {
            var builders = operations.ToDictionary(o => o, o => new OperationMethodChainBuilder(o, clientName, fields, typeFactory));
            foreach (var (_, builder) in builders)
            {
                builder.BuildNextPageMethod(builders);
            }

            foreach (var (_, builder) in builders)
            {
                yield return builder.BuildOperationMethodChain();
            }
        }

        private (ConstructorSignature[] PrimaryConstructors, ConstructorSignature[] SecondaryConstructors) BuildPublicConstructors(IReadOnlyList<Parameter> orderedParameters)
        {
            if (!IsSubClient)
            {
                var requiredParameters = RestClientBuilder.GetRequiredParameters(orderedParameters).ToArray();
                var optionalParameters = RestClientBuilder.GetOptionalParameters(orderedParameters).Append(CreateOptionsParameter()).ToArray();

                return (
                    BuildPrimaryConstructors(requiredParameters, optionalParameters).ToArray(),
                    BuildSecondaryConstructors(requiredParameters, optionalParameters).ToArray()
                );
            }
            else
            {
                return (Array.Empty<ConstructorSignature>(), new[] { CreateMockingConstructor() });
            }
        }

        private IEnumerable<ConstructorSignature> BuildPrimaryConstructors(IReadOnlyList<Parameter> requiredParameters, IReadOnlyList<Parameter> optionalParameters)
        {
            var optionalToRequired = optionalParameters
                .Select(parameter => ClientOptions.Type.EqualsIgnoreNullable(parameter.Type)
                ? parameter with { DefaultValue = null, Validation = ValidationType.None }
                : parameter with
                {
                    DefaultValue = null,
                    Validation = parameter.Initializer != null ? Parameter.GetValidation(parameter.Type, parameter.RequestLocation, parameter.SkipUrlEncoding) : parameter.Validation,
                    Initializer = null
                }).ToArray();

            if (Fields.CredentialFields.Count == 0)
            {
                yield return CreatePrimaryConstructor(requiredParameters.Concat(optionalToRequired).ToArray());
            }
            else
            {
                foreach (var credentialField in Fields.CredentialFields)
                {
                    yield return CreatePrimaryConstructor(requiredParameters.Append(CreateCredentialParameter(credentialField!.Type)).Concat(optionalToRequired).ToArray());
                }
            }
        }

        private IEnumerable<ConstructorSignature> BuildSecondaryConstructors(IReadOnlyList<Parameter> requiredParameters, IReadOnlyList<Parameter> optionalParameters)
        {
            if (requiredParameters.Any() || Fields.CredentialFields.Any())
            {
                yield return CreateMockingConstructor();
            }

            var optionalParametersArguments = optionalParameters
                .Select(p => p.Initializer ?? p.Type.GetParameterInitializer(p.DefaultValue!.Value)!)
                .ToArray();

            if (Fields.CredentialFields.Count == 0)
            {
                yield return CreateSecondaryConstructor(requiredParameters, optionalParametersArguments);
            }
            else
            {
                foreach (var credentialField in Fields.CredentialFields)
                {
                    yield return CreateSecondaryConstructor(requiredParameters.Append(CreateCredentialParameter(credentialField!.Type)).ToArray(), optionalParametersArguments);
                }
            }
        }

        private ConstructorSignature CreatePrimaryConstructor(IReadOnlyList<Parameter> parameters)
            => new(Declaration.Name, $"Initializes a new instance of {Declaration.Name}", null, Public, parameters);

        private ConstructorSignature CreateSecondaryConstructor(IReadOnlyList<Parameter> parameters, FormattableString[] optionalParametersArguments)
        {
            var arguments = parameters
                .Select<Parameter, FormattableString>(p => $"{p.Name}")
                .Concat(optionalParametersArguments)
                .ToArray();
            return new(Declaration.Name, $"Initializes a new instance of {Declaration.Name}", null, Public, parameters, Initializer: new ConstructorInitializer(false, arguments));
        }

        private Parameter CreateCredentialParameter(CSharpType type)
        {
            return new Parameter(
                "credential",
                "A credential used to authenticate to an Azure Service.",
                type,
                null,
                ValidationType.AssertNotNull,
                null);
        }

        private ConstructorSignature CreateMockingConstructor()
            => new(Declaration.Name, $"Initializes a new instance of {Declaration.Name} for mocking.", null, Protected, Array.Empty<Parameter>());

        private Parameter CreateOptionsParameter()
        {
            var clientOptionsType = ClientOptions.Type.WithNullable(true);
            return new Parameter("options", "The options for configuring the client.", clientOptionsType, Constant.Default(clientOptionsType), ValidationType.None, Constant.NewInstanceOf(clientOptionsType).GetConstantFormattable());
        }

        private ConstructorSignature BuildSubClientInternalConstructor()
        {
            var constructorParameters = GetSubClientFactoryMethodParameters()
                .Select(p => p with { DefaultValue = null, Validation = ValidationType.None, Initializer = null })
                .ToArray();

            return new ConstructorSignature(Declaration.Name, $"Initializes a new instance of {Declaration.Name}", null, Internal, constructorParameters);
        }

        public LowLevelSubClientFactoryMethod BuildFactoryMethod(ClientFields parentFields, string libraryName)
        {
            var constructorCallParameters = GetSubClientFactoryMethodParameters().ToArray();
            var methodParameters = constructorCallParameters.Where(p => parentFields.GetFieldByParameter(p) == null).ToArray();

            var subClientName = Type.Name;
            var methodName = subClientName.StartsWith(libraryName)
                ? subClientName[libraryName.Length..]
                : subClientName;

            if (!IsResourceClient)
            {
                methodName += ClientBuilder.GetClientSuffix();
            }

            var methodSignature = new MethodSignature($"Get{methodName}",
                $"Initializes a new instance of {Type.Name}", null, Public | Virtual, Type, null,
                methodParameters.ToArray());
            FieldDeclaration? cachingField = methodParameters.Any()
                ? null
                : new FieldDeclaration(FieldModifiers.Private, this.Type, $"_cached{Type.Name}");

            return new LowLevelSubClientFactoryMethod(methodSignature, cachingField, constructorCallParameters);
        }

        private IEnumerable<Parameter> GetSubClientFactoryMethodParameters()
            => new[] { KnownParameters.ClientDiagnostics, KnownParameters.Pipeline, KnownParameters.KeyAuth, KnownParameters.TokenAuth }
                .Concat(RestClientBuilder.GetConstructorParameters(Parameters, null, includeAPIVersion: true))
                .Where(p => Fields.GetFieldByParameter(p) != null);
    }
}

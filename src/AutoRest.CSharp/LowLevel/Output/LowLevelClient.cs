// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Common.Output.Builders;
using AutoRest.CSharp.Common.Output.Models.Responses;
using AutoRest.CSharp.Common.Output.Models.ValueExpressions;
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
        protected override string DefaultName { get; }
        protected override string DefaultNamespace { get; }
        protected override string DefaultAccessibility => "public";

        private ConstructorSignature? _subClientInternalConstructor;

        public string Description { get; }
        public ConstructorSignature[] PrimaryConstructors { get; }
        public ConstructorSignature[] SecondaryConstructors { get; }
        public ConstructorSignature SubClientInternalConstructor => _subClientInternalConstructor ??= BuildSubClientInternalConstructor();

        public IReadOnlyList<LowLevelClient> SubClients { get; init; }
        public IReadOnlyList<RestClientMethod> RequestMethods { get; }
        public IReadOnlyList<ResponseClassifierType> ResponseClassifierTypes { get; }
        public IReadOnlyList<LowLevelClientMethod> ClientMethods { get; }
        public LowLevelClient? ParentClient;
        public LowLevelSubClientFactoryMethod? FactoryMethod { get; }

        public ClientOptionsTypeProvider ClientOptions { get; }
        public IReadOnlyList<Parameter> Parameters { get; }
        public ClientFields Fields { get; }
        public bool IsSubClient { get; }
        public bool IsResourceClient { get; }

        public LowLevelClient(string name, string ns, string description, string libraryName, LowLevelClient? parentClient, IEnumerable<InputOperation> operations, IReadOnlyList<Parameter> clientParameters, InputAuth authorization, SourceInputModel? sourceInputModel, ClientOptionsTypeProvider clientOptions, TypeFactory typeFactory)
            : base(ns, sourceInputModel)
        {
            DefaultName = name;
            DefaultNamespace = ns;
            Description = description;
            IsSubClient = parentClient != null;
            ParentClient = parentClient;

            ClientOptions = clientOptions;

            Parameters = clientParameters;
            IsResourceClient = Parameters.Any(p => p.IsResourceIdentifier);
            Fields = ClientFields.CreateForClient(Parameters, authorization);

            (PrimaryConstructors, SecondaryConstructors) = BuildPublicConstructors(Parameters);

            var methods = BuildMethods(typeFactory, operations, Fields, Declaration.Name);

            // Temporary sorting to minimize amount of changes.
            ClientMethods = methods
                .OrderBy(b => b.IsLongRunning ? 2 : b.IsPaging ? 1 : 0)
                .ToArray();

            // Temporary sorting to minimize amount of changes.
            RequestMethods = methods.Select(m => m.RequestMethods[0])
                .Concat(ClientMethods.Where(m => m.RequestMethods.Count == 2).Select(m => m.RequestMethods[1]))
                .ToArray();

            ResponseClassifierTypes = RequestMethods.Select(m => m.ResponseClassifierType).Distinct().ToArray();

            FactoryMethod = parentClient != null ? BuildFactoryMethod(parentClient.Fields, libraryName) : null;

            SubClients = Array.Empty<LowLevelClient>();
        }

        public static IReadOnlyList<LowLevelClientMethod> BuildMethods(TypeFactory typeFactory, IEnumerable<InputOperation> operations, ClientFields fields, string clientName)
        {
            var operationParameters = new Dictionary<InputOperation, MethodParametersBuilder>();
            foreach (var inputOperation in operations)
            {
                var builder = new MethodParametersBuilder(typeFactory, inputOperation);
                builder.BuildDpg();
                operationParameters[inputOperation] = builder;
            }

            var methods = new List<LowLevelClientMethod>();
            foreach (var (operation, parametersBuilder) in operationParameters)
            {
                var createNextPageMessageMethodParameters = operation.Paging is { NextLinkOperation: { } nextLinkOperation }
                    ? operationParameters[nextLinkOperation].CreateMessageParameters
                    : operation.Paging is { NextLinkName: {} }
                        ? parametersBuilder.CreateMessageParameters.Prepend(KnownParameters.NextLink).ToArray()
                        : Array.Empty<Parameter>();

                var methodBuilder = new OperationMethodsBuilder(operation, null, fields, clientName, typeFactory, parametersBuilder.RequestParts, parametersBuilder.CreateMessageParameters, createNextPageMessageMethodParameters, parametersBuilder.ParameterLinks);
                methods.Add(methodBuilder.BuildDpg());
            }

            return methods;
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
                ? parameter with { DefaultValue = null, Validation = Validation.None }
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
                .Select(p => (ValueExpression)new FormattableStringToExpression(p.Initializer ?? p.Type.GetParameterInitializer(p.DefaultValue!.Value)!))
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

        private ConstructorSignature CreateSecondaryConstructor(IReadOnlyList<Parameter> parameters, ValueExpression[] optionalParametersArguments)
        {
            var arguments = parameters
                .Select<Parameter, ValueExpression>(p => p)
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
                Validation.AssertNotNull,
                null);
        }

        private ConstructorSignature CreateMockingConstructor()
            => new(Declaration.Name, $"Initializes a new instance of {Declaration.Name} for mocking.", null, Protected, Array.Empty<Parameter>());

        private Parameter CreateOptionsParameter()
        {
            var clientOptionsType = ClientOptions.Type.WithNullable(true);
            return new Parameter("options", "The options for configuring the client.", clientOptionsType, Constant.Default(clientOptionsType), Validation.None, Constant.NewInstanceOf(clientOptionsType).GetConstantFormattable());
        }

        private ConstructorSignature BuildSubClientInternalConstructor()
        {
            var constructorParameters = GetSubClientFactoryMethodParameters()
                .Select(p => p with { DefaultValue = null, Validation = Validation.None, Initializer = null })
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

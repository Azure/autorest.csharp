﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Common.Input.Examples;
using AutoRest.CSharp.Common.Output.Builders;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Common.Output.Models.Responses;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Input.Source;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Utilities;
using Microsoft.CodeAnalysis;
using static AutoRest.CSharp.Output.Models.MethodSignatureModifiers;

namespace AutoRest.CSharp.Output.Models
{
    internal class DpgClient : TypeProvider
    {
        protected override string DefaultName { get; }
        protected override string DefaultNamespace { get; }
        protected override string DefaultAccessibility => "public";

        private readonly TypeFactory _typeFactory;
        private ConstructorSignature? _subClientInternalConstructor;

        public string Description { get; }
        public ConstructorSignature[] PrimaryConstructors { get; }
        public ConstructorSignature[] SecondaryConstructors { get; }
        public ConstructorSignature SubClientInternalConstructor => _subClientInternalConstructor ??= BuildSubClientInternalConstructor();

        public DpgClient TopLevelClient { get; }
        public IReadOnlyList<DpgClient> SubClients { get; init; }
        public IReadOnlyList<ResponseClassifierType> ResponseClassifierTypes { get; }
        public IReadOnlyList<RestClientOperationMethods> OperationMethods { get; }
        public DpgClient? ParentClient;
        public LowLevelSubClientFactoryMethod? FactoryMethod { get; }

        public ClientOptionsTypeProvider ClientOptions { get; }
        public IReadOnlyList<Parameter> Parameters { get; }
        public ClientFields Fields { get; }
        public bool IsSubClient { get; }
        public bool IsResourceClient { get; }

        public DpgClient(string name, string ns, string key, string description, string libraryName, DpgClient? parentClient, IEnumerable<InputOperation> operations, IReadOnlyList<Parameter> clientParameters, IReadOnlyList<InputClientExample> clientExamples, InputAuth authorization, SourceInputModel? sourceInputModel, ClientOptionsTypeProvider clientOptions, TypeFactory typeFactory)
            : base(ns, sourceInputModel)
        {
            DefaultName = name;
            DefaultNamespace = ns;
            Description = description;
            IsSubClient = parentClient != null;
            ParentClient = parentClient;

            TopLevelClient = GetTopLevelClient(this);

            _typeFactory = typeFactory;

            ClientOptions = clientOptions;

            //we should not overload the concept of parameters.  ApiVersion is never a parameter for a client and should be treated differently.
            //by adding it in the parameters we have to make sure we treat it differently in all places that loop over the parameter list.
            Parameters = Configuration.IsBranded ? clientParameters : clientParameters.Where(p => !p.IsApiVersionParameter).ToArray();
            IsResourceClient = Parameters.Any(p => p.IsResourceIdentifier);
            Fields = ClientFields.CreateForClient(Parameters, authorization);
            FactoryMethod = parentClient != null ? BuildFactoryMethod(parentClient.Fields, libraryName) : null;

            (PrimaryConstructors, SecondaryConstructors) = BuildPublicConstructors(Parameters);

            OperationMethods = new ClientMethodsBuilder(operations, null, sourceInputModel, typeFactory)
                .Build(Fields, new DpgOperationSampleBuilder(this, clientExamples, ExistingType), Declaration.Name, Declaration.Namespace, key)
                .ToList();

            ResponseClassifierTypes = OperationMethods.Select(rm => rm.ResponseClassifier).Distinct().ToArray();

            SubClients = Array.Empty<DpgClient>();
        }

        private static DpgClient GetTopLevelClient(DpgClient candidate)
        {
            while (candidate.ParentClient != null)
            {
                candidate = candidate.ParentClient;
            }
            return candidate;
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
                /* order the constructor parameters as (endpoint, required parameters, optional parameters) */
                yield return CreatePrimaryConstructor(requiredParameters.Concat(optionalToRequired).OrderBy(p => !p.IsEndpoint).ToArray());
            }
            else
            {
                foreach (var credentialField in Fields.CredentialFields)
                {
                    /* order the constructor parameters as (endpoint, required parameters, credential, optional parameters) */
                    yield return CreatePrimaryConstructor(requiredParameters.Append(CreateCredentialParameter(credentialField.Type)).Concat(optionalToRequired).OrderBy(p => !p.IsEndpoint).ToArray());
                }
            }
        }

        private IEnumerable<ConstructorSignature> BuildSecondaryConstructors(IReadOnlyList<Parameter> requiredParameters, IReadOnlyList<Parameter> optionalParameters)
        {
            if (requiredParameters.Any() || Fields.CredentialFields.Any())
            {
                yield return CreateMockingConstructor();
            }

            /* Construct the parameter arguments to call primitive constructor.
             * In primitive constructor, the endpoint is the first parameter,
             * so put the endpoint as the first parameter argument if the endpoint is optional parameter.
             * */
            var optionalParametersArguments = optionalParameters
                .Where(p => !p.IsEndpoint)
                .Select(p => p.Initializer ?? Parameter.GetParameterInitializer(p.Type, p.DefaultValue!.Value)!)
                .ToArray();

            var optionalEndpoint = optionalParameters.FirstOrDefault(p => p.IsEndpoint);
            var arguments = new List<ValueExpression>();
            if (optionalEndpoint != null)
            {
                arguments.Add(optionalEndpoint.Initializer ?? Parameter.GetParameterInitializer(optionalEndpoint.Type, optionalEndpoint.DefaultValue!.Value)!);
            }

            arguments.AddRange(requiredParameters.Select(requiredParameter => (ValueExpression)requiredParameter));

            if (Fields.CredentialFields.Count == 0)
            {
                var allArguments = arguments.Concat(optionalParametersArguments);
                yield return CreateSecondaryConstructor(requiredParameters, allArguments.ToArray());
            }
            else
            {
                foreach (var credentialField in Fields.CredentialFields)
                {
                    var credentialParameter = CreateCredentialParameter(credentialField.Type);
                    var allArguments = arguments.Append(credentialParameter).Concat(optionalParametersArguments);
                    yield return CreateSecondaryConstructor(requiredParameters.Append(credentialParameter).ToArray(), allArguments.ToArray());
                }
            }
        }

        private ConstructorSignature CreatePrimaryConstructor(IReadOnlyList<Parameter> parameters)
            => new(Type, $"Initializes a new instance of {Declaration.Name}", null, Public, parameters);

        private ConstructorSignature CreateSecondaryConstructor(IReadOnlyList<Parameter> parameters, ValueExpression[] arguments)
        {
            return new(Type, $"Initializes a new instance of {Declaration.Name}", null, Public, parameters, Initializer: new ConstructorInitializer(false, arguments));
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
            => new(Type, $"Initializes a new instance of {Declaration.Name} for mocking.", null, Protected, Array.Empty<Parameter>());

        private Parameter CreateOptionsParameter()
        {
            var clientOptionsType = ClientOptions.Type.WithNullable(true);
            return new Parameter("options", "The options for configuring the client.", clientOptionsType, Constant.Default(clientOptionsType), Validation.None, new ConstantExpression(Constant.NewInstanceOf(clientOptionsType)));
        }

        private ConstructorSignature BuildSubClientInternalConstructor()
        {
            var constructorParameters = GetSubClientFactoryMethodParameters()
                .Select(p => p with { DefaultValue = null, Validation = Validation.None, Initializer = null })
                .ToArray();

            return new ConstructorSignature(Type, $"Initializes a new instance of {Declaration.Name}", null, Internal, constructorParameters);
        }

        private LowLevelSubClientFactoryMethod BuildFactoryMethod(ClientFields parentFields, string libraryName)
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
                .Concat(RestClientBuilder.GetConstructorParameters(Parameters, null, includeAPIVersion: true).OrderBy(p => !p.IsEndpoint))
                .Where(p => Fields.GetFieldByParameter(p) != null);

        internal MethodSignatureBase? GetEffectiveCtor()
        {
            //TODO: This method is needed because we allow roslyn code gen attributes to be run AFTER the writers do their job but before
            //      the code is emitted. This is a hack to allow the writers to know what the effective ctor is after the roslyn code gen attributes

            List<ConstructorSignature> candidates = new(SecondaryConstructors.Where(c => c.Modifiers == MethodSignatureModifiers.Public));

            if (ExistingType is null)
            {
                return candidates.MinBy(c => c.Parameters.Count);
            }

            //    [CodeGenSuppress("ConfidentialLedgerCertificateClient", typeof(Uri), typeof(TokenCredential), typeof(ConfidentialLedgerClientOptions))]
            //remove suppressed ctors from the candidates
            foreach (var attribute in ExistingType.GetAttributes().Where(a => a.AttributeClass is not null && a.AttributeClass.Name == "CodeGenSuppressAttribute"))
            {
                if (attribute.ConstructorArguments.Length != 2)
                    continue;
                var classTarget = attribute.ConstructorArguments[0].Value;
                if (classTarget is null || !classTarget.Equals(DefaultName))
                    continue;

                candidates.RemoveAll(ctor => IsParamMatch(ctor.Parameters, attribute.ConstructorArguments[1].Values.Select(tc => (INamedTypeSymbol)(tc.Value!)).ToArray()));
            }

            // add custom ctors into the candidates
            foreach (var existingCtor in ExistingType.Constructors)
            {
                var parameters = existingCtor.Parameters;
                var modifiers = GetModifiers(existingCtor);
                bool isPublic = modifiers.HasFlag(Public);
                //TODO: Currently skipping ctors which use models from the library due to constructing with all empty lists.
                if (!isPublic || parameters.Length == 0 || parameters.Any(p => ((INamedTypeSymbol)p.Type).GetCSharpType(_typeFactory) == null))
                {
                    if (!isPublic)
                        candidates.RemoveAll(ctor => IsParamMatch(ctor.Parameters, existingCtor.Parameters.Select(p => (INamedTypeSymbol)p.Type).ToArray()));
                    continue;
                }
                var ctor = new ConstructorSignature(
                    Type,
                    FormattableStringHelpers.FromString(GetSummaryPortion(existingCtor.GetDocumentationCommentXml())),
                    null,
                    modifiers,
                    parameters.Select(p => new Parameter(p.Name, p.GetDocumentationCommentXml(), ((INamedTypeSymbol)p.Type).GetCSharpType(_typeFactory)!, null, Validation.None, null)).ToArray(),
                    null);
                candidates.Add(ctor);
            }

            return candidates.MinBy(c => c.Parameters.Count);
        }

        private string? GetSummaryPortion(string? xmlComment)
        {
            if (xmlComment is null)
                return null;

            ReadOnlySpan<char> span = xmlComment.AsSpan();
            int start = span.IndexOf("<summary>");
            if (start == -1)
                return null;
            start += 9;
            int end = span.IndexOf("</summary>");
            if (end == -1)
                return null;
            return span.Slice(start, end - start).Trim().ToString();
        }

        private bool IsParamMatch(IReadOnlyList<Parameter> methodParameters, INamedTypeSymbol[] suppressionParameters)
        {
            if (methodParameters.Count != suppressionParameters.Length)
                return false;

            for (int i = 0; i < methodParameters.Count; i++)
            {
                if (!suppressionParameters[i].IsSameType(methodParameters[i].Type))
                    return false;
            }

            return true;
        }

        private MethodSignatureModifiers GetModifiers(IMethodSymbol existingCtor)
        {
            MethodSignatureModifiers result = GetAccessModifier(existingCtor.DeclaredAccessibility);
            if (existingCtor.IsStatic)
            {
                result |= Static;
            }
            if (existingCtor.IsVirtual)
            {
                result |= Virtual;
            }
            return result;
        }

        private static MethodSignatureModifiers GetAccessModifier(Accessibility declaredAccessibility) => declaredAccessibility switch
        {
            Accessibility.Public => Public,
            Accessibility.Protected => Protected,
            Accessibility.Internal => Internal,
            _ => Private
        };

        internal bool IsMethodSuppressed(MethodSignatureBase signature)
        {
            if (ExistingType is null)
                return false;

            //[CodeGenSuppress("GetTests", typeof(string), typeof(string), typeof(DateTimeOffset?), typeof(DateTimeOffset?), typeof(int?), typeof(RequestContext))]
            //remove suppressed ctors from the candidates
            foreach (var attribute in ExistingType.GetAttributes().Where(a => a.AttributeClass is not null && a.AttributeClass.Name == "CodeGenSuppressAttribute"))
            {
                if (attribute.ConstructorArguments.Length != 2)
                    continue;
                var methodTarget = attribute.ConstructorArguments[0].Value;
                if (methodTarget is null || !methodTarget.Equals(signature.Name))
                    continue;

                if (IsParamMatch(signature.Parameters, attribute.ConstructorArguments[1].Values.Select(tc => (INamedTypeSymbol)(tc.Value!)).ToArray()))
                    return true;
            }

            return false;
        }
    }
}
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Common.Output.Models;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Mgmt.Models;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Utilities;
using Azure.ResourceManager;

namespace AutoRest.CSharp.Mgmt.Output
{
    internal class MgmtExtension : MgmtTypeProvider
    {
        public override bool IsStatic => IsArmCore ? false : true; // explicitly expand this for readability

        private readonly IEnumerable<Operation> _allRawOperations;

        public MgmtExtension(IEnumerable<Operation> allRawOperations, IEnumerable<MgmtMockingExtension> mockingExtensions, Type armCoreType, RequestPath? contextualPath = null)
            : base(armCoreType.Name)
        {
            _allRawOperations = allRawOperations;
            _mockingExtensions = mockingExtensions; // this property is populated later
            ArmCoreType = armCoreType;
            DefaultName = Configuration.MgmtConfiguration.IsArmCore ? ResourceName : $"{ResourceName}Extensions";
            DefaultNamespace = Configuration.MgmtConfiguration.IsArmCore ? ArmCoreType.Namespace! : base.DefaultNamespace;
            Description = Configuration.MgmtConfiguration.IsArmCore ? (FormattableString)$"" : $"A class to add extension methods to {ResourceName}.";
            ContextualPath = contextualPath ?? RequestPath.GetContextualPath(armCoreType);
            ArmCoreNamespace = ArmCoreType.Namespace!;
            ChildResources = !Configuration.MgmtConfiguration.IsArmCore || ArmCoreType.Namespace != MgmtContext.Context.DefaultNamespace ? base.ChildResources : Enumerable.Empty<Resource>();
            ExtensionParameter = new Parameter(
                VariableName,
                $"The <see cref=\"{ArmCoreType}\" /> instance the method will execute against.",
                ArmCoreType,
                null,
                ValidationType.None,
                null);

            MethodModifiers = IsArmCore ?
                MethodSignatureModifiers.Public | MethodSignatureModifiers.Virtual :
                MethodSignatureModifiers.Public | MethodSignatureModifiers.Static | MethodSignatureModifiers.Extension;
        }

        protected override ConstructorSignature? EnsureMockingCtor()
        {
            return IsArmCore ? null : base.EnsureMockingCtor();
        }

        public override FormattableString BranchIdVariableName => $"{ExtensionParameter.Name}.Id";

        public Parameter ExtensionParameter { get; }

        protected virtual string VariableName => Configuration.MgmtConfiguration.IsArmCore ? "this" : ArmCoreType.Name.ToVariableName();

        public override CSharpType? BaseType => null;

        public override FormattableString Description { get; }

        public Type ArmCoreType { get; }

        public string ArmCoreNamespace { get; }

        protected override string DefaultName { get; }

        protected override string DefaultNamespace { get; }

        public RequestPath ContextualPath { get; }

        public override IEnumerable<Resource> ChildResources { get; }

        public virtual bool IsEmpty => !ClientOperations.Any() && !ChildResources.Any();

        protected internal override CSharpType TypeAsResource => ArmCoreType;

        protected override IEnumerable<FieldDeclaration> EnsureFieldDeclaration()
        {
            yield break;
        }

        protected override IEnumerable<MgmtClientOperation> EnsureClientOperations()
        {
            var extensionParamToUse = Configuration.MgmtConfiguration.IsArmCore ? null : ExtensionParameter;
            return _allRawOperations.Select(operation =>
            {
                var operationName = GetOperationName(operation, ResourceName);
                // TODO -- these logic needs a thorough refactor -- the values MgmtRestOperation consumes here are actually coupled together
                // some of the values are calculated multiple times (here and in writers).
                // we just leave this implementation here since it could work for now
                return MgmtClientOperation.FromOperation(
                    new MgmtRestOperation(
                        operation,
                        operation.GetRequestPath(),
                        ContextualPath,
                        operationName,
                        propertyBagName: ResourceName),
                    BranchIdVariableName,
                    extensionParamToUse);
            });
        }

        public string GetOperationName(Operation operation) => GetOperationName(operation, ResourceName);

        protected override string CalculateOperationName(Operation operation, string clientResourceName)
        {
            var operationName = base.CalculateOperationName(operation, clientResourceName);

            if (MgmtContext.Library.GetRestClientMethod(operation).IsListMethod(out var itemType) && itemType.TryCastResourceData(out var data))
            {
                var requestPath = operation.GetRequestPath();
                // we need to find the correct resource type that links with this resource data
                var resource = FindResourceFromResourceData(data, requestPath);
                if (resource != null)
                {
                    var extraLayers = GetExtraLayers(requestPath, resource);
                    if (!extraLayers.Any())
                        return $"Get{resource.ResourceName.ResourceNameToPlural()}";
                    var suffix = string.Join("", extraLayers.Select(segment => segment.ConstantValue.FirstCharToUpperCase().LastWordToSingular()));
                    return $"Get{resource.ResourceName.ResourceNameToPlural()}By{suffix}";
                }
            }

            return operationName;
        }

        private IEnumerable<Segment> GetExtraLayers(RequestPath requestPath, Resource resource)
        {
            var rawType = ResourceTypeSegment.ParseRequestPath(requestPath);
            var segmentsInResourceType = new HashSet<Segment>(resource.ResourceType);
            // compare and find the new segments in rawType
            return rawType.Where(segment => segment.IsConstant && !segmentsInResourceType.Contains(segment));
        }

        // This piece of logic is duplicated in MgmtExtensionWriter, to be refactored
        private Resource? FindResourceFromResourceData(ResourceData data, RequestPath requestPath)
        {
            // we need to find the correct resource type that links with this resource data
            var candidates = MgmtContext.Library.FindResources(data);

            // return null when there is no match
            if (!candidates.Any())
                return null;

            // when we only find one result, just return it.
            if (candidates.Count() == 1)
                return candidates.Single();

            // if there is more candidates than one, we are going to some more matching to see if we could determine one
            var resourceType = requestPath.GetResourceType();
            var filteredResources = candidates.Where(resource => resource.ResourceType == resourceType);

            if (filteredResources.Count() == 1)
                return filteredResources.Single();

            return null;
        }

        private Method? _mockingExtensionFactoryMethod;
        public Method MockingExtensionFactoryMethod => _mockingExtensionFactoryMethod ??= BuildMockingExtensionFactoryMethod();

        protected virtual Method BuildMockingExtensionFactoryMethod()
        {
            var signature = new MethodSignature(
                MockingExtension.FactoryMethodName,
                null,
                null,
                MethodSignatureModifiers.Private | MethodSignatureModifiers.Static,
                MockingExtension.Type,
                null,
                new[] { _generalExtensionParameter });

            var extensionVariable = (ValueExpression)_generalExtensionParameter;
            var clientVariable = new VariableReference(typeof(ArmClient), "client");
            var body = Snippets.Return(
                extensionVariable.Invoke(
                    nameof(ArmResource.GetCachedClient),
                    new FuncExpression(new[] { clientVariable.Declaration }, Snippets.New.Instance(MockingExtension.Type, clientVariable, extensionVariable.Property(nameof(ArmResource.Id))))
                ));

            return new(signature, body);
        }

        private readonly Parameter _generalExtensionParameter = new Parameter(
            "resource",
            $"The resource parameters to use in these operations.",
            typeof(ArmResource),
            null,
            ValidationType.None,
            null);

        public MgmtMockingExtension MockingExtension => Cache[ArmCoreType];

        private readonly IEnumerable<MgmtMockingExtension> _mockingExtensions;

        private Dictionary<CSharpType, MgmtMockingExtension>? _cache;
        private Dictionary<CSharpType, MgmtMockingExtension> Cache => _cache ??= _mockingExtensions.ToDictionary(
            extensionClient => extensionClient.ExtendedResourceType,
            extensionClient => extensionClient);

        /// <summary>
        /// Build the implementation of methods in the extension.
        /// It calls the factory method of the mocking extension first, and then calls the method wtih the same name and parameter list on the mocking extension
        /// </summary>
        /// <param name="signature"></param>
        /// <param name="isAsync"></param>
        /// <returns></returns>
        protected Method BuildRedirectCallToMockingExtension(MethodSignature signature, bool isAsync)
        {
            var callFactoryMethod = new InvokeInstanceMethodExpression(null, (MethodSignature)MockingExtensionFactoryMethod.Signature, new[] { (ValueExpression)signature.Parameters[0] }, false);

            var signatureOnMockingExtension = signature.WithAsync(false) with
            {
                Modifiers = MethodSignatureModifiers.Public | MethodSignatureModifiers.Virtual,
                Parameters = signature.Parameters.Skip(1).ToArray()
            };
            var callMethodOnMockingExtension = callFactoryMethod.Invoke(signatureOnMockingExtension.WithAsync(isAsync));

            var methodBody = Snippets.Return(callMethodOnMockingExtension);

            return new(signature, methodBody);
        }

        protected override Method BuildGetSingletonResourceMethod(Resource resource)
        {
            var originalMethod = base.BuildGetSingletonResourceMethod(resource);
            if (IsArmCore)
                return originalMethod;

            // if it not arm core, we should generate these methods in a static extension way
            var originalSignature = (MethodSignature)originalMethod.Signature;
            var signature = originalSignature with
            {
                Parameters = originalSignature.Parameters.Prepend(ExtensionParameter).ToArray()
            };

            return BuildRedirectCallToMockingExtension(signature, false);
        }

        protected override Method BuildGetChildCollectionMethod(ResourceCollection collection)
        {
            var originalMethod = base.BuildGetChildCollectionMethod(collection);
            if (IsArmCore)
                return originalMethod;

            // if it not arm core, we should generate these methods in a static extension way
            var originalSignature = (MethodSignature)originalMethod.Signature;
            var signature = originalSignature with
            {
                Parameters = originalSignature.Parameters.Prepend(ExtensionParameter).ToArray()
            };

            return BuildRedirectCallToMockingExtension(signature, false);
        }

        protected override Method BuildGetChildResourceMethod(ResourceCollection collection, MethodSignatureBase getCollectionMethodSignature, bool isAsync)
        {
            var originalMethod = base.BuildGetChildResourceMethod(collection, getCollectionMethodSignature, isAsync);
            if (IsArmCore)
                return originalMethod;

            // if it not arm core, we should generate these methods in a static extension way
            return BuildRedirectCallToMockingExtension((MethodSignature)originalMethod.Signature, isAsync);
        }
    }
}

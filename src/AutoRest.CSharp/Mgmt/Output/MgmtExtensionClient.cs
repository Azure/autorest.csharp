// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Mgmt.Models;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Utilities;
using Azure.Core;
using Azure.ResourceManager;
using static AutoRest.CSharp.Output.Models.MethodSignatureModifiers;

namespace AutoRest.CSharp.Mgmt.Output
{
    internal class MgmtExtensionClient : MgmtTypeProvider
    {
        private readonly IEnumerable<MgmtClientOperation> _operations;
        private readonly MgmtExtension? _extensionForChildResources;

        public MgmtExtensionClient(CSharpType resourceType, IEnumerable<MgmtClientOperation> operations, MgmtExtension? extensionForChildResources)
            : base(resourceType.Name)
        {
            _operations = operations;
            _extensionForChildResources = extensionForChildResources;
            ExtendedResourceType = resourceType;
            DefaultName = $"{resourceType.Name}Extension";
        }

        public override bool IsInitializedByProperties => true;

        public override bool HasChildResourceGetMethods => false;

        protected override ConstructorSignature? EnsureArmClientCtor()
        {
            return new ConstructorSignature(
                Name: Type.Name,
                Summary: null,
                Description: $"Initializes a new instance of the <see cref=\"{Type.Name}\"/> class.",
                Modifiers: Internal,
                Parameters: new[] { ArmClientParameter, ResourceIdentifierParameter },
                Initializer: new(
                    isBase: true,
                    arguments: new[] { ArmClientParameter, ResourceIdentifierParameter }));
        }

        private string? _factoryMethodName;
        public string FactoryMethodName => _factoryMethodName ??= $"Get{Declaration.Name}";

        private IEnumerable<MgmtExtensionClientFactoryMethod>? _factoryMethods;
        public IEnumerable<MgmtExtensionClientFactoryMethod> FactoryMethods => _factoryMethods ??= EnsureFactoryMethods();

        private IEnumerable<MgmtExtensionClientFactoryMethod> EnsureFactoryMethods()
        {
            var resourceExtensionMethod = new MethodSignature(
                FactoryMethodName,
                null,
                null,
                Private | Static,
                Type,
                null,
                new[] { _generalExtensionParameter });
            Action<CodeWriter> resourceExtensionMethodBody = writer =>
            {
                using (writer.Scope($"return {_generalExtensionParameter.Name}.GetCachedClient(client =>", newLine: false))
                {
                    writer.Line($"return new {Type}(client, {_generalExtensionParameter.Name}.Id);");
                }
                writer.LineRaw(");");
            };
            yield return new(resourceExtensionMethod, resourceExtensionMethodBody);

            var scopeExtensionMethod = new MethodSignature(
                FactoryMethodName,
                null,
                null,
                Private | Static,
                Type,
                null,
                new[] { ArmClientParameter, _scopeParameter });
            Action<CodeWriter> scopeExtensionMethodBody = writer =>
            {
                using (writer.Scope($"return {ArmClientParameter.Name}.GetResourceClient(() => ", newLine: false))
                {
                    writer.Line($"return new {Type}({ArmClientParameter.Name}, {_scopeParameter.Name});");
                }
                writer.LineRaw(");");
            };
            yield return new(scopeExtensionMethod, scopeExtensionMethodBody);
        }

        private Parameter _generalExtensionParameter = new Parameter(
            "resource",
            $"The resource parameters to use in these operations.",
            typeof(ArmResource),
            null,
            ValidationType.None,
            null);

        private Parameter _scopeParameter = new Parameter(
            "scope",
            $"The scope to use in these operations",
            typeof(ResourceIdentifier),
            null,
            ValidationType.None,
            null);

        protected override IEnumerable<MgmtClientOperation> EnsureClientOperations()
        {
            // here we have to capsulate the MgmtClientOperation again to remove the extra "extension parameter" we added when constructing them in MgmtExtension.EnsureClientOperations
            // and here we need to regroup the MgmtRestOperation in these MgmtClientOperation in case there are method name collisions
            var operationDict = new Dictionary<string, List<MgmtRestOperation>>();
            foreach (var operation in _operations)
            {
                foreach (var restOperation in operation)
                    operationDict.AddInList(operation.Name, restOperation);
            }

            foreach (var (_, operations) in operationDict)
            {
                yield return MgmtClientOperation.FromOperations(operations)!;
            }
        }

        public override ResourceTypeSegment GetBranchResourceType(RequestPath branch)
        {
            return branch.GetResourceType();
        }

        protected override string CalculateOperationName(Operation operation, string clientResourceName)
        {
            return base.CalculateOperationName(operation, clientResourceName);
        }

        public CSharpType ExtendedResourceType { get; }

        public override CSharpType? BaseType => typeof(ArmResource);

        protected override string DefaultName { get; }

        protected override string DefaultNamespace => $"{base.DefaultNamespace}.Mock";

        public bool IsEmpty => !ClientOperations.Any() && !ChildResources.Any();

        public override IEnumerable<Resource> ChildResources => _extensionForChildResources?.ChildResources ?? Enumerable.Empty<Resource>();

        private FormattableString? _description;
        public override FormattableString Description => _description ??= $"A class to add extension methods to {ResourceName}.";

        protected override string DefaultAccessibility => "public";
    }

    internal record MgmtExtensionClientFactoryMethod(MethodSignature Signature, Action<CodeWriter> MethodBodyImplementation);
}

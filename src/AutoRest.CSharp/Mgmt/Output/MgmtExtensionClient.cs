// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Mgmt.AutoRest;
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
            // name of this class is like "ComputeResourceGroupResourceExtension"
            DefaultName = GetExtensionClientDefaultName(resourceType.Name);
        }

        private static string GetExtensionClientDefaultName(string resourceName)
        {
            // trim the Resource suffix if it has one. Actually it should always have one, eg, SubscriptionResource, ResourceGroupResource, etc.
            // an exception for this is ArmResource, we would not like to trim this suffix
            if (resourceName.EndsWith("Resource") && resourceName != "ArmResource")
            {
                resourceName = resourceName[..^8];
            }

            return $"{MgmtContext.RPName}{resourceName}MockingExtension";
        }

        public override bool IsInitializedByProperties => true;

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

            // only ArmResourceExtensionClient needs this factory method
            if (ExtendedResourceType.Equals(typeof(ArmResource)))
            {
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
            // and here we need to regroup these MgmtClientOperations when they cannot be overloard of each other
            var operationDict = new Dictionary<string, List<MgmtClientOperation>>();
            foreach (var operation in _operations)
            {
                operationDict.AddInList(GetMgmtClientOperationKey(operation.MethodSignature), operation);
            }

            foreach (var (_, operations) in operationDict)
            {
                yield return MgmtClientOperation.FromOperations(operations.SelectMany(clientOperation => clientOperation).ToList())!;
            }
        }

        public override ResourceTypeSegment GetBranchResourceType(RequestPath branch)
        {
            return branch.GetResourceType();
        }

        public CSharpType ExtendedResourceType { get; }

        public override CSharpType? BaseType => typeof(ArmResource);

        protected override string DefaultName { get; }
        protected override string DefaultNamespace => $"{base.DefaultNamespace}.Mocking";

        public override string DiagnosticNamespace => base.DefaultNamespace;

        public bool IsEmpty => !ClientOperations.Any() && !ChildResources.Any();

        public override IEnumerable<Resource> ChildResources => _extensionForChildResources?.ChildResources ?? Enumerable.Empty<Resource>();

        private FormattableString? _description;
        public override FormattableString Description => _description ??= $"A class to add extension methods to {ResourceName}.";

        protected override string DefaultAccessibility => "public";

        /// <summary>
        /// Construct a key for overload of this method signature.
        /// The format of this key is like "MethodName(TypeOfParamter1,TypeOfParamter2,...,TypeOfLastParameter)"
        /// </summary>
        /// <param name="methodSignature"></param>
        /// <returns></returns>
        private static string GetMgmtClientOperationKey(MethodSignature methodSignature)
        {
            var builder = new StringBuilder();
            builder.Append(methodSignature.Name).Append("(");
            // all methods here should be extension methods, therefore we skip the first parameter which is the extension method parameter "this" and in this context, it is actually myself
            builder.AppendJoin(',', methodSignature.Parameters.Skip(1).Select(p => p.Type.ToString()));
            builder.Append(")");

            return builder.ToString();
        }
    }

    internal record MgmtExtensionClientFactoryMethod(MethodSignature Signature, Action<CodeWriter> MethodBodyImplementation);
}

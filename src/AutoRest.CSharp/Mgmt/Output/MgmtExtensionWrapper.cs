// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Common.Output.Models;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Models;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;
using Azure.Core;
using Azure.ResourceManager;
using static AutoRest.CSharp.Output.Models.MethodSignatureModifiers;

namespace AutoRest.CSharp.Mgmt.Output
{
    /// <summary>
    /// MgmtExtensionsWrapper is a wrapper of all the <see cref="MgmtExtension"/>, despite the <see cref="MgmtExtension"/> is inheriting from <see cref="MgmtTypeProvider"/>, currently it will not produce a class in the generated code.
    /// In ArmCore, we will not use this class because Azure.ResourceManager does not need to generate extension classes, we just need to generate partial classes to extend them because those "to be extended" types are defined in Azure.ResourceManager.
    /// In other packages, we need this TypeProvider to generate one big extension class that contains all the extension methods.
    /// </summary>
    internal class MgmtExtensionWrapper : MgmtTypeProvider
    {
        public IEnumerable<MgmtExtension> Extensions { get; }

        public IEnumerable<MgmtExtensionClient> ExtensionClients { get; }

        public override bool IsStatic => true;

        public bool IsEmpty => Extensions.All(extension => extension.IsEmpty);

        public MgmtExtensionWrapper(IEnumerable<MgmtExtension> extensions, IEnumerable<MgmtExtensionClient> extensionClients) : base(MgmtContext.RPName)
        {
            DefaultName = $"{ResourceName}Extensions";
            Description = Configuration.MgmtConfiguration.IsArmCore ? (FormattableString)$"" : $"A class to add extension methods to {MgmtContext.Context.DefaultNamespace}.";
            Extensions = extensions;
            ExtensionClients = extensionClients;
        }

        public override CSharpType? BaseType => null;

        public override FormattableString Description { get; }

        protected override string DefaultName { get; }

        protected override string DefaultAccessibility => "public";

        protected override IEnumerable<MgmtClientOperation> EnsureClientOperations()
        {
            foreach (var extension in Extensions)
            {
                foreach (var operation in extension.ClientOperations)
                {
                    yield return operation;
                }
            }
        }

        protected override IEnumerable<Method> BuildMethods()
        {
            yield break;
        }

        private IEnumerable<Method>? _clientFactoryMethods;
        public IEnumerable<Method> ClientFactoryMethods => _clientFactoryMethods ??= BuildClientFactoryMethods();

        private IEnumerable<Method> BuildClientFactoryMethods()
        {
            var clientArgument = new VariableReference(typeof(ArmClient), "client");
            var clientParameter = (ValueExpression)ArmClientParameter;
            var extensionParameter = (ValueExpression)_generalExtensionParameter;
            foreach (var client in ExtensionClients)
            {
                if (client.IsEmpty)
                    continue;

                var factoryMethodName = $"Get{client.Declaration.Name}";

                var resourceExtensionMethod = new MethodSignature(
                    factoryMethodName,
                    null,
                    null,
                    Private | Static,
                    client.Type,
                    null,
                    new[] { _generalExtensionParameter });
                var resourceExtensionMethodBody = Snippets.Return(
                    extensionParameter.Invoke(
                            nameof(ArmResource.GetCachedClient),
                            new FuncExpression(new[] { clientArgument.Declaration }, Snippets.New.Instance(client.Type, clientArgument, extensionParameter.Property(nameof(ArmResource.Id))))
                    )); // TODO -- update FuncExpression to make it could accept a block

                yield return new(resourceExtensionMethod, resourceExtensionMethodBody);

                var scopeExtensionMethod = new MethodSignature(
                    factoryMethodName,
                    null,
                    null,
                    Private | Static,
                    client.Type,
                    null,
                    new[] { ArmClientParameter, _scopeParameter });
                var scopeExtensionMethodBody = Snippets.Return(
                    clientParameter.Invoke(
                        nameof(ArmClient.GetResourceClient),
                        new FuncExpression(Array.Empty<CodeWriterDeclaration>(), Snippets.New.Instance(client.Type, clientParameter, _scopeParameter))
                    ));

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
    }
}

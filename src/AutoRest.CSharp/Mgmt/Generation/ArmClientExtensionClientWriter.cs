// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Mgmt.Models;
using AutoRest.CSharp.Mgmt.Output;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Utilities;
using Azure.Core;

namespace AutoRest.CSharp.Mgmt.Generation
{
    internal sealed class ArmClientExtensionClientWriter : MgmtExtensionClientWriter
    {
        private MgmtExtensionClient This { get; }

        public ArmClientExtensionClientWriter(MgmtExtensionClient extensionClient) : base(extensionClient)
        {
            This = extensionClient;
        }

        protected override void WriteCtors()
        {
            base.WriteCtors();

            if (This.ArmClientCtor is { } armClientCtor)
            {
                // for ArmClientExtensionClient, we write an extra ctor that only takes ArmClient as parameter
                var ctor = armClientCtor with
                {
                    Parameters = new[] { MgmtTypeProvider.ArmClientParameter },
                    Initializer = new(false, new FormattableString[] { $"{MgmtTypeProvider.ArmClientParameter.Name:I}", $"{typeof(ResourceIdentifier)}.{nameof(ResourceIdentifier.Root)}" })
                };

                using (_writer.WriteMethodDeclaration(ctor))
                {
                    // it does not need a body
                }
            }
        }

        protected internal override void WriteImplementations()
        {
            base.WriteImplementations();

            foreach (var resource in MgmtContext.Library.ArmResources)
            {
                WriteGetResourceFromIdMethod(resource);
                _writer.Line();
            }
        }

        protected override IDisposable WriteCommonMethod(MgmtClientOperation clientOperation, bool isAsync)
        {
            var originalSignature = clientOperation.MethodSignature;
            var signature = originalSignature with
            {
                Parameters = originalSignature.Parameters.Prepend(MgmtTypeProvider.ScopeParameter).ToArray()
            };
            _writer.Line();
            var returnDescription = clientOperation.ReturnsDescription?.Invoke(isAsync);
            return _writer.WriteCommonMethod(signature, returnDescription, isAsync, This.Accessibility == "public", SkipParameterValidation);
        }

        private void WriteGetResourceFromIdMethod(Resource resource)
        {
            List<FormattableString> lines = new List<FormattableString>();
            string an = resource.Type.Name.StartsWithVowel() ? "an" : "a";
            lines.Add($"Gets an object representing {an} <see cref=\"{resource.Type}\" /> along with the instance operations that can be performed on it but with no data.");
            lines.Add($"You can use <see cref=\"{resource.Type}.CreateResourceIdentifier\" /> to create {an} <see cref=\"{resource.Type}\" /> <see cref=\"{typeof(ResourceIdentifier)}\" /> from its components.");
            _writer.WriteXmlDocumentationSummary(FormattableStringHelpers.Join(lines, "\r\n"));
            _writer.WriteXmlDocumentationParameter("id", $"The resource ID of the resource to get.");
            _writer.WriteXmlDocumentationReturns($"Returns a <see cref=\"{resource.Type.Name}\" /> object.");
            using (_writer.Scope($"public virtual {resource.Type} Get{resource.Type.Name}({typeof(Azure.Core.ResourceIdentifier)} id)"))
            {
                WriteGetter(resource, "Client");
            }
        }

        private void WriteGetter(Resource resource, string armVariable)
        {
            _writer.Line($"{resource.Type.Name}.ValidateResourceId(id);");
            _writer.Line($"return new {resource.Type.Name}({armVariable}, id);");
        }

        /// <summary>
        /// In ArmClientExtensionClient, its `Id` property is actually dummy, therefore we need to override this method to use `scope` instead of using the `Id` property
        /// </summary>
        /// <param name="resource"></param>
        /// <param name="singletonResourceIdSuffix"></param>
        /// <param name="signature"></param>
        protected override void WriteSingletonResourceEntry(Resource resource, SingletonResourceSuffix singletonResourceIdSuffix, MethodSignature signature)
        {
            _writer.Line($"return new {resource.Type.Name}({ArmClientReference}, {singletonResourceIdSuffix.BuildResourceIdentifier($"{MgmtTypeProvider.ScopeParameter.Name}")});");
        }

        /// <summary>
        /// Override this method to prepend the `scope` parameter
        /// </summary>
        /// <returns></returns>
        protected override Parameter[] GetParametersForSingletonEntry()
        {
            return base.GetParametersForSingletonEntry().Prepend(MgmtTypeProvider.ScopeParameter).ToArray();
        }

        /// <summary>
        /// Override this method to prepend the `scope` parameter
        /// </summary>
        /// <param name="resourceCollection"></param>
        /// <returns></returns>
        protected override Parameter[] GetParametersForCollectionEntry(ResourceCollection resourceCollection)
        {
            return base.GetParametersForCollectionEntry(resourceCollection).Prepend(MgmtTypeProvider.ScopeParameter).ToArray();
        }

        /// <summary>
        /// In ArmClientExtensionClient, its `Id` property is actually dummy, therefore we need to override this method to use `scope` instead of using the `Id` property
        /// </summary>
        /// <param name="resourceCollection"></param>
        /// <param name="signature"></param>
        protected override void WriteResourceCollectionEntry(ResourceCollection resourceCollection, MethodSignature signature)
        {
            // we cannot use GetCachedClient here because the Id of this instance will never change.
            _writer.Append($"return new {resourceCollection.Type}({ArmClientReference}, {MgmtTypeProvider.ScopeParameter.Name}, ");
            foreach (var parameter in resourceCollection.ExtraConstructorParameters)
            {
                _writer.Append($"{parameter.Name}, ");
            }
            _writer.RemoveTrailingComma();
            _writer.LineRaw(");");
        }
    }
}

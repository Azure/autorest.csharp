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
using Humanizer.Localisation;

namespace AutoRest.CSharp.Mgmt.Generation
{
    internal sealed class ArmClientExtensionClientWriter : MgmtExtensionClientWriter
    {
        private readonly Parameter _scopeParameter;
        private MgmtMockingExtension This { get; }

        public ArmClientExtensionClientWriter(MgmtMockingExtension extensionClient) : base(extensionClient)
        {
            This = extensionClient;
            _scopeParameter = new Parameter(
                Name: "scope",
                Description: $"The scope that the resource will apply against.",
                Type: typeof(ResourceIdentifier),
                DefaultValue: null,
                Validation: ValidationType.None,
                Initializer: null);
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

        protected override WriteMethodDelegate GetMethodDelegate(bool isLongRunning, bool isPaging)
        {
            var writeBody = base.GetMethodDelegate(isLongRunning, isPaging);
            return (clientOperation, diagnostic, isAsync) =>
            {
                var requestPaths = clientOperation.Select(restOperation => restOperation.RequestPath);
                var scopeResourceTypes = requestPaths.Select(requestPath => requestPath.GetParameterizedScopeResourceTypes() ?? Enumerable.Empty<ResourceTypeSegment>()).SelectMany(types => types).Distinct();
                var scopeTypes = ArmClientExtensionWriter.GetScopeTypeStrings(scopeResourceTypes);

                WriteScopeResourceTypesValidation(_scopeParameter.Name, scopeTypes);

                writeBody(clientOperation, diagnostic, isAsync);
            };
        }

        /// <summary>
        /// In ArmClientExtensionClient, its `Id` property is actually dummy, therefore we need to override this method to use `scope` instead of using the `Id` property
        /// </summary>
        /// <param name="resource"></param>
        /// <param name="singletonResourceIdSuffix"></param>
        /// <param name="signature"></param>
        protected override void WriteSingletonResourceEntry(Resource resource, SingletonResourceSuffix singletonResourceIdSuffix, MethodSignature signature)
        {
            var scopeTypes = ArmClientExtensionWriter.GetScopeTypeStrings(resource.RequestPath.GetParameterizedScopeResourceTypes());
            WriteScopeResourceTypesValidation(_scopeParameter.Name, scopeTypes);

            _writer.Line($"return new {resource.Type.Name}({ArmClientReference}, {singletonResourceIdSuffix.BuildResourceIdentifier($"{MgmtTypeProvider.ScopeParameter.Name}")});");
        }

        /// <summary>
        /// In ArmClientExtensionClient, its `Id` property is actually dummy, therefore we need to override this method to use `scope` instead of using the `Id` property
        /// </summary>
        /// <param name="resourceCollection"></param>
        /// <param name="signature"></param>
        protected override void WriteResourceCollectionEntry(ResourceCollection resourceCollection, MethodSignature signature)
        {
            var scopeTypes = ArmClientExtensionWriter.GetScopeTypeStrings(resourceCollection.RequestPath.GetParameterizedScopeResourceTypes());
            WriteScopeResourceTypesValidation(_scopeParameter.Name, scopeTypes);

            // we cannot use GetCachedClient here because the Id of this instance will never change.
            _writer.Append($"return new {resourceCollection.Type}({ArmClientReference}, {MgmtTypeProvider.ScopeParameter.Name}, ");
            foreach (var parameter in resourceCollection.ExtraConstructorParameters)
            {
                _writer.Append($"{parameter.Name}, ");
            }
            _writer.RemoveTrailingComma();
            _writer.LineRaw(");");
        }

        private void WriteScopeResourceTypesValidation(string parameterName, ICollection<FormattableString>? types)
        {
            if (types == null)
                return;
            // validate the scope types
            var typeAssertions = types.Select(type => (FormattableString)$"!{parameterName:I}.ResourceType.Equals(\"{type}\")").ToArray();
            var assertion = typeAssertions.Join(" || ");
            using (_writer.Scope($"if ({assertion})"))
            {
                _writer.Line($"throw new {typeof(ArgumentException)}({typeof(string)}.{nameof(string.Format)}(\"Invalid resource type {{0}} expected {types.Join(", ", " or ")}\", {parameterName:I}.ResourceType));");
            }
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
    }
}

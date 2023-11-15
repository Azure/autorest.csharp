// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions;
using AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions.Azure;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Mgmt.Models;
using AutoRest.CSharp.Mgmt.Output;
using AutoRest.CSharp.Output.Models.Shared;
using Azure.Core;

namespace AutoRest.CSharp.Mgmt.Generation
{
    internal sealed class ArmClientMockableExtensionWriter : MgmtMockableExtensionResourceWriter
    {
        private readonly Parameter _scopeParameter;
        private MgmtMockableArmClient This { get; }

        public ArmClientMockableExtensionWriter(MgmtMockableArmClient extensionClient) : base(extensionClient)
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
                    Initializer = new(false, new ValueExpression[] { MgmtTypeProvider.ArmClientParameter, ResourceIdentifierExpression.Root })
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

            foreach (var method in This.ArmResourceMethods)
            {
                _writer.WriteMethodDocumentation(method.Signature);
                _writer.WriteMethod(method);
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
                var scopeTypes = ResourceTypeBuilder.GetScopeTypeStrings(scopeResourceTypes);

                WriteScopeResourceTypesValidation(_scopeParameter.Name, scopeTypes);

                writeBody(clientOperation, diagnostic, isAsync);
            };
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
    }
}

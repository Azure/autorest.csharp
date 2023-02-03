// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Mgmt.Models;
using AutoRest.CSharp.Mgmt.Output;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Utilities;
using Azure.Core;
using Azure.ResourceManager;
using static AutoRest.CSharp.Output.Models.MethodSignatureModifiers;

namespace AutoRest.CSharp.Mgmt.Generation
{
    internal class ArmResourceExtensionsWriter : MgmtExtensionWriter
    {
        private MgmtExtensions This { get; }

        private readonly Parameter _armClientParameter;
        private readonly Parameter _scopeParameter;

        public ArmResourceExtensionsWriter(CodeWriter writer, MgmtExtensions extension)
            : base(writer, extension)
        {
            This = extension;
            _armClientParameter = This.ExtensionParameter with
            {
                Name = "client",
                Description = $"The <see cref=\"{typeof(ArmClient)}\" /> instance the method will execute against.",
                Type = typeof(ArmClient),
            };
            _scopeParameter = new Parameter(
                Name: "scope",
                Description: $"The scope that the resource will apply against.",
                Type: typeof(ResourceIdentifier),
                DefaultValue: null,
                Validation: ValidationType.None,
                Initializer: null);
        }

        protected override void WritePrivateHelpers()
        {
            if (IsArmCore)
                return;

            _writer.Line();
            var armClientSignature = new MethodSignature(
                "GetExtensionClient",
                null,
                null,
                Private | Static,
                This.ExtensionClient.Type,
                null,
                new[] { _armClientParameter, _scopeParameter });
            using (_writer.WriteMethodDeclaration(armClientSignature))
            {
                using (_writer.Scope($"return {_armClientParameter.Name}.GetResourceClient(() =>"))
                {
                    _writer.Line($"return new {This.ExtensionClient.Type}({_armClientParameter.Name}, {_scopeParameter.Name});");
                }
                _writer.Line($");");
            }

            base.WritePrivateHelpers();
        }

        protected override void WriteSingletonResourceGetMethod(Resource resource)
        {
            if (Configuration.MgmtConfiguration.GenerateArmResourceExtensions.Contains(resource.RequestPath))
            {
                base.WriteSingletonResourceGetMethod(resource);
                _writer.Line();
            }

            var scopeTypes = GetScopeTypeStrings(resource.RequestPath.GetParameterizedScopeResourceTypes());
            var signature = new MethodSignature(
                $"Get{resource.ResourceName}",
                null,
                $"Gets an object representing a {resource.Type.Name} along with the instance operations that can be performed on it in the {This.ResourceName}.",
                GetMethodModifiers(),
                resource.Type,
                $"Returns a <see cref=\"{resource.Type}\" /> object.",
                GetParametersForSingletonEntry(scopeTypes));
            using (_writer.WriteCommonMethod(signature, null, false, This.Accessibility == "public"))
            {
                WriteMethodBodyWrapper(signature, false, false, scopeTypes);
            }
        }

        protected override void WriteResourceCollectionGetMethod(Resource resource)
        {
            if (Configuration.MgmtConfiguration.GenerateArmResourceExtensions.Contains(resource.RequestPath))
            {
                base.WriteResourceCollectionGetMethod(resource);
                _writer.Line();
            }

            var scopeTypes = GetScopeTypeStrings(resource.RequestPath.GetParameterizedScopeResourceTypes());
            var resourceCollection = resource.ResourceCollection!;
            var signature = new MethodSignature(
                $"{GetResourceCollectionMethodName(resourceCollection)}",
                null,
                $"Gets a collection of {resource.Type.Name.LastWordToPlural()} in the {This.ResourceName}.",
                GetMethodModifiers(),
                resourceCollection.Type,
                $"An object representing collection of {resource.Type.Name.LastWordToPlural()} and their operations over a {resource.Type.Name}.",
                GetParametersForCollectionEntry(resourceCollection, scopeTypes));
            using (_writer.WriteCommonMethod(signature, null, false, This.Accessibility == "public"))
            {
                WriteMethodBodyWrapper(signature, false, false, scopeTypes);
            }
        }

        protected override void WriteChildResourceGetMethod(ResourceCollection resourceCollection, bool isAsync)
        {
            if (Configuration.MgmtConfiguration.GenerateArmResourceExtensions.Contains(resourceCollection.Resource.RequestPath))
            {
                base.WriteChildResourceGetMethod(resourceCollection, isAsync);
                _writer.Line();
            }

            var scopeTypes = GetScopeTypeStrings(resourceCollection.RequestPath.GetParameterizedScopeResourceTypes());
            var getOperation = resourceCollection.GetOperation;
            // Copy the original method signature with changes in name and modifier (e.g. when adding into extension class, the modifier should be static)
            var methodSignature = getOperation.MethodSignature with
            {
                // name after `Get{ResourceName}`
                Name = $"{getOperation.MethodSignature.Name}{resourceCollection.Resource.ResourceName}",
                Modifiers = GetMethodModifiers(),
                // There could be parameters to get resource collection
                Parameters = GetParametersForCollectionEntry(resourceCollection, scopeTypes).Concat(GetParametersForResourceEntry(resourceCollection)).ToArray(),
                Attributes = new[] { new CSharpAttribute(typeof(ForwardsClientCallsAttribute)) }
            };

            _writer.Line();
            using (_writer.WriteCommonMethodWithoutValidation(methodSignature, getOperation.ReturnsDescription != null ? getOperation.ReturnsDescription(isAsync) : null, isAsync, This.Accessibility == "public"))
            {
                WriteResourceEntry(resourceCollection, isAsync, scopeTypes);
            }
        }

        private void WriteResourceEntry(ResourceCollection resourceCollection, bool isAsync, ICollection<FormattableString>? types)
        {
            if (IsArmCore)
            {
                base.WriteResourceEntry(resourceCollection, isAsync);
            }
            else
            {
                WriteScopeResourceTypesValidation(_scopeParameter.Name, types);
                var operation = resourceCollection.GetOperation;
                string configureAwait = isAsync & !operation.IsPagingOperation ? ".ConfigureAwait(false)" : string.Empty;

                _writer.AppendRaw("return ")
                    .AppendRawIf("await ", isAsync && !operation.IsPagingOperation)
                    .Append($"{GetResourceCollectionMethodName(resourceCollection)}(");
                foreach (var parameter in GetParametersForCollectionEntry(resourceCollection, types))
                {
                    _writer.Append($"{parameter.Name:I},");
                }
                _writer.RemoveTrailingComma();
                _writer.Append($").{operation.MethodSignature.WithAsync(isAsync).Name}(");
                foreach (var parameter in operation.MethodSignature.Parameters)
                {
                    _writer.Append($"{parameter.Name},");
                }

                _writer.RemoveTrailingComma();
                _writer.AppendRaw(")")
                    .AppendRawIf(".ConfigureAwait(false)", isAsync && !operation.IsPagingOperation)
                    .LineRaw(";");
            }
        }

        private void WriteMethodBodyWrapper(MethodSignature signature, bool isAsync, bool isPaging, ICollection<FormattableString>? scopeTypes)
        {
            WriteScopeResourceTypesValidation(_scopeParameter.Name, scopeTypes);

            _writer.AppendRaw("return ")
                .AppendRawIf("await ", isAsync && !isPaging)
                .Append($"GetExtensionClient({_armClientParameter.Name}, {_scopeParameter.Name}).{CreateMethodName(signature.Name, isAsync)}(");

            foreach (var parameter in signature.Parameters.Skip(2))
            {
                _writer.Append($"{parameter.Name},");
            }

            _writer.RemoveTrailingComma();
            _writer.AppendRaw(")")
                .AppendRawIf(".ConfigureAwait(false)", isAsync && !isPaging)
                .LineRaw(";");
        }

        private ICollection<FormattableString>? GetScopeTypeStrings(IEnumerable<ResourceTypeSegment>? scopeTypes)
        {
            if (scopeTypes == null || scopeTypes.Contains(ResourceTypeSegment.Any))
                return null;

            return scopeTypes.Select(type => (FormattableString)$"{type}").ToArray();
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

        private Parameter[] GetParametersForSingletonEntry(ICollection<FormattableString>? types)
            => IsArmCore
                ? base.GetParametersForSingletonEntry()
                : new[] {
                    _armClientParameter,
                    GetScopeParameter(types)
                };

        private Parameter[] GetParametersForCollectionEntry(ResourceCollection resourceCollection, ICollection<FormattableString>? types)
            => IsArmCore
                ? base.GetParametersForCollectionEntry(resourceCollection)
                : resourceCollection.ExtraConstructorParameters.Prepend(GetScopeParameter(types)).Prepend(_armClientParameter).ToArray();

        private Parameter GetScopeParameter(ICollection<FormattableString>? types)
        {
            if (types == null)
                return _scopeParameter;

            return _scopeParameter with
            {
                Description = _scopeParameter.Description + $" Expected resource type includes the following: {types.Join(", ", " or ")}"
            };
        }
    }
}

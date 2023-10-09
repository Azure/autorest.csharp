// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
using Azure.ResourceManager;

namespace AutoRest.CSharp.Mgmt.Generation
{
    internal sealed class ArmClientExtensionWriter : MgmtExtensionWriter
    {
        private readonly Parameter _armClientParameter;
        private readonly Parameter _scopeParameter;

        private MgmtExtension This { get; }

        public ArmClientExtensionWriter(ArmClientExtension extension) : this(new CodeWriter(), extension)
        {
        }

        public ArmClientExtensionWriter(CodeWriter writer, ArmClientExtension extension) : base(writer, extension)
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

        protected internal override void WriteImplementations()
        {
            base.WriteImplementations();

            foreach (var resource in MgmtContext.Library.ArmResources)
            {
                WriteGetResourceFromIdMethod(resource);
                _writer.Line();
            }
        }

        protected override void WriteMethod(MgmtClientOperation clientOperation, bool isAsync)
        {
            using (_writer.WriteCommonMethod(clientOperation.MethodSignature, null, isAsync, This.Accessibility == "public", SkipParameterValidation))
            {
                WriteMethodBodyWrapper(clientOperation.MethodSignature, isAsync, clientOperation.IsPagingOperation);
            }
            _writer.Line();
        }

        protected override void WriteSingletonResourceGetMethod(Resource resource)
        {
            if (IsArmCore)
            {
                base.WriteSingletonResourceGetMethod(resource);
            }
            else
            {
                var scopeTypes = ResourceTypeBuilder.GetScopeTypeStrings(resource.RequestPath.GetParameterizedScopeResourceTypes());
                var signature = new MethodSignature(
                    $"Get{resource.ResourceName}",
                    null,
                    $"Gets an object representing a {resource.Type.Name} along with the instance operations that can be performed on it in the {This.ResourceName}.",
                    GetMethodModifiers(),
                    resource.Type,
                    $"Returns a <see cref=\"{resource.Type}\" /> object.",
                    GetParametersForSingletonEntry(scopeTypes));
                using (_writer.WriteCommonMethod(signature, null, false, This.Accessibility == "public", SkipParameterValidation))
                {
                    WriteMethodBodyWrapper(signature, false, false);
                }
            }
        }
        protected override void WriteResourceCollectionGetMethod(Resource resource)
        {
            if (IsArmCore)
            {
                base.WriteResourceCollectionGetMethod(resource);
            }
            else
            {
                var scopeTypes = ResourceTypeBuilder.GetScopeTypeStrings(resource.RequestPath.GetParameterizedScopeResourceTypes());
                var resourceCollection = resource.ResourceCollection!;
                var signature = new MethodSignature(
                    $"{GetResourceCollectionMethodName(resourceCollection)}",
                    null,
                    $"Gets a collection of {resource.Type.Name.LastWordToPlural()} in the {This.ResourceName}.",
                    GetMethodModifiers(),
                    resourceCollection.Type,
                    $"An object representing collection of {resource.Type.Name.LastWordToPlural()} and their operations over a {resource.Type.Name}.",
                    GetParametersForCollectionEntry(resourceCollection, scopeTypes));
                using (_writer.WriteCommonMethod(signature, null, false, This.Accessibility == "public", SkipParameterValidation))
                {
                    WriteMethodBodyWrapper(signature, false, false);
                }
            }
        }

        protected override void WriteChildResourceGetMethod(ResourceCollection resourceCollection, bool isAsync)
        {
            if (IsArmCore)
            {
                base.WriteChildResourceGetMethod(resourceCollection, isAsync);
            }
            else
            {
                var scopeTypes = ResourceTypeBuilder.GetScopeTypeStrings(resourceCollection.RequestPath.GetParameterizedScopeResourceTypes());
                var getOperation = resourceCollection.GetOperation;
                // Copy the original method signature with changes in name and modifier (e.g. when adding into extension class, the modifier should be static)
                var signature = getOperation.MethodSignature with
                {
                    // name after `Get{ResourceName}`
                    Name = $"{getOperation.MethodSignature.Name}{resourceCollection.Resource.ResourceName}",
                    Modifiers = GetMethodModifiers(),
                    // There could be parameters to get resource collection
                    Parameters = GetParametersForCollectionEntry(resourceCollection, scopeTypes).Concat(GetParametersForResourceEntry(resourceCollection)).ToArray(),
                    Attributes = new[] { new CSharpAttribute(typeof(ForwardsClientCallsAttribute)) }
                };

                using (_writer.WriteCommonMethodWithoutValidation(signature, getOperation.ReturnsDescription != null ? getOperation.ReturnsDescription(isAsync) : null, isAsync, This.Accessibility == "public"))
                {
                    WriteMethodBodyWrapper(signature, isAsync, false);
                }
            }
        }

        /// <summary>
        /// Returns the parameters by the specific scope
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        private Parameter[] GetScopeVersionMethodParameters(IEnumerable<Parameter> parameters, ICollection<FormattableString>? types)
        {
            var scopeParameter = GetScopeParameter(types);
            return parameters.Prepend(scopeParameter).Prepend(_armClientParameter).ToArray();
        }

        private Parameter[] GetParametersForSingletonEntry(ICollection<FormattableString>? types) => GetScopeVersionMethodParameters(Enumerable.Empty<Parameter>(), types);

        private Parameter[] GetParametersForCollectionEntry(ResourceCollection resourceCollection, ICollection<FormattableString>? types) => GetScopeVersionMethodParameters(resourceCollection.ExtraConstructorParameters, types);

        private Parameter GetScopeParameter(ICollection<FormattableString>? types)
        {
            if (types == null)
                return _scopeParameter;

            return _scopeParameter with
            {
                Description = $"{_scopeParameter.Description} Expected resource type includes the following: {types.Join(", ", " or ")}"
            };
        }

        private void WriteGetResourceFromIdMethod(Resource resource)
        {
            List<FormattableString> lines = new List<FormattableString>();
            string an = resource.Type.Name.StartsWithVowel() ? "an" : "a";
            lines.Add($"Gets an object representing {an} <see cref=\"{resource.Type}\" /> along with the instance operations that can be performed on it but with no data.");
            lines.Add($"You can use <see cref=\"{resource.Type}.CreateResourceIdentifier\" /> to create {an} <see cref=\"{resource.Type}\" /> <see cref=\"{typeof(ResourceIdentifier)}\" /> from its components.");
            _writer.WriteXmlDocumentationSummary(FormattableStringHelpers.Join(lines, "\r\n"));
            if (!IsArmCore)
            {
                _writer.WriteXmlDocumentationParameter($"{This.ExtensionParameter.Name}", $"The <see cref=\"{This.ExtensionParameter.Type}\" /> instance the method will execute against.");
            }
            _writer.WriteXmlDocumentationParameter("id", $"The resource ID of the resource to get.");
            _writer.WriteXmlDocumentationReturns($"Returns a <see cref=\"{resource.Type.Name}\" /> object.");
            var modifier = IsArmCore ? "virtual" : "static";
            var instanceParameter = IsArmCore ? string.Empty : $"this {This.ExtensionParameter.Type.Name} {This.ExtensionParameter.Name}, ";
            using (_writer.Scope($"public {modifier} {resource.Type} Get{resource.Type.Name}({instanceParameter}{typeof(Azure.Core.ResourceIdentifier)} id)"))
            {
                if (!IsArmCore)
                {
                    _writer.AppendRaw("return ")
                        .Append($"{This.MockingExtension.FactoryMethodName}({This.ExtensionParameter.Name}).Get{resource.Type.Name}(id);");
                }
                else
                {
                    WriteGetter(resource, "this");
                }
            }
        }

        private void WriteGetter(Resource resource, string armVariable)
        {
            _writer.Line($"{resource.Type.Name}.ValidateResourceId(id);");
            _writer.Line($"return new {resource.Type.Name}({armVariable}, id);");
        }
    }
}

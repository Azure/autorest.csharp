// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Output;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Generation.Types;
using System;
using AutoRest.CSharp.Utilities;
using System.Linq;
using Azure.ResourceManager;
using Azure.Core;
using static AutoRest.CSharp.Output.Models.MethodSignatureModifiers;
using AutoRest.CSharp.Input;
using Humanizer.Localisation;

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
                Description: $"The scope that the method will apply against.",
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
            }

            var signature = new MethodSignature(
                $"Get{resource.ResourceName}",
                null,
                $"Gets an object representing a {resource.Type.Name} along with the instance operations that can be performed on it in the {This.ResourceName}.",
                GetMethodModifiers(),
                resource.Type,
                $"Returns a <see cref=\"{resource.Type}\" /> object.",
                GetParametersForSingletonEntry());
            using (WriteCommonMethod(signature, null, false))
            {
                // TODO
                WriteSingletonResourceEntry(resource, resource.SingletonResourceIdSuffix!, signature);
            }
        }

        protected override void WriteResourceCollectionGetMethod(Resource resource)
        {
            if (Configuration.MgmtConfiguration.GenerateArmResourceExtensions.Contains(resource.RequestPath))
            {
                base.WriteResourceCollectionGetMethod(resource);
                _writer.Line();
            }

            var resourceCollection = resource.ResourceCollection!;
            var signature = new MethodSignature(
                $"{GetResourceCollectionMethodName(resourceCollection)}",
                null,
                $"Gets a collection of {resource.Type.Name.LastWordToPlural()} in the {This.ResourceName}.",
                GetMethodModifiers(),
                resourceCollection.Type,
                $"An object representing collection of {resource.Type.Name.LastWordToPlural()} and their operations over a {resource.Type.Name}.",
                GetParametersForCollectionEntry(resourceCollection));
            using (WriteCommonMethod(signature, null, false))
            {
                WriteCollectionBody(signature, false, false);
            }
        }

        protected override void WriteChildResourceGetMethod(ResourceCollection resourceCollection, bool isAsync)
        {
            if (Configuration.MgmtConfiguration.GenerateArmResourceExtensions.Contains(resourceCollection.Resource.RequestPath))
            {
                base.WriteChildResourceGetMethod(resourceCollection, isAsync);
                _writer.Line();
            }

            var getOperation = resourceCollection.GetOperation;
            // Copy the original method signature with changes in name and modifier (e.g. when adding into extension class, the modifier should be static)
            var methodSignature = getOperation.MethodSignature with
            {
                // name after `Get{ResourceName}`
                Name = $"{getOperation.MethodSignature.Name}{resourceCollection.Resource.ResourceName}",
                Modifiers = GetMethodModifiers(),
                // There could be parameters to get resource collection
                Parameters = GetParametersForCollectionEntry(resourceCollection).Concat(GetParametersForResourceEntry(resourceCollection)).ToArray(),
            };

            _writer.Line();
            using (WriteCommonMethodWithoutValidation(methodSignature, getOperation.ReturnsDescription != null ? getOperation.ReturnsDescription(isAsync) : null, isAsync, true, new List<Attribute> { new ForwardsClientCallsAttribute() }))
            {
                WriteResourceEntry(resourceCollection, isAsync);
            }
        }

        private new void WriteResourceEntry(ResourceCollection resourceCollection, bool isAsync)
        {
            if (IsArmCore)
            {
                base.WriteResourceEntry(resourceCollection, isAsync);
            }
            else
            {
                var operation = resourceCollection.GetOperation;
                string awaitText = isAsync & !operation.IsPagingOperation ? " await" : string.Empty;
                string configureAwait = isAsync & !operation.IsPagingOperation ? ".ConfigureAwait(false)" : string.Empty;
                _writer.Append($"return{awaitText} {GetResourceCollectionMethodName(resourceCollection)}({GetResourceCollectionMethodArgumentList(resourceCollection)}).{operation.MethodSignature.WithAsync(isAsync).Name}(");

                foreach (var parameter in operation.MethodSignature.Parameters)
                {
                    _writer.Append($"{parameter.Name},");
                }

                _writer.RemoveTrailingComma();
                _writer.Line($"){configureAwait};");
            }
        }

        private void WriteCollectionBody(MethodSignature signature, bool isAsync, bool isPaging)
        {
            if (IsArmCore)
            {
                WriteGetter(signature.ReturnType, ArmClientReference);
            }
            else
            {
                WriteMethodBodyWrapper(signature, isAsync, isPaging);
            }
        }

        private void WriteMethodBodyWrapper(MethodSignature signature, bool isAsync, bool isPaging)
        {
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

        private void WriteGetter(CSharpType? type, string armClientVariable)
        {
            _writer.Line($"return new {type}({armClientVariable}, {This.ExtensionParameter.Name}.Id);");
        }

        private new string GetResourceCollectionMethodArgumentList(ResourceCollection resourceCollection)
        {
            return string.Join(", ", GetParametersForCollectionEntry(resourceCollection).Select(p => p.Name));
        }

        private new Parameter[] GetParametersForSingletonEntry() => IsArmCore ? base.GetParametersForSingletonEntry() : new[] { _armClientParameter, _scopeParameter };

        private new Parameter[] GetParametersForCollectionEntry(ResourceCollection resourceCollection)
            => IsArmCore ? base.GetParametersForCollectionEntry(resourceCollection) : resourceCollection.ExtraConstructorParameters.Prepend(_scopeParameter).Prepend(_armClientParameter).ToArray();
    }
}

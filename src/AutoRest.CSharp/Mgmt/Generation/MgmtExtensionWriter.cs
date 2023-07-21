// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Linq;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.Models;
using AutoRest.CSharp.Mgmt.Output;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Utilities;
using Azure.Core;
using Azure.ResourceManager;
using static AutoRest.CSharp.Output.Models.MethodSignatureModifiers;

namespace AutoRest.CSharp.Mgmt.Generation
{
    internal class MgmtExtensionWriter : MgmtClientBaseWriter
    {
        public static MgmtExtensionWriter GetWriter(MgmtExtension extension) => GetWriter(new CodeWriter(), extension);

        public static MgmtExtensionWriter GetWriter(CodeWriter writer, MgmtExtension extension) => extension switch
        {
            ArmClientExtension armClientExtension => new ArmClientExtensionWriter(writer, armClientExtension),
            // the class ArmResourceExtensionWriter is created to handle scope resources, but in ArmCore we do not have that problem, therefore for ArmCore we just let the regular MgmtExtension class handle that
            ArmResourceExtension armResourceExtension when !Configuration.MgmtConfiguration.IsArmCore => new ArmResourceExtensionWriter(writer, armResourceExtension),
            _ => new MgmtExtensionWriter(writer, extension)
        };

        private MgmtExtension This { get; }
        protected delegate void WriteResourceGetBody(MethodSignature signature, bool isAsync, bool isPaging);

        public MgmtExtensionWriter(MgmtExtension extensions)
            : this(new CodeWriter(), extensions)
        {
            This = extensions;
        }

        public MgmtExtensionWriter(CodeWriter writer, MgmtExtension extensions) : base(writer, extensions)
        {
            This = extensions;
        }

        protected override WriteMethodDelegate GetMethodDelegate(bool isLongRunning, bool isPaging)
            => IsArmCore ? base.GetMethodDelegate(isLongRunning, isPaging) : GetMethodWrapperImpl;

        private void GetMethodWrapperImpl(MgmtClientOperation clientOperation, Diagnostic diagnostic, bool isAsync)
            => WriteMethodBodyWrapper(clientOperation.MethodSignature, isAsync, clientOperation.IsPagingOperation);

        private void WriteMethodBodyWrapper(MethodSignature signature, bool isAsync, bool isPaging)
        {
            var extensionClient = This.GetExtensionClient(null);

            _writer.AppendRaw("return ")
                .AppendRawIf("await ", isAsync && !isPaging)
                .Append($"{extensionClient.FactoryMethodName}({This.ExtensionParameter.Name}).{CreateMethodName(signature.Name, isAsync)}(");

            foreach (var parameter in signature.Parameters.Skip(1))
            {
                _writer.Append($"{parameter.Name},");
            }

            _writer.RemoveTrailingComma();
            _writer.AppendRaw(")")
                .AppendRawIf(".ConfigureAwait(false)", isAsync && !isPaging)
                .LineRaw(";");
        }

        protected override void WriteResourceCollectionEntry(ResourceCollection resourceCollection, MethodSignature signature)
        {
            if (IsArmCore)
            {
                base.WriteResourceCollectionEntry(resourceCollection, signature);
            }
            else
            {
                WriteMethodBodyWrapper(signature, false, false);
            }
        }

        protected override void WriteSingletonResourceEntry(Resource resource, SingletonResourceSuffix singletonResourceSuffix, MethodSignature signature)
        {
            _writer.UseNamespace(typeof(ResourceIdentifier).Namespace!);
            if (IsArmCore)
            {
                base.WriteSingletonResourceEntry(resource, singletonResourceSuffix, signature);
            }
            else
            {
                WriteMethodBodyWrapper(signature, false, false);
            }
        }

        protected override void WriteResourceEntry(ResourceCollection resourceCollection, bool isAsync)
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

        protected override MethodSignatureModifiers GetMethodModifiers() => IsArmCore ? base.GetMethodModifiers() : Public | Static | Extension;

        protected override Parameter[] GetParametersForSingletonEntry() => IsArmCore ? base.GetParametersForSingletonEntry() : new[] { This.ExtensionParameter };

        protected override Parameter[] GetParametersForCollectionEntry(ResourceCollection resourceCollection)
            => IsArmCore ? base.GetParametersForCollectionEntry(resourceCollection) : resourceCollection.ExtraConstructorParameters.Prepend(This.ExtensionParameter).ToArray();
    }
}

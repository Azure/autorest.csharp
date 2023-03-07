// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Linq;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Mgmt.Models;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Mgmt.Output;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Utilities;
using AutoRest.CSharp.Output.Models.Requests;
using static AutoRest.CSharp.Output.Models.MethodSignatureModifiers;
using Azure.Core;
using AutoRest.CSharp.Generation.Types;

namespace AutoRest.CSharp.Mgmt.Generation
{
    internal class MgmtExtensionWriter : MgmtClientBaseWriter
    {
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
            => WriteMethodBodyWrapper(clientOperation.Resource?.Type, clientOperation.MethodSignature, isAsync, clientOperation.IsPagingOperation);

        // TODO -- move this method to the wrapper
        //protected override void WritePrivateHelpers()
        //{
        //    if (IsArmCore)
        //        return;

        //    _writer.Line();
        //    var extensionClientSignature = new MethodSignature(
        //        $"Get{This.ExtensionClient.Type.Name}",
        //        null,
        //        null,
        //        Private | Static,
        //        This.ExtensionClient.Type,
        //        null,
        //        new[] { This.ExtensionParameter });
        //    using (_writer.WriteMethodDeclaration(extensionClientSignature))
        //    {
        //        using (_writer.Scope($"return {This.ExtensionParameter.Name}.GetCachedClient(({ArmClientReference.ToVariableName()}) =>"))
        //        {
        //            _writer.Line($"return new {extensionClientSignature.ReturnType}({ArmClientReference.ToVariableName()}, {This.ExtensionParameter.Name}.Id);");
        //        }
        //        _writer.Line($");");
        //    }
        //}

        private void WriteMethodBodyWrapper(CSharpType? resourceType, MethodSignature signature, bool isAsync, bool isPaging)
        {
            var extensionClient = This.GetExtensionClient(resourceType);

            _writer.AppendRaw("return ")
                .AppendRawIf("await ", isAsync && !isPaging)
                .Append($"Get{extensionClient.Type.Name}({This.ExtensionParameter.Name}).{CreateMethodName(signature.Name, isAsync)}(");

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
                WriteMethodBodyWrapper(null, signature, false, false);
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
                // TODO -- verify if this works fine
                WriteMethodBodyWrapper(null, signature, false, false);
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

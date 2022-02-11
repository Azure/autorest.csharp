// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Mgmt.Models;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Mgmt.Output;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Utilities;
using AutoRest.CSharp.Output.Models.Requests;
using static AutoRest.CSharp.Mgmt.Decorator.ParameterMappingBuilder;

namespace AutoRest.CSharp.Mgmt.Generation
{
    internal class MgmtExtensionWriter : MgmtClientBaseWriter
    {
        private MgmtExtensions This { get; }
        protected delegate void WriteResourceGetBody(MethodSignature signature, bool isAsync, bool isPaging);

        public MgmtExtensionWriter(MgmtExtensions extensions, BuildContext<MgmtOutputLibrary> context)
            : base(new CodeWriter(), extensions, context)
        {
            This = extensions;
        }

        protected override WriteMethodDelegate GetMethodDelegate(bool isLongRunning, bool isPaging)
            => IsArmCore ? base.GetMethodDelegate(isLongRunning, isPaging) : GetMethodWrapperImpl;

        private void GetMethodWrapperImpl(MgmtClientOperation clientOperation, Diagnostic diagnostic, bool isAsync)
            => WriteMethodBodyWrapper(clientOperation.MethodSignature, isAsync, clientOperation.IsPagingOperation);

        protected override void WritePrivateHelpers()
        {
            if (IsArmCore)
                return;

            _writer.Line();
            string staticText = IsArmCore ? string.Empty : "static ";
            FormattableString signatureParamText = IsArmCore ? (FormattableString)$"" : (FormattableString)$"{This.ExtensionParameter.Type} {This.ExtensionParameter.Name}";
            using (_writer.Scope($"private {staticText}{This.ExtensionParameter.Type.Name}ExtensionClient GetExtensionClient({signatureParamText})"))
            {
                using (_writer.Scope($"return {This.ExtensionParameter.Name}.GetCachedClient(({ArmClientReference.ToVariableName()}) =>"))
                {
                    _writer.Line($"return new {This.ExtensionParameter.Type.Name}ExtensionClient({ArmClientReference.ToVariableName()}, {This.ExtensionParameter.Name}.Id);");
                }
                _writer.Line($");");
            }
        }

        private void WriteMethodBodyWrapper(MethodSignature signature, bool isAsync, bool isPaging)
        {
            string asyncText = isAsync ? "Async" : string.Empty;
            string configureAwait = isAsync & !isPaging ? ".ConfigureAwait(false)" : string.Empty;
            string awaitText = isAsync & !isPaging ? " await" : string.Empty;
            _writer.Append($"return{awaitText} GetExtensionClient({This.ExtensionParameter.Name}).{signature.Name}{asyncText}(");

            foreach (var parameter in signature.Parameters.Skip(1))
            {
                _writer.Append($"{parameter.Name},");
            }

            _writer.RemoveTrailingComma();
            _writer.Line($"){configureAwait};");
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

        protected override void WriteSingletonResourceEntry(Resource resource, string singletonResourceSuffix, MethodSignature signature)
        {
            if (IsArmCore)
            {
                base.WriteSingletonResourceEntry(resource, singletonResourceSuffix, signature);
            }
            else
            {
                WriteMethodBodyWrapper(signature, false, false);
            }
        }

        protected override Parameter[] GetParametersForCollectionEntry(ResourceCollection resourceCollection)
        {
            if (IsArmCore)
                return base.GetParametersForCollectionEntry(resourceCollection);

            List<Parameter> parameters = new List<Parameter>();
            if (!IsArmCore)
                parameters.Add(This.ExtensionParameter);
            parameters.AddRange(resourceCollection.ExtraConstructorParameters);
            return parameters.ToArray();
        }

        protected override Parameter[] GetParametersForSingletonEntry()
        {
            if (IsArmCore)
                return base.GetParametersForSingletonEntry();

            List<Parameter> parameters = new List<Parameter>();
            if (!IsArmCore)
                parameters.Add(This.ExtensionParameter);
            return parameters.ToArray();
        }
    }
}

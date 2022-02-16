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

namespace AutoRest.CSharp.Mgmt.Generation
{
    internal class ArmResourceExtensionsWriter : MgmtExtensionWriter
    {
        private MgmtExtensions This { get; }

        public ArmResourceExtensionsWriter(MgmtExtensions extensions)
            : base(extensions)
        {
            This = extensions;
        }

        protected override void WritePrivateHelpers()
        {
        }

        protected override void WriteResourceCollectionEntry(ResourceCollection resourceCollection, MethodSignature signature)
            => WriteCollectionBody(signature, false, false);

        private void WriteCollectionBody(MethodSignature signature, bool isAsync, bool isPaging)
        {
            if (!IsArmCore)
            {
                using (_writer.Scope($"return {This.ExtensionParameter.Name}.GetCachedClient<{signature.ReturnType}>(({ArmClientReference.ToVariableName()}) =>"))
                {
                    WriteGetter(signature.ReturnType, $"{ArmClientReference.ToVariableName()}");
                }
                _writer.Line($");");
            }
            else
            {
                WriteGetter(signature.ReturnType, ArmClientReference);
            }
        }

        private void WriteGetter(CSharpType? type, string armClientVariable)
        {
            _writer.Line($"return new {type}({armClientVariable}, {This.ExtensionParameter.Name}.Id);");
        }
    }
}

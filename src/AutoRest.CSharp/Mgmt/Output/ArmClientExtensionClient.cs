// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Mgmt.Models;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Utilities;
using Azure.Core;
using Azure.ResourceManager;
using static AutoRest.CSharp.Output.Models.MethodSignatureModifiers;

namespace AutoRest.CSharp.Mgmt.Output
{
    internal class ArmClientExtensionClient : MgmtExtensionClient
    {
        public ArmClientExtensionClient(CSharpType resourceType, IEnumerable<MgmtClientOperation> operations, MgmtExtension? extensionForChildResources) : base(resourceType, operations, extensionForChildResources)
        {
        }

        protected override MgmtExtensionClientFactoryMethod EnsureFactoryMethod()
        {
            var scopeExtensionMethod = new MethodSignature(
                FactoryMethodName,
                null,
                null,
                Private | Static,
                Type,
                null,
                new[] { ArmClientParameter });
            Action<CodeWriter> scopeExtensionMethodBody = writer =>
            {
                using (writer.Scope($"return {ArmClientParameter.Name}.GetCachedClient(client => ", newLine: false))
                {
                    writer.Line($"return new {Type}(client);");
                }
                writer.LineRaw(");");
            };
            return new(scopeExtensionMethod, scopeExtensionMethodBody);
        }

        public override FormattableString IdVariableName => $"scope";

        public override FormattableString BranchIdVariableName => $"scope";

        public override bool IsEmpty => !ClientOperations.Any() && !MgmtContext.Library.ArmResources.Any();
    }
}

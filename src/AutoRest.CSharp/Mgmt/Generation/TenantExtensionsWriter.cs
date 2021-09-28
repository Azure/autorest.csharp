// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;
using Azure.ResourceManager.Resources;

namespace AutoRest.CSharp.Mgmt.Generation
{
    //internal class TenantExtensionsWriter : MgmtExtensionWriter
    //{
    //    private CodeWriter _writer;
    //    public TenantExtensionsWriter(CodeWriter writer, BuildContext<MgmtOutputLibrary> context) : base(context)
    //    {
    //        _writer = writer;
    //    }

    //    protected override string Description => "A class to add extension methods to Tenant.";
    //    protected override string TypeNameOfThis => ResourceTypeBuilder.TypeToExtensionName[ResourceTypeBuilder.Tenant];
    //    protected override string ExtensionOperationVariableName => "tenant";

    //    protected override Type ExtensionOperationVariableType => typeof(Tenant);

    //    public override void Write()
    //    {
    //        using (_writer.Namespace(Context.DefaultNamespace))
    //        {
    //            _writer.WriteXmlDocumentationSummary($"{Description}");
    //            using (_writer.Scope($"{Accessibility} static partial class {TypeNameOfThis}"))
    //            {
    //                foreach (var resource in Context.Library.ArmResources)
    //                {
    //                    if (!resource.OperationGroup.IsAncestorResourceTypeTenant(Context))
    //                        continue;
    //                    _writer.Line($"#region {resource.Type.Name}");
    //                    WriteExtensionGetResourceFromIdMethod(_writer, resource);
    //                    _writer.LineRaw("#endregion");
    //                    _writer.Line();
    //                }
    //            }
    //        }
    //    }
    //}
}

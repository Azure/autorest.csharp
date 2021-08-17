// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Mgmt.Output;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Utilities;
using Azure.ResourceManager.Management;

namespace AutoRest.CSharp.Mgmt.Generation
{
    internal class ManagementGroupExtensionsWriter : MgmtExtensionWriter
    {
        protected override string Description => "A class to add extension methods to ManagementGroup.";
        protected override string TypeNameOfThis => ResourceTypeBuilder.TypeToExtensionName[ResourceTypeBuilder.ManagementGroups];
        protected override string ExtensionOperationVariableName => "managementGroup";

        protected override Type ExtensionOperationVariableType => typeof(ManagementGroup);

        public override void WriteExtension(CodeWriter writer, BuildContext<MgmtOutputLibrary> context)
        {
            var @namespace = context.DefaultNamespace;
            using (writer.Namespace(@namespace))
            {
                writer.WriteXmlDocumentationSummary($"{Description}");
                using (writer.Scope($"{Accessibility} static partial class {TypeNameOfThis}"))
                {
                    foreach (var resource in context.Library.ManagementGroupChildResources)
                    {
                        writer.Line($"#region {resource.Type.Name}");
                        if (resource.IsSingletonResource)
                        {
                            WriteGetSingletonResourceMethod(writer, resource);
                        }
                        else
                        {
                            // a non-singleton resource must have a resource container
                            WriteGetResourceContainerMethod(writer, resource.ResourceContainer!);
                        }
                        writer.LineRaw("#endregion");
                        writer.Line();
                    }

                }
            }
        }

        protected override bool ShouldPassThrough(ref string dotParent, Stack<string> parentNameStack, Parameter parameter, ref string valueExpression)
        {
            return true;
        }

        protected override void MakeResourceNameParamPassThrough(RestClientMethod method, List<ParameterMapping> parameterMapping, Stack<string> parentNameStack)
        {
        }
    }
}

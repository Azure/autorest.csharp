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
        private CodeWriter _writer;
        public ManagementGroupExtensionsWriter(CodeWriter writer, BuildContext<MgmtOutputLibrary> context) : base(context)
        {
            _writer = writer;
        }

        protected override string Description => "A class to add extension methods to ManagementGroup.";
        protected override string TypeNameOfThis => ResourceTypeBuilder.TypeToExtensionName[ResourceTypeBuilder.ManagementGroups];
        protected override string ExtensionOperationVariableName => "managementGroup";

        protected override Type ExtensionOperationVariableType => typeof(ManagementGroup);

        public override void WriteExtension()
        {
            using (_writer.Namespace(Context.DefaultNamespace))
            {
                _writer.WriteXmlDocumentationSummary($"{Description}");
                using (_writer.Scope($"{Accessibility} static partial class {TypeNameOfThis}"))
                {
                    foreach (var resource in Context.Library.ManagementGroupChildResources)
                    {
                        _writer.Line($"#region {resource.Type.Name}");
                        if (resource.OperationGroup.TryGetSingletonResourceSuffix(Configuration, out var singletonResourceSuffix))
                        {
                            WriteGetSingletonResourceMethod(_writer, resource, singletonResourceSuffix);
                        }
                        else
                        {
                            // a non-singleton resource must have a resource container
                            WriteGetResourceContainerMethod(_writer, resource.ResourceContainer!);
                        }
                        _writer.LineRaw("#endregion");
                        _writer.Line();
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

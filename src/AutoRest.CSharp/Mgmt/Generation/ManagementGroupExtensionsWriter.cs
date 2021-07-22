// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Mgmt.Output;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;
using Azure.ResourceManager.Core;

namespace AutoRest.CSharp.Mgmt.Generation
{
    internal class ManagementGroupExtensionsWriter : MgmtExtensionWriter
    {
        protected override string Description => "A class to add extension methods to ManagementGroup.";
        protected override string TypeNameOfThis => ResourceTypeBuilder.TypeToExtensionName[ResourceTypeBuilder.ManagementGroups];
        protected override string ExtensionOperationVariableName => "managementGroup";

        protected override Type ExtensionOperationVariableType => typeof(ManagementGroupOperations);

        public override void WriteExtension(CodeWriter writer, BuildContext<MgmtOutputLibrary> context)
        {
            var @namespace = context.DefaultNamespace;
            using (writer.Namespace(@namespace))
            {
                writer.WriteXmlDocumentationSummary($"{Description}");
                using (writer.Scope($"{Accessibility} static partial class {TypeNameOfThis}"))
                {
                    foreach (var resource in context.Library.ArmResource)
                    {
                        if (resource.OperationGroup.IsScopeResource(context.Configuration.MgmtConfiguration))
                        {
                            writer.Line($"#region {resource.Type.Name}");
                            var resourceContainer = context.Library.GetResourceContainer(resource.OperationGroup);
                            WriteGetScopeResourceContainerMethod(writer, resourceContainer!);
                            writer.LineRaw("#endregion");
                        }
                        writer.Line();
                    }

                }
            }
        }

        private void WriteGetScopeResourceContainerMethod(CodeWriter writer, ResourceContainer resourceContainer)
        {
            writer.WriteXmlDocumentationSummary($"Gets an object representing a {resourceContainer.Type.Name} along with the instance operations that can be performed on it.");
            writer.WriteXmlDocumentationParameter(ExtensionOperationVariableName, $"The <see cref=\"{typeof(ManagementGroupOperations)}\" /> instance the method will execute against.");
            writer.WriteXmlDocumentationReturns($"Returns a <see cref=\"{resourceContainer.Type.Name}\" /> object.");

            using (writer.Scope($"public static {resourceContainer.Type} Get{resourceContainer.Type.Name}(this {typeof(ManagementGroupOperations)} {ExtensionOperationVariableName})"))
            {
                writer.Line($"return new {resourceContainer.Type.Name}({ExtensionOperationVariableName});");
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

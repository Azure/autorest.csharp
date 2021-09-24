// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Linq;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Input.Source;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Mgmt.Generation;
using AutoRest.CSharp.MgmtTest.Generation;
using AutoRest.CSharp.Output.Models.Types;

namespace AutoRest.CSharp.AutoRest.Plugins
{
    internal class MgmtTestTarget
    {
        public static void Execute(GeneratedCodeWorkspace project, CodeModel codeModel, SourceInputModel? sourceInputModel, Configuration configuration)
        {
            BuildContext<MgmtOutputLibrary> context = new BuildContext<MgmtOutputLibrary>(codeModel, configuration, sourceInputModel);
            var restClientWriter = new RestClientWriter();
            var serializeWriter = new SerializationWriter();
            var resourceGroupExtensionsWriter = new ResourceGroupExtensionsWriter();
            var subscriptionExtensionsWriter = new SubscriptionExtensionsWriter();
            var mgmtLongRunningOperationWriter = new MgmtLongRunningOperationWriter();


            var extensionsWriter = new CodeWriter();
            var mockExtensionWriter = new TestHelperWriter(extensionsWriter, context);
            mockExtensionWriter.WriteMockExtension();
            project.AddGeneratedFile($"Mock/TestHelper.cs", extensionsWriter.ToString());

            foreach (var resourceContainer in context.Library.ResourceContainers)
            {
                //if (!resourceContainer.OperationGroup.ParentResourceType(context.Configuration.MgmtConfiguration).Equals(ResourceTypeBuilder.ResourceGroups))
                if (!ResourceContainerTestWriter.CanCreateParentResourceFromExample(context, resourceContainer))
                {   // TODO: currently generate only resourceGroup's child containers
                    continue;
                }
                var codeWriter = new CodeWriter();
                var containerWriter = new ResourceContainerTestWriter(codeWriter, resourceContainer, context);
                containerWriter.WriteContainerTest();

                project.AddGeneratedFile($"Mock/{resourceContainer.Type.Name}Test.cs", codeWriter.ToString());
            }
        }
    }
}

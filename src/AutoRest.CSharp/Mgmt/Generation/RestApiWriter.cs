// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Output.Models.Types;
using Azure.ResourceManager.Core;

namespace AutoRest.CSharp.Mgmt.Generation
{
    internal class RestApiWriter : MgmtClientBaseWriter
    {
        public void Write(CodeWriter writer, OperationGroup operationGroup, BuildContext<MgmtOutputLibrary> context)
        {
            _restClient = context.Library.GetRestClient(operationGroup);

            using (writer.Namespace(context.DefaultNamespace))
            {
                writer.WriteXmlDocumentationSummary(operationGroup.Language?.CSharp?.Description);
                string baseClass = $"ContainerBase";
                using (writer.Scope($"public partial class RestApiContainer : {baseClass}"))
                {
                    WriteFields(writer, _restClient);
                    WriteContainerCtors(writer, "RestApiContainer", typeof(ResourceOperationsBase));
                    WriteContainerProperties(writer, "ResourceIdentifier.RootResourceIdentifier.ResourceType");
                    WriteMethods(writer, operationGroup);
                }
            }
        }

        private void WriteMethods(CodeWriter writer, OperationGroup operationGroup)
        {
            //throw new NotImplementedException();
        }
    }
}

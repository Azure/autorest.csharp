// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Linq;
using AutoRest.CSharp.Common.Output.Builders;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Types;

namespace AutoRest.CSharp.Mgmt.Generation
{
    internal class RestApiWriter : MgmtClientBaseWriter
    {
        public void Write(CodeWriter writer, OperationGroup operationGroup, BuildContext<MgmtOutputLibrary> context)
        {
            _restClient = context.Library.GetRestClient(operationGroup);
            if (_restClient == null)
                throw new InvalidOperationException("Attempting to write RestApiContainer but no RestOperation class was found");

            using (writer.Namespace(context.DefaultNamespace))
            {
                writer.WriteXmlDocumentationSummary(operationGroup.Language?.CSharp?.Description);
                string baseClass = $"ContainerBase";
                using (writer.Scope($"public partial class RestApiContainer : {baseClass}"))
                {
                    WriteFields(writer, _restClient);
                    WriteContainerCtors(writer, "RestApiContainer", "ClientContext", "parent.ClientOptions, parent.Credential, parent.BaseUri, parent.Pipeline");
                    WriteContainerProperties(writer, "ResourceIdentifier.RootResourceIdentifier.ResourceType");
                    var operationType = context.Library.FindTypeByName("RestApi");
                    if (operationType != null)
                        WriteMethods(writer, operationGroup, operationType);
                }
            }
        }

        private void WriteMethods(CodeWriter writer, OperationGroup operationGroup, CSharpType type)
        {
            WriteList(writer, false, type, GetPagingMethod(operationGroup, type), $"");
            WriteList(writer, true, type, GetPagingMethod(operationGroup, type), $"");
        }

        private PagingMethod GetPagingMethod(OperationGroup operationGroup, CSharpType type)
        {
            return ClientBuilder.BuildPagingMethods(operationGroup, _restClient!, type.Implementation.Declaration).First();
        }
    }
}

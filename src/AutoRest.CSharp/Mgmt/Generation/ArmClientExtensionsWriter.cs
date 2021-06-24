// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Linq;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Output.Models.Types;
using Azure.ResourceManager.Core;

namespace AutoRest.CSharp.Mgmt.Generation
{
    internal class ArmClientExtensionsWriter
    {
        protected string Description = "A class to add extension methods to ArmClient.";
        protected string Accessibility = "public";
        protected string Type = "ArmClientExtensions";

        public void WriteExtension(CodeWriter writer, BuildContext<MgmtOutputLibrary> context)
        {
            using (writer.Namespace(context.DefaultNamespace))
            {
                writer.WriteXmlDocumentationSummary(Description);
                using (writer.Scope($"{Accessibility} static partial class {Type}"))
                {
                    WriteGetContainers(writer, context);
                }
            }
        }

        private void WriteGetContainers(CodeWriter writer, BuildContext<MgmtOutputLibrary> context)
        {
            if (context.Library.RestApiOperationGroup != null)
            {
                writer.WriteXmlDocumentationSummary($"Gets an object representing a the rest api operations.");
                writer.WriteXmlDocumentationReturns($"Returns a <see cref=\"RestApiContainer\" /> object.");
                using (writer.Scope($"public static RestApiContainer Get{context.DefaultNamespace.Split(".").Last()}RestApis (this {typeof(ArmClient)} armClient)"))
                {
                    writer.Line($"return armClient.GetContainer((clientOptions, credential, baseUri, pipeline) =>");
                    using (writer.Scope())
                    {
                        writer.Line($"return new RestApiContainer(new ClientContext(clientOptions, credential, baseUri, pipeline));");
                    }
                    writer.Line($");");
                }
            }
        }
    }
}

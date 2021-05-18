// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoRest.CSharp.AutoRest.Plugins;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Mgmt.Output;
using Azure;
using Azure.ResourceManager.Core;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Mgmt.AutoRest;
using System.Text.RegularExpressions;

namespace AutoRest.CSharp.Mgmt.Generation
{
    internal class ResourceOperationWriter
    {
        private const string ClientDiagnosticsVariable = "clientDiagnostics";
        private const string PipelineVariable = "pipeline";

        public void WriteClient(CodeWriter writer, ResourceOperation resourceOperation, BuildContext<MgmtOutputLibrary> context)
        {
            var cs = resourceOperation.Type;
            var @namespace = cs.Namespace;
            using (writer.Namespace(@namespace))
            {
                writer.WriteXmlDocumentationSummary(resourceOperation.Description);
                using (writer.Scope($"{resourceOperation.Declaration.Accessibility} partial class {cs.Name} : ResourceOperationsBase<{resourceOperation.ResourceIdentifierType}, {resourceOperation.ResourceName}>"))
                {
                    WriteClientCtors(writer, resourceOperation);
                    WriteClientProperties(writer, resourceOperation, context.Configuration.MgmtConfiguration);
                    WriteClientMethods(writer, resourceOperation, context);
                }
            }
        }

        private void WriteClientCtors(CodeWriter writer, ResourceOperation resourceOperation)
        {
            var typeOfThis = resourceOperation.Type.Name;

            // write an internal default constructor
            writer.WriteXmlDocumentationSummary($"Initializes a new instance of the <see cref=\"{typeOfThis}\"/> class for mocking.");
            using (writer.Scope($"protected {typeOfThis}()"))
            { }

            // write "generic resource" constructor
            writer.Line();
            writer.WriteXmlDocumentationSummary($"Initializes a new instance of the <see cref=\"{typeOfThis}\"/> class.");
            writer.WriteXmlDocumentationParameter("genericOperations", $"An instance of <see cref=\"{typeof(GenericResourceOperations)}\"/> that has an id for a {resourceOperation.ResourceName}.");
            using (writer.Scope($"internal {typeOfThis}({typeof(GenericResourceOperations)} genericOperations) : base(genericOperations, genericOperations.Id)"))
            { }

            // write "resource + id" constructor
            writer.Line();
            writer.WriteXmlDocumentationSummary($"Initializes a new instance of the <see cref=\"{typeOfThis}\"/> class.");
            writer.WriteXmlDocumentationParameter("options", "The client parameters to use in these operations.");
            writer.WriteXmlDocumentationParameter("id", "The identifier of the resource that is the target of operations.");
            using (writer.Scope($"protected {typeOfThis}({typeof(ResourceOperationsBase)} options, {resourceOperation.ResourceIdentifierType} id) : base(options, id)"))
            { }
        }

        private void WriteClientProperties(CodeWriter writer, ResourceOperation resourceOperation, MgmtConfiguration config)
        {
            writer.Line();
            writer.Line($"public static readonly {typeof(ResourceType)} ResourceType = \"{resourceOperation.OperationGroup.ResourceType(config)}\";");
            writer.Line($"protected override {typeof(ResourceType)} ValidResourceType => ResourceType;");
        }

        private void WriteClientMethods(CodeWriter writer, ResourceOperation resourceOperation, BuildContext<MgmtOutputLibrary> context)
        {
            writer.Line();
            writer.WriteXmlDocumentationInheritDoc();
            using (writer.Scope($"public override {typeof(Response)}<{resourceOperation.ResourceName}> Get({typeof(CancellationToken)} cancellationToken = default)"))
            {
                writer.Line($"throw new {typeof(NotImplementedException)}();");
            }

            writer.Line();
            writer.WriteXmlDocumentationInheritDoc();
            using (writer.Scope($"public override Task<{typeof(Response)}<{resourceOperation.ResourceName}>> GetAsync({typeof(CancellationToken)} cancellationToken = default)"))
            {
                writer.Line($"throw new {typeof(NotImplementedException)}();");
            }

            writer.Line();
            writer.WriteXmlDocumentationSummary($"Lists all available geo-locations.");
            writer.WriteXmlDocumentationParameter("cancellationToken", "A token to allow the caller to cancel the call to the service. The default value is <see cref=\"P: System.Threading.CancellationToken.None\" />.");
            writer.WriteXmlDocumentationReturns("A collection of location that may take multiple service requests to iterate over.");
            using (writer.Scope($"public {typeof(IEnumerable<LocationData>)} ListAvailableLocations({typeof(CancellationToken)} cancellationToken = default)"))
            {
                writer.Line($"return ListAvailableLocations(ResourceType);");
            }

            writer.Line();
            writer.WriteXmlDocumentationSummary($"Lists all available geo-locations.");
            writer.WriteXmlDocumentationParameter("cancellationToken", "A token to allow the caller to cancel the call to the service. The default value is <see cref=\"P: System.Threading.CancellationToken.None\" />.");
            writer.WriteXmlDocumentationReturns("An async collection of location that may take multiple service requests to iterate over.");
            writer.WriteXmlDocumentationException(typeof(InvalidOperationException), "The default subscription id is null.");
            using (writer.Scope($"public async {typeof(Task<IEnumerable<LocationData>>)} ListAvailableLocationsAsync({typeof(CancellationToken)} cancellationToken = default)"))
            {
                writer.Line($"return await ListAvailableLocationsAsync(ResourceType, cancellationToken);");
            }
            writer.Line();

            foreach (var item in context.CodeModel.OperationGroups)
            {
                if (item.ParentResourceType(context.Configuration.MgmtConfiguration).Equals(resourceOperation.OperationGroup.ResourceType(context.Configuration.MgmtConfiguration)))
                {
                    var container = context.Library.ResourceContainers.FirstOrDefault(x => x.ResourceName.Equals(item.Resource(context.Configuration.MgmtConfiguration)));
                    if (container == null)
                        return;
                    writer.WriteXmlDocumentationSummary($"Gets a list of {container.ResourceName} in the {resourceOperation.ResourceName}.");
                    writer.WriteXmlDocumentationReturns($"An object representing collection of {Pluralization(container.ResourceName)} and their operations over a {resourceOperation.ResourceName}.");
                    using (writer.Scope($"public {container.Type} Get{Pluralization(container.ResourceName)}()"))
                    {
                        writer.Line($"return new {container.Type}(this);");
                    }
                    writer.Line();
                }
            }
        }

        internal static string Pluralization(string single)
        {
            if (new Regex("([^aeiou])y$").IsMatch(single))
            {
                single = Regex.Replace(single, "([^aeiou])y$", "ie");
            }
            else if (new Regex("fe?$").IsMatch(single))
            {
                single = Regex.Replace(single, "fe?$", "ve");
            }
            else if (new Regex("([^aeiou]o|[sxz]|[cs]h)$").IsMatch(single))
            {
                single = Regex.Replace(single, "([^aeiou]o|[sxz]|[cs]h)$", "e");
            }
            return single + "s";
        }
    }
}

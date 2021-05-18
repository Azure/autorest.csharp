// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoRest.CSharp.AutoRest.Plugins;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Mgmt.Output;
using AutoRest.CSharp.Output.Models.Types;
using Azure;
using Azure.ResourceManager.Core;
using System.Text.RegularExpressions;

namespace AutoRest.CSharp.Mgmt.Generation
{
    internal class ResourceOperationWriter
    {
        private const string ClientDiagnosticsVariable = "clientDiagnostics";
        private const string PipelineVariable = "pipeline";

        public void WriteClient(CodeWriter writer, ResourceOperation resourceOperation, BuildContext<MgmtOutputLibrary> context)
        {
            var config = context.Configuration.MgmtConfiguration;
            var cs = resourceOperation.Type;
            var @namespace = cs.Namespace;
            var isSingleton = resourceOperation.OperationGroup.IsSingletonResource(config);
            var baseClass = isSingleton ? "SingletonOperationsBase" : "ResourceOperationsBase";
            using (writer.Namespace(@namespace))
            {
                writer.WriteXmlDocumentationSummary(resourceOperation.Description);
                using (writer.Scope($"{resourceOperation.Declaration.Accessibility} partial class {cs.Name} : {baseClass}<{resourceOperation.ResourceIdentifierType}, {resourceOperation.ResourceName}>"))
                {
                    WriteClientCtors(writer, resourceOperation, isSingleton);
                    WriteClientProperties(writer, resourceOperation, config);

                    // TODO Write singleton operations
                    if (!isSingleton)
                    {
                        WriteClientMethods(writer, resourceOperation, context);
                    }

                    WriteChildSingletonGetOperationMethods(writer, resourceOperation, context);
                }
            }
        }

        private void WriteClientCtors(CodeWriter writer, ResourceOperation resourceOperation, bool isSingleton = false)
        {
            var typeOfThis = resourceOperation.Type.Name;
            var baseConstructorCall = isSingleton ? "base(genericOperations)" : "base(genericOperations, genericOperations.Id)";
            var constructorType = isSingleton ? typeof(OperationsBase) : typeof(GenericResourceOperations);

            // write an internal default constructor
            writer.WriteXmlDocumentationSummary($"Initializes a new instance of the <see cref=\"{typeOfThis}\"/> class for mocking.");
            using (writer.Scope($"protected {typeOfThis}()"))
            { }

            // write "resource + id" constructor
            writer.Line();
            writer.WriteXmlDocumentationSummary($"Initializes a new instance of the <see cref=\"{typeOfThis}\"/> class.");
            writer.WriteXmlDocumentationParameter("options", "The client parameters to use in these operations.");
            writer.WriteXmlDocumentationParameter("id", "The identifier of the resource that is the target of operations.");
            baseConstructorCall = isSingleton ? "base(options)" : "base(options, id)";
            using (writer.Scope($"internal protected {typeOfThis}({typeof(ResourceOperationsBase)} options, {resourceOperation.ResourceIdentifierType} id) : {baseConstructorCall}"))
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
            var config = context.Configuration.MgmtConfiguration;
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
                if (item.ParentResourceType(config).Equals(resourceOperation.OperationGroup.ResourceType(config))
                    && !item.IsSingletonResource(config))
                {
                    var container = context.Library.ResourceContainers.FirstOrDefault(x => x.ResourceName.Equals(item.Resource(config)));
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


        private void WriteChildSingletonGetOperationMethods(CodeWriter writer, ResourceOperation currentOperation, BuildContext<MgmtOutputLibrary> context)
        {
            var config = context.Configuration.MgmtConfiguration;
            foreach (var operation in context.Library.ResourceOperations)
            {
                if (operation.OperationGroup.IsSingletonResource(config)
                    && operation.OperationGroup.ParentResourceType(config).Equals(currentOperation.OperationGroup.ResourceType(config)))
                {
                    writer.Line($"#region Get {operation.Type.Name}s operation");

                    writer.WriteXmlDocumentationSummary($"Gets an object representing a {operation.Type.Name} along with the instance operations that can be performed on it.");
                    writer.WriteXmlDocumentationReturns($"Returns a <see cref=\"{operation.Type.Name}\" /> object.");
                    using (writer.Scope($"public {operation.Type} Get{operation.Type.Name}s()"))
                    {
                        writer.Line($"return new {operation.Type.Name}(this);");
                    }
                    writer.LineRaw("#endregion");
                    writer.Line();
                }
            }
        }

    }
}

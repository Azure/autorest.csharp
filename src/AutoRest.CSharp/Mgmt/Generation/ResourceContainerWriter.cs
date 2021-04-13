// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Shared;
using Azure.Core;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Mgmt.Output;
using Azure.ResourceManager.Core.Resources;
using Azure;
using Azure.ResourceManager.Core;
using Azure.Core.Pipeline;
using System.Threading.Tasks;

namespace AutoRest.CSharp.Mgmt.Generation
{
    /// <summary>
    /// Code writer for resource container.
    /// A resource container should have 3 operations:
    /// 1. CreateOrUpdate (4 variants)
    /// 2. Get (2 variants)
    /// 3. List (4 variants)
    /// and the following builder methods:
    /// 1. Construct
    /// </summary>
    internal class ResourceContainerWriter
    {
        private const string ClientDiagnosticsVariable = "clientDiagnostics";
        private const string PipelineVariable = "pipeline";

        public void WriteClient(CodeWriter writer, ResourceContainer resourceContainer)
        {
            writer.UseNamespace(typeof(Task).Namespace!); // I need to explicitly use namespace here because
            // at build time I don't have the type information inside Task<>

            var cs = resourceContainer.Type;
            var @namespace = cs.Namespace;
            using (writer.Namespace(@namespace))
            {
                writer.WriteXmlDocumentationSummary(resourceContainer.Description);
                var baseClass = $"ResourceContainerBase<{resourceContainer.ResourceIdentifierType}, {resourceContainer.ResourceDefaultName}, {resourceContainer.DataDefaultName}>";
                using (writer.Scope($"{resourceContainer.Declaration.Accessibility} partial class {cs.Name:D} : {baseClass}"))
                {
                    WriteClientCtors(writer, resourceContainer);
                    WriteFields(writer, resourceContainer);
                    WriteIdProperty(writer, resourceContainer);
                    WriteValidResourceType(writer, resourceContainer);
                    WriteResourceOperations(writer, resourceContainer);
                    WriteBuilders(writer, resourceContainer);
                }
            }
        }

        private void WriteClientCtors(CodeWriter writer, ResourceContainer resourceContainer)
        {
            writer.WriteXmlDocumentationSummary($"Initializes a new instance of {resourceContainer.Type.Name} class.");
            var resourceGroupParameterName = "resourceGroup";
            writer.WriteXmlDocumentationParameter(resourceGroupParameterName, "The parent resource group.");

            using (writer.Scope($"internal {resourceContainer.Type.Name:D}(ResourceGroupOperations {resourceGroupParameterName}) : base({resourceGroupParameterName})"))
            {
                writer.Line($"_clientDiagnostics = new ClientDiagnostics(ClientOptions);");
                writer.Line($"_pipeline = new HttpPipeline(ClientOptions.Transport);");
            }
        }

        private void WriteFields(CodeWriter writer, ResourceContainer resourceContainer)
        {
            writer.Line();
            writer.Line($"private readonly {typeof(ClientDiagnostics)} _clientDiagnostics;");
            writer.Line($"private readonly {typeof(HttpPipeline)} _pipeline;");

            writer.Line();
            writer.WriteXmlDocumentationSummary($"Represents the REST operations.");
            writer.Line($"private {resourceContainer.RestOperationsDefaultName} Operations => new {resourceContainer.RestOperationsDefaultName}(_clientDiagnostics, _pipeline, Id.SubscriptionId);");
        }

        private void WriteIdProperty(CodeWriter writer, ResourceContainer resourceContainer)
        {
            writer.Line();
            writer.WriteXmlDocumentationSummary($"Typed Resource Identifier for the container.");
            writer.LineRaw("// todo: hard coding ResourceGroupResourceIdentifier we don't know the exact ID type but we need it in implementations in CreateOrUpdate() etc.");
            writer.Line($"public new ResourceGroupResourceIdentifier Id => base.Id as ResourceGroupResourceIdentifier;");
        }

        private void WriteValidResourceType(CodeWriter writer, ResourceContainer resourceContainer)
        {
            writer.Line();
            writer.WriteXmlDocumentationInheritDoc();
            // todo: what if valid resource type is not resource group?
            writer.Line($"protected override ResourceType ValidResourceType => {"ResourceGroupOperations"}.ResourceType;");
        }

        private void WriteResourceOperations(CodeWriter writer, ResourceContainer resourceContainer)
        {
            writer.Line();
            writer.LineRaw($"// Container level operations.");

            // To generate resource operations, we need to find out the correct REST client methods to call.
            // We can't find CreateOrUpdate method by name cause it may not always be called `CreateOrUpdate`.
            if (FindRestClientMethodByHttpMethod(resourceContainer, RequestMethod.Put, out var restClientMethod))
            {
                WriteCreateOrUpdateVariants(writer, resourceContainer, restClientMethod);
            }
            else
            {
                WriteFakeCreateOrUpdateVariants(writer, resourceContainer);
            }

            // We can't find Get method by HTTP method because it may map to List
            if (FindRestClientMethodByHttpMethod(resourceContainer, new string[] { "Get" }, out restClientMethod))
            {
                WriteGetVariants(writer, resourceContainer, restClientMethod);
            }

            WriteListAsGenericResource(writer, resourceContainer);
            WriteListAsGenericResourceAsync(writer, resourceContainer);
            WriteList(writer, resourceContainer);
            WriteListAsync(writer, resourceContainer);
        }

        private bool FindRestClientMethodByHttpMethod(ResourceContainer resourceContainer, RequestMethod httpMethod, out RestClientMethod restMethod)
        {
            restMethod = resourceContainer.RestClient.Methods.FirstOrDefault(m => m.Request.HttpMethod.Equals(httpMethod));
            return restMethod != null;
        }
        private bool FindRestClientMethodByHttpMethod(ResourceContainer resourceContainer, IEnumerable<string> nameOptions, out RestClientMethod restMethod)
        {
            restMethod = resourceContainer.RestClient.Methods.FirstOrDefault(m => nameOptions.Any(nameOption => string.Equals(m.Name, nameOption, StringComparison.InvariantCultureIgnoreCase)));
            return restMethod != null;
        }

        private void WriteCreateOrUpdateVariants(CodeWriter writer, ResourceContainer resourceContainer, RestClientMethod restClientMethod)
        {
            // hack: should add a IsLongRunning property to method?
            var isLongRunning = restClientMethod.Responses.All(response => response.ResponseBody == null);
            var parameterMapping = BuildParameterMapping(restClientMethod);

            // CreateOrUpdate()
            writer.Line();
            writer.WriteXmlDocumentationInheritDoc();
            foreach (var parameter in parameterMapping.Where(p => p.IsPassThru))
            {
                writer.WriteXmlDocumentationParameter(parameter.Parameter.Name, parameter.Parameter.Description);
            }
            writer.WriteXmlDocumentationParameter("cancellationToken", @"A token to allow the caller to cancel the call to the service. The default value is <see cref=""P:System.Threading.CancellationToken.None"" />.");

            writer.Append($"public override ArmResponse<{resourceContainer.ResourceDefaultName}> CreateOrUpdate(");
            foreach (var parameter in parameterMapping.Where(p => p.IsPassThru))
            {
                writer.WriteParameter(parameter.Parameter);
            }
            using (writer.Scope($"{typeof(CancellationToken)} cancellationToken = default)"))
            {
                writer.Append($"return StartCreateOrUpdate(");
                foreach (var parameter in parameterMapping)
                {
                    if (parameter.IsPassThru)
                    {
                        writer.AppendRaw($"{parameter.Parameter.Name}, ");
                    }
                }
                writer.Line($"cancellationToken: cancellationToken).WaitForCompletion();");
            }

            // CreateOrUpdateAsync()
            writer.Line();
            writer.WriteXmlDocumentationInheritDoc();
            foreach (var parameter in parameterMapping.Where(p => p.IsPassThru))
            {
                writer.WriteXmlDocumentationParameter(parameter.Parameter.Name, parameter.Parameter.Description);
            }
            writer.WriteXmlDocumentationParameter("cancellationToken", @"A token to allow the caller to cancel the call to the service. The default value is <see cref=""P:System.Threading.CancellationToken.None"" />.");

            writer.Append($"public async override Task<ArmResponse<{resourceContainer.ResourceDefaultName}>> CreateOrUpdateAsync(");
            foreach (var parameter in parameterMapping.Where(p => p.IsPassThru))
            {
                writer.WriteParameter(parameter.Parameter);
            }
            using (writer.Scope($"{typeof(CancellationToken)} cancellationToken = default)"))
            {
                writer.Append($"var operation = await StartCreateOrUpdateAsync(");
                foreach (var parameter in parameterMapping)
                {
                    if (parameter.IsPassThru)
                    {
                        writer.AppendRaw($"{parameter.Parameter.Name}, ");
                    }
                }
                writer.Line($"cancellationToken: cancellationToken).ConfigureAwait(false);");
                writer.Line($"return operation.WaitForCompletion();");  // no WaitForCompletionAsync()?
            }

            // StartCreateOrUpdate()
            writer.Line();
            writer.WriteXmlDocumentationInheritDoc();
            foreach (var parameter in parameterMapping.Where(p => p.IsPassThru))
            {
                writer.WriteXmlDocumentationParameter(parameter.Parameter.Name, parameter.Parameter.Description);
            }
            writer.WriteXmlDocumentationParameter("cancellationToken", @"A token to allow the caller to cancel the call to the service. The default value is <see cref=""P:System.Threading.CancellationToken.None"" />.");

            writer.Append($"public override ArmOperation<{resourceContainer.ResourceDefaultName}> StartCreateOrUpdate(");
            foreach (var parameter in parameterMapping.Where(p => p.IsPassThru))
            {
                writer.WriteParameter(parameter.Parameter);
            }
            using (writer.Scope($"{typeof(CancellationToken)} cancellationToken = default)"))
            {
                writer.Append($"var originalResponse = Operations.{restClientMethod.Name}(");
                foreach (var parameter in parameterMapping)
                {
                    writer.AppendRaw(parameter.IsPassThru ? parameter.Parameter.Name : parameter.ValueExpression);
                    writer.AppendRaw(", ");
                }
                writer.Line($"cancellationToken: cancellationToken);");
                if (isLongRunning)
                {
                    writer.Line($"var operation = new {resourceContainer.ResourceDefaultName}{restClientMethod.Name}Operation(");
                    writer.Line($"_clientDiagnostics, _pipeline, Operations.Create{restClientMethod.Name}Request(");
                    foreach (var parameter in parameterMapping)
                    {
                        writer.AppendRaw(parameter.IsPassThru ? parameter.Parameter.Name : parameter.ValueExpression);
                        writer.AppendRaw(", ");
                    }
                    writer.RemoveTrailingComma();
                    writer.Line($").Request,");
                    writer.Line($"originalResponse);");
                    writer.Line($"return new ArmOperation<{resourceContainer.ResourceDefaultName}, {resourceContainer.DataDefaultName}>(");
                    writer.Line($"operation,");
                    writer.Line($"data => new {resourceContainer.ResourceDefaultName}(Parent, data));");
                }
                else
                {
                    writer.Line($"return new ArmOperation<{resourceContainer.ResourceDefaultName}, {resourceContainer.DataDefaultName}>(");
                    writer.Line($"originalResponse,");
                    writer.Line($"data => new {resourceContainer.ResourceDefaultName}(Parent, data));");

                }
            }

            // StartCreateOrUpdateAsync()
            writer.Line();
            writer.WriteXmlDocumentationInheritDoc();
            foreach (var parameter in parameterMapping.Where(p => p.IsPassThru))
            {
                writer.WriteXmlDocumentationParameter(parameter.Parameter.Name, parameter.Parameter.Description);
            }
            writer.WriteXmlDocumentationParameter("cancellationToken", @"A token to allow the caller to cancel the call to the service. The default value is <see cref=""P:System.Threading.CancellationToken.None"" />.");

            writer.Append($"public async override Task<ArmOperation<{resourceContainer.ResourceDefaultName}>> StartCreateOrUpdateAsync(");
            foreach (var parameter in parameterMapping.Where(p => p.IsPassThru))
            {
                writer.WriteParameter(parameter.Parameter);
            }
            using (writer.Scope($"{typeof(CancellationToken)} cancellationToken = default)"))
            {
                writer.Append($"var originalResponse = await Operations.{restClientMethod.Name}Async(");
                foreach (var parameter in parameterMapping)
                {
                    writer.AppendRaw(parameter.IsPassThru ? parameter.Parameter.Name : parameter.ValueExpression);
                    writer.AppendRaw(", ");
                }
                writer.Line($"cancellationToken: cancellationToken).ConfigureAwait(false);");
                if (isLongRunning)
                {
                    writer.Line($"var operation = new {resourceContainer.ResourceDefaultName}{restClientMethod.Name}Operation(");
                    writer.Line($"_clientDiagnostics, _pipeline, Operations.Create{restClientMethod.Name}Request(");
                    foreach (var parameter in parameterMapping)
                    {
                        writer.AppendRaw(parameter.IsPassThru ? parameter.Parameter.Name : parameter.ValueExpression);
                        writer.AppendRaw(", ");
                    }
                    writer.RemoveTrailingComma();
                    writer.Line($").Request,");
                    writer.Line($"originalResponse);");
                    writer.Line($"return new ArmOperation<{resourceContainer.ResourceDefaultName}, {resourceContainer.DataDefaultName}>(");
                    writer.Line($"operation,");
                    writer.Line($"data => new {resourceContainer.ResourceDefaultName}(Parent, data));");
                }
                else
                {
                    writer.Line($"return new ArmOperation<{resourceContainer.ResourceDefaultName}, {resourceContainer.DataDefaultName}>(");
                    writer.Line($"originalResponse,");
                    writer.Line($"data => new {resourceContainer.ResourceDefaultName}(Parent, data));");
                }
            }
        }

        /// <summary>
        /// Builds the mapping between resource operations in Container class and that in RestOperations class.
        /// </summary>
        /// <param name="method">Represents a method in RestOperations class.</param>
        /// <returns>
        /// A list of tuples containing
        /// - Parameter: the reference to the parameter object in RestClientMethod
        /// - IsPassThru: should the parameter be passed through from the method in container class
        /// - ValueExpression: if not pass-through, this is the value to pass in RestClientMethod
        /// </returns>
        private IEnumerable<(Parameter Parameter, bool IsPassThru, string ValueExpression)> BuildParameterMapping(RestClientMethod method)
        {
            var parameterMapping = new List<(Parameter Parameter, bool IsPassThru, string ValueExpression)>();
            var dotParent = "";

            foreach (var parameter in method.Parameters)
            {
                bool passThru = true;
                string valueExpression = string.Empty;
                if (parameter.Type.Equals(typeof(System.String)))
                {
                    // todo: how about "location"?
                    if (string.Equals(parameter.Name, "resourceGroupName", StringComparison.InvariantCultureIgnoreCase))
                    {
                        passThru = false;
                        valueExpression = "Id.ResourceGroupName";
                    }
                    else
                    {
                        passThru = false;
                        valueExpression = $"Id{dotParent}.Name";
                        dotParent += ".Parent";
                    }
                }
                else
                {
                    passThru = true;
                }
                parameterMapping.Add((parameter, passThru, valueExpression));
            }
            // make last string parameter (typically the resource name) pass-through from container method
            // ignoring optional parameters such as `expand`
            var lastString = parameterMapping.LastOrDefault(parameter => parameter.Parameter.Type.Equals(typeof(System.String)) && parameter.Parameter.DefaultValue is null);
            if (lastString.Parameter != null && !lastString.Parameter.Name.Equals("resourceGroupName", StringComparison.InvariantCultureIgnoreCase))
            {
                var index = parameterMapping.IndexOf(lastString);
                parameterMapping[index] = (lastString.Parameter, true, string.Empty);
                // can't just do `lastString.IsPassThru = true` as it does not affect parameterMapping
                // lastString is not a ref?
            }
            return parameterMapping;
        }

        /// <summary>
        /// Write 4 variants of CreateOrUpdate that only throw exceptions when the resource does not support PUT,
        /// so that the container class implements the methods overload defined in `ContainerBase`.
        /// </summary>
        /// <param name="writer"></param>
        private void WriteFakeCreateOrUpdateVariants(CodeWriter writer, ResourceContainer resourceContainer)
        {
            var nameParameter = new Parameter("name", "The name of the resource.", typeof(string), null, false);
            var resourceDetailsParameter = new Parameter("resourceDetails", "The desired resource configuration.", resourceContainer.ResourceData.Type, null, false);
            // CreateOrUpdate()
            writer.Line();
            writer.WriteXmlDocumentationInheritDoc();
            var parameters = new List<Parameter> { nameParameter, resourceDetailsParameter };
            writer.Append($"public override ArmResponse<{resourceContainer.ResourceDefaultName}> CreateOrUpdate(");
            parameters.ForEach(parameter => writer.WriteParameter(parameter));
            var doesNotSupportPut = @"This resource does not support PUT HTTP method.";
            using (writer.Scope($"{typeof(CancellationToken)} cancellationToken = default)"))
            {
                writer.Line($"// {doesNotSupportPut}");
                writer.Line($"throw new {typeof(NotImplementedException)}();");
            }

            // CreateOrUpdateAsync()
            writer.Line();
            writer.WriteXmlDocumentationInheritDoc();
            writer.Append($"public override Task<ArmResponse<{resourceContainer.ResourceDefaultName}>> CreateOrUpdateAsync(");
            parameters.ForEach(parameter => writer.WriteParameter(parameter));
            using (writer.Scope($"{typeof(CancellationToken)} cancellationToken = default)"))
            {
                writer.Line($"// {doesNotSupportPut}");
                writer.Line($"throw new {typeof(NotImplementedException)}();");
            }

            // StartCreateOrUpdate()
            writer.Line();
            writer.WriteXmlDocumentationInheritDoc();
            writer.Append($"public override ArmOperation<{resourceContainer.ResourceDefaultName}> StartCreateOrUpdate(");
            parameters.ForEach(parameter => writer.WriteParameter(parameter));
            using (writer.Scope($"{typeof(CancellationToken)} cancellationToken = default)"))
            {
                writer.Line($"// {doesNotSupportPut}");
                writer.Line($"throw new {typeof(NotImplementedException)}();");
            }

            // StartCreateOrUpdateAsync()
            writer.Line();
            writer.WriteXmlDocumentationInheritDoc();
            writer.Append($"public override Task<ArmOperation<{resourceContainer.ResourceDefaultName}>> StartCreateOrUpdateAsync(");
            parameters.ForEach(parameter => writer.WriteParameter(parameter));
            using (writer.Scope($"{typeof(CancellationToken)} cancellationToken = default)"))
            {
                writer.Line($"// {doesNotSupportPut}");
                writer.Line($"throw new {typeof(NotImplementedException)}();");
            }
        }

        private void WriteCreateOrUpdateAsync(CodeWriter writer, ResourceContainer resourceContainer)
        {

            writer.Line();
            writer.WriteXmlDocumentationInheritDoc();
            using (writer.Scope($"public async override Task<ArmResponse<{resourceContainer.ResourceDefaultName}>> CreateOrUpdateAsync(string name, {resourceContainer.DataDefaultName} resourceDetails, {typeof(CancellationToken)} cancellationToken = default)"))
            {
                writer.Line($"var response = await Operations.CreateOrUpdateAsync(Id.ResourceGroupName, name, resourceDetails).ConfigureAwait(false);");
                writer.Line($"return new ArmResponse<{resourceContainer.ResourceDefaultName}, {resourceContainer.DataDefaultName}>(");
                writer.Line($"response,");
                writer.Line($"data => new {resourceContainer.ResourceDefaultName}(Parent, data));");
            }
        }

        private void WriteStartCreateOrUpdate(CodeWriter writer, ResourceContainer resourceContainer)
        {
            writer.Line();
            writer.WriteXmlDocumentationInheritDoc();
            using (writer.Scope($"public override ArmOperation<{resourceContainer.ResourceDefaultName}> StartCreateOrUpdate(string name, {resourceContainer.DataDefaultName} resourceDetails, {typeof(CancellationToken)} cancellationToken = default)"))
            {
                writer.Line($"return new ArmOperation<{resourceContainer.ResourceDefaultName}, {resourceContainer.DataDefaultName}>(");
                writer.Line($"Operations.CreateOrUpdate(Id.ResourceGroupName, name, resourceDetails, cancellationToken),");
                writer.Line($"data => new {resourceContainer.ResourceDefaultName}(Parent, data));");
            }
        }

        private void WriteStartCreateOrUpdateAsync(CodeWriter writer, ResourceContainer resourceContainer)
        {
            writer.Line();
            writer.WriteXmlDocumentationInheritDoc();
            using (writer.Scope($"public async override Task<ArmOperation<{resourceContainer.ResourceDefaultName}>> StartCreateOrUpdateAsync(string name, {resourceContainer.DataDefaultName} resourceDetails, {typeof(CancellationToken)} cancellationToken = default)"))
            {
                writer.Line($"return new ArmOperation<{resourceContainer.ResourceDefaultName}, {resourceContainer.DataDefaultName}>(");
                writer.Line($"await Operations.CreateOrUpdateAsync(Id.ResourceGroupName, name, resourceDetails, cancellationToken).ConfigureAwait(false),");
                writer.Line($"data => new {resourceContainer.ResourceDefaultName}(Parent, data));");
            }
        }

        private void WriteGetVariants(CodeWriter writer, ResourceContainer resourceContainer, RestClientMethod method)
        {
            var parameterMapping = BuildParameterMapping(method);
            // some Get() contains extra non-name parameters which if added to method signature,
            // would break the inheritance to ResourceContainerBase
            // e.g. `expand` when getting image in compute RP
            parameterMapping = parameterMapping.Where(mapping => mapping.Parameter.DefaultValue is null);

            // Get()
            writer.Line();
            writer.WriteXmlDocumentationInheritDoc();
            foreach (var parameter in parameterMapping.Where(p => p.IsPassThru))
            {
                writer.WriteXmlDocumentationParameter(parameter.Parameter.Name, parameter.Parameter.Description);
            }
            writer.WriteXmlDocumentationParameter("cancellationToken", @"A token to allow the caller to cancel the call to the service. The default value is <see cref=""P:System.Threading.CancellationToken.None"" />.");

            writer.Append($"public override ArmResponse<{resourceContainer.ResourceDefaultName}> Get(");
            foreach (var parameter in parameterMapping.Where(p => p.IsPassThru))
            {
                writer.WriteParameter(parameter.Parameter);
            }
            using (writer.Scope($"{typeof(CancellationToken)} cancellationToken = default)"))
            {
                writer.Line($"return new ArmResponse<{resourceContainer.ResourceDefaultName}, {resourceContainer.DataDefaultName}>(");
                writer.Append($"Operations.Get(");
                foreach (var parameter in parameterMapping)
                {
                    writer.AppendRaw(parameter.IsPassThru ? parameter.Parameter.Name : parameter.ValueExpression);
                    writer.AppendRaw(", ");
                }
                writer.Line($"cancellationToken: cancellationToken),");
                writer.Line($"data => new {resourceContainer.ResourceDefaultName}(Parent, data));");
            }

            // GetAsync()
            writer.Line();
            writer.WriteXmlDocumentationInheritDoc();
            foreach (var parameter in parameterMapping.Where(p => p.IsPassThru))
            {
                writer.WriteXmlDocumentationParameter(parameter.Parameter.Name, parameter.Parameter.Description);
            }
            writer.WriteXmlDocumentationParameter("cancellationToken", @"A token to allow the caller to cancel the call to the service. The default value is <see cref=""P:System.Threading.CancellationToken.None"" />.");

            writer.Append($"public async override Task<ArmResponse<{resourceContainer.ResourceDefaultName}>> GetAsync(");
            foreach (var parameter in parameterMapping.Where(p => p.IsPassThru))
            {
                writer.WriteParameter(parameter.Parameter);
            }
            using (writer.Scope($"{typeof(CancellationToken)} cancellationToken = default)"))
            {
                writer.Line($"return new ArmResponse<{resourceContainer.ResourceDefaultName}, {resourceContainer.DataDefaultName}>(");
                writer.Append($"await Operations.GetAsync(");
                foreach (var parameter in parameterMapping)
                {
                    writer.AppendRaw(parameter.IsPassThru ? parameter.Parameter.Name : parameter.ValueExpression);
                    writer.AppendRaw(", ");
                }
                writer.Line($"cancellationToken: cancellationToken),");
                writer.Line($"data => new {resourceContainer.ResourceDefaultName}(Parent, data));");
            }
        }

        private void WriteGetAsync(CodeWriter writer, ResourceContainer resourceContainer, RestClientMethod method)
        {
            writer.Line();
            writer.WriteXmlDocumentationInheritDoc();
            using (writer.Scope($"public async override Task<ArmResponse<{resourceContainer.ResourceDefaultName}>> GetAsync(string name, {typeof(CancellationToken)} cancellationToken = default)"))
            {
                writer.Line($"return new ArmResponse<{resourceContainer.ResourceDefaultName}, {resourceContainer.DataDefaultName}>(");
                writer.Line($"await Operations.GetAsync(Id.ResourceGroupName, name, cancellationToken),");
                writer.Line($"data => new {resourceContainer.ResourceDefaultName}(Parent, data));");
            }
        }

        private void WriteList(CodeWriter writer, ResourceContainer resourceContainer)
        {
            writer.Line();
            // todo: do not hard code resource type
            writer.WriteXmlDocumentationSummary($"Filters the list of {"todo: availability set"} for this resource group. Makes an additional network call to retrieve the full data model for each resource group.");
            writer.WriteXmlDocumentationParameter("nameFilter", "The filter used in this operation.");
            writer.WriteXmlDocumentationParameter("top", "The number of results to return.");
            writer.WriteXmlDocumentationParameter("cancellationToken", "A token to allow the caller to cancel the call to the service. The default value is <see cref=\"P:System.Threading.CancellationToken.None\" />.");
            // todo: do not hard code resource type
            writer.WriteXmlDocumentation("returns", $"A collection of {"todo: availability set"} that may take multiple service requests to iterate over.");
            using (writer.Scope($"public Pageable<{resourceContainer.ResourceDefaultName}> List(string nameFilter, int? top = null, {typeof(CancellationToken)} cancellationToken = default)"))
            {
                writer.Line($"var results = ListAsGenericResource(nameFilter, top, cancellationToken);");
                writer.Line($"return new PhWrappingPageable<GenericResource, {resourceContainer.ResourceDefaultName}>(results, genericResource => new {resourceContainer.OperationsDefaultName}(genericResource).Get().Value);");
            }
        }

        private void WriteListAsync(CodeWriter writer, ResourceContainer resourceContainer)
        {
            writer.Line();
            // todo: do not hard code resource type
            writer.WriteXmlDocumentationSummary($"Filters the list of {"todo: availability set"} for this resource group. Makes an additional network call to retrieve the full data model for each resource group.");
            writer.WriteXmlDocumentationParameter("nameFilter", "The filter used in this operation.");
            writer.WriteXmlDocumentationParameter("top", "The number of results to return.");
            writer.WriteXmlDocumentationParameter("cancellationToken", "A token to allow the caller to cancel the call to the service. The default value is <see cref=\"P:System.Threading.CancellationToken.None\" />.");
            // todo: do not hard code resource type
            writer.WriteXmlDocumentation("returns", $"An async collection of {"todo: availability set"} that may take multiple service requests to iterate over.");
            using (writer.Scope($"public AsyncPageable<{resourceContainer.ResourceDefaultName}> ListAsync(string nameFilter, int? top = null, {typeof(CancellationToken)} cancellationToken = default)"))
            {
                writer.Line($"var results = ListAsGenericResourceAsync(nameFilter, top, cancellationToken);");
                writer.Line($"return new PhWrappingAsyncPageable<GenericResource, {resourceContainer.ResourceDefaultName}>(results, genericResource => new {resourceContainer.OperationsDefaultName}(genericResource).Get().Value);");
            }
        }

        private void WriteListAsGenericResource(CodeWriter writer, ResourceContainer resourceContainer)
        {
            writer.Line();
            // todo: do not hard code resource type
            writer.WriteXmlDocumentationSummary($"Filters the list of {"todo: availability set"} for this resource group represented as generic resources.");
            writer.WriteXmlDocumentationParameter("nameFilter", "The filter used in this operation.");
            writer.WriteXmlDocumentationParameter("top", "The number of results to return.");
            writer.WriteXmlDocumentationParameter("cancellationToken", "A token to allow the caller to cancel the call to the service. The default value is <see cref=\"P:System.Threading.CancellationToken.None\" />.");
            writer.WriteXmlDocumentation("returns", $"A collection of resource that may take multiple service requests to iterate over.");
            using (writer.Scope($"public {typeof(Pageable<GenericResource>)} ListAsGenericResource(string nameFilter, int? top = null, {typeof(CancellationToken)} cancellationToken = default)"))
            {
                writer.Line($"var filters = new {typeof(ResourceFilterCollection)}({resourceContainer.DataDefaultName}.ResourceType);");
                writer.Line($"filters.SubstringFilter = nameFilter;");
                // todo: do not hard code ResourceGroupOperations
                writer.Line($"return ResourceListOperations.ListAtContext(Parent as ResourceGroupOperations, filters, top, cancellationToken);");
            }
        }

        private void WriteListAsGenericResourceAsync(CodeWriter writer, ResourceContainer resourceContainer)
        {
            writer.Line();
            // todo: do not hard code resource type
            writer.WriteXmlDocumentationSummary($"Filters the list of {"todo: availability set"} for this resource group represented as generic resources.");
            writer.WriteXmlDocumentationParameter("nameFilter", "The filter used in this operation.");
            writer.WriteXmlDocumentationParameter("top", "The number of results to return.");
            writer.WriteXmlDocumentationParameter("cancellationToken", "A token to allow the caller to cancel the call to the service. The default value is <see cref=\"P:System.Threading.CancellationToken.None\" />.");
            writer.WriteXmlDocumentation("returns", $"An async collection of resource that may take multiple service requests to iterate over.");
            using (writer.Scope($"public {typeof(AsyncPageable<GenericResource>)} ListAsGenericResourceAsync(string nameFilter, int? top = null, {typeof(CancellationToken)} cancellationToken = default)"))
            {
                writer.Line($"var filters = new {typeof(ResourceFilterCollection)}({resourceContainer.DataDefaultName}.ResourceType);");
                writer.Line($"filters.SubstringFilter = nameFilter;");
                // todo: do not hard code ResourceGroupOperations
                writer.Line($"return ResourceListOperations.ListAtContextAsync(Parent as ResourceGroupOperations, filters, top, cancellationToken);");
            }
        }

        private void WriteBuilders(CodeWriter writer, ResourceContainer resourceContainer)
        {
            writer.Line();
            writer.LineRaw($"// Builders.");
            writer.LineRaw($"// public ArmBuilder<{resourceContainer.ResourceIdentifierType}, {resourceContainer.ResourceDefaultName}, {resourceContainer.DataDefaultName}> Construct() {{ }}");
        }
    }
}

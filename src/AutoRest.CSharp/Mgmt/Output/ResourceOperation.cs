// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoRest.CSharp.Common.Output.Builders;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Mgmt.Generation;
using AutoRest.CSharp.Output.Builders;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Responses;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Utilities;

namespace AutoRest.CSharp.Mgmt.Output
{
    internal class ResourceOperation : TypeProvider
    {
        private const string ClientSuffixValue = "Client";
        private const string OperationsSuffixValue = "Operations";
        private const string ContainerSuffixValue = "Container";
        private const string DataSuffixValue = "Data";
        private Type? _resourceIdentifierType;
        private BuildContext<MgmtOutputLibrary> _context;
        private IEnumerable<ClientMethod>? _methods;
        private IEnumerable<PagingMethod>? _pagingMethods;
        private ClientMethod? _getMethod;
        private List<ClientMethod>? _getMethods;

        private IDictionary<OperationGroup, MgmtNonResourceOperation> _childOperations;

        internal OperationGroup OperationGroup { get; }
        protected MgmtRestClient? _restClient;

        public ResourceOperation(OperationGroup operationGroup, BuildContext<MgmtOutputLibrary> context,
            IEnumerable<OperationGroup>? nonResourceOperationGroups = null) : base(context)
        {
            _context = context;
            OperationGroup = operationGroup;
            DefaultName = ResourceName + SuffixValue;
            _childOperations = nonResourceOperationGroups?.ToDictionary(operationGroup => operationGroup,
                operationGroup => new MgmtNonResourceOperation(operationGroup, context, DefaultName)) ?? new Dictionary<OperationGroup, MgmtNonResourceOperation>();
        }

        public Resource Resource => _context.Library.GetArmResource(OperationGroup);

        public string ResourceName => Resource.Type.Name;

        protected virtual string SuffixValue => OperationsSuffixValue;

        protected override string DefaultName { get; }

        protected override string DefaultAccessibility { get; } = "public";

        public string Description => BuilderHelpers.EscapeXmlDescription(CreateDescription(OperationGroup, ResourceName));

        public MgmtRestClient RestClient => _restClient ??= _context.Library.GetRestClient(OperationGroup);

        public ResourceData ResourceData => _context.Library.GetResourceData(OperationGroup);

        public Type ResourceIdentifierType => _resourceIdentifierType ??= OperationGroup.GetResourceIdentifierType(_context);

        public IEnumerable<ClientMethod> Methods => _methods ??= GetMethodsInScope();

        public IDictionary<OperationGroup, MgmtNonResourceOperation> ChildOperations => _childOperations;

        public IEnumerable<PagingMethod> PagingMethods => _pagingMethods ??= ClientBuilder.BuildPagingMethods(OperationGroup, RestClient, Declaration, OverridePagingMethodName);

        private string OverridePagingMethodName(OperationGroup operationGroup, Operation operation, RestClientMethod restClientMethod)
        {
            // override the name for ListBySubscription
            if (restClientMethod.Name == "ListAll" || restClientMethod.Name == "ListBySubscription")
            {
                return $"List{ResourceName.ToPlural()}";
            }

            return restClientMethod.Name;
        }

        public virtual ClientMethod? GetMethod => _getMethod ??= Methods.FirstOrDefault(m => m.Name.StartsWith("Get") && m.RestClientMethod.Responses[0].ResponseBody?.Type.Name == ResourceData.Type.Name && m.RestClientMethod.Parameters.FirstOrDefault()?.Name.Equals("scope") == true) ?? Methods.FirstOrDefault(m => m.Name.StartsWith("Get") && m.RestClientMethod.Responses[0].ResponseBody?.Type.Name == ResourceData.Type.Name);

        public virtual List<ClientMethod> GetMethods => _getMethods ??= GetGetMethods();

        private List<ClientMethod> GetGetMethods()
        {
            var getMethods = Methods.Where(m => m.Name.StartsWith("Get") && m.RestClientMethod.Responses[0].ResponseBody?.Type.Name == ResourceData.Type.Name).ToList();
            // TODO: remove GetByIdMethod
            // if (GetByIdMethod != null && GetByIdMethod != GetMethod)
            // {
            //     getMethods.Remove(GetByIdMethod);
            // }
            return getMethods;
        }

        protected virtual IEnumerable<ClientMethod> GetMethodsInScope()
        {
            return ClientBuilder.BuildMethods(OperationGroup, RestClient, Declaration);
        }

        public Diagnostic GetDiagnostic(RestClientMethod method)
        {
            return new Diagnostic($"{Declaration.Name}.{method.Name}", Array.Empty<DiagnosticAttribute>());
        }

        protected virtual string CreateDescription(OperationGroup operationGroup, string clientPrefix)
        {
            return string.IsNullOrWhiteSpace(operationGroup.Language.Default.Description) ?
                $"A class representing the operations that can be performed over a specific {clientPrefix}." :
                BuilderHelpers.EscapeXmlDescription(operationGroup.Language.Default.Description);
        }
    }
}

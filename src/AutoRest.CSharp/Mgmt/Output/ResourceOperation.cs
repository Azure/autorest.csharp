// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

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
using AutoRest.CSharp.Output.Models.Types;

namespace AutoRest.CSharp.Mgmt.Output
{
    internal class ResourceOperation : TypeProvider
    {
        private const string ClientSuffixValue = "Client";
        private const string OperationsSuffixValue = "Operations";
        private const string ContainerSuffixValue = "Container";
        private const string DataSuffixValue = "Data";
        private string _prefix;
        private BuildContext<MgmtOutputLibrary> _context;
        private PagingMethod[]? _pagingMethods;

        public OperationGroup _operationGroup { get; protected set; }
        protected MgmtRestClient? _restClient;

        public ResourceOperation(OperationGroup operationGroup, BuildContext<MgmtOutputLibrary> context)
            : base(context)
        {
            _context = context;
            _operationGroup = operationGroup;
            _prefix = operationGroup.Resource(context.Configuration.MgmtConfiguration);
            DefaultName = _prefix + SuffixValue;
        }

        public string ResourceName => _operationGroup.Resource(_context.Configuration.MgmtConfiguration);

        protected virtual string SuffixValue => OperationsSuffixValue;

        protected override string DefaultName { get; }

        protected override string DefaultAccessibility { get; } = "public";

        public string Description => BuilderHelpers.EscapeXmlDescription(CreateDescription(_operationGroup, _prefix));

        public MgmtRestClient RestClient => _restClient ??= _context.Library.FindRestClient(_operationGroup);

        public string ResourceIdentifierType => _operationGroup.GetResourceIdentifierType();

        public PagingMethod[] PagingMethods => _pagingMethods ??= ClientBuilder.BuildPagingMethods(_operationGroup, RestClient, Declaration).ToArray();

        protected virtual string CreateDescription(OperationGroup operationGroup, string clientPrefix)
        {
            StringBuilder summary = new StringBuilder();
            return string.IsNullOrWhiteSpace(operationGroup.Language.Default.Description) ?
                $"A class representing the operations that can be performed over a specific {clientPrefix}." :
                BuilderHelpers.EscapeXmlDescription(operationGroup.Language.Default.Description);
        }
    }
}

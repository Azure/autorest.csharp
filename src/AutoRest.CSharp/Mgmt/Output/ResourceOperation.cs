// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Text;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Generation;
using AutoRest.CSharp.Output.Builders;
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

        protected OperationGroup _operationGroup;
        protected MgmtRestClient? _restClient;
        protected ResourceData? _resourceData;

        public ResourceOperation(OperationGroup operationGroup, BuildContext<MgmtOutputLibrary> context)
            : base(context)
        {
            _context = context;
            _operationGroup = operationGroup;
            _prefix = operationGroup.Resource;
            DefaultName = _prefix + SuffixValue;
        }

        public string ResourceName => _operationGroup.Resource;

        protected virtual string SuffixValue => OperationsSuffixValue;

        protected override string DefaultName { get; }

        protected override string DefaultAccessibility { get; } = "public";

        public string Description => BuilderHelpers.EscapeXmlDescription(CreateDescription(_operationGroup, _prefix));

        public MgmtRestClient RestClient => _restClient ??= _context.Library.FindRestClient(_operationGroup);

        /// <summary>
        /// Get the model for the XXXResourceData class related to this operation.
        /// </summary>
        public ResourceData ResourceData => _resourceData ??= _context.Library.FindResourceData(ResourceName);

        public string ResourceIdentifierType => _operationGroup.GetResourceIdentifierType();

        protected virtual string CreateDescription(OperationGroup operationGroup, string clientPrefix)
        {
            StringBuilder summary = new StringBuilder();
            return string.IsNullOrWhiteSpace(operationGroup.Language.Default.Description) ?
                $"A class representing the operations that can be performed over a specific {clientPrefix}." :
                BuilderHelpers.EscapeXmlDescription(operationGroup.Language.Default.Description);
        }

        // helper name loopups so you can quickly find related class names in various writers
        public string ResourceDefaultName => _prefix;
        public string OperationsDefaultName => _prefix + OperationsSuffixValue;
        public string ContainerDefaultName => _prefix + ContainerSuffixValue;
        public string DataDefaultName => _prefix + DataSuffixValue;
        public string RestOperationsDefaultName => RestClient.Type.Name;
    }
}

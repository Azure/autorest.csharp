// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
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
        private Type? _resourceIdentifierType;
        private BuildContext<MgmtOutputLibrary> _context;
        private ClientMethod[]? _methods;
        private PagingMethod[]? _pagingMethods;

        internal OperationGroup OperationGroup { get; }
        protected MgmtRestClient? _restClient;

        public ResourceOperation(OperationGroup operationGroup, BuildContext<MgmtOutputLibrary> context)
            : base(context)
        {
            _context = context;
            OperationGroup = operationGroup;
            _prefix = operationGroup.Resource(context.Configuration.MgmtConfiguration);
            var isExtension = operationGroup.IsExtensionResource(context.Configuration.MgmtConfiguration);
            string midValue = "";
            if (isExtension)
            {
                var parent = operationGroup.ParentResourceType(context.Configuration.MgmtConfiguration);
                var parentArr = parent.Split('/');
                midValue = parentArr[parentArr.Length - 1];
                midValue = FirstCharToUpper(midValue);
            }
            DefaultName = _prefix + midValue + SuffixValue;
        }

        public string ResourceName => OperationGroup.Resource(_context.Configuration.MgmtConfiguration);

        protected virtual string SuffixValue => OperationsSuffixValue;

        protected override string DefaultName { get; }

        protected override string DefaultAccessibility { get; } = "public";

        public string Description => BuilderHelpers.EscapeXmlDescription(CreateDescription(OperationGroup, _prefix));

        public MgmtRestClient RestClient => _restClient ??= _context.Library.GetRestClient(OperationGroup);

        public Type ResourceIdentifierType => _resourceIdentifierType ??= OperationGroup.GetResourceIdentifierType(
            _context.Library.GetResourceData(OperationGroup),
            _context.Configuration.MgmtConfiguration, false);

        public ClientMethod[] Methods => _methods ??= ClientBuilder.BuildMethods(OperationGroup, RestClient, Declaration).ToArray();

        public PagingMethod[] PagingMethods => _pagingMethods ??= ClientBuilder.BuildPagingMethods(OperationGroup, RestClient, Declaration).ToArray();

        protected virtual string CreateDescription(OperationGroup operationGroup, string clientPrefix)
        {
            StringBuilder summary = new StringBuilder();
            return string.IsNullOrWhiteSpace(operationGroup.Language.Default.Description) ?
                $"A class representing the operations that can be performed over a specific {clientPrefix}." :
                BuilderHelpers.EscapeXmlDescription(operationGroup.Language.Default.Description);
        }

        private static string FirstCharToUpper(string input) =>
        input switch
        {
            null => throw new ArgumentNullException(nameof(input)),
            "" => throw new ArgumentException($"{nameof(input)} cannot be empty", nameof(input)),
            _ => input.First().ToString().ToUpper() + input.Substring(1)
        };
    }
}

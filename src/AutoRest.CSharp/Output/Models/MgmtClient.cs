// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Output.Builders;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Responses;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;

namespace AutoRest.CSharp.Output.Models
{
    internal class MgmtClient : ClientBase
    {
        private readonly OperationGroup _operationGroup;
        private MgmtRestClient? _restClient;
        private readonly BuildContext<MgmtOutputLibrary> _context;

        public MgmtClient(OperationGroup operationGroup, BuildContext<MgmtOutputLibrary> context) : base(context)
        {
            _operationGroup = operationGroup;
            _context = context;
            var clientPrefix = GetClientPrefix(operationGroup.Language.Default.Name, Context);
            DefaultName = clientPrefix + ClientSuffix;
            ClientShortName = string.IsNullOrEmpty(clientPrefix) ? DefaultName : clientPrefix;
        }

        public string ClientShortName { get; }
        public string Description => BuilderHelpers.EscapeXmlDescription(CreateDescription(_operationGroup, GetClientPrefix(Declaration.Name, Context)));
        public MgmtRestClient RestClient => _restClient ??= _context.Library.FindRestClient(_operationGroup);

        protected override string DefaultName { get; }

        protected override string DefaultAccessibility { get; } = "public";
        private IEnumerable<Parameter> GetRequiredParameters()
        {
            List<Parameter> parameters = new List<Parameter>();
            foreach (var parameter in RestClient.Parameters)
            {
                if (parameter.DefaultValue == null)
                {
                    parameters.Add(parameter);
                }
            }

            return parameters;
        }

        private IEnumerable<Parameter> GetOptionalParameters()
        {
            List<Parameter> parameters = new List<Parameter>();
            foreach (var parameter in RestClient.Parameters)
            {
                if (parameter.DefaultValue != null && !parameter.IsApiVersionParameter)
                {
                    parameters.Add(parameter);
                }
            }

            return parameters;
        }

        public IReadOnlyCollection<Parameter> GetClientConstructorParameters(CSharpType credentialType)
        {
            List<Parameter> parameters = new List<Parameter>();

            parameters.AddRange(GetRequiredParameters());

            var credentialParam = new Parameter(
                "credential",
                "A credential used to authenticate to an Azure Service.",
                credentialType,
                null,
                true);
            parameters.Add(credentialParam);

            parameters.AddRange(GetOptionalParameters());

            return parameters;
        }
    }
}

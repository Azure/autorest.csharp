// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Shared;

namespace AutoRest.CSharp.Mgmt.Output
{
    internal class MgmtRestClient : RestClient
    {
        private readonly IReadOnlyList<Operation> _operations;
        private IReadOnlyList<Resource>? _resources;

        public string Key { get; }

        public MgmtRestClient(InputClient inputClient, IReadOnlyList<Parameter> clientParameters, IReadOnlyList<Parameter> restClientParameters, List<Operation> operations, string clientName, MgmtOutputLibrary library)
            : base(new ClientMethodsBuilder(inputClient.Operations, library, null, library.TypeFactory), null, clientParameters, restClientParameters, clientName, MgmtContext.Context.DefaultNamespace, MgmtContext.Context.SourceInputModel)
        {
            Key = inputClient.Key;
            _operations = operations;
        }

        public IReadOnlyList<Resource> Resources => _resources ??= _operations.SelectMany(operation => operation.GetResourceFromResourceType()).Distinct().ToList();
    }
}

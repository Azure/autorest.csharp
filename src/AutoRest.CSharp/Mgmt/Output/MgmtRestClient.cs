// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Common.Output.Builders;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Shared;

namespace AutoRest.CSharp.Mgmt.Output
{
    internal class MgmtRestClient : RestClient
    {
        private readonly IReadOnlyList<InputOperation> _operations;
        private IReadOnlyList<Resource>? _resources;

        public MgmtRestClient(InputClient inputClient, IReadOnlyList<Parameter> clientParameters, IReadOnlyList<Parameter> restClientParameters, IReadOnlyList<InputOperation> operations, string clientName, MgmtOutputLibrary library, IReadOnlyDictionary<object, string> renamingMap)
            : base(new ClientMethodsBuilder(inputClient.Operations, library, MgmtContext.Context.SourceInputModel, library.TypeFactory, renamingMap), clientParameters, restClientParameters, clientName, Configuration.Namespace, inputClient.Key, MgmtContext.Context.SourceInputModel)
        {
            _operations = operations;
        }

        public IReadOnlyList<Resource> Resources => _resources ??= _operations.SelectMany(operation => operation.GetResourceFromResourceType()).Distinct().ToList();
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Common.Output.Builders;
using AutoRest.CSharp.Input.Source;
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
        private readonly MgmtOutputLibrary _library;

        public MgmtRestClient(InputClient inputClient, IReadOnlyList<Parameter> clientParameters, IReadOnlyList<Parameter> restClientParameters, IReadOnlyList<InputOperation> operations, string clientName, MgmtOutputLibrary library, SourceInputModel? sourceInputModel)
            : base(new ClientMethodsBuilder(inputClient.Operations, library, sourceInputModel, library.TypeFactory), clientParameters, restClientParameters, clientName, Configuration.Namespace, inputClient.Key, sourceInputModel)
        {
            _library = library;
            _operations = operations;
        }

        public IReadOnlyList<Resource> Resources => _resources ??= _operations.SelectMany(operation => operation.GetResourceFromResourceType(_library)).Distinct().ToList();
    }
}

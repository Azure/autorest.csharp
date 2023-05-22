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
using AutoRest.CSharp.Output.Models.Types;
using Azure.Core;

namespace AutoRest.CSharp.Mgmt.Output
{
    internal class MgmtRestClient : RestClient
    {
        private readonly IReadOnlyList<Operation> _operations;
        private IReadOnlyList<Resource>? _resources;

        public string Key { get; }

        public MgmtRestClient(InputClient inputClient, IReadOnlyList<Parameter> clientParameters, IReadOnlyList<Parameter> restClientParameters, List<Operation> operations, string clientName, MgmtOutputLibrary library)
            : base(new ClientMethodsBuilder(inputClient.Operations, library.TypeFactory, false, true), clientParameters, restClientParameters, library.TypeFactory, library, clientName, MgmtContext.Context.DefaultNamespace, MgmtContext.Context.SourceInputModel)
        {
            Key = inputClient.Key;
            _operations = operations;
        }

        protected override LegacyMethods BuildMethods(OutputLibrary library, OperationMethodsBuilderBase methodBuilder)
        {
            if (methodBuilder.Operation.HttpMethod != RequestMethod.Get)
            {
                return methodBuilder.BuildLegacy(null, null, null);
            }

            var mpgLibrary = (MgmtOutputLibrary)library;
            if (!mpgLibrary.TryGetResourceData(methodBuilder.Operation.Path, out var resourceData))
            {
                return methodBuilder.BuildLegacy(null, null, null);
            }

            var operationSet = mpgLibrary.GetOperationSet(methodBuilder.Operation.Path);
            return methodBuilder.BuildLegacy(null, null, operationSet.IsResource() ? resourceData.Type : null);
        }

        public IReadOnlyList<Resource> Resources => _resources ??= _operations.SelectMany(operation => operation.GetResourceFromResourceType()).Distinct().ToList();
    }
}

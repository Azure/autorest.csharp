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
            : base(inputClient, clientParameters, restClientParameters, library.TypeFactory, library, clientName, MgmtContext.Context.DefaultNamespace, MgmtContext.Context.SourceInputModel)
        {
            Key = inputClient.Key;
            _operations = operations;
        }

        protected override HlcMethods BuildMethods(OutputLibrary library, OperationMethodsBuilder methodBuilder, InputOperation operation)
        {
            if (operation.HttpMethod != RequestMethod.Get)
            {
                return methodBuilder.BuildMpg(null);
            }

            var mpgLibrary = (MgmtOutputLibrary)library;
            if (!mpgLibrary.TryGetResourceData(operation.Path, out var resourceData))
            {
                return methodBuilder.BuildMpg(null);
            }

            var operationSet = mpgLibrary.GetOperationSet(operation.Path);
            return methodBuilder.BuildMpg(operationSet.IsResource() ? resourceData.Type : null);
        }

        public IReadOnlyList<Resource> Resources => _resources ??= _operations.SelectMany(operation => operation.GetResourceFromResourceType()).Distinct().ToList();
    }
}

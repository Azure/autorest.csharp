// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Utilities;

namespace AutoRest.CSharp.Common.Input
{
    internal class RenameInputsVisitor : InputNamespaceVisitor
    {
        private readonly InputNamespace _rootNamespace;
        private const string TopParameterName = "top";
        private const string MaxCountParameterName = "maxCount";
        private readonly string _defaultName;

        private RenameInputsVisitor(InputNamespace rootNamespace)
        {
            _rootNamespace = rootNamespace;
            _defaultName = rootNamespace.Name.ReplaceLast("Client", "");
        }

        public static InputNamespace Visit(InputNamespace rootNamespace) => new RenameInputsVisitor(rootNamespace).VisitNamespace(rootNamespace);

        protected override InputOperation VisitOperation(InputOperation sourceOperation, InputClient sourceClient, InputOperation? targetNextLinkOperation, IReadOnlyDictionary<InputType, InputType> typesMap)
        {
            var clientName = sourceOperation.ResourceName ?? (sourceClient.Name.IsNullOrEmpty() ? _defaultName : sourceClient.Name);
            // operation.Parameters.Any(p => p.Name.Equals(MaxCountParameterName, StringComparison.OrdinalIgnoreCase)

            return base.VisitOperation(sourceOperation with {Name = UpdateOperationName(sourceOperation,  clientName)}, sourceClient, targetNextLinkOperation, typesMap);
        }

        protected override InputParameter VisitOperationParameter(InputParameter sourceParameter, InputOperation sourceOperation, IReadOnlyDictionary<InputType, InputType> typesMap)
        {
            var parameter = sourceOperation.Paging is null && !Configuration.DisablePaginationTopRenaming && sourceParameter.Name.Equals(TopParameterName, StringComparison.OrdinalIgnoreCase) && !sourceOperation.Parameters.Any(p => p.Name.Equals(MaxCountParameterName, StringComparison.OrdinalIgnoreCase))
                ? sourceParameter with { Name = MaxCountParameterName }
                : sourceParameter;

            return base.VisitOperationParameter(parameter, sourceOperation, typesMap);
        }

        private static string UpdateOperationName(InputOperation operation, string clientName)
            => operation.CleanName.RenameGetMethod(clientName).RenameListToGet(clientName);
    }
}

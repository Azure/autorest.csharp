// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License

using System;
using System.Collections.Generic;
using System.Text;
using AutoRest.CSharp.AutoRest.Plugins;
using AutoRest.CSharp.Input;

namespace AutoRest.CSharp.Mgmt.Decorator
{
    internal static class CodeModelExtensions
    {
        public static IEnumerable<OperationGroup> GetResourceOperationGroups(this CodeModel codeModel, MgmtConfiguration config)
        {
            foreach (var operationGroup in codeModel.OperationGroups)
            {
                if (IsResource(operationGroup, config))
                    yield return operationGroup;
            }
        }

        public static IEnumerable<OperationGroup> GetNonResourceOperationGroups(this CodeModel codeModel, MgmtConfiguration config)
        {
            foreach (var operationGroup in codeModel.OperationGroups)
            {
                if (!operationGroup.IsResource(config) && !operationGroup.IsListOnly(config))
                    yield return operationGroup;
            }
        }

        private static bool IsResource(OperationGroup operationGroup, MgmtConfiguration config)
        {
            return operationGroup.IsResource(config) && !operationGroup.IsListOnly(config);
        }
    }
}

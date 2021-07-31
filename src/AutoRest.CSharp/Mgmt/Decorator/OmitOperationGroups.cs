// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Output.Models.Types;

namespace AutoRest.CSharp.Mgmt.Decorator
{
    internal static class OmitOperationGroups
    {
        public static void RemoveOperationGroups(CodeModel codeModel, BuildContext<MgmtOutputLibrary> context)
        {
            var operationGroupsToOmit = context.Configuration.MgmtConfiguration.OperationGroupsToOmit;
            if (operationGroupsToOmit.Length > 0)
            {
                var omitSet = operationGroupsToOmit.ToHashSet();
                codeModel.OperationGroups = codeModel.OperationGroups.Where(og => !omitSet.Contains(og.Key)).ToList();

                OmitOrphanedModels.RemoveOrphanedModels(codeModel);
            }
        }
    }
}

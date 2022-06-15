// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Models;
using AutoRest.CSharp.Utilities;

namespace AutoRest.CSharp.Mgmt.Decorator.Transformer
{
    internal static class BodyParameterNormalizer
    {
        public static void UpdatePatchOperations()
        {
            foreach (var operationGroup in MgmtContext.CodeModel.OperationGroups)
            {
                foreach (var operation in operationGroup.Operations)
                {
                    if (operation.GetHttpMethod() == HttpMethod.Patch)
                    {
                        var bodyParameter = operation.GetBodyParameter();
                        if (bodyParameter != null)
                            bodyParameter.Required = true;
                    }
                }
            }
        }
    }
}

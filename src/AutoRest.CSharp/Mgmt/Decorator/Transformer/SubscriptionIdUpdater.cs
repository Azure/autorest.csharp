// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using AutoRest.CSharp.Input;

namespace AutoRest.CSharp.Mgmt.Decorator.Transformer
{
    internal static class SubscriptionIdUpdater
    {
        public static void Update(CodeModel codeModel)
        {
            bool setSubParam = false;
            foreach (var operationGroup in codeModel.OperationGroups)
            {
                foreach (var op in operationGroup.Operations)
                {
                    foreach (var p in op.Parameters)
                    {
                        // update the first subscriptionId parameter to be 'method' parameter
                        if (!setSubParam && p.Language.Default.Name.Equals("subscriptionId", StringComparison.OrdinalIgnoreCase))
                        {
                            setSubParam = true;
                            p.Implementation = ImplementationLocation.Method;
                            p.Schema.Type = AllSchemaTypes.String;
                        }
                        // update the apiVersion parameter to be 'client' parameter
                        if (p.Origin is not null && p.Origin.Equals("modelerfour:synthesized/api-version", StringComparison.OrdinalIgnoreCase))
                        {
                            p.Implementation = ImplementationLocation.Client;
                        }
                    }
                }
            }
        }

    }
}

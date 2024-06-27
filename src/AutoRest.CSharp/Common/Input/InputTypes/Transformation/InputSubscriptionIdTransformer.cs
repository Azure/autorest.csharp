// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace AutoRest.CSharp.Common.Input
{
    // TODO: remove this workaround
    // We might firstly refine the logoc of getting parent resource for now.
    // Ideally, we should get the parent resource from typespec directly to not depend on Subscriptionid type.
    internal class InputSubscriptionIdTransformer
    {
        public static void Transform(InputNamespace inputNamespace)
        {
            bool setSubParam = false;
            foreach (var client in inputNamespace.Clients)
            {
                foreach (var op in client.Operations)
                {
                    foreach (var p in op.Parameters)
                    {
                        // update the first subscriptionId parameter to be 'method' parameter
                        if (!setSubParam && p.Name.Equals("subscriptionId", StringComparison.OrdinalIgnoreCase))
                        {
                            setSubParam = true;
                            p.Kind = InputOperationParameterKind.Method;
                            p.Type = InputPrimitiveType.String;
                        }
                    }
                }
            }
        }
    }
}

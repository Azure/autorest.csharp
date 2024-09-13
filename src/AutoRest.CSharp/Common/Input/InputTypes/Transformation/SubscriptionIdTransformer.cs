// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;

namespace AutoRest.CSharp.Common.Input.InputTypes.Transformation
{
    internal class SubscriptionIdTransformer
    {
        public static void Transform(InputNamespace inputNamespace)
        {
            foreach (var client in inputNamespace.Clients)
            {
                foreach (var operation in client.Operations)
                {
                    var subscriptionIdParameter = operation.Parameters.Where(p => p.NameInRequest == "subscriptionId").FirstOrDefault();
                    if (subscriptionIdParameter != null)
                    {
                        subscriptionIdParameter.Kind = InputOperationParameterKind.Method;
                    }
                }
            }
        }
    }
}

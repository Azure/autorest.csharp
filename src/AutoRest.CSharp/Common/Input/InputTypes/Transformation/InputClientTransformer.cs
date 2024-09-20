// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;

namespace AutoRest.CSharp.Common.Input
{
    internal class InputClientTransformer
    {
        public static void Transform(InputNamespace input)
        {
            foreach (var client in input.Clients)
            {
                RemoveInternalOperationFromInputClient(client);
                UpdateSubscriptionId(client);
            }
        }

        private static void RemoveInternalOperationFromInputClient(InputClient inputClient)
        {
            var operationsToKeep = new List<InputOperation>();
            foreach (var operation in inputClient.Operations)
            {
                // operations_list has been covered in Azure.ResourceManager already, we don't need to generate it in the client
                if (operation.CrossLanguageDefinitionId != "Azure.ResourceManager.Operations.list")
                {
                    operationsToKeep.Add(operation);
                }
            }
            inputClient.Operations = operationsToKeep;
        }

        private static void UpdateSubscriptionId(InputClient inputClient)
        {
            foreach (var operation in inputClient.Operations)
            {
                var subscriptionIdParameter = operation.Parameters.FirstOrDefault(p => p.NameInRequest.Equals("subscriptionId", StringComparison.OrdinalIgnoreCase));
                if (subscriptionIdParameter != null)
                {
                    subscriptionIdParameter.Kind = InputOperationParameterKind.Method;
                    subscriptionIdParameter.Type = InputPrimitiveType.String;
                }
            }
        }
    }
}

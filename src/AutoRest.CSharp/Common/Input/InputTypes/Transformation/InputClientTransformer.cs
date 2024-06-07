﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace AutoRest.CSharp.Common.Input.InputTypes.Transformation
{
    internal class InputClientTransformer
    {
        // TODO: Skip internal operations for Mgmt, we might need a better way to remove operations, tracking in https://github.com/Azure/typespec-azure/issues/964
        public static void Transform(InputNamespace input)
        {
            foreach (var client in input.Clients)
            {
                RemoveInternalOperationFromInputClient(client);
            }
        }

        private static void RemoveInternalOperationFromInputClient(InputClient inputClient)
        {
            var operationsToKeep = new List<InputOperation>();
            foreach (var operation in inputClient.Operations)
            {
                if (operation.Accessibility == "public")
                {
                    operationsToKeep.Add(operation);
                }
            }
            inputClient.Operations = operationsToKeep;
        }
    }
}

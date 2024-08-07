﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

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
                // "internal" is set only we set access decorator in typespec, default null represents public
                // TODO: Skip internal operations for Mgmt, we might need a better way to remove operations, tracking in https://github.com/Azure/typespec-azure/issues/964
                if (operation.Accessibility == "public")
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
                foreach (var parameter in operation.Parameters)
                {
                    if (parameter.Name.Equals("subscriptionId", StringComparison.OrdinalIgnoreCase))
                    {
                        parameter.Type = InputPrimitiveType.String;
                    }
                }
            }
        }
    }
}

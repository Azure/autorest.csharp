// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Diagnostics;

namespace AutoRest.CSharp.V3.ClientModels
{
    internal struct ClientConstant
    {
        public ClientConstant(object? value, ClientTypeReference type)
        {
            Debug.Assert(value == null || value.GetType().Namespace?.StartsWith("System") == true);
            Value = value;
            Type = type;

            if (value == null)
            {
                if (!type.IsNullable)
                {
                    throw new InvalidOperationException("Null constant with non-nullable type");
                }
                return;
            }

            var expectedType = type switch
            {
                BinaryTypeReference _ => typeof(byte[]),
                FrameworkTypeReference frameworkType => frameworkType.Type,
                _ => throw new InvalidOperationException("Unexpected type kind")
            };

            if (value.GetType() != expectedType)
            {
                throw new InvalidOperationException("Constant type mismatch");
            }
        }

        public object? Value { get; }
        public ClientTypeReference Type { get; }
    }
}

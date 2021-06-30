﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Output.Models.Types;

namespace AutoRest.CSharp.Output.Models.Shared
{
    internal readonly struct Constant
    {
        public static object NewInstanceSentinel { get; } = new object();

        public Constant(object? value, CSharpType type)
        {
            Value = value;
            Type = type;

            if (value == null)
            {
                if (!type.IsNullable)
                {
                    throw new InvalidOperationException($"Null constant with non-nullable type {type}");
                }
            }

            if (value == NewInstanceSentinel)
            {
                return;
            }

            if (!type.IsFrameworkType &&
                type.Implementation is EnumType &&
                value != null &&
                !(value is EnumTypeValue || value is string))
            {
                throw new InvalidOperationException($"Unexpected value '{value}' for enum type '{type}'");
            }

            if (value != null && type.IsFrameworkType && value.GetType() != type.FrameworkType)
            {
                throw new InvalidOperationException("Constant type mismatch");
            }
        }

        public object? Value { get; }
        public CSharpType Type { get; }
        public bool IsNewInstanceSentinel => Value == NewInstanceSentinel;

        public static Constant NewInstanceOf(CSharpType type)
        {
            return new Constant(NewInstanceSentinel, type);
        }

        public static Constant Default(CSharpType type)
        {
            return new Constant(null, type);
        }
    }
}

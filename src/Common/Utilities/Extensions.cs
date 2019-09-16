// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

#pragma warning disable CS3024 // Constraint type is not CLS-compliant
namespace AutoRest.Core.Utilities
{
    /// <summary>
    /// Provides useful extension methods to simplify common coding tasks.
    /// </summary>
    public static class Extensions
    {
        public static bool IsValueType(this Type type) => type.GetTypeInfo().IsValueType;

        private static Type[] ParameterTypes(this IEnumerable<ParameterInfo> parameterInfos) => parameterInfos?.Select(p => p.ParameterType).ToArray();

        public static Type[] ParameterTypes(this MethodBase method) => method?.GetParameters().ParameterTypes();
    }
}
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using static System.Reflection.BindingFlags;

namespace CadlRanchProjects.Tests
{
    public static class TypeAsserts
    {
        public static PropertyInfo HasProperty(Type type, string name, BindingFlags bindingFlags)
        {
            var parameterInfo = type.GetProperties(bindingFlags).FirstOrDefault(p => p.Name == name);
            Assert.NotNull(parameterInfo, $"Property '{name}' is not found");
            return parameterInfo;
        }
    }
}

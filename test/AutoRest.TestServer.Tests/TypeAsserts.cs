// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Reflection;
using NUnit.Framework;

namespace AutoRest.TestServer.Tests
{
    public static class TypeAsserts
    {
        public static MethodInfo HasPublicInstanceMethod(Type type, string name)
        {
            var methodInfo = type.GetMethod(name, BindingFlags.Instance | BindingFlags.Public);
            Assert.NotNull(methodInfo);
            return methodInfo;
        }

        public static ParameterInfo HasParameter(MethodInfo method, string name)
        {
            var parameterInfo = method.GetParameters().FirstOrDefault(p=>p.Name == name);
            Assert.NotNull(parameterInfo);
            return parameterInfo;
        }

        public static PropertyInfo HasProperty(Type type, string name)
        {
            var parameterInfo = type.GetProperties().FirstOrDefault(p=>p.Name == name);
            Assert.NotNull(parameterInfo, $"Property '{name}' is not found");
            return parameterInfo;
        }
    }
}

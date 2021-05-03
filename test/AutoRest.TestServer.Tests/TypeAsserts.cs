// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Reflection;
using NUnit.Framework;
using static System.Reflection.BindingFlags;

namespace AutoRest.TestServer.Tests
{
    public static class TypeAsserts
    {
        public static void TypeIsStatic(Type type)
        {
            if (type.IsAbstract && type.IsSealed && type.GetMembers(Public | NonPublic | Instance).All(m => m.DeclaringType == typeof(object)))
            {
                return;
            }

            Fail($"Type {type} is expected to be static.");
        }

        public static void TypeOnlyDeclaredThesePublicMethods(Type type, params string[] expectedMethodNames)
        {
            var publicMethodNames = type.GetMethods(Public | Static | Instance)
                .Where(m => m.DeclaringType == type)
                .Select(m => m.Name)
                .ToList();

            var missingMethods = string.Join(", ", expectedMethodNames.Except(publicMethodNames).Select(n => "\"" + n + "\"").OrderBy(s => s));
            var extraMethods = string.Join(", ", publicMethodNames.Except(expectedMethodNames).Select(n => "\"" + n + "\"").OrderBy(s => s));
            if (missingMethods.Length == 0)
            {
                if (extraMethods.Length == 0)
                {
                    return;
                }

                Fail($"Type \"{type}\" has public methods {extraMethods} that aren't expected.");
            }

            if (extraMethods.Length == 0)
            {
                Fail($"Type \"{type}\" doesn't have public methods {missingMethods}.");
            }

            Fail($"Type \"{type}\" doesn't have public methods {missingMethods} and has public methods {extraMethods} that aren't expected.");
        }

        public static MethodInfo HasPublicInstanceMethod(Type type, string name)
        {
            var methodInfo = type.GetMethod(name, BindingFlags.Instance | BindingFlags.Public);
            Assert.NotNull(methodInfo);
            return methodInfo;
        }

        public static ParameterInfo HasParameter(ConstructorInfo ctor, string name)
        {
            var parameterInfo = ctor.GetParameters().FirstOrDefault(p=>p.Name == name);
            Assert.NotNull(parameterInfo);
            return parameterInfo;
        }

        public static ParameterInfo HasParameter(MethodInfo method, string name)
        {
            var parameterInfo = method.GetParameters().FirstOrDefault(p=>p.Name == name);
            Assert.NotNull(parameterInfo);
            return parameterInfo;
        }

        public static PropertyInfo HasProperty(Type type, string name, BindingFlags bindingFlags)
        {
            var parameterInfo = type.GetProperties(bindingFlags).FirstOrDefault(p=>p.Name == name);
            Assert.NotNull(parameterInfo, $"Property '{name}' is not found");
            return parameterInfo;
        }

        public static FieldInfo HasField(Type type, string name, BindingFlags bindingFlags)
        {
            var fieldInfo = type.GetFields(bindingFlags).FirstOrDefault(p=>p.Name == name);
            Assert.NotNull(fieldInfo, $"Field '{name}' is not found");
            return fieldInfo;
        }

        private static void Fail(FormattableString message)
        {
            Assert.Fail(FormattableString.Invariant(message));
        }
    }
}

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
        public static void HasNoType(Assembly assembly, string typeName)
        {
            foreach (var type in assembly.DefinedTypes)
            {
                if (type.Name == typeName || $"{type.Namespace}.{type.Name}" == typeName)
                {
                    Assert.Fail($"Assembly \"{assembly.GetName().Name}\" isn't expected to define type \"{typeName}\".");
                }
            }
        }

        public static void TypeIsStatic(Type type)
        {
            if (type.IsAbstract && type.IsSealed && type.GetMembers(Public | NonPublic | Instance).All(m => m.DeclaringType == typeof(object)))
            {
                return;
            }

            Assert.Fail($"Type \"{type}\" is expected to be static.");
        }

        public static void TypeIsNotPublic(Type type)
        {
            if (!type.IsPublic)
            {
                return;
            }

            Assert.Fail($"Type \"{type}\" is expected not to be public.");
        }

        public static void TypeOnlyDeclaresThesePublicMethods(Type type, params string[] expectedMethodNames)
        {
            var publicMethodNames = type.GetMethods(Public | Static | Instance)
                .Where(m => m.DeclaringType == type && !m.IsSpecialName)
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

                Assert.Fail($"Type \"{type}\" has public methods {extraMethods} that aren't expected.");
            }

            if (extraMethods.Length == 0)
            {
                Assert.Fail($"Type \"{type}\" doesn't have public methods {missingMethods}.");
            }

            Assert.Fail($"Type \"{type}\" doesn't have public methods {missingMethods} and has public methods {extraMethods} that aren't expected.");
        }

        public static void HasPublicInstanceMethod(Type type, string methodName, Parameter[] parameters)
        {
            var methodInfo = type.GetMethod(methodName, Instance | Public);
            if (methodInfo == null)
            {
                Assert.Fail($"Type \"{type}\" doesn't have a public method {methodName}.");
            }

            var existingParameters = methodInfo.GetParameters();
            if (existingParameters.Length != parameters.Length)
            {
                Assert.Fail($"Method \"{type}.{methodName}\" is expected to have {parameters.Length} parameters, but it has {existingParameters.Length} parameters.");
            }

            for (var i = 0; i < methodInfo.GetParameters().Length; i++)
            {
                var existingParameter = methodInfo.GetParameters()[i];
                var expectedParameter = parameters[i];
                if (expectedParameter.Type != existingParameter.ParameterType)
                {
                    Assert.Fail($"Method \"{type}.{methodName}\" is expected to have parameter of type {expectedParameter.Type} at position {i}, but its type is {existingParameter.ParameterType}.");
                }

                if (expectedParameter.Name != existingParameter.Name)
                {
                    Assert.Fail($"Method \"{type}.{methodName}\" is expected to have parameter named {expectedParameter.Name} at position {i}, but its name is {existingParameter.Name}.");
                }

                if (expectedParameter.HasDefaultValue)
                {
                    if (!existingParameter.HasDefaultValue)
                    {
                        Assert.Fail($"Method \"{type}.{methodName}\" is expected to have default value \"{expectedParameter.DefaultValue}\" for parameter {expectedParameter.Name} at position {i}, but it has no default value.");
                    }

                    if (!Equals(expectedParameter.DefaultValue, existingParameter.DefaultValue))
                    {
                        Assert.Fail($"Method \"{type}.{methodName}\" is expected to have default value \"{expectedParameter.DefaultValue}\" for parameter {expectedParameter.Name} at position {i}, but it has default value \"{existingParameter.DefaultValue}\".");
                    }
                }
                else if (existingParameter.HasDefaultValue)
                {
                    Assert.Fail($"Method \"{type}.{methodName}\" is expected to have no default value for parameter {expectedParameter.Name} at position {i}, but it has default value \"{existingParameter.DefaultValue}\".");
                }
            }
        }

        public static MethodInfo HasPublicInstanceMethod(Type type, string name)
        {
            var methodInfo = type.GetMethod(name, Instance | Public);
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

        public record Parameter(string Name, Type Type, bool HasDefaultValue, object? DefaultValue)
        {
            public Parameter(string name, Type type) : this(name, type, false, null) {}
            public Parameter(string name, Type type, object? defaultValue) : this(name, type, true, defaultValue) {}
        }
    }
}

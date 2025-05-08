// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Microsoft.CodeAnalysis;
using NUnit.Framework;

namespace AutoRest.TestServer.Tests.Infrastructure
{
    [Parallelizable(ParallelScope.Fixtures)]
    public abstract class TestServerTestBase
    {
        internal static object GetClientDiagnostics(Assembly assembly)
        {
            return GetObject(GetClientDiagnosticsType(assembly), [new TestOptions(), (bool?)null]);
        }

        internal static Type GetOptionalType(Assembly assembly)
        {
            return FindType(assembly, "Optional");
        }

        internal static Type GetClientDiagnosticsType(Assembly assembly)
        {
            return FindType(assembly, "ClientDiagnostics");
        }

        internal static Type FindType(Assembly assembly, string name)
            => assembly.GetTypes().FirstOrDefault(t => t.Name == name);

        internal static object GetClient(Type clientType, params object[] args)
            => GetObject(clientType, [GetClientDiagnostics(clientType.Assembly), .. args]);

        internal static void SetProperty(object obj, string propertyName, object value)
        {
            var property = obj.GetType().GetProperty(propertyName, BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
            property.SetValue(obj, value);
        }

        internal static object GetObject(Type type, params object[] args)
        {
            var constructors = type.GetConstructors(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);

            // First, try to find an exact parameter match
            var exactCtor = constructors.FirstOrDefault(ctor =>
            {
                var parameters = ctor.GetParameters();
                if (parameters.Length != args.Length)
                    return false;
                return parameters.Select(p => p.ParameterType)
                                 .SequenceEqual(args.Select(a => a?.GetType()));
            });

            if (exactCtor != null)
            {
                return exactCtor.Invoke(args);
            }

            // If no exact match, look for a constructor with optional params after provided args
            foreach (var ctor in constructors)
            {
                var parameters = ctor.GetParameters();

                if (parameters.Length >= args.Length &&
                    parameters.Skip(args.Length).All(p => p.IsOptional))
                {
                    return ctor.Invoke([.. args, .. parameters.Skip(args.Length).Select(p => p.DefaultValue)]);
                }
            }

            throw new MissingMethodException($"No matching constructor found for type {type} with the provided arguments.");
        }

        internal static T GetClient<T>(params object[] args) => (T)GetClient(typeof(T), args);

        internal static object GetProperty(object obj, string propertyName)
        {
            return obj.GetType().GetProperty(propertyName, BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public).GetValue(obj);
        }

        internal static object GetStaticProperty(Type type, string propertyName)
        {
            return type.GetProperty(propertyName, BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Public).GetValue(null);
        }

        internal static object InvokeStaticMethod(Type type, string methodName, params object[] args)
            => InvokeMethodInternal(type, null, methodName, [], BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Public, args);

        internal static object InvokeStaticMethod(Type type, string methodName, IEnumerable<Type> genericArgs, params object[] args)
            => InvokeMethodInternal(type, null, methodName, genericArgs, BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Public, args);

        internal static object InvokeMethod(object obj, string methodName, params object[] args)
            => InvokeMethodInternal(obj.GetType(), obj, methodName, [], BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public, args);

        private static object InvokeMethodInternal(Type type, object obj, string methodName, IEnumerable<Type> genericArgs, BindingFlags flags, params object[] args)
        {
            var methods = type.GetMethods(flags);
            MethodInfo? methodInfo = null;
            foreach (var method in methods)
            {
                var methodToTry = method;
                if (genericArgs.Any())
                {
                    methodToTry = methodToTry.MakeGenericMethod([.. genericArgs]);
                }

                if (!methodToTry.Name.Equals(methodName, StringComparison.Ordinal))
                    continue;

                var parameters = methodToTry.GetParameters();
                if (parameters.Length < args.Length)
                    continue;

                //verify the types match for all the args passed in
                int i = 0;
                bool isMatch = true;
                foreach (var parameter in parameters.Take(args.Length))
                {
                    if (!parameter.ParameterType.IsAssignableFrom(args[i++]?.GetType()) &&
                        !CanAssignNull(parameter.ParameterType, args[i -1]))
                    {
                        isMatch = false;
                        break;
                    }
                }

                if (isMatch)
                {
                    methodInfo = methodToTry;
                    break;
                }
            }
            if (methodInfo == null)
                throw new MissingMethodException($"No matching method found for type {type} with the provided name {methodName}.");

            return methodInfo.Invoke(obj, [.. args, .. methodInfo.GetParameters().Skip(args.Length).Select(p => p.DefaultValue)]);
        }

        private static bool CanAssignNull(Type parameterType, object arg)
        {
            if (arg is not null)
                return false;

            return !parameterType.IsValueType ||
                (parameterType.IsGenericType && parameterType.GetGenericTypeDefinition().Equals(typeof(Nullable<>)));
        }

        internal static async Task<object> InvokeMethodAsync(object obj, string methodName, params object[] args)
        {
            var task = (Task)InvokeMethod(obj, methodName, args);
            await task;
            return GetProperty(task, "Result");
        }

        private protected async Task<object> InvokeRestClient(object client, string methodName, params object[] args)
        {
            var restClient = GetProperty(client, "RestClient");
            Task task = (Task)InvokeMethod(restClient, methodName, args);
            await task;
            return GetProperty(task, "Result");
        }

        public Task TestStatus(Func<Uri, HttpPipeline, Response> test, bool ignoreScenario = false, bool useSimplePipeline = false)
        {
            return TestStatus((host, pipeline) => Task.FromResult(test(host, pipeline)), ignoreScenario, useSimplePipeline);
        }

        public Task TestStatus(Func<Uri, HttpPipeline, Task<Response>> test, bool ignoreScenario = false, bool useSimplePipeline = false)
        {
            return TestStatus(GetScenarioName(), test, ignoreScenario, useSimplePipeline);
        }

        internal static void AssertValidStatus(Response r)
        {
            switch (r.Status) {
                case 200:
                case 201:
                case 202:
                case 204:
                    return;
                default:
                    string content = r.Content.ToString();
                    string trimmedContent = content.Substring(0, Math.Min(content.Length, 2000));
                    string message = $"Unexpected response in test.\n Status: {r.Status}\n Reason: {r.ReasonPhrase}\nContent: {trimmedContent}";
                    Assert.Fail (message);
                    return;
            }
        }

        private Task TestStatus(string scenario, Func<Uri, HttpPipeline, Task<Response>> test, bool ignoreScenario = false, bool useSimplePipeline = false) => Test(scenario, async (host, pipeline) =>
        {
            AssertValidStatus (await test(host, pipeline));
        }, ignoreScenario, useSimplePipeline);

        public Task Test(Action<Uri, HttpPipeline> test, bool ignoreScenario = false, bool useSimplePipeline = false)
        {
            return Test(GetScenarioName(), (host, pipeline) =>
            {
                test(host, pipeline);
                return Task.CompletedTask;
            }, ignoreScenario, useSimplePipeline);
        }

        public Task Test(Func<Uri, HttpPipeline, Task> test, bool ignoreScenario = false, bool useSimplePipeline = false)
        {
            return Test(GetScenarioName(), test, ignoreScenario, useSimplePipeline);
        }

        private async Task Test(string scenario, Func<Uri, HttpPipeline, Task> test, bool ignoreScenario = false, bool useSimplePipeline = false)
        {
            var scenarioParameter = ignoreScenario ? new string[0] : new[] {scenario};
            var server = TestServerSession.Start(scenario, false, scenarioParameter);

            try
            {
                var transport = new HttpClientTransport(server.Server.Client);
                var testClientOptions = new TestClientOptions
                {
                    Transport = new FailureInjectingTransport(transport),
                    Retry = { Delay = TimeSpan.FromMilliseconds(1) },
                };
                testClientOptions.AddPolicy(new CustomClientRequestIdPolicy(), HttpPipelinePosition.PerCall);

                var pipeline = useSimplePipeline
                    ? new HttpPipeline(transport)
                    : HttpPipelineBuilder.Build(testClientOptions);

                await test(server.Host, pipeline);
            }
            catch (Exception ex)
            {
                try
                {
                    await server.DisposeAsync();
                }
                catch (Exception disposeException)
                {
                    throw new AggregateException(ex, disposeException);
                }

                throw;
            }

            await server.DisposeAsync();
        }

        private static string GetScenarioName()
        {
            var testName = TestContext.CurrentContext.Test.Name;
            var indexOfUnderscore = testName.IndexOf('_');
            return indexOfUnderscore == -1 ? testName : testName.Substring(0, indexOfUnderscore);
        }

        internal static bool IsCollectionDefined(Assembly assembly, object obj)
        {
            return (bool)InvokeStaticMethod(GetOptionalType(assembly), "IsCollectionDefined", obj.GetType().GetGenericArguments(), obj);
        }

        private class TestClientOptions : ClientOptions
        {

        }
    }
}

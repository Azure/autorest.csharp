// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using AutoRest.TestServer.Tests.Infrastructure;
using Azure.Core;
using Azure.Core.Pipeline;

namespace AutoRest.TestServer.Tests
{
    public class InProcTestBase
    {
        internal static ClientDiagnostics ClientDiagnostics = new ClientDiagnostics(new TestOptions());
        internal static HttpPipeline HttpPipeline = HttpPipelineBuilder.Build(new TestOptions());
        internal static ClientOptions ClientOptions = new TestOptions();

        private protected T GetClient<T>(params object[] args)
            => TestServerTestBase.GetClient<T>(args);

        private protected object GetClient(Type type, params object[] args)
            => TestServerTestBase.GetClient(type, args);

        private protected Type GetType(Assembly assembly, string name)
            => TestServerTestBase.FindType(assembly, name);

        private protected object GetInternalProperty(object obj, string propertyName)
            => TestServerTestBase.GetProperty(obj, propertyName);

        private protected object GetObject(Type type, params object[] args)
            => TestServerTestBase.GetObject(type, args);

        private protected async Task<object> InvokeInternalMethod(object client, string methodName, params object[] args)
        {
            var method = client.GetType().GetMethod(methodName, BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
            //always append default cancellation token
            Task task = (Task)method.Invoke(client, [.. args, default(CancellationToken)]);
            await task;
            return task.GetType().GetProperty("Result").GetValue(task);
        }
    }
}

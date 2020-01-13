// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using AutoRest.CSharp.V3.JsonRpc.MessageModels;
using AutoRest.CSharp.V3.JsonRpc.Messaging;

namespace AutoRest.CSharp.V3
{
    internal static class Program
    {
        private static bool HasServerArgument(IEnumerable<string> args) => args?.Any(a => a.Equals("--server", StringComparison.InvariantCultureIgnoreCase)) ?? false;
        private static bool PluginStart(JsonRpcConnection connection, string pluginName, string sessionId) => PluginProcessor.Start(new JsonRpcCommunication(connection, pluginName, sessionId)).GetAwaiter().GetResult();

        public static int Main(string[] args)
        {
            if (args.Contains("--standalone"))
            {
                return RunStandalone(args);
            }

            if (args.Contains("--launch-debugger") && !Debugger.IsAttached)
            {
                Debugger.Launch();
            }

            if (!HasServerArgument(args))
            {
                Console.WriteLine("Not a valid invocation of this AutoRest extension. Invoke this extension through the AutoRest pipeline.");
                return 1;
            }

            var connection = new JsonRpcConnection(Console.OpenStandardInput(), Console.OpenStandardOutput(),
                new Dictionary<string, IncomingRequestAction>
                {
                    { nameof(IncomingMessageSerializer.GetPluginNames), (c, r) => r.GetPluginNames(PluginProcessor.PluginNames) },
                    { nameof(IncomingMessageSerializer.Process),        (c, r) => r.Process(c, PluginStart) },
                    { nameof(IncomingMessageSerializer.Shutdown),       (c, r) => r.Shutdown(c.CancellationTokenSource) }
                });
            connection.Start();

            Console.Error.WriteLine("Shutting Down");
            return 0;
        }

        private static int RunStandalone(string[] args)
        {
            return PluginProcessor.Start(new HostCommunication(args)).GetAwaiter().GetResult() ? 0 : 1;
        }
    }
}

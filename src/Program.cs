using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.V3.Common.JsonRpc;
using AutoRest.CSharp.V3.Common.Plugins;
using Microsoft.Perks.JsonRPC;

namespace AutoRest.CSharp.V3
{
    internal static class Program
    {
        public static int Main(string[] args)
        {
            if (!HasServerArgument(args))
            {
                Console.WriteLine("Not a valid invocation of this AutoRest extension. Invoke this extension through the AutoRest pipeline.");
                return 1;
            }

            //var autoRestConnection = new Connection(Console.OpenStandardInput(), Console.OpenStandardOutput(), 
            //    (connection, pluginName, sessionId) => new Dispatcher2(connection, pluginName, sessionId).Start(),
            //    "csharp-v3");

            //var connection = new Connection(Console.OpenStandardInput(), Console.OpenStandardOutput());
            //connection.IncomingRequestActions.Add(nameof(IncomingMessages.GetPluginNames), r => r.GetPluginNames("csharp-v3"));
            //connection.IncomingRequestActions.Add(nameof(IncomingMessages.Process), r => r.Process(connection, ));
            //connection.IncomingRequestActions.Add(nameof(IncomingMessages.Shutdown), r => r.GetPluginNames("csharp-v3"));
            //(connection, pluginName, sessionId) => PluginProcessor.Start(new AutoRestInterface(connection, pluginName, sessionId)),
            //"csharp-v3");

            var connection = new Connection(Console.OpenStandardInput(), Console.OpenStandardOutput(),
                new Dictionary<string, IncomingRequestAction>
                {
                    { nameof(IncomingMessages.GetPluginNames), (c, r) => r.GetPluginNames(PluginProcessor.PluginNames) },
                    { nameof(IncomingMessages.Process),        (c, r) => r.Process(c, (c1, pn, si) => PluginProcessor.Start(new AutoRestInterface(c1, pn, si)).Result) },
                    { nameof(IncomingMessages.Shutdown),       (c, r) => r.Shutdown(c.CancellationTokenSource) }
                });

            connection.Start().GetResult();

            Console.Error.WriteLine("Shutting Down");
            return 0;
        }

        private static bool HasServerArgument(IEnumerable<string> args) => args?.Any(a => a.Equals("--server", StringComparison.InvariantCultureIgnoreCase)) ?? false;
    }
}

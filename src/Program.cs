using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.V3.Common.JsonRpc;
using AutoRest.CSharp.V3.Common.JsonRpc.Messaging;

namespace AutoRest.CSharp.V3
{
    internal static class Program
    {
        private static bool HasServerArgument(IEnumerable<string> args) => args?.Any(a => a.Equals("--server", StringComparison.InvariantCultureIgnoreCase)) ?? false;

        public static int Main(string[] args)
        {
            if (!HasServerArgument(args))
            {
                Console.WriteLine("Not a valid invocation of this AutoRest extension. Invoke this extension through the AutoRest pipeline.");
                return 1;
            }

            static bool PluginStart(Connection c, string pn, string si) => PluginProcessor.Start(new AutoRestInterface(c, pn, si)).GetAwaiter().GetResult();
            
            var connection = new Connection(Console.OpenStandardInput(), Console.OpenStandardOutput(),
                new Dictionary<string, IncomingRequestAction>
                {
                    { nameof(IncomingMessages.GetPluginNames), (c, r) => r.GetPluginNames(PluginProcessor.PluginNames) },
                    { nameof(IncomingMessages.Process),        (c, r) => r.Process(c, PluginStart) },
                    { nameof(IncomingMessages.Shutdown),       (c, r) => r.Shutdown(c.CancellationTokenSource) }
                });

            connection.Start();

            Console.Error.WriteLine("Shutting Down");
            return 0;
        }
    }
}

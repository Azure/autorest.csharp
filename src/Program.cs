using System;
using System.Collections.Generic;
using System.Linq;
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

            var autoRestConnection = new Connection(Console.OpenStandardInput(), Console.OpenStandardOutput(),
                (connection, pluginName, sessionId) => PluginProcessor.Start(new AutoRestInterface(connection, pluginName, sessionId)),
                "csharp-v3");

            autoRestConnection.Start().GetResult();

            Console.Error.WriteLine("Shutting Down");
            return 0;
        }

        private static bool HasServerArgument(IEnumerable<string> args) => args?.Any(a => a.Equals("--server", StringComparison.InvariantCultureIgnoreCase)) ?? false;
    }
}

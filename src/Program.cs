using System;
using System.Collections.Generic;
using System.Linq;
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

            var autoRestConnection = new Connection(Console.OpenStandardInput(), Console.OpenStandardOutput(), 
                (connection, pluginName, sessionId) => new Dispatcher(connection, pluginName, sessionId).Process(),
                "csharp-v3");
            //connection.Dispatch<IEnumerable<string>>("GetPluginNames", async () => new[] { "csharp-v3" });
            //connection.Dispatch<string, string, bool>("Process", (pluginName, sessionId) => new Dispatcher(connection, pluginName, sessionId).Process());
            //connection.Dispatch("Shutdown", connection.Stop);
            autoRestConnection.GetAwaiter().GetResult();

            Console.Error.WriteLine("Shutting Down");
            return 0;
        }

        private static bool HasServerArgument(IEnumerable<string> args) => args?.Any(a => a.Equals("--server", StringComparison.InvariantCultureIgnoreCase)) ?? false;
    }
}

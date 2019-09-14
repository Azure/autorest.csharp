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

            using var connection = new Connection(Console.OpenStandardOutput(), Console.OpenStandardInput());
            connection.Dispatch<IEnumerable<string>>("GetPluginNames", async () => new[] { "csharp-v3" });
            connection.Dispatch<string, string, bool>("Process", (plugin, sessionId) => new Dispatcher(connection, plugin, sessionId).Process());
            connection.DispatchNotification("Shutdown", connection.Stop);
            connection.GetAwaiter().GetResult();

            Console.Error.WriteLine("Shutting Down");
            return 0;
        }

        private static bool HasServerArgument(IEnumerable<string> args) => args?.Any(a => a.Equals("--server", StringComparison.InvariantCultureIgnoreCase)) ?? false;
    }
}

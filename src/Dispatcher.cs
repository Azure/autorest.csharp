using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Perks.JsonRPC;

namespace AutoRest.CSharp.V3
{
    internal class Dispatcher : NewPlugin
    {
        public Dispatcher(Connection connection, string plugin, string sessionId) : base(connection, plugin, sessionId) { }

        protected override async Task<bool> ProcessInternal()
        {
            var files = await ListInputs();
            if (!files.Any())
            {
                throw new Exception("Generator did not receive the code model file.");
            }

            var codeModel = await ReadFile(files.First());
            return true;
        }
    }
}

using System;
using System.Linq;
using System.Threading.Tasks;
using AutoRest.CSharp.V3.Common.JsonRpc;
using AutoRest.CSharp.V3.Common.Plugins;
using Microsoft.Perks.JsonRPC;

namespace AutoRest.CSharp.V3
{
    internal class Dispatcher2
    {
        private readonly AutoRestCommands _autoRest;

        public Dispatcher2(Connection connection, string pluginName, string sessionId)
        {
            _autoRest = new AutoRestCommands(connection, pluginName, sessionId);
        }

        public async Task<bool> Process() => await _autoRest.Process(ProcessInternal);

        private async Task<bool> ProcessInternal()
        {
            var testItem = await _autoRest.GetValue<string>("test-item");

            var files = await _autoRest.ListInputs();
            if (!files.Any())
            {
                throw new Exception("Generator did not receive the code model file.");
            }

            var codeModel = await _autoRest.ReadFile(files.FirstOrDefault());

            var inputFiles = await _autoRest.GetValue<string[]>("input-file");
            var inputFileMessage = new Common.JsonRpc.Message { Channel = Channel.Fatal, Text = inputFiles.FirstOrDefault() };
            await _autoRest.Message(inputFileMessage);

            await _autoRest.WriteFile("CodeModel.yaml", codeModel, "source-file-csharp");
            return true;
        }
    }
}

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
            var file = new Message
            {
                Channel = "file",
                Details = new
                {
                    content = codeModel,
                    type = "source-file-csharp",
                    uri = "CodeModel.yaml"
                },
                //Text = codeModel,
                //Key = new[] { "source-file-csharp", "CodeModel.yaml" }
            };
            //Message(new Message {Text = codeModel, Channel = "fatal"});
            Message(file);
            //WriteFile("CodeModel.yaml", codeModel, null);
            //Console.WriteLine("Got here");
            return true;
        }
    }
}

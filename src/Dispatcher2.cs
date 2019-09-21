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

        public Dispatcher2(Connection connection, string sessionId)
        {
            _autoRest = new AutoRestCommands(connection, sessionId);
        }

        //protected override async Task<bool> ProcessInternal()
        //{
        //    var files = await ListInputs();
        //    if (!files.Any())
        //    {
        //        throw new Exception("Generator did not receive the code model file.");
        //    }

        //    var codeModel = await ReadFile(files.First());
        //    var file = new Message
        //    {
        //        Channel = "file",
        //        Details = new
        //        {
        //            content = codeModel,
        //            type = "source-file-csharp",
        //            uri = "CodeModel.yaml"
        //        }
        //        //Text = codeModel,
        //        //Key = new[] { "source-file-csharp", "CodeModel.yaml" }
        //    };
        //    //Message(new Message {Text = codeModel, Channel = "fatal"});
        //    Message(new Message { Text = (await GetValue<string[]>("input-file")).FirstOrDefault(), Channel = "fatal" });
        //    Message(file);
        //    //WriteFile("CodeModel.yaml", codeModel, null);
        //    //Console.WriteLine("Got here");
        //    return true;
        //}

        //protected override async Task<bool> ProcessInternal()
        //{
        //    var requestId = Connection.NewRequestId.ToString();
        //    var files = await Connection.Request2<string[]>(AutoRestRequests.ListInputs(requestId, SessionId));
        //    if (!files.Any())
        //    {
        //        throw new Exception("Generator did not receive the code model file.");
        //    }

        //    requestId = Connection.NewRequestId.ToString();
        //    var codeModel = await Connection.Request2<string>(AutoRestRequests.ReadFile(requestId, SessionId, files.First()));

        //    requestId = Connection.NewRequestId.ToString();
        //    var inputFile = (await Connection.Request2<string[]>(AutoRestRequests.GetValue(requestId, SessionId, "input-file"))).FirstOrDefault();

        //    var inputFileMessage = new Common.JsonRpc.Message { Channel = Channel.Fatal, Text = inputFile };
        //    await Connection.Send(AutoRestRequests.Message(SessionId, inputFileMessage));

        //    var file = AutoRestRequests.WriteFile(SessionId, "CodeModel.yaml", codeModel, "source-file-csharp");
        //    await Connection.Send(file);

        //    return true;
        //}

        public async Task<bool> Process() => await _autoRest.Process(ProcessInternal);

        private async Task<bool> ProcessInternal()
        {
            var testItem = await _autoRest.GetValue<string>("test-item");

            // array
            var files = await _autoRest.ListInputs();
            //if (!files.Any())
            //{
            //    throw new Exception("Generator did not receive the code model file.");
            //}

            var codeModel = await _autoRest.ReadFile(files.FirstOrDefault());

            //requestId = Connection.NewRequestId.ToString();
            //// array
            //var inputFile = (await Connection.Request3(AutoRestRequests.GetValue(requestId, SessionId, "input-file")));
            var inputFiles = await _autoRest.GetValue<string[]>("input-file");
            var inputFileMessage = new Common.JsonRpc.Message { Channel = Channel.Fatal, Text = inputFiles.FirstOrDefault() };
            await _autoRest.Message(inputFileMessage);

            await _autoRest.WriteFile("CodeModel.yaml", codeModel, "source-file-csharp");

            return true;
        }
    }
}

using System;
using System.Linq;
using System.Threading.Tasks;
using AutoRest.CSharp.V3.Common.JsonRpc;
using Microsoft.Perks.JsonRPC;

namespace AutoRest.CSharp.V3
{
    internal class Dispatcher : NewPlugin
    {
        public Connection Connection { get; }
        public string SessionId { get; }
        public Dispatcher(Connection connection, string plugin, string sessionId) : base(connection, plugin, sessionId)
        {
            Connection = connection;
            SessionId = sessionId;
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

        protected override async Task<bool> ProcessInternal()
        {
            var requestId = Connection.NewRequestId.ToString();
            var files = await Connection.Request2<string[]>(AutoRestRequests.ListInputs(requestId, SessionId));
            if (!files.Any())
            {
                throw new Exception("Generator did not receive the code model file.");
            }

            requestId = Connection.NewRequestId.ToString();
            var codeModel = await Connection.Request2<string>(AutoRestRequests.ReadFile(requestId, SessionId, files.First()));

            //Message(new Message { Text = (await GetValue<string[]>("input-file")).FirstOrDefault(), Channel = "fatal" });

            requestId = Connection.NewRequestId.ToString();
            var inputFile = (await Connection.Request2<string[]>(AutoRestRequests.GetValue(requestId, SessionId, "input-file"))).FirstOrDefault();

            var inputFileMessage = new Common.JsonRpc.Message { Channel = Channel.Fatal, Text = inputFile };
            //requestId = Connection.NewRequestId.ToString();
            await Connection.Send(AutoRestRequests.Message(SessionId, inputFileMessage));

            //var file = new Message
            //{
            //    Channel = "file",
            //    Details = new
            //    {
            //        content = codeModel,
            //        type = "source-file-csharp",
            //        uri = "CodeModel.yaml"
            //    }
            //    //Text = codeModel,
            //    //Key = new[] { "source-file-csharp", "CodeModel.yaml" }
            //};
            //Message(file);
            //requestId = Connection.NewRequestId.ToString();
            var file = AutoRestRequests.WriteFile(SessionId, "CodeModel.yaml", codeModel, "source-file-csharp");
            await Connection.Send(file);

            return true;
        }
    }
}

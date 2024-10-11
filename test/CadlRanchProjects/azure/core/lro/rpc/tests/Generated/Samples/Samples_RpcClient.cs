// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Text.Json;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Identity;
using NUnit.Framework;
using _Specs_.Azure.Core.Lro.Rpc.Models;

namespace _Specs_.Azure.Core.Lro.Rpc.Samples
{
    public partial class Samples_RpcClient
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Rpc_LongRunningRpc_ShortVersion()
        {
            RpcClient client = new RpcClient();

            using RequestContent content = RequestContent.Create(new
            {
                prompt = "<prompt>",
            });
            Operation<BinaryData> operation = client.LongRunningRpc(WaitUntil.Completed, content);
            BinaryData responseData = operation.Value;

            JsonElement result = JsonDocument.Parse(responseData.ToStream()).RootElement;
            Console.WriteLine(result.GetProperty("data").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Rpc_LongRunningRpc_ShortVersion_Async()
        {
            RpcClient client = new RpcClient();

            using RequestContent content = RequestContent.Create(new
            {
                prompt = "<prompt>",
            });
            Operation<BinaryData> operation = await client.LongRunningRpcAsync(WaitUntil.Completed, content);
            BinaryData responseData = operation.Value;

            JsonElement result = JsonDocument.Parse(responseData.ToStream()).RootElement;
            Console.WriteLine(result.GetProperty("data").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Rpc_LongRunningRpc_ShortVersion_Convenience()
        {
            RpcClient client = new RpcClient();

            GenerationOptions body = new GenerationOptions("<prompt>");
            Operation<GenerationResult> operation = client.LongRunningRpc(WaitUntil.Completed, body);
            GenerationResult responseData = operation.Value;
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Rpc_LongRunningRpc_ShortVersion_Convenience_Async()
        {
            RpcClient client = new RpcClient();

            GenerationOptions body = new GenerationOptions("<prompt>");
            Operation<GenerationResult> operation = await client.LongRunningRpcAsync(WaitUntil.Completed, body);
            GenerationResult responseData = operation.Value;
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Rpc_LongRunningRpc_AllParameters()
        {
            RpcClient client = new RpcClient();

            using RequestContent content = RequestContent.Create(new
            {
                prompt = "<prompt>",
            });
            Operation<BinaryData> operation = client.LongRunningRpc(WaitUntil.Completed, content);
            BinaryData responseData = operation.Value;

            JsonElement result = JsonDocument.Parse(responseData.ToStream()).RootElement;
            Console.WriteLine(result.GetProperty("data").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Rpc_LongRunningRpc_AllParameters_Async()
        {
            RpcClient client = new RpcClient();

            using RequestContent content = RequestContent.Create(new
            {
                prompt = "<prompt>",
            });
            Operation<BinaryData> operation = await client.LongRunningRpcAsync(WaitUntil.Completed, content);
            BinaryData responseData = operation.Value;

            JsonElement result = JsonDocument.Parse(responseData.ToStream()).RootElement;
            Console.WriteLine(result.GetProperty("data").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Rpc_LongRunningRpc_AllParameters_Convenience()
        {
            RpcClient client = new RpcClient();

            GenerationOptions body = new GenerationOptions("<prompt>");
            Operation<GenerationResult> operation = client.LongRunningRpc(WaitUntil.Completed, body);
            GenerationResult responseData = operation.Value;
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Rpc_LongRunningRpc_AllParameters_Convenience_Async()
        {
            RpcClient client = new RpcClient();

            GenerationOptions body = new GenerationOptions("<prompt>");
            Operation<GenerationResult> operation = await client.LongRunningRpcAsync(WaitUntil.Completed, body);
            GenerationResult responseData = operation.Value;
        }
    }
}

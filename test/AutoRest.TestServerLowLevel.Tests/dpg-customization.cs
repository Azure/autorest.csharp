using System;
using System.Linq;
using System.Threading.Tasks;
using AutoRest.TestServer.Tests.Infrastructure;
using Azure;
using Azure.Core;
using Azure.Core.Tests;
using dpg_customization_LowLevel;
using dpg_customization_LowLevel.Models;
using NUnit.Framework;

namespace AutoRest.TestServer.Tests
{
    public class DpgCustomizationTest : TestServerLowLevelTestBase
    {
        [Test]
        public Task GetRawModel() => Test(async (host) =>
        {
            Response result = await new DPGClient(Key, host, null).GetModelAsync("raw");
            JsonData responseBody = JsonData.FromBytes(result.Content.ToMemory());
            Assert.AreEqual("raw", (string)responseBody["received"]);
        });

        [Test]
        public Task GetHandwrittenModel() => Test(async (host) =>
        {
            using var diagnosticListener = new ClientDiagnosticListener("dpg_customization_LowLevel", asyncLocal: true);
            var scopes = diagnosticListener.Scopes;
            CollectionAssert.IsEmpty(diagnosticListener.Scopes);

            Response<Product> result = await new DPGClient(Key, host, null).GetModelValueAsync("model");
            Assert.AreEqual(1, scopes.Count);
            Assert.AreEqual("DPGClient.GetModelValue", scopes[0].Name);
            Assert.True(scopes[0].IsCompleted);
            Assert.AreEqual("model", $"{result.Value.Received}");
        });

        [Test]
        public Task PostRawModel() => Test(async (host) =>
        {
            var value = new
            {
                hello = "world!"
            };
            Response result = await new DPGClient(Key, host, null).PostModelAsync("raw", RequestContent.Create(value));
            Assert.AreEqual(200, result.Status);
            JsonData responseBody = JsonData.FromBytes(result.Content.ToMemory());
            Assert.AreEqual("raw", (string)responseBody["received"]);
        });

        [Test]
        public Task PostHandwrittenModel() => Test(async (host) =>
        {
            using var diagnosticListener = new ClientDiagnosticListener("dpg_customization_LowLevel", asyncLocal: true);
            var scopes = diagnosticListener.Scopes;
            CollectionAssert.IsEmpty(diagnosticListener.Scopes);

            Input input = new Input("world!");
            Response<Product> result = await new DPGClient(Key, host, null).PostModelAsync("model", input);
            Assert.True(scopes.Count == 1);
            Assert.AreEqual(scopes[0].Name, "DPGClient.PostModel");
            Assert.True(scopes[0].IsCompleted);
            Assert.AreEqual("model", $"{result.Value.Received}");
        });

        [Test]
        public Task GetRawPages() => Test(async (host) =>
        {
            AsyncPageable<BinaryData> allPages = new DPGClient(Key, host, null).GetPagesAsync("raw");
            await foreach (Page<BinaryData> page in allPages.AsPages())
            {
                var firstItem = JsonData.FromBytes(page.Values.First());
                Assert.AreEqual("raw", (string)firstItem["received"]);
            }
        });

        [Test]
        public Task GetHandwrittenModelPages() => Test(async (host) =>
        {
            using var diagnosticListener = new ClientDiagnosticListener("dpg_customization_LowLevel", asyncLocal: true);
            CollectionAssert.IsEmpty(diagnosticListener.Scopes);

            AsyncPageable<Product> allPages = new DPGClient(Key, host, null).GetPageValuesAsync("model");
            var pagesCount = 0;
            await foreach (Page<Product> page in allPages.AsPages())
            {
                pagesCount++;
                Assert.AreEqual("model", $"{page.Values.First().Received}");
            }

            // +1 due to the last iteration of enumeration that doesn't make a call
            Assert.AreEqual(pagesCount + 1, diagnosticListener.Scopes.Count);
        });

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public Task RawLRO(bool suppressNestedSpans) => Test(async (host) =>
        {
            using var diagnosticListener = new ClientDiagnosticListener("dpg_customization_LowLevel", asyncLocal: true);
            CollectionAssert.IsEmpty(diagnosticListener.Scopes);

            Operation<BinaryData> result = await new DPGClient(Key, host, null, suppressNestedSpans).LroAsync(WaitUntil.Started, "raw");
            diagnosticListener.AssertAndRemoveScope("DPGClient.Lro");
            CollectionAssert.IsEmpty(diagnosticListener.Scopes);

            await result.WaitForCompletionAsync();
            diagnosticListener.AssertAndRemoveScope("DPGClient.Lro.WaitForCompletion");
            if (suppressNestedSpans)
            {
                CollectionAssert.IsEmpty(diagnosticListener.Scopes);
            }
            else
            {
                CollectionAssert.IsNotEmpty(diagnosticListener.Scopes);
            }

            JsonData responseBody = JsonData.FromBytes(result.Value.ToMemory());
            Assert.AreEqual("raw", (string)responseBody["received"]);
        });

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public Task RawLROResponseOperationOfT(bool suppressNestedSpans) => Test(async (host) =>
        {
            using var diagnosticListener = new ClientDiagnosticListener("dpg_customization_LowLevel", asyncLocal: true);
            CollectionAssert.IsEmpty(diagnosticListener.Scopes);

            Operation<BinaryData> result = await new DPGClient(Key, host, null, suppressNestedSpans).LroAsync(WaitUntil.Started, "raw");
            diagnosticListener.AssertAndRemoveScope("DPGClient.Lro");
            CollectionAssert.IsEmpty(diagnosticListener.Scopes);

            await result.WaitForCompletionResponseAsync();
            diagnosticListener.AssertAndRemoveScope("DPGClient.Lro.WaitForCompletion");
            if (suppressNestedSpans)
            {
                CollectionAssert.IsEmpty(diagnosticListener.Scopes);
            }
            else
            {
                CollectionAssert.IsNotEmpty(diagnosticListener.Scopes);
            }

            JsonData responseBody = JsonData.FromBytes(result.Value.ToMemory());
            Assert.AreEqual("raw", (string)responseBody["received"]);
        }, ignoreScenario: true);

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public Task RawLROResponseOperation(bool suppressNestedSpans) => Test(async (host) =>
        {
            using var diagnosticListener = new ClientDiagnosticListener("dpg_customization_LowLevel", asyncLocal: true);
            CollectionAssert.IsEmpty(diagnosticListener.Scopes);

            Operation result = await new DPGClient(Key, host, null, suppressNestedSpans).LroAsync(WaitUntil.Started, "raw");
            diagnosticListener.AssertAndRemoveScope("DPGClient.Lro");
            CollectionAssert.IsEmpty(diagnosticListener.Scopes);

            await result.WaitForCompletionResponseAsync();
            diagnosticListener.AssertAndRemoveScope("DPGClient.Lro.WaitForCompletion");
            if (suppressNestedSpans)
            {
                CollectionAssert.IsEmpty(diagnosticListener.Scopes);
            }
            else
            {
                CollectionAssert.IsNotEmpty(diagnosticListener.Scopes);
            }

            JsonData responseBody = JsonData.FromBytes(result.GetRawResponse().Content.ToMemory());
            Assert.AreEqual("raw", (string)responseBody["received"]);
        }, ignoreScenario: true);

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public Task RawLROManualIterationOperationOfT(bool suppressNestedSpans) => Test(async (host) =>
        {
            using var diagnosticListener = new ClientDiagnosticListener("dpg_customization_LowLevel", asyncLocal: true);
            CollectionAssert.IsEmpty(diagnosticListener.Scopes);

            Operation<Product> lro = await new DPGClient(Key, host, null, suppressNestedSpans).LroValueAsync(WaitUntil.Started, "raw");
            diagnosticListener.AssertAndRemoveScope("DPGClient.LroValue");

            if (!suppressNestedSpans)
            {
                diagnosticListener.AssertAndRemoveScope("DPGClient.Lro");
            }

            CollectionAssert.IsEmpty(diagnosticListener.Scopes);

            while (!lro.HasCompleted)
            {
                await lro.UpdateStatusAsync();
                diagnosticListener.AssertAndRemoveScope("DPGClient.LroValue.UpdateStatus");
                if (suppressNestedSpans)
                {
                    CollectionAssert.IsEmpty(diagnosticListener.Scopes);
                }
                else
                {
                    CollectionAssert.IsNotEmpty(diagnosticListener.Scopes);
                }
            }
        }, ignoreScenario: true);

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public Task RawLROManualIterationOperation(bool suppressNestedSpans) => Test(async (host) =>
        {
            using var diagnosticListener = new ClientDiagnosticListener("dpg_customization_LowLevel", asyncLocal: true);
            CollectionAssert.IsEmpty(diagnosticListener.Scopes);

            Operation lro = await new DPGClient(Key, host, null, suppressNestedSpans).LroValueAsync(WaitUntil.Started, "raw");
            diagnosticListener.AssertAndRemoveScope("DPGClient.LroValue");

            if (!suppressNestedSpans)
            {
                diagnosticListener.AssertAndRemoveScope("DPGClient.Lro");
            }

            CollectionAssert.IsEmpty(diagnosticListener.Scopes);

            while (!lro.HasCompleted)
            {
                await lro.UpdateStatusAsync();
                diagnosticListener.AssertAndRemoveScope("DPGClient.LroValue.UpdateStatus");
                if (suppressNestedSpans)
                {
                    CollectionAssert.IsEmpty(diagnosticListener.Scopes);
                }
                else
                {
                    CollectionAssert.IsNotEmpty(diagnosticListener.Scopes);
                }
            }
        }, ignoreScenario: true);

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public Task RawLROWaitUntilCompletedOperationOfT(bool suppressNestedSpans) => Test(async (host) =>
        {
            using var diagnosticListener = new ClientDiagnosticListener("dpg_customization_LowLevel", asyncLocal: true);
            CollectionAssert.IsEmpty(diagnosticListener.Scopes);

            Operation<Product> result = await new DPGClient(Key, host, null, suppressNestedSpans).LroValueAsync(WaitUntil.Completed, "raw");
            diagnosticListener.AssertAndRemoveScope("DPGClient.LroValue");

            if (suppressNestedSpans)
            {
                CollectionAssert.IsEmpty(diagnosticListener.Scopes);
            }
            else
            {
                CollectionAssert.IsNotEmpty(diagnosticListener.Scopes);
            }

            Assert.AreEqual("raw", result.Value.Received.ToString());
        }, ignoreScenario: true);

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public Task RawLROWaitUntilCompletedOperation(bool suppressNestedSpans) => Test(async (host) =>
        {
            using var diagnosticListener = new ClientDiagnosticListener("dpg_customization_LowLevel", asyncLocal: true);
            CollectionAssert.IsEmpty(diagnosticListener.Scopes);

            Operation result = await new DPGClient(Key, host, null, suppressNestedSpans).LroValueAsync(WaitUntil.Completed, "raw");
            diagnosticListener.AssertAndRemoveScope("DPGClient.LroValue");

            if (suppressNestedSpans)
            {
                CollectionAssert.IsEmpty(diagnosticListener.Scopes);
            }
            else
            {
                CollectionAssert.IsNotEmpty(diagnosticListener.Scopes);
            }

            JsonData responseBody = JsonData.FromBytes(result.GetRawResponse().Content.ToMemory());
            Assert.AreEqual("raw", (string)responseBody["received"]);
        }, ignoreScenario: true);

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public Task HandwrittenModelLro(bool suppressNestedSpans) => Test(async (host) =>
        {
            using var diagnosticListener = new ClientDiagnosticListener("dpg_customization_LowLevel", asyncLocal: true);
            CollectionAssert.IsEmpty(diagnosticListener.Scopes);

            Operation<Product> lro = await new DPGClient(Key, host, null, suppressNestedSpans).LroValueAsync(WaitUntil.Started, "model");
            diagnosticListener.AssertAndRemoveScope("DPGClient.LroValue");
            if (!suppressNestedSpans)
            {
                diagnosticListener.AssertAndRemoveScope("DPGClient.Lro");
            }
            CollectionAssert.IsEmpty(diagnosticListener.Scopes);

            await lro.WaitForCompletionAsync();
            diagnosticListener.AssertAndRemoveScope("DPGClient.LroValue.WaitForCompletion");
            if (suppressNestedSpans)
            {
                CollectionAssert.IsEmpty(diagnosticListener.Scopes);
            }
            else
            {
                CollectionAssert.IsNotEmpty(diagnosticListener.Scopes);
            }
            Assert.AreEqual("model", $"{lro.Value.Received}");
        });

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public Task HandwrittenModelLroResponseOperationOfT(bool suppressNestedSpans) => Test(async (host) =>
        {
            using var diagnosticListener = new ClientDiagnosticListener("dpg_customization_LowLevel", asyncLocal: true);
            CollectionAssert.IsEmpty(diagnosticListener.Scopes);

            Operation<Product> lro = await new DPGClient(Key, host, null, suppressNestedSpans).LroValueAsync(WaitUntil.Started, "model");
            diagnosticListener.AssertAndRemoveScope("DPGClient.LroValue");
            if (!suppressNestedSpans)
            {
                diagnosticListener.AssertAndRemoveScope("DPGClient.Lro");
            }
            CollectionAssert.IsEmpty(diagnosticListener.Scopes);

            await lro.WaitForCompletionResponseAsync();
            diagnosticListener.AssertAndRemoveScope("DPGClient.LroValue.WaitForCompletion");
            if (suppressNestedSpans)
            {
                CollectionAssert.IsEmpty(diagnosticListener.Scopes);
            }
            else
            {
                CollectionAssert.IsNotEmpty(diagnosticListener.Scopes);
            }
            Assert.AreEqual("model", $"{lro.Value.Received}");
        }, ignoreScenario: true);

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public Task HandwrittenModelLroResponseOperation(bool suppressNestedSpans) => Test(async (host) =>
        {
            using var diagnosticListener = new ClientDiagnosticListener("dpg_customization_LowLevel", asyncLocal: true);
            CollectionAssert.IsEmpty(diagnosticListener.Scopes);

            Operation lro = await new DPGClient(Key, host, null, suppressNestedSpans).LroValueAsync(WaitUntil.Started, "model");
            diagnosticListener.AssertAndRemoveScope("DPGClient.LroValue");
            if (!suppressNestedSpans)
            {
                diagnosticListener.AssertAndRemoveScope("DPGClient.Lro");
            }
            CollectionAssert.IsEmpty(diagnosticListener.Scopes);

            await lro.WaitForCompletionResponseAsync();
            diagnosticListener.AssertAndRemoveScope("DPGClient.LroValue.WaitForCompletion");
            if (suppressNestedSpans)
            {
                CollectionAssert.IsEmpty(diagnosticListener.Scopes);
            }
            else
            {
                CollectionAssert.IsNotEmpty(diagnosticListener.Scopes);
            }

            JsonData responseBody = JsonData.FromBytes(lro.GetRawResponse().Content.ToMemory());
            Assert.AreEqual("model", (string)responseBody["received"]);
        }, ignoreScenario: true);

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public Task HandwrittenModelLroManualIterationOperationOfT(bool suppressNestedSpans) => Test(async (host) =>
        {
            using var diagnosticListener = new ClientDiagnosticListener("dpg_customization_LowLevel", asyncLocal: true);
            CollectionAssert.IsEmpty(diagnosticListener.Scopes);

            Operation<Product> lro = await new DPGClient(Key, host, null, suppressNestedSpans).LroValueAsync(WaitUntil.Started, "model");
            diagnosticListener.AssertAndRemoveScope("DPGClient.LroValue");
            if (!suppressNestedSpans)
            {
                diagnosticListener.AssertAndRemoveScope("DPGClient.Lro");
            }
            CollectionAssert.IsEmpty(diagnosticListener.Scopes);

            while (!lro.HasCompleted)
            {
                await lro.UpdateStatusAsync();
                diagnosticListener.AssertAndRemoveScope("DPGClient.LroValue.UpdateStatus");
                if (suppressNestedSpans)
                {
                    CollectionAssert.IsEmpty(diagnosticListener.Scopes);
                }
                else
                {
                    CollectionAssert.IsNotEmpty(diagnosticListener.Scopes);
                }
            }
        }, ignoreScenario: true);

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public Task HandwrittenModelLroManualIterationOperation(bool suppressNestedSpans) => Test(async (host) =>
        {
            using var diagnosticListener = new ClientDiagnosticListener("dpg_customization_LowLevel", asyncLocal: true);
            CollectionAssert.IsEmpty(diagnosticListener.Scopes);

            Operation lro = await new DPGClient(Key, host, null, suppressNestedSpans).LroValueAsync(WaitUntil.Started, "model");
            diagnosticListener.AssertAndRemoveScope("DPGClient.LroValue");
            if (!suppressNestedSpans)
            {
                diagnosticListener.AssertAndRemoveScope("DPGClient.Lro");
            }
            CollectionAssert.IsEmpty(diagnosticListener.Scopes);

            while (!lro.HasCompleted)
            {
                await lro.UpdateStatusAsync();
                diagnosticListener.AssertAndRemoveScope("DPGClient.LroValue.UpdateStatus");
                if (suppressNestedSpans)
                {
                    CollectionAssert.IsEmpty(diagnosticListener.Scopes);
                }
                else
                {
                    CollectionAssert.IsNotEmpty(diagnosticListener.Scopes);
                }
            }
        }, ignoreScenario: true);

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public Task HandwrittenModelLroWaitUntilCompletedOperationOfT(bool suppressNestedSpans) => Test(async (host) =>
        {
            using var diagnosticListener = new ClientDiagnosticListener("dpg_customization_LowLevel", asyncLocal: true);
            CollectionAssert.IsEmpty(diagnosticListener.Scopes);

            Operation<Product> lro = await new DPGClient(Key, host, null, suppressNestedSpans).LroValueAsync(WaitUntil.Completed, "model");
            diagnosticListener.AssertAndRemoveScope("DPGClient.LroValue");
            if (!suppressNestedSpans)
            {
                diagnosticListener.AssertAndRemoveScope("DPGClient.Lro");
            }
            else
            {
                CollectionAssert.IsEmpty(diagnosticListener.Scopes);
            }
            Assert.AreEqual("model", $"{lro.Value.Received}");
        }, ignoreScenario: true);

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public Task HandwrittenModelLroWaitUntilCompletedOperation(bool suppressNestedSpans) => Test(async (host) =>
        {
            using var diagnosticListener = new ClientDiagnosticListener("dpg_customization_LowLevel", asyncLocal: true);
            CollectionAssert.IsEmpty(diagnosticListener.Scopes);

            Operation lro = await new DPGClient(Key, host, null, suppressNestedSpans).LroValueAsync(WaitUntil.Completed, "model");
            diagnosticListener.AssertAndRemoveScope("DPGClient.LroValue");
            if (!suppressNestedSpans)
            {
                diagnosticListener.AssertAndRemoveScope("DPGClient.Lro");
            }
            else
            {
                CollectionAssert.IsEmpty(diagnosticListener.Scopes);
            }
            JsonData responseBody = JsonData.FromBytes(lro.GetRawResponse().Content.ToMemory());
            Assert.AreEqual("model", (string)responseBody["received"]);
        }, ignoreScenario: true);

        [Test]
        public Task DPGGlassBreaker() => Test(async (host) =>
        {
            var pipeline = new DPGClient(Key, host, null).Pipeline;
            HttpMessage message = pipeline.CreateMessage();
            Request request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(host);
            uri.AppendPath("/servicedriven/glassbreaker", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            Response result = await pipeline.ProcessMessageAsync(message, null).ConfigureAwait(false);

            Assert.AreEqual(200, result.Status);
        });
    }
}

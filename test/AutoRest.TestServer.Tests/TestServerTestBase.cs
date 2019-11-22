// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.Pipeline;

namespace AutoRest.TestServer.Tests
{
    public class TestServerTestBase
    {
        public ClientDiagnostics ClientDiagnostics = new ClientDiagnostics(new TestOptions());
        public HttpPipeline Pipeline = HttpPipelineBuilder.Build(new TestOptions());
    }
}

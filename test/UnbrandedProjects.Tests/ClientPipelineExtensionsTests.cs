// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel;
using System.ClientModel.Primitives;
using System.Threading.Tasks;
using NUnit.Framework;
using UnbrandedTypeSpec;

namespace UnbrandedProjects.Tests
{
    public class ClientPipelineExtensionsTests
    {
        [Test]
        public async Task ValidateClientPipelineExtensions_NoError_NoOptions_Async()
        {
            ClientPipelineOptions pipelineOptions = new()
            {
                Transport = new MockTransport(false)
            };

            ClientPipeline pipeline = ClientPipeline.Create(pipelineOptions);

            PipelineMessage message = pipeline.CreateMessage();
            var response = await pipeline.ProcessMessageAsync(message, null);

            Assert.IsNotNull(response);
            Assert.IsFalse(response.IsError);
        }

        [Test]
        public async Task ValidateClientPipelineExtensions_NoError_DefaultOptions_Async()
        {
            ClientPipelineOptions pipelineOptions = new()
            {
                Transport = new MockTransport(false)
            };

            ClientPipeline pipeline = ClientPipeline.Create(pipelineOptions);

            PipelineMessage message = pipeline.CreateMessage();
            var options = new RequestOptions
            {
                ErrorOptions = ClientErrorBehaviors.Default
            };
            var response = await pipeline.ProcessMessageAsync(message, options);

            Assert.IsNotNull(response);
            Assert.IsFalse(response.IsError);
        }

        [Test]
        public async Task ValidateClientPipelineExtensions_NoError_NoThrowOptions_Async()
        {
            ClientPipelineOptions pipelineOptions = new()
            {
                Transport = new MockTransport(false)
            };

            ClientPipeline pipeline = ClientPipeline.Create(pipelineOptions);

            PipelineMessage message = pipeline.CreateMessage();
            var options = new RequestOptions
            {
                ErrorOptions = ClientErrorBehaviors.NoThrow
            };
            var response = await pipeline.ProcessMessageAsync(message, options);

            Assert.IsNotNull(response);
            Assert.IsFalse(response.IsError);
        }

        [Test]
        public void ValidateClientPipelineExtensions_NoError_NoOptions()
        {
            ClientPipelineOptions pipelineOptions = new()
            {
                Transport = new MockTransport(false)
            };

            ClientPipeline pipeline = ClientPipeline.Create(pipelineOptions);

            PipelineMessage message = pipeline.CreateMessage();
            var response = pipeline.ProcessMessage(message, null);

            Assert.IsNotNull(response);
            Assert.IsFalse(response.IsError);
        }

        [Test]
        public void ValidateClientPipelineExtensions_NoError_DefaultOptions()
        {
            ClientPipelineOptions pipelineOptions = new()
            {
                Transport = new MockTransport(false)
            };

            ClientPipeline pipeline = ClientPipeline.Create(pipelineOptions);

            PipelineMessage message = pipeline.CreateMessage();
            var options = new RequestOptions
            {
                ErrorOptions = ClientErrorBehaviors.Default
            };
            var response = pipeline.ProcessMessage(message, options);

            Assert.IsNotNull(response);
            Assert.IsFalse(response.IsError);
        }

        [Test]
        public void ValidateClientPipelineExtensions_NoError_NoThrowOptions()
        {
            ClientPipelineOptions pipelineOptions = new()
            {
                Transport = new MockTransport(false)
            };

            ClientPipeline pipeline = ClientPipeline.Create(pipelineOptions);

            PipelineMessage message = pipeline.CreateMessage();
            var options = new RequestOptions
            {
                ErrorOptions = ClientErrorBehaviors.NoThrow
            };
            var response = pipeline.ProcessMessage(message, options);

            Assert.IsNotNull(response);
            Assert.IsFalse(response.IsError);
        }

        [Test]
        public void ValidateClientPipelineExtensions_Error_NoOptions_Async()
        {
            ClientPipelineOptions pipelineOptions = new()
            {
                Transport = new MockTransport(true)
            };

            ClientPipeline pipeline = ClientPipeline.Create(pipelineOptions);

            PipelineMessage message = pipeline.CreateMessage();
            // this should throw ClientResultException
            Assert.ThrowsAsync<ClientResultException>(async () => await pipeline.ProcessMessageAsync(message, null));
        }

        [Test]
        public void ValidateClientPipelineExtensions_Error_DefaultOptions_Async()
        {
            ClientPipelineOptions pipelineOptions = new()
            {
                Transport = new MockTransport(true)
            };

            ClientPipeline pipeline = ClientPipeline.Create(pipelineOptions);

            PipelineMessage message = pipeline.CreateMessage();
            var options = new RequestOptions
            {
                ErrorOptions = ClientErrorBehaviors.Default
            };
            // this should throw ClientResultException
            Assert.ThrowsAsync<ClientResultException>(async () => await pipeline.ProcessMessageAsync(message, options));
        }

        [Test]
        public async Task ValidateClientPipelineExtensions_Error_NoThrowOptions_Async()
        {
            ClientPipelineOptions pipelineOptions = new()
            {
                Transport = new MockTransport(true)
            };

            ClientPipeline pipeline = ClientPipeline.Create(pipelineOptions);

            PipelineMessage message = pipeline.CreateMessage();
            var options = new RequestOptions
            {
                ErrorOptions = ClientErrorBehaviors.NoThrow
            };
            // this should not throw
            var response = await pipeline.ProcessMessageAsync(message, options);

            Assert.IsNotNull(response);
            Assert.IsTrue(response.IsError);
        }

        [Test]
        public void ValidateClientPipelineExtensions_Error_NoOptions()
        {
            ClientPipelineOptions pipelineOptions = new()
            {
                Transport = new MockTransport(true)
            };

            ClientPipeline pipeline = ClientPipeline.Create(pipelineOptions);

            PipelineMessage message = pipeline.CreateMessage();
            // this should throw ClientResultException
            Assert.Throws<ClientResultException>(() => pipeline.ProcessMessage(message, null));
        }

        [Test]
        public void ValidateClientPipelineExtensions_Error_DefaultOptions()
        {
            ClientPipelineOptions pipelineOptions = new()
            {
                Transport = new MockTransport(true)
            };

            ClientPipeline pipeline = ClientPipeline.Create(pipelineOptions);

            PipelineMessage message = pipeline.CreateMessage();
            var options = new RequestOptions
            {
                ErrorOptions = ClientErrorBehaviors.Default
            };
            // this should throw ClientResultException
            Assert.Throws<ClientResultException>(() => pipeline.ProcessMessage(message, options));
        }

        [Test]
        public void ValidateClientPipelineExtensions_Error_NoThrowOptions()
        {
            ClientPipelineOptions pipelineOptions = new()
            {
                Transport = new MockTransport(true)
            };

            ClientPipeline pipeline = ClientPipeline.Create(pipelineOptions);

            PipelineMessage message = pipeline.CreateMessage();
            var options = new RequestOptions
            {
                ErrorOptions = ClientErrorBehaviors.NoThrow
            };
            // this should not throw
            var response = pipeline.ProcessMessage(message, options);

            Assert.IsNotNull(response);
            Assert.IsTrue(response.IsError);
        }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace UnbrandedProjects.Tests;

public class MockTransport : PipelineTransport
{
    private readonly bool _isError;

    public MockTransport(bool isError)
    {
        _isError = isError;
    }

    protected override PipelineMessage CreateMessageCore()
    {
        return new TransportMessage();
    }

    protected override void ProcessCore(PipelineMessage message)
    {
        if (message is TransportMessage transportMessage)
        {
            transportMessage.SetResponse(_isError);
        }
    }

    protected override ValueTask ProcessCoreAsync(PipelineMessage message)
    {
        if (message is TransportMessage transportMessage)
        {
            transportMessage.SetResponse(_isError);
        }

        return new ValueTask();
    }

    private class TransportMessage : PipelineMessage
    {
        public TransportMessage() : this(new TransportRequest())
        {
        }

        protected internal TransportMessage(PipelineRequest request) : base(request)
        {
        }

        public void SetResponse(bool isError)
        {
            Response = new TransportResponse(isError);
        }
    }

    private class TransportRequest : PipelineRequest
    {
        public TransportRequest() { }

        public override void Dispose()
        {
            throw new NotImplementedException();
        }

        protected override BinaryContent? ContentCore
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        protected override PipelineRequestHeaders HeadersCore
            => throw new NotImplementedException();

        protected override string MethodCore
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        protected override Uri? UriCore
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }
    }

    private class TransportResponse : PipelineResponse
    {
        private readonly bool _isError;
        public TransportResponse(bool isError)
        {
            _isError = isError;
        }

        public override bool IsError => _isError;

        public override int Status => 0;

        public override string ReasonPhrase => string.Empty;

        public override Stream? ContentStream
        {
            get => null;
            set => throw new NotImplementedException();
        }

        public override BinaryData Content => throw new NotImplementedException();

        protected override PipelineResponseHeaders HeadersCore
            => throw new NotImplementedException();

        public override void Dispose()
        {
            throw new NotImplementedException();
        }

        public override BinaryData BufferContent(CancellationToken cancellationToken = default)
        {
            return BinaryData.FromString("{}");
        }

        public override ValueTask<BinaryData> BufferContentAsync(CancellationToken cancellationToken = default)
        {
            return ValueTask.FromResult(BinaryData.FromString("{}"));
        }
    }
}

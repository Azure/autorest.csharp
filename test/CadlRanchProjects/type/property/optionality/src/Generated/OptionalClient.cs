// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading;
using Azure.Core;
using Azure.Core.Pipeline;

namespace _Type.Property.Optionality
{
    // Data plane generated client.
    /// <summary> Illustrates models with optional properties. </summary>
    public partial class OptionalClient
    {
        private readonly HttpPipeline _pipeline;
        private readonly Uri _endpoint;

        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal ClientDiagnostics ClientDiagnostics { get; }

        /// <summary> The HTTP pipeline for sending and receiving REST requests and responses. </summary>
        public virtual HttpPipeline Pipeline => _pipeline;

        /// <summary> Initializes a new instance of OptionalClient. </summary>
        public OptionalClient() : this(new Uri("http://localhost:3000"), new OptionalClientOptions())
        {
        }

        /// <summary> Initializes a new instance of OptionalClient. </summary>
        /// <param name="endpoint"> Service host. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> is null. </exception>
        public OptionalClient(Uri endpoint, OptionalClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            options ??= new OptionalClientOptions();

            ClientDiagnostics = new ClientDiagnostics(options, true);
            _pipeline = HttpPipelineBuilder.Build(options, Array.Empty<HttpPipelinePolicy>(), Array.Empty<HttpPipelinePolicy>(), new ResponseClassifier());
            _endpoint = endpoint;
        }

        private String _cachedString;
        private Bytes _cachedBytes;
        private Datetime _cachedDatetime;
        private Duration _cachedDuration;
        private CollectionsByte _cachedCollectionsByte;
        private CollectionsModel _cachedCollectionsModel;
        private StringLiteral _cachedStringLiteral;
        private IntLiteral _cachedIntLiteral;
        private FloatLiteral _cachedFloatLiteral;
        private BooleanLiteral _cachedBooleanLiteral;
        private UnionStringLiteral _cachedUnionStringLiteral;
        private UnionIntLiteral _cachedUnionIntLiteral;
        private UnionFloatLiteral _cachedUnionFloatLiteral;
        private RequiredAndOptional _cachedRequiredAndOptional;

        /// <summary> Initializes a new instance of String. </summary>
        public virtual String GetStringClient()
        {
            return Volatile.Read(ref _cachedString) ?? Interlocked.CompareExchange(ref _cachedString, new String(ClientDiagnostics, _pipeline, _endpoint), null) ?? _cachedString;
        }

        /// <summary> Initializes a new instance of Bytes. </summary>
        public virtual Bytes GetBytesClient()
        {
            return Volatile.Read(ref _cachedBytes) ?? Interlocked.CompareExchange(ref _cachedBytes, new Bytes(ClientDiagnostics, _pipeline, _endpoint), null) ?? _cachedBytes;
        }

        /// <summary> Initializes a new instance of Datetime. </summary>
        public virtual Datetime GetDatetimeClient()
        {
            return Volatile.Read(ref _cachedDatetime) ?? Interlocked.CompareExchange(ref _cachedDatetime, new Datetime(ClientDiagnostics, _pipeline, _endpoint), null) ?? _cachedDatetime;
        }

        /// <summary> Initializes a new instance of Duration. </summary>
        public virtual Duration GetDurationClient()
        {
            return Volatile.Read(ref _cachedDuration) ?? Interlocked.CompareExchange(ref _cachedDuration, new Duration(ClientDiagnostics, _pipeline, _endpoint), null) ?? _cachedDuration;
        }

        /// <summary> Initializes a new instance of CollectionsByte. </summary>
        public virtual CollectionsByte GetCollectionsByteClient()
        {
            return Volatile.Read(ref _cachedCollectionsByte) ?? Interlocked.CompareExchange(ref _cachedCollectionsByte, new CollectionsByte(ClientDiagnostics, _pipeline, _endpoint), null) ?? _cachedCollectionsByte;
        }

        /// <summary> Initializes a new instance of CollectionsModel. </summary>
        public virtual CollectionsModel GetCollectionsModelClient()
        {
            return Volatile.Read(ref _cachedCollectionsModel) ?? Interlocked.CompareExchange(ref _cachedCollectionsModel, new CollectionsModel(ClientDiagnostics, _pipeline, _endpoint), null) ?? _cachedCollectionsModel;
        }

        /// <summary> Initializes a new instance of StringLiteral. </summary>
        public virtual StringLiteral GetStringLiteralClient()
        {
            return Volatile.Read(ref _cachedStringLiteral) ?? Interlocked.CompareExchange(ref _cachedStringLiteral, new StringLiteral(ClientDiagnostics, _pipeline, _endpoint), null) ?? _cachedStringLiteral;
        }

        /// <summary> Initializes a new instance of IntLiteral. </summary>
        public virtual IntLiteral GetIntLiteralClient()
        {
            return Volatile.Read(ref _cachedIntLiteral) ?? Interlocked.CompareExchange(ref _cachedIntLiteral, new IntLiteral(ClientDiagnostics, _pipeline, _endpoint), null) ?? _cachedIntLiteral;
        }

        /// <summary> Initializes a new instance of FloatLiteral. </summary>
        public virtual FloatLiteral GetFloatLiteralClient()
        {
            return Volatile.Read(ref _cachedFloatLiteral) ?? Interlocked.CompareExchange(ref _cachedFloatLiteral, new FloatLiteral(ClientDiagnostics, _pipeline, _endpoint), null) ?? _cachedFloatLiteral;
        }

        /// <summary> Initializes a new instance of BooleanLiteral. </summary>
        public virtual BooleanLiteral GetBooleanLiteralClient()
        {
            return Volatile.Read(ref _cachedBooleanLiteral) ?? Interlocked.CompareExchange(ref _cachedBooleanLiteral, new BooleanLiteral(ClientDiagnostics, _pipeline, _endpoint), null) ?? _cachedBooleanLiteral;
        }

        /// <summary> Initializes a new instance of UnionStringLiteral. </summary>
        public virtual UnionStringLiteral GetUnionStringLiteralClient()
        {
            return Volatile.Read(ref _cachedUnionStringLiteral) ?? Interlocked.CompareExchange(ref _cachedUnionStringLiteral, new UnionStringLiteral(ClientDiagnostics, _pipeline, _endpoint), null) ?? _cachedUnionStringLiteral;
        }

        /// <summary> Initializes a new instance of UnionIntLiteral. </summary>
        public virtual UnionIntLiteral GetUnionIntLiteralClient()
        {
            return Volatile.Read(ref _cachedUnionIntLiteral) ?? Interlocked.CompareExchange(ref _cachedUnionIntLiteral, new UnionIntLiteral(ClientDiagnostics, _pipeline, _endpoint), null) ?? _cachedUnionIntLiteral;
        }

        /// <summary> Initializes a new instance of UnionFloatLiteral. </summary>
        public virtual UnionFloatLiteral GetUnionFloatLiteralClient()
        {
            return Volatile.Read(ref _cachedUnionFloatLiteral) ?? Interlocked.CompareExchange(ref _cachedUnionFloatLiteral, new UnionFloatLiteral(ClientDiagnostics, _pipeline, _endpoint), null) ?? _cachedUnionFloatLiteral;
        }

        /// <summary> Initializes a new instance of RequiredAndOptional. </summary>
        public virtual RequiredAndOptional GetRequiredAndOptionalClient()
        {
            return Volatile.Read(ref _cachedRequiredAndOptional) ?? Interlocked.CompareExchange(ref _cachedRequiredAndOptional, new RequiredAndOptional(ClientDiagnostics, _pipeline, _endpoint), null) ?? _cachedRequiredAndOptional;
        }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading;
using Azure.Core;
using Azure.Core.Pipeline;

namespace _Type.Property.AdditionalProperties
{
    // Data plane generated client.
    /// <summary> The AdditionalProperties service client. </summary>
    public partial class AdditionalPropertiesClient
    {
        private readonly HttpPipeline _pipeline;
        private readonly Uri _endpoint;

        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal ClientDiagnostics ClientDiagnostics { get; }

        /// <summary> The HTTP pipeline for sending and receiving REST requests and responses. </summary>
        public virtual HttpPipeline Pipeline => _pipeline;

        /// <summary> Initializes a new instance of AdditionalPropertiesClient. </summary>
        public AdditionalPropertiesClient() : this(new Uri("http://localhost:3000"), new AdditionalPropertiesClientOptions())
        {
        }

        /// <summary> Initializes a new instance of AdditionalPropertiesClient. </summary>
        /// <param name="endpoint"> TestServer endpoint. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> is null. </exception>
        public AdditionalPropertiesClient(Uri endpoint, AdditionalPropertiesClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            options ??= new AdditionalPropertiesClientOptions();

            ClientDiagnostics = new ClientDiagnostics(options, true);
            _pipeline = HttpPipelineBuilder.Build(options, Array.Empty<HttpPipelinePolicy>(), Array.Empty<HttpPipelinePolicy>(), new ResponseClassifier());
            _endpoint = endpoint;
        }

        private ExtendsUnknown _cachedExtendsUnknown;
        private ExtendsUnknownDerived _cachedExtendsUnknownDerived;
        private ExtendsUnknownDiscriminated _cachedExtendsUnknownDiscriminated;
        private IsUnknown _cachedIsUnknown;
        private IsUnknownDerived _cachedIsUnknownDerived;
        private IsUnknownDiscriminated _cachedIsUnknownDiscriminated;
        private ExtendsString _cachedExtendsString;
        private IsString _cachedIsString;
        private ExtendsFloat _cachedExtendsFloat;
        private IsFloat _cachedIsFloat;
        private ExtendsModel _cachedExtendsModel;
        private IsModel _cachedIsModel;
        private ExtendsModelArray _cachedExtendsModelArray;
        private IsModelArray _cachedIsModelArray;

        /// <summary> Initializes a new instance of ExtendsUnknown. </summary>
        public virtual ExtendsUnknown GetExtendsUnknownClient()
        {
            return Volatile.Read(ref _cachedExtendsUnknown) ?? Interlocked.CompareExchange(ref _cachedExtendsUnknown, new ExtendsUnknown(ClientDiagnostics, _pipeline, _endpoint), null) ?? _cachedExtendsUnknown;
        }

        /// <summary> Initializes a new instance of ExtendsUnknownDerived. </summary>
        public virtual ExtendsUnknownDerived GetExtendsUnknownDerivedClient()
        {
            return Volatile.Read(ref _cachedExtendsUnknownDerived) ?? Interlocked.CompareExchange(ref _cachedExtendsUnknownDerived, new ExtendsUnknownDerived(ClientDiagnostics, _pipeline, _endpoint), null) ?? _cachedExtendsUnknownDerived;
        }

        /// <summary> Initializes a new instance of ExtendsUnknownDiscriminated. </summary>
        public virtual ExtendsUnknownDiscriminated GetExtendsUnknownDiscriminatedClient()
        {
            return Volatile.Read(ref _cachedExtendsUnknownDiscriminated) ?? Interlocked.CompareExchange(ref _cachedExtendsUnknownDiscriminated, new ExtendsUnknownDiscriminated(ClientDiagnostics, _pipeline, _endpoint), null) ?? _cachedExtendsUnknownDiscriminated;
        }

        /// <summary> Initializes a new instance of IsUnknown. </summary>
        public virtual IsUnknown GetIsUnknownClient()
        {
            return Volatile.Read(ref _cachedIsUnknown) ?? Interlocked.CompareExchange(ref _cachedIsUnknown, new IsUnknown(ClientDiagnostics, _pipeline, _endpoint), null) ?? _cachedIsUnknown;
        }

        /// <summary> Initializes a new instance of IsUnknownDerived. </summary>
        public virtual IsUnknownDerived GetIsUnknownDerivedClient()
        {
            return Volatile.Read(ref _cachedIsUnknownDerived) ?? Interlocked.CompareExchange(ref _cachedIsUnknownDerived, new IsUnknownDerived(ClientDiagnostics, _pipeline, _endpoint), null) ?? _cachedIsUnknownDerived;
        }

        /// <summary> Initializes a new instance of IsUnknownDiscriminated. </summary>
        public virtual IsUnknownDiscriminated GetIsUnknownDiscriminatedClient()
        {
            return Volatile.Read(ref _cachedIsUnknownDiscriminated) ?? Interlocked.CompareExchange(ref _cachedIsUnknownDiscriminated, new IsUnknownDiscriminated(ClientDiagnostics, _pipeline, _endpoint), null) ?? _cachedIsUnknownDiscriminated;
        }

        /// <summary> Initializes a new instance of ExtendsString. </summary>
        public virtual ExtendsString GetExtendsStringClient()
        {
            return Volatile.Read(ref _cachedExtendsString) ?? Interlocked.CompareExchange(ref _cachedExtendsString, new ExtendsString(ClientDiagnostics, _pipeline, _endpoint), null) ?? _cachedExtendsString;
        }

        /// <summary> Initializes a new instance of IsString. </summary>
        public virtual IsString GetIsStringClient()
        {
            return Volatile.Read(ref _cachedIsString) ?? Interlocked.CompareExchange(ref _cachedIsString, new IsString(ClientDiagnostics, _pipeline, _endpoint), null) ?? _cachedIsString;
        }

        /// <summary> Initializes a new instance of ExtendsFloat. </summary>
        public virtual ExtendsFloat GetExtendsFloatClient()
        {
            return Volatile.Read(ref _cachedExtendsFloat) ?? Interlocked.CompareExchange(ref _cachedExtendsFloat, new ExtendsFloat(ClientDiagnostics, _pipeline, _endpoint), null) ?? _cachedExtendsFloat;
        }

        /// <summary> Initializes a new instance of IsFloat. </summary>
        public virtual IsFloat GetIsFloatClient()
        {
            return Volatile.Read(ref _cachedIsFloat) ?? Interlocked.CompareExchange(ref _cachedIsFloat, new IsFloat(ClientDiagnostics, _pipeline, _endpoint), null) ?? _cachedIsFloat;
        }

        /// <summary> Initializes a new instance of ExtendsModel. </summary>
        public virtual ExtendsModel GetExtendsModelClient()
        {
            return Volatile.Read(ref _cachedExtendsModel) ?? Interlocked.CompareExchange(ref _cachedExtendsModel, new ExtendsModel(ClientDiagnostics, _pipeline, _endpoint), null) ?? _cachedExtendsModel;
        }

        /// <summary> Initializes a new instance of IsModel. </summary>
        public virtual IsModel GetIsModelClient()
        {
            return Volatile.Read(ref _cachedIsModel) ?? Interlocked.CompareExchange(ref _cachedIsModel, new IsModel(ClientDiagnostics, _pipeline, _endpoint), null) ?? _cachedIsModel;
        }

        /// <summary> Initializes a new instance of ExtendsModelArray. </summary>
        public virtual ExtendsModelArray GetExtendsModelArrayClient()
        {
            return Volatile.Read(ref _cachedExtendsModelArray) ?? Interlocked.CompareExchange(ref _cachedExtendsModelArray, new ExtendsModelArray(ClientDiagnostics, _pipeline, _endpoint), null) ?? _cachedExtendsModelArray;
        }

        /// <summary> Initializes a new instance of IsModelArray. </summary>
        public virtual IsModelArray GetIsModelArrayClient()
        {
            return Volatile.Read(ref _cachedIsModelArray) ?? Interlocked.CompareExchange(ref _cachedIsModelArray, new IsModelArray(ClientDiagnostics, _pipeline, _endpoint), null) ?? _cachedIsModelArray;
        }
    }
}

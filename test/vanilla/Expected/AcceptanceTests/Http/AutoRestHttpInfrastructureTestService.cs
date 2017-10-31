// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
// </auto-generated>

namespace Fixtures.AcceptanceTestsHttp
{
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Models;
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Http;

    /// <summary>
    /// Test Infrastructure for AutoRest
    /// </summary>
    public partial class AutoRestHttpInfrastructureTestService : ServiceClient<AutoRestHttpInfrastructureTestService>, IAutoRestHttpInfrastructureTestService
    {
        /// <summary>
        /// Gets or sets the base URI of the service.
        /// </summary>
        public System.Uri BaseUri { get; set; }

        /// <summary>
        /// Gets or sets JSON serialization settings.
        /// </summary>
        public JsonSerializerSettings SerializationSettings { get; private set; }

        /// <summary>
        /// Gets or sets JSON deserialization settings.
        /// </summary>
        public JsonSerializerSettings DeserializationSettings { get; private set; }

        /// <summary>
        /// Gets the IHttpFailure.
        /// </summary>
        public virtual IHttpFailure HttpFailure { get; private set; }

        /// <summary>
        /// Gets the IHttpSuccess.
        /// </summary>
        public virtual IHttpSuccess HttpSuccess { get; private set; }

        /// <summary>
        /// Gets the IHttpRedirects.
        /// </summary>
        public virtual IHttpRedirects HttpRedirects { get; private set; }

        /// <summary>
        /// Gets the IHttpClientFailure.
        /// </summary>
        public virtual IHttpClientFailure HttpClientFailure { get; private set; }

        /// <summary>
        /// Gets the IHttpServerFailure.
        /// </summary>
        public virtual IHttpServerFailure HttpServerFailure { get; private set; }

        /// <summary>
        /// Gets the IHttpRetry.
        /// </summary>
        public virtual IHttpRetry HttpRetry { get; private set; }

        /// <summary>
        /// Gets the IMultipleResponses.
        /// </summary>
        public virtual IMultipleResponses MultipleResponses { get; private set; }

        /// <summary>
        /// Initializes a new instance of the AutoRestHttpInfrastructureTestService class.
        /// </summary>
        /// <param name='handlers'>
        /// Optional. The delegating handlers to add to the http client pipeline.
        /// </param>
        public AutoRestHttpInfrastructureTestService(params DelegatingHandler[] handlers) : base(handlers)
        {
            Initialize();
        }

        /// <summary>
        /// Initializes a new instance of the AutoRestHttpInfrastructureTestService class.
        /// </summary>
        /// <param name='rootHandler'>
        /// Optional. The http client handler used to handle http transport.
        /// </param>
        /// <param name='handlers'>
        /// Optional. The delegating handlers to add to the http client pipeline.
        /// </param>
        public AutoRestHttpInfrastructureTestService(HttpClientHandler rootHandler, params DelegatingHandler[] handlers) : base(rootHandler, handlers)
        {
            Initialize();
        }

        /// <summary>
        /// Initializes a new instance of the AutoRestHttpInfrastructureTestService class.
        /// </summary>
        /// <param name='baseUri'>
        /// Optional. The base URI of the service.
        /// </param>
        /// <param name='handlers'>
        /// Optional. The delegating handlers to add to the http client pipeline.
        /// </param>
        /// <exception cref='System.ArgumentNullException'>
        /// Thrown when a required parameter is null.
        /// </exception>
        public AutoRestHttpInfrastructureTestService(System.Uri baseUri, params DelegatingHandler[] handlers) : this(handlers)
        {
            if (baseUri == null)
            {
                throw new System.ArgumentNullException(nameof(baseUri));
            }
            BaseUri = baseUri;
        }

        /// <summary>
        /// Initializes a new instance of the AutoRestHttpInfrastructureTestService class.
        /// </summary>
        /// <param name='baseUri'>
        /// Optional. The base URI of the service.
        /// </param>
        /// <param name='rootHandler'>
        /// Optional. The http client handler used to handle http transport.
        /// </param>
        /// <param name='handlers'>
        /// Optional. The delegating handlers to add to the http client pipeline.
        /// </param>
        /// <exception cref='System.ArgumentNullException'>
        /// Thrown when a required parameter is null.
        /// </exception>
        public AutoRestHttpInfrastructureTestService(System.Uri baseUri, HttpClientHandler rootHandler, params DelegatingHandler[] handlers) : this(rootHandler, handlers)
        {
            if (baseUri == null)
            {
                throw new System.ArgumentNullException(nameof(baseUri));
            }
            BaseUri = baseUri;
        }

        /// <summary>
        /// An optional partial-method to perform custom initialization.
        /// </summary>
        partial void CustomInitialize();
        /// <summary>
        /// Initializes client properties.
        /// </summary>
        private void Initialize()
        {
            HttpFailure = new HttpFailure(new HttpFailureWithHttpMessages(this));
            HttpSuccess = new HttpSuccess(new HttpSuccessWithHttpMessages(this));
            HttpRedirects = new HttpRedirects(new HttpRedirectsWithHttpMessages(this));
            HttpClientFailure = new HttpClientFailure(new HttpClientFailureWithHttpMessages(this));
            HttpServerFailure = new HttpServerFailure(new HttpServerFailureWithHttpMessages(this));
            HttpRetry = new HttpRetry(new HttpRetryWithHttpMessages(this));
            MultipleResponses = new MultipleResponses(new MultipleResponsesWithHttpMessages(this));
            BaseUri = new System.Uri("http://localhost");
            SerializationSettings = new JsonSerializerSettings
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                DateFormatHandling = Newtonsoft.Json.DateFormatHandling.IsoDateFormat,
                DateTimeZoneHandling = Newtonsoft.Json.DateTimeZoneHandling.Utc,
                NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore,
                ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Serialize,
                ContractResolver = new ReadOnlyJsonContractResolver(),
                Converters = new List<JsonConverter>
                    {
                        new Iso8601TimeSpanConverter()
                    }
            };
            DeserializationSettings = new JsonSerializerSettings
            {
                DateFormatHandling = Newtonsoft.Json.DateFormatHandling.IsoDateFormat,
                DateTimeZoneHandling = Newtonsoft.Json.DateTimeZoneHandling.Utc,
                NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore,
                ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Serialize,
                ContractResolver = new ReadOnlyJsonContractResolver(),
                Converters = new List<JsonConverter>
                    {
                        new Iso8601TimeSpanConverter()
                    }
            };
            CustomInitialize();
        }
    }
}

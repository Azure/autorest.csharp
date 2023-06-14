// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using body_complex.Models;

namespace body_complex
{
    internal partial class PolymorphismRestClient
    {
        private readonly HttpPipeline _pipeline;
        private readonly Uri _endpoint;

        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal ClientDiagnostics ClientDiagnostics { get; }

        /// <summary> Initializes a new instance of PolymorphismRestClient. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="clientDiagnostics"/> or <paramref name="pipeline"/> is null. </exception>
        public PolymorphismRestClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Uri endpoint = null)
        {
            ClientDiagnostics = clientDiagnostics ?? throw new ArgumentNullException(nameof(clientDiagnostics));
            _pipeline = pipeline ?? throw new ArgumentNullException(nameof(pipeline));
            _endpoint = endpoint ?? new Uri("http://localhost:3000");
        }

        internal HttpMessage CreateGetValidRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/complex/polymorphism/valid", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get complex types that are polymorphic. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<Fish>> GetValidAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetValidRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        Fish value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = Fish.DeserializeFish(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get complex types that are polymorphic. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<Fish> GetValid(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetValidRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        Fish value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = Fish.DeserializeFish(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePutValidRequest(Fish complexBody)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/complex/polymorphism/valid", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(complexBody);
            request.Content = content;
            return message;
        }

        /// <summary> Put complex types that are polymorphic. </summary>
        /// <param name="complexBody">
        /// Please put a salmon that looks like this:
        /// {
        ///         'fishtype':'Salmon',
        ///         'location':'alaska',
        ///         'iswild':true,
        ///         'species':'king',
        ///         'length':1.0,
        ///         'siblings':[
        ///           {
        ///             'fishtype':'Shark',
        ///             'age':6,
        ///             'birthday': '2012-01-05T01:00:00Z',
        ///             'length':20.0,
        ///             'species':'predator',
        ///           },
        ///           {
        ///             'fishtype':'Sawshark',
        ///             'age':105,
        ///             'birthday': '1900-01-05T01:00:00Z',
        ///             'length':10.0,
        ///             'picture': new Buffer([255, 255, 255, 255, 254]).toString('base64'),
        ///             'species':'dangerous',
        ///           },
        ///           {
        ///             'fishtype': 'goblin',
        ///             'age': 1,
        ///             'birthday': '2015-08-08T00:00:00Z',
        ///             'length': 30.0,
        ///             'species': 'scary',
        ///             'jawsize': 5
        ///           }
        ///         ]
        ///       };
        /// </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="complexBody"/> is null. </exception>
        public async Task<Response> PutValidAsync(Fish complexBody, CancellationToken cancellationToken = default)
        {
            if (complexBody == null)
            {
                throw new ArgumentNullException(nameof(complexBody));
            }

            using var message = CreatePutValidRequest(complexBody);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Put complex types that are polymorphic. </summary>
        /// <param name="complexBody">
        /// Please put a salmon that looks like this:
        /// {
        ///         'fishtype':'Salmon',
        ///         'location':'alaska',
        ///         'iswild':true,
        ///         'species':'king',
        ///         'length':1.0,
        ///         'siblings':[
        ///           {
        ///             'fishtype':'Shark',
        ///             'age':6,
        ///             'birthday': '2012-01-05T01:00:00Z',
        ///             'length':20.0,
        ///             'species':'predator',
        ///           },
        ///           {
        ///             'fishtype':'Sawshark',
        ///             'age':105,
        ///             'birthday': '1900-01-05T01:00:00Z',
        ///             'length':10.0,
        ///             'picture': new Buffer([255, 255, 255, 255, 254]).toString('base64'),
        ///             'species':'dangerous',
        ///           },
        ///           {
        ///             'fishtype': 'goblin',
        ///             'age': 1,
        ///             'birthday': '2015-08-08T00:00:00Z',
        ///             'length': 30.0,
        ///             'species': 'scary',
        ///             'jawsize': 5
        ///           }
        ///         ]
        ///       };
        /// </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="complexBody"/> is null. </exception>
        public Response PutValid(Fish complexBody, CancellationToken cancellationToken = default)
        {
            if (complexBody == null)
            {
                throw new ArgumentNullException(nameof(complexBody));
            }

            using var message = CreatePutValidRequest(complexBody);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetDotSyntaxRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/complex/polymorphism/dotsyntax", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get complex types that are polymorphic, JSON key contains a dot. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<DotFish>> GetDotSyntaxAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetDotSyntaxRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        DotFish value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = DotFish.DeserializeDotFish(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get complex types that are polymorphic, JSON key contains a dot. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<DotFish> GetDotSyntax(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetDotSyntaxRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        DotFish value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = DotFish.DeserializeDotFish(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetComposedWithDiscriminatorRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/complex/polymorphism/composedWithDiscriminator", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get complex object composing a polymorphic scalar property and array property with polymorphic element type, with discriminator specified. Deserialization must NOT fail and use the discriminator type specified on the wire. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<DotFishMarket>> GetComposedWithDiscriminatorAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetComposedWithDiscriminatorRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        DotFishMarket value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = DotFishMarket.DeserializeDotFishMarket(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get complex object composing a polymorphic scalar property and array property with polymorphic element type, with discriminator specified. Deserialization must NOT fail and use the discriminator type specified on the wire. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<DotFishMarket> GetComposedWithDiscriminator(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetComposedWithDiscriminatorRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        DotFishMarket value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = DotFishMarket.DeserializeDotFishMarket(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetComposedWithoutDiscriminatorRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/complex/polymorphism/composedWithoutDiscriminator", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get complex object composing a polymorphic scalar property and array property with polymorphic element type, without discriminator specified on wire. Deserialization must NOT fail and use the explicit type of the property. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<DotFishMarket>> GetComposedWithoutDiscriminatorAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetComposedWithoutDiscriminatorRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        DotFishMarket value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = DotFishMarket.DeserializeDotFishMarket(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get complex object composing a polymorphic scalar property and array property with polymorphic element type, without discriminator specified on wire. Deserialization must NOT fail and use the explicit type of the property. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<DotFishMarket> GetComposedWithoutDiscriminator(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetComposedWithoutDiscriminatorRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        DotFishMarket value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = DotFishMarket.DeserializeDotFishMarket(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetComplicatedRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/complex/polymorphism/complicated", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get complex types that are polymorphic, but not at the root of the hierarchy; also have additional properties. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<Salmon>> GetComplicatedAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetComplicatedRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        Salmon value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = Salmon.DeserializeSalmon(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get complex types that are polymorphic, but not at the root of the hierarchy; also have additional properties. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<Salmon> GetComplicated(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetComplicatedRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        Salmon value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = Salmon.DeserializeSalmon(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePutComplicatedRequest(Salmon complexBody)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/complex/polymorphism/complicated", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(complexBody);
            request.Content = content;
            return message;
        }

        /// <summary> Put complex types that are polymorphic, but not at the root of the hierarchy; also have additional properties. </summary>
        /// <param name="complexBody"> The Salmon to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="complexBody"/> is null. </exception>
        public async Task<Response> PutComplicatedAsync(Salmon complexBody, CancellationToken cancellationToken = default)
        {
            if (complexBody == null)
            {
                throw new ArgumentNullException(nameof(complexBody));
            }

            using var message = CreatePutComplicatedRequest(complexBody);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Put complex types that are polymorphic, but not at the root of the hierarchy; also have additional properties. </summary>
        /// <param name="complexBody"> The Salmon to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="complexBody"/> is null. </exception>
        public Response PutComplicated(Salmon complexBody, CancellationToken cancellationToken = default)
        {
            if (complexBody == null)
            {
                throw new ArgumentNullException(nameof(complexBody));
            }

            using var message = CreatePutComplicatedRequest(complexBody);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePutMissingDiscriminatorRequest(Salmon complexBody)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/complex/polymorphism/missingdiscriminator", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(complexBody);
            request.Content = content;
            return message;
        }

        /// <summary> Put complex types that are polymorphic, omitting the discriminator. </summary>
        /// <param name="complexBody"> The Salmon to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="complexBody"/> is null. </exception>
        public async Task<Response<Salmon>> PutMissingDiscriminatorAsync(Salmon complexBody, CancellationToken cancellationToken = default)
        {
            if (complexBody == null)
            {
                throw new ArgumentNullException(nameof(complexBody));
            }

            using var message = CreatePutMissingDiscriminatorRequest(complexBody);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        Salmon value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = Salmon.DeserializeSalmon(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Put complex types that are polymorphic, omitting the discriminator. </summary>
        /// <param name="complexBody"> The Salmon to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="complexBody"/> is null. </exception>
        public Response<Salmon> PutMissingDiscriminator(Salmon complexBody, CancellationToken cancellationToken = default)
        {
            if (complexBody == null)
            {
                throw new ArgumentNullException(nameof(complexBody));
            }

            using var message = CreatePutMissingDiscriminatorRequest(complexBody);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        Salmon value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = Salmon.DeserializeSalmon(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePutValidMissingRequiredRequest(Fish complexBody)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/complex/polymorphism/missingrequired/invalid", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(complexBody);
            request.Content = content;
            return message;
        }

        /// <summary> Put complex types that are polymorphic, attempting to omit required 'birthday' field - the request should not be allowed from the client. </summary>
        /// <param name="complexBody">
        /// Please attempt put a sawshark that looks like this, the client should not allow this data to be sent:
        /// {
        ///     "fishtype": "sawshark",
        ///     "species": "snaggle toothed",
        ///     "length": 18.5,
        ///     "age": 2,
        ///     "birthday": "2013-06-01T01:00:00Z",
        ///     "location": "alaska",
        ///     "picture": base64(FF FF FF FF FE),
        ///     "siblings": [
        ///         {
        ///             "fishtype": "shark",
        ///             "species": "predator",
        ///             "birthday": "2012-01-05T01:00:00Z",
        ///             "length": 20,
        ///             "age": 6
        ///         },
        ///         {
        ///             "fishtype": "sawshark",
        ///             "species": "dangerous",
        ///             "picture": base64(FF FF FF FF FE),
        ///             "length": 10,
        ///             "age": 105
        ///         }
        ///     ]
        /// }
        /// </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="complexBody"/> is null. </exception>
        public async Task<Response> PutValidMissingRequiredAsync(Fish complexBody, CancellationToken cancellationToken = default)
        {
            if (complexBody == null)
            {
                throw new ArgumentNullException(nameof(complexBody));
            }

            using var message = CreatePutValidMissingRequiredRequest(complexBody);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Put complex types that are polymorphic, attempting to omit required 'birthday' field - the request should not be allowed from the client. </summary>
        /// <param name="complexBody">
        /// Please attempt put a sawshark that looks like this, the client should not allow this data to be sent:
        /// {
        ///     "fishtype": "sawshark",
        ///     "species": "snaggle toothed",
        ///     "length": 18.5,
        ///     "age": 2,
        ///     "birthday": "2013-06-01T01:00:00Z",
        ///     "location": "alaska",
        ///     "picture": base64(FF FF FF FF FE),
        ///     "siblings": [
        ///         {
        ///             "fishtype": "shark",
        ///             "species": "predator",
        ///             "birthday": "2012-01-05T01:00:00Z",
        ///             "length": 20,
        ///             "age": 6
        ///         },
        ///         {
        ///             "fishtype": "sawshark",
        ///             "species": "dangerous",
        ///             "picture": base64(FF FF FF FF FE),
        ///             "length": 10,
        ///             "age": 105
        ///         }
        ///     ]
        /// }
        /// </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="complexBody"/> is null. </exception>
        public Response PutValidMissingRequired(Fish complexBody, CancellationToken cancellationToken = default)
        {
            if (complexBody == null)
            {
                throw new ArgumentNullException(nameof(complexBody));
            }

            using var message = CreatePutValidMissingRequiredRequest(complexBody);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }
    }
}

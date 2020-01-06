// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using body_complex.Models.V20160229;

namespace body_complex
{
    internal partial class PolymorphismOperations
    {
        private string host;
        private ClientDiagnostics clientDiagnostics;
        private HttpPipeline pipeline;
        /// <summary> Initializes a new instance of PolymorphismOperations. </summary>
        public PolymorphismOperations(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "http://localhost:3000")
        {
            if (host == null)
            {
                throw new ArgumentNullException(nameof(host));
            }

            this.host = host;
            this.clientDiagnostics = clientDiagnostics;
            this.pipeline = pipeline;
        }
        /// <summary> Get complex types that are polymorphic. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<Fish>> GetValidAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("body_complex.GetValid");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/complex/polymorphism/valid", false);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = Fish.DeserializeFish(document.RootElement);
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Put complex types that are polymorphic. </summary>
        /// <param name="complexBody">
        /// Please put a salmon that looks like this:
        /// {
        ///         &apos;fishtype&apos;:&apos;Salmon&apos;,
        ///         &apos;location&apos;:&apos;alaska&apos;,
        ///         &apos;iswild&apos;:true,
        ///         &apos;species&apos;:&apos;king&apos;,
        ///         &apos;length&apos;:1.0,
        ///         &apos;siblings&apos;:[
        ///           {
        ///             &apos;fishtype&apos;:&apos;Shark&apos;,
        ///             &apos;age&apos;:6,
        ///             &apos;birthday&apos;: &apos;2012-01-05T01:00:00Z&apos;,
        ///             &apos;length&apos;:20.0,
        ///             &apos;species&apos;:&apos;predator&apos;,
        ///           },
        ///           {
        ///             &apos;fishtype&apos;:&apos;Sawshark&apos;,
        ///             &apos;age&apos;:105,
        ///             &apos;birthday&apos;: &apos;1900-01-05T01:00:00Z&apos;,
        ///             &apos;length&apos;:10.0,
        ///             &apos;picture&apos;: new Buffer([255, 255, 255, 255, 254]).toString(&apos;base64&apos;),
        ///             &apos;species&apos;:&apos;dangerous&apos;,
        ///           },
        ///           {
        ///             &apos;fishtype&apos;: &apos;goblin&apos;,
        ///             &apos;age&apos;: 1,
        ///             &apos;birthday&apos;: &apos;2015-08-08T00:00:00Z&apos;,
        ///             &apos;length&apos;: 30.0,
        ///             &apos;species&apos;: &apos;scary&apos;,
        ///             &apos;jawsize&apos;: 5
        ///           }
        ///         ]
        ///       };.
        /// </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutValidAsync(Fish complexBody, CancellationToken cancellationToken = default)
        {
            if (complexBody == null)
            {
                throw new ArgumentNullException(nameof(complexBody));
            }

            using var scope = clientDiagnostics.CreateScope("body_complex.PutValid");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Put;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/complex/polymorphism/valid", false);
                request.Headers.Add("Content-Type", "application/json");
                using var content = new Utf8JsonRequestContent();
                content.JsonWriter.WriteObjectValue(complexBody);
                request.Content = content;
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        return message.Response;
                    default:
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Get complex types that are polymorphic, JSON key contains a dot. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<DotFish>> GetDotSyntaxAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("body_complex.GetDotSyntax");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/complex/polymorphism/dotsyntax", false);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = DotFish.DeserializeDotFish(document.RootElement);
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Get complex object composing a polymorphic scalar property and array property with polymorphic element type, with discriminator specified. Deserialization must NOT fail and use the discriminator type specified on the wire. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<DotFishMarket>> GetComposedWithDiscriminatorAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("body_complex.GetComposedWithDiscriminator");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/complex/polymorphism/composedWithDiscriminator", false);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = DotFishMarket.DeserializeDotFishMarket(document.RootElement);
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Get complex object composing a polymorphic scalar property and array property with polymorphic element type, without discriminator specified on wire. Deserialization must NOT fail and use the explicit type of the property. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<DotFishMarket>> GetComposedWithoutDiscriminatorAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("body_complex.GetComposedWithoutDiscriminator");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/complex/polymorphism/composedWithoutDiscriminator", false);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = DotFishMarket.DeserializeDotFishMarket(document.RootElement);
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Get complex types that are polymorphic, but not at the root of the hierarchy; also have additional properties. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<Salmon>> GetComplicatedAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("body_complex.GetComplicated");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/complex/polymorphism/complicated", false);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = Salmon.DeserializeSalmon(document.RootElement);
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Put complex types that are polymorphic, but not at the root of the hierarchy; also have additional properties. </summary>
        /// <param name="complexBody"> The salmon to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutComplicatedAsync(Salmon complexBody, CancellationToken cancellationToken = default)
        {
            if (complexBody == null)
            {
                throw new ArgumentNullException(nameof(complexBody));
            }

            using var scope = clientDiagnostics.CreateScope("body_complex.PutComplicated");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Put;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/complex/polymorphism/complicated", false);
                request.Headers.Add("Content-Type", "application/json");
                using var content = new Utf8JsonRequestContent();
                content.JsonWriter.WriteObjectValue(complexBody);
                request.Content = content;
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        return message.Response;
                    default:
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Put complex types that are polymorphic, omitting the discriminator. </summary>
        /// <param name="complexBody"> The salmon to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<Salmon>> PutMissingDiscriminatorAsync(Salmon complexBody, CancellationToken cancellationToken = default)
        {
            if (complexBody == null)
            {
                throw new ArgumentNullException(nameof(complexBody));
            }

            using var scope = clientDiagnostics.CreateScope("body_complex.PutMissingDiscriminator");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Put;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/complex/polymorphism/missingdiscriminator", false);
                request.Headers.Add("Content-Type", "application/json");
                using var content = new Utf8JsonRequestContent();
                content.JsonWriter.WriteObjectValue(complexBody);
                request.Content = content;
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = Salmon.DeserializeSalmon(document.RootElement);
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Put complex types that are polymorphic, attempting to omit required &apos;birthday&apos; field - the request should not be allowed from the client. </summary>
        /// <param name="complexBody">
        /// Please put a salmon that looks like this:
        /// {
        ///         &apos;fishtype&apos;:&apos;Salmon&apos;,
        ///         &apos;location&apos;:&apos;alaska&apos;,
        ///         &apos;iswild&apos;:true,
        ///         &apos;species&apos;:&apos;king&apos;,
        ///         &apos;length&apos;:1.0,
        ///         &apos;siblings&apos;:[
        ///           {
        ///             &apos;fishtype&apos;:&apos;Shark&apos;,
        ///             &apos;age&apos;:6,
        ///             &apos;birthday&apos;: &apos;2012-01-05T01:00:00Z&apos;,
        ///             &apos;length&apos;:20.0,
        ///             &apos;species&apos;:&apos;predator&apos;,
        ///           },
        ///           {
        ///             &apos;fishtype&apos;:&apos;Sawshark&apos;,
        ///             &apos;age&apos;:105,
        ///             &apos;birthday&apos;: &apos;1900-01-05T01:00:00Z&apos;,
        ///             &apos;length&apos;:10.0,
        ///             &apos;picture&apos;: new Buffer([255, 255, 255, 255, 254]).toString(&apos;base64&apos;),
        ///             &apos;species&apos;:&apos;dangerous&apos;,
        ///           },
        ///           {
        ///             &apos;fishtype&apos;: &apos;goblin&apos;,
        ///             &apos;age&apos;: 1,
        ///             &apos;birthday&apos;: &apos;2015-08-08T00:00:00Z&apos;,
        ///             &apos;length&apos;: 30.0,
        ///             &apos;species&apos;: &apos;scary&apos;,
        ///             &apos;jawsize&apos;: 5
        ///           }
        ///         ]
        ///       };.
        /// </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutValidMissingRequiredAsync(Fish complexBody, CancellationToken cancellationToken = default)
        {
            if (complexBody == null)
            {
                throw new ArgumentNullException(nameof(complexBody));
            }

            using var scope = clientDiagnostics.CreateScope("body_complex.PutValidMissingRequired");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Put;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/complex/polymorphism/missingrequired/invalid", false);
                request.Headers.Add("Content-Type", "application/json");
                using var content = new Utf8JsonRequestContent();
                content.JsonWriter.WriteObjectValue(complexBody);
                request.Content = content;
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        return message.Response;
                    default:
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}

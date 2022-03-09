// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.Serialization;
using dpg_customization_LowLevel.Models;

namespace dpg_customization_LowLevel
{
    public partial class DPGClient
    {
        /// <summary> Get models that you will either return to end users as a raw body, or with a model added during grow up. </summary>
        /// <param name="mode"> The mode with which you&apos;ll be handling your returned body. &apos;raw&apos; for just dealing with the raw body, and &apos;model&apos; if you are going to convert the raw body to a customized body before returning to users. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="mode"/> is null. </exception>
        public virtual async Task<Response<Product>> GetModelValueAsync(string mode, CancellationToken cancellationToken = default)
        {
            RequestContext requestContext = new RequestContext();
            requestContext.CancellationToken = cancellationToken;

            Response response = await GetModelAsync(mode, requestContext);
            return Response.FromValue((Product)response, response);
        }

        /// <summary> Get models that you will either return to end users as a raw body, or with a model added during grow up. </summary>
        /// <param name="mode"> The mode with which you&apos;ll be handling your returned body. &apos;raw&apos; for just dealing with the raw body, and &apos;model&apos; if you are going to convert the raw body to a customized body before returning to users. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="mode"/> is null. </exception>
        public virtual Response<Product> GetModelValue(string mode, CancellationToken cancellationToken = default)
        {
            RequestContext requestContext = new RequestContext();
            requestContext.CancellationToken = cancellationToken;

            Response response = GetModel(mode, requestContext);
            return Response.FromValue((Product)response, response);
        }

        /// <summary> Post either raw response as a model and pass in &apos;raw&apos; for mode, or grow up your operation to take a model instead, and put in &apos;model&apos; as mode. </summary>
        /// <param name="mode"> The mode with which you&apos;ll be handling your returned body. &apos;raw&apos; for just dealing with the raw body, and &apos;model&apos; if you are going to convert the raw body to a customized body before returning to users. </param>
        /// <param name="input"> Please put {&apos;hello&apos;: &apos;world!&apos;}. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="mode"/> or <paramref name="input"/> is null. </exception>
        public virtual async Task<Response<Product>> PostModelAsync(string mode, Input input, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(input, nameof(input));

            RequestContext requestContext = new RequestContext();
            requestContext.CancellationToken = cancellationToken;

            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            };

            Response response = await PostModelAsync("model", RequestContent.Create(input, new JsonObjectSerializer(options)), requestContext);
            return Response.FromValue((Product)response, response);
        }

        /// <summary> Post either raw response as a model and pass in &apos;raw&apos; for mode, or grow up your operation to take a model instead, and put in &apos;model&apos; as mode. </summary>
        /// <param name="mode"> The mode with which you&apos;ll be handling your returned body. &apos;raw&apos; for just dealing with the raw body, and &apos;model&apos; if you are going to convert the raw body to a customized body before returning to users. </param>
        /// <param name="input"> Please put {&apos;hello&apos;: &apos;world!&apos;}. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="mode"/> or <paramref name="input"/> is null. </exception>
        public virtual Response<Product> PostModel(string mode, Input input, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(input, nameof(input));

            RequestContext requestContext = new RequestContext();
            requestContext.CancellationToken = cancellationToken;

            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            };

            Response result = PostModel("model", RequestContent.Create(input, new JsonObjectSerializer(options)), requestContext);
            return Response.FromValue((Product)result, result);
        }

        /// <summary> Get pages that you will either return to users in pages of raw bodies, or pages of models following growup. </summary>
        /// <param name="mode"> The mode with which you&apos;ll be handling your returned body. &apos;raw&apos; for just dealing with the raw body, and &apos;model&apos; if you are going to convert the raw body to a customized body before returning to users. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="mode"/> is null. </exception>
        public virtual AsyncPageable<Product> GetPageValuesAsync(string mode, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(mode, nameof(mode));

            RequestContext context = new RequestContext();
            context.CancellationToken = cancellationToken;

            using DiagnosticScope scope = ClientDiagnostics.CreateScope("DPGClient.GetPagesValue");
            scope.Start();

            try
            {
                AsyncPageable<BinaryData> pageableBindaryData = GetPagesAsync(mode, context);
                return PageableHelpers.Select(pageableBindaryData, response => ((ProductResult)response).Values);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get pages that you will either return to users in pages of raw bodies, or pages of models following growup. </summary>
        /// <param name="mode"> The mode with which you&apos;ll be handling your returned body. &apos;raw&apos; for just dealing with the raw body, and &apos;model&apos; if you are going to convert the raw body to a customized body before returning to users. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="mode"/> is null. </exception>
        public virtual Pageable<Product> GetPageValues(string mode, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(mode, nameof(mode));

            RequestContext context = new RequestContext();
            context.CancellationToken = cancellationToken;

            using DiagnosticScope scope = ClientDiagnostics.CreateScope("DPGClient.GetPagesValue");
            scope.Start();

            try
            {
                Pageable<BinaryData> pageableBindaryData = GetPages(mode, context);
                return PageableHelpers.Select(pageableBindaryData, response => ((ProductResult)response).Values);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}

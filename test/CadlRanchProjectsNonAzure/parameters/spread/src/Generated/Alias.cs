// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Scm.Parameters.Spread.Models;

namespace Scm.Parameters.Spread
{
    // Data plane generated sub-client.
    /// <summary> The Alias sub-client. </summary>
    public partial class Alias
    {
        private readonly ClientPipeline _pipeline;
        private readonly Uri _endpoint;

        /// <summary> The HTTP pipeline for sending and receiving REST requests and responses. </summary>
        public virtual ClientPipeline Pipeline => _pipeline;

        /// <summary> Initializes a new instance of Alias for mocking. </summary>
        protected Alias()
        {
        }

        /// <summary> Initializes a new instance of Alias. </summary>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="endpoint"> TestServer endpoint. </param>
        internal Alias(ClientPipeline pipeline, Uri endpoint)
        {
            _pipeline = pipeline;
            _endpoint = endpoint;
        }

        /// <summary> Spread as request body. </summary>
        /// <param name="name"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public virtual async Task<ClientResult> SpreadAsRequestBodyAsync(string name)
        {
            Argument.AssertNotNull(name, nameof(name));

            SpreadAsRequestBodyRequest spreadAsRequestBodyRequest = new SpreadAsRequestBodyRequest(name, null);
            ClientResult result = await SpreadAsRequestBodyAsync(spreadAsRequestBodyRequest.ToBinaryContent(), null).ConfigureAwait(false);
            return result;
        }

        /// <summary> Spread as request body. </summary>
        /// <param name="name"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public virtual ClientResult SpreadAsRequestBody(string name)
        {
            Argument.AssertNotNull(name, nameof(name));

            SpreadAsRequestBodyRequest spreadAsRequestBodyRequest = new SpreadAsRequestBodyRequest(name, null);
            ClientResult result = SpreadAsRequestBody(spreadAsRequestBodyRequest.ToBinaryContent(), null);
            return result;
        }

        /// <summary>
        /// [Protocol Method] Spread as request body.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://aka.ms/azsdk/net/protocol-methods">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="SpreadAsRequestBodyAsync(string)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="options"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual async Task<ClientResult> SpreadAsRequestBodyAsync(BinaryContent content, RequestOptions options = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using PipelineMessage message = CreateSpreadAsRequestBodyRequest(content, options);
            return ClientResult.FromResponse(await _pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false));
        }

        /// <summary>
        /// [Protocol Method] Spread as request body.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://aka.ms/azsdk/net/protocol-methods">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="SpreadAsRequestBody(string)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="options"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual ClientResult SpreadAsRequestBody(BinaryContent content, RequestOptions options = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using PipelineMessage message = CreateSpreadAsRequestBodyRequest(content, options);
            return ClientResult.FromResponse(_pipeline.ProcessMessage(message, options));
        }

        /// <summary> Spread as inner model parameter. </summary>
        /// <param name="id"> The <see cref="string"/> to use. </param>
        /// <param name="xMsTestHeader"> The <see cref="string"/> to use. </param>
        /// <param name="name"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="id"/>, <paramref name="xMsTestHeader"/> or <paramref name="name"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="id"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual async Task<ClientResult> SpreadAsInnerModelParameterAsync(string id, string xMsTestHeader, string name)
        {
            Argument.AssertNotNullOrEmpty(id, nameof(id));
            Argument.AssertNotNull(xMsTestHeader, nameof(xMsTestHeader));
            Argument.AssertNotNull(name, nameof(name));

            InnerModel innerModel = new InnerModel(name, null);
            ClientResult result = await SpreadAsInnerModelParameterAsync(id, xMsTestHeader, innerModel.ToBinaryContent(), null).ConfigureAwait(false);
            return result;
        }

        /// <summary> Spread as inner model parameter. </summary>
        /// <param name="id"> The <see cref="string"/> to use. </param>
        /// <param name="xMsTestHeader"> The <see cref="string"/> to use. </param>
        /// <param name="name"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="id"/>, <paramref name="xMsTestHeader"/> or <paramref name="name"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="id"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual ClientResult SpreadAsInnerModelParameter(string id, string xMsTestHeader, string name)
        {
            Argument.AssertNotNullOrEmpty(id, nameof(id));
            Argument.AssertNotNull(xMsTestHeader, nameof(xMsTestHeader));
            Argument.AssertNotNull(name, nameof(name));

            InnerModel innerModel = new InnerModel(name, null);
            ClientResult result = SpreadAsInnerModelParameter(id, xMsTestHeader, innerModel.ToBinaryContent(), null);
            return result;
        }

        /// <summary>
        /// [Protocol Method] Spread as inner model parameter.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://aka.ms/azsdk/net/protocol-methods">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="SpreadAsInnerModelParameterAsync(string,string,string)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="id"> The <see cref="string"/> to use. </param>
        /// <param name="xMsTestHeader"> The <see cref="string"/> to use. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="options"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="id"/>, <paramref name="xMsTestHeader"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="id"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual async Task<ClientResult> SpreadAsInnerModelParameterAsync(string id, string xMsTestHeader, BinaryContent content, RequestOptions options = null)
        {
            Argument.AssertNotNullOrEmpty(id, nameof(id));
            Argument.AssertNotNull(xMsTestHeader, nameof(xMsTestHeader));
            Argument.AssertNotNull(content, nameof(content));

            using PipelineMessage message = CreateSpreadAsInnerModelParameterRequest(id, xMsTestHeader, content, options);
            return ClientResult.FromResponse(await _pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false));
        }

        /// <summary>
        /// [Protocol Method] Spread as inner model parameter.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://aka.ms/azsdk/net/protocol-methods">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="SpreadAsInnerModelParameter(string,string,string)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="id"> The <see cref="string"/> to use. </param>
        /// <param name="xMsTestHeader"> The <see cref="string"/> to use. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="options"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="id"/>, <paramref name="xMsTestHeader"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="id"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual ClientResult SpreadAsInnerModelParameter(string id, string xMsTestHeader, BinaryContent content, RequestOptions options = null)
        {
            Argument.AssertNotNullOrEmpty(id, nameof(id));
            Argument.AssertNotNull(xMsTestHeader, nameof(xMsTestHeader));
            Argument.AssertNotNull(content, nameof(content));

            using PipelineMessage message = CreateSpreadAsInnerModelParameterRequest(id, xMsTestHeader, content, options);
            return ClientResult.FromResponse(_pipeline.ProcessMessage(message, options));
        }

        /// <summary> Spread as request parameter. </summary>
        /// <param name="id"> The <see cref="string"/> to use. </param>
        /// <param name="xMsTestHeader"> The <see cref="string"/> to use. </param>
        /// <param name="name"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="id"/>, <paramref name="xMsTestHeader"/> or <paramref name="name"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="id"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual async Task<ClientResult> SpreadAsRequestParameterAsync(string id, string xMsTestHeader, string name)
        {
            Argument.AssertNotNullOrEmpty(id, nameof(id));
            Argument.AssertNotNull(xMsTestHeader, nameof(xMsTestHeader));
            Argument.AssertNotNull(name, nameof(name));

            SpreadAsRequestParameterRequest spreadAsRequestParameterRequest = new SpreadAsRequestParameterRequest(name, null);
            ClientResult result = await SpreadAsRequestParameterAsync(id, xMsTestHeader, spreadAsRequestParameterRequest.ToBinaryContent(), null).ConfigureAwait(false);
            return result;
        }

        /// <summary> Spread as request parameter. </summary>
        /// <param name="id"> The <see cref="string"/> to use. </param>
        /// <param name="xMsTestHeader"> The <see cref="string"/> to use. </param>
        /// <param name="name"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="id"/>, <paramref name="xMsTestHeader"/> or <paramref name="name"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="id"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual ClientResult SpreadAsRequestParameter(string id, string xMsTestHeader, string name)
        {
            Argument.AssertNotNullOrEmpty(id, nameof(id));
            Argument.AssertNotNull(xMsTestHeader, nameof(xMsTestHeader));
            Argument.AssertNotNull(name, nameof(name));

            SpreadAsRequestParameterRequest spreadAsRequestParameterRequest = new SpreadAsRequestParameterRequest(name, null);
            ClientResult result = SpreadAsRequestParameter(id, xMsTestHeader, spreadAsRequestParameterRequest.ToBinaryContent(), null);
            return result;
        }

        /// <summary>
        /// [Protocol Method] Spread as request parameter.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://aka.ms/azsdk/net/protocol-methods">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="SpreadAsRequestParameterAsync(string,string,string)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="id"> The <see cref="string"/> to use. </param>
        /// <param name="xMsTestHeader"> The <see cref="string"/> to use. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="options"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="id"/>, <paramref name="xMsTestHeader"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="id"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual async Task<ClientResult> SpreadAsRequestParameterAsync(string id, string xMsTestHeader, BinaryContent content, RequestOptions options = null)
        {
            Argument.AssertNotNullOrEmpty(id, nameof(id));
            Argument.AssertNotNull(xMsTestHeader, nameof(xMsTestHeader));
            Argument.AssertNotNull(content, nameof(content));

            using PipelineMessage message = CreateSpreadAsRequestParameterRequest(id, xMsTestHeader, content, options);
            return ClientResult.FromResponse(await _pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false));
        }

        /// <summary>
        /// [Protocol Method] Spread as request parameter.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://aka.ms/azsdk/net/protocol-methods">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="SpreadAsRequestParameter(string,string,string)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="id"> The <see cref="string"/> to use. </param>
        /// <param name="xMsTestHeader"> The <see cref="string"/> to use. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="options"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="id"/>, <paramref name="xMsTestHeader"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="id"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual ClientResult SpreadAsRequestParameter(string id, string xMsTestHeader, BinaryContent content, RequestOptions options = null)
        {
            Argument.AssertNotNullOrEmpty(id, nameof(id));
            Argument.AssertNotNull(xMsTestHeader, nameof(xMsTestHeader));
            Argument.AssertNotNull(content, nameof(content));

            using PipelineMessage message = CreateSpreadAsRequestParameterRequest(id, xMsTestHeader, content, options);
            return ClientResult.FromResponse(_pipeline.ProcessMessage(message, options));
        }

        /// <summary> Spread with multiple parameters. </summary>
        /// <param name="id"> The <see cref="string"/> to use. </param>
        /// <param name="xMsTestHeader"> The <see cref="string"/> to use. </param>
        /// <param name="requiredString"> required string. </param>
        /// <param name="requiredIntList"> required int. </param>
        /// <param name="optionalInt"> optional int. </param>
        /// <param name="optionalStringList"> optional string. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="id"/>, <paramref name="xMsTestHeader"/>, <paramref name="requiredString"/> or <paramref name="requiredIntList"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="id"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual async Task<ClientResult> SpreadWithMultipleParametersAsync(string id, string xMsTestHeader, string requiredString, IEnumerable<int> requiredIntList, int? optionalInt = null, IEnumerable<string> optionalStringList = null)
        {
            Argument.AssertNotNullOrEmpty(id, nameof(id));
            Argument.AssertNotNull(xMsTestHeader, nameof(xMsTestHeader));
            Argument.AssertNotNull(requiredString, nameof(requiredString));
            Argument.AssertNotNull(requiredIntList, nameof(requiredIntList));

            SpreadWithMultipleParametersRequest spreadWithMultipleParametersRequest = new SpreadWithMultipleParametersRequest(requiredString, optionalInt, requiredIntList.ToList(), optionalStringList?.ToList() as IList<string> ?? new ChangeTrackingList<string>(), null);
            ClientResult result = await SpreadWithMultipleParametersAsync(id, xMsTestHeader, spreadWithMultipleParametersRequest.ToBinaryContent(), null).ConfigureAwait(false);
            return result;
        }

        /// <summary> Spread with multiple parameters. </summary>
        /// <param name="id"> The <see cref="string"/> to use. </param>
        /// <param name="xMsTestHeader"> The <see cref="string"/> to use. </param>
        /// <param name="requiredString"> required string. </param>
        /// <param name="requiredIntList"> required int. </param>
        /// <param name="optionalInt"> optional int. </param>
        /// <param name="optionalStringList"> optional string. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="id"/>, <paramref name="xMsTestHeader"/>, <paramref name="requiredString"/> or <paramref name="requiredIntList"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="id"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual ClientResult SpreadWithMultipleParameters(string id, string xMsTestHeader, string requiredString, IEnumerable<int> requiredIntList, int? optionalInt = null, IEnumerable<string> optionalStringList = null)
        {
            Argument.AssertNotNullOrEmpty(id, nameof(id));
            Argument.AssertNotNull(xMsTestHeader, nameof(xMsTestHeader));
            Argument.AssertNotNull(requiredString, nameof(requiredString));
            Argument.AssertNotNull(requiredIntList, nameof(requiredIntList));

            SpreadWithMultipleParametersRequest spreadWithMultipleParametersRequest = new SpreadWithMultipleParametersRequest(requiredString, optionalInt, requiredIntList.ToList(), optionalStringList?.ToList() as IList<string> ?? new ChangeTrackingList<string>(), null);
            ClientResult result = SpreadWithMultipleParameters(id, xMsTestHeader, spreadWithMultipleParametersRequest.ToBinaryContent(), null);
            return result;
        }

        /// <summary>
        /// [Protocol Method] Spread with multiple parameters.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://aka.ms/azsdk/net/protocol-methods">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="SpreadWithMultipleParametersAsync(string,string,string,IEnumerable{int},int?,IEnumerable{string})"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="id"> The <see cref="string"/> to use. </param>
        /// <param name="xMsTestHeader"> The <see cref="string"/> to use. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="options"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="id"/>, <paramref name="xMsTestHeader"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="id"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual async Task<ClientResult> SpreadWithMultipleParametersAsync(string id, string xMsTestHeader, BinaryContent content, RequestOptions options = null)
        {
            Argument.AssertNotNullOrEmpty(id, nameof(id));
            Argument.AssertNotNull(xMsTestHeader, nameof(xMsTestHeader));
            Argument.AssertNotNull(content, nameof(content));

            using PipelineMessage message = CreateSpreadWithMultipleParametersRequest(id, xMsTestHeader, content, options);
            return ClientResult.FromResponse(await _pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false));
        }

        /// <summary>
        /// [Protocol Method] Spread with multiple parameters.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://aka.ms/azsdk/net/protocol-methods">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="SpreadWithMultipleParameters(string,string,string,IEnumerable{int},int?,IEnumerable{string})"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="id"> The <see cref="string"/> to use. </param>
        /// <param name="xMsTestHeader"> The <see cref="string"/> to use. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="options"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="id"/>, <paramref name="xMsTestHeader"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="id"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual ClientResult SpreadWithMultipleParameters(string id, string xMsTestHeader, BinaryContent content, RequestOptions options = null)
        {
            Argument.AssertNotNullOrEmpty(id, nameof(id));
            Argument.AssertNotNull(xMsTestHeader, nameof(xMsTestHeader));
            Argument.AssertNotNull(content, nameof(content));

            using PipelineMessage message = CreateSpreadWithMultipleParametersRequest(id, xMsTestHeader, content, options);
            return ClientResult.FromResponse(_pipeline.ProcessMessage(message, options));
        }

        /// <summary> spread an alias with contains another alias property as body. </summary>
        /// <param name="id"> The <see cref="string"/> to use. </param>
        /// <param name="xMsTestHeader"> The <see cref="string"/> to use. </param>
        /// <param name="name"> name of the Thing. </param>
        /// <param name="age"> age of the Thing. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="id"/>, <paramref name="xMsTestHeader"/> or <paramref name="name"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="id"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual async Task<ClientResult> SpreadAliasWithSpreadAliasAsync(string id, string xMsTestHeader, string name, int age)
        {
            Argument.AssertNotNullOrEmpty(id, nameof(id));
            Argument.AssertNotNull(xMsTestHeader, nameof(xMsTestHeader));
            Argument.AssertNotNull(name, nameof(name));

            SpreadAliasWithSpreadAliasRequest spreadAliasWithSpreadAliasRequest = new SpreadAliasWithSpreadAliasRequest(name, age, null);
            ClientResult result = await SpreadAliasWithSpreadAliasAsync(id, xMsTestHeader, spreadAliasWithSpreadAliasRequest.ToBinaryContent(), null).ConfigureAwait(false);
            return result;
        }

        /// <summary> spread an alias with contains another alias property as body. </summary>
        /// <param name="id"> The <see cref="string"/> to use. </param>
        /// <param name="xMsTestHeader"> The <see cref="string"/> to use. </param>
        /// <param name="name"> name of the Thing. </param>
        /// <param name="age"> age of the Thing. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="id"/>, <paramref name="xMsTestHeader"/> or <paramref name="name"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="id"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual ClientResult SpreadAliasWithSpreadAlias(string id, string xMsTestHeader, string name, int age)
        {
            Argument.AssertNotNullOrEmpty(id, nameof(id));
            Argument.AssertNotNull(xMsTestHeader, nameof(xMsTestHeader));
            Argument.AssertNotNull(name, nameof(name));

            SpreadAliasWithSpreadAliasRequest spreadAliasWithSpreadAliasRequest = new SpreadAliasWithSpreadAliasRequest(name, age, null);
            ClientResult result = SpreadAliasWithSpreadAlias(id, xMsTestHeader, spreadAliasWithSpreadAliasRequest.ToBinaryContent(), null);
            return result;
        }

        /// <summary>
        /// [Protocol Method] spread an alias with contains another alias property as body.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://aka.ms/azsdk/net/protocol-methods">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="SpreadAliasWithSpreadAliasAsync(string,string,string,int)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="id"> The <see cref="string"/> to use. </param>
        /// <param name="xMsTestHeader"> The <see cref="string"/> to use. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="options"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="id"/>, <paramref name="xMsTestHeader"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="id"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual async Task<ClientResult> SpreadAliasWithSpreadAliasAsync(string id, string xMsTestHeader, BinaryContent content, RequestOptions options = null)
        {
            Argument.AssertNotNullOrEmpty(id, nameof(id));
            Argument.AssertNotNull(xMsTestHeader, nameof(xMsTestHeader));
            Argument.AssertNotNull(content, nameof(content));

            using PipelineMessage message = CreateSpreadAliasWithSpreadAliasRequest(id, xMsTestHeader, content, options);
            return ClientResult.FromResponse(await _pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false));
        }

        /// <summary>
        /// [Protocol Method] spread an alias with contains another alias property as body.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://aka.ms/azsdk/net/protocol-methods">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="SpreadAliasWithSpreadAlias(string,string,string,int)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="id"> The <see cref="string"/> to use. </param>
        /// <param name="xMsTestHeader"> The <see cref="string"/> to use. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="options"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="id"/>, <paramref name="xMsTestHeader"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="id"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual ClientResult SpreadAliasWithSpreadAlias(string id, string xMsTestHeader, BinaryContent content, RequestOptions options = null)
        {
            Argument.AssertNotNullOrEmpty(id, nameof(id));
            Argument.AssertNotNull(xMsTestHeader, nameof(xMsTestHeader));
            Argument.AssertNotNull(content, nameof(content));

            using PipelineMessage message = CreateSpreadAliasWithSpreadAliasRequest(id, xMsTestHeader, content, options);
            return ClientResult.FromResponse(_pipeline.ProcessMessage(message, options));
        }

        internal PipelineMessage CreateSpreadAsRequestBodyRequest(BinaryContent content, RequestOptions options)
        {
            var message = _pipeline.CreateMessage();
            message.ResponseClassifier = PipelineMessageClassifier204;
            var request = message.Request;
            request.Method = "PUT";
            var uri = new ClientUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/parameters/spread/alias/request-body", false);
            request.Uri = uri.ToUri();
            request.Headers.Set("Accept", "application/json");
            request.Headers.Set("Content-Type", "application/json");
            request.Content = content;
            message.Apply(options);
            return message;
        }

        internal PipelineMessage CreateSpreadAsInnerModelParameterRequest(string id, string xMsTestHeader, BinaryContent content, RequestOptions options)
        {
            var message = _pipeline.CreateMessage();
            message.ResponseClassifier = PipelineMessageClassifier204;
            var request = message.Request;
            request.Method = "POST";
            var uri = new ClientUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/parameters/spread/alias/request-with-model/", false);
            uri.AppendPath(id, true);
            request.Uri = uri.ToUri();
            request.Headers.Set("x-ms-test-header", xMsTestHeader);
            request.Headers.Set("Accept", "application/json");
            request.Headers.Set("Content-Type", "application/json");
            request.Content = content;
            message.Apply(options);
            return message;
        }

        internal PipelineMessage CreateSpreadAsRequestParameterRequest(string id, string xMsTestHeader, BinaryContent content, RequestOptions options)
        {
            var message = _pipeline.CreateMessage();
            message.ResponseClassifier = PipelineMessageClassifier204;
            var request = message.Request;
            request.Method = "PUT";
            var uri = new ClientUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/parameters/spread/alias/request-parameter/", false);
            uri.AppendPath(id, true);
            request.Uri = uri.ToUri();
            request.Headers.Set("x-ms-test-header", xMsTestHeader);
            request.Headers.Set("Accept", "application/json");
            request.Headers.Set("Content-Type", "application/json");
            request.Content = content;
            message.Apply(options);
            return message;
        }

        internal PipelineMessage CreateSpreadWithMultipleParametersRequest(string id, string xMsTestHeader, BinaryContent content, RequestOptions options)
        {
            var message = _pipeline.CreateMessage();
            message.ResponseClassifier = PipelineMessageClassifier204;
            var request = message.Request;
            request.Method = "PUT";
            var uri = new ClientUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/parameters/spread/alias/multiple-parameters/", false);
            uri.AppendPath(id, true);
            request.Uri = uri.ToUri();
            request.Headers.Set("x-ms-test-header", xMsTestHeader);
            request.Headers.Set("Accept", "application/json");
            request.Headers.Set("Content-Type", "application/json");
            request.Content = content;
            message.Apply(options);
            return message;
        }

        internal PipelineMessage CreateSpreadAliasWithSpreadAliasRequest(string id, string xMsTestHeader, BinaryContent content, RequestOptions options)
        {
            var message = _pipeline.CreateMessage();
            message.ResponseClassifier = PipelineMessageClassifier204;
            var request = message.Request;
            request.Method = "POST";
            var uri = new ClientUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/parameters/spread/alias/request-with-spread-alias/", false);
            uri.AppendPath(id, true);
            request.Uri = uri.ToUri();
            request.Headers.Set("x-ms-test-header", xMsTestHeader);
            request.Headers.Set("Accept", "application/json");
            request.Headers.Set("Content-Type", "application/json");
            request.Content = content;
            message.Apply(options);
            return message;
        }

        private static PipelineMessageClassifier _pipelineMessageClassifier204;
        private static PipelineMessageClassifier PipelineMessageClassifier204 => _pipelineMessageClassifier204 ??= PipelineMessageClassifier.Create(stackalloc ushort[] { 204 });
    }
}

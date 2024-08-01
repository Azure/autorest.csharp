// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Threading;

namespace OpenAI
{
    // Data plane generated sub-client.
    /// <summary> The Chat sub-client. </summary>
    public partial class Chat
    {
        private const string AuthorizationHeader = "Authorization";
        private readonly ApiKeyCredential _keyCredential;
        private const string AuthorizationApiKeyPrefix = "Bearer";
        private readonly ClientPipeline _pipeline;
        private readonly Uri _endpoint;

        /// <summary> The HTTP pipeline for sending and receiving REST requests and responses. </summary>
        public virtual ClientPipeline Pipeline => _pipeline;

        /// <summary> Initializes a new instance of Chat for mocking. </summary>
        protected Chat()
        {
        }

        /// <summary> Initializes a new instance of Chat. </summary>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="keyCredential"> The key credential to copy. </param>
        /// <param name="endpoint"> The <see cref="string"/> to use. </param>
        internal Chat(ClientPipeline pipeline, ApiKeyCredential keyCredential, Uri endpoint)
        {
            _pipeline = pipeline;
            _keyCredential = keyCredential;
            _endpoint = endpoint;
        }

        private ChatCompletions _cachedChatCompletions;

        /// <summary> Initializes a new instance of ChatCompletions. </summary>
        public virtual ChatCompletions GetChatCompletionsClient()
        {
            return Volatile.Read(ref _cachedChatCompletions) ?? Interlocked.CompareExchange(ref _cachedChatCompletions, new ChatCompletions(_pipeline, _keyCredential, _endpoint), null) ?? _cachedChatCompletions;
        }
    }
}

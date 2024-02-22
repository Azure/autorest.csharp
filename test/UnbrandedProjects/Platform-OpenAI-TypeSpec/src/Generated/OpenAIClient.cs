// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.ClientModel.Primitives.Pipeline;
using System.Threading;

namespace OpenAI
{
    // Data plane generated client.
    /// <summary> The OpenAI service client. </summary>
    public partial class OpenAIClient
    {
        private const string AuthorizationHeader = "Authorization";
        private readonly KeyCredential _keyCredential;
        private const string AuthorizationApiKeyPrefix = "Bearer";
        private readonly MessagePipeline _pipeline;
        private readonly Uri _endpoint;

        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal TelemetrySource ClientDiagnostics { get; }

        /// <summary> The HTTP pipeline for sending and receiving REST requests and responses. </summary>
        public virtual MessagePipeline Pipeline => _pipeline;

        /// <summary> Initializes a new instance of OpenAIClient for mocking. </summary>
        protected OpenAIClient()
        {
        }

        /// <summary> Initializes a new instance of OpenAIClient. </summary>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="credential"/> is null. </exception>
        public OpenAIClient(KeyCredential credential) : this(new Uri("https://api.openai.com/v1"), credential, new OpenAIClientOptions())
        {
        }

        /// <summary> Initializes a new instance of OpenAIClient. </summary>
        /// <param name="endpoint"> OpenAI Endpoint. </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> or <paramref name="credential"/> is null. </exception>
        public OpenAIClient(Uri endpoint, KeyCredential credential, OpenAIClientOptions options)
        {
            if (endpoint == null)
            {
                throw new ArgumentNullException(nameof(endpoint));
            }
            if (credential == null)
            {
                throw new ArgumentNullException(nameof(credential));
            }
            options ??= new OpenAIClientOptions();

            ClientDiagnostics = new TelemetrySource(options, true);
            _keyCredential = credential;
            _pipeline = MessagePipeline.Create(options, new IPipelinePolicy<PipelineMessage>[] { new KeyCredentialPolicy(_keyCredential, AuthorizationHeader, AuthorizationApiKeyPrefix) }, Array.Empty<IPipelinePolicy<PipelineMessage>>());
            _endpoint = endpoint;
        }

        private Audio _cachedAudio;
        private Chat _cachedChat;
        private FineTuning _cachedFineTuning;
        private Completions _cachedCompletions;
        private Edits _cachedEdits;
        private Embeddings _cachedEmbeddings;
        private Files _cachedFiles;
        private FineTunes _cachedFineTunes;
        private ModelsOps _cachedModelsOps;
        private Images _cachedImages;
        private Moderations _cachedModerations;

        /// <summary> Initializes a new instance of Audio. </summary>
        public virtual Audio GetAudioClient()
        {
            return Volatile.Read(ref _cachedAudio) ?? Interlocked.CompareExchange(ref _cachedAudio, new Audio(ClientDiagnostics, _pipeline, _keyCredential, _endpoint), null) ?? _cachedAudio;
        }

        /// <summary> Initializes a new instance of Chat. </summary>
        public virtual Chat GetChatClient()
        {
            return Volatile.Read(ref _cachedChat) ?? Interlocked.CompareExchange(ref _cachedChat, new Chat(ClientDiagnostics, _pipeline, _keyCredential, _endpoint), null) ?? _cachedChat;
        }

        /// <summary> Initializes a new instance of FineTuning. </summary>
        public virtual FineTuning GetFineTuningClient()
        {
            return Volatile.Read(ref _cachedFineTuning) ?? Interlocked.CompareExchange(ref _cachedFineTuning, new FineTuning(ClientDiagnostics, _pipeline, _keyCredential, _endpoint), null) ?? _cachedFineTuning;
        }

        /// <summary> Initializes a new instance of Completions. </summary>
        public virtual Completions GetCompletionsClient()
        {
            return Volatile.Read(ref _cachedCompletions) ?? Interlocked.CompareExchange(ref _cachedCompletions, new Completions(ClientDiagnostics, _pipeline, _keyCredential, _endpoint), null) ?? _cachedCompletions;
        }

        /// <summary> Initializes a new instance of Edits. </summary>
        public virtual Edits GetEditsClient()
        {
            return Volatile.Read(ref _cachedEdits) ?? Interlocked.CompareExchange(ref _cachedEdits, new Edits(ClientDiagnostics, _pipeline, _keyCredential, _endpoint), null) ?? _cachedEdits;
        }

        /// <summary> Initializes a new instance of Embeddings. </summary>
        public virtual Embeddings GetEmbeddingsClient()
        {
            return Volatile.Read(ref _cachedEmbeddings) ?? Interlocked.CompareExchange(ref _cachedEmbeddings, new Embeddings(ClientDiagnostics, _pipeline, _keyCredential, _endpoint), null) ?? _cachedEmbeddings;
        }

        /// <summary> Initializes a new instance of Files. </summary>
        public virtual Files GetFilesClient()
        {
            return Volatile.Read(ref _cachedFiles) ?? Interlocked.CompareExchange(ref _cachedFiles, new Files(ClientDiagnostics, _pipeline, _keyCredential, _endpoint), null) ?? _cachedFiles;
        }

        /// <summary> Initializes a new instance of FineTunes. </summary>
        public virtual FineTunes GetFineTunesClient()
        {
            return Volatile.Read(ref _cachedFineTunes) ?? Interlocked.CompareExchange(ref _cachedFineTunes, new FineTunes(ClientDiagnostics, _pipeline, _keyCredential, _endpoint), null) ?? _cachedFineTunes;
        }

        /// <summary> Initializes a new instance of ModelsOps. </summary>
        public virtual ModelsOps GetModelsOpsClient()
        {
            return Volatile.Read(ref _cachedModelsOps) ?? Interlocked.CompareExchange(ref _cachedModelsOps, new ModelsOps(ClientDiagnostics, _pipeline, _keyCredential, _endpoint), null) ?? _cachedModelsOps;
        }

        /// <summary> Initializes a new instance of Images. </summary>
        public virtual Images GetImagesClient()
        {
            return Volatile.Read(ref _cachedImages) ?? Interlocked.CompareExchange(ref _cachedImages, new Images(ClientDiagnostics, _pipeline, _keyCredential, _endpoint), null) ?? _cachedImages;
        }

        /// <summary> Initializes a new instance of Moderations. </summary>
        public virtual Moderations GetModerationsClient()
        {
            return Volatile.Read(ref _cachedModerations) ?? Interlocked.CompareExchange(ref _cachedModerations, new Moderations(ClientDiagnostics, _pipeline, _keyCredential, _endpoint), null) ?? _cachedModerations;
        }
    }
}

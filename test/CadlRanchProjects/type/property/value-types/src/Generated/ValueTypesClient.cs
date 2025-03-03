// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading;
using Azure.Core;
using Azure.Core.Pipeline;

namespace _Type.Property.ValueTypes
{
    // Data plane generated client.
    /// <summary> Illustrates various property types for models. </summary>
    public partial class ValueTypesClient
    {
        private readonly HttpPipeline _pipeline;
        private readonly Uri _endpoint;

        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal ClientDiagnostics ClientDiagnostics { get; }

        /// <summary> The HTTP pipeline for sending and receiving REST requests and responses. </summary>
        public virtual HttpPipeline Pipeline => _pipeline;

        /// <summary> Initializes a new instance of ValueTypesClient. </summary>
        public ValueTypesClient() : this(new Uri("http://localhost:3000"), new ValueTypesClientOptions())
        {
        }

        /// <summary> Initializes a new instance of ValueTypesClient. </summary>
        /// <param name="endpoint"> Service host. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> is null. </exception>
        public ValueTypesClient(Uri endpoint, ValueTypesClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            options ??= new ValueTypesClientOptions();

            ClientDiagnostics = new ClientDiagnostics(options, true);
            _pipeline = HttpPipelineBuilder.Build(options, Array.Empty<HttpPipelinePolicy>(), Array.Empty<HttpPipelinePolicy>(), new ResponseClassifier());
            _endpoint = endpoint;
        }

        private Boolean _cachedBoolean;
        private String _cachedString;
        private Bytes _cachedBytes;
        private Int _cachedInt;
        private Float _cachedFloat;
        private Decimal _cachedDecimal;
        private Decimal128 _cachedDecimal128;
        private Datetime _cachedDatetime;
        private Duration _cachedDuration;
        private Enum _cachedEnum;
        private ExtensibleEnum _cachedExtensibleEnum;
        private Model _cachedModel;
        private CollectionsString _cachedCollectionsString;
        private CollectionsInt _cachedCollectionsInt;
        private CollectionsModel _cachedCollectionsModel;
        private DictionaryString _cachedDictionaryString;
        private Never _cachedNever;
        private UnknownString _cachedUnknownString;
        private UnknownInt _cachedUnknownInt;
        private UnknownDict _cachedUnknownDict;
        private UnknownArray _cachedUnknownArray;
        private StringLiteral _cachedStringLiteral;
        private IntLiteral _cachedIntLiteral;
        private FloatLiteral _cachedFloatLiteral;
        private BooleanLiteral _cachedBooleanLiteral;
        private UnionStringLiteral _cachedUnionStringLiteral;
        private UnionIntLiteral _cachedUnionIntLiteral;
        private UnionFloatLiteral _cachedUnionFloatLiteral;
        private UnionEnumValue _cachedUnionEnumValue;

        /// <summary> Initializes a new instance of Boolean. </summary>
        public virtual Boolean GetBooleanClient()
        {
            return Volatile.Read(ref _cachedBoolean) ?? Interlocked.CompareExchange(ref _cachedBoolean, new Boolean(ClientDiagnostics, _pipeline, _endpoint), null) ?? _cachedBoolean;
        }

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

        /// <summary> Initializes a new instance of Int. </summary>
        public virtual Int GetIntClient()
        {
            return Volatile.Read(ref _cachedInt) ?? Interlocked.CompareExchange(ref _cachedInt, new Int(ClientDiagnostics, _pipeline, _endpoint), null) ?? _cachedInt;
        }

        /// <summary> Initializes a new instance of Float. </summary>
        public virtual Float GetFloatClient()
        {
            return Volatile.Read(ref _cachedFloat) ?? Interlocked.CompareExchange(ref _cachedFloat, new Float(ClientDiagnostics, _pipeline, _endpoint), null) ?? _cachedFloat;
        }

        /// <summary> Initializes a new instance of Decimal. </summary>
        public virtual Decimal GetDecimalClient()
        {
            return Volatile.Read(ref _cachedDecimal) ?? Interlocked.CompareExchange(ref _cachedDecimal, new Decimal(ClientDiagnostics, _pipeline, _endpoint), null) ?? _cachedDecimal;
        }

        /// <summary> Initializes a new instance of Decimal128. </summary>
        public virtual Decimal128 GetDecimal128Client()
        {
            return Volatile.Read(ref _cachedDecimal128) ?? Interlocked.CompareExchange(ref _cachedDecimal128, new Decimal128(ClientDiagnostics, _pipeline, _endpoint), null) ?? _cachedDecimal128;
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

        /// <summary> Initializes a new instance of Enum. </summary>
        public virtual Enum GetEnumClient()
        {
            return Volatile.Read(ref _cachedEnum) ?? Interlocked.CompareExchange(ref _cachedEnum, new Enum(ClientDiagnostics, _pipeline, _endpoint), null) ?? _cachedEnum;
        }

        /// <summary> Initializes a new instance of ExtensibleEnum. </summary>
        public virtual ExtensibleEnum GetExtensibleEnumClient()
        {
            return Volatile.Read(ref _cachedExtensibleEnum) ?? Interlocked.CompareExchange(ref _cachedExtensibleEnum, new ExtensibleEnum(ClientDiagnostics, _pipeline, _endpoint), null) ?? _cachedExtensibleEnum;
        }

        /// <summary> Initializes a new instance of Model. </summary>
        public virtual Model GetModelClient()
        {
            return Volatile.Read(ref _cachedModel) ?? Interlocked.CompareExchange(ref _cachedModel, new Model(ClientDiagnostics, _pipeline, _endpoint), null) ?? _cachedModel;
        }

        /// <summary> Initializes a new instance of CollectionsString. </summary>
        public virtual CollectionsString GetCollectionsStringClient()
        {
            return Volatile.Read(ref _cachedCollectionsString) ?? Interlocked.CompareExchange(ref _cachedCollectionsString, new CollectionsString(ClientDiagnostics, _pipeline, _endpoint), null) ?? _cachedCollectionsString;
        }

        /// <summary> Initializes a new instance of CollectionsInt. </summary>
        public virtual CollectionsInt GetCollectionsIntClient()
        {
            return Volatile.Read(ref _cachedCollectionsInt) ?? Interlocked.CompareExchange(ref _cachedCollectionsInt, new CollectionsInt(ClientDiagnostics, _pipeline, _endpoint), null) ?? _cachedCollectionsInt;
        }

        /// <summary> Initializes a new instance of CollectionsModel. </summary>
        public virtual CollectionsModel GetCollectionsModelClient()
        {
            return Volatile.Read(ref _cachedCollectionsModel) ?? Interlocked.CompareExchange(ref _cachedCollectionsModel, new CollectionsModel(ClientDiagnostics, _pipeline, _endpoint), null) ?? _cachedCollectionsModel;
        }

        /// <summary> Initializes a new instance of DictionaryString. </summary>
        public virtual DictionaryString GetDictionaryStringClient()
        {
            return Volatile.Read(ref _cachedDictionaryString) ?? Interlocked.CompareExchange(ref _cachedDictionaryString, new DictionaryString(ClientDiagnostics, _pipeline, _endpoint), null) ?? _cachedDictionaryString;
        }

        /// <summary> Initializes a new instance of Never. </summary>
        public virtual Never GetNeverClient()
        {
            return Volatile.Read(ref _cachedNever) ?? Interlocked.CompareExchange(ref _cachedNever, new Never(ClientDiagnostics, _pipeline, _endpoint), null) ?? _cachedNever;
        }

        /// <summary> Initializes a new instance of UnknownString. </summary>
        public virtual UnknownString GetUnknownStringClient()
        {
            return Volatile.Read(ref _cachedUnknownString) ?? Interlocked.CompareExchange(ref _cachedUnknownString, new UnknownString(ClientDiagnostics, _pipeline, _endpoint), null) ?? _cachedUnknownString;
        }

        /// <summary> Initializes a new instance of UnknownInt. </summary>
        public virtual UnknownInt GetUnknownIntClient()
        {
            return Volatile.Read(ref _cachedUnknownInt) ?? Interlocked.CompareExchange(ref _cachedUnknownInt, new UnknownInt(ClientDiagnostics, _pipeline, _endpoint), null) ?? _cachedUnknownInt;
        }

        /// <summary> Initializes a new instance of UnknownDict. </summary>
        public virtual UnknownDict GetUnknownDictClient()
        {
            return Volatile.Read(ref _cachedUnknownDict) ?? Interlocked.CompareExchange(ref _cachedUnknownDict, new UnknownDict(ClientDiagnostics, _pipeline, _endpoint), null) ?? _cachedUnknownDict;
        }

        /// <summary> Initializes a new instance of UnknownArray. </summary>
        public virtual UnknownArray GetUnknownArrayClient()
        {
            return Volatile.Read(ref _cachedUnknownArray) ?? Interlocked.CompareExchange(ref _cachedUnknownArray, new UnknownArray(ClientDiagnostics, _pipeline, _endpoint), null) ?? _cachedUnknownArray;
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

        /// <summary> Initializes a new instance of UnionEnumValue. </summary>
        public virtual UnionEnumValue GetUnionEnumValueClient()
        {
            return Volatile.Read(ref _cachedUnionEnumValue) ?? Interlocked.CompareExchange(ref _cachedUnionEnumValue, new UnionEnumValue(ClientDiagnostics, _pipeline, _endpoint), null) ?? _cachedUnionEnumValue;
        }
    }
}

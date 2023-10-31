// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Net.ClientModel.Core;
using System.Net.ClientModel.Internal;
using System.Threading.Tasks;
using AutoRest.CSharp.Common.Output.Expressions;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Generation.Writers;
using Azure.Core;

namespace AutoRest.CSharp.Common.Input
{
    internal abstract class ApiTypes
    {
        public abstract Type ResponseType { get; }
        public abstract Type ResponseOfTType { get; }

        public abstract string FromResponseName { get; }
        public abstract string ResponseParameterName { get; }

        public abstract string GetRawResponseName { get; }

        public Type GetResponseOfT<T>() => ResponseOfTType.MakeGenericType(typeof(T));
        public Type GetTaskOfResponse(Type? valueType = default) =>
            valueType is null ? typeof(Task<>).MakeGenericType(ResponseType) : typeof(Task<>).MakeGenericType(ResponseOfTType.MakeGenericType(valueType));
        public Type GetValueTaskOfResponse(Type? valueType = default) =>
            valueType is null ? typeof(ValueTask<>).MakeGenericType(ResponseType) : typeof(ValueTask<>).MakeGenericType(ResponseOfTType.MakeGenericType(valueType));

        public abstract Type HttpPipelineType { get; }
        public abstract string HttpPipelineCreateMessageName { get; }

        public abstract Type HttpMessageType { get; }
        public abstract string HttpMessageResponseName { get; }
        public string HttpMessageResponseStatusName => nameof(PipelineResponse.Status);

        public Type GetNextPageFuncType() => typeof(Func<,,>).MakeGenericType(typeof(int?), typeof(string), HttpMessageType);

        public abstract Type ClientDiagnosticsType { get; }
        public abstract string ClientDiagnosticsCreateScopeName { get; }

        public abstract Type ClientOptionsType { get; }

        public abstract Type ArgumentType { get; }
        public string AssertNotNullOrEmptyName => nameof(ClientUtilities.AssertNotNullOrEmpty);
        public string AssertNotNullName => nameof(ClientUtilities.AssertNotNull);

        public abstract Type RequestContextType { get; }

        public abstract Type ChangeTrackingListType { get; }
        public abstract Type ChangeTrackingDictionaryType { get; }

        public abstract Type HttpPipelineBuilderType { get; }
        public abstract Type BearerAuthenticationPolicyType { get; }
        public abstract Type KeyCredentialPolicyType { get; }
        public abstract Type KeyCredentialType { get; }
        public FormattableString GetHttpPipelineBearerString(string pipelineField, string optionsVariable, string credentialVariable, CodeWriterDeclaration? scopesParam)
            => $"{pipelineField} = {HttpPipelineBuilderType}.Build({optionsVariable}, new {BearerAuthenticationPolicyType}({credentialVariable}, {scopesParam}));";
        public FormattableString GetHttpPipelineKeyCredentialString(string pipelineField, string optionsVariable, string credentialVariable, string keyName)
            => $"{pipelineField} = {HttpPipelineBuilderType}.Build({optionsVariable}, new {KeyCredentialPolicyType}({credentialVariable}, \"{keyName}\"));";
        public abstract FormattableString GetHttpPipelineClassifierString(string pipelineField, string optionsVariable, FormattableString perCallPolicies, FormattableString perRetryPolicies);

        public abstract Type HttpPipelinePolicyType { get; }

        public abstract string HttpMessageRequestName { get; }

        public abstract Type RequestContentType { get; }
        public abstract string ToRequestContentName { get; }
        public abstract string RequestContentCreateName { get; }

        public abstract Type IUtf8JsonSerializableType { get; }
        public string IUtf8JsonSerializableWriteName => nameof(IUtf8JsonSerializable.Write);

        public abstract Type Utf8JsonWriterExtensionsType { get; }
        public string Utf8JsonWriterExtensionsWriteObjectValueName => nameof(Utf8JsonWriterExtensions.WriteObjectValue);
        public string Utf8JsonWriterExtensionsWriteNumberValueName => nameof(Utf8JsonWriterExtensions.WriteNumberValue);
        public string Utf8JsonWriterExtensionsWriteStringValueName => nameof(Utf8JsonWriterExtensions.WriteStringValue);
        public string Utf8JsonWriterExtensionsWriteBase64StringValueName => nameof(Utf8JsonWriterExtensions.WriteBase64StringValue);

        public abstract Type OptionalType { get; }
        public abstract Type OptionalPropertyType { get; }

        public string OptionalIsCollectionDefinedName => nameof(OptionalProperty.IsCollectionDefined);
        public string OptionalIsDefinedName => nameof(OptionalProperty.IsDefined);
        public string OptionalToDictionaryName => nameof(OptionalProperty.ToDictionary);
        public string OptionalToListName => nameof(OptionalProperty.ToList);
        public string OptionalToNullableName => nameof(OptionalProperty.ToNullable);

        public abstract Type RequestFailedExceptionType { get; }

        public string ResponseClassifierIsErrorResponseName => nameof(ResponseErrorClassifier.IsErrorResponse);

        public abstract string EndPointSampleValue { get; }

        public abstract Type ResponseClassifierType { get; }
        public abstract Type StatusCodeClassifierType { get; }

        public abstract ValueExpression GetCreateFromStreamSampleExpression(ValueExpression freeFormObjectExpression);

        public abstract ValueExpression GetKeySampleExpression(string clientName);

        public abstract ExtensibleSnippets ExtensibleSnippets { get; }

        public abstract string LicenseString { get; }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Common.Output.Builders;
using AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions;
using AutoRest.CSharp.Common.Output.Expressions.Statements;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Common.Output.Models;
using AutoRest.CSharp.Common.Output.Models.Types;
using AutoRest.CSharp.Common.Output.Models.Types.HelperTypeProviders;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Output.Builders;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;
using Azure.Core;
using static AutoRest.CSharp.Common.Output.Models.Snippets;

namespace AutoRest.CSharp.Output.Models
{
    internal record ConvenienceMethod(MethodSignature Signature, IReadOnlyList<ProtocolToConvenienceParameterConverter> ProtocolToConvenienceParameterConverters, CSharpType? ResponseType, IReadOnlyList<string>? RequestMediaTypes, IReadOnlyList<string>? ResponseMediaTypes, Diagnostic? Diagnostic, bool IsPageable, bool IsLongRunning, string? Deprecated)
    {
        private record ConvenienceParameterInfo(Parameter? Convenience, ConvenienceParameterSpread? ConvenienceSpread);

        public IEnumerable<MethodBodyStatement> GetConvertStatements(LowLevelClientMethod clientMethod, bool async, FieldDeclaration clientDiagnostics)
        {
            var protocolMethod = clientMethod.ProtocolMethodSignature;
            var parametersDict = ProtocolToConvenienceParameterConverters.ToDictionary(converter => converter.Protocol.Name, converter => new ConvenienceParameterInfo(converter.Convenience, converter.ConvenienceSpread));
            var protocolInvocationExpressions = new List<ValueExpression>();
            VariableReference? content = null;
            bool isMultipartOperation = RequestMediaTypes != null && RequestMediaTypes.Count == 1 && RequestMediaTypes.Contains("multipart/form-data");
            foreach (var protocol in protocolMethod.Parameters)
            {
                var (convenience, convenienceSpread) = parametersDict[protocol.Name];
                if (protocol == KnownParameters.RequestContext || protocol == KnownParameters.RequestContextRequired)
                {
                    // convert cancellationToken to request context
                    // when the protocol needs a request context, we should either convert the cancellationToken to request context, or pass null if required, or do nothing if optional.
                    if (convenience != null)
                    {
                        // meaning we have a cancellationToken, we need to convert it
                        var context = new VariableReference(protocol.Type, protocol.Name);
                        // write: RequestContext context = FromCancellationToken(cancellationToken);
                        yield return Declare(context, new InvokeStaticMethodExpression(null, "FromCancellationToken", new ValueExpression[] { convenience }));
                        protocolInvocationExpressions.Add(context);
                    }
                    else
                    {
                        // if convenience parameter is null here, we just use the default value of the protocol parameter as value (we always do this even if the parameter is optional just in case there is an ordering issue)
                        protocolInvocationExpressions.Add(DefaultOf(protocol.Type));
                    }
                }
                else if (protocol == KnownParameters.RequestContent || protocol == KnownParameters.RequestContentNullable)
                {
                    Debug.Assert(convenience is not null);
                    // convert body to request content
                    if (convenienceSpread == null)
                    {
                        content = new VariableReference(isMultipartOperation ? MultipartFormDataRequestContentProvider.Instance.Type : protocol.Type, protocol.Name);
                        yield return UsingDeclare(content, convenience.GetConversionToProtocol(protocol.Type, RequestMediaTypes?.FirstOrDefault()));
                        protocolInvocationExpressions.Add(content);
                    }
                    else
                    {
                        // write some statements to put the spread back into a local variable
                        yield return GetSpreadConversion(convenienceSpread, convenience, out var spreadExpression);
                        if (isMultipartOperation)
                        {
                            content = new VariableReference(MultipartFormDataRequestContentProvider.Instance.Type, protocol.Name);
                            yield return UsingDeclare(content, spreadExpression.ToMultipartRequestContent());
                            protocolInvocationExpressions.Add(content);
                        }
                        else
                        {
                            protocolInvocationExpressions.Add(spreadExpression.ToRequestContent());
                        }
                    }
                }
                else
                {
                    // process any other parameter
                    if (convenience != null)
                    {
                        // if convenience parameter is not null here, we convert it to protocol parameter value properly
                        var expression = convenience.GetConversionToProtocol(protocol.Type, RequestMediaTypes?.FirstOrDefault());
                        protocolInvocationExpressions.Add(expression);
                    }
                    else
                    {
                        // if convenience parameter is null here, we just use the default value of the protocol parameter as value (we always do this even if the parameter is optional just in case there is an ordering issue)
                        if (isMultipartOperation && protocol.Name == "contentType" && content != null)
                        {
                            protocolInvocationExpressions.Add(MultipartFormDataRequestContentProvider.Instance.ContentTypeProperty(content));
                        }
                        else
                        {
                            protocolInvocationExpressions.Add(DefaultOf(protocol.Type));
                        }
                    }
                }
            }

            // call the protocol method using the expressions we have for the parameters in protocol method
            var invocation = new InvokeInstanceMethodExpression(null, protocolMethod.WithAsync(async), protocolInvocationExpressions);

            // handles the response
            // TODO -- currently we only need to build response handling for long running method and normal method
            if (IsPageable)
                throw new NotImplementedException("Statements for handling pageable convenience method has not been implemented yet");

            if (IsLongRunning)
            {
                if (ResponseType == null)
                {
                    // return [await] protocolMethod(parameters...)[.ConfigureAwait(false)];
                    yield return Return(invocation);
                }
                else
                {
                    // Operation<BinaryData> response = [await] protocolMethod(parameters...)[.ConfigureAwait(false)];
                    var response = new VariableReference(protocolMethod.ReturnType!, Configuration.ApiTypes.ResponseParameterName);
                    yield return Declare(response, invocation);
                    // return ProtocolOperationHelpers.Convert(response, r => responseType.FromResponse(r), ClientDiagnostics, scopeName);
                    var diagnostic = Diagnostic ?? clientMethod.ProtocolMethodDiagnostic;
                    yield return Return(new InvokeStaticMethodExpression(
                        typeof(ProtocolOperationHelpers),
                        nameof(ProtocolOperationHelpers.Convert),
                        new ValueExpression[]
                        {
                            response,
                            GetLongRunningConversionMethod(clientMethod.LongRunningResultRetrievalMethod, ResponseType),
                            clientDiagnostics,
                            Literal(diagnostic.ScopeName)
                        }));
                }
            }
            else
            {
                var response = new VariableReference(protocolMethod.ReturnType!, Configuration.ApiTypes.ResponseParameterName);
                yield return Declare(response, invocation);
                // handle normal responses
                if (ResponseType is null)
                {
                    yield return Return(response);
                }
                else if (ResponseType is { IsFrameworkType: false, Implementation: SerializableObjectType { Serialization.Json: { } } serializableObjectType })
                {
                    yield return Return(Extensible.RestOperations.GetTypedResponseFromModel(serializableObjectType, response));
                }
                else if (ResponseType is { IsFrameworkType: false, Implementation: EnumType enumType })
                {
                    yield return Return(Extensible.RestOperations.GetTypedResponseFromEnum(enumType, response));
                }
                else if (ResponseType.IsCollection)
                {
                    Debug.Assert(clientMethod.ResponseBodyType is not null);
                    var serializationFormat = SerializationBuilder.GetSerializationFormat(clientMethod.ResponseBodyType, ResponseType);
                    var serialization = SerializationBuilder.BuildJsonSerialization(clientMethod.ResponseBodyType, ResponseType, false, serializationFormat);
                    var value = new VariableReference(ResponseType, "value");

                    yield return new[]
                    {
                        Declare(value, Default),
                        JsonSerializationMethodsBuilder.BuildDeserializationForMethods(serialization, async, value, Extensible.RestOperations.GetContentStream(response), false, null),
                        Return(Extensible.RestOperations.GetTypedResponseFromValue(value, response))
                    };
                }
                else if (ResponseType is { IsFrameworkType: true })
                {
                    yield return Return(Extensible.RestOperations.GetTypedResponseFromBinaryData(ResponseType.FrameworkType, response, ResponseMediaTypes?.FirstOrDefault()));
                }
            }
        }

        private ValueExpression GetLongRunningConversionMethod(LongRunningResultRetrievalMethod? convertMethod, CSharpType responseType)
        {
            if (convertMethod is null)
            {
                return new FormattableStringToExpression($"{responseType}.FromResponse");
            }
            return new FormattableStringToExpression($"{convertMethod.MethodSignature.Name}");
        }

        private MethodBodyStatement GetSpreadConversion(ConvenienceParameterSpread convenienceSpread, Parameter convenience, out SerializableObjectTypeExpression spread)
        {
            var backingModel = convenienceSpread.BackingModel;
            var spreadVar = new VariableReference(convenienceSpread.BackingModel.Type, convenience.Name);
            var arguments = new List<ValueExpression>();
            var ctorSignature = backingModel.SerializationConstructor.Signature;
            var parametersDict = convenienceSpread.SpreadedParameters.ToDictionary(p => p.Name);
            foreach (var ctorParameter in ctorSignature.Parameters)
            {
                if (parametersDict.TryGetValue(ctorParameter.Name, out var parameter))
                {
                    // we have a value in the spread parameter list for a ctor parameter
                    ValueExpression expression = new ParameterReference(parameter);
                    if (parameter.Type.IsList)
                    {
                        expression = expression.GetConversion(parameter.Type, ctorParameter.Type);
                        if (parameter.Validation is not ValidationType.AssertNotNull or ValidationType.AssertNotNullOrEmpty)
                        {
                            // we have to add a cast otherwise this will not compile
                            // this could compile: a?.ToList() as IList<string> ?? new ChangeTrackingList<string>()
                            // this will not compile: a?.ToList() ?? new ChangeTrackingList<string>()
                            expression = NullCoalescing(new AsExpression(expression, ctorParameter.Type), New.Instance(parameter.Type.PropertyInitializationType));
                        }
                    }
                    else if (parameter.Type.IsDictionary)
                    {
                        if (parameter.Validation is not ValidationType.AssertNotNull or ValidationType.AssertNotNullOrEmpty)
                        {
                            expression = NullCoalescing(expression, New.Instance(parameter.Type.PropertyInitializationType));
                        }
                    }

                    // add the argument into the list
                    arguments.Add(expression);
                }
                else
                {
                    // we do not have this ctor parameter in the spread parameter list, this should only happen to the raw data field parameter
                    arguments.Add(ctorParameter.Type.IsValueType ? Default.CastTo(ctorParameter.Type) : Null.CastTo(ctorParameter.Type));
                }
            }

            spread = new SerializableObjectTypeExpression(backingModel, spreadVar);
            return Declare(spreadVar, New.Instance(ctorSignature, arguments));
        }
    }

    internal record ProtocolToConvenienceParameterConverter(Parameter Protocol, Parameter? Convenience, ConvenienceParameterSpread? ConvenienceSpread);

    internal record ConvenienceParameterSpread(ModelTypeProvider BackingModel, IReadOnlyList<Parameter> SpreadedParameters);
}

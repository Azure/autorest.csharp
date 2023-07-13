// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Common.Output.Builders;
using AutoRest.CSharp.Common.Output.Models;
using AutoRest.CSharp.Common.Output.Models.KnownValueExpressions;
using AutoRest.CSharp.Common.Output.Models.Responses;
using AutoRest.CSharp.Common.Output.Models.Statements;
using AutoRest.CSharp.Common.Output.Models.Types;
using AutoRest.CSharp.Common.Output.Models.ValueExpressions;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Output.Builders;
using AutoRest.CSharp.Output.Models.Serialization;
using AutoRest.CSharp.Output.Models.Serialization.Json;
using AutoRest.CSharp.Output.Models.Serialization.Xml;
using AutoRest.CSharp.Output.Models.Types;
using Azure;
using Azure.Core;
using static AutoRest.CSharp.Common.Output.Models.Snippets;
using Operation = Azure.Operation;
using StatusCodes = AutoRest.CSharp.Output.Models.Responses.StatusCodes;

namespace AutoRest.CSharp.Output.Models
{
    internal class StatusCodeSwitchBuilder
    {
        private readonly CSharpType? _headerModelType;
        private readonly IReadOnlyList<(CSharpType? Type, ObjectSerialization? Serialization, IReadOnlyList<int> StatusCodes)>? _successResponses;

        public CSharpType? ResponseType { get; }
        public CSharpType ProtocolReturnType { get; }
        public CSharpType RestClientConvenienceReturnType { get; }
        public CSharpType? PageItemType { get; }
        public CSharpType ClientConvenienceReturnType { get; }
        public ResponseClassifierType ResponseClassifier { get; }

        public static StatusCodeSwitchBuilder CreateSwitch(InputOperation operation, OutputLibrary? library, TypeFactory typeFactory)
        {
            var headerModelType = (library as DataPlaneOutputLibrary)?.FindHeaderModel(operation)?.Type;
            var isLro = operation.LongRunning is not null;
            var successStatusCodes = new List<int>();

            var successResponses = new List<(CSharpType? Type, ObjectSerialization? Serialization, IReadOnlyList<int> StatusCodes)>();
            foreach (var (statusCodes, bodyType, bodyMediaType, _, isErrorResponse) in operation.Responses)
            {
                if (isErrorResponse)
                {
                    continue;
                }

                successStatusCodes.AddRange(statusCodes);
                if (bodyType == null)
                {
                    successResponses.Add((null, null, statusCodes));
                }
                else if (bodyMediaType == BodyMediaType.Text)
                {
                    successResponses.Add((typeof(string), null, statusCodes));
                }
                else if (bodyType is InputPrimitiveType { Kind: InputTypeKind.Stream })
                {
                    successResponses.Add((typeof(Stream), null, statusCodes));
                }
                else
                {
                    var responseType = TypeFactory.GetOutputType(typeFactory.CreateType(bodyType));
                    var serialization = SerializationBuilder.Build(bodyMediaType, bodyType, responseType);
                    successResponses.Add((responseType, serialization, statusCodes));
                }
            }

            if (FindResourceDataType(operation, library) is {} resourceDataType && successResponses.Any())
            {
                var responseBodyTypeName = successResponses[0].Type?.Name;
                if (responseBodyTypeName == resourceDataType.Name && operation.Responses.Any(r => r.BodyType is {} type && resourceDataType.EqualsIgnoreNullable(typeFactory.CreateType(type))))
                {
                    successResponses.Add((null, null, new[]{404}));
                }
            }

            successResponses = successResponses
                .GroupBy(r => r.Type)
                .Select(g => (g.Key, g.First().Serialization, (IReadOnlyList<int>)g.SelectMany(r => r.StatusCodes).Distinct().ToArray()))
                .ToList();

            var commonResponseType = successResponses.Count(r => r.Type is not null) switch
            {
                0 => null,
                1 => successResponses.First(r => r.Type is not null).Type,
                _ => typeof(object)
            };

            var pageItemType = GetPageItemType(commonResponseType, operation);

            if (isLro && (Configuration.AzureArm || Configuration.Generation1ConvenienceClient))
            {
                successStatusCodes = operation.Responses
                    .Where(r => !r.IsErrorResponse)
                    .SelectMany(r => r.StatusCodes)
                    .ToList();

                successResponses = new(){ (null, null, successStatusCodes.Distinct().ToList()) };
                commonResponseType = null;
            }

            return new StatusCodeSwitchBuilder
            (
                successResponses,
                headerModelType,
                commonResponseType,
                GetProtocolReturnType(commonResponseType is not null, isLro, operation.Paging is not null),
                GetRestClientConvenienceReturnType(commonResponseType, headerModelType),
                pageItemType,
                GetClientConvenienceReturnType(commonResponseType, pageItemType, isLro),
                new ResponseClassifierType(successStatusCodes.Distinct().Select(c => new StatusCodes(c, null)).OrderBy(c => c.Code))
            );
        }

        public static StatusCodeSwitchBuilder CreateHeadAsBooleanOperationSwitch() => new(null, null, typeof(bool), typeof(Response<bool>), typeof(Response<bool>), null, typeof(Response<bool>), new ResponseClassifierType(new[]{ new StatusCodes(null, 2), new StatusCodes(null, 4) }.OrderBy(c => c.Code)));

        private StatusCodeSwitchBuilder(IReadOnlyList<(CSharpType? Type, ObjectSerialization? Serialization, IReadOnlyList<int> StatusCodes)>? successResponses, CSharpType? headerModelType, CSharpType? responseType, CSharpType protocolReturnType, CSharpType restClientConvenienceReturnType, CSharpType? pageItemType, CSharpType clientConvenienceReturnType, ResponseClassifierType responseClassifier)
        {
            _successResponses = successResponses;
            _headerModelType = headerModelType;

            ResponseType = responseType;
            ProtocolReturnType = protocolReturnType;
            RestClientConvenienceReturnType = restClientConvenienceReturnType;
            PageItemType = pageItemType;
            ClientConvenienceReturnType = clientConvenienceReturnType;
            ResponseClassifier = responseClassifier;
        }

        public StatusCodeSwitchBuilder CreateLroPagingNextPageSwitch()
        {
            var successResponses = new (CSharpType?, ObjectSerialization?, IReadOnlyList<int>)[]{(null, null, new[]{200})};
            var responseClassifierType = new ResponseClassifierType(new[] { new StatusCodes(200, null) }.OrderBy(c => c.Code));

            return new StatusCodeSwitchBuilder(successResponses, _headerModelType, ResponseType, ProtocolReturnType, RestClientConvenienceReturnType, PageItemType, ClientConvenienceReturnType, responseClassifierType);
        }

        public MethodBodyStatement Build(HttpMessageExpression httpMessage, bool async)
        {
            if (_successResponses is null)
            {
                return new SwitchStatement(httpMessage.Response.Status)
                {
                    new(new[]{new FormattableStringToExpression($"int s when s >= 200 && s < 300")}, BuildHeadAsBooleanSwitchCaseStatement(httpMessage, True), AddScope: true),
                    new(new[]{new FormattableStringToExpression($"int s when s >= 400 && s < 500")}, BuildHeadAsBooleanSwitchCaseStatement(httpMessage, False), AddScope: true),
                    SwitchCase.Default(Throw(New.RequestFailedException(httpMessage.Response)))
                };
            }

            if (_headerModelType is null)
            {
                return new SwitchStatement
                (
                    httpMessage.Response.Status,
                    _successResponses
                        .Select(r => new SwitchCase(r.StatusCodes.Select(Int).ToList(), BuildStatusCodeSwitchCaseStatement(r.Type, r.Serialization, httpMessage, async), AddScope: r.Type is not null))
                        .Append(SwitchCase.Default(Throw(New.RequestFailedException(httpMessage.Response))))
                        .ToArray()
                );
            }

            return new MethodBodyStatement[]
            {
                new DeclareVariableStatement(null, "headers", New.Instance(_headerModelType, httpMessage.Response), out var headers),
                new SwitchStatement
                (
                    httpMessage.Response.Status,
                    _successResponses
                        .Select(r => new SwitchCase(r.StatusCodes.Select(Int).ToList(), BuildStatusCodeSwitchCaseStatement(r.Type, r.Serialization, httpMessage, headers, async), AddScope: r.Type is not null))
                        .Append(SwitchCase.Default(Throw(New.RequestFailedException(httpMessage.Response))))
                        .ToArray()
                )
            };
        }

        private static CSharpType? FindResourceDataType(InputOperation operation, OutputLibrary? library)
        {
            if (operation.HttpMethod != RequestMethod.Get)
            {
                return null;
            }

            if (library is not MgmtOutputLibrary mpgLibrary || !mpgLibrary.TryGetResourceData(operation.Path, out var resourceData))
            {
                return null;
            }

            var operationSet = mpgLibrary.GetOperationSet(operation.Path);
            return operationSet.IsResource() ? resourceData.Type : null;
        }

        private static CSharpType GetProtocolReturnType(bool hasResponseType, bool isLro, bool isPageable)
        {
            return (isLro, isPageable) switch
            {
                (true, true) => typeof(Operation<Pageable<BinaryData>>),
                (false, true) => typeof(Pageable<BinaryData>),
                (true, false) => hasResponseType ? typeof(Operation<BinaryData>) : typeof(Operation),
                _ => new CSharpType(typeof(Response))
            };
        }

        private static CSharpType? GetPageItemType(CSharpType? responseType, InputOperation operation)
        {
            if (operation.Paging is not {} paging)
            {
                return null;
            }

            if (responseType is null)
            {
                throw new InvalidOperationException($"Method {operation.Name} is pageable and has to have a return value");
            }

            if (responseType.IsFrameworkType || responseType.Implementation is not SerializableObjectType modelType)
            {
                return TypeFactory.IsList(responseType) ? TypeFactory.GetElementType(responseType) : responseType;
            }

            var property = modelType.GetPropertyBySerializedName(paging.ItemName ?? "value");
            var propertyType = property.ValueType.WithNullable(false);
            if (!TypeFactory.IsList(propertyType))
            {
                throw new InvalidOperationException($"'{modelType.Declaration.Name}.{property.Declaration.Name}' property must be a collection of items");
            }

            return TypeFactory.GetElementType(property.ValueType);
        }

        private static CSharpType GetRestClientConvenienceReturnType(CSharpType? responseType, CSharpType? headerModelType)
        {
            return (responseType, headerModelType) switch
            {
                (not null, not null) => new CSharpType(typeof(ResponseWithHeaders<,>), responseType, headerModelType),
                (not null, null) => new CSharpType(typeof(Response<>), responseType),
                (null, not null) => new CSharpType(typeof(ResponseWithHeaders<>), headerModelType),
                _ => new CSharpType(typeof(Response))
            };
        }

        private static CSharpType GetClientConvenienceReturnType(CSharpType? responseType, CSharpType? pageItemType, bool isLro)
        {
            return (isLro, pageItemType) switch
            {
                (true, not null) => new(typeof(Operation<>), new CSharpType(typeof(Pageable<>), pageItemType)),
                (false, not null) => new(typeof(Pageable<>), pageItemType),
                (true, null) => responseType is not null ? new CSharpType(typeof(Operation<>), responseType) : typeof(Operation),
                _ => responseType is not null ? new CSharpType(typeof(Response<>), responseType) : new CSharpType(typeof(Azure.Response))
            };
        }

        private static MethodBodyStatement BuildHeadAsBooleanSwitchCaseStatement(HttpMessageExpression httpMessage, BoolExpression valueConstant)
        {
            return new MethodBodyStatement[]
            {
                new DeclareVariableStatement(typeof(bool), "value", valueConstant, out var value),
                Return(ResponseExpression.FromValue(value, httpMessage.Response))
            };
        }

        private MethodBodyStatement BuildStatusCodeSwitchCaseStatement(CSharpType? type, ObjectSerialization? serialization, HttpMessageExpression httpMessage, bool async)
        {
            if (type is null)
            {
                return ResponseType != null
                    ? Return(ResponseExpression.FromValue(new CastExpression(Null, ResponseType), httpMessage.Response))
                    : Return(httpMessage.Response);
            }

            var valueStatement = BuildStatusCodeSwitchCaseValueStatement(type, serialization, httpMessage, async, out ValueExpression value);

            var returnStatement = ResponseType is not null && !ResponseType.EqualsIgnoreNullable(type)
                ? Return(ResponseExpression.FromValue(ResponseType, value, httpMessage.Response))
                : Return(ResponseExpression.FromValue(value, httpMessage.Response));

            return new[] { valueStatement, returnStatement };
        }

        private MethodBodyStatement BuildStatusCodeSwitchCaseStatement(CSharpType? type, ObjectSerialization? serialization, HttpMessageExpression httpMessage, ValueExpression headers, bool async)
        {
            if (type is null)
            {
                return ResponseType != null
                    ? Return(ResponseWithHeadersExpression.FromValue(new CastExpression(Null, ResponseType), headers, httpMessage.Response))
                    : Return(ResponseWithHeadersExpression.FromValue(headers, httpMessage.Response));
            }

            var valueStatement = BuildStatusCodeSwitchCaseValueStatement(type, serialization, httpMessage, async, out ValueExpression value);

            var returnStatement = ResponseType is not null && !ResponseType.EqualsIgnoreNullable(type)
                    ? Return(ResponseWithHeadersExpression.FromValue(ResponseType, value, headers, httpMessage.Response))
                    : Return(ResponseWithHeadersExpression.FromValue(value, headers, httpMessage.Response));

            return new[] { valueStatement, returnStatement };
        }

        private static MethodBodyStatement BuildStatusCodeSwitchCaseValueStatement(CSharpType type, ObjectSerialization? serialization, HttpMessageExpression httpMessage, bool async, out ValueExpression value)
        {
            if (serialization is not null)
            {
                return new[]
                {
                    new DeclareVariableStatement(type, "value", Snippets.Default, out value),
                    serialization switch
                    {
                        JsonSerialization jsonSerialization => JsonSerializationMethodsBuilder.BuildDeserializationForMethods(jsonSerialization, async, value, httpMessage.Response, type.Equals(typeof(BinaryData))),
                        XmlElementSerialization xmlSerialization => XmlSerializationMethodsBuilder.BuildDeserializationForMethods(xmlSerialization, value, httpMessage.Response).AsStatement(),
                        _ => throw new NotImplementedException(serialization?.ToString() ?? $"No serialization for type {type}")
                    }
                };
            }

            if (type.Equals(typeof(Stream)))
            {
                return new DeclareVariableStatement(null, "value", httpMessage.ExtractResponseContent(), out value);
            }

            if (type.Equals(typeof(string)))
            {
                return new[]
                {
                    Declare("streamReader", New.StreamReader(httpMessage.Response.ContentStream), out StreamReaderExpression streamReader),
                    new DeclareVariableStatement(type, "value", streamReader.ReadToEnd(async), out value)
                };
            }

            throw new InvalidOperationException();
        }
    }
}

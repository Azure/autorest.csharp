// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions;
using AutoRest.CSharp.Common.Output.Expressions.Statements;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Common.Output.Models;
using AutoRest.CSharp.Common.Output.Models.Responses;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Output.Builders;
using AutoRest.CSharp.Output.Models.Serialization;
using AutoRest.CSharp.Output.Models.Serialization.Json;
using AutoRest.CSharp.Output.Models.Serialization.Xml;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Utilities;
using Azure;
using Azure.Core;
using static AutoRest.CSharp.Common.Output.Models.Snippets;
using Operation = Azure.Operation;
using StatusCodes = AutoRest.CSharp.Output.Models.Responses.StatusCodes;

namespace AutoRest.CSharp.Common.Output.Builders
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

            var successInputResponses = new List<(InputType? Type, BodyMediaType? BodyMediaType, IEnumerable<int> StatusCodes)>();
            foreach (var (statusCodes, bodyType, bodyMediaType, _, isErrorResponse) in operation.Responses)
            {
                if (isErrorResponse)
                {
                    continue;
                }

                successStatusCodes.AddRange(statusCodes);
                if (bodyType == null)
                {
                    successInputResponses.Add((null, null, statusCodes));
                }
                else if (bodyMediaType == BodyMediaType.Text)
                {
                    successInputResponses.Add((InputPrimitiveType.String, null, statusCodes));
                }
                else if (bodyType is InputPrimitiveType { Kind: InputTypeKind.Stream } streamInputType)
                {
                    successInputResponses.Add((streamInputType, null, statusCodes));
                }
                else
                {
                    successInputResponses.Add((bodyType, bodyMediaType, statusCodes));
                }
            }

            if (FindResourceDataType(operation, library) is {} resourceDataType)
            {
                if (successInputResponses.Select(r => r.Type).WhereNotNull().Any(type => resourceDataType.EqualsIgnoreNullable(typeFactory.CreateType(type))))
                {
                    successInputResponses.Add((null, successInputResponses[0].BodyMediaType, new[]{404}));
                }
            }

            successInputResponses = successInputResponses
                .GroupBy(r => r.Type)
                .Select(g => (g.Key, g.First().BodyMediaType, g.SelectMany(r => r.StatusCodes).Distinct()))
                .ToList();

            var commonResponseInputType = successInputResponses.Count(r => r.Type is not null) switch
            {
                0 => null,
                1 => successInputResponses.First(r => r.Type is not null).Type,
                _ => InputPrimitiveType.Object
            };

            var pageItemInputType = GetPageItemType(commonResponseInputType, operation);

            if (isLro && (Configuration.AzureArm || Configuration.Generation1ConvenienceClient))
            {
                successStatusCodes = operation.Responses
                    .Where(r => !r.IsErrorResponse)
                    .SelectMany(r => r.StatusCodes)
                    .ToList();

                successInputResponses = new(){ (null, BodyMediaType.None, successStatusCodes.Distinct().ToList()) };
                commonResponseInputType = null;
            }

            var commonResponseType = commonResponseInputType is null
                ? null
                : TypeFactory.GetOutputType(typeFactory.CreateType(commonResponseInputType));
            var pageItemType = pageItemInputType is null
                ? null
                : TypeFactory.GetOutputType(typeFactory.CreateType(pageItemInputType));

            var successResponses = new List<(CSharpType? Type, ObjectSerialization? Serialization, IReadOnlyList<int> StatusCodes)>();
            foreach (var (inputType, bodyMediaType, statusCodes) in successInputResponses)
            {
                if (inputType is null)
                {
                    successResponses.Add((null, null, statusCodes.ToList()));
                }
                else
                {
                    var type = TypeFactory.GetOutputType(typeFactory.CreateType(inputType));
                    var serialization = bodyMediaType.HasValue ? SerializationBuilder.Build(bodyMediaType.Value, inputType, type) : null;
                    successResponses.Add((type, serialization, statusCodes.ToList()));
                }
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

            var headers = new VariableReference(_headerModelType, "headers");
            return new MethodBodyStatement[]
            {
                new DeclareVariableStatement(null, headers.Declaration, New.Instance(_headerModelType, httpMessage.Response)),
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

        private static InputType? GetPageItemType(InputType? responseType, InputOperation operation)
        {
            if (operation.Paging is not {} paging)
            {
                return null;
            }

            if (responseType is null)
            {
                throw new InvalidOperationException($"Method {operation.Name} is pageable and has to have a return value");
            }

            if (responseType is InputListType listType)
            {
                return listType.ElementType;
            }

            if (responseType is not InputModelType modelType)
            {
                return responseType;
            }

            var itemName = paging.ItemName ?? "value";
            if (modelType.Properties.FirstOrDefault(p => p.SerializedName == itemName) is not {} property)
            {
                return null;
            }

            if (property.Type is not InputListType listPropertyType)
            {
                throw new InvalidOperationException($"'{modelType.Name}.{property.Name}' property must be a collection of items");
            }

            return listPropertyType.ElementType;

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
                Declare("value", valueConstant, out var value),
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
                        XmlElementSerialization xmlSerialization => XmlSerializationMethodsBuilder.BuildDeserializationForMethods(xmlSerialization, value, httpMessage.Response),
                        _ => throw new NotImplementedException(serialization?.ToString() ?? $"No serialization for type {type}")
                    }
                };
            }

            if (type.Equals(typeof(Stream)))
            {
                return Var("value", httpMessage.ExtractResponseContent(), out value);
            }

            if (type.Equals(typeof(string)))
            {
                return new[]
                {
                    Declare("streamReader", New.StreamReader(httpMessage.Response.ContentStream), out StreamReaderExpression streamReader),
                    Declare("value", streamReader.ReadToEnd(async), out value)
                };
            }

            throw new InvalidOperationException();
        }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions;
using AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions.Azure;
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
            var successInputResponses = GetNonLroSuccessInputResponses(operation, library, typeFactory);
            var commonResponseInputType = successInputResponses.Count(r => r.Type is not null) switch
            {
                0 => null,
                1 => successInputResponses.First(r => r.Type is not null).Type,
                _ => InputPrimitiveType.Object
            };

            var pageItemInputType = GetPageItemType(commonResponseInputType, operation);
            if (operation.LongRunning is { } lro)
            {
                var response = GetLroSuccessInputResponse(operation, lro);
                successInputResponses = new[] { response };
                commonResponseInputType = response.Type;
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

            var headerModelType = (library as DataPlaneOutputLibrary)?.FindHeaderModel(operation)?.Type;

            return new StatusCodeSwitchBuilder
            (
                successResponses,
                headerModelType,
                commonResponseType,
                GetProtocolReturnType(commonResponseType is not null, operation.LongRunning is not null, operation.Paging is not null),
                GetRestClientConvenienceReturnType(commonResponseType, headerModelType),
                pageItemType,
                GetClientConvenienceReturnType(commonResponseType, pageItemType, operation.LongRunning is not null),
                new ResponseClassifierType(successInputResponses.SelectMany(s => s.StatusCodes).Distinct().Select(c => new StatusCodes(c, null)).OrderBy(c => c.Code))
            );
        }

        private static (InputType? Type, BodyMediaType? BodyMediaType, IEnumerable<int> StatusCodes) GetLroSuccessInputResponse(InputOperation operation, OperationLongRunning lro)
        {
            var successStatusCodes = operation.Responses
                .Where(r => !r.IsErrorResponse)
                .SelectMany(r => r.StatusCodes);

            if (Configuration.AzureArm || Configuration.Generation1ConvenienceClient)
            {
                return (null, BodyMediaType.None, successStatusCodes.Distinct().ToList());
            }

            //[TODO]: Should we include status codes from FinalResponse?
            //if (!lro.FinalResponse.IsErrorResponse)
            //{
            //    successStatusCodes = successStatusCodes.Concat(lro.FinalResponse.StatusCodes);
            //}
            return (lro.FinalResponse.BodyType, lro.FinalResponse.BodyMediaType, successStatusCodes.Distinct().ToList());
        }

        private static IReadOnlyList<(InputType? Type, BodyMediaType? BodyMediaType, IEnumerable<int> StatusCodes)> GetNonLroSuccessInputResponses(InputOperation operation, OutputLibrary? library, TypeFactory typeFactory)
        {
            var successInputResponses = new List<(InputType? Type, BodyMediaType? BodyMediaType, IEnumerable<int> StatusCodes)>();
            foreach (var (statusCodes, bodyType, bodyMediaType, _, isErrorResponse) in operation.Responses)
            {
                if (isErrorResponse)
                {
                    continue;
                }

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

            return successInputResponses;
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
            if (_successResponses is [{StatusCodes: {} statusCodes, Type: {} type} _] && type.Equals(typeof(Stream)))
            {
                return new SwitchStatement
                (
                    httpMessage.Response.Status,
                    new[]
                    {
                        new(statusCodes.Select(Int).ToList(), new MethodBodyStatement[]
                        {
                            Var("value", httpMessage.ExtractResponseContent(), out var value),
                            Return(ResponseExpression.FromValue(value, httpMessage.Response))
                        }, AddScope: true),
                        SwitchCase.Default(Throw(New.RequestFailedException(httpMessage.Response)))
                    }
                );
            }

            return Build(httpMessage.Response, async);
        }

        public MethodBodyStatement Build(ResponseExpression response, bool async)
        {
            if (_successResponses is null)
            {
                return new SwitchStatement(response.Status)
                {
                    new(new[]{new FormattableStringToExpression($"int s when s >= 200 && s < 300")}, BuildHeadAsBooleanSwitchCaseStatement(response, True), AddScope: true),
                    new(new[]{new FormattableStringToExpression($"int s when s >= 400 && s < 500")}, BuildHeadAsBooleanSwitchCaseStatement(response, False), AddScope: true),
                    SwitchCase.Default(Throw(New.RequestFailedException(response)))
                };
            }

            if (_headerModelType is null)
            {
                return new SwitchStatement
                (
                    response.Status,
                    _successResponses
                        .Select(r => new SwitchCase(r.StatusCodes.Select(Int).ToList(), BuildStatusCodeSwitchCaseStatement(r.Type, r.Serialization, response, async), AddScope: r.Type is not null))
                        .Append(SwitchCase.Default(Throw(New.RequestFailedException(response))))
                        .ToArray()
                );
            }

            var headers = new VariableReference(_headerModelType, "headers");
            return new MethodBodyStatement[]
            {
                new DeclareVariableStatement(null, headers.Declaration, New.Instance(_headerModelType, response)),
                new SwitchStatement
                (
                    response.Status,
                    _successResponses
                        .Select(r => new SwitchCase(r.StatusCodes.Select(Int).ToList(), BuildStatusCodeSwitchCaseStatement(r.Type, r.Serialization, response, headers, async), AddScope: r.Type is not null))
                        .Append(SwitchCase.Default(Throw(New.RequestFailedException(response))))
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

        private static MethodBodyStatement BuildHeadAsBooleanSwitchCaseStatement(ResponseExpression response, BoolExpression valueConstant)
        {
            return new MethodBodyStatement[]
            {
                Declare("value", valueConstant, out var value),
                Return(ResponseExpression.FromValue(value, response))
            };
        }

        private MethodBodyStatement BuildStatusCodeSwitchCaseStatement(CSharpType? type, ObjectSerialization? serialization, ResponseExpression response, bool async)
        {
            if (type is null)
            {
                return ResponseType != null
                    ? Return(ResponseExpression.FromValue(new CastExpression(Null, ResponseType), response))
                    : Return(response);
            }

            var valueStatement = BuildStatusCodeSwitchCaseValueStatement(type, serialization, response, async, out TypedValueExpression value);

            var returnStatement = ResponseType is not null && !ResponseType.EqualsIgnoreNullable(type)
                ? Return(ResponseExpression.FromValue(ResponseType, value, response))
                : Return(ResponseExpression.FromValue(value, response));

            return new[] { valueStatement, returnStatement };
        }

        private MethodBodyStatement BuildStatusCodeSwitchCaseStatement(CSharpType? type, ObjectSerialization? serialization, ResponseExpression response, ValueExpression headers, bool async)
        {
            if (type is null)
            {
                return ResponseType != null
                    ? Return(ResponseWithHeadersExpression.FromValue(new CastExpression(Null, ResponseType), headers, response))
                    : Return(ResponseWithHeadersExpression.FromValue(headers, response));
            }

            var valueStatement = BuildStatusCodeSwitchCaseValueStatement(type, serialization, response, async, out TypedValueExpression value);

            var returnStatement = ResponseType is not null && !ResponseType.EqualsIgnoreNullable(type)
                    ? Return(ResponseWithHeadersExpression.FromValue(ResponseType, value, headers, response))
                    : Return(ResponseWithHeadersExpression.FromValue(value, headers, response));

            return new[] { valueStatement, returnStatement };
        }

        private static MethodBodyStatement BuildStatusCodeSwitchCaseValueStatement(CSharpType type, ObjectSerialization? serialization, ResponseExpression response, bool async, out TypedValueExpression value)
        {
            if (serialization is not null)
            {
                return new[]
                {
                    Declare(type, "value", Snippets.Default, out value),
                    serialization switch
                    {
                        JsonSerialization jsonSerialization => JsonSerializationMethodsBuilder.BuildDeserializationForMethods(jsonSerialization, async, value, response, type.Equals(typeof(BinaryData))),
                        XmlElementSerialization xmlSerialization => XmlSerializationMethodsBuilder.BuildDeserializationForMethods(xmlSerialization, value, response),
                        _ => throw new NotImplementedException(serialization?.ToString() ?? $"No serialization for type {type}")
                    }
                };
            }

            if (type.Equals(typeof(Stream)))
            {
                throw new InvalidOperationException("Stream not supported");
            }

            if (type.Equals(typeof(string)))
            {
                return new[]
                {
                    Declare("streamReader", New.StreamReader(response.ContentStream), out StreamReaderExpression streamReader),
                    Declare("value", streamReader.ReadToEnd(async), out value)
                };
            }

            throw new InvalidOperationException();
        }
    }
}

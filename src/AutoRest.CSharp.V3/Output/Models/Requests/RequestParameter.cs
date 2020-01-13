// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using AutoRest.CSharp.V3.Output.Models.Shared;
using AutoRest.CSharp.V3.Output.Models.TypeReferences;

namespace AutoRest.CSharp.V3.Output.Models.Requests
{
    internal struct RequestParameter
    {
        private readonly Constant? _constant;
        private readonly Parameter? _parameter;

        public RequestParameter(Constant constant)
        {
            Type = constant.Type;
            _constant = constant;
            _parameter = null;
        }

        public RequestParameter(Parameter parameter)
        {
            Type = parameter.Type;
            _parameter = parameter;
            _constant = null;
        }

        public TypeReference Type { get; }
        public bool IsConstant => _constant.HasValue;

        public Constant Constant => _constant ?? throw new InvalidOperationException("Not a constant");
        public Parameter Parameter => _parameter ?? throw new InvalidOperationException("Not a parameter");

        public static implicit operator RequestParameter(Constant constant) => new RequestParameter(constant);
        public static implicit operator RequestParameter(Parameter parameter) => new RequestParameter(parameter);
    }
}

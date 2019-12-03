// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;

namespace AutoRest.CSharp.V3.ClientModel
{
    internal struct ConstantOrParameter
    {
        private readonly ClientConstant? _constant;
        private readonly ServiceClientMethodParameter? _parameter;

        public ConstantOrParameter(ClientConstant constant)
        {
            _constant = constant;
            _parameter = null;
        }

        public ConstantOrParameter(ServiceClientMethodParameter parameter)
        {
            _parameter = parameter;
            _constant = null;
        }

        public bool IsConstant => _constant.HasValue;

        public ClientConstant Constant => _constant ?? throw new InvalidOperationException("Not a constant");
        public ServiceClientMethodParameter Parameter => _parameter ?? throw new InvalidOperationException("Not a parameter");

        public static implicit operator ConstantOrParameter(ClientConstant constant) => new ConstantOrParameter(constant);
        public static implicit operator ConstantOrParameter(ServiceClientMethodParameter parameter) => new ConstantOrParameter(parameter);
    }
}

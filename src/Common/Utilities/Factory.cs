// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// 

using System;

namespace AutoRest.Core.Utilities
{
    public class Factory
    {
        private readonly Type _targetType;

        protected internal Factory(Type t)
        {
            _targetType = t;
        }
    }
}
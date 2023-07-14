// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoRest.CSharp.Input;

namespace AutoRest.CSharp.Common.Decorator
{
    internal class EliminateClientDefaultValueTransformer
    {
        public static void Transform(CodeModel codeModel)
        {
            foreach (var schema in codeModel.AllSchemas.OfType<ObjectSchema>())
            {
                foreach (var property in schema.Properties)
                {
                    /* eliminate the client default value of modle property */
                    property.ClientDefaultValue = null;
                }
            }
        }

    }
}

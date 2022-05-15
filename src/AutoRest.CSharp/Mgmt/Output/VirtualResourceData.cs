// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Text;
using AutoRest.CSharp.Input;

namespace AutoRest.CSharp.Mgmt.Output
{
    internal class VirtualResourceData : ResourceData
    {
        private static ObjectSchema GetEmptyObjectSchemaWithName(string name)
        {
            return new ObjectSchema
            {
                Language = new Languages
                {
                    Default = new Language
                    {
                        Name = name,
                    }
                }
            };
        }

        public VirtualResourceData(string name) : base(GetEmptyObjectSchemaWithName(name))
        {
        }
    }
}

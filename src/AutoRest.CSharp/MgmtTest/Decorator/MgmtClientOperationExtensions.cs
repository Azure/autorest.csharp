// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Models;
using AutoRest.CSharp.Output.Models.Types;

namespace AutoRest.CSharp.MgmtTest.Decorator
{
    internal static class MgmtClientOperationExtensions
    {
        public static SortedDictionary<RequestPath, MgmtRestOperation> GetSortedOperationMappings(this MgmtClientOperation clientOperation)
        {
            var dict = new SortedDictionary<RequestPath, MgmtRestOperation>(Comparer<RequestPath>.Create(
                (x1, x2) =>
                {
                    // order by path length descendently
                    var str1 = x1.ToString();
                    var str2 = x2.ToString();
                    if (str1 is null)
                    {
                        return 1;
                    }

                    if (str2 is null)
                    {
                        return -1;
                    }

                    return str2.Length - str1.Length;
                }));
            foreach ((var key, var value) in clientOperation.OperationMappings)
            {
                dict.Add(key, value);
            }
            return dict;
        }

        public static bool HasExample(this MgmtClientOperation clientOperation, BuildContext<MgmtOutputLibrary> context)
        {
            foreach ((var branch, var operation) in clientOperation.GetSortedOperationMappings())
            {
                var exampleGroup = operation.FindExampleGroup(context);
                if (exampleGroup is not null && exampleGroup.Examples.Count > 0)
                    return true;
                break;
            }
            return false;
        }
    }
}

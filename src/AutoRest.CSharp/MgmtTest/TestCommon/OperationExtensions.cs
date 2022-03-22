// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Diagnostics.CodeAnalysis;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.Output;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Models;

namespace AutoRest.CSharp.MgmtTest.TestCommon
{
    internal static class OperationExtensions
    {
        public static bool IsCollectionOperation(this Operation operation, [MaybeNullWhen(false)] out ResourceCollection collection, [MaybeNullWhen(false)] out MgmtClientOperation clientOperation, [MaybeNullWhen(false)] out MgmtRestOperation restOperation)
        {
            collection = null;
            clientOperation = null;
            restOperation = null;
            foreach (var c in MgmtContext.Library.ResourceCollections)
            {
                foreach (var co in c.AllOperations)
                {
                    foreach (var ro in co)
                    {
                        if (ro.Operation == operation)
                        {
                            collection = c;
                            clientOperation = co;
                            restOperation = ro;
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public static bool IsResourceOperation(this Operation operation, [MaybeNullWhen(false)] out Resource resource, [MaybeNullWhen(false)] out MgmtClientOperation clientOperation, [MaybeNullWhen(false)] out MgmtRestOperation restOperation)
        {
            resource = null;
            clientOperation = null;
            restOperation = null;
            foreach (var r in MgmtContext.Library.ArmResources)
            {
                foreach (var co in r.AllOperations)
                {
                    foreach (var ro in co)
                    {
                        if (ro.Operation == operation)
                        {
                            resource = r;
                            clientOperation = co;
                            restOperation = ro;
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public static bool IsSubscriptionOperation(this Operation operation, [MaybeNullWhen(false)] out MgmtClientOperation clientOperation, [MaybeNullWhen(false)] out MgmtRestOperation restOperation)
        {
            clientOperation = null;
            restOperation = null;
            foreach (var co in MgmtContext.Library.SubscriptionExtensions.ClientOperations)
            {
                foreach (var ro in co)
                {
                    if (ro.Operation == operation)
                    {
                        clientOperation = co;
                        restOperation = ro;
                        return true;
                    }
                }
            }
            return false;
        }
    }
}

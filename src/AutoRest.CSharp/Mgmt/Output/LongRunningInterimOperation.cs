// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Mgmt.AutoRest;
using Azure;
using Azure.Core;
using Azure.ResourceManager;

namespace AutoRest.CSharp.Mgmt.Output
{
    internal class LongRunningInterimOperation
    {
        public LongRunningInterimOperation(CSharpType returnType, string methodName)
        {
            ReturnType = returnType;
            BaseClassType = new CSharpType(typeof(ArmOperation<>), returnType);
            IOperationSourceType = new CSharpType(typeof(IOperationSource<>), returnType);
            StateLockType = new CSharpType(typeof(AsyncLockWithValue<>), returnType);
            ValueTaskType = new CSharpType(typeof(ValueTask<>), returnType);
            ResponseType = new CSharpType(typeof(Response<>), returnType);
            OperationType = $"{MgmtContext.Context.DefaultNamespace.Split('.').Last()}ArmOperation<{returnType.Name}>";
            var returnTypeName = returnType.Name;
            if (returnTypeName.EndsWith("Resource"))
            {
                returnTypeName = returnTypeName.Substring(0, returnTypeName.Length - "Resource".Length);
            }
            else if (returnTypeName.EndsWith("Data"))
            {
                returnTypeName = returnTypeName.Substring(0, returnTypeName.Length - "Data".Length);
            }
            TypeName = $"{returnTypeName}{methodName}Operation";
            var targetSchema = new ObjectSchema()
            {
                Language = new Languages()
                {
                    Default = new Language()
                    {
                        Name = TypeName,
                        Namespace = MgmtContext.Context.DefaultNamespace
                    }
                }
            };
            InterimType = new CSharpType(new MgmtObjectType(targetSchema), MgmtContext.Context.DefaultNamespace, TypeName);
        }

        public CSharpType ReturnType { get; }

        public CSharpType BaseClassType { get; }

        public CSharpType IOperationSourceType { get; }

        public CSharpType StateLockType { get; }

        public CSharpType ValueTaskType { get; }

        public CSharpType ResponseType { get; }

        public CSharpType InterimType { get; }

        public string TypeName { get; }

        public string OperationType { get; }

        public static IEqualityComparer<LongRunningInterimOperation> LongRunningInterimOperationComparer { get; } = new LongRunningInterimOperationComparerImplementation();

        private class LongRunningInterimOperationComparerImplementation : IEqualityComparer<LongRunningInterimOperation>
        {
            public bool Equals(LongRunningInterimOperation? x, LongRunningInterimOperation? y)
            {
                if (x is null || y is null)
                {
                    return ReferenceEquals(x, y);
                }

                return x.TypeName == y.TypeName;
            }

            public int GetHashCode(LongRunningInterimOperation obj)
            {

                var hashCode = new HashCode();
                hashCode.Add(obj.TypeName);

                return hashCode.ToHashCode();
            }
        }
    }
}

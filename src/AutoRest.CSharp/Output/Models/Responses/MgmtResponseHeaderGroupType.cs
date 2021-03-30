// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Output.Builders;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Utilities;

namespace AutoRest.CSharp.Output.Models.Responses
{
    internal class MgmtResponseHeaderGroupType: ResponseHeaderGroupType
    {
        private readonly BuildContext<MgmtOutputLibrary> _context;

        public MgmtResponseHeaderGroupType(OperationGroup operationGroup, Operation operation, HttpResponseHeader[] httpResponseHeaders, BuildContext<MgmtOutputLibrary> context)
            : base(operation, httpResponseHeaders, context.Library.FindRestClient(operationGroup).ClientPrefix, context)
        {
            _context = context;
        }

        public static MgmtResponseHeaderGroupType? TryCreate(OperationGroup operationGroup, Operation operation, BuildContext<MgmtOutputLibrary> context)
        {
            var httpResponseHeaders = operation.Responses.SelectMany(r => r.HttpResponse.Headers)
                .Where(h => !_knownResponseHeaders.Contains(h.Header, StringComparer.InvariantCultureIgnoreCase))
                .GroupBy(h => h.Header)
                // Take first header definition with any particular name
                .Select(h => h.First())
                .ToArray();

            if (!httpResponseHeaders.Any())
            {
                return null;
            }

            return new MgmtResponseHeaderGroupType(operationGroup, operation, httpResponseHeaders, context);
        }

        protected override CSharpType GetCsharpType(Schema schema, bool isNullable)
        {
            return _context.TypeFactory.CreateType(schema, isNullable);
        }
    }
}

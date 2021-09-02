// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Output.Models.Requests;

namespace AutoRest.CSharp.Mgmt.Models
{
    internal class RequestPath
    {
        private IReadOnlyList<Segment> segments;

        public RequestPath(RestClientMethod method)
        {
            segments = new List<Segment>();
            Init(method);
        }

        public bool IsChildOf(RequestPath other)
        {
            // TODO
            return false;
        }

        private void Init(RestClientMethod method)
        {
            var httpRequest = method.GetHttpRequest();
            if (httpRequest == null)
                throw new InvalidOperationException($"Cannot take http request from method {method.Name} from {method.Operation.Language.Default.SerializedName}");
            var path = httpRequest.Path;
            var segments = path.Split('/', StringSplitOptions.RemoveEmptyEntries).Select(s => new Segment(s));
        }
    }
}

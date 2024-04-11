using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;

namespace AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions
{
    internal sealed record HttpContentHeadersExpression(ValueExpression Untyped) : TypedValueExpression<HttpContentHeaders>(Untyped)
    {
        public ValueExpression ContentType => Property(nameof(HttpContentHeaders.ContentType), true);
    }
}

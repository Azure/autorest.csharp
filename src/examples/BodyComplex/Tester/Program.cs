using System;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Identity;
using BodyComplex.Operations;

namespace Tester
{
    class Program
    {
        static void Main(string[] args)
        {
            var uri = new Uri("http://localhost:3000/complex/basic/valid");
            var pipeline = HttpPipelineBuilder.Build(new DefaultAzureCredentialOptions());
            var result = BasicOperations.GetValidAsync(uri, pipeline).GetAwaiter().GetResult();
        }
    }
}

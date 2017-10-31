namespace Fixtures.AcceptanceTestsHiddenMethods
{
    using Microsoft.Rest;
    using Models;
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using System.Net;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// BasicOperations operations.
    /// </summary>
    public partial class BasicOperations : IBasicOperations
    {
        public async Task PutValidAsync(string name, string color, int? id = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            await (WithHttpMessages() as BasicOperationsWithHttpMessages).PutValidAsync(new Basic { Id = id, Name = name, Color = color }, customHeaders, cancellationToken);
        }
    }
}
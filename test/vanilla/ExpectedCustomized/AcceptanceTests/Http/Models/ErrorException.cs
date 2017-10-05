namespace Fixtures.AcceptanceTestsHttp.Models
{
    using Microsoft.Rest;

    /// <summary>
    /// Exception thrown for an invalid response with Error information.
    /// </summary>
    public partial class ErrorException : RestException
    {
        public const string StringFromPartial = "StringFromPartial";
    }
}
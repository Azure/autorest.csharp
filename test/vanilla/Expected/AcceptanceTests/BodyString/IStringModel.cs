// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
// </auto-generated>

namespace Fixtures.AcceptanceTestsBodyString
{
    using Models;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// StringModel operations.
    /// </summary>
    public partial interface IStringModel
    {
        IStringModelWithHttpMessages WithHttpMessages();

        /// <summary>
        /// Get null string value value
        /// </summary>
        string GetNull();

        /// <summary>
        /// Get null string value value
        /// </summary>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<string> GetNullAsync(CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Set string value null
        /// </summary>
        /// <param name='stringBody'>
        /// Possible values include: ''
        /// </param>
        void PutNull(string stringBody = default(string));

        /// <summary>
        /// Set string value null
        /// </summary>
        /// <param name='stringBody'>
        /// Possible values include: ''
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task PutNullAsync(string stringBody = default(string), CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Get empty string value value ''
        /// </summary>
        string GetEmpty();

        /// <summary>
        /// Get empty string value value ''
        /// </summary>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<string> GetEmptyAsync(CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Set string value empty ''
        /// </summary>
        /// <param name='stringBody'>
        /// Possible values include: ''
        /// </param>
        void PutEmpty(string stringBody);

        /// <summary>
        /// Set string value empty ''
        /// </summary>
        /// <param name='stringBody'>
        /// Possible values include: ''
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task PutEmptyAsync(string stringBody, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Get mbcs string value '啊齄丂狛狜隣郎隣兀﨩ˊ▇█〞〡￤℡㈱‐ー﹡﹢﹫、〓ⅰⅹ⒈€㈠㈩ⅠⅫ！￣ぁんァヶΑ︴АЯаяāɡㄅㄩ─╋︵﹄︻︱︳︴ⅰⅹɑɡ〇〾⿻⺁䜣€ '
        /// </summary>
        string GetMbcs();

        /// <summary>
        /// Get mbcs string value '啊齄丂狛狜隣郎隣兀﨩ˊ▇█〞〡￤℡㈱‐ー﹡﹢﹫、〓ⅰⅹ⒈€㈠㈩ⅠⅫ！￣ぁんァヶΑ︴АЯаяāɡㄅㄩ─╋︵﹄︻︱︳︴ⅰⅹɑɡ〇〾⿻⺁䜣€ '
        /// </summary>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<string> GetMbcsAsync(CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Set string value mbcs '啊齄丂狛狜隣郎隣兀﨩ˊ▇█〞〡￤℡㈱‐ー﹡﹢﹫、〓ⅰⅹ⒈€㈠㈩ⅠⅫ！￣ぁんァヶΑ︴АЯаяāɡㄅㄩ─╋︵﹄︻︱︳︴ⅰⅹɑɡ〇〾⿻⺁䜣€ '
        /// </summary>
        /// <param name='stringBody'>
        /// Possible values include: '啊齄丂狛狜隣郎隣兀﨩ˊ▇█〞〡￤℡㈱‐ー﹡﹢﹫、〓ⅰⅹ⒈€㈠㈩ⅠⅫ！￣ぁんァヶΑ︴АЯаяāɡㄅㄩ─╋︵﹄︻︱︳︴ⅰⅹɑɡ〇〾⿻⺁䜣€ '
        /// </param>
        void PutMbcs(string stringBody);

        /// <summary>
        /// Set string value mbcs '啊齄丂狛狜隣郎隣兀﨩ˊ▇█〞〡￤℡㈱‐ー﹡﹢﹫、〓ⅰⅹ⒈€㈠㈩ⅠⅫ！￣ぁんァヶΑ︴АЯаяāɡㄅㄩ─╋︵﹄︻︱︳︴ⅰⅹɑɡ〇〾⿻⺁䜣€ '
        /// </summary>
        /// <param name='stringBody'>
        /// Possible values include: '啊齄丂狛狜隣郎隣兀﨩ˊ▇█〞〡￤℡㈱‐ー﹡﹢﹫、〓ⅰⅹ⒈€㈠㈩ⅠⅫ！￣ぁんァヶΑ︴АЯаяāɡㄅㄩ─╋︵﹄︻︱︳︴ⅰⅹɑɡ〇〾⿻⺁䜣€ '
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task PutMbcsAsync(string stringBody, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Get string value with leading and trailing whitespace '&lt;tab&gt;&lt;space&gt;&lt;space&gt;Now is the time for all
        /// good men to come to the aid of their country&lt;tab&gt;&lt;space&gt;&lt;space&gt;'
        /// </summary>
        string GetWhitespace();

        /// <summary>
        /// Get string value with leading and trailing whitespace '&lt;tab&gt;&lt;space&gt;&lt;space&gt;Now is the time for all
        /// good men to come to the aid of their country&lt;tab&gt;&lt;space&gt;&lt;space&gt;'
        /// </summary>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<string> GetWhitespaceAsync(CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Set String value with leading and trailing whitespace '&lt;tab&gt;&lt;space&gt;&lt;space&gt;Now is the time for all
        /// good men to come to the aid of their country&lt;tab&gt;&lt;space&gt;&lt;space&gt;'
        /// </summary>
        /// <param name='stringBody'>
        /// Possible values include: '    Now is the time for all good men to come to the aid of their country    '
        /// </param>
        void PutWhitespace(string stringBody);

        /// <summary>
        /// Set String value with leading and trailing whitespace '&lt;tab&gt;&lt;space&gt;&lt;space&gt;Now is the time for all
        /// good men to come to the aid of their country&lt;tab&gt;&lt;space&gt;&lt;space&gt;'
        /// </summary>
        /// <param name='stringBody'>
        /// Possible values include: '    Now is the time for all good men to come to the aid of their country    '
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task PutWhitespaceAsync(string stringBody, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Get String value when no string value is sent in response payload
        /// </summary>
        string GetNotProvided();

        /// <summary>
        /// Get String value when no string value is sent in response payload
        /// </summary>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<string> GetNotProvidedAsync(CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Get value that is base64 encoded
        /// </summary>
        byte[] GetBase64Encoded();

        /// <summary>
        /// Get value that is base64 encoded
        /// </summary>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<byte[]> GetBase64EncodedAsync(CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Get value that is base64url encoded
        /// </summary>
        byte[] GetBase64UrlEncoded();

        /// <summary>
        /// Get value that is base64url encoded
        /// </summary>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<byte[]> GetBase64UrlEncodedAsync(CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Put value that is base64url encoded
        /// </summary>
        /// <param name='stringBody'>
        /// </param>
        void PutBase64UrlEncoded(byte[] stringBody);

        /// <summary>
        /// Put value that is base64url encoded
        /// </summary>
        /// <param name='stringBody'>
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task PutBase64UrlEncodedAsync(byte[] stringBody, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Get null value that is expected to be base64url encoded
        /// </summary>
        byte[] GetNullBase64UrlEncoded();

        /// <summary>
        /// Get null value that is expected to be base64url encoded
        /// </summary>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<byte[]> GetNullBase64UrlEncodedAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}

import "@azure-tools/typespec-azure-core";
import "@typespec/http";
import "@typespec/rest";

using TypeSpec.Http;
using TypeSpec.Rest;
using Azure.Core;

@service({
    title: "SimplePost",
})
   
namespace SimplePost;
   
interface SimplePostClient {
    @post @route("add") IncrementCount(@path addend: int32) : int32;
}
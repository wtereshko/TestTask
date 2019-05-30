using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;

namespace TestTask.Tools
{
    public class JSONNegotiator : DefaultContentNegotiator
    {
        public override ContentNegotiationResult Negotiate(Type type,
        HttpRequestMessage request, IEnumerable<MediaTypeFormatter> formatters)
        {
            return new ContentNegotiationResult(new JsonMediaTypeFormatter(),
                       new MediaTypeHeaderValue("application/json"));
        }
    }
}
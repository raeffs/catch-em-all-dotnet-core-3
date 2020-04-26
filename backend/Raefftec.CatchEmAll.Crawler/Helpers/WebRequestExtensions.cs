using System.Net;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace Raefftec.CatchEmAll
{
    internal static class WebRequestExtensions
    {
        public static async Task<HtmlDocument> GetHtmlDocumentAsync(this WebRequest request)
        {
            var response = await request.GetResponseAsync();
            var document = new HtmlDocument();
            using var stream = response.GetResponseStream();
            document.Load(stream);
            return document;
        }
    }
}

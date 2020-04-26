using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Raefftec.CatchEmAll
{
    internal class Crawler : ICrawler
    {
        public async Task<AnalyzeSearchPageResult> AnalyzeSearchPageAsync(AnalyzeSearchPageArguments arguments)
        {
            var url = string.Format("https://www.ricardo.ch/de/s/{0}?sort=newest", Uri.EscapeDataString(arguments.SearchTerm));
            var data = await this.FetchAndParsePage<Models.SearchPageDataJson>(url);
            var entries = data?.InitialState?.Srp?.Results;

            if (entries == null)
            {
                return new AnalyzeSearchPageResult();
            }

            var articles = entries.Select(x => new ArticleData
            {
                Id = x.Id,
                Name = x.Title ?? string.Empty,
                Created = x.CreationDate,
                Ends = x.EndDate,
                PurchasePrice = x.BuyNowPrice,
                BidPrice = x.BidPrice
            });

            return new AnalyzeSearchPageResult
            {
                Articles = articles
            };
        }

        public async Task<AnalyzeArticlePageResult> AnalyzeArticlePageAsync(AnalyzeArticlePageArguments arguments)
        {
            // the url copied from the browser is human readable, but the human readable part can be omitted
            var url = string.Format("https://www.ricardo.ch/de/a/{0}/", arguments.ExternalId);
            var data = await this.FetchAndParsePage<Models.ArticlePageDataJson>(url);
            var articleData = data?.InitialState?.Pdp?.Article;
            var bidData = data?.InitialState?.Pdp?.Bid;

            if (articleData == null)
            {
                // todo: add proper exceptions
                throw new Exception();
            }

            if (articleData.Id != articleData.ProductId)
            {
                // todo: not sure yet what that could mean
                throw new Exception();
            }

            return new AnalyzeArticlePageResult
            {
                Article = new ArticleData
                {
                    Id = articleData.Id,
                    Name = articleData.Title ?? string.Empty,
                    Created = articleData.CreationDate,
                    Ends = articleData.EndDate,
                    IsClosed = articleData.Status != 0,
                    PurchasePrice = articleData.Offer?.Price,
                    BidPrice = bidData?.Data?.NextMinimumBid,
                }
            };
        }

        private async Task<T> FetchAndParsePage<T>(string url)
        {
            var document = await WebRequest.Create(url).GetHtmlDocumentAsync();
            // the HTML contains an inline script that contains the initial data for the page for SEO / prerendering purposes
            // so we get that script and extract the data JSON -> much easier than parsing the HTML
            // todo: the JSON also contains the Firebase settings, maybe it would be even easier to just connect to the Firebase database directly...
            var scriptContent = document.DocumentNode.SelectSingleNode(".//script[contains(text(), 'window.ricardo=')]").InnerHtml;
            // we just strip off all the non-JSON stuff
            var jsonContent = scriptContent.Replace("window.ricardo=", string.Empty).TrimEnd(';');
            // and parse the JSON
            return JsonConvert.DeserializeObject<T>(jsonContent);
        }
    }
}

using System.Threading.Tasks;

namespace Raefftec.CatchEmAll
{
    public interface ICrawler
    {
        public Task<AnalyzeSearchPageResult> AnalyzeSearchPageAsync(AnalyzeSearchPageArguments arguments);

        public Task<AnalyzeArticlePageResult> AnalyzeArticlePageAsync(AnalyzeArticlePageArguments arguments);
    }
}
